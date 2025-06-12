using System;
using System.Collections.Generic;
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
    }
}
