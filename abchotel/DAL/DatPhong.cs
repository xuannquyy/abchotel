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
            string query = @"
                INSERT INTO DatPhong (MaPhong, MaKhachHang, NgayNhan, NgayTra, SoNguoiO, TongTien)
                VALUES (@MaPhong, @MaKhachHang, @NgayNhan, @NgayTra, @SoNguoiO, @TongTien);
                
                UPDATE Phong SET TrangThai = N'Đang ở' WHERE MaPhong = @MaPhong";

            return DatabaseHelper.ExecuteNonQuery(query,
                ("@MaPhong", dp.MaPhong),
                ("@MaKhachHang", dp.MaKhachHang),
                ("@NgayNhan", dp.NgayNhan),
                ("@NgayTra", dp.NgayTra),
                ("@SoNguoiO", dp.SoNguoiO),
                ("@TongTien", dp.TongTien)
            ) > 1;
        }
        
        public DataTable LayDanhSachDatPhongHomNay()
        {
            // Lấy các phòng có NgayNhan là hôm nay
            string query = @"
                SELECT 
                    kh.HoTen, 
                    p.SoPhong, 
                    dp.NgayNhan, 
                    dp.NgayTra, 
                    dp.SoNguoiO, 
                    dp.TongTien,
                    kh.CCCD,
                    kh.SoDienThoai
                FROM DatPhong dp
                JOIN KhachHang kh ON dp.MaKhachHang = kh.MaKhachHang
                JOIN Phong p ON dp.MaPhong = p.MaPhong
                WHERE CAST(dp.NgayNhan AS DATE) = CAST(GETDATE() AS DATE)
                ORDER BY dp.MaDatPhong DESC"; // Hiển thị đặt phòng mới nhất lên đầu

            return DatabaseHelper.GetData(query);
        }
        public int TongSoNguoiDangO()
        {
            string query = @"
                SELECT ISNULL(SUM(SoNguoiO), 0) 
                FROM DatPhong 
                WHERE 
                    CAST(GETDATE() AS DATE) >= CAST(NgayNhan AS DATE) 
                    AND CAST(GETDATE() AS DATE) < CAST(NgayTra AS DATE)";

            object result = DatabaseHelper.ExecuteScalar(query);
            return Convert.ToInt32(result);
        }
    }
}