using abchotel.DAL;
using abchotel.Model;
using System;
using System.Data;

public class HoaDonDAL
{
    // Lấy danh sách các phòng ĐANG Ở (chưa thanh toán) để đưa vào ComboBox
    public DataTable LayDanhSachDatPhongChuaThanhToan()
    {
        string query = @"
                SELECT dp.MaDatPhong, p.SoPhong + N' - ' + kh.HoTen AS HienThi
                FROM DatPhong dp
                JOIN Phong p ON dp.MaPhong = p.MaPhong
                JOIN KhachHang kh ON dp.MaKhachHang = kh.MaKhachHang
                WHERE p.TrangThai = N'Đang ở' 
                AND NOT EXISTS (
                    SELECT 1 FROM HoaDon hd 
                    WHERE hd.MaDatPhong = dp.MaDatPhong AND hd.TrangThai = N'Đã thanh toán'
                )";
        return DatabaseHelper.GetData(query);
    }

    // Lấy thông tin chi tiết Hóa đơn (bao gồm cả Tiền phòng)
    public HoaDon LayThongTinHoaDon(int maDatPhong)
    {
        string query = "sp_GetOrCreateHoaDon"; // Sẽ dùng Stored Procedure

        // SỬA 2: Gọi hàm GetData với đúng CommandType
        // Giờ đây nó sẽ chọn đúng hàm 3 tham số
        var dt = DatabaseHelper.GetData(query, CommandType.StoredProcedure, ("@MaDatPhong", maDatPhong));

        if (dt.Rows.Count > 0)
        {
            DataRow row = dt.Rows[0];
            return new HoaDon
            {
                MaHoaDon = (int)row["MaHoaDon"],
                MaDatPhong = (int)row["MaDatPhong"],
                NgayLap = (DateTime)row["NgayLap"],
                TongTienPhong = (decimal)row["TongTienPhong"],
                TongTienDichVu = (decimal)row["TongTienDichVu"],
                GiamGiaPhanTram = (int)row["GiamGiaPhanTram"],
                TongThanhToan = (decimal)row["TongThanhToan"],
                TrangThai = row["TrangThai"].ToString(),
                TenKhachHang = row["HoTen"].ToString(),
                SoPhong = row["SoPhong"].ToString(),
                NgayNhan = (DateTime)row["NgayNhan"],
                NgayTra = (DateTime)row["NgayTra"]
            };
        }
        return null;
    }

    // Lấy chi tiết tiền phòng (để cho vào DGV 1)
    public DataTable LayChiTietTienPhong(int maDatPhong)
    {
        string query = @"
                SELECT 
                    p.LoaiPhong AS N'Loại phòng', 
                    DATEDIFF(day, dp.NgayNhan, dp.NgayTra) AS N'Số đêm',
                    p.DonGia AS N'Đơn giá',
                    (DATEDIFF(day, dp.NgayNhan, dp.NgayTra) * p.DonGia) AS N'Tổng'
                FROM DatPhong dp
                JOIN Phong p ON dp.MaPhong = p.MaPhong
                WHERE dp.MaDatPhong = @MaDatPhong";
        return DatabaseHelper.GetData(query, ("@MaDatPhong", maDatPhong));
    }

    // Lấy danh sách dịch vụ đã dùng (để cho vào DGV 2)
    public DataTable LayChiTietDichVu(int maHoaDon)
    {
        string query = @"
                SELECT 
                    dv.MaDichVu AS N'Mã DV',
                    dv.TenDichVu AS N'Tên dịch vụ',
                    ct.SoLuong AS N'Số lượng',
                    ct.DonGia AS N'Đơn giá',
                    ct.ThanhTien AS N'Tổng'
                FROM ChiTietDichVu ct
                JOIN DichVu dv ON ct.MaDichVu = dv.MaDichVu
                WHERE ct.MaHoaDon = @MaHoaDon";
        return DatabaseHelper.GetData(query, ("@MaHoaDon", maHoaDon));
    }

    // Lưu thanh toán cuối cùng
    public int LuuThanhToan(int maHoaDon, int giamGiaPhanTram, decimal tongThanhToan)
    {
        string query = @"
                UPDATE HoaDon 
                SET 
                    GiamGiaPhanTram = @GiamGia,
                    TongThanhToan = @TongThanhToan,
                    TrangThai = N'Đã thanh toán'
                WHERE MaHoaDon = @MaHoaDon;
                
                -- Cập nhật trạng thái phòng về 'Trống'
                UPDATE p
                SET p.TrangThai = N'Trống'
                FROM Phong p
                JOIN DatPhong dp ON p.MaPhong = dp.MaPhong
                JOIN HoaDon hd ON dp.MaDatPhong = hd.MaDatPhong
                WHERE hd.MaHoaDon = @MaHoaDon;
            ";

        return DatabaseHelper.ExecuteNonQuery(query,
            ("@GiamGia", giamGiaPhanTram),
            ("@TongThanhToan", tongThanhToan),
            ("@MaHoaDon", maHoaDon)
        );
    }
}