using abchotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abchotel.DAL
{
    public class KhachHangDAL
    {
        public List<KhachHang> LayTatCaKhachHang()
        {
            string query = "SELECT * FROM KhachHang";
            DataTable dt = DatabaseHelper.GetData(query);
            List<KhachHang> list = new List<KhachHang>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new KhachHang
                {
                    MaKhachHang = (int)row["MaKhachHang"],
                    HoTen = row["HoTen"].ToString(),
                    GioiTinh = row["GioiTinh"].ToString(),
                    NgaySinh = (DateTime)row["NgaySinh"],
                    CCCD = row["CCCD"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),
                    DiaChi = row["DiaChi"].ToString()
                });
            }
            return list;
        }
    }

}
