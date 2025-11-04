using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
namespace abchotel
{
    public partial class FormforgotPW : Form
    {
        public FormforgotPW()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
           
            string username = textBox1.Text.Trim();
            string email = textBox2.Text.Trim();
            string newPassword = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            // Gọi lớp BLL hoặc DAL để kiểm tra thông tin
            UserBLL userBLL = new UserBLL();
            bool result = userBLL.ResetPassword(username, email, newPassword);

            if (result)
                MessageBox.Show("Đặt lại mật khẩu thành công!");
            else
                MessageBox.Show("Tên đăng nhập hoặc email không đúng!");
        }
    
    }
}
