using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanBida.DTO;

namespace QuanLyQuanBida.DAL
{
    public class KhachHangDAL
    {
        private DB_QuanLyQuanBidaEntities db = new DB_QuanLyQuanBidaEntities();

        public List<KhachHangDTO> LayDanhSachKhachHang()
        {
            var khachHangs = db.KhachHang
                .Select(kh => new KhachHangDTO
                {
                    MaKhachHang = kh.MaKhachHang,
                    HoTenVaSDT = kh.HoTen + " - " + kh.SoDienThoai
                })
                .ToList();
            return khachHangs;
        }
        public string LayTenKhachHang(int maKhachHang)
        {
            return db.KhachHang
                .Where(kh => kh.MaKhachHang == maKhachHang)
                .Select(kh => kh.HoTen)
                .FirstOrDefault();
        }
    }
}
