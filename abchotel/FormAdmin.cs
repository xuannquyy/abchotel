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
using abchotel.BLL;
using abchotel.Model;

namespace abchotel
{
    public partial class FormAdmin : Form
    {
        private readonly NguoiDungBLL bll = new NguoiDungBLL();
        public FormAdmin()
        {
            InitializeComponent();
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            cbChucVu.Items.AddRange(new string[] { "Admin", "User" });
            HienThiDS();
        }
        private void HienThiDS()
        {
            lvTaiKhoan.Items.Clear();
            DataTable dt = bll.LayTatCa();
            foreach (DataRow r in dt.Rows)
            {
                ListViewItem item = new ListViewItem(r["MaNguoiDung"].ToString());
                item.SubItems.Add(r["TenDangNhap"].ToString());
                item.SubItems.Add(r["HoTen"].ToString());
                item.SubItems.Add(r["Email"].ToString());
                item.SubItems.Add(r["VaiTro"].ToString());
                lvTaiKhoan.Items.Add(item);
            }
        }

        private void btthemmoi_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbtendn.Text) ||
                string.IsNullOrWhiteSpace(txbmatkhau.Text) ||
                string.IsNullOrWhiteSpace(txbhoten.Text))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }

            var nd = new NguoiDung()
            {
                TenDangNhap = txbtendn.Text,
                MatKhau = txbmatkhau.Text,
                HoTen = txbhoten.Text,
                Email = txbmail.Text,
                VaiTro = cbChucVu.Text
            };

            if (bll.Them(nd))
            {
                MessageBox.Show("Thêm tài khoản thành công!");
                HienThiDS();
                LamMoi();
            }
        }

        private void btxoatk_Click(object sender, EventArgs e)
        {
            if (lvTaiKhoan.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần xóa!");
                return;
            }

            int ma = int.Parse(lvTaiKhoan.SelectedItems[0].SubItems[0].Text);
            if (bll.Xoa(ma))
            {
                MessageBox.Show("Xóa thành công!");
                HienThiDS();
            }
        }

        private void btluu_Click(object sender, EventArgs e)
        {
            LamMoi();
        }
        private void LamMoi()
        {
            txbtendn.Clear();
            txbmatkhau.Clear();
            txbhoten.Clear();
            txbmail.Clear();
            cbChucVu.SelectedIndex = -1;
        }
        private void btreset_Click(object sender, EventArgs e)
        {
            if (lvTaiKhoan.SelectedItems.Count == 0)
            {
                MessageBox.Show("Chọn tài khoản cần đổi mật khẩu!");
                return;
            }

            int ma = int.Parse(lvTaiKhoan.SelectedItems[0].SubItems[0].Text);
            string cu = Microsoft.VisualBasic.Interaction.InputBox("Nhập mật khẩu cũ:", "Reset mật khẩu");
            string moi = Microsoft.VisualBasic.Interaction.InputBox("Nhập mật khẩu mới:", "Reset mật khẩu");

            if (bll.DoiMatKhau(ma, cu, moi))
                MessageBox.Show("Đổi mật khẩu thành công!");
            else
                MessageBox.Show("Mật khẩu cũ không đúng!");

            HienThiDS();
        }
    }
}
