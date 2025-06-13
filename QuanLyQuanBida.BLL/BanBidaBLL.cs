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
        public int CapNhatTrangThaiBan(int maBan, string trangThai)
        {
            if (string.IsNullOrEmpty(trangThai) || (trangThai != "Trống" && trangThai != "Đang chơi" && trangThai != "Bảo trì"))
            {
                throw new ArgumentException("Trạng thái bàn không hợp lệ.");
            }
            return bidaDAL.CapNhatTrangThaiBan(maBan, trangThai);
        }
    }
}
