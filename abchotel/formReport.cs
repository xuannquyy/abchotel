using abchotel.BLL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace abchotel
{
    public partial class FormReport : Form
    {
        private ReportBLL reportBLL = new ReportBLL();
        public FormReport()
        {
            InitializeComponent();
            OfficeOpenXml.ExcelPackage.License.SetNonCommercialPersonal("Khai Bao Su Dung");
            LoadReportForm();
        }
        private void LoadReportForm()
        {
            // Thêm các lựa chọn vào ComboBox
            cboloaibc.Items.Add("Theo ngày");
            cboloaibc.Items.Add("Theo tháng");
            cboloaibc.Items.Add("Theo năm");
            cboloaibc.SelectedIndex = 0; // Chọn "Theo ngày" làm mặc định

            cboloaibc.SelectedIndexChanged += cboloaibc_SelectedIndexChanged;

            dtfrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtto.Value = DateTime.Now;

            // Kích hoạt sự kiện lần đầu
            cboloaibc_SelectedIndexChanged(null, null);

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

                if (reportType == "Theo tháng")
                {
                    // Lấy ngày 1 của tháng bắt đầu
                    fromDate = new DateTime(fromDate.Year, fromDate.Month, 1);
                    // Lấy ngày cuối của tháng kết thúc
                    toDate = new DateTime(toDate.Year, toDate.Month, DateTime.DaysInMonth(toDate.Year, toDate.Month));
                }
                else if (reportType == "Theo năm")
                {
                    // Lấy ngày 1/1 của năm bắt đầu
                    fromDate = new DateTime(fromDate.Year, 1, 1);
                    // Lấy ngày 31/12 của năm kết thúc
                    toDate = new DateTime(toDate.Year, 12, 31);
                }

                toDate = toDate.Date.AddDays(1).AddSeconds(-1);

                if (fromDate > toDate)
                {
                    MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DataTable dt = reportBLL.LayDuLieuBaoCao(reportType, fromDate, toDate);

                dgvdt.DataSource = dt;
                FormatDataGridView();

                decimal tongDoanhThu = 0;
                int tongHoaDon = 0;

                if (dt.Rows.Count > 0)
                {
                    tongDoanhThu = dt.AsEnumerable().Sum(row => row.Field<decimal>("DoanhThu"));
                    tongHoaDon = dt.AsEnumerable().Sum(row => row.Field<int>("SoHoaDon"));
                }

                lblvaluesdthu.Text = string.Format(new CultureInfo("vi-VN"), "{0:N0} VND", tongDoanhThu);
                lblvaluessohoadon.Text = tongHoaDon.ToString();

                PopulateChart(dt, reportType);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xem báo cáo: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            FileInfo file = new FileInfo(filePath);
            using (ExcelPackage package = new ExcelPackage(file))
            {
                ExcelWorksheet ws = package.Workbook.Worksheets.Add("BaoCaoDoanhThu");

                // 1. Thêm tiêu đề
                string reportType = cboloaibc.SelectedItem.ToString();
                string fromDate = dtfrom.Value.ToString("dd/MM/yyyy");
                string toDate = dtto.Value.ToString("dd/MM/yyyy");
                string title = $"BÁO CÁO DOANH THU {reportType.ToUpper()} (Từ {fromDate} đến {toDate})";

                ws.Cells["A1"].Value = title;
                ws.Cells["A1:C1"].Merge = true;
                ws.Cells["A1"].Style.Font.Bold = true;
                ws.Cells["A1"].Style.Font.Size = 16;
                ws.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // 2. Thêm tổng quan
                ws.Cells["A3"].Value = "Tổng doanh thu:";
                ws.Cells["B3"].Value = lblvaluesdthu.Text;
                ws.Cells["A4"].Value = "Tổng số hóa đơn:";
                ws.Cells["B4"].Value = lblvaluessohoadon.Text;
                ws.Cells["A3:A4"].Style.Font.Bold = true;

                // 3. Tải dữ liệu từ DataTable (Nguồn của DataGridView)
                DataTable dt = (DataTable)dgv.DataSource;
                ws.Cells["A6"].LoadFromDataTable(dt, true); // true = chèn tiêu đề cột

                // 4. Định dạng
                using (ExcelRange headers = ws.Cells["A6:C6"])
                {
                    headers.Style.Font.Bold = true;
                    headers.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    headers.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                }

                // Định dạng cột DoanhThu
                if (dt.Columns.Contains("DoanhThu"))
                {
                    int doanhThuColIndex = dt.Columns["DoanhThu"].Ordinal + 1;
                    ws.Column(doanhThuColIndex).Style.Numberformat.Format = "#,##0";
                }

                // 5. Thêm dòng tổng
                int totalRow = dt.Rows.Count + 7; // (A6 là header, +1)
                ws.Cells[totalRow, 1].Value = "TỔNG CỘNG";
                ws.Cells[totalRow, 1].Style.Font.Bold = true;

                ws.Cells[totalRow, 2].Formula = $"SUM(B7:B{totalRow - 1})";
                ws.Cells[totalRow, 2].Style.Numberformat.Format = "#,##0";
                ws.Cells[totalRow, 2].Style.Font.Bold = true;

                ws.Cells[totalRow, 3].Formula = $"SUM(C7:C{totalRow - 1})";
                ws.Cells[totalRow, 3].Style.Numberformat.Format = "0";
                ws.Cells[totalRow, 3].Style.Font.Bold = true;

                ws.Cells[ws.Dimension.Address].AutoFitColumns();
                package.Save();
            }
        }

        private void cboloaibc_SelectedIndexChanged(object sender, EventArgs e)
        {
            string reportType = cboloaibc.SelectedItem.ToString();

            if (reportType == "Theo ngày")
            {
                dtfrom.CustomFormat = "dd/MM/yyyy";
                dtto.CustomFormat = "dd/MM/yyyy";
                dtfrom.ShowUpDown = false;
                dtto.ShowUpDown = false;

                // Đặt lại ngày
                dtfrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                dtto.Value = DateTime.Now;
            }
            else if (reportType == "Theo tháng")
            {
                dtfrom.CustomFormat = "MM / yyyy";
                dtto.CustomFormat = "MM / yyyy";
                dtfrom.ShowUpDown = true; // Chỉ hiện tháng/năm
                dtto.ShowUpDown = true;

                // Đặt lại ngày
                dtfrom.Value = new DateTime(DateTime.Now.Year, 1, 1); // Tháng 1
                dtto.Value = DateTime.Now; // Tháng hiện tại
            }
            else if (reportType == "Theo năm")
            {
                dtfrom.CustomFormat = "yyyy";
                dtto.CustomFormat = "yyyy";
                dtfrom.ShowUpDown = true; // Chỉ hiện năm
                dtto.ShowUpDown = true;

                // Đặt lại ngày
                dtfrom.Value = new DateTime(DateTime.Now.Year - 1, 1, 1); // Năm ngoái
                dtto.Value = DateTime.Now; // Năm nay
            }
        }
    }
}
