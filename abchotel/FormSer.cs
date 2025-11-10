using abchotel.BLL;
using abchotel.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using abchotel.Model;

namespace abchotel
{
    public partial class FormSer : Form
    {
        public class DichVuDaChon
        {
            public int MaDV { get; set; } // Sửa: từ string -> int
            public string TenDV { get; set; }
            public decimal DonGia { get; set; }
            public int SoLuong { get; set; }
            public decimal ThanhTien => DonGia * SoLuong;
        }

        private List<DichVuDaChon> dsDaChon = new List<DichVuDaChon>();
        private DichVuBLL dichVuBLL = new DichVuBLL();
        private ChiTietDichVuBLL ctdvBLL = new ChiTietDichVuBLL();
        // Biến lưu trữ thông tin khách hàng đang chọn
        private int maDatPhongHienTai = -1;
        private int maHoaDonHienTai = -1;
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

            var selectedItem = lViewDV.SelectedItems[0];

            // Sửa: Lấy MaDV là INT
            int ma = int.Parse(selectedItem.SubItems[0].Text);
            string ten = selectedItem.SubItems[1].Text;

            decimal gia = decimal.Parse(selectedItem.SubItems[2].Text.Replace(",", ""));

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

            if (maHoaDonHienTai <= 0 || maDatPhongHienTai <= 0)
            {
                MessageBox.Show("Vui lòng nhập Mã Phòng và chọn khách hàng đang ở!");
                txbMphong.Focus();
                return;
            }

            try
            {
                int soLuongThemThanhCong = 0;

                foreach (var dv in dsDaChon)
                {
                    var chiTiet = new ChiTietDichVu
                    {
                        MaHoaDon = maHoaDonHienTai,
                        MaDichVu = dv.MaDV,
                        SoLuong = dv.SoLuong,
                        DonGia = dv.DonGia
                    };

                    if (ctdvBLL.Them(chiTiet))
                    {
                        soLuongThemThanhCong++;
                    }
                }

                MessageBox.Show($"Đã đăng ký/cập nhật thành công {soLuongThemThanhCong} loại dịch vụ cho khách hàng {txbhoten.Text}!");
                btnHuy_Click(null, null); // Xóa form
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi đăng ký dịch vụ: " + ex.Message);
            }
        }

        private void lViewDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lViewDV.SelectedItems.Count == 1)
            {
                var item = lViewDV.SelectedItems[0];
                // Hiển thị đơn giá của dịch vụ ĐANG CHỌN (bên trái)
                txbdongia.Text = item.SubItems[2].Text;
            }
        }
        private void CapNhatListBox()
        {
            listBox1.Items.Clear();
            foreach (var dv in dsDaChon)
            {
                listBox1.Items.Add($"{dv.MaDV} - {dv.TenDV} - {dv.DonGia:N0}đ - x{dv.SoLuong}");
            }

            decimal tongTien = dsDaChon.Sum(d => d.ThanhTien);
            int tongSoLuong = dsDaChon.Sum(d => d.SoLuong);

            // Sửa: Hiển thị TỔNG TIỀN ở ô Đơn giá
            txbdongia.Text = tongTien.ToString("N0") + " VNĐ";
            txbsldv.Text = tongSoLuong.ToString();
        }

        

        private void FormSer_Load(object sender, EventArgs e)
        {
            LoadDanhSachDichVu();
            // Gắn sự kiện Leave cho txbMphong
            txbMphong.Leave += new EventHandler(txbMphong_Leave);
        }
        private void LoadDanhSachDichVu()
        {
            lViewDV.Items.Clear();
            var ds = dichVuBLL.LayTatCaDichVu();
            foreach (var dv in ds)
            {
                // Giả sử lViewDV có 4 cột: MaDV, TenDV, DonGia, DonViTinh
                ListViewItem item = new ListViewItem(dv.MaDichVu.ToString());
                item.SubItems.Add(dv.TenDichVu);
                item.SubItems.Add(dv.DonGia.ToString("N0"));

                // (Thêm DonViTinh nếu bạn có cột đó)
                // item.SubItems.Add(dv.DonViTinh); 

                lViewDV.Items.Add(item);
            }
        }

        // --- SỰ KIỆN TÌM KHÁCH HÀNG ---
        private void txbMphong_Leave(object sender, EventArgs e)
        {
            string soPhong = txbMphong.Text.Trim();
            if (string.IsNullOrEmpty(soPhong))
            {
                txbhoten.Clear();
                maDatPhongHienTai = -1;
                maHoaDonHienTai = -1;
                return;
            }

            // Dùng 1 câu query để tìm khách hàng đang ở phòng này
            string query = @"
                SELECT TOP 1 dp.MaDatPhong, kh.HoTen
                FROM DatPhong dp
                JOIN Phong p ON dp.MaPhong = p.MaPhong
                JOIN KhachHang kh ON dp.MaKhachHang = kh.MaKhachHang
                WHERE p.SoPhong = @SoPhong AND p.TrangThai = N'Đang ở'
                ORDER BY dp.MaDatPhong DESC"; // Lấy lượt đặt mới nhất

            DataTable dt = DatabaseHelper.GetData(query, ("@SoPhong", soPhong));

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];
                txbhoten.Text = row["HoTen"].ToString();
                maDatPhongHienTai = (int)row["MaDatPhong"];

                // Tự động lấy (hoặc tạo) Hóa Đơn cho lượt đặt phòng này
                TimMaHoaDon();
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng nào đang ở phòng này.");
                txbhoten.Clear();
                maDatPhongHienTai = -1;
                maHoaDonHienTai = -1;
            }
        }

        // Hàm gọi Stored Procedure để lấy MaHoaDon
        private void TimMaHoaDon()
        {
            if (maDatPhongHienTai <= 0) return;

            try
            {
                var dt = DatabaseHelper.GetData("sp_GetOrCreateHoaDon", CommandType.StoredProcedure, ("@MaDatPhong", maDatPhongHienTai));
                if (dt.Rows.Count > 0)
                {
                    maHoaDonHienTai = (int)dt.Rows[0]["MaHoaDon"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã hóa đơn: " + ex.Message);
                maHoaDonHienTai = -1;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txbMphong.Clear();
            txbhoten.Clear();
            txbsldv.Clear();
            txbdongia.Clear();
            txbMphong.Focus();

            // Xóa danh sách
            dsDaChon.Clear();
            listBox1.Items.Clear();

            // Reset biến
            maDatPhongHienTai = -1;
            maHoaDonHienTai = -1;
        }
    }
}
