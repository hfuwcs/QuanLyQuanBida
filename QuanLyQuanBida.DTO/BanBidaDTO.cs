using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBida.DTO
{
    public class BanBidaDTO
    {
        public int MaBan { get; set; }
        public string TenBan { get; set; }
        public Nullable<int> MaLoaiBan { get; set; }
        public string TrangThai { get; set; }
        public decimal GiaTheoGio { get; set; }
    }
}
