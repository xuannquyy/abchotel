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
        public List<Phong> LayTatCaPhong()
        {
            string query = @"
                SELECT p.*, 
                       c.HoTen AS TenKhachHang,
                       b.CheckIn AS NgayNhan,
                       b.CheckOut AS NgayTra
                FROM Phong p
                LEFT JOIN DatPhong b ON p.MaPhong = b.MaPhong
                LEFT JOIN KhachHang c ON b.MaKhachHang = c.MaKhachHang";

            DataTable dt = DatabaseHelper.GetData(query);
            List<Phong> list = new List<Phong>();
            foreach (DataRow row in dt.Rows)
            {
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
            string sql = "INSERT INTO Phong(SoPhong,LoaiPhong,TrangThai,DonGia) VALUES(@SoPhong,@LoaiPhong,@TrangThai,@DonGia)";
            DatabaseHelper.ExecuteNonQuery(sql,
                ("@SoPhong", p.SoPhong),
                ("@LoaiPhong", p.LoaiPhong),
                ("@TrangThai", p.TrangThai),
                ("@DonGia", p.DonGia));
        }

        public void SuaPhong(Phong p)
        {
            string sql = "UPDATE Phong SET SoPhong=@SoPhong,LoaiPhong=@LoaiPhong,TrangThai=@TrangThai,DonGia=@DonGia WHERE MaPhong=@MaPhong";
            DatabaseHelper.ExecuteNonQuery(sql,
                ("@SoPhong", p.SoPhong),
                ("@LoaiPhong", p.LoaiPhong),
                ("@TrangThai", p.TrangThai),
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
            string query = "SELECT * FROM Phong WHERE SoPhong LIKE @SoPhong";
            DataTable dt = DatabaseHelper.GetData(query, ("@SoPhong", "%" + soPhong + "%"));
            List<Phong> list = new List<Phong>();
            foreach (DataRow row in dt.Rows)
            {
                list.Add(new Phong
                {
                    MaPhong = (int)row["MaPhong"],
                    SoPhong = row["SoPhong"].ToString(),
                    LoaiPhong = row["LoaiPhong"].ToString(),
                    TrangThai = row["TrangThai"].ToString(),
                    DonGia = (decimal)row["DonGia"]
                });
            }
            return list;
        }
    }
}
