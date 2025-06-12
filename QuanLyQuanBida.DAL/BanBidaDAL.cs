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
                    TenBan = b.TenBan,
                    TrangThai = b.TrangThai
                    //== "Trống" ? "Trống" : (b.TrangThai == "DangChoi" ? "Đang chơi" : "Bảo trì")
                })
                .ToList();
            return tables;
        }
    }
}
