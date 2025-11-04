using abchotel.DAL;
using abchotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abchotel.DAL;
using abchotel.Model;

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
    }
}
