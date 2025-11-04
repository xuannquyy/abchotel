using abchotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abchotel.DAL
{
    public class NguoiDungDAL
    {
        private readonly DatabaseHelper db = new DatabaseHelper();

        public DataTable LayTatCa()
        {
            string query = "SELECT * FROM NguoiDung";
            return db.ExecuteQuery(query);
        }

        public bool Them(NguoiDung nd)
        {
            string query = "INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, Email, VaiTro) VALUES (@TenDangNhap, @MatKhau, @HoTen, @Email, @VaiTro)";
            SqlParameter[] p =
            {
                new SqlParameter("@TenDangNhap", nd.TenDangNhap),
                new SqlParameter("@MatKhau", nd.MatKhau),
                new SqlParameter("@HoTen", nd.HoTen),
                new SqlParameter("@Email", nd.Email),
                new SqlParameter("@VaiTro", nd.VaiTro)
            };
            return db.ExecuteNonQuery(query, p) > 0;
        }

        public bool Xoa(int maND)
        {
            string query = "DELETE FROM NguoiDung WHERE MaNguoiDung = @Ma";
            SqlParameter[] p = { new SqlParameter("@Ma", maND) };
            return db.ExecuteNonQuery(query, p) > 0;
        }

        public bool DoiMatKhau(int maND, string matKhauCu, string matKhauMoi)
        {
            string query = "UPDATE NguoiDung SET MatKhau = @Moi WHERE MaNguoiDung = @Ma AND MatKhau = @Cu";
            SqlParameter[] p =
            {
                new SqlParameter("@Ma", maND),
                new SqlParameter("@Cu", matKhauCu),
                new SqlParameter("@Moi", matKhauMoi)
            };
            return db.ExecuteNonQuery(query, p) > 0;
        }
    }
}
