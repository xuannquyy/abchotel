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
        public DataTable LayTatCa()
        {
            string query = "SELECT * FROM NguoiDung";
            return DatabaseHelper.GetData(query); 
        }

        public bool Them(NguoiDung nd)
        {
            string query = "INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, Email, VaiTro) " +
                           "VALUES (@TenDangNhap, @MatKhau, @HoTen, @Email, @VaiTro)";

            return DatabaseHelper.ExecuteNonQuery(
                query,
                ("@TenDangNhap", nd.TenDangNhap),
                ("@MatKhau", nd.MatKhau),
                ("@HoTen", nd.HoTen),
                ("@Email", nd.Email),
                ("@VaiTro", nd.VaiTro)
            ) > 0;
        }

        public bool Xoa(int maND)
        {
            string query = "DELETE FROM NguoiDung WHERE MaNguoiDung = @Ma";
            return DatabaseHelper.ExecuteNonQuery(query, ("@Ma", maND)) > 0;
        }

        public bool DoiMatKhau(int maND, string matKhauCu, string matKhauMoi)
        {
            string query = "UPDATE NguoiDung SET MatKhau = @Moi WHERE MaNguoiDung = @Ma AND MatKhau = @Cu";
            return DatabaseHelper.ExecuteNonQuery(
                query,
                ("@Ma", maND),
                ("@Cu", matKhauCu),
                ("@Moi", matKhauMoi)
            ) > 0;
        }
        public NguoiDung DangNhap(string username, string password)
        {
            string query = "SELECT * FROM NguoiDung WHERE TenDangNhap = @username AND MatKhau = @password";

            DataTable dt = DatabaseHelper.GetData(query, ("@username", username), ("@password", password));

            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                return new NguoiDung
                {
                    MaNguoiDung = Convert.ToInt32(r["MaNguoiDung"]),
                    TenDangNhap = r["TenDangNhap"].ToString(),
                    MatKhau = r["MatKhau"].ToString(),
                    HoTen = r["HoTen"].ToString(),
                    Email = r["Email"].ToString(),
                    VaiTro = r["VaiTro"].ToString()
                };
            }
            return null;
        }
        public NguoiDung CheckEmail(string email)
        {
            string query = "SELECT * FROM NguoiDung WHERE Email = @Email";
            DataTable dt = DatabaseHelper.GetData(query, ("@Email", email));
            if (dt.Rows.Count > 0)
            {
                DataRow r = dt.Rows[0];
                return new NguoiDung
                {
                    MaNguoiDung = Convert.ToInt32(r["MaNguoiDung"]),
                    TenDangNhap = r["TenDangNhap"].ToString(),
                    MatKhau = r["MatKhau"].ToString(),
                    HoTen = r["HoTen"].ToString(),
                    Email = r["Email"].ToString(),
                    VaiTro = r["VaiTro"].ToString()
                };
            }
            return null;
        }

        public bool DoiMatKhauTheoTen(string username, string email, string newPass)
        {
            string query = "UPDATE NguoiDung SET MatKhau = @MatKhauMoi WHERE TenDangNhap = @TenDangNhap AND Email = @Email";
            return DatabaseHelper.ExecuteNonQuery(query,
                ("@MatKhauMoi", newPass),
                ("@TenDangNhap", username),
                ("@Email", email)
            ) > 0;
        }
    }
}
