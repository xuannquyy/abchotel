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
            return DatabaseHelper.GetData(query, ("@LoaiPhong", loaiPhong));
        }

        public bool ThemDatPhong(DatPhong dp)
        {
            string query = @"INSERT INTO DatPhong (MaPhong, MaKhachHang, NgayNhan, NgayTra, SoNguoiO, TongTien)
                             VALUES (@MaPhong, @MaKhachHang, @NgayNhan, @NgayTra, @SoNguoiO, @TongTien);
                             UPDATE Phong SET TrangThai = N'Đang ở' WHERE MaPhong = @MaPhong";
            return DatabaseHelper.ExecuteNonQuery(query,
                ("@MaPhong", dp.MaPhong),
                ("@MaKhachHang", dp.MaKhachHang),
                ("@NgayNhan", dp.NgayNhan),
                ("@NgayTra", dp.NgayTra),
                ("@SoNguoiO", dp.SoNguoiO),
                ("@TongTien", dp.TongTien)
            ) > 0;
        }
    }
}