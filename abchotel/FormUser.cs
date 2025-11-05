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
            this.maNguoiDung = maNguoiDung;
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
            DataTable dt = bll.LayTatCa();
            nguoiDungHienTai = null;

            foreach (DataRow row in dt.Rows)
            {
                if ((int)row["MaNguoiDung"] == maNguoiDung)
                {
                    nguoiDungHienTai = new NguoiDung
                    {
                        MaNguoiDung = maNguoiDung,
                        TenDangNhap = row["TenDangNhap"].ToString(),
                        HoTen = row["HoTen"].ToString(),
                        Email = row["Email"].ToString(),
                        VaiTro = row["VaiTro"].ToString(),
                        MatKhau = row["MatKhau"].ToString()
                    };
                    break;
                }
            }

            if (nguoiDungHienTai != null)
            {
                txtTenDangNhap.Text = nguoiDungHienTai.TenDangNhap;
                txtHoTen.Text = nguoiDungHienTai.HoTen;
                txtEmail.Text = nguoiDungHienTai.Email;
                txtChucVu.Text = nguoiDungHienTai.VaiTro;
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
            string query = "UPDATE NguoiDung SET HoTen = @HoTen, Email = @Email WHERE MaNguoiDung = @Ma";
            bool kq = abchotel.DAL.DatabaseHelper.ExecuteNonQuery(
                query,
                ("@HoTen", txtHoTen.Text.Trim()),
                ("@Email", txtEmail.Text.Trim()),
                ("@Ma", maNguoiDung)
            ) > 0;

            if (kq)
                MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo");
        }
    }
}
