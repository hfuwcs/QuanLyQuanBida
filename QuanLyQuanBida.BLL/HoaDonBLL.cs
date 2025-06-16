using Helper;
using QuanLyQuanBida;
using QuanLyQuanBida.DAL;
using QuanLyQuanBida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuanLyQuanBida.BLL
{
    public class HoaDonBLL
    {
        HoaDonDAL HoaDonDAL = new HoaDonDAL();
        private BanBidaDAL banBidaDAL = new BanBidaDAL();
        private ChiTietHoaDonDAL ChiTietHoaDonDAL = new ChiTietHoaDonDAL();
        private HoaDonReportDAL dal = new HoaDonReportDAL();
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

        public int TaoHoaDon(int maKH, string tenKhachVangLai, int maBan, int maNV, List<ChiTietHoaDonDTO> dichVuChonTruoc) 
        {
            if ((maKH <= 0 && string.IsNullOrWhiteSpace(tenKhachVangLai)) || maBan <= 0)
            {
                throw new ArgumentException("Thông tin khách hàng hoặc bàn không hợp lệ.");
            }

            var ban = banBidaDAL.LayChiTietBan(maBan);
            if (ban == null || ban.TrangThai != "Trống")
            {
                throw new InvalidOperationException("Bàn không trống hoặc không tồn tại.");
            }

            bool isVangLai = (maKH == AppSettings.VangLaiCustomerId);

            if (isVangLai)
            {
                if (string.IsNullOrWhiteSpace(tenKhachVangLai))
                {
                    throw new ArgumentException("Vui lòng nhập tên khách vãng lai.");
                }
            }
            else
            {
                tenKhachVangLai = null;
            }

            int maHoaDonMoi = HoaDonDAL.TaoHoaDon(maKH, tenKhachVangLai, maBan, maNV);

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
        #region Thống kê hóa đơn
        public Dictionary<string, double> GetMonthlyRevenue(int year)
        {
            return HoaDonDAL.GetMonthlyRevenue(year);
        }
        public Dictionary<string, double> GetMonthlyRevenue(DateTime startDate, DateTime endDate)
        {
            return HoaDonDAL.GetMonthlyRevenue(startDate, endDate);
        }

        public Dictionary<string, double> GetRevenueByCategory()
        {
            return HoaDonDAL.GetRevenueByCategory();
        }

        public Dictionary<string, double> GetTopRevenueByTable(int topN = 5)
        {
            return HoaDonDAL.GetTopRevenueByTable(topN);
        }

        public Dictionary<DateTime, double> GetDailyRevenue(int days = 7)
        {
            return HoaDonDAL.GetDailyRevenue(days);
        }
        #endregion
        public List<HoaDonReportDTO> GetReportData(int maHoaDon)
        {
            return dal.GetReportDataByMaHoaDon(maHoaDon);
        }
        public List<HoaDonReportDTO> LayDuLieuChoHoaDonReport(int maHoaDon)
        {
            var hoaDonEntity = new HoaDonDAL().LayHoaDonDayDuTheoMa(maHoaDon); // Giả sử DAL có phương thức này
            if (hoaDonEntity == null) return null;

            var reportDataList = new List<HoaDonReportDTO>();

            var thongTinChung = new
            {
                MaHoaDon = hoaDonEntity.MaHoaDon,
                TenBan = hoaDonEntity.BanBida?.TenBan ?? "N/A",
                ThoiGianBatDau = hoaDonEntity.ThoiGianBatDau,
                ThoiGianKetThuc = hoaDonEntity.ThoiGianKetThuc,
                TenNhanVien = hoaDonEntity.NhanVien?.HoTen ?? "N/A",
                TenKhachHang = hoaDonEntity.KhachHang?.HoTen ?? "Khách vãng lai",
                TongTienGio = hoaDonEntity.TienGio ?? 0,
                TongTienDichVu = hoaDonEntity.TienDichVu ?? 0,
                GiamGia = hoaDonEntity.GiamGia ?? 0,
                TongThanhToan = hoaDonEntity.TongTien ?? 0
            };

            if (thongTinChung.TongTienGio > 0)
            {
                TimeSpan thoiGianChoi = TimeSpan.Zero;
                if (thongTinChung.ThoiGianKetThuc.HasValue)
                {
                    thoiGianChoi = thongTinChung.ThoiGianKetThuc.Value - thongTinChung.ThoiGianBatDau;
                }
                reportDataList.Add(new HoaDonReportDTO
                {
                    // Thông tin chung
                    MaHoaDon = thongTinChung.MaHoaDon,
                    TenBan = thongTinChung.TenBan,
                    ThoiGianBatDau = thongTinChung.ThoiGianBatDau,
                    ThoiGianKetThuc = thongTinChung.ThoiGianKetThuc,
                    TenNhanVien = thongTinChung.TenNhanVien,
                    TenKhachHang = thongTinChung.TenKhachHang,
                    TongTienGio = thongTinChung.TongTienGio,
                    TongTienDichVu = thongTinChung.TongTienDichVu,
                    GiamGia = thongTinChung.GiamGia,
                    TongThanhToan = thongTinChung.TongThanhToan,
                    // Thông tin dòng
                    Item_TenDichVu = $"Tiền giờ ({thoiGianChoi.Hours}h {thoiGianChoi.Minutes}p)",
                    Item_SoLuong = 1,
                    Item_DonGia = 0,
                    Item_ThanhTien = thongTinChung.TongTienGio
                });
            }


            foreach (var cthd in hoaDonEntity.ChiTietHoaDon)
            {
                reportDataList.Add(new HoaDonReportDTO
                {
                    MaHoaDon = thongTinChung.MaHoaDon,
                    TenBan = thongTinChung.TenBan,
                    ThoiGianBatDau = thongTinChung.ThoiGianBatDau,
                    ThoiGianKetThuc = thongTinChung.ThoiGianKetThuc,
                    TenNhanVien = thongTinChung.TenNhanVien,
                    TenKhachHang = thongTinChung.TenKhachHang,
                    TongTienGio = thongTinChung.TongTienGio,
                    TongTienDichVu = thongTinChung.TongTienDichVu,
                    GiamGia = thongTinChung.GiamGia,
                    TongThanhToan = thongTinChung.TongThanhToan,
                    Item_TenDichVu = cthd.DichVu?.TenDichVu ?? "N/A",
                    Item_SoLuong = cthd.SoLuong,
                    Item_DonGia = cthd.DonGia,
                    Item_ThanhTien = cthd.SoLuong * cthd.DonGia
                });
            }
            return reportDataList;
        }
    }
}
