using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abchotel.Model;

namespace abchotel.DAL
{
    public class DichVuDAL
    {
        public List<DichVu> LayTatCaDichVu()
        {
            string query = "SELECT * FROM DichVu";
            DataTable dt = DatabaseHelper.GetData(query);
            List<DichVu> list = new List<DichVu>();

            foreach (DataRow row in dt.Rows)
            {
                list.Add(new DichVu
                {
                    MaDichVu = (int)row["MaDichVu"],
                    TenDichVu = row["TenDichVu"].ToString(),
                    DonGia = (decimal)row["DonGia"]
                    
                });
            }
            return list;
        }
    }
}
