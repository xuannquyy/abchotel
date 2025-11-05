using abchotel.BLL;
using abchotel.Model;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

// Thư viện Excel (EPPlus)
using OfficeOpenXml;
using OfficeOpenXml.Style;

// Thư viện PDF (iTextSharp)
using iTextSharp.text;
using iTextSharp.text.pdf;


namespace abchotel
{
    public partial class FormInvoice : Form
    {
        private HoaDonBLL hoaDonBLL = new HoaDonBLL();
        private HoaDon currentHoaDon; // Dùng để lưu hóa đơn đang xem
        private CultureInfo culture = new CultureInfo("vi-VN");
        public FormInvoice()
        {
            InitializeComponent();
            OfficeOpenXml.ExcelPackage.License.SetNonCommercialPersonal("Khai Bao Su Dung");
        }
        private void FormInvoice_Load(object sender, EventArgs e)
        {
            LoadDanhSachPhong();
            ResetForm();
        }
        private void LoadDanhSachPhong()
        {
            try
            {
                DataTable dt = hoaDonBLL.LayDanhSachDatPhongChuaThanhToan();

                // Thêm một dòng "chọn phòng" placeholder
                DataRow placeholder = dt.NewRow();
                placeholder["MaDatPhong"] = 0; // Giá trị 0 để nhận biết
                placeholder["HienThi"] = "--- Chọn phòng thanh toán ---";
                dt.Rows.InsertAt(placeholder, 0);

                cboSoPhong.DataSource = dt;
                cboSoPhong.DisplayMember = "HienThi"; // Cột "HienThi" từ DAL
                cboSoPhong.ValueMember = "MaDatPhong"; // Cột "MaDatPhong" từ DAL
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải danh sách phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ResetForm()
        {
            currentHoaDon = null;

            // Group 1: Thông tin khách hàng
            cboSoPhong.SelectedIndex = 0; // Chọn placeholder
            txtTenKhachHang.Text = "";
            txtNgayNhan.Text = "";
            txtNgayTra.Text = "";
            txtLoaiPhong.Text = "";
            lblChiPhiPhong.Text = "0 VNĐ";

            // Group 2: Chi phí dịch vụ
            dgvChiTietDichVu.DataSource = null;
            lblChiPhiDichVu.Text = "0 VNĐ";

            // Group 3: Tổng kết
            txtTienPhong.Text = "0";
            txtTienDichVu.Text = "0";
            numGiamGia.Value = 0;
            lblTongCong.Text = "0 VNĐ";

            // Vô hiệu hóa các nút
            btnThanhToan.Enabled = false;
            btnexcel.Enabled = false;
            btnpdf.Enabled = false;
        }

        private void cboSoPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSoPhong.SelectedValue == null)
            {
                return; // Thoát nếu SelectedValue chưa sẵn sàng
            }

            int maDatPhong;
            try
            {
                maDatPhong = Convert.ToInt32(cboSoPhong.SelectedValue);
            }
            catch (Exception)
            {
                ResetForm();
                return; // Thoát nếu không thể chuyển đổi
            }

            // Nếu chọn placeholder (giá trị 0) thì reset form
            if (maDatPhong == 0)
            {
                ResetForm();
                return;
            }

            try
            {
                // Gọi SP sp_GetOrCreateHoaDon thông qua BLL
                currentHoaDon = hoaDonBLL.LayThongTinHoaDon(maDatPhong);

                if (currentHoaDon == null)
                {
                    MessageBox.Show("Không thể tải thông tin hóa đơn cho phòng này.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ResetForm();
                    return;
                }

                // --- Bắt đầu điền thông tin lên Form ---

                // Group 1: Thông tin khách hàng
                txtTenKhachHang.Text = currentHoaDon.TenKhachHang;
                txtNgayNhan.Text = currentHoaDon.NgayNhan.ToString("dd/MM/yyyy");
                txtNgayTra.Text = currentHoaDon.NgayTra.ToString("dd/MM/yyyy");

                // Lấy chi tiết tiền phòng (Loại phòng, số đêm, đơn giá)
                DataTable dtPhong = hoaDonBLL.LayChiTietTienPhong(maDatPhong);
                if (dtPhong.Rows.Count > 0)
                {
                    DataRow row = dtPhong.Rows[0];
                    txtLoaiPhong.Text = row["Loại phòng"].ToString();
                    int soDem = Convert.ToInt32(row["Số đêm"]);
                    decimal donGia = Convert.ToDecimal(row["Đơn giá"]);

                    // Hiển thị chi tiết: 1.200.000 VNĐ x 2 đêm = 2.400.000 VNĐ
                    lblDongiaphong.Text = string.Format(culture, "{0:N0} VNĐ x {1} đêm",
                        donGia, soDem);
                    lblChiPhiPhong.Text = string.Format(culture, "{0:N0} VNĐ",
                        currentHoaDon.TongTienPhong);
                    
              
                }

                // Group 2: Chi phí dịch vụ
                DataTable dtDV = hoaDonBLL.LayChiTietDichVu(currentHoaDon.MaHoaDon);
                dgvChiTietDichVu.DataSource = dtDV;
                dgvChiTietDichVu.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Tự động co giãn cột
                // Hiển thị tổng tiền dịch vụ
                lblChiPhiDichVu.Text = string.Format(culture, "{0:N0} VNĐ", currentHoaDon.TongTienDichVu);

                // Group 3: Tổng kết
                txtTienPhong.Text = string.Format(culture, "{0:N0}", currentHoaDon.TongTienPhong);
                txtTienDichVu.Text = string.Format(culture, "{0:N0}", currentHoaDon.TongTienDichVu);
                numGiamGia.Value = currentHoaDon.GiamGiaPhanTram; // Tải giảm giá nếu có

                // Tính tổng cộng
                TinhTongCong();

                // Kích hoạt các nút
                btnThanhToan.Enabled = true;
                btnexcel.Enabled = true;
                btnpdf.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi chọn phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ResetForm();
            }
        }

        private void numGiamGia_ValueChanged(object sender, EventArgs e)
        {
            TinhTongCong();
        }
        private void TinhTongCong()
        {
            if (currentHoaDon == null)
            {
                lblTongCong.Text = "0 VNĐ";
                return;
            }

            try
            {
                decimal tienPhong = currentHoaDon.TongTienPhong;
                decimal tienDichVu = currentHoaDon.TongTienDichVu;
                int giamGia = (int)numGiamGia.Value;

                decimal tongTruocGiam = tienPhong + tienDichVu;
                decimal tongThanhToan = tongTruocGiam * (1 - (decimal)giamGia / 100);

                // Hiển thị tổng cộng
                lblTongCong.Text = string.Format(culture, "{0:N0} VNĐ", tongThanhToan);

                // Cập nhật lại đối tượng currentHoaDon để sẵn sàng lưu
                currentHoaDon.TongThanhToan = tongThanhToan;
                currentHoaDon.GiamGiaPhanTram = giamGia;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tính tổng tiền: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (currentHoaDon == null)
            {
                MessageBox.Show("Vui lòng chọn phòng để thanh toán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Xác nhận thanh toán
            string thongBao = $"Xác nhận thanh toán cho phòng {currentHoaDon.SoPhong}?\n" +
                              $"Tổng cộng: {currentHoaDon.TongThanhToan:N0} VNĐ";

            DialogResult dr = MessageBox.Show(thongBao, "Xác nhận thanh toán", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                try
                {
                    // Gọi BLL để lưu thanh toán (cập nhật HoaDon và Phòng)
                    hoaDonBLL.LuuThanhToan(
                        currentHoaDon.MaHoaDon,
                        currentHoaDon.GiamGiaPhanTram,
                        currentHoaDon.TongThanhToan
                    );

                    MessageBox.Show("Thanh toán thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Tải lại danh sách phòng (phòng vừa thanh toán sẽ biến mất)
                    LoadDanhSachPhong();
                    // Reset form về trạng thái sạch
                    ResetForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu thanh toán: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnexcel_Click(object sender, EventArgs e)
        {
            if (currentHoaDon == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn trước khi xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Workbook (*.xlsx)|*.xlsx";
            saveFileDialog.FileName = $"HoaDon_{currentHoaDon.SoPhong.Replace(" ", "")}_{DateTime.Now:yyyyMMdd}.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    FileInfo file = new FileInfo(saveFileDialog.FileName);
                    using (ExcelPackage package = new ExcelPackage(file))
                    {
                        ExcelWorksheet ws = package.Workbook.Worksheets.Add("HoaDon");

                        // --- Tiêu đề ---
                        ws.Cells["A1:D1"].Merge = true;
                        ws.Cells["A1"].Value = "HÓA ĐƠN THANH TOÁN KHÁCH SẠN";
                        ws.Cells["A1"].Style.Font.Bold = true;
                        ws.Cells["A1"].Style.Font.Size = 16;
                        ws.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                        // --- Thông tin khách hàng ---
                        ws.Cells["A3"].Value = "Khách hàng:";
                        ws.Cells["B3"].Value = currentHoaDon.TenKhachHang;
                        ws.Cells["A4"].Value = "Số phòng:";
                        ws.Cells["B4"].Value = currentHoaDon.SoPhong;
                        ws.Cells["A5"].Value = "Thời gian:";
                        ws.Cells["B5"].Value = $"Từ {currentHoaDon.NgayNhan:dd/MM/yyyy} đến {currentHoaDon.NgayTra:dd/MM/yyyy}";

                        ws.Cells["A3:A5"].Style.Font.Bold = true;

                        // --- Chi tiết tiền phòng ---
                        ws.Cells["A7"].Value = "CHI TIẾT TIỀN PHÒNG";
                        ws.Cells["A7:D7"].Merge = true;
                        ws.Cells["A7"].Style.Font.Bold = true;
                        ws.Cells["A8"].Value = "Loại phòng";
                        ws.Cells["B8"].Value = "Số đêm";
                        ws.Cells["C8"].Value = "Đơn giá";
                        ws.Cells["D8"].Value = "Tổng";

                        DataTable dtPhong = (DataTable)hoaDonBLL.LayChiTietTienPhong(currentHoaDon.MaDatPhong);
                        ws.Cells["A9"].LoadFromDataTable(dtPhong, false); // Tải dữ liệu phòng
                        ws.Cells["A8:D9"].Style.Border.BorderAround(ExcelBorderStyle.Thin);
                        ws.Cells["C9:D9"].Style.Numberformat.Format = "#,##0";


                        // --- Chi tiết dịch vụ ---
                        ws.Cells["A11"].Value = "CHI TIẾT DỊCH VỤ";
                        ws.Cells["A11:D11"].Merge = true;
                        ws.Cells["A11"].Style.Font.Bold = true;
                        ws.Cells["A12"].Value = "Tên dịch vụ";
                        ws.Cells["B12"].Value = "Số lượng";
                        ws.Cells["C12"].Value = "Đơn giá";
                        ws.Cells["D12"].Value = "Tổng";
                        ws.Cells["A12:D12"].Style.Font.Bold = true;

                        DataTable dtDV = (DataTable)dgvChiTietDichVu.DataSource;
                        int rowDVStart = 13;
                        if (dtDV != null && dtDV.Rows.Count > 0)
                        {
                            // Chỉ lấy 4 cột: Tên, SL, Đơn giá, Tổng
                            foreach (DataRow row in dtDV.Rows)
                            {
                                ws.Cells[rowDVStart, 1].Value = row["Tên dịch vụ"];
                                ws.Cells[rowDVStart, 2].Value = row["Số lượng"];
                                ws.Cells[rowDVStart, 3].Value = row["Đơn giá"];
                                ws.Cells[rowDVStart, 4].Value = row["Tổng"];
                                rowDVStart++;
                            }
                            ws.Cells[$"C13:D{rowDVStart - 1}"].Style.Numberformat.Format = "#,##0";
                        }
                        else
                        {
                            ws.Cells[rowDVStart, 1].Value = "Không sử dụng dịch vụ";
                            ws.Cells[$"A{rowDVStart}:D{rowDVStart}"].Merge = true;
                            rowDVStart++;
                        }
                        ws.Cells[$"A12:D{rowDVStart - 1}"].Style.Border.BorderAround(ExcelBorderStyle.Thin);


                        // --- Tổng kết ---
                        int rowTongKet = rowDVStart + 1;
                        ws.Cells[rowTongKet, 3].Value = "Tiền phòng:";
                        ws.Cells[rowTongKet, 4].Value = currentHoaDon.TongTienPhong;
                        rowTongKet++;
                        ws.Cells[rowTongKet, 3].Value = "Tiền dịch vụ:";
                        ws.Cells[rowTongKet, 4].Value = currentHoaDon.TongTienDichVu;
                        rowTongKet++;
                        ws.Cells[rowTongKet, 3].Value = $"Giảm giá ({currentHoaDon.GiamGiaPhanTram}%):";
                        ws.Cells[rowTongKet, 4].Value = (currentHoaDon.TongTienPhong + currentHoaDon.TongTienDichVu) * (currentHoaDon.GiamGiaPhanTram / 100m);
                        rowTongKet++;
                        ws.Cells[rowTongKet, 3].Value = "TỔNG CỘNG:";
                        ws.Cells[rowTongKet, 4].Value = currentHoaDon.TongThanhToan;

                        ws.Cells[$"C{rowDVStart + 1}:C{rowTongKet}"].Style.Font.Bold = true;
                        ws.Cells[$"D{rowDVStart + 1}:D{rowTongKet}"].Style.Numberformat.Format = "#,##0 VNĐ";
                        ws.Cells[$"D{rowTongKet}"].Style.Font.Bold = true;
                        ws.Cells[$"D{rowTongKet}"].Style.Font.Color.SetColor(System.Drawing.Color.Red);

                        // Tự động căn chỉnh cột
                        ws.Cells[ws.Dimension.Address].AutoFitColumns();

                        package.Save();
                    }

                    MessageBox.Show($"Xuất Excel thành công!\nFile đã được lưu tại: {saveFileDialog.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnpdf_Click(object sender, EventArgs e)
        {
            if (currentHoaDon == null)
            {
                MessageBox.Show("Vui lòng chọn hóa đơn trước khi xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Document (*.pdf)|*.pdf";
            saveFileDialog.FileName = $"HoaDon_{currentHoaDon.SoPhong.Replace(" ", "")}_{DateTime.Now:yyyyMMdd}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // --- BẮT BUỘC: Thiết lập Font tiếng Việt ---
                    // iTextSharp không tự nhận font, ta phải chỉ đường dẫn đến file font
                    // Hãy đảm bảo bạn có file arial.ttf trong máy (hoặc một font .ttf khác hỗ trợ tiếng Việt)
                    string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");
                    if (!File.Exists(fontPath))
                    {
                        MessageBox.Show("Không tìm thấy font 'arial.ttf' trong C:\\Windows\\Fonts. Không thể xuất PDF.", "Lỗi Font", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                    iTextSharp.text.Font fontTieuDe = new iTextSharp.text.Font(baseFont, 16, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font fontBold = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.BOLD);
                    iTextSharp.text.Font fontThuong = new iTextSharp.text.Font(baseFont, 11, iTextSharp.text.Font.NORMAL);
                    iTextSharp.text.Font fontTongCong = new iTextSharp.text.Font(baseFont, 12, iTextSharp.text.Font.BOLD, BaseColor.RED);


                    // --- Bắt đầu tạo file PDF ---
                    Document document = new Document(PageSize.A4, 30f, 30f, 30f, 30f);
                    PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));
                    document.Open();

                    // Tiêu đề
                    Paragraph tieuDe = new Paragraph("HÓA ĐƠN THANH TOÁN KHÁCH SẠN", fontTieuDe);
                    tieuDe.Alignment = Element.ALIGN_CENTER;
                    document.Add(tieuDe);

                    document.Add(new Paragraph(" ", fontThuong)); // Dòng trống

                    // Thông tin khách hàng
                    document.Add(new Paragraph($"Khách hàng: {currentHoaDon.TenKhachHang}", fontThuong));
                    document.Add(new Paragraph($"Số phòng: {currentHoaDon.SoPhong}", fontThuong));
                    document.Add(new Paragraph($"Thời gian: Từ {currentHoaDon.NgayNhan:dd/MM/yyyy} đến {currentHoaDon.NgayTra:dd/MM/yyyy}", fontThuong));
                    document.Add(new Paragraph($"Ngày lập hóa đơn: {DateTime.Now:dd/MM/yyyy}", fontThuong));

                    document.Add(new Paragraph("----------------------------------------------------------", fontThuong));

                    // Bảng Tiền Phòng (lấy từ BLL)
                    document.Add(new Paragraph("CHI TIẾT TIỀN PHÒNG", fontBold));
                    PdfPTable tblPhong = new PdfPTable(4); // 4 cột
                    tblPhong.WidthPercentage = 100;
                    tblPhong.SetWidths(new float[] { 2f, 1f, 1.5f, 1.5f });
                    tblPhong.AddCell(new Phrase("Loại phòng", fontBold));
                    tblPhong.AddCell(new Phrase("Số đêm", fontBold));
                    tblPhong.AddCell(new Phrase("Đơn giá", fontBold));
                    tblPhong.AddCell(new Phrase("Tổng", fontBold));

                    DataTable dtPhong = hoaDonBLL.LayChiTietTienPhong(currentHoaDon.MaDatPhong);
                    foreach (DataRow row in dtPhong.Rows)
                    {
                        tblPhong.AddCell(new Phrase(row["Loại phòng"].ToString(), fontThuong));
                        tblPhong.AddCell(new Phrase(row["Số đêm"].ToString(), fontThuong));
                        tblPhong.AddCell(new Phrase(Convert.ToDecimal(row["Đơn giá"]).ToString("N0", culture), fontThuong));
                        tblPhong.AddCell(new Phrase(Convert.ToDecimal(row["Tổng"]).ToString("N0", culture), fontThuong));
                    }
                    document.Add(tblPhong);
                    document.Add(new Paragraph(" ", fontThuong)); // Dòng trống

                    // Bảng Dịch Vụ (lấy từ DataGridView)
                    document.Add(new Paragraph("CHI TIẾT DỊCH VỤ", fontBold));
                    PdfPTable tblDV = new PdfPTable(4); // 4 cột
                    tblDV.WidthPercentage = 100;
                    tblDV.SetWidths(new float[] { 2f, 1f, 1.5f, 1.5f });
                    tblDV.AddCell(new Phrase("Tên dịch vụ", fontBold));
                    tblDV.AddCell(new Phrase("Số lượng", fontBold));
                    tblDV.AddCell(new Phrase("Đơn giá", fontBold));
                    tblDV.AddCell(new Phrase("Tổng", fontBold));

                    DataTable dtDV = (DataTable)dgvChiTietDichVu.DataSource;
                    if (dtDV != null && dtDV.Rows.Count > 0)
                    {
                        foreach (DataRow row in dtDV.Rows)
                        {
                            tblDV.AddCell(new Phrase(row["Tên dịch vụ"].ToString(), fontThuong));
                            tblDV.AddCell(new Phrase(row["Số lượng"].ToString(), fontThuong));
                            tblDV.AddCell(new Phrase(Convert.ToDecimal(row["Đơn giá"]).ToString("N0", culture), fontThuong));
                            tblDV.AddCell(new Phrase(Convert.ToDecimal(row["Tổng"]).ToString("N0", culture), fontThuong));
                        }
                    }
                    else
                    {
                        PdfPCell cell = new PdfPCell(new Phrase("Không sử dụng dịch vụ.", fontThuong));
                        cell.Colspan = 4;
                        tblDV.AddCell(cell);
                    }
                    document.Add(tblDV);
                    document.Add(new Paragraph("----------------------------------------------------------", fontThuong));

                    // Tổng kết
                    decimal tongTruocGiam = currentHoaDon.TongTienPhong + currentHoaDon.TongTienDichVu;
                    decimal tienGiam = tongTruocGiam * (currentHoaDon.GiamGiaPhanTram / 100m);

                    document.Add(new Paragraph($"Tiền phòng: {currentHoaDon.TongTienPhong.ToString("N0", culture)} VNĐ", fontThuong) { Alignment = Element.ALIGN_RIGHT });
                    document.Add(new Paragraph($"Tiền dịch vụ: {currentHoaDon.TongTienDichVu.ToString("N0", culture)} VNĐ", fontThuong) { Alignment = Element.ALIGN_RIGHT });
                    document.Add(new Paragraph($"Giảm giá ({currentHoaDon.GiamGiaPhanTram}%): {tienGiam.ToString("N0", culture)} VNĐ", fontThuong) { Alignment = Element.ALIGN_RIGHT });
                    document.Add(new Paragraph($"TỔNG CỘNG: {currentHoaDon.TongThanhToan.ToString("N0", culture)} VNĐ", fontTongCong) { Alignment = Element.ALIGN_RIGHT });

                    document.Close();
                    writer.Close();

                    MessageBox.Show($"Xuất PDF thành công!\nFile đã được lưu tại: {saveFileDialog.FileName}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // Lỗi phổ biến nhất là file đang được mở
                    if (ex is IOException)
                        MessageBox.Show("Lỗi khi xuất PDF: File có thể đang được mở. Vui lòng đóng file và thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        MessageBox.Show("Lỗi khi xuất PDF: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}