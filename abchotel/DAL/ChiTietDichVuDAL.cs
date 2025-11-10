using abchotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abchotel.DAL
{
    public class ChiTietDichVuDAL
    {
        public bool Them(ChiTietDichVu ctdv)
        {
            string query = @"
                IF EXISTS (SELECT 1 FROM ChiTietDichVu WHERE MaHoaDon = @MaHD AND MaDichVu = @MaDV)
                    UPDATE ChiTietDichVu 
                    SET SoLuong = SoLuong + @SL 
                    WHERE MaHoaDon = @MaHD AND MaDichVu = @MaDV
                ELSE
                    INSERT INTO ChiTietDichVu (MaHoaDon, MaDichVu, SoLuong, DonGia) 
                    VALUES (@MaHD, @MaDV, @SL, @DonGia)";

            return DatabaseHelper.ExecuteNonQuery(query,
                ("@MaHD", ctdv.MaHoaDon),
                ("@MaDV", ctdv.MaDichVu),
                ("@SL", ctdv.SoLuong),
                ("@DonGia", ctdv.DonGia)
            ) > 0;
        }
    }
}
