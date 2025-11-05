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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string username = txtTen.Text.Trim();
            string password = txtMatkhau.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!");
                return;
            }

            NguoiDungBLL bll = new NguoiDungBLL();
            NguoiDung user = bll.DangNhap(username, password);
            if (user == null)
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");
            }
            else if (user.VaiTro == "Admin")
            {
                FormAdmin formAdmin = new FormAdmin();
                this.Hide();

                formAdmin.FormClosed += (s, args) => this.Show();

                formAdmin.Show();
            }
            else if (user.VaiTro == "User")
            {
                FormMain formMain = new FormMain(user);
                this.Hide();

                formMain.FormClosed += (s, args) => Application.Exit();
                formMain.Show();
            }
            else
            {
                MessageBox.Show("Vai trò người dùng không được hỗ trợ: " + user.VaiTro);
            }
        }

          
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormforgotPW formforgotPW = new FormforgotPW();
            this.Hide();
            formforgotPW.ShowDialog();
            this.Show();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtTen.Clear();
            txtMatkhau.Clear();
            txtTen.Focus();
            txtMatkhau.PasswordChar = '•';

            checkBoxhienmk.Checked = false;
        }

        private void checkBoxhienmk_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxhienmk.Checked)
            {
                txtMatkhau.PasswordChar = '\0';
            }
            else
            {
                txtMatkhau.PasswordChar = '•';
            }
        }
    }
}
