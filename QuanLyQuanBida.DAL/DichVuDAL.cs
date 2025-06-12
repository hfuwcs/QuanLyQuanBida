using QuanLyQuanBida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBida.DAL
{
    public class DichVuDAL
    {
        private DB_QuanLyQuanBidaEntities db = new DB_QuanLyQuanBidaEntities();

        public List<DichVuDTO> LayDanhSachDichVu(string category = "All")
        {
            var services = new List<Tuple<string, decimal>>() ?? null;

            try
            {
                if (string.IsNullOrEmpty(category) || category == "All")
                {
                    //Lấy hết
                    services = db.DichVu
                        .Select(dv => new { dv.TenDichVu, dv.Gia })
                        .ToList()
                        .Select(dv => Tuple.Create(dv.TenDichVu, dv.Gia))
                        .ToList();
                }
                else
                {
                    //Lấy theo loại dịch vụ
                    services = db.DichVu
                        .Where(dv => dv.LoaiDichVu.TenLoaiDV == category)
                        .Select(dv => new { dv.TenDichVu, dv.Gia })
                        .ToList()
                        .Select(dv => Tuple.Create(dv.TenDichVu, dv.Gia))
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching services: {ex.Message}");
                return new List<DichVuDTO>();
            }

            return services.Select(dv => new DichVuDTO
            {
                TenDichVu = dv.Item1,
                Gia = dv.Item2
            }).ToList();
        }

    }
}
