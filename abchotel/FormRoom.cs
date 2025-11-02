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
    public partial class FormRoom : Form
    {
        private PhongBLL phongBLL = new PhongBLL();
        private int maPhongDangChon = -1;

        public FormRoom()
        {
            InitializeComponent();
            KhoiTaoDatePicker();
            LoadFullList();
            txtTimkiem.Focus();
        }
        private void KhoiTaoDatePicker()
        {
            dateNhan.Format = DateTimePickerFormat.Custom;
            dateNhan.CustomFormat = " ";
            dateTra.Format = DateTimePickerFormat.Custom;
            dateTra.CustomFormat = " ";
        }
        private void LoadFullList()
        {
            var ds = phongBLL.LayTatCaPhong();
            HienThiPhong(ds);
        }
        private void HienThiPhong(List<Phong> ds)
        {
            lstPhong.Items.Clear();
            foreach (var p in ds)
            {
                ListViewItem item = CreateListViewItemFromPhong(p);
                lstPhong.Items.Add(item);
            }
        }
        private ListViewItem CreateListViewItemFromPhong(Phong p)
        {
            ListViewItem item = new ListViewItem(p.MaPhong.ToString());
            item.SubItems.Add(p.TenKhachHang ?? "");
            item.SubItems.Add(p.SoPhong ?? "");
            item.SubItems.Add(p.LoaiPhong ?? "");
            item.SubItems.Add(p.NgayNhan?.ToString("dd/MM/yyyy") ?? "");
            item.SubItems.Add(p.NgayTra?.ToString("dd/MM/yyyy") ?? "");
            item.SubItems.Add(p.DonGia.ToString("N0"));
            return item;
        }
        private void lstPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPhong.SelectedItems.Count == 0) return;

            var item = lstPhong.SelectedItems[0];
            maPhongDangChon = int.Parse(item.Text);

            txtMaphong.Text = item.SubItems[0].Text;
            txtTenKH.Text = item.SubItems[1].Text;
            txtSophong.Text = item.SubItems[2].Text;
            txtLoaiphong.Text = item.SubItems[3].Text;
            txtDongia.Text = item.SubItems[6].Text;

            if (!string.IsNullOrWhiteSpace(item.SubItems[4].Text))
            {
                dateNhan.CustomFormat = "dd/MM/yyyy";
                dateNhan.Value = DateTime.ParseExact(item.SubItems[4].Text, "dd/MM/yyyy", null);
            }
            else dateNhan.CustomFormat = " ";

            if (!string.IsNullOrWhiteSpace(item.SubItems[5].Text))
            {
                dateTra.CustomFormat = "dd/MM/yyyy";
                dateTra.Value = DateTime.ParseExact(item.SubItems[5].Text, "dd/MM/yyyy", null);
            }
            else dateTra.CustomFormat = " ";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var p = new Phong
                {
                    TenKhachHang = txtTenKH.Text.Trim(),
                    SoPhong = txtSophong.Text.Trim(),
                    LoaiPhong = txtLoaiphong.Text.Trim(),
                    DonGia = decimal.TryParse(txtDongia.Text, out decimal g) ? g : 0,
                    NgayNhan = dateNhan.CustomFormat == " " ? (DateTime?)null : dateNhan.Value,
                    NgayTra = dateTra.CustomFormat == " " ? (DateTime?)null : dateTra.Value,
                    TrangThai = string.IsNullOrWhiteSpace(txtTenKH.Text) ? "Trống" : "Đang ở"
                };

                phongBLL.ThemPhong(p);
                LoadFullList();
                MessageBox.Show("Đã thêm phòng mới!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (maPhongDangChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn phòng để sửa!");
                return;
            }

            try
            {
                var p = new Phong
                {
                    MaPhong = maPhongDangChon,
                    TenKhachHang = txtTenKH.Text.Trim(),
                    SoPhong = txtSophong.Text.Trim(),
                    LoaiPhong = txtLoaiphong.Text.Trim(),
                    DonGia = decimal.TryParse(txtDongia.Text, out decimal g2) ? g2 : 0,
                    NgayNhan = dateNhan.CustomFormat == " " ? (DateTime?)null : dateNhan.Value,
                    NgayTra = dateTra.CustomFormat == " " ? (DateTime?)null : dateTra.Value,
                    TrangThai = string.IsNullOrWhiteSpace(txtTenKH.Text) ? "Trống" : "Đang ở"
                };

                phongBLL.SuaPhong(p);
                LoadFullList();
                MessageBox.Show("Cập nhật phòng thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (maPhongDangChon <= 0)
            {
                MessageBox.Show("Vui lòng chọn phòng để xóa!");
                return;
            }

            if (MessageBox.Show("Bạn có chắc muốn xóa phòng này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    phongBLL.XoaPhong(maPhongDangChon);
                    LoadFullList();
                    MessageBox.Show("Đã xóa phòng!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                }
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn hủy tất cả thay đổi chưa lưu?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                LoadFullList();
                txtMaphong.Clear();
                txtTenKH.Clear();
                txtSophong.Clear();
                txtLoaiphong.Clear();
                txtDongia.Clear();
                dateNhan.CustomFormat = " ";
                dateTra.CustomFormat = " ";
                maPhongDangChon = -1;
            }
        }

        private void pbTimkiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimkiem.Text.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                LoadFullList();
                return;
            }

            var result = phongBLL.LayTatCaPhong()
                .Where(p => p.SoPhong.Contains(keyword) || (p.TenKhachHang ?? "").Contains(keyword))
                .ToList();
            HienThiPhong(result);
        }

        private void txtTimkiem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                pbTimkiem_Click(null, null);
        }

        private void dateNhan_ValueChanged(object sender, EventArgs e)
        {
            dateNhan.CustomFormat = "dd/MM/yyyy";
        }

        private void dateTra_ValueChanged(object sender, EventArgs e)
        {
            dateTra.CustomFormat = "dd/MM/yyyy";
        }
    }
}
