using abchotel.BLL;
using abchotel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        }
        private void KhoiTaoDatePicker()
        {
            dateNgaysinh.Format = DateTimePickerFormat.Custom;
            dateNgaysinh.CustomFormat = " "; 
        }
        private void LoadDanhSachKhachHang()
        {
            lstKhachHang.Items.Clear();
            var ds = khBLL.LayTatCaKhachHang();

            foreach (var kh in ds)
            {
                ListViewItem item = new ListViewItem(kh.MaKhachHang.ToString());
                item.SubItems.Add(kh.HoTen);
                item.SubItems.Add(kh.GioiTinh);
                item.SubItems.Add(kh.NgaySinh == DateTime.MinValue ? "" : kh.NgaySinh.ToString("dd/MM/yyyy"));
                item.SubItems.Add(kh.CCCD);
                item.SubItems.Add(kh.SoDienThoai);
                item.SubItems.Add(kh.DiaChi);
                item.SubItems.Add(LaySoPhongTheoKhach(kh.MaKhachHang)); // cột Số phòng
                lstKhachHang.Items.Add(item);
            }
        }
        private string LaySoPhongTheoKhach(int maKhach)
        {
            try
            {
                string query = @"SELECT p.SoPhong 
                                 FROM DatPhong dp 
                                 JOIN Phong p ON dp.MaPhong = p.MaPhong
                                 WHERE dp.MaKhachHang = @ma";
                var dt = abchotel.DAL.DatabaseHelper.GetData(query, ("@ma", maKhach));
                return dt.Rows.Count > 0 ? dt.Rows[0]["SoPhong"].ToString() : "Chưa có";
            }
            catch
            {
                return "Chưa có";
            }
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
            lblPhong.Text = "Phòng: " + item.SubItems[7].Text;

            // Xử lý ngày sinh trống
            if (string.IsNullOrWhiteSpace(item.SubItems[3].Text))
                dateNgaysinh.CustomFormat = " ";
            else
            {
                dateNgaysinh.CustomFormat = "dd/MM/yyyy";
                dateNgaysinh.Value = DateTime.ParseExact(item.SubItems[3].Text, "dd/MM/yyyy", null);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var kh = new KhachHang
                {
                    HoTen = txtTenKH.Text.Trim(),
                    GioiTinh = rdoNam.Checked ? "Nam" : (rdoNu.Checked ? "Nữ" : ""),
                    NgaySinh = dateNgaysinh.CustomFormat == " " ? DateTime.MinValue : dateNgaysinh.Value,
                    CCCD = txtCCCD.Text.Trim(),
                    SoDienThoai = txtSDT.Text.Trim(),
                    DiaChi = txtDiachi.Text.Trim()
                };

                khBLL.ThemKhachHang(kh);
                LoadDanhSachKhachHang();
                MessageBox.Show("Đã thêm khách hàng mới!");
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

            try
            {
                var kh = new KhachHang
                {
                    MaKhachHang = maKhachDangChon,
                    HoTen = txtTenKH.Text.Trim(),
                    GioiTinh = rdoNam.Checked ? "Nam" : (rdoNu.Checked ? "Nữ" : ""),
                    NgaySinh = dateNgaysinh.CustomFormat == " " ? DateTime.MinValue : dateNgaysinh.Value,
                    CCCD = txtCCCD.Text.Trim(),
                    SoDienThoai = txtSDT.Text.Trim(),
                    DiaChi = txtDiachi.Text.Trim()
                };

                khBLL.SuaKhachHang(kh);
                LoadDanhSachKhachHang();
                MessageBox.Show("Cập nhật khách hàng thành công!");
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Hủy tất cả thay đổi chưa lưu?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LoadDanhSachKhachHang();
                txtMaKH.Clear();
                txtTenKH.Clear();
                rdoNam.Checked = false;
                rdoNu.Checked = false;
                txtCCCD.Clear();
                txtSDT.Clear();
                txtDiachi.Clear();
                dateNgaysinh.CustomFormat = " ";
                lblPhong.Text = "Phòng:";
                maKhachDangChon = -1;
            }
        }

        private void pbTimkiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimkiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadDanhSachKhachHang();
                return;
            }

            var result = khBLL.LayTatCaKhachHang()
                .Where(k => LaySoPhongTheoKhach(k.MaKhachHang).Contains(keyword))
                .ToList();

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
                item.SubItems.Add(LaySoPhongTheoKhach(kh.MaKhachHang));
                lstKhachHang.Items.Add(item);
            }
        }
    }
}
