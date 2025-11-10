using abchotel.BLL;
using abchotel.Model;
using System;
using System.Data;
using System.Windows.Forms;

namespace abchotel
{
    public partial class FormUser : Form
    {
        private readonly NguoiDungBLL bll = new NguoiDungBLL();
        private readonly int maNguoiDung; // lấy từ khi login
        private NguoiDung nguoiDungHienTai;
        public FormUser()
        {
            InitializeComponent();
        }
        public FormUser(int maNguoiDungDangNhap) : this() // 'this()' gọi hàm FormUser() ở trên
        {
            this.maNguoiDung = maNguoiDungDangNhap;
        }
        private void btnlmkm_Click(object sender, EventArgs e)
        {
            string cu = txtmkc.Text.Trim();
            string moi = txtmkm.Text.Trim();
            string xacNhan = txtXacNhan.Text.Trim();

            if (string.IsNullOrEmpty(cu) || string.IsNullOrEmpty(moi) || string.IsNullOrEmpty(xacNhan))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo");
                return;
            }

            if (moi != xacNhan)
            {
                MessageBox.Show("Mật khẩu mới không khớp!", "Lỗi");
                return;
            }
            if (bll.DoiMatKhau(maNguoiDung, cu, moi))
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo");
                txtmkc.Clear();
                txtmkm.Clear();
                txtXacNhan.Clear();
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng!", "Lỗi");
            }
        }

        private void FormUser_Load(object sender, EventArgs e)
        {
            HienThiThongTin();
        }
        private void HienThiThongTin()
        {
            nguoiDungHienTai = bll.LayTheoMa(this.maNguoiDung);

            if (nguoiDungHienTai != null)
            {
                txtmnv.Text = nguoiDungHienTai.MaNguoiDung.ToString();
                txtTenDangNhap.Text = nguoiDungHienTai.TenDangNhap;
                txtHoTen.Text = nguoiDungHienTai.HoTen;
                txtEmail.Text = nguoiDungHienTai.Email;
                txtChucVu.Text = nguoiDungHienTai.VaiTro;
            }
            else
            {
                MessageBox.Show("Không thể tải thông tin người dùng!");
                this.Close();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtmkc.Clear();
            txtmkm.Clear();
            txtXacNhan.Clear();
        }

        private void btnLuuthongtin_Click(object sender, EventArgs e)
        {
            // Cập nhật thông tin vào đối tượng
            nguoiDungHienTai.HoTen = txtHoTen.Text.Trim();
            nguoiDungHienTai.Email = txtEmail.Text.Trim();

            bool kq = bll.SuaThongTinCaNhan(nguoiDungHienTai);

            if (kq)
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo");
            else
                MessageBox.Show("Cập nhật thất bại!", "Lỗi");
        }
    }
}
