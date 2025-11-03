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
    public partial class FormSer : Form
    {
        public class DichVuDaChon
        {
            public string MaDV { get; set; }
            public string TenDV { get; set; }
            public decimal DonGia { get; set; }
            public int SoLuong { get; set; }
            public decimal ThanhTien => DonGia * SoLuong;
        }

        private List<DichVuDaChon> dsDaChon = new List<DichVuDaChon>();
        public FormSer()
        {
            InitializeComponent();
        }

        private void butthemDV_Click(object sender, EventArgs e)
        {
            if (lViewDV.SelectedItems.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ ở danh sách bên trái!");
                return;
            }

            var selectedItems = lViewDV.SelectedItems.Cast<ListViewItem>().ToList();

            foreach (var item in selectedItems)
            {
                string ma = item.SubItems[0].Text;
                string ten = item.SubItems[1].Text;


                string giaText = item.SubItems[2].Text.Replace(".", "").Replace(",", "");
                decimal gia = decimal.Parse(giaText);

                var dv = dsDaChon.FirstOrDefault(x => x.MaDV == ma);
                if (dv == null)
                {
                    dsDaChon.Add(new DichVuDaChon
                    {
                        MaDV = ma,
                        TenDV = ten,
                        DonGia = gia,
                        SoLuong = 1
                    });
                }
                else
                {
                    dv.SoLuong++;
                }
            }

            CapNhatListBox();
        }

        private void butxoa_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                dsDaChon.RemoveAt(listBox1.SelectedIndex);
                CapNhatListBox();
            }
        }

        private void butdangky_Click(object sender, EventArgs e)
        {
            if (dsDaChon.Count == 0)
            {
                MessageBox.Show("Chưa có dịch vụ nào được chọn!");
                return;
            }


            if (string.IsNullOrWhiteSpace(txbMphong.Text) || string.IsNullOrWhiteSpace(txbhoten.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ Mã phòng và Họ tên!");
                return;
            }

            decimal tong = dsDaChon.Sum(d => d.ThanhTien);
            string chiTiet = string.Join("\n", dsDaChon.Select(d => $"{d.TenDV} x{d.SoLuong} = {d.ThanhTien:#,0}đ"));

            MessageBox.Show(

                $"Mã Phòng: {txbMphong.Text}\n\n" +
                $"Khách hàng: {txbhoten.Text}\n\n" +
                $"{chiTiet}\n\nTổng cộng: {tong:#,0}VNĐ",
                "Đăng ký thành công!"
            );
        }

        private void lViewDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lViewDV.SelectedItems.Count == 1)
            {
                var item = lViewDV.SelectedItems[0];
                txbdongia.Text = item.SubItems[2].Text;
            }
        }
        private void CapNhatListBox()
        {
            listBox1.Items.Clear();
            foreach (var dv in dsDaChon)
            {
                listBox1.Items.Add($"{dv.MaDV} - {dv.TenDV} - {dv.DonGia:#,0}đ - x{dv.SoLuong}");
            }

            decimal tongTien = dsDaChon.Sum(d => d.ThanhTien);
            int tongSoLuong = dsDaChon.Sum(d => d.SoLuong);


            txbdongia.Text = tongTien.ToString("#,0") + " VNĐ";
            txbsldv.Text = tongSoLuong.ToString();
        }

        private void Làmlammoi_Click(object sender, EventArgs e)
        {
            txbMphong.Clear();
            txbhoten.Clear();
            txbsldv.Clear();
            txbdongia.Clear();
            txbMphong.Focus();
            listBox1.Items.Clear();
        }
    }
}
