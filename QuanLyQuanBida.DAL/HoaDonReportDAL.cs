using QuanLyQuanBida.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace QuanLyQuanBida.DAL
{
    public class HoaDonReportDAL
    {
        public List<HoaDonReportDTO> GetReportDataByMaHoaDon(int maHoaDon)
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                var hoaDonCoBan = db.HoaDon
                    .Where(hd => hd.MaHoaDon == maHoaDon)
                    .Select(hd => new
                    {
                        hd.ThoiGianBatDau,
                        GiaTheoGio = hd.BanBida.LoaiBan.GiaTheoGio,

                        hd.MaHoaDon,
                        hd.BanBida.TenBan,
                        hd.ThoiGianKetThuc,
                        TenNhanVien = (hd.NhanVien == null) ? "N/A" : hd.NhanVien.HoTen,
                        TenKhachHang = (hd.KhachHang == null) ? "Khách vãng lai" : hd.KhachHang.HoTen,
                        GiamGia = hd.GiamGia ?? 0
                    })
                    .FirstOrDefault();

                // Nếu không tìm thấy hóa đơn, trả về danh sách rỗng
                if (hoaDonCoBan == null)
                {
                    return new List<HoaDonReportDTO>();
                }

                DateTime thoiGianTinhToan = hoaDonCoBan.ThoiGianKetThuc ?? DateTime.Now;

                decimal tienGio = TinhTienGio(hoaDonCoBan.ThoiGianBatDau, thoiGianTinhToan, hoaDonCoBan.GiaTheoGio);

                decimal tienDichVu = db.ChiTietHoaDon
                                     .Where(cthd => cthd.MaHoaDon == maHoaDon)
                                     .Sum(cthd => (decimal?)(cthd.SoLuong * cthd.DonGia)) ?? 0;

                decimal tongThanhToan = tienGio + tienDichVu - hoaDonCoBan.GiamGia;

                var reportDataList = new List<HoaDonReportDTO>();

                if (tienGio > 0)
                {
                    reportDataList.Add(new HoaDonReportDTO
                    {
                        MaHoaDon = hoaDonCoBan.MaHoaDon,
                        TenBan = hoaDonCoBan.TenBan,
                        ThoiGianBatDau = hoaDonCoBan.ThoiGianBatDau,
                        ThoiGianKetThuc = thoiGianTinhToan,
                        TenNhanVien = hoaDonCoBan.TenNhanVien,
                        TenKhachHang = hoaDonCoBan.TenKhachHang,
                        TongTienGio = tienGio,
                        TongTienDichVu = tienDichVu,
                        GiamGia = hoaDonCoBan.GiamGia,
                        TongThanhToan = tongThanhToan,
                        Item_TenDichVu = "Tiền giờ chơi",
                        Item_SoLuong = 1,
                        Item_DonGia = tienGio,
                        Item_ThanhTien = tienGio
                    });
                }

                var chiTietDichVu = db.ChiTietHoaDon
                    .Where(cthd => cthd.MaHoaDon == maHoaDon)
                    .Select(cthd => new { TenDichVu = cthd.DichVu.TenDichVu, cthd.SoLuong, cthd.DonGia, ThanhTien = cthd.ThanhTien ?? 0 })
                    .ToList();

                foreach (var item in chiTietDichVu)
                {
                    reportDataList.Add(new HoaDonReportDTO
                    {
                        MaHoaDon = hoaDonCoBan.MaHoaDon,
                        TenBan = hoaDonCoBan.TenBan,
                        ThoiGianBatDau = hoaDonCoBan.ThoiGianBatDau,
                        ThoiGianKetThuc = thoiGianTinhToan,
                        TenNhanVien = hoaDonCoBan.TenNhanVien,
                        TenKhachHang = hoaDonCoBan.TenKhachHang,
                        TongTienGio = tienGio,
                        TongTienDichVu = tienDichVu,
                        GiamGia = hoaDonCoBan.GiamGia,
                        TongThanhToan = tongThanhToan,
                        Item_TenDichVu = item.TenDichVu,
                        Item_SoLuong = item.SoLuong,
                        Item_DonGia = item.DonGia,
                        Item_ThanhTien = item.ThanhTien
                    });
                }

                if (!reportDataList.Any())
                {
                    reportDataList.Add(new HoaDonReportDTO
                    {
                        MaHoaDon = hoaDonCoBan.MaHoaDon,
                        TenBan = hoaDonCoBan.TenBan,
                        ThoiGianBatDau = hoaDonCoBan.ThoiGianBatDau,
                        ThoiGianKetThuc = thoiGianTinhToan,
                        TenNhanVien = hoaDonCoBan.TenNhanVien,
                        TenKhachHang = hoaDonCoBan.TenKhachHang,
                        TongTienGio = tienGio,
                        TongTienDichVu = tienDichVu,
                        GiamGia = hoaDonCoBan.GiamGia,
                        TongThanhToan = tongThanhToan,
                        Item_TenDichVu = null
                    });
                }

                return reportDataList;
            }
        }

        private decimal TinhTienGio(DateTime thoiGianBatDau, DateTime thoiGianKetThuc, decimal donGiaTheoGio)
        {
            if (thoiGianKetThuc <= thoiGianBatDau || donGiaTheoGio <= 0)
            {
                return 0m;
            }
            double tongSoPhutThucTe = (thoiGianKetThuc - thoiGianBatDau).TotalMinutes;
            if (tongSoPhutThucTe <= 60)
            {
                return donGiaTheoGio;
            }
            else
            {
                double phutChoiThem = tongSoPhutThucTe - 60;
                int soBlockTinhTien = (int)Math.Ceiling(phutChoiThem / 10);
                int tongSoPhutTinhTien = 60 + (soBlockTinhTien * 10);
                decimal donGiaTheoPhut = donGiaTheoGio / 60;
                return Math.Round(tongSoPhutTinhTien * donGiaTheoPhut);
            }
        }
    }
}