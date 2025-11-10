using abchotel.BLL;
using abchotel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace abchotel
{
    public partial class FormBooking : Form
    {
        private readonly KhachHangBLL khachHangBLL = new KhachHangBLL();
        private readonly DatPhongBLL datPhongBLL = new DatPhongBLL();
        private bool _isCalculating = false; // Cờ để tránh lặp vô hạn sự kiện
        public FormBooking()
        {
            InitializeComponent();
        }

        private void FormBooking_Load(object sender, EventArgs e)
        {
            SetupForm();
            LoadDanhSachDatPhongHomNay();
        }
        private void SetupForm()
        {
            // Nạp ComboBox
            Cbloaiphong.Items.AddRange(new string[] { "Phòng Đơn", "Phòng Đôi", "VIP - Phòng Đơn", "VIP - Phòng Đôi" });
            cbgioitinh.Items.AddRange(new string[] { "Nam", "Nữ" });

            // Cài đặt DateTimePicker
            datenhan.MinDate = DateTime.Today;
            datenhan.Value = DateTime.Today;
            datetra.MinDate = DateTime.Today.AddDays(1);
            datetra.Value = DateTime.Today.AddDays(1);

            KhoiTaoDatePickerNgaySinh();

            // Gắn sự kiện
            Cbloaiphong.SelectedIndexChanged += Cbloaiphong_SelectedIndexChanged;
            cbphongtrong.SelectedIndexChanged += cbphongtrong_SelectedIndexChanged;

            datenhan.ValueChanged += DateTimePicker_ValueChanged;
            datetra.ValueChanged += DateTimePicker_ValueChanged;
            txbsodem.TextChanged += txbsodem_TextChanged;

            txbsodem.KeyPress += TextBox_OnlyNumbers_KeyPress;
            txbsoluong.KeyPress += TextBox_OnlyNumbers_KeyPress;
            txbCMND.KeyPress += TextBox_OnlyNumbers_KeyPress;
            txbsdt.KeyPress += TextBox_OnlyNumbers_KeyPress;

            butdatphong.Click += butdatphong_Click;
            butlmmoi.Click += butlmmoi_Click;

            // Chạy làm mới để set trạng thái ban đầu
            butlmmoi_Click(null, null);
        }

        private void KhoiTaoDatePickerNgaySinh()
        {
            datesinh.Format = DateTimePickerFormat.Custom;
            datesinh.CustomFormat = " "; // Mặc định trống
            datesinh.ValueChanged += datesinh_ValueChanged;
        }
        
        private void datesinh_ValueChanged(object sender, EventArgs e)
        {
            datesinh.CustomFormat = "dd/MM/yyyy";
        }

        private void Cbloaiphong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbloaiphong.SelectedIndex == -1)
            {
                cbphongtrong.DataSource = null;
                return;
            }

            try
            {
                string loaiPhong = Cbloaiphong.SelectedItem.ToString();
                DataTable dtPhong = datPhongBLL.LayPhongTrongTheoLoai(loaiPhong);

                cbphongtrong.DataSource = dtPhong;
                cbphongtrong.DisplayMember = "SoPhong";
                cbphongtrong.ValueMember = "MaPhong";

                if (dtPhong.Rows.Count == 0)
                {
                    cbphongtrong.Text = "Không còn phòng trống";
                }
            }
            catch (Exception ex)
            {
                // (Không dùng MessageBox)
                Console.WriteLine("Lỗi nạp phòng trống: " + ex.Message);
            }
        }

        private void cbphongtrong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbphongtrong.SelectedValue == null || !(cbphongtrong.SelectedValue is int))
            {
                txbsophong.Clear();
                txbgia.Text = "0";
                return;
            }

            try
            {
                DataRowView drv = (DataRowView)cbphongtrong.SelectedItem;
                txbsophong.Text = drv["SoPhong"].ToString();
                decimal donGia = Convert.ToDecimal(drv["DonGia"]);

                txbgia.Text = string.Format("{0:N0}", donGia);

                // Sau khi có giá, tính toán lại
                TinhToanNgayVaTien("cbphong");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi chọn phòng: " + ex.Message);
            }
        }
        private void LoadDanhSachDatPhongHomNay()
        {
            try
            {
                DataTable dt = datPhongBLL.LayDanhSachDatPhongHomNay();
                listViewDatPhong.Items.Clear();

                foreach (DataRow row in dt.Rows)
                {
                    ListViewItem item = new ListViewItem(row["HoTen"].ToString());
                    item.SubItems.Add(row["SoPhong"].ToString());
                    item.SubItems.Add(row["CCCD"].ToString());
                    item.SubItems.Add(row["SoDienThoai"].ToString());
                    item.SubItems.Add(Convert.ToDateTime(row["NgayNhan"]).ToString("dd/MM/yyyy"));
                    item.SubItems.Add(Convert.ToDateTime(row["NgayTra"]).ToString("dd/MM/yyyy"));
                    item.SubItems.Add(row["SoNguoiO"].ToString());
                    item.SubItems.Add(string.Format(new CultureInfo("vi-VN"), "{0:N0} VND", row["TongTien"]));

                    listViewDatPhong.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi nạp danh sách đặt phòng: " + ex.Message);
            }
        }
        private void DateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            TinhToanNgayVaTien("date");
        }

        private void txbsodem_TextChanged(object sender, EventArgs e)
        {
            if (ActiveControl == txbsodem) // Chỉ chạy khi người dùng gõ
            {
                TinhToanNgayVaTien("sodem");
            }
        }
        private void TinhToanNgayVaTien(string nguoiGoi)
        {
            if (_isCalculating) return; // Ngăn lặp vô hạn
            _isCalculating = true;

            try
            {
                DateTime ngayNhan = datenhan.Value;
                DateTime ngayTra = datetra.Value;
                int soDem = 0;

                // 1. Lấy giá phòng
                decimal giaPhong = 0;
                decimal.TryParse(txbgia.Text.Replace(",", ""), out giaPhong);

                if (nguoiGoi == "date")
                {
                    // Đảm bảo ngày trả luôn sau ngày nhận
                    if (ngayTra.Date <= ngayNhan.Date)
                    {
                        ngayTra = ngayNhan.AddDays(1);
                        datetra.Value = ngayTra; // Cập nhật UI
                    }
                    TimeSpan span = ngayTra.Date - ngayNhan.Date;
                    soDem = (int)Math.Ceiling(span.TotalDays);
                    txbsodem.Text = soDem.ToString();
                }
                else if (nguoiGoi == "sodem")
                {
                    if (int.TryParse(txbsodem.Text, out soDem) && soDem > 0)
                    {
                        datetra.Value = ngayNhan.AddDays(soDem);
                    }
                    else
                    {
                        soDem = 0; // Sẽ tính tiền = 0
                    }
                }
                else if (nguoiGoi == "cbphong")
                {
                    // Chỉ cần lấy số đêm từ textbox và tính lại tiền
                    int.TryParse(txbsodem.Text, out soDem);
                }

                // Tính tiền
                decimal tamTinh = giaPhong * soDem;
                lbttamtinh.Text = string.Format(new CultureInfo("vi-VN"), "{0:N0} VND", tamTinh);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tính toán: " + ex.Message);
            }
            finally
            {
                _isCalculating = false;
            }
        }

        private void butlmmoi_Click(object sender, EventArgs e)
        {
            // Thông tin đăng ký
            Cbloaiphong.SelectedIndex = -1;
            cbphongtrong.DataSource = null;
            cbphongtrong.Items.Clear();
            datenhan.Value = DateTime.Today;
            datetra.Value = DateTime.Today.AddDays(1);
            txbsodem.Text = "1";

            // Thông tin khách hàng
            txbhoten.Clear();
            datesinh.CustomFormat = " ";
            cbgioitinh.SelectedIndex = -1;
            txbCMND.Clear();
            txbsdt.Clear();
            txbdiachi.Clear();

            // Thông tin phòng
            txbsophong.Clear();
            txbsoluong.Clear();
            txbgia.Text = "0";
            lbttamtinh.Text = "0 VND";
        }

        private void butdatphong_Click(object sender, EventArgs e)
        {
            // 1. Validate
            if (!IsFormValid()) return;

            try
            {
                // 2. Tạo Khách hàng
                KhachHang kh = new KhachHang
                {
                    HoTen = txbhoten.Text.Trim(),
                    GioiTinh = cbgioitinh.SelectedItem.ToString(),
                    NgaySinh = (datesinh.CustomFormat == " ") ? DateTime.MinValue : datesinh.Value,
                    CCCD = txbCMND.Text.Trim(),
                    SoDienThoai = txbsdt.Text.Trim(),
                    DiaChi = txbdiachi.Text.Trim()
                };

                // *** ĐÃ SỬA LỖI LOGIC ***
                // Lỗi cũ: Hàm ThemKhachHang trả về 1 (rows affected)
                // Sửa: Hàm ThemKhachHang (đã sửa ở DAL) trả về ID
                int maKhachHang = khachHangBLL.ThemKhachHang(kh);

                // 3. Tạo Đặt phòng
                decimal tongTien = 0;
                decimal.TryParse(lbttamtinh.Text.Replace(" VND", "").Replace(",", ""), out tongTien);

                DatPhong dp = new DatPhong
                {
                    MaPhong = (int)cbphongtrong.SelectedValue,
                    MaKhachHang = maKhachHang, // Giờ đã là ID đúng
                    NgayNhan = datenhan.Value.Date,
                    NgayTra = datetra.Value.Date,
                    SoNguoiO = int.Parse(txbsoluong.Text),
                    TongTien = tongTien
                };

                // 4. Lưu Đặt phòng
                bool thanhCong = datPhongBLL.ThemDatPhong(dp);

                if (thanhCong)
                {
                    MessageBox.Show("Đặt phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    butlmmoi_Click(null, null);
                    LoadDanhSachDatPhongHomNay();
                }
                else
                {
                    ShowError("Đặt phòng thất bại. Vui lòng thử lại.");
                }
            }
            catch (Exception ex)
            {
                ShowError("Lỗi khi đặt phòng: " + ex.Message);
            }
        }
        private bool IsFormValid()
        {
            // 1. Kiểm tra phòng
            if (Cbloaiphong.SelectedIndex == -1)
            {
                ShowError("Vui lòng chọn loại phòng.");
                return false;
            }
            if (cbphongtrong.SelectedValue == null)
            {
                ShowError("Vui lòng chọn phòng trống.");
                return false;
            }

            // 2. Kiểm tra ngày
            if (datetra.Value.Date <= datenhan.Value.Date || txbsodem.Text == "0")
            {
                ShowError("Ngày trả phải sau ngày nhận (ít nhất 1 đêm).");
                return false;
            }

            // 3. Kiểm tra khách hàng
            if (string.IsNullOrWhiteSpace(txbhoten.Text))
            {
                ShowError("Vui lòng nhập họ tên khách hàng.");
                txbhoten.Focus();
                return false;
            }
            if (cbgioitinh.SelectedIndex == -1)
            {
                ShowError("Vui lòng chọn giới tính.");
                return false;
            }
            if (!Regex.IsMatch(txbCMND.Text, @"^(\d{9}|\d{12})$"))
            {
                ShowError("CCCD/CMND phải là 9 hoặc 12 số.");
                txbCMND.Focus();
                return false;
            }
            if (!Regex.IsMatch(txbsdt.Text, @"^\d{10}$"))
            {
                ShowError("Số điện thoại phải là 10 số.");
                txbsdt.Focus();
                return false;
            }

            // 4. Kiểm tra thông tin phòng
            if (string.IsNullOrWhiteSpace(txbsoluong.Text) || int.Parse(txbsoluong.Text) <= 0)
            {
                ShowError("Vui lòng nhập số người ở (ít nhất 1).");
                txbsoluong.Focus();
                return false;
            }

            return true;
        }

        private void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Sự kiện KeyPress để chỉ cho phép nhập số
        private void TextBox_OnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
