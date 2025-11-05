using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abchotel.DAL
{
    public class ReportDAL
    {
        public DataTable LayDuLieuBaoCao(string reportType, DateTime fromDate, DateTime toDate)
        {
            // Xây dựng câu truy vấn SQL động
            StringBuilder query = new StringBuilder();
            string selectColumn = "";
            string groupByColumn = "";
            string orderByColumn = "";

            switch (reportType)
            {
                case "Theo ngày":
                    selectColumn = " CONVERT(varchar, NgayLap, 103) AS ThoiGian "; // Định dạng dd/MM/yyyy
                    groupByColumn = " CONVERT(varchar, NgayLap, 103), CAST(NgayLap AS DATE) ";
                    orderByColumn = " CAST(NgayLap AS DATE) ";
                    break;
                case "Theo tháng":
                    selectColumn = " FORMAT(NgayLap, 'MM/yyyy') AS ThoiGian ";
                    groupByColumn = " FORMAT(NgayLap, 'MM/yyyy'), YEAR(NgayLap), MONTH(NgayLap) ";
                    orderByColumn = " YEAR(NgayLap), MONTH(NgayLap) ";
                    break;
                case "Theo năm":
                    selectColumn = " CAST(YEAR(NgayLap) AS varchar) AS ThoiGian ";
                    groupByColumn = " YEAR(NgayLap) ";
                    orderByColumn = " YEAR(NgayLap) ";
                    break;
                default:
                    throw new ArgumentException("Loại báo cáo không hợp lệ.");
            }

            query.Append($" SELECT {selectColumn}, ");
            query.Append("        SUM(TongThanhToan) AS DoanhThu, ");
            query.Append("        COUNT(MaHoaDon) AS SoHoaDon ");
            query.Append(" FROM HoaDon ");
            query.Append(" WHERE TrangThai = N'Đã thanh toán' ");
            query.Append("   AND NgayLap BETWEEN @FromDate AND @ToDate ");
            query.Append($" GROUP BY {groupByColumn} ");
            query.Append($" ORDER BY {orderByColumn} ASC ");

            // Gọi DatabaseHelper để thực thi
            return DatabaseHelper.GetData(query.ToString(),
                ("@FromDate", fromDate),
                ("@ToDate", toDate)
            );
        }
    }
}
