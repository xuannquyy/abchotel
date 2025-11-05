using abchotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abchotel.DAL
{
    public class HoaDonDAL
    {
        public DataTable LayDanhSachHoaDon()
        {
            string query = "SELECT * FROM HoaDon";
            return DatabaseHelper.GetData(query);
        }

        public int ThemHoaDon(HoaDon hd)
        {
            string query = "INSERT INTO HoaDon (MaDatPhong, MaDichVu, NgayLap, ThanhTien) VALUES (@MaDatPhong, @MaDichVu, @NgayLap, @ThanhTien)";
            return DatabaseHelper.ExecuteNonQuery(query,
                ("@MaDatPhong", hd.MaDatPhong),
                ("@MaDichVu", hd.MaDichVu),
                ("@NgayLap", hd.NgayLap),
                ("@ThanhTien", hd.ThanhTien)
            );
        }

        public int XoaHoaDon(int maHoaDon)
        {
            string query = "DELETE FROM HoaDon WHERE MaHoaDon = @MaHoaDon";
            return DatabaseHelper.ExecuteNonQuery(query, ("@MaHoaDon", maHoaDon));
        }
        public decimal DoanhThuHomNay()
        {
            string query = "SELECT ISNULL(SUM(ThanhTien), 0) FROM HoaDon WHERE CAST(NgayLap AS DATE) = CAST(GETDATE() AS DATE)";
            object result = DatabaseHelper.ExecuteScalar(query);
            return Convert.ToDecimal(result);
        }

    }
}
