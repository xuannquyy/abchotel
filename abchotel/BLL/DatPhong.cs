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
    public class DatPhongBLL
    {
        private readonly DatPhongDAL dal = new DatPhongDAL();

        public DataTable LayPhongTrongTheoLoai(string loaiPhong)
        {
            return dal.LayPhongTrongTheoLoai(loaiPhong);
        }

        public bool ThemDatPhong(DatPhong dp)
        {
            return dal.ThemDatPhong(dp);
        }
        public DataTable LayDanhSachDatPhongHomNay()
        {
            return dal.LayDanhSachDatPhongHomNay();
        }
        public int TongSoNguoiDangO()
        {
            return dal.TongSoNguoiDangO();
        }
    }
}
