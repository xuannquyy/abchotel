using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using OfficeOpenXml;
using iTextBaseColor = iTextSharp.text.BaseColor;
using iTextFont = iTextSharp.text.Font;

namespace abchotel
{
    public partial class FormInvoice : Form
    {
        // 🚀 CONNECTION STRING
        string connectionString = @"Data Source=ANHENHS\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True";

        // 💰 GLOBAL VARIABLES
        decimal tongPhong = 0, tongDV = 0, tongTamTinh = 0, tongCong = 0;

        // 🔑 Dùng INT cho ID vì MaHoaDon trong DB là INT
        private int currentMaHoaDon = 1;
        private readonly object hienthucTT;

        public FormInvoice()
        {
            InitializeComponent();
        }

        // 🎯 INTERFACE: Hàm để truyền Mã Hóa Đơn từ form khác
        public void SetInvoiceData(int maHoaDon)
        {
            this.currentMaHoaDon = maHoaDon;
        }

        private void FormInvoice_Load_1(object sender, EventArgs e)
        {
            SetupDataGridViews();

            // Nếu currentMaHoaDon là 0 (chưa được set từ bên ngoài), bạn có thể xử lý lỗi
            if (currentMaHoaDon <= 0)
            {
                MessageBox.Show("Mã Hóa Đơn không hợp lệ. Vui lòng chọn hóa đơn từ form quản lý.", "Lỗi Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // Đóng form nếu không có dữ liệu để load
                return;
            }
            // Gán sự kiện TextChanged cho các ô cần tính toán
            txtgiamgia.TextChanged += TxtGiaTri_TextChanged;
            txtphuthu.TextChanged += TxtGiaTri_TextChanged;

            // Thiết lập ComboBox (giả định tên là cbohienthuc)
            cbohienthuc.Items.AddRange(new object[] { "Tiền mặt", "Chuyển khoản", "Thẻ tín dụng" });
            cbohienthuc.SelectedIndex = 0;

            LoadThongTinKhachHang();
            LoadChiPhiPhong();
            // Hàm LoadChiPhiDVPhong() và LoadChiPhiDichVu() được gộp lại
            LoadChiPhiDichVu();

            TinhTongTamTinh();
        }

        // 🔹 Thiết lập style cho các DataGridView
        private void SetupDataGridViews()
        {
            foreach (var dgv in new[] { dgvcpp, dgvcpdvp, dgvcpdv })
            {
                dgv.BackgroundColor = Color.White;
                dgv.BorderStyle = BorderStyle.Fixed3D;
                dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 82, 155);
                dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                // **FIXED**: Lỗi tham chiếu Font không rõ ràng
                dgv.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Segoe UI", 9, FontStyle.Bold);
                dgv.EnableHeadersVisualStyles = false;
                dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv.RowHeadersVisible = false;
                dgv.AllowUserToAddRows = false;
                dgv.AllowUserToDeleteRows = false;
            }
        }

        // 🔹 Tải Thông tin khách hàng (ĐÃ SỬA QUERY THEO CẤU TRÚC DB)
        private void LoadThongTinKhachHang()
        {
            // Tên Controls giả định: txtma, txtten, txtphong, txtngay, txtsongay, label3
            txtma.Text = currentMaHoaDon.ToString();

            // Query: HoaDon -> DatPhong -> KhachHang & Phong
            string query = "SELECT KH.HoTen, P.SoPhong, DP.NgayNhan, DP.NgayTra " +
                    "FROM HoaDon AS HD JOIN DatPhong AS DP ON HD.MaDatPhong = DP.MaDatPhong " +
                    "JOIN KhachHang AS KH ON DP.MaKhachHang = KH.MaKhachHang " +
                    "JOIN Phong AS P ON DP.MaPhong = P.MaPhong " +
                    "WHERE HD.MaHoaDon = @MaHoaDon";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaHoaDon", currentMaHoaDon);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        // Ánh xạ dữ liệu vào controls
                        txtten.Text = reader["HoTen"].ToString();
                        txtphong.Text = reader["SoPhong"].ToString();

                        DateTime ngayNhan = reader.GetDateTime(reader.GetOrdinal("NgayNhan"));
                        DateTime ngayTra = reader.GetDateTime(reader.GetOrdinal("NgayTra"));

                        txtngay.Text = ngayTra.ToString("dd/MM/yyyy");

                        // Tính Số Ngày Ở (Số đêm)
                        TimeSpan duration = ngayTra - ngayNhan;
                        int soNgay = (int)Math.Ceiling(duration.TotalDays);
                        if (soNgay == 0) soNgay = 1;

                        txtsongay.Text = soNgay.ToString();
                        // label3 là label hiển thị chi tiết thời gian ở
                        label3.Text = $"{soNgay} ngày";
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải thông tin khách hàng: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // 🔹 Tải Chi Phí Phòng (ĐÃ SỬA QUERY VÀ CỘT SỐ NGÀY)
        private void LoadChiPhiPhong()
        {
            // Tính tiền phòng: Đơn Giá Phòng * (NgayTra - NgayNhan)
            string query = "SELECT P.SoPhong AS [Số Phòng], P.DonGia AS [Giá/Đêm], " +
                           "DATEDIFF(day, DP.NgayNhan, DP.NgayTra) AS [Số đêm], " +
                           "P.DonGia * DATEDIFF(day, DP.NgayNhan, DP.NgayTra) AS [Thành tiền] " +
                           "FROM HoaDon AS HD JOIN DatPhong AS DP ON HD.MaDatPhong = DP.MaDatPhong " +
                           "JOIN Phong AS P ON DP.MaPhong = P.MaPhong " +
                           "WHERE HD.MaHoaDon = @MaHoaDon";

            LoadDataToDataGridView(dgvcpp, query, "Chi phí phòng");
        }

        // 🔹 Tải Chi Phí Dịch Vụ (SỬ DỤNG BẢNG ChiTietDichVu MỚI)
        private void LoadChiPhiDichVu()
        {
            // Query lấy dữ liệu từ bảng ChiTietDichVu mới
            string query = "SELECT DV.TenDichVu AS [Tên dịch vụ], CT.DonGia AS [Đơn giá], " +
                           "CT.SoLuong AS [Số lượng], CT.ThanhTien AS [Thành tiền] " +
                           "FROM ChiTietDichVu AS CT JOIN DichVu AS DV ON CT.MaDichVu = DV.MaDichVu " +
                           "WHERE CT.MaHoaDon = @MaHoaDon";

            // Load chung data dịch vụ cho cả hai DGV (giả định)
            LoadDataToDataGridView(dgvcpdvp, query, "Chi phí dịch vụ phòng");
            LoadDataToDataGridView(dgvcpdv, query, "Chi phí dịch vụ");
        }

        // 🔹 Hàm chung để tải dữ liệu và tính tổng
        private void LoadDataToDataGridView(DataGridView dgv, string query, string dgvTag)
        {
            dgv.Tag = dgvTag;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@MaHoaDon", currentMaHoaDon);
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    DataTable dt = new DataTable();
                    connection.Open();
                    da.Fill(dt);
                    dgv.DataSource = dt;

                    decimal currentTong = 0;
                    if (dt.Columns.Contains("Thành tiền"))
                    {
                        // Tính tổng tiền cho DGV hiện tại
                        currentTong = dt.AsEnumerable().Sum(row => row.Field<decimal>("Thành tiền"));

                        // Định dạng cột Thành tiền
                        dgv.Columns["Thành tiền"].DefaultCellStyle.Format = "N0";
                        dgv.Columns["Thành tiền"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    }

                    // Cập nhật các biến tổng (global)
                    if (dgv == dgvcpp)
                    {
                        tongPhong = currentTong;
                    }
                    else if (dgv == dgvcpdvp || dgv == dgvcpdv)
                    {
                        // Cộng dồn tổng dịch vụ (sẽ bị nhân đôi, ta sửa ở TinhTongTamTinh)
                        tongDV += currentTong;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi tải dữ liệu {dgvTag}: {ex.Message}", "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ----------------------------------------------------
        // II. TÍNH TOÁN
        // ----------------------------------------------------

        // 🔹 Xử lý sự kiện khi Giảm Giá/Phụ Thu thay đổi (GIỮ NGUYÊN - ĐÃ ĐÚNG)
        private void TxtGiaTri_TextChanged(object sender, EventArgs e)
        {
            TextBox currentTextBox = sender as TextBox;
            if (currentTextBox == null) return;

            currentTextBox.TextChanged -= TxtGiaTri_TextChanged;

            decimal amount = ParseCurrency(currentTextBox.Text);
            currentTextBox.Text = amount.ToString("N0");
            currentTextBox.SelectionStart = currentTextBox.Text.Length;

            currentTextBox.TextChanged += TxtGiaTri_TextChanged;

            TinhTongCong();
        }

        // 🔹 Hàm chuyển đổi chuỗi tiền tệ an toàn (GIỮ NGUYÊN - ĐÃ ĐÚNG)
        private decimal ParseCurrency(string text)
        {
            string cleanText = text.Replace(".", "").Replace(",", "");
            if (decimal.TryParse(cleanText, out decimal result))
            {
                return result;
            }
            return 0;
        }

        // 🔹 Tính Tổng Tạm Tính (ĐÃ SỬA LỖI TÍNH TỔNG DV BỊ NHÂN ĐÔI)
        private void TinhTongTamTinh()
        {
            // Chia đôi tongDV vì nó được cộng dồn 2 lần (dgvcpdvp và dgvcpdv)
            tongDV = tongDV / 2;

            tongTamTinh = tongPhong + tongDV;

            // Tên Controls giả định: txttienphong, txttiendv, lbltongtamtinh
            txttienphong.Text = tongPhong.ToString("N0");
            txttiendv.Text = tongDV.ToString("N0");

            lbltongtamtinh.Text = tongTamTinh.ToString("N0") + " VNĐ";

            TinhTongCong();
        }

        // 🔹 Tính Tổng Cộng (GIỮ NGUYÊN - ĐÃ ĐÚNG)
        private void TinhTongCong()
        {
            // Tên Controls giả định: txtgiamgia, txtphuthu, lbltongcong
            decimal giamGia = ParseCurrency(txtgiamgia.Text);
            decimal phuThu = ParseCurrency(txtphuthu.Text);

            tongCong = tongTamTinh - giamGia + phuThu;
            lbltongcong.Text = tongCong.ToString("N0") + " VNĐ";
        }

        // ----------------------------------------------------
        // III. XỬ LÝ CHỨC NĂNG
        // ----------------------------------------------------

        // 💾 Nút Thanh Toán (ĐÃ SỬA QUERY CẬP NHẬT HoaDon)
        private void btnthanhtoan_Click(object sender, EventArgs e)
        {
            TinhTongCong();
            string hinhThucTT = cbohienthuc.Text;

            string confirmMessage = $"Xác nhận thanh toán tổng cộng {lbltongcong.Text} bằng hình thức '{hinhThucTT}'?";
            if (MessageBox.Show(confirmMessage, "Xác Nhận Thanh Toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string query = "UPDATE HoaDon SET " +
                "ThanhTien = @TongCong, GiamGia = @GiamGia, PhuThu = @PhuThu, " +
                "HinhThucThanhToan = @HinhThucTT " +
                "WHERE MaHoaDon = @MaHoaDon";
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@TongCong", tongCong);

                        // 🌟 BỎ COMMENT CÁC DÒNG DƯỚI VÀ SỬA TÊN PARAMETER
                        command.Parameters.AddWithValue("@GiamGia", ParseCurrency(txtgiamgia.Text));
                        command.Parameters.AddWithValue("@PhuThu", ParseCurrency(txtphuthu.Text));
                        command.Parameters.AddWithValue("@HinhThucTT", hinhThucTT); // Dùng biến hinhThucTT đã lấy từ ComboBox

                        command.Parameters.AddWithValue("@MaHoaDon", currentMaHoaDon);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thanh toán hóa đơn thành công và đã được cập nhật!", "Hoàn Tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnthanhtoan.Enabled = false;
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy hóa đơn để cập nhật.", "Lỗi Lưu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thanh toán: " + ex.Message, "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 📄 Nút Xuất PDF (GIỮ NGUYÊN - ĐÃ ĐÚNG)
        private void btnpdf_Click(object sender, EventArgs e)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            try
            {
                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF File|*.pdf", FileName = $"{currentMaHoaDon}_HoaDon.pdf" })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                        {
                            Document doc = new Document(PageSize.A4, 20, 20, 20, 20);
                            PdfWriter.GetInstance(doc, stream);
                            doc.Open();

                            string fontName = "times.ttf";
                            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), fontName);

                            BaseFont bf;
                            try
                            {
                                // 2. Tải font từ đường dẫn, sử dụng IDENTITY_H và nhúng font (EMBEDDED)
                                bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                            }
                            catch (iTextSharp.text.DocumentException)
                            {
                                // Nếu không tìm thấy file font (fontPath), dùng font mặc định nhưng không hỗ trợ TV
                                // Hoặc bạn có thể báo lỗi rõ ràng hơn
                                bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                                MessageBox.Show($"Lỗi không tìm thấy file font: {fontName}. Vui lòng kiểm tra C:\\Windows\\Fonts.", "Lỗi Font", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }

                            // 3. Sử dụng BaseFont bf mới để tạo các đối tượng Font
                            iTextFont vnFont = new iTextFont(bf, 11, iTextFont.NORMAL, iTextBaseColor.BLACK);
                            iTextFont vnFontBold = new iTextFont(bf, 13, iTextFont.BOLD, iTextBaseColor.BLACK);
                            iTextFont titleFont = new iTextFont(bf, 16, iTextFont.BOLD, iTextBaseColor.BLACK);

                            Paragraph title = new Paragraph("HÓA ĐƠN KHÁCH SẠN", titleFont) { Alignment = Element.ALIGN_CENTER };
                            doc.Add(title);
                            doc.Add(new Paragraph("\n"));

                            // Thêm thông tin khách hàng
                            doc.Add(new Paragraph($"Mã Hóa Đơn: {txtma.Text}", vnFont));
                            doc.Add(new Paragraph($"Tên Khách Hàng: {txtten.Text}", vnFont));
                            doc.Add(new Paragraph($"Tổng Cộng: {lbltongcong.Text}", vnFontBold));
                            doc.Add(new Paragraph("\n"));

                            foreach (DataGridView dgv in new[] { dgvcpp, dgvcpdvp, dgvcpdv })
                            {
                                doc.Add(new Paragraph(dgv.Tag?.ToString() ?? "Danh sách", vnFontBold));

                                PdfPTable table = new PdfPTable(dgv.Columns.Count);
                                table.WidthPercentage = 100;
                                table.SpacingBefore = 5f;

                                // Header
                                foreach (DataGridViewColumn col in dgv.Columns)
                                {
                                    PdfPCell cell = new PdfPCell(new Phrase(col.HeaderText, new iTextFont(bf, 11, iTextFont.BOLD, iTextBaseColor.WHITE)))
                                    {
                                        BackgroundColor = new iTextBaseColor(0, 82, 155),
                                        HorizontalAlignment = Element.ALIGN_CENTER
                                    };
                                    table.AddCell(cell);
                                }

                                // Dữ liệu
                                foreach (DataGridViewRow row in dgv.Rows)
                                {
                                    if (row.IsNewRow) continue;
                                    foreach (DataGridViewCell cell in row.Cells)
                                    {
                                        table.AddCell(new Phrase(cell.Value?.ToString() ?? "", vnFont));
                                    }
                                }
                                doc.Add(table);
                                doc.Add(new Paragraph("\n"));
                            }

                            doc.Close();
                        }

                        MessageBox.Show("Xuất PDF thành công!", "Hoàn Tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message + "\n(Lưu ý: Bạn có thể cần cài đặt font tiếng Việt cho iTextSharp)");
            }
        }

        // 📈 Nút Xuất Excel (GIỮ NGUYÊN - ĐÃ ĐÚNG)
        private void btnexcel_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra currentMaHoaDon để đặt tên file
                string fileName = currentMaHoaDon > 0 ? $"{currentMaHoaDon}_HoaDon.xlsx" : "HoaDon_Export.xlsx";

                using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel|*.xlsx", FileName = fileName })
                {
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        using (ExcelPackage package = new ExcelPackage())
                        {
                            ExcelWorksheet ws = package.Workbook.Worksheets.Add("HoaDon");

                            int startRow = 1;
                            foreach (DataGridView dgv in new[] { dgvcpp, dgvcpdvp, dgvcpdv })
                            {
                                ws.Cells[startRow, 1].Value = dgv.Tag?.ToString() ?? "Dữ liệu";
                                ws.Cells[startRow, 1].Style.Font.Bold = true;
                                startRow++;

                                for (int i = 0; i < dgv.Columns.Count; i++)
                                {
                                    ws.Cells[startRow, i + 1].Value = dgv.Columns[i].HeaderText;
                                    ws.Cells[startRow, i + 1].Style.Font.Bold = true;
                                }
                                startRow++;

                                foreach (DataGridViewRow row in dgv.Rows)
                                {
                                    if (row.IsNewRow) continue;
                                    for (int c = 0; c < dgv.Columns.Count; c++)
                                    {
                                        ws.Cells[startRow, c + 1].Value = row.Cells[c].Value;
                                    }
                                    startRow++;
                                }

                                startRow += 2;
                            }

                            // Thêm thông tin tổng kết
                            ws.Cells[startRow, 1].Value = "TỔNG CỘNG THANH TOÁN:";
                            ws.Cells[startRow, 4].Value = tongCong;
                            ws.Cells[startRow, 4].Style.Numberformat.Format = "#,##0";
                            ws.Cells[startRow, 4].Style.Font.Bold = true;

                            ws.Cells.AutoFitColumns();
                            package.SaveAs(new System.IO.FileInfo(sfd.FileName));
                            MessageBox.Show("Xuất EXCEL thành công!", "Hoàn Tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message);
            }
        }
    }
}