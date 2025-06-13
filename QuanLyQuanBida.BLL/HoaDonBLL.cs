﻿using QuanLyQuanBida.DAL;
using QuanLyQuanBida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBida.BLL
{
    public class HoaDonBLL
    {
        HoaDonDAL HoaDonDAL = new HoaDonDAL();
        private BanBidaDAL banBidaDAL = new BanBidaDAL();
        private ChiTietHoaDonDAL ChiTietHoaDonDAL = new ChiTietHoaDonDAL();
        public Tuple<int, decimal> TinhTienGio(DateTime thoiGianBatDau, DateTime thoiGianKetThuc, decimal donGiaTheoGio)
        {
            if (thoiGianKetThuc <= thoiGianBatDau || donGiaTheoGio <= 0)
            {
                return Tuple.Create(0, 0m); 
            }

            // Tính tổng số phút thực tế khách đã chơi
            double tongSoPhutThucTe = (thoiGianKetThuc - thoiGianBatDau).TotalMinutes;

            // Quy tắc 1: Nếu chơi từ 60 phút trở xuống, tính tròn 1 giờ
            if (tongSoPhutThucTe <= 60)
            {
                return Tuple.Create(60, donGiaTheoGio);
            }

            // Quy tắc 2: Nếu chơi trên 60 phút
            else
            {
                // Tách phần giờ đầu và số phút chơi thêm
                int phutGioDau = 60;
                double phutChoiThem = tongSoPhutThucTe - phutGioDau;

                // Quy định kích thước block (10 phút)
                const int kichThuocBlock = 10;

                // Tính số block cần tính tiền bằng cách làm tròn lên
                int soBlockTinhTien = (int)Math.Ceiling(phutChoiThem / kichThuocBlock);

                // Tổng số phút cuối cùng cần tính tiền
                int tongSoPhutTinhTien = phutGioDau + (soBlockTinhTien * kichThuocBlock);

                decimal donGiaTheoPhut = donGiaTheoGio / 60;
                decimal tongTien = tongSoPhutTinhTien * donGiaTheoPhut;

                return Tuple.Create(tongSoPhutTinhTien, tongTien);
            }
        }
        public List<DichVuDTO> LayChiTietDichVu(int maHoaDon)
        { 
            return HoaDonDAL.LayChiTietDichVu(maHoaDon);
        }
        public HoaDonDTO LayHoaDonHienTaiCuaBan(int maBan)
        {
            var hoaDon = HoaDonDAL.LayHoaDonChuaThanhToanTheoMaBan(maBan);
            if (hoaDon != null)
            {
                hoaDon.ChiTietDichVu = ChiTietHoaDonDAL.LayChiTietDichVuTheoMaHD(hoaDon.MaHoaDon);
            }
            return hoaDon;
        }

        public int TaoHoaDon(int maKH, string tenKhach, int maBan, int maNV, List<ChiTietHoaDonDTO> dichVuChonTruoc) 
        {
            if ((maKH <= 0 && string.IsNullOrWhiteSpace(tenKhach)) || maBan <= 0)
            {
                throw new ArgumentException("Thông tin khách hàng hoặc bàn không hợp lệ.");
            }

            var ban = banBidaDAL.LayChiTietBan(maBan);
            if (ban == null || ban.TrangThai != "Trống")
            {
                throw new InvalidOperationException("Bàn không trống hoặc không tồn tại.");
            }

            int maHoaDonMoi = HoaDonDAL.TaoHoaDon(maKH, tenKhach, maBan, maNV);
            if (maHoaDonMoi <= 0)
            {
                throw new Exception("Không thể tạo hóa đơn mới.");
            }

            if (dichVuChonTruoc != null && dichVuChonTruoc.Any())
            {
                bool themOk = ChiTietHoaDonDAL.ThemDanhSachDichVuVaoHoaDon(maHoaDonMoi, dichVuChonTruoc);
                if (!themOk)
                {
                    Console.WriteLine($"Lỗi khi thêm dịch vụ chọn trước cho hóa đơn {maHoaDonMoi}");
                }
            }

            banBidaDAL.CapNhatTrangThaiBan(maBan, "Đang chơi");
            return maHoaDonMoi;
        }
        public bool ThanhToan(int maHoaDon, int maBan, decimal tongTien, decimal giamGia, decimal tienGio, decimal tienDichVu)
        {
            try
            {
                int ketQuaHD = HoaDonDAL.CapNhatHoaDon(maHoaDon, tongTien, giamGia, tienGio, tienDichVu);

                if (ketQuaHD > 0)
                {
                    banBidaDAL.CapNhatTrangThaiBan(maBan, "Trống");
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public decimal LayDonGiaTheoGio(int maLoaiBan)
        {
            return banBidaDAL.LayDonGiaTheoGio(maLoaiBan);
        }

        public DateTime LayThoiGianBatDau(int maHoaDon)
        {
            return HoaDonDAL.LayThoiGianBatDau(maHoaDon);
        }
    }
}
