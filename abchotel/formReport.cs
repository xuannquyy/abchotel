using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using OfficeOpenXml;
using System.IO;


namespace abchotel
{
    public partial class FormReport : Form
    {
        string connectionString = @"Data Source=ANHENHS\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True";

        public FormReport()
        {
            InitializeComponent();
        }

        private void formReport_Load(object sender, EventArgs e)
        {
            cboloaibc.Items.Add("Theo ngày");
            cboloaibc.Items.Add("Theo tháng");
            cboloaibc.SelectedIndex = 0;

            dtfrom.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtto.Value = DateTime.Now;
        }

        private void btntk_Click(object sender, EventArgs e)
        {
            LoadReport();
        }

        void LoadReport()
        {
            if (cboloaibc.SelectedIndex == 0)
                ThongKeTheoNgay();
            else
                ThongKeTheoThang();
        }

        void ThongKeTheoNgay()
        {
            string query = @"
                SELECT NgayLap AS Ngay, 
                       SUM(ThanhTien) AS DoanhThu, 
                       COUNT(*) AS SoHoaDon
                FROM HoaDon
                WHERE NgayLap BETWEEN @from AND @to
                GROUP BY NgayLap
                ORDER BY NgayLap";

            LoadData(query, "Ngay");
        }

        void ThongKeTheoThang()
        {
            string query = @"
                SELECT FORMAT(NgayLap, 'MM/yyyy') AS Thang,
                       SUM(ThanhTien) AS DoanhThu,
                       COUNT(*) AS SoHoaDon
                FROM HoaDon
                WHERE NgayLap BETWEEN @from AND @to
                GROUP BY FORMAT(NgayLap, 'MM/yyyy')
                ORDER BY MIN(NgayLap)";

            LoadData(query, "Thang");
        }

        void LoadData(string query, string xField)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                da.SelectCommand.Parameters.AddWithValue("@from", dtfrom.Value);
                da.SelectCommand.Parameters.AddWithValue("@to", dtto.Value);

                DataTable dt = new DataTable();
                da.Fill(dt);

                dgvdoanhthu.DataSource = dt; // ✅ Thêm để hiển thị chi tiết
                LoadChart(dt, xField);
                LoadSummary(dt);
            }
        }
        void LoadChart(DataTable dt, string xField)
        {
            chdthu.Series.Clear();
            var series = chdthu.Series.Add("Doanh thu");
            series.ChartType = SeriesChartType.Column;

            foreach (DataRow row in dt.Rows)
            {
                series.Points.AddXY(row[xField], Convert.ToDouble(row["DoanhThu"]));
            }
        }

        void LoadSummary(DataTable dt)
        {
            decimal total = 0;
            int count = 0;

            foreach (DataRow row in dt.Rows)
            {
                total += Convert.ToDecimal(row["DoanhThu"]);
                count += Convert.ToInt32(row["SoHoaDon"]);
            }

            lblvaluesdthu.Text = total.ToString("N0") + " VNĐ";
            lblvaluessohoadon.Text = count.ToString();
        }

        private void formReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát?", "Xác nhận thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvdoanhthu.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo");
                return;
            }

            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Excel file|*.xlsx";
            save.FileName = "BaoCaoDoanhThu.xlsx";

            if (save.ShowDialog() == DialogResult.OK)
            {

                using (ExcelPackage excel = new ExcelPackage())
                {
                    var ws = excel.Workbook.Worksheets.Add("Report");

                    // Tiêu đề
                    for (int i = 0; i < dgvdoanhthu.Columns.Count; i++)
                    {
                        ws.Cells[1, i + 1].Value = dgvdoanhthu.Columns[i].HeaderText;
                        ws.Cells[1, i + 1].Style.Font.Bold = true;
                    }

                    // Dữ liệu
                    for (int r = 0; r < dgvdoanhthu.Rows.Count; r++)
                    {
                        for (int c = 0; c < dgvdoanhthu.Columns.Count; c++)
                        {
                            ws.Cells[r + 2, c + 1].Value =
                                dgvdoanhthu.Rows[r].Cells[c].Value?.ToString();
                        }
                    }

                    File.WriteAllBytes(save.FileName, excel.GetAsByteArray());
                    MessageBox.Show("Xuất Excel thành công!", "Thông báo");
                }
            }
        }
    }
}