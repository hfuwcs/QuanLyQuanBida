using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBida.DTO
{
    public class HoaDonReportDTO
    {
        // --- Thông tin chung của Hóa Đơn
        public int MaHoaDon { get; set; }
        public string TenBan { get; set; }
        public DateTime ThoiGianBatDau { get; set; }
        public DateTime? ThoiGianKetThuc { get; set; }
        public string TenNhanVien { get; set; }
        public string TenKhachHang { get; set; }
        public decimal TongTienGio { get; set; }
        public decimal TongTienDichVu { get; set; }
        public decimal GiamGia { get; set; }
        public decimal TongThanhToan { get; set; }

        // --- Thông tin chi tiết của từng Dòng
        public string Item_TenDichVu { get; set; }
        public int Item_SoLuong { get; set; }
        public decimal Item_DonGia { get; set; }
        public decimal Item_ThanhTien { get; set; }
    }
}