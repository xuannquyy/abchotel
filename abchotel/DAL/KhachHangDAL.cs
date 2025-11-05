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
        // Hàm này được dùng để tạo đối tượng KhachHang từ DataRow
        // Giúp tránh lặp code ở LayTatCa và TimKiem
        private KhachHang MapDataRowToKhachHang(DataRow row)
        {
            return new KhachHang
            {
                MaKhachHang = (int)row["MaKhachHang"],
                HoTen = row["HoTen"].ToString(),
                GioiTinh = row["GioiTinh"].ToString(),
                NgaySinh = row["NgaySinh"] == DBNull.Value ? DateTime.MinValue : (DateTime)row["NgaySinh"],
                CCCD = row["CCCD"].ToString(),
                SoDienThoai = row["SoDienThoai"].ToString(),
                DiaChi = row["DiaChi"].ToString(),
                // Gán số phòng (nếu có)
                SoPhongHienTai = row["SoPhongHienTai"] == DBNull.Value ? null : row["SoPhongHienTai"].ToString()
            };
        }

        public List<KhachHang> LayTatCaKhachHang()
        {
            // Sửa lại query để nó lấy luôn SoPhongHienTai (nếu có)
            // Logic: Lấy TOP 1 phòng mà khách đó đang ở (TrangThai = 'Đang ở')
            string query = @"
                SELECT kh.*, (
                    SELECT TOP 1 p.SoPhong 
                    FROM DatPhong dp 
                    JOIN Phong p ON dp.MaPhong = p.MaPhong AND p.TrangThai = N'Đang ở'
                    WHERE dp.MaKhachHang = kh.MaKhachHang
                ) AS SoPhongHienTai
                FROM KhachHang kh";

            DataTable dt = DatabaseHelper.GetData(query);
            List<KhachHang> list = new List<KhachHang>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToKhachHang(row));
            }

            return list;
        }

        // THÊM HÀM TÌM KIẾM MỚI
        public List<KhachHang> TimKiemKhachHang(string keyword)
        {
            // Câu query này sẽ tìm kiếm theo Tên, CCCD, SĐT 
            // VÀ tìm xem khách có ở phòng nào khớp keyword không (dùng EXISTS)
            string query = @"
                DECLARE @kw NVARCHAR(100) = '%' + @keyword + '%';
                
                SELECT kh.*, (
                    SELECT TOP 1 p.SoPhong 
                    FROM DatPhong dp 
                    JOIN Phong p ON dp.MaPhong = p.MaPhong AND p.TrangThai = N'Đang ở'
                    WHERE dp.MaKhachHang = kh.MaKhachHang
                ) AS SoPhongHienTai
                FROM KhachHang kh
                WHERE 
                    kh.HoTen LIKE @kw OR
                    kh.CCCD LIKE @kw OR
                    kh.SoDienThoai LIKE @kw OR
                    EXISTS (
                        SELECT 1
                        FROM DatPhong dp 
                        JOIN Phong p ON dp.MaPhong = p.MaPhong AND p.TrangThai = N'Đang ở'
                        WHERE dp.MaKhachHang = kh.MaKhachHang AND p.SoPhong LIKE @kw
                    )";

            DataTable dt = DatabaseHelper.GetData(query, ("@keyword", keyword));
            List<KhachHang> list = new List<KhachHang>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToKhachHang(row));
            }
            return list;
        }

        public int ThemKhachHang(KhachHang kh)
        {
            string query = @"
                INSERT INTO KhachHang (HoTen, GioiTinh, NgaySinh, CCCD, SoDienThoai, DiaChi)
                VALUES (@HoTen, @GioiTinh, @NgaySinh, @CCCD, @SoDienThoai, @DiaChi)";
            return DatabaseHelper.ExecuteNonQuery(query,
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
            return DatabaseHelper.ExecuteNonQuery(query,
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
            return DatabaseHelper.ExecuteNonQuery(query, ("@Ma", ma));
        }
    }
}
