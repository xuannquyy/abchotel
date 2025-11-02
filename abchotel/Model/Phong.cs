using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abchotel.Model
{
    public class Phong
    {
        public int MaPhong { get; set; }
        public string SoPhong { get; set; }
        public string LoaiPhong { get; set; }
        public string TrangThai { get; set; }
        public decimal DonGia { get; set; }
        public string TenKhachHang { get; set; } // để hiển thị người đang ở nếu có
        public DateTime? NgayNhan { get; set; }
        public DateTime? NgayTra { get; set; }
    }
}
