using abchotel.BLL;
using abchotel.Model;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace abchotel
{
    public partial class FormMain : Form
    {
        DatPhongBLL datPhongBLL = new DatPhongBLL();
        HoaDonBLL hoaDonBLL = new HoaDonBLL();
        PhongBLL phongBLL = new PhongBLL();
        private string tenNhanVienHienTai;
        private int maNhanVienHienTai;
        public FormMain()
        {
            InitializeComponent();
            timer1.Interval = 1000;
            timer1.Start();
        }
        public FormMain(NguoiDung user) : this() 
        {
            this.tenNhanVienHienTai = user.HoTen;
            this.maNhanVienHienTai = user.MaNguoiDung; 
            lblNhanvien.Text = "Nhân viên: " + this.tenNhanVienHienTai;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = "Thời gian: " + DateTime.Now.ToString("dd/MM/yyyy") + " " + DateTime.Now.ToString("HH:mm:ss");
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát phần mềm?","Xác nhận",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning)== DialogResult.Cancel)
            {
                e.Cancel = true;
            }    
        }
        
        private void FormMain_Load(object sender, EventArgs e)
        {
            CapNhatDuLieu();
        }
        public void CapNhatDuLieu()
        {
            HienThiTrangThaiPhong();
            CapNhatThongTinTongQuan();
        }
        private void HienThiTrangThaiPhong()
        {
            var ds = phongBLL.LayTatCaPhong();
            foreach (var p in ds)
            {
                string tenPanel = "pn" + p.SoPhong;   

                var panel = this.Controls.Find(tenPanel, true).FirstOrDefault() as Panel;

                if (panel != null)
                {
                    if (p.TrangThai == "Đang ở")
                        panel.BackColor = Color.LightGreen;
                    else
                        panel.BackColor = SystemColors.ActiveCaption;
                }
            }
        }
        private void CapNhatThongTinTongQuan()
        {
            var ds = phongBLL.LayTatCaPhong();

            int soPhongTrong = ds.Count(p => p.TrangThai == "Trống");
            lblPhongtrong.Text = $"{soPhongTrong}";

            int tongSoNguoiO = datPhongBLL.TongSoNguoiDangO();
            lblKhachhang.Text = $"{tongSoNguoiO}";

            decimal doanhThuHomNay = hoaDonBLL.LayDoanhThuHomNay();
            lblDoanhthu.Text = $"{doanhThuHomNay:N0} VNĐ";
        }

        private void pnDatphong_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormBooking frm = new FormBooking();
            frm.FormClosed += (s, args) =>
            {
                this.Show();
                this.CapNhatDuLieu();
            };
            frm.Show();
        }

        private void pnTraphong_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormInvoice frm = new FormInvoice();
            frm.FormClosed += (s, args) =>
            {
                this.Show();
                this.CapNhatDuLieu(); 
            };
            frm.Show();
        }

        private void pnDichvu_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormSer frm = new FormSer();
            frm.FormClosed += (s, args) =>
            {
                this.Show();
                this.CapNhatDuLieu(); 
            };
            frm.Show();
        }

        private void pnQlyphong_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormRoom frm = new FormRoom();
            frm.FormClosed += (s, args) =>
            {
                this.Show();
                this.CapNhatDuLieu(); 
            };
            frm.Show();
        }

        private void pnQlykhachhang_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormCustomer frm = new FormCustomer();
            frm.FormClosed += (s, args) =>
            {
                this.Show();
            };
            frm.Show();
        }

        private void pnThongke_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormReport frm = new FormReport(); 
            frm.FormClosed += (s, args) => this.Show();
            frm.Show();
        }

        private void pnCaidat_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormUser frm = new FormUser(this.maNhanVienHienTai);
            frm.FormClosed += (s, args) => this.Show();
            frm.Show();
        }
    }
}
