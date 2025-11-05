using abchotel.BLL;
using OfficeOpenXml;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;
// 1. Trong Solution Explorer, click chuột phải vào mục "References" của dự án abchotel.
// 2. Chọn "Add Reference..."
// 3. Một cửa sổ mới sẽ hiện ra. Chọn tab "COM" (ở bên trái).
// 4. Tìm trong danh sách "Microsoft Excel 16.0 Object Library" (con số 16.0 có thể là 15.0, 14.0... tùy vào phiên bản Office bạn cài).
// 5. Đánh dấu tick vào nó và nhấn OK.
//
namespace abchotel
{
    public partial class FormReport : Form
    {
        private ReportBLL reportBLL = new ReportBLL();
        public FormReport()
        {
            InitializeComponent();
            LoadReportForm();
        }
        private void LoadReportForm()
        {
            // Thêm các lựa chọn vào ComboBox
            cboloaibc.Items.Add("Theo ngày");
            cboloaibc.Items.Add("Theo tháng");
            cboloaibc.Items.Add("Theo năm");
            cboloaibc.SelectedIndex = 0; // Chọn "Theo ngày" làm mặc định

            // Định dạng DateTimePicker
            dtfrom.CustomFormat = "dd/MM/yyyy";
            dtfrom.Format = DateTimePickerFormat.Custom;
            dtto.CustomFormat = "dd/MM/yyyy";
            dtto.Format = DateTimePickerFormat.Custom;

            // Đặt ngày mặc định (ví dụ: ngày đầu tháng và ngày hiện tại)
            dtfrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtto.Value = DateTime.Now;

            // Xóa dữ liệu mẫu và thiết lập trạng thái ban đầu
            ClearReportData();
        }

        private void ClearReportData()
        {
            lblvaluesdthu.Text = "0 VND";
            lblvaluessohoadon.Text = "0";
            dgvdt.DataSource = null;
            chdthu.Series.Clear();
            chdthu.Titles.Clear();
            chdthu.Titles.Add("Biểu đồ doanh thu");
        }

        private void btntk_Click(object sender, EventArgs e)
        {
            try
            {
                string reportType = cboloaibc.SelectedItem.ToString();
                DateTime fromDate = dtfrom.Value;
                DateTime toDate = dtto.Value;

                // Thêm 1 ngày vào toDate để bao gồm cả ngày kết thúc
                // (Vì SQL BETWEEN thường tính đến 00:00:00 của ngày)
                toDate = toDate.AddDays(1).AddSeconds(-1);


                if (fromDate > toDate)
                {
                    // Thay vì MessageBox, ta có thể dùng một Label để thông báo lỗi
                    // (Giả sử bạn có một lblError trên form)
                    // lblError.Text = "Ngày bắt đầu không được lớn hơn ngày kết thúc.";
                    // Hoặc đơn giản là không làm gì cả
                    return;
                }

                // Gọi BLL để lấy dữ liệu
                DataTable dt = reportBLL.LayDuLieuBaoCao(reportType, fromDate, toDate);

                // 1. Hiển thị dữ liệu lên DataGridView
                dgvdt.DataSource = dt;
                FormatDataGridView();

                // 2. Tính toán và hiển thị tổng
                decimal tongDoanhThu = 0;
                int tongHoaDon = 0;

                if (dt.Rows.Count > 0)
                {
                    // Dùng LINQ để tính tổng từ DataTable
                    tongDoanhThu = dt.AsEnumerable().Sum(row => row.Field<decimal>("DoanhThu"));
                    tongHoaDon = dt.AsEnumerable().Sum(row => row.Field<int>("SoHoaDon"));
                }

                lblvaluesdthu.Text = string.Format(new CultureInfo("vi-VN"), "{0:N0} VND", tongDoanhThu);
                lblvaluessohoadon.Text = tongHoaDon.ToString();

                // 3. Vẽ biểu đồ
                PopulateChart(dt, reportType);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi (ví dụ: ghi log, hiển thị thông báo)
                // (Tránh dùng MessageBox nếu theo yêu cầu)
                Console.WriteLine("Lỗi khi xem báo cáo: " + ex.Message);
            }
        }
        private void FormatDataGridView()
        {
            if (dgvdt.Columns.Contains("ThoiGian"))
            {
                dgvdt.Columns["ThoiGian"].HeaderText = "Thời gian";
            }
            if (dgvdt.Columns.Contains("DoanhThu"))
            {
                dgvdt.Columns["DoanhThu"].HeaderText = "Doanh Thu";
                dgvdt.Columns["DoanhThu"].DefaultCellStyle.Format = "N0"; // Định dạng số
            }
            if (dgvdt.Columns.Contains("SoHoaDon"))
            {
                dgvdt.Columns["SoHoaDon"].HeaderText = "Số hóa đơn";
            }
            dgvdt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void PopulateChart(DataTable dt, string reportType)
        {
            chdthu.Series.Clear();
            chdthu.Titles.Clear();
            chdthu.Titles.Add($"Biểu đồ doanh thu {reportType.ToLower()}");

            Series series = chdthu.Series.Add("Doanh thu");
            series.ChartType = SeriesChartType.Column;
            series.IsValueShownAsLabel = true; // Hiển thị giá trị trên cột
            series.LabelFormat = "N0";

            // Đặt tên cho trục X
            chdthu.ChartAreas[0].AxisX.Title = "Thời gian";
            chdthu.ChartAreas[0].AxisY.Title = "Doanh thu (VND)";

            // Thêm dữ liệu vào biểu đồ
            foreach (DataRow row in dt.Rows)
            {
                string thoiGian = row["ThoiGian"].ToString();
                decimal doanhThu = Convert.ToDecimal(row["DoanhThu"]);
                series.Points.AddXY(thoiGian, doanhThu);
            }

            // Điều chỉnh hiển thị nhãn trục X nếu có quá nhiều
            if (dt.Rows.Count > 10)
            {
                chdthu.ChartAreas[0].AxisX.Interval = Math.Max(1, dt.Rows.Count / 10);
                chdthu.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            }
            else
            {
                chdthu.ChartAreas[0].AxisX.Interval = 1;
                chdthu.ChartAreas[0].AxisX.LabelStyle.Angle = 0;
            }
        }

        private void btnxuat_Click(object sender, EventArgs e)
        {
            if (dgvdt.Rows.Count == 0)
            {
                // Không có dữ liệu để xuất
                return;
            }

            // Hiển thị hộp thoại SaveFile
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Lưu file Excel";
            saveFileDialog.FileName = $"BaoCaoDoanhThu_{DateTime.Now:ddMMyyyy_HHmmss}.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToExcel(dgvdt, saveFileDialog.FileName);
            }
        }
        private void ExportToExcel(DataGridView dgv, string filePath)
        {
            Excel.Application excelApp = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                excelApp = new Excel.Application();
                if (excelApp == null)
                {
                    // "Excel is not properly installed!!"
                    return;
                }

                excelApp.Visible = false; // Không hiển thị Excel
                workbook = excelApp.Workbooks.Add(Type.Missing);
                worksheet = (Excel.Worksheet)workbook.Sheets[1];
                worksheet.Name = "BaoCaoDoanhThu";

                // 1. Thêm tiêu đề
                string reportType = cboloaibc.SelectedItem.ToString();
                string fromDate = dtfrom.Value.ToString("dd/MM/yyyy");
                string toDate = dtto.Value.ToString("dd/MM/yyyy");
                string title = $"BÁO CÁO DOANH THU {reportType.ToUpper()} (Từ {fromDate} đến {toDate})";

                Excel.Range titleRange = worksheet.Range[worksheet.Cells[1, 1], worksheet.Cells[1, dgv.Columns.Count]];
                titleRange.Merge();
                titleRange.Value = title;
                titleRange.Font.Bold = true;
                titleRange.Font.Size = 16;
                titleRange.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;

                // 2. Thêm tiêu đề cột (Header) từ DataGridView
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    worksheet.Cells[3, i + 1] = dgv.Columns[i].HeaderText;
                    Excel.Range headerCell = (Excel.Range)worksheet.Cells[3, i + 1];
                    headerCell.Font.Bold = true;
                    headerCell.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    headerCell.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                }

                // 3. Thêm dữ liệu
                for (int i = 0; i < dgv.Rows.Count; i++)
                {
                    for (int j = 0; j < dgv.Columns.Count; j++)
                    {
                        // Ghi giá trị vào ô
                        worksheet.Cells[i + 4, j + 1] = dgv.Rows[i].Cells[j].Value?.ToString();

                        // Áp dụng định dạng
                        if (dgv.Columns[j].Name == "DoanhThu")
                        {
                            // Định dạng số cho cột DoanhThu
                            ((Excel.Range)worksheet.Cells[i + 4, j + 1]).NumberFormat = "#,##0";
                        }

                        ((Excel.Range)worksheet.Cells[i + 4, j + 1]).Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    }
                }

                // 4. Thêm tổng kết
                int totalRowIndex = dgv.Rows.Count + 5; // Dòng sau dòng dữ liệu cuối
                worksheet.Cells[totalRowIndex, 1] = "TỔNG CỘNG";
                ((Excel.Range)worksheet.Cells[totalRowIndex, 1]).Font.Bold = true;

                // Tính tổng doanh thu và số hóa đơn
                // (Giả sử cột 1 là "Thời gian", 2 là "DoanhThu", 3 là "SoHoaDon")
                if (dgv.Columns.Contains("DoanhThu") && dgv.Columns["DoanhThu"].Index == 1)
                {
                    Excel.Range totalRevenueCell = (Excel.Range)worksheet.Cells[totalRowIndex, 2];
                    totalRevenueCell.Formula = $"=SUM(B4:B{totalRowIndex - 2})";
                    totalRevenueCell.NumberFormat = "#,##0";
                    totalRevenueCell.Font.Bold = true;
                }

                if (dgv.Columns.Contains("SoHoaDon") && dgv.Columns["SoHoaDon"].Index == 2)
                {
                    Excel.Range totalInvoiceCell = (Excel.Range)worksheet.Cells[totalRowIndex, 3];
                    totalInvoiceCell.Formula = $"=SUM(C4:C{totalRowIndex - 2})";
                    totalInvoiceCell.NumberFormat = "0";
                    totalInvoiceCell.Font.Bold = true;
                }

                // Tự động điều chỉnh độ rộng cột
                worksheet.Columns.AutoFit();

                // Lưu workbook
                workbook.SaveAs(filePath);
            }
            catch (Exception ex)
            {
                // "Error exporting to Excel: " + ex.Message
                Console.WriteLine("Lỗi khi xuất Excel: " + ex.Message);
            }
            finally
            {
                // Đóng và giải phóng tài nguyên COM
                if (workbook != null) workbook.Close(false, Type.Missing, Type.Missing);
                if (excelApp != null) excelApp.Quit();

                ReleaseObject(worksheet);
                ReleaseObject(workbook);
                ReleaseObject(excelApp);
            }
        }
        private void ReleaseObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
