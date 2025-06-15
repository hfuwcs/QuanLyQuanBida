using QuanLyQuanBida.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                         .OrderByDescending(hd => hd.ThoiGianBatDau)
                         .Select(hd => new HoaDonDTO
                         {
                             MaHoaDon = hd.MaHoaDon,
                             ThoiGianBatDau = hd.ThoiGianBatDau,

                             MaBan = hd.BanBida.MaBan,
                             TenBan = hd.BanBida.TenBan,
                             GiaTheoGio = hd.BanBida.LoaiBan.GiaTheoGio,
                             TongTien = hd.TongTien ?? 0,

                             ChiTietDichVu = hd.ChiTietHoaDon.Select(ct => new ChiTietHoaDonDTO
                             {
                                 MaCTHD = ct.MaCTHD,
                                 MaDichVu = ct.MaDichVu,
                                 TenDichVu = ct.DichVu.TenDichVu,
                                 SoLuong = ct.SoLuong,
                                 DonGia = ct.DonGia,
                                 ThanhTien = ct.ThanhTien, 
                             }).ToList()
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
        public HoaDon LayHoaDonDayDuTheoMa(int maHoaDon)
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                return db.HoaDon
                         .Include(hd => hd.BanBida)
                         .Include(hd => hd.NhanVien)
                         .Include(hd => hd.KhachHang)
                         .Include(hd => hd.ChiTietHoaDon.Select(cthd => cthd.DichVu))
                         .FirstOrDefault(hd => hd.MaHoaDon == maHoaDon);
            }
        }
        #region Doanh thu
        // 1. Doanh thu theo Tháng (theo năm)
        public Dictionary<string, double> GetMonthlyRevenue(int year)
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                var monthlyRevenue = db.HoaDon
                    .Where(hd => hd.ThoiGianKetThuc.HasValue && hd.ThoiGianKetThuc.Value.Year == year && hd.TongTien.HasValue)
                    .GroupBy(hd => hd.ThoiGianKetThuc.Value.Month)
                    .Select(g => new
                    {
                        Month = g.Key,
                        TotalRevenue = g.Sum(hd => hd.TongTien.Value) 
                    })
                    .OrderBy(r => r.Month)
                    .ToList()
                    .ToDictionary(r => $"Tháng {r.Month}/{year}", r => (double)r.TotalRevenue); // Ép kiểu sang double
                return monthlyRevenue;
            }
        }

        // Doanh thu theo Tháng (theo khoảng thời gian)
        public Dictionary<string, double> GetMonthlyRevenue(DateTime startDate, DateTime endDate)
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                DateTime inclusiveEndDate = endDate.Date.AddDays(1).AddTicks(-1);

                var monthlyRevenue = db.HoaDon
                    .Where(hd => hd.ThoiGianKetThuc.HasValue && hd.ThoiGianKetThuc.Value >= startDate.Date && hd.ThoiGianKetThuc.Value <= inclusiveEndDate && hd.TongTien.HasValue)
                    .GroupBy(hd => new { hd.ThoiGianKetThuc.Value.Year, hd.ThoiGianKetThuc.Value.Month })
                    .Select(g => new
                    {
                        Year = g.Key.Year,
                        Month = g.Key.Month,
                        TotalRevenue = g.Sum(hd => hd.TongTien.Value) 
                    })
                    .OrderBy(r => r.Year).ThenBy(r => r.Month)
                    .ToList() // Thực thi query
                    .ToDictionary(r => $"Tháng {r.Month}/{r.Year}", r => (double)r.TotalRevenue); // Ép kiểu sang double
                return monthlyRevenue;
            }
        }

        // 2. Doanh thu theo Loại Dịch Vụ
        public Dictionary<string, double> GetRevenueByCategory()
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                var revenueByCategory = new Dictionary<string, double>();

                // a. Doanh thu từ các dịch vụ (items)
                var serviceItemRevenueQuery = db.ChiTietHoaDon
                    .Where(cthd => cthd.HoaDon.ThoiGianKetThuc.HasValue && // Chỉ tính các hóa đơn đã hoàn thành
                                   cthd.DichVu != null &&
                                   cthd.DichVu.LoaiDichVu != null && // Đảm bảo LoaiDichVu tồn tại
                                   cthd.SoLuong > 0 && // Số lượng phải lớn hơn 0
                                   cthd.DichVu.Gia > 0) // Giá phải lớn hơn 0 
                    .GroupBy(cthd => cthd.DichVu.LoaiDichVu.TenLoaiDV) 
                    .Select(g => new
                    {
                        CategoryName = g.Key,
                        TotalRevenueForCategory = g.Sum(cthd => (decimal)cthd.SoLuong * cthd.DichVu.Gia)
                    })
                    .ToList();

                foreach (var item in serviceItemRevenueQuery)
                {
                    revenueByCategory[item.CategoryName] = (double)item.TotalRevenueForCategory; // Ép kiểu
                }

                // b. Tổng tiền giờ từ tất cả các hóa đơn đã hoàn thành
                double totalHourlyRevenueFromBills = (double)(db.HoaDon
                    .Where(hd => hd.ThoiGianKetThuc.HasValue && hd.TienGio.HasValue && hd.TienGio.Value > 0)
                    .Sum(hd => (decimal?)hd.TienGio.Value) ?? 0m);

                revenueByCategory["Tiền giờ"] = totalHourlyRevenueFromBills;

                return revenueByCategory;
            }
        }

        // 3. Doanh thu theo Bàn (Top N bàn)
        public Dictionary<string, double> GetTopRevenueByTable(int topN = 5)
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                var revenueByTable = db.HoaDon
                    .Where(hd => hd.ThoiGianKetThuc.HasValue && hd.BanBida != null && hd.TongTien.HasValue)
                    .GroupBy(hd => hd.BanBida.TenBan) 
                    .Select(g => new
                    {
                        TableName = g.Key,
                        TotalRevenue = g.Sum(hd => hd.TongTien.Value) 
                    })
                    .OrderByDescending(r => r.TotalRevenue)
                    .Take(topN)
                    .ToList()
                    .ToDictionary(r => r.TableName, r => (double)r.TotalRevenue); 
                return revenueByTable;
            }
        }

        // 4. Doanh thu theo Ngày
        public Dictionary<DateTime, double> GetDailyRevenue(int days = 7)
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                DateTime today = DateTime.Today;
                DateTime startDate = today.AddDays(-(days - 1));

                var dailyRevenue = db.HoaDon
                    .Where(hd => hd.ThoiGianKetThuc.HasValue &&
                                 DbFunctions.TruncateTime(hd.ThoiGianKetThuc.Value) >= startDate &&
                                 DbFunctions.TruncateTime(hd.ThoiGianKetThuc.Value) <= today &&
                                 hd.TongTien.HasValue)
                    .GroupBy(hd => DbFunctions.TruncateTime(hd.ThoiGianKetThuc.Value))
                    .Select(g => new
                    {
                        Date = g.Key.Value,
                        TotalRevenue = g.Sum(hd => hd.TongTien.Value)
                    })
                    .OrderBy(r => r.Date)
                    .ToList()
                    .ToDictionary(r => r.Date, r => (double)r.TotalRevenue);
                return dailyRevenue;
            }
        }
        #endregion
    }
}
