using abchotel.DAL;
using abchotel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abchotel.BLL
{
    public class NguoiDungBLL
    {
        private readonly NguoiDungDAL dal = new NguoiDungDAL();
        public NguoiDung LayTheoMa(int maND)
        {
            return dal.LayTheoMa(maND);
        }
        public DataTable LayTatCa()
        {
            return dal.LayTatCa();
        }

        public bool Them(NguoiDung nd)
        {
            return dal.Them(nd);
        }
        public bool SuaThongTinCaNhan(NguoiDung nd)
        {
            return dal.SuaThongTinCaNhan(nd);
        }
        public bool Xoa(int ma)
        {
            return dal.Xoa(ma);
        }

        public bool DoiMatKhau(int ma, string cu, string moi)
        {
            return dal.DoiMatKhau(ma, cu, moi);
        }
        public NguoiDung DangNhap(string username, string password)
        {
            return dal.DangNhap(username, password);
        }
        public NguoiDung CheckEmail(string email)
        {
            return dal.CheckEmail(email);
        }

        public bool DoiMatKhauTheoTen(string username, string email, string newPass)
        {
            return dal.DoiMatKhauTheoTen(username, email, newPass);
        }
        public DataTable TimKiem(string keyword)
        {
            return dal.TimKiem(keyword);
        }
    }
}
