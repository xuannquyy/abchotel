using abchotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abchotel.DAL
{
    public class PhongDAL
    {
        public DataTable LayTatCaLoaiPhong()
        {
            string query = "SELECT DISTINCT LoaiPhong FROM Phong ORDER BY LoaiPhong";
            return DatabaseHelper.GetData(query);
        }
        public List<Phong> LayTatCaPhong()
        {
            string query = @"
                SELECT p.*, 
                       c.HoTen AS TenKhachHang,
                       b.NgayNhan AS NgayNhan,
                       b.NgayTra AS NgayTra
                FROM Phong p
                LEFT JOIN DatPhong b ON p.MaPhong = b.MaPhong AND p.TrangThai = N'Đang ở'
                LEFT JOIN KhachHang c ON b.MaKhachHang = c.MaKhachHang";

            DataTable dt = DatabaseHelper.GetData(query);
            List<Phong> list = new List<Phong>();
            // Dùng GroupBy để phòng trường hợp dữ liệu rác (1 phòng có 2 khách ở)
            var groupedRows = dt.AsEnumerable().GroupBy(row => (int)row["MaPhong"]);
            foreach (var group in groupedRows)
            {
                DataRow row = group.First(); // Luôn lấy dòng đầu tiên của nhóm
                list.Add(new Phong
                {
                    MaPhong = (int)row["MaPhong"],
                    SoPhong = row["SoPhong"].ToString(),
                    LoaiPhong = row["LoaiPhong"].ToString(),
                    TrangThai = row["TrangThai"].ToString(),
                    DonGia = (decimal)row["DonGia"],
                    TenKhachHang = row["TenKhachHang"].ToString(),
                    NgayNhan = row["NgayNhan"] == DBNull.Value ? null : (DateTime?)row["NgayNhan"],
                    NgayTra = row["NgayTra"] == DBNull.Value ? null : (DateTime?)row["NgayTra"]
                });
            }
            return list;
        }

        public void ThemPhong(Phong p)
        {
            string sql = "INSERT INTO Phong(SoPhong,LoaiPhong,TrangThai,DonGia) VALUES(@SoPhong,@LoaiPhong, N'Trống',@DonGia)";
            DatabaseHelper.ExecuteNonQuery(sql,
                ("@SoPhong", p.SoPhong),
                ("@LoaiPhong", p.LoaiPhong),
                ("@DonGia", p.DonGia));
        }

        public void SuaPhong(Phong p)
        {
            string sql = @"
                UPDATE Phong SET 
                    SoPhong=@SoPhong,
                    LoaiPhong=@LoaiPhong,
                    DonGia=@DonGia 
                WHERE MaPhong=@MaPhong";

            DatabaseHelper.ExecuteNonQuery(sql,
                ("@SoPhong", p.SoPhong),
                ("@LoaiPhong", p.LoaiPhong),
                ("@DonGia", p.DonGia),
                ("@MaPhong", p.MaPhong));
        }

        public void XoaPhong(int maPhong)
        {
            string sql = "DELETE FROM Phong WHERE MaPhong=@MaPhong";
            DatabaseHelper.ExecuteNonQuery(sql, ("@MaPhong", maPhong));
        }

        public List<Phong> TimKiemPhongTheoSo(string soPhong)
        {
            string query = @"
                SELECT p.*, 
                       c.HoTen AS TenKhachHang,
                       b.NgayNhan AS NgayNhan,
                       b.NgayTra AS NgayTra
                FROM Phong p
                LEFT JOIN DatPhong b ON p.MaPhong = b.MaPhong AND p.TrangThai = N'Đang ở'
                LEFT JOIN KhachHang c ON b.MaKhachHang = c.MaKhachHang
                WHERE p.SoPhong LIKE @SoPhong";

            DataTable dt = DatabaseHelper.GetData(query, ("@SoPhong", "%" + soPhong + "%"));
            List<Phong> list = new List<Phong>();

            var groupedRows = dt.AsEnumerable().GroupBy(row => (int)row["MaPhong"]);

            foreach (var group in groupedRows)
            {
                DataRow row = group.First();
                list.Add(new Phong
                {
                    MaPhong = (int)row["MaPhong"],
                    SoPhong = row["SoPhong"].ToString(),
                    LoaiPhong = row["LoaiPhong"].ToString(),
                    TrangThai = row["TrangThai"].ToString(),
                    DonGia = (decimal)row["DonGia"],
                    TenKhachHang = row["TenKhachHang"].ToString(),
                    NgayNhan = row["NgayNhan"] == DBNull.Value ? null : (DateTime?)row["NgayNhan"],
                    NgayTra = row["NgayTra"] == DBNull.Value ? null : (DateTime?)row["NgayTra"]
                });
            }
            return list;
        }
    }
}
