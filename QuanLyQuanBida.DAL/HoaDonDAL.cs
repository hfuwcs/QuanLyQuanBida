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
        public int TaoHoaDon(int maKH, string tenKhach, int maBan, int maNV)
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                var hoaDon = new HoaDon
                {
                    MaHoaDon = 0, //tự động tăng
                    ThoiGianBatDau = DateTime.Now,
                    GiamGia = 0,
                    TrangThai = "Chưa thanh toán",
                    MaBan = maBan,
                    MaKhachHang = maKH,
                    MaNhanVienTao = maNV,
                };
                db.HoaDon.Add(hoaDon);
                db.SaveChanges();

                return hoaDon.MaHoaDon;
            }
        }
        public int CapNhatHoaDon(int maHoaDon, decimal tongTien,decimal giamGia, decimal tienGio,decimal tienDichVu)
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                var hoaDon = db.HoaDon.FirstOrDefault(hd => hd.MaHoaDon == maHoaDon);
                if (hoaDon != null)
                {
                    hoaDon.TongTien = tongTien;
                    hoaDon.GiamGia = giamGia;
                    hoaDon.TienGio = tienGio;
                    hoaDon.TienDichVu = tienDichVu;
                    hoaDon.ThoiGianKetThuc = DateTime.Now; 
                    hoaDon.TrangThai = "Đã thanh toán"; 
                    db.SaveChanges();
                    return 1;
                }
                return 0; 
            }
        }
    }
}
