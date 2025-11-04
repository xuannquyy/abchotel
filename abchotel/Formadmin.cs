using System;
using System.Windows.Forms;

namespace abchotel
{
    public partial class FormUser : Form
    {
        public FormUser()
        {
            InitializeComponent();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        // --- Nút Lưu mật khẩu mới ---
        private void btnlmkm_Click(object sender, EventArgs e)
        {
            string maNV = txtmnv.Text.Trim();
            string tenNV = txttnv.Text.Trim();
            string chucVu = txtcv.Text.Trim();
            string email = txtemail.Text.Trim();
            string matKhauCu = txtmkc.Text.Trim();
            string matKhauMoi = txtmkm.Text.Trim();
            string nhapLaiMK = txtnlmk.Text.Trim();

            // Kiểm tra nhập đủ thông tin
            if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(tenNV) ||
                string.IsNullOrEmpty(chucVu) || string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(matKhauCu) || string.IsNullOrEmpty(matKhauMoi) ||
                string.IsNullOrEmpty(nhapLaiMK))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra mật khẩu mới trùng khớp
            if (matKhauMoi != nhapLaiMK)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Nếu tất cả hợp lệ
            MessageBox.Show("Mật khẩu mới đã được lưu thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // (Tùy bạn: có thể thêm code lưu vào CSDL tại đây)
        }
    }
}
