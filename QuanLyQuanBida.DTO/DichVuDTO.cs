using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBida.DTO
{
    public class DichVuDTO
    {
        public int MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public Nullable<int> MaLoaiDV { get; set; }
        public string DonViTinh { get; set; }
        public string LoaiDichVu { get; set; }
        public decimal Gia { get; set; }
    }
}
