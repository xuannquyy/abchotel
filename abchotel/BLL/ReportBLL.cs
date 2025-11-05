using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abchotel.DAL;

namespace abchotel.BLL
{
    public class ReportBLL
    {
        private ReportDAL dal = new ReportDAL();

        public DataTable LayDuLieuBaoCao(string reportType, DateTime fromDate, DateTime toDate)
        {
            return dal.LayDuLieuBaoCao(reportType, fromDate, toDate);
        }
    }
}
