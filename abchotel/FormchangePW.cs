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
    public partial class FormchangePW : Form
    {
        public FormchangePW()
        {
            InitializeComponent();
        }

        private void FormchangePW_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string oldPass = textBox1.Text.Trim();
            string newPass = textBox2.Text.Trim();
            string confirm = textBox3.Text.Trim();
            string username = textBox4.Text; // hoặc lấy từ biến lưu user đang đăng nhập

            if (string.IsNullOrEmpty(oldPass) || string.IsNullOrEmpty(newPass) || string.IsNullOrEmpty(confirm))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (newPass != confirm)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!");
                return;
            }

            UserBLL userBLL = new UserBLL();
            bool result = userBLL.ChangePassword(username, oldPass, newPass);

            if (result)
            {
                MessageBox.Show("Đổi mật khẩu thành công!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng!");
            }
        }
    }
    }
}
