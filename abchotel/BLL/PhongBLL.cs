using abchotel.DAL;
using abchotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abchotel.BLL
{
    public class PhongBLL
    {
        private PhongDAL phongDAL = new PhongDAL();

        public List<Phong> LayTatCaPhong() => phongDAL.LayTatCaPhong();
        public void ThemPhong(Phong p) => phongDAL.ThemPhong(p);
        public void SuaPhong(Phong p) => phongDAL.SuaPhong(p);
        public void XoaPhong(int maPhong) => phongDAL.XoaPhong(maPhong);
        public List<Phong> TimKiemPhongTheoSo(string soPhong) => phongDAL.TimKiemPhongTheoSo(soPhong);
    }
}
