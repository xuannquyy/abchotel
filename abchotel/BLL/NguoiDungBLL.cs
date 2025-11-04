
using abchotel.Model;

using System;

using System.Collections.Generic;

using System.Data;

using System.Linq;

using System.Text;

using System.Threading.Tasks;
using abchotel.DAL;



namespace abchotel.BLL

{

    public class NguoiDungBLL

    {

        private readonly NguoiDungDAL dal = new NguoiDungDAL();



        public DataTable LayTatCa()

        {

            return dal.LayTatCa();

        }



        public bool Them(NguoiDung nd)

        {

            return dal.Them(nd);

        }



        public bool Xoa(int ma)

        {

            return dal.Xoa(ma);

        }



        public bool DoiMatKhau(int ma, string cu, string moi)

        {

            return dal.DoiMatKhau(ma, cu, moi);

        }

    }

}
