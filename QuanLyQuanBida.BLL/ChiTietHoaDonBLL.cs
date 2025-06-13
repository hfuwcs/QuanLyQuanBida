using QuanLyQuanBida.DAL;
using QuanLyQuanBida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBida.BLL
{
    public class ChiTietHoaDonBLL
    {
        private ChiTietHoaDonDAL chiTietHoaDonDAL = new ChiTietHoaDonDAL();
        private DichVuDAL dichVuDAL = new DichVuDAL();

        public ChiTietHoaDonDTO ThemHoacCapNhatDichVuChoHoaDon(int maHoaDon, int maDichVu, int soLuongMoi, decimal donGiaHienTaiCuaDichVu)
        {
            if (maHoaDon <= 0 || maDichVu <= 0)
                throw new ArgumentException("Mã hóa đơn hoặc mã dịch vụ không hợp lệ.");


            var persistedEntity = chiTietHoaDonDAL.ThemHoacCapNhatDichVu(maHoaDon, maDichVu, soLuongMoi, donGiaHienTaiCuaDichVu);

            if (persistedEntity != null)
            {
                return new ChiTietHoaDonDTO
                {
                    MaCTHD = persistedEntity.MaCTHD,
                    MaHoaDon = persistedEntity.MaHoaDon,
                    MaDichVu = persistedEntity.MaDichVu,
                    SoLuong = persistedEntity.SoLuong,
                    DonGia = persistedEntity.DonGia
                };
            }
            return null;
        }

        public bool ThemDanhSachDichVuVaoHoaDon(int maHoaDon, List<ChiTietHoaDonDTO> danhSachDichVuChon)
        {
            if (maHoaDon <= 0) throw new ArgumentException("Mã hóa đơn không hợp lệ.");
            return chiTietHoaDonDAL.ThemDanhSachDichVuVaoHoaDon(maHoaDon, danhSachDichVuChon);
        }
    }
}