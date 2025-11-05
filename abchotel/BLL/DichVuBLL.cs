using abchotel.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using abchotel.Model;

namespace abchotel.BLL
{
    public class DichVuBLL
    {
        private DichVuDAL dal = new DichVuDAL();
        public List<DichVu> LayTatCaDichVu() => dal.LayTatCaDichVu();
    }
}
