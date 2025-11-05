using abchotel.BLL;
using abchotel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace abchotel
{
    public partial class FormCustomer : Form
    {
        private KhachHangBLL khBLL = new KhachHangBLL();
        private int maKhachDangChon = -1;
        public FormCustomer()
        {
            InitializeComponent();
            KhoiTaoDatePicker();
            LoadDanhSachKhachHang();
            txtSDT.MaxLength = 10;
            txtCCCD.MaxLength = 12; 

        }
        private void KhoiTaoDatePicker()
        {
            dateNgaysinh.Format = DateTimePickerFormat.Custom;
            dateNgaysinh.CustomFormat = " "; 
        }
        private void LoadDanhSachKhachHang()
        {
            var ds = khBLL.LayTatCaKhachHang();
            HienThiKhachHang(ds);
        }
        
        private void lstKhachhang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstKhachHang.SelectedItems.Count == 0) return;

            var item = lstKhachHang.SelectedItems[0];
            maKhachDangChon = int.Parse(item.Text);

            txtMaKH.Text = item.Text;
            txtTenKH.Text = item.SubItems[1].Text;
            if (item.SubItems[2].Text == "Nam")
                rdoNam.Checked = true;
            else if (item.SubItems[2].Text == "Nữ")
                rdoNu.Checked = true;
            else
            {
                rdoNam.Checked = false;
                rdoNu.Checked = false;
            }

            txtCCCD.Text = item.SubItems[4].Text;
            txtSDT.Text = item.SubItems[5].Text;
            txtDiachi.Text = item.SubItems[6].Text;
            lblPhong.Text = item.SubItems[7].Text;

            // Xử lý ngày sinh trống
            if (string.IsNullOrWhiteSpace(item.SubItems[3].Text))
                dateNgaysinh.CustomFormat = " ";
            else
            {
                dateNgaysinh.CustomFormat = "dd/MM/yyyy";
                dateNgaysinh.Value = DateTime.ParseExact(item.SubItems[3].Text, "dd/MM/yyyy", null);
            }
        }
        private bool IsFormValid()
        {
            // 1. Kiểm tra Tên
            if (string.IsNullOrWhiteSpace(txtTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên khách hàng.");
                txtTenKH.Focus();
                return false;
            }

            // 2. Kiểm tra Giới tính
            if (!rdoNam.Checked && !rdoNu.Checked)
            {
                MessageBox.Show("Vui lòng chọn Giới tính.");
                return false;
            }

            // 3. Kiểm tra SĐT
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại.");
                txtSDT.Focus();
                return false;
            }
            if (txtSDT.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 số.");
                txtSDT.Focus();
                return false;
            }
            // Kiểm tra SĐT có phải toàn số không (phòng trường hợp copy-paste)
            if (!Regex.IsMatch(txtSDT.Text, @"^\d{10}$"))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa số.");
                txtSDT.Focus();
                return false;
            }


            // 4. Kiểm tra CCCD
            if (string.IsNullOrWhiteSpace(txtCCCD.Text))
            {
                MessageBox.Show("Vui lòng nhập số CCCD/Passport.");
                txtCCCD.Focus();
                return false;
            }
            // Cho phép CMND 9 số hoặc CCCD 12 số
            if (txtCCCD.Text.Length != 9 && txtCCCD.Text.Length != 12)
            {
                MessageBox.Show("CCCD/CMND phải có 9 hoặc 12 số.");
                txtCCCD.Focus();
                return false;
            }
            // Kiểm tra CCCD có phải toàn số không
            if (!Regex.IsMatch(txtCCCD.Text, @"^\d+$"))
            {
                MessageBox.Show("CCCD/CMND chỉ được chứa số.");
                txtCCCD.Focus();
                return false;
            }

            return true; // Tất cả đều hợp lệ
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!IsFormValid()) return;
            try
            {
                var kh = new KhachHang
                {
                    HoTen = txtTenKH.Text.Trim(),
                    GioiTinh = rdoNam.Checked ? "Nam" : (rdoNu.Checked ? "Nữ" : ""),
                    NgaySinh = (dateNgaysinh.CustomFormat == " ") ? DateTime.MinValue : dateNgaysinh.Value,
                    CCCD = txtCCCD.Text.Trim(),
                    SoDienThoai = txtSDT.Text.Trim(),
                    DiaChi = txtDiachi.Text.Trim()
                };

                khBLL.ThemKhachHang(kh);
                LoadDanhSachKhachHang();
                MessageBox.Show("Đã thêm khách hàng mới!");
                btnHuy_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maKhachDangChon < 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để sửa!");
                return;
            }
            if (!IsFormValid()) return;
            try
            {
                var kh = new KhachHang
                {
                    MaKhachHang = maKhachDangChon,
                    HoTen = txtTenKH.Text.Trim(),
                    GioiTinh = rdoNam.Checked ? "Nam" : (rdoNu.Checked ? "Nữ" : ""),
                    NgaySinh = (dateNgaysinh.CustomFormat == " ") ? DateTime.MinValue : dateNgaysinh.Value,
                    CCCD = txtCCCD.Text.Trim(),
                    SoDienThoai = txtSDT.Text.Trim(),
                    DiaChi = txtDiachi.Text.Trim()
                };

                khBLL.SuaKhachHang(kh);
                LoadDanhSachKhachHang();
                MessageBox.Show("Cập nhật khách hàng thành công!");
                btnHuy_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maKhachDangChon < 0)
            {
                MessageBox.Show("Vui lòng chọn khách hàng để xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa khách hàng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    khBLL.XoaKhachHang(maKhachDangChon);
                    LoadDanhSachKhachHang();
                    MessageBox.Show("Đã xóa khách hàng!");
                    btnHuy_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtMaKH.Clear();
            txtTenKH.Clear();
            rdoNam.Checked = false;
            rdoNu.Checked = false;
            txtCCCD.Clear();
            txtSDT.Clear();
            txtDiachi.Clear();
            txtTimkiem.Clear();
            dateNgaysinh.CustomFormat = " "; 
            lblPhong.Text = "Phòng:";
            maKhachDangChon = -1; 
            lstKhachHang.SelectedItems.Clear();
            LoadDanhSachKhachHang();
        }

        private void pbTimkiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimkiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadDanhSachKhachHang();
                return;
            }

            var result = khBLL.TimKiemKhachHang(keyword);

            HienThiKhachHang(result);
        }

        private void txtTimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                pbTimkiem_Click(null, null);
        }
        private void HienThiKhachHang(List<KhachHang> ds)
        {
            lstKhachHang.Items.Clear();
            foreach (var kh in ds)
            {
                ListViewItem item = new ListViewItem(kh.MaKhachHang.ToString());
                item.SubItems.Add(kh.HoTen);
                item.SubItems.Add(kh.GioiTinh);
                item.SubItems.Add(kh.NgaySinh == DateTime.MinValue ? "" : kh.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(kh.CCCD);
                item.SubItems.Add(kh.SoDienThoai);
                item.SubItems.Add(kh.DiaChi);
                item.SubItems.Add(kh.SoPhongHienTai ?? "Chưa có");
                lstKhachHang.Items.Add(item);
            }
        }

        private void dateNgaysinh_ValueChanged(object sender, EventArgs e)
        {
            dateNgaysinh.CustomFormat = "dd/MM/yyyy";
        }

        private void txtCCCD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; 
            }
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
