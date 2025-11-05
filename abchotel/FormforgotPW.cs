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
       
        NguoiDungBLL bll = new NguoiDungBLL();
        private string otpCode;
        private string otoCode;
        private string GenerateOTP()
        {
            Random random = new Random();
            int otp = random.Next(100000, 999999);
            return otp.ToString();
        }

        public FormforgotPW()
        { 
            
            InitializeComponent();
        }
        private void label2_Click(object sender, EventArgs e)
        {
           
            string username = txtUsername.Text.Trim();
            string email = txtOTP.Text.Trim();
            string newPassword = txtEmail.Text.Trim();
           
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // Gọi lớp BLL hoặc DAL để kiểm tra thông tin
            NguoiDungBLL userBLL = new NguoiDungBLL();
            bool result = userBLL.LayTatCa( username, email, newPassword);

            if (result)
                MessageBox.Show("Đặt lại mật khẩu thành công!");
            else
                MessageBox.Show("Tên đăng nhập hoặc email không đúng!");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();

            NguoiDung user = NguoiDungBLL.CheckEmail(email);

            if (user == null || !user.TenDangNhap.Equals(username, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Tên đăng nhập hoặc Email không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            otoCode= bll.GenerateOTP();

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress("youremail@gmail.com");
                mail.To.Add(email);
                mail.Subject = "Mã OTP - Quên mật khẩu";
                mail.Body = "Xin chào " + username + ",\n\nMã OTP của bạn là: " + otpCode + "\n\nTrân trọng,\nHệ thống Quản lý Khách sạn";

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

            bool result = bll.DoiMatKhau(txtEmail, txtNewPass.Text.Trim());

            if (result)
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                new FormMain().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đổi mật khẩu thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
