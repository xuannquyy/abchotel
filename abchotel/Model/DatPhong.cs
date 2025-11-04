using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abchotel.Model
{
    public class DatPhong
    {
        public int MaDatPhong { get; set; }
        public int MaPhong { get; set; }
        public int MaKhachHang { get; set; }
        public DateTime NgayNhan { get; set; }
        public DateTime NgayTra { get; set; }
        public int SoNguoiO { get; set; }
        public decimal TongTien { get; set; }
    }
}
