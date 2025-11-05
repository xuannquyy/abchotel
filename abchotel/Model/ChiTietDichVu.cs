using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abchotel.Model
{
    public class ChiTietDichVu
    {
        public int MaChiTiet { get; set; }
        public int MaHoaDon { get; set; }
        public int MaDichVu { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }

        // Thuộc tính thêm để hiển thị
        public string TenDichVu { get; set; }
    }
}
