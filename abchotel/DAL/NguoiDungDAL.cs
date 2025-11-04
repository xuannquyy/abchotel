using abchotel.Model;
using System;

using System.Collections.Generic;

using System.Data;

using System.Data.SqlClient;

using System.Linq;

using System.Text;

using System.Threading.Tasks;
using abchotel.DAL;




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

    }

}