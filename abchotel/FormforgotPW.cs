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
using System.Data.SqlClient;
using abchotel.Model;
using System.Net;
using System.Net.Mail;
using abchotel.DAL;
namespace abchotel
{
    public partial class FormforgotPW : Form
    {
        private string otpCode;
        private NguoiDungBLL bll = new NguoiDungBLL();
        public FormforgotPW()
        {
            InitializeComponent();
        }

        private void bntXacnhan_Click(object sender, EventArgs e)
        {
            if (txtOTP.Text.Trim() != otpCode)
            {
                MessageBox.Show("Mã OTP không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNewPass.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu mới!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool result = bll.DoiMatKhauTheoTen(txtUsername.Text.Trim(), txtEmail.Text.Trim(), txtNewPass.Text.Trim());

            if (result)
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Hide();
                new FormLogin().Show();
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void bntGui_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();

            NguoiDung user = bll.CheckEmail(email);

            if (user == null || !user.TenDangNhap.Equals(username, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Tên đăng nhập hoặc Email không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Tạo mã OTP ngẫu nhiên
            otpCode = new Random().Next(100000, 999999).ToString();

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("youremail@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Mã OTP - Quên mật khẩu";
                mail.Body = $"Xin chào {username},\n\nMã OTP của bạn là: {otpCode}\n\nTrân trọng,\nHệ thống ABC Hotel";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("youremail@gmail.com", "your_app_password");
                smtp.EnableSsl = true;
                smtp.Send(mail);

                MessageBox.Show("Đã gửi mã OTP đến email của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception)
            {
                MessageBox.Show("Không thể gửi email. Vui lòng kiểm tra kết nối hoặc cấu hình Gmail!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
