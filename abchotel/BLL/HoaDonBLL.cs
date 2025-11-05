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

        public DataTable LayDanhSachDatPhongChuaThanhToan() => dal.LayDanhSachDatPhongChuaThanhToan();
        public HoaDon LayThongTinHoaDon(int maDatPhong) => dal.LayThongTinHoaDon(maDatPhong);
        public DataTable LayChiTietTienPhong(int maDatPhong) => dal.LayChiTietTienPhong(maDatPhong);
        public DataTable LayChiTietDichVu(int maHoaDon) => dal.LayChiTietDichVu(maHoaDon);
        public void LuuThanhToan(int maHoaDon, int giamGiaPhanTram, decimal tongThanhToan)
        {
            dal.LuuThanhToan(maHoaDon, giamGiaPhanTram, tongThanhToan);
        }

        public decimal LayDoanhThuHomNay()
        {
            return dal.LayDoanhThuHomNay();
        }
    }
}
