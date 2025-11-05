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
    public partial class Formlgin : Form
    {
        public Formlgin()
        {
            InitializeComponent();
        
        private void Formlgin_Load(object sender, EventArgs e)
        {

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

            NguoiDung user =  NguoiDungBLL.(username, password);
            if

            (user != null)
            { MessageBox.Show(" Tên đăng nhập hoặc mật khẩu không đúng!");
            }
            else if ( user.VaiTro == "Admin")
            { 
                FormAdmin formAdmin = new FormAdmin();
                this.Hide();
                formAdmin.ShowDialog();
                this.Show();
            }
            else if (user.VaiTro == "Nguoi Dung")
            {
                FormMain formMain = new FormMain();
                this.Hide();
                formMain.ShowDialog();
                this.Show();
            } 
        }

          private void checkBox1_CheckedChanged(object sender, EventArgs e)
               {
                  if (checkBoxhienmk.Checked)
                   {
                    txtMatkhau.PasswordChar = '\0';
                   }
                  else
                            {
                                txtMatkhau.PasswordChar = '*';
                            }
                        }

        

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormforgotPW formforgotPW = new FormforgotPW();
            this.Hide();
            formforgotPW.ShowDialog();
            this.Show();
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
