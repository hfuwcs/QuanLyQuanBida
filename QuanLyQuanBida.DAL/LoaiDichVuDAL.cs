using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBida.DAL
{
    public class LoaiDichVuDAL
    {

        private DB_QuanLyQuanBidaEntities db = new DB_QuanLyQuanBidaEntities();

        public List<string> LayDanhSachLoaiDichVu()
        {
            return db.LoaiDichVu.Select(ldv => ldv.TenLoaiDV).ToList();
        }
        public List<string> LoadLoaiDichVuToComboBox()
        {
            var services = new List<string>() ?? null;
            try
            {
                services = db.LoaiDichVu
                    .Select(ldv => ldv.TenLoaiDV)
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading service categories: {ex.Message}");
                return new List<string>();
            }
            return services;
        }
    }
}
