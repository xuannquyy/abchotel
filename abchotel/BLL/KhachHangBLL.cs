using abchotel.DAL;
using abchotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abchotel.BLL
{
    public class KhachHangBLL
    {
        private KhachHangDAL dal = new KhachHangDAL();

        public List<KhachHang> LayTatCaKhachHang() => dal.LayTatCaKhachHang();
        public int ThemKhachHang(KhachHang kh) => dal.ThemKhachHang(kh);
        public void SuaKhachHang(KhachHang kh) => dal.SuaKhachHang(kh);
        public void XoaKhachHang(int ma) => dal.XoaKhachHang(ma);
        public List<KhachHang> TimKiemKhachHang(string keyword) => dal.TimKiemKhachHang(keyword);
    }

}
