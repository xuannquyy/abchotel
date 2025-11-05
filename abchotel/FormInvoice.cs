using abchotel.DAL;
using abchotel.BLL;
using abchotel.Model;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using OfficeOpenXml;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Linq;

namespace abchotel
{
    public partial class FormInvoice : Form
    {
        private HoaDonBLL hdBLL = new HoaDonBLL();
        private CultureInfo vn = new CultureInfo("vi-VN");

        public FormInvoice()
        {
            InitializeComponent();
            Load += FormInvoice_Load;
            // NOTE QUAN TRỌNG: Đảm bảo TextBox Giảm giá (txtgiamgia) đã được gán sự kiện 
            // TextChanged trỏ đến hàm txtgiamgia_TextChanged trong Form Designer.
        }

        private void FormInvoice_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            LoadHoaDon();
        }

        private void LoadHoaDon()
        {
            DataTable dtHD = hdBLL.LayDanhSachDatPhongChuaThanhToan();
            if (dtHD == null || dtHD.Rows.Count == 0) return;

            DataRow hdRow = dtHD.Rows[0];
            int maHoaDon = Convert.ToInt32(hdRow["MaHoaDon"]);
            int maDatPhong = Convert.ToInt32(hdRow["MaDatPhong"]);

            txtma.Text = maHoaDon.ToString();

            string queryThongTin = "SELECT KH.HoTen, P.SoPhong, DP.NgayNhan, DP.NgayTra " +
                                   "FROM DatPhong DP " +
                                   "JOIN KhachHang KH ON DP.MaKhachHang = KH.MaKhachHang " +
                                   "JOIN Phong P ON DP.MaPhong = P.MaPhong " +
                                   "WHERE DP.MaDatPhong = @MaDP";

            DataTable dtInfo = DatabaseHelper.GetData(queryThongTin, ("@MaDP", maDatPhong));

            if (dtInfo.Rows.Count > 0)
            {
                DataRow infoRow = dtInfo.Rows[0];
                txtten.Text = infoRow["HoTen"].ToString();
                txtphong.Text = infoRow["SoPhong"].ToString();
                txttungay.Text = Convert.ToDateTime(infoRow["NgayNhan"]).ToShortDateString();
                txtdenngay.Text = Convert.ToDateTime(infoRow["NgayTra"]).ToShortDateString();
            }

            LoadChiTietHoaDon(maHoaDon);
        }

        // --- HÀM CĂN CHỈNH DATAGRIDVIEW (Đã giữ lại từ lần sửa trước) ---
        private void FormatDGV(DataGridView dgv)
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.HeaderText == "Thành Tiền" || col.HeaderText == "Số Đêm" || col.HeaderText == "Số Lượng")
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    if (col.HeaderText == "Thành Tiền")
                    {
                        col.DefaultCellStyle.Format = "N0";
                    }
                }
                else
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }
            }
        }
        // ----------------------------------------

        private void LoadChiTietHoaDon(int maHoaDon)
        {
            // Query cho Chi phí phòng (gồm Loại Phòng, Số Đêm, Thành Tiền)
            string queryPhong = @"
                SELECT 
                    P.LoaiPhong, 
                    DATEDIFF(day, DP.NgayNhan, DP.NgayTra) AS SoDem,
                    DP.TongTien AS ThanhTien
                FROM DatPhong DP
                INNER JOIN Phong P ON DP.MaPhong = P.MaPhong
                INNER JOIN HoaDon HD ON HD.MaDatPhong = DP.MaDatPhong
                WHERE HD.MaHoaDon = @MaHD";

            dgvcpp.DataSource = DatabaseHelper.GetData(queryPhong, ("@MaHD", maHoaDon));
            FormatDGV(dgvcpp);

            // Query cho Chi phí dịch vụ
            string queryDV = @"
                SELECT 
                    DV.TenDichVu, 
                    CTDV.SoLuong,
                    CTDV.ThanhTien
                FROM ChiTietDichVu CTDV
                INNER JOIN DichVu DV ON CTDV.MaDichVu = DV.MaDichVu
                WHERE CTDV.MaHoaDon = @MaHD";

            dgvcpdv.DataSource = DatabaseHelper.GetData(queryDV, ("@MaHD", maHoaDon));
            FormatDGV(dgvcpdv);

            CapNhatTongTien();
        }

        private void CapNhatTongTien()
        {
            decimal tienPhong = 0;
            decimal tienDV = 0;

            // Tính tiền phòng
            foreach (DataGridViewRow row in dgvcpp.Rows)
                if (row.Cells["ThanhTien"].Value != null && row.Cells["ThanhTien"].Value != DBNull.Value)
                    tienPhong += Convert.ToDecimal(row.Cells["ThanhTien"].Value);

            // Tính tiền dịch vụ
            foreach (DataGridViewRow row in dgvcpdv.Rows)
                if (row.Cells["ThanhTien"].Value != null && row.Cells["ThanhTien"].Value != DBNull.Value)
                    tienDV += Convert.ToDecimal(row.Cells["ThanhTien"].Value);

            txttienphong.Text = tienPhong.ToString("N0", vn);
            txttiendv.Text = tienDV.ToString("N0", vn);

            decimal tongTamTinh = tienPhong + tienDV;
            lbltongtam.Text = $"Tổng tạm tính: {tongTamTinh:N0} VNĐ";

            // 🌟 LOGIC ĐÃ SỬA: XỬ LÝ GIẢM GIÁ % HOẶC TIỀN MẶT 🌟
            decimal giamgia = 0;
            string discountText = txtgiamgia.Text.Trim();

            if (discountText.EndsWith("%"))
            {
                // Giảm giá theo %
                string percentValue = discountText.TrimEnd('%');
                decimal percent = 0;

                if (decimal.TryParse(percentValue, NumberStyles.Any, vn, out percent))
                {
                    if (percent > 0 && percent <= 100)
                    {
                        giamgia = tongTamTinh * (percent / 100m);
                    }
                }
            }
            else
            {
                // Giảm giá theo số tiền cố định
                decimal.TryParse(discountText, NumberStyles.Any, vn, out giamgia);
            }
            // -------------------------------------------------------------

            decimal tongCong = tongTamTinh - giamgia;
            lbltongcong.Text = $"Tổng cộng: {tongCong:N0} VNĐ";
        }

        private void txtgiamgia_TextChanged_1(object sender, EventArgs e)
        {
            CapNhatTongTien();
        }
        private void btnexcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog
            {
                Filter = "Excel file|*.xlsx",
                FileName = "HoaDon.xlsx"
            };

            if (save.ShowDialog() != DialogResult.OK) return;

            using (ExcelPackage excel = new ExcelPackage())
            {
                var ws = excel.Workbook.Worksheets.Add("HoaDon");

                // Sửa tiêu đề cột Excel
                ws.Cells[1, 1].Value = "Loại Phòng";
                ws.Cells[1, 2].Value = "Số Đêm";
                ws.Cells[1, 3].Value = "Thành Tiền";

                for (int r = 0; r < dgvcpp.Rows.Count; r++)
                {
                    // Xuất 3 cột: Loại Phòng (0), Số Đêm (1), Thành Tiền (2)
                    ws.Cells[r + 2, 1].Value = dgvcpp.Rows[r].Cells[0].Value;
                    ws.Cells[r + 2, 2].Value = dgvcpp.Rows[r].Cells[1].Value;
                    ws.Cells[r + 2, 3].Value = dgvcpp.Rows[r].Cells[2].Value;
                }

                int startRowDV = dgvcpp.Rows.Count + 4;
                ws.Cells[startRowDV, 1].Value = "Dịch Vụ";
                ws.Cells[startRowDV, 2].Value = "Số Lượng";
                ws.Cells[startRowDV, 3].Value = "Thành Tiền";

                for (int r = 0; r < dgvcpdv.Rows.Count; r++)
                {
                    ws.Cells[startRowDV + r + 1, 1].Value = dgvcpdv.Rows[r].Cells[0].Value;
                    ws.Cells[startRowDV + r + 1, 2].Value = dgvcpdv.Rows[r].Cells[1].Value;
                    ws.Cells[startRowDV + r + 1, 3].Value = dgvcpdv.Rows[r].Cells[2].Value;
                }

                int rowTotal = startRowDV + dgvcpdv.Rows.Count + 2;
                ws.Cells[rowTotal, 1].Value = lbltongtam.Text;
                ws.Cells[rowTotal + 1, 1].Value = lbltongcong.Text;

                File.WriteAllBytes(save.FileName, excel.GetAsByteArray());
                MessageBox.Show("Xuất Excel thành công!");
            }
        }

        private void btnpdf_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog
            {
                Filter = "PDF file|*.pdf",
                FileName = "HoaDon.pdf"
            };

            if (save.ShowDialog() != DialogResult.OK) return;

            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(save.FileName, FileMode.Create));
            doc.Open();

            doc.Add(new Paragraph("HÓA ĐƠN KHÁCH SẠN"));
            doc.Add(new Paragraph($"Mã hóa đơn: {txtma.Text}"));
            doc.Add(new Paragraph($"Khách hàng: {txtten.Text}"));
            doc.Add(new Paragraph($"Phòng: {txtphong.Text}"));
            doc.Add(new Paragraph($"Thời gian ở: {txttungay.Text} - {txtdenngay.Text}"));

            doc.Add(new Paragraph("\nChi tiết phòng:"));
            foreach (DataGridViewRow row in dgvcpp.Rows)
            {
                // Lấy Số đêm (Index 1) và Thành tiền (Index 2)
                int soDem = Convert.ToInt32(row.Cells[1].Value);
                decimal thanhTien = Convert.ToDecimal(row.Cells[2].Value);
                doc.Add(new Paragraph($"{row.Cells[0].Value} ({soDem} Đêm) - {thanhTien:N0} VNĐ"));
            }

            doc.Add(new Paragraph("\nChi tiết dịch vụ:"));
            foreach (DataGridViewRow row in dgvcpdv.Rows)
            {
                decimal val = Convert.ToDecimal(row.Cells[2].Value);
                doc.Add(new Paragraph($"{row.Cells[0].Value} (SL: {row.Cells[1].Value}) - {val:N0} VNĐ"));
            }

            doc.Add(new Paragraph("\n" + lbltongtam.Text));
            doc.Add(new Paragraph(lbltongcong.Text));

            doc.Close();
            MessageBox.Show("Xuất PDF thành công!");
        }

        private void btnthanhtoan_Click(object sender, EventArgs e)
        {
            try
            {
                decimal tongCong = 0;
                decimal.TryParse(
                    lbltongcong.Text.Replace("Tổng cộng: ", "").Replace(" VNĐ", "").Trim(),
                    NumberStyles.AllowThousands,
                    vn,
                    out tongCong
                );

                if (tongCong <= 0)
                {
                    MessageBox.Show("Không có hóa đơn hợp lệ để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                MessageBox.Show($"Thanh toán thành công!\nTổng cộng: {tongCong:N0} VNĐ",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                btnthanhtoan.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Tongtinkh_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}