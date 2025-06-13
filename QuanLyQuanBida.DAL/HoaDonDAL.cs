using QuanLyQuanBida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBida.DAL
{
    public class HoaDonDAL
    {
        private DB_QuanLyQuanBidaEntities db = new DB_QuanLyQuanBidaEntities();

        public DateTime LayThoiGianBatDau(int maHoaDon)
        {
            return db.HoaDon
                .Where(hd => hd.MaHoaDon == maHoaDon)
                .Select(hd => hd.ThoiGianBatDau)
                .FirstOrDefault();
        }
        public HoaDonDTO LayHoaDonChuaThanhToanTheoMaBan(int maBan)
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                return db.HoaDon
                         .Where(hd => hd.MaBan == maBan && hd.TrangThai == "Chưa thanh toán")
                         .Select(hd => new HoaDonDTO
                         {
                             MaHoaDon = hd.MaHoaDon,
                             ThoiGianBatDau = hd.ThoiGianBatDau
                         })
                         .FirstOrDefault();
            }
        }

        public List<DichVuDTO> LayChiTietDichVu(int maHoaDon)
        {
            List<DichVuDTO> chiTietDichVu = db.ChiTietHoaDon
                .Where(ct => ct.MaHoaDon == maHoaDon)
                .Select(ct => new DichVuDTO
                {
                    MaDichVu = ct.MaDichVu,
                    TenDichVu = ct.DichVu.TenDichVu,
                    MaLoaiDV = ct.DichVu.MaLoaiDV,
                    DonViTinh = ct.DichVu.DonViTinh,
                    LoaiDichVu = ct.DichVu.LoaiDichVu.TenLoaiDV,
                    Gia = ct.DichVu.Gia,
                    SoLuong = ct.SoLuong
                }).ToList();
            return chiTietDichVu;
        }
        public int TaoHoaDon(int maKH, string tenKhach, int maBan)
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                var hoaDon = new HoaDon
                {
                    MaHoaDon = TaoMaHoaDonNgauNhien(db),
                    ThoiGianBatDau = DateTime.Now,
                    GiamGia = 0,
                    TrangThai = "Chưa thanh toán",
                    MaBan = maBan,
                    MaKhachHang = maKH,
                    MaNhanVienTao = null, // Chưa có làm form đăng nhập nhân viên
                };
                db.HoaDon.Add(hoaDon);
                db.SaveChanges();

                return hoaDon.MaHoaDon;
            }
        }

        public int TaoMaHoaDonNgauNhien(DB_QuanLyQuanBidaEntities db)
        {
            int maHoaDon;
            Random rnd = new Random();

            do
            {
                int timePart = (int)(DateTime.Now.Ticks % 100000); // 5 chữ số
                int randomPart = rnd.Next(10000, 99999);           // 5 chữ số
                maHoaDon = int.Parse($"{timePart}{randomPart}".Substring(0, 9)); // Tổng: 9 chữ số

            } while (db.HoaDon.Any(h => h.MaHoaDon == maHoaDon)); 
            return maHoaDon;
        }
    }
}
