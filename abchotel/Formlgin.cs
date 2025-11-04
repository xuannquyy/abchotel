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
    public partial class Formlgin : Form
    {
        public Formlgin()
        {
            InitializeComponent();
        }

        private void Formlgin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            string username  = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!");
                return;
            }

            UserBLL userBLL = new UserBLL();
            bool result = userBLL.CheckLogin(username, password);

            if (result)
            {
                MessageBox.Show("Đăng nhập thành công!");
                this.Hide(); // Ẩn form login
                FormMain FormMain = new FormMain(); // Mở form chính
                FormMain.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormforgotPW formforgotPW = new FormforgotPW();
            formforgotPW.ShowDialog();
        }
    }
}
