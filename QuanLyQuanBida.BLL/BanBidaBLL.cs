using QuanLyQuanBida.DAL;
using QuanLyQuanBida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBida.BLL
{
    public class BanBidaBLL
    {
        private BanBidaDAL bidaDAL = new BanBidaDAL();

        public List<BanBidaDTO> LayDanhSachBan()
        {
            return bidaDAL.LayDanhSachBan();
        }
        public BanBidaDTO LayChiTietBan(int maBan)
        {
            return bidaDAL.LayChiTietBan(maBan);
        }


    }
}
