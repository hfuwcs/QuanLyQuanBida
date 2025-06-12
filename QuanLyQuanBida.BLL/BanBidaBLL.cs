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
        KhachHangDAL khachHangDAL = new KhachHangDAL();
        LoaiDichVuDAL loaiDichVuDAL = new LoaiDichVuDAL();
        DichVuDAL dichVuDAL = new DichVuDAL();

        public List<BanBidaDTO> LayDanhSachBan()
        {
            return bidaDAL.LayDanhSachBan();
        }
        public List<KhachHangDTO> LayDanhSachKhachHang()
        {
            return khachHangDAL.LayDanhSachKhachHang();
        }
        public List<string> LayDanhSachLoaiDichVu()
        {
            return loaiDichVuDAL.LayDanhSachLoaiDichVu();
        }
        public List<DichVuDTO> LayDanhSachDichVu(string tenLoaiDichVu = "All")
        {
            return dichVuDAL.LayDanhSachDichVu(tenLoaiDichVu);
        }
        public List<string> LayDanhSachLoaiDichVuToComboBox()
        {
            return loaiDichVuDAL.LoadLoaiDichVuToComboBox();
        }
    }
}
