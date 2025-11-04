using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abchotel.Model
{
    public class HoaDon
    {
        public int MaHoaDon { get; set; }
        public int MaDatPhong { get; set; }
        public DateTime NgayLap { get; set; }
        public decimal TongTienPhong { get; set; }
        public decimal TongTienDichVu { get; set; }
        public int GiamGiaPhanTram { get; set; }
        public decimal TongThanhToan { get; set; }
        public string TrangThai { get; set; }

        // Các thuộc tính thêm để hiển thị, không có trong CSDL
        public string TenKhachHang { get; set; }
        public string SoPhong { get; set; }
        public DateTime NgayNhan { get; set; }
        public DateTime NgayTra { get; set; }
    }
}
