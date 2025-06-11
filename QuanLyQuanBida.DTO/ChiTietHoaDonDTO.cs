using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBida.DTO
{
    public class ChiTietHoaDonDTO
    {
        public int MaCTHD { get; set; }
        public int MaHoaDon { get; set; }
        public int MaDichVu { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public Nullable<decimal> ThanhTien { get; set; }
    }
}
