using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using OfficeOpenXml;

namespace abchotel
{
    public partial class FormReport : Form
    {
        string connectionString = @"Data Source=ANHENHS\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True";

        public FormReport()
        {
            InitializeComponent();

            // 🔹 Đảm bảo ComboBox đã được khởi tạo trước khi thêm items
            if (cboloaibc != null)
            {
                cboloaibc.Items.Add("Theo ngày");
                cboloaibc.Items.Add("Theo tháng");
                cboloaibc.SelectedIndex = 0;

                // 🔹 Thêm sự kiện SelectedIndexChanged
                cboloaibc.SelectedIndexChanged += Cboloaibc_SelectedIndexChanged;
            }
        }

        private void FormReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            // Thiết lập ngày mặc định
            dtfrom.Value = new DateTime(DateTime.Now.Year, 1, 1);
            dtto.Value = DateTime.Now;

            // Load báo cáo ngay lần đầu
            LoadReport();
        }

        private void Cboloaibc_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReport(); // Gọi lại báo cáo khi đổi ComboBox
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
                WHERE NgayLap BETWEEN @from AND @to AND ThanhTien IS NOT NULL
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
                WHERE NgayLap BETWEEN @from AND @to AND ThanhTien IS NOT NULL
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

                dgvdt.DataSource = dt;
                FormatGridDoanhThu();

                LoadChart(dt, xField);
                LoadSummary(dt);
            }
        }

        void FormatGridDoanhThu()
        {
            dgvdt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvdt.RowHeadersVisible = false;
            dgvdt.BackgroundColor = System.Drawing.Color.White;

            dgvdt.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(10, 35, 66);
            dgvdt.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvdt.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvdt.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 10, System.Drawing.FontStyle.Bold);

            dgvdt.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight; // căn phải số
            dgvdt.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightBlue;
            dgvdt.EnableHeadersVisualStyles = false;

            if (dgvdt.Columns.Contains("DoanhThu"))
                dgvdt.Columns["DoanhThu"].DefaultCellStyle.Format = "N0"; // 90.000
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
                total += row["DoanhThu"] != DBNull.Value ? (decimal)row["DoanhThu"] : 0;
                count += row["SoHoaDon"] != DBNull.Value ? Convert.ToInt32(row["SoHoaDon"]) : 0;
            }

            CultureInfo vn = new CultureInfo("vi-VN");
            lblvaluesdthu.Text = total.ToString("N0", vn) + " VNĐ";
            lblvaluesdthu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

            lblvaluessohoadon.Text = count + " hóa đơn";
            lblvaluessohoadon.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
        }
        private void FormReport_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát?",
                "Xác nhận thoát", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.No)
                e.Cancel = true;
        }

        private void btnxuat_Click(object sender, EventArgs e)
        {
            if (dgvdt.Rows.Count == 0)
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
                    for (int i = 0; i < dgvdt.Columns.Count; i++)
                    {
                        ws.Cells[1, i + 1].Value = dgvdt.Columns[i].HeaderText;
                        ws.Cells[1, i + 1].Style.Font.Bold = true;
                    }

                    // Dữ liệu
                    for (int r = 0; r < dgvdt.Rows.Count; r++)
                    {
                        for (int c = 0; c < dgvdt.Columns.Count; c++)
                        {
                            ws.Cells[r + 2, c + 1].Value =
                                dgvdt.Rows[r].Cells[c].Value?.ToString();
                        }
                    }

                    File.WriteAllBytes(save.FileName, excel.GetAsByteArray());
                    MessageBox.Show("Xuất Excel thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void lblfrom_Click(object sender, EventArgs e)
        {

        }

        private void lblto_Click(object sender, EventArgs e)
        {

        }

        private void dtto_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
