using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBida.DTO
{
    public class HoaDonDTO
    {
        public int MaHoaDon { get; set; }
        public int MaBan { get; set; }
        public Nullable<int> MaKhachHang { get; set; }
        public Nullable<int> MaNhanVienTao { get; set; }
        public System.DateTime ThoiGianBatDau { get; set; }
        public Nullable<System.DateTime> ThoiGianKetThuc { get; set; }
        public Nullable<decimal> TienGio { get; set; }
        public Nullable<decimal> TienDichVu { get; set; }
        public Nullable<decimal> GiamGia { get; set; }
        public Nullable<decimal> TongTien { get; set; }
        public string TrangThai { get; set; }
    }
}
