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
                    NgaySinh = row["NgaySinh"] == DBNull.Value ? DateTime.MinValue : (DateTime)row["NgaySinh"],
                    CCCD = row["CCCD"].ToString(),
                    SoDienThoai = row["SoDienThoai"].ToString(),
                    DiaChi = row["DiaChi"].ToString()
                });
            }

            return list;
        }

        public int ThemKhachHang(KhachHang kh)
        {
            string query = @"
                INSERT INTO KhachHang (HoTen, GioiTinh, NgaySinh, CCCD, SoDienThoai, DiaChi)
                VALUES (@HoTen, @GioiTinh, @NgaySinh, @CCCD, @SoDienThoai, @DiaChi)";
            return DatabaseHelper.ExecuteQuery(query,
                ("@HoTen", kh.HoTen),
                ("@GioiTinh", kh.GioiTinh),
                ("@NgaySinh", kh.NgaySinh),
                ("@CCCD", kh.CCCD),
                ("@SoDienThoai", kh.SoDienThoai),
                ("@DiaChi", kh.DiaChi));
        }

        public int SuaKhachHang(KhachHang kh)
        {
            string query = @"
                UPDATE KhachHang SET
                    HoTen = @HoTen,
                    GioiTinh = @GioiTinh,
                    NgaySinh = @NgaySinh,
                    CCCD = @CCCD,
                    SoDienThoai = @SoDienThoai,
                    DiaChi = @DiaChi
                WHERE MaKhachHang = @MaKhachHang";
            return DatabaseHelper.ExecuteQuery(query,
                ("@HoTen", kh.HoTen),
                ("@GioiTinh", kh.GioiTinh),
                ("@NgaySinh", kh.NgaySinh),
                ("@CCCD", kh.CCCD),
                ("@SoDienThoai", kh.SoDienThoai),
                ("@DiaChi", kh.DiaChi),
                ("@MaKhachHang", kh.MaKhachHang));
        }

        public int XoaKhachHang(int ma)
        {
            string query = "DELETE FROM KhachHang WHERE MaKhachHang = @Ma";
            return DatabaseHelper.ExecuteQuery(query, ("@Ma", ma));
        }
    }
}
