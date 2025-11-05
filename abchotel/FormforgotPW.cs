using abchotel.BLL;
using abchotel.DAL;
using abchotel.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
                this.Close();
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
                string fromMail = ConfigurationManager.AppSettings["SmtpEmail"];
                string fromPassword = ConfigurationManager.AppSettings["SmtpPassword"];

                if (string.IsNullOrEmpty(fromMail) || string.IsNullOrEmpty(fromPassword))
                {
                    MessageBox.Show("Lỗi: Chưa cấu hình email gửi đi trong App.config!", "Lỗi cấu hình", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(fromMail);
                mail.To.Add(email);
                mail.Subject = "Mã OTP - Quên mật khẩu";
                mail.Body = $"Xin chào {username},\n\nMã OTP của bạn là: {otpCode}\n\nTrân trọng,\nHệ thống ABC Hotel";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential(fromMail, fromPassword); // Dùng 2 biến
                smtp.EnableSsl = true;
                smtp.Send(mail);

                MessageBox.Show("Đã gửi mã OTP đến email của bạn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("Không thể gửi email. Vui lòng kiểm tra lại cấu hình email và Mật khẩu ứng dụng trong App.config!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
