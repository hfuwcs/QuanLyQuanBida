using QuanLyQuanBida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBida.DAL
{
    public class BanBidaDAL
    {
        private DB_QuanLyQuanBidaEntities db = new DB_QuanLyQuanBidaEntities();
        public List<BanBidaDTO> LayDanhSachBan()
        {
            var tables = db.BanBida
                .Select(b => new BanBidaDTO
                {
                    MaBan = b.MaBan,
                    MaLoaiBan = b.MaLoaiBan,
                    TenBan = b.TenBan,
                    TrangThai = b.TrangThai,
                    GiaTheoGio = b.LoaiBan.GiaTheoGio,
                    //== "Trống" ? "Trống" : (b.TrangThai == "DangChoi" ? "Đang chơi" : "Bảo trì")
                })
                .ToList();
            return tables;
        }
        
        public BanBidaDTO LayChiTietBan(int maBan)
        {
            var table = db.BanBida
                .Where(b => b.MaBan == maBan)
                .Select(b => new BanBidaDTO
                {
                    MaBan = b.MaBan,
                    MaLoaiBan = b.MaLoaiBan,
                    TenBan = b.TenBan,
                    TrangThai = b.TrangThai,
                    GiaTheoGio = b.LoaiBan.GiaTheoGio
                })
                .FirstOrDefault();
            return table;
        }
        public decimal LayDonGiaTheoGio(int maLoaiBan)
        {
            var donGia = db.LoaiBan
                .Where(lb => lb.MaLoaiBan == maLoaiBan)
                .Select(lb => lb.GiaTheoGio)
                .FirstOrDefault();
            return donGia;
        }
    }
}
