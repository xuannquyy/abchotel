using abchotel.DAL;
using abchotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abchotel.BLL
{
    public class HoaDonBLL
    {
        private HoaDonDAL dal = new HoaDonDAL();

        public DataTable LayDanhSachHoaDon() => dal.LayDanhSachHoaDon();

        public int ThemHoaDon(HoaDon hd) => dal.ThemHoaDon(hd);

        public int XoaHoaDon(int maHoaDon) => dal.XoaHoaDon(maHoaDon);
    }
}
