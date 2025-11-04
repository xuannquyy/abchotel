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
    public partial class FormBooking : Form
    {
        public class Phong
        {
            public string MaPhong { get; set; }
            public string SoPhong { get; set; }
            public string LoaiPhong { get; set; }
            public decimal GiaPhong { get; set; }
            
            public bool Trong { get; set; } = true;
        }

        // Danh sách phòng toàn khách sạn
        private List<Phong> danhSachPhong = new List<Phong>();
        public FormBooking()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                danhSachPhong.Add(new Phong { MaPhong = $"P{i:000}", SoPhong = $"10{i}", LoaiPhong = "Phòng đơn", GiaPhong = 300000 });
            }
            for (int i = 11; i <= 20; i++)
            {
                danhSachPhong.Add(new Phong { MaPhong = $"P{i:000}", SoPhong = $"20{i}", LoaiPhong = "Phòng đôi", GiaPhong = 500000 });
            }
            for (int i = 21; i <= 30; i++)
            {
                danhSachPhong.Add(new Phong { MaPhong = $"P{i:000}", SoPhong = $"30{i}", LoaiPhong = "Phòng VIP", GiaPhong = 800000 });
            }

            Cbloaiphong.Items.AddRange(new string[] { "Phòng đơn", "Phòng đôi", "Phòng VIP" });
            cbgioitinh.Items.AddRange(new string[] { "Nam", "Nữ", "Khác" });
            txbsodem.TextChanged += txbsodem_TextChanged;
        }

        private void Cbloaiphong_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbphongtrong.Items.Clear();

            var dsPhongTrong = danhSachPhong
                .Where(p => p.LoaiPhong == Cbloaiphong.Text && p.Trong)
                .ToList();

            foreach (var p in dsPhongTrong)
                cbphongtrong.Items.Add(p.SoPhong);

            if (dsPhongTrong.Count > 0)
            {
                txbgia.Text = dsPhongTrong[0].GiaPhong.ToString("#,0") + " VNĐ";
                
            }

            TinhTamTinh();
        }
        private void TinhTamTinh()
        {
            if (Cbloaiphong.SelectedItem == null) return;

            DateTime nhan = datenhan.Value.Date;
            DateTime tra = datetra.Value.Date;
            int soDem = (tra - nhan).Days;
            if (soDem <= 0) soDem = 1;

            var phong = danhSachPhong.FirstOrDefault(p => p.LoaiPhong == Cbloaiphong.Text);
            if (phong != null)
            {
                decimal tong = phong.GiaPhong * soDem;
                lbVMD.Text = tong.ToString("#,0") + " VNĐ";
                txbsodem.Text = soDem.ToString();
            }
        }

        private void butdatphong_Click(object sender, EventArgs e)
        {
            if (cbphongtrong.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn phòng trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txbhoten.Text) || string.IsNullOrWhiteSpace(txbCMND.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ họ tên và CMND!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string soPhong = cbphongtrong.Text;
            var phong = danhSachPhong.FirstOrDefault(p => p.SoPhong == soPhong);
            if (phong == null) return;

            // Đánh dấu đã thuê
            phong.Trong = false;

            int soDem = int.Parse(txbsodem.Text);
            decimal thanhTien = phong.GiaPhong * soDem;

            // Thêm vào ListView
            ListViewItem item = new ListViewItem(phong.MaPhong);
            item.SubItems.Add(phong.SoPhong);
            item.SubItems.Add(txbhoten.Text);
            item.SubItems.Add(txbCMND.Text);
            item.SubItems.Add(phong.LoaiPhong);
            item.SubItems.Add(datenhan.Value.ToShortDateString());
            item.SubItems.Add(datetra.Value.ToShortDateString());
            item.SubItems.Add(thanhTien.ToString("#,0") + " VNĐ");
            listView1.Items.Add(item);

            MessageBox.Show("Đặt phòng thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LamMoi();
        }

        //private void butnhanphong_Click(object sender, EventArgs e)
        //{
        //    if (listView1.SelectedItems.Count == 0)
        //    {
        //        MessageBox.Show("Vui lòng chọn một phòng trong danh sách để nhận!", "Thông báo");
        //        return;
        //    }

        //    string maPhong = listView1.SelectedItems[0].SubItems[0].Text;
        //    MessageBox.Show($"Phòng {maPhong} đã được nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //}

        private void butlmmoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }
        private void LamMoi()
        {
            Cbloaiphong.SelectedIndex = -1;
            cbphongtrong.Items.Clear();
            txbgia.Clear();
            txbsoluong.Clear();
            txbhoten.Clear();
            txbCMND.Clear();
            txbsodem.Clear();
            lbVMD.Text = "0 VNĐ";
            datenhan.Value = DateTime.Now;
            datetra.Value = DateTime.Now.AddDays(1);
            txbsdt.Clear();
            txbdiachi.Clear();
            txbMphong.Clear();
            cbgioitinh.Items.Clear();
            txbsophong.Clear();

        }

        private void txbsodem_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txbsodem.Text, out int soDem))
            {
                if (soDem > 0)
                {
                    // Cập nhật ngày trả = ngày nhận + số đêm
                    datetra.Value = datenhan.Value.AddDays(soDem);
                    TinhTamTinh(); // gọi lại hàm tính tiền tạm tính
                }
            }
        }

        private void datenhan_ValueChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txbsodem.Text, out int soDem) && soDem > 0)
                datetra.Value = datenhan.Value.AddDays(soDem);

            TinhTamTinh();
        }
        private void txbsdt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbsodem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txbhoten_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }
    }
}
