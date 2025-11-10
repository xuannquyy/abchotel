using abchotel.DAL;
using abchotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abchotel.BLL
{
    public class ChiTietDichVuBLL
    {
        private readonly ChiTietDichVuDAL dal = new ChiTietDichVuDAL();

        public bool Them(ChiTietDichVu ctdv) => dal.Them(ctdv);
    }
}
