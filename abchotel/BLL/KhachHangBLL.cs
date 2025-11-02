using abchotel.DAL;
using abchotel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abchotel.BLL
{
    public class KhachHangBLL
    {
        private KhachHangDAL khDAL = new KhachHangDAL();
        public List<KhachHang> LayTatCaKhachHang()
        {
            return khDAL.LayTatCaKhachHang();
        }
    }

}
