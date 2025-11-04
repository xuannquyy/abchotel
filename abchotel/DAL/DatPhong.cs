using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abchotel.Model;

namespace abchotel.DAL
{
    public class DatPhongDAL
    {
        private readonly DatabaseHelper db = new DatabaseHelper();

        public DataTable LayPhongTrongTheoLoai(string loaiPhong)
        {
            string query = "SELECT * FROM Phong WHERE LoaiPhong = @LoaiPhong AND TrangThai = N'Trống'";
            SqlParameter[] p = { new SqlParameter("@LoaiPhong", loaiPhong) };
            return db.ExecuteNonQuery(query, p);
        }

        public bool ThemDatPhong(DatPhong dp)
        {
            string query = @"INSERT INTO DatPhong (MaPhong, MaKhachHang, NgayNhan, NgayTra, SoNguoiO, TongTien)
                             VALUES (@MaPhong, @MaKhachHang, @NgayNhan, @NgayTra, @SoNguoiO, @TongTien);
                             UPDATE Phong SET TrangThai = N'Đang ở' WHERE MaPhong = @MaPhong";
            SqlParameter[] p =
            {
                new SqlParameter("@MaPhong", dp.MaPhong),
                new SqlParameter("@MaKhachHang", dp.MaKhachHang),
                new SqlParameter("@NgayNhan", dp.NgayNhan),
                new SqlParameter("@NgayTra", dp.NgayTra),
                new SqlParameter("@SoNguoiO", dp.SoNguoiO),
                new SqlParameter("@TongTien", dp.TongTien)
            };
            return db.ExecuteNonQuery(query, p) > 0;
        }
    }
}