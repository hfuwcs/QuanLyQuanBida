using QuanLyQuanBida.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            var services = new List<DichVuDTO>() ?? null;

            try
            {
                if (string.IsNullOrEmpty(category) || category == "All")
                {
                    //Lấy hết
                    services = db.DichVu
                        .Join(
                            db.LoaiDichVu,
                            ldv => ldv.MaLoaiDV,
                            dv => dv.MaLoaiDV,
                            (dv,ldv) => new
                            {
                                dv.MaDichVu,
                                dv.TenDichVu,
                                dv.MaLoaiDV,
                                dv.DonViTinh,
                                dv.Gia,
                                ldv.TenLoaiDV
                            }
                        )
                        .Select(dv => new 
                        {
                            dv.MaDichVu,
                            dv.TenDichVu,
                            dv.MaLoaiDV,
                            dv.DonViTinh,
                            dv.TenLoaiDV,
                            dv.Gia
                        })
                        .ToList()
                        .Select(dv => new DichVuDTO
                        {
                            MaDichVu = dv.MaDichVu,
                            TenDichVu = dv.TenDichVu,
                            MaLoaiDV = dv.MaLoaiDV,
                            DonViTinh = dv.DonViTinh,
                            LoaiDichVu = dv.TenLoaiDV,
                            Gia = dv.Gia
                        })
                        .ToList();
                }
                else
                {
                    services = db.DichVu
                        .Join(
                            db.LoaiDichVu,
                            ldv => ldv.MaLoaiDV,
                            dv => dv.MaLoaiDV,
                            (dv, ldv) => new
                            {
                                dv.MaDichVu,
                                dv.TenDichVu,
                                dv.MaLoaiDV,
                                dv.DonViTinh,
                                dv.Gia,
                                ldv.TenLoaiDV
                            }
                        )
                        .Where(ldv => ldv.TenLoaiDV == category)
                        .Select(dv => new
                        {
                            dv.MaDichVu,
                            dv.TenDichVu,
                            dv.MaLoaiDV,
                            dv.DonViTinh,
                            dv.TenLoaiDV,
                            dv.Gia
                        })
                        .ToList()
                        .Select(dv => new DichVuDTO
                        {
                            MaDichVu = dv.MaDichVu,
                            TenDichVu = dv.TenDichVu,
                            MaLoaiDV = dv.MaLoaiDV,
                            DonViTinh = dv.DonViTinh,
                            LoaiDichVu = dv.TenLoaiDV,
                            Gia = dv.Gia
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching services: {ex.Message}");
                return new List<DichVuDTO>();
            }

            return services;
        }

        public DichVuDTO LayDichVuTheoID(int maDichVu = 1)
        {
            DichVuDTO dichVuDTO = db.DichVu 
            .Where(dv => dv.MaDichVu == maDichVu)
            .Select(dv => new DichVuDTO
            {
                MaDichVu = dv.MaDichVu,
                TenDichVu = dv.TenDichVu,
                MaLoaiDV = dv.MaLoaiDV,
                DonViTinh = dv.DonViTinh,
                LoaiDichVu = dv.LoaiDichVu.TenLoaiDV,
                Gia = dv.Gia
            })
            .FirstOrDefault();

            return dichVuDTO;
        }
        public Tuple<string, decimal> LayTenVaGiaDichVu(int maDichVu = 1)
        {
            DichVuDTO dichVu = LayDichVuTheoID(maDichVu);
            return Tuple.Create(dichVu.TenDichVu, dichVu.Gia);
        }
        public string LayTenDichVu(int maDV)
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                var dichVu = db.DichVu.FirstOrDefault(dv => dv.MaDichVu == maDV);
                return dichVu != null ? dichVu.TenDichVu : string.Empty;
            }
        }
        public DichVuDTO ThemDichVu(DichVuDTO dichVuMoiDTO)
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                // Mapping từ DTO sang Entity
                var dichVuEntity = new DichVu
                {
                    TenDichVu = dichVuMoiDTO.TenDichVu,
                    MaLoaiDV = dichVuMoiDTO.MaLoaiDV,
                    DonViTinh = dichVuMoiDTO.DonViTinh,
                    Gia = dichVuMoiDTO.Gia
                };

                db.DichVu.Add(dichVuEntity);
                db.SaveChanges();

                // Cập nhật lại DTO với MaDichVu mới được tạo (nếu DB tự tăng)
                // và nạp lại TenLoaiDV để hiển thị đúng
                dichVuMoiDTO.MaDichVu = dichVuEntity.MaDichVu;
                if (dichVuEntity.LoaiDichVu != null) // Nếu navigation property được load
                {
                    dichVuMoiDTO.LoaiDichVu = dichVuEntity.LoaiDichVu.TenLoaiDV;
                }
                else if (dichVuMoiDTO.MaLoaiDV.HasValue) // Hoặc query lại tên loại DV
                {
                    var loaiDV = db.LoaiDichVu.Find(dichVuMoiDTO.MaLoaiDV.Value);
                    if (loaiDV != null) dichVuMoiDTO.LoaiDichVu = loaiDV.TenLoaiDV;
                }
                return dichVuMoiDTO; // Trả về DTO đã được cập nhật MaDichVu
            }
        }

        public bool SuaDichVu(DichVuDTO dichVuCapNhatDTO)
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                var dichVuEntity = db.DichVu.Find(dichVuCapNhatDTO.MaDichVu);
                if (dichVuEntity == null) return false;

                dichVuEntity.TenDichVu = dichVuCapNhatDTO.TenDichVu;
                dichVuEntity.MaLoaiDV = dichVuCapNhatDTO.MaLoaiDV; // DTO phải có MaLoaiDV (int?)
                dichVuEntity.DonViTinh = dichVuCapNhatDTO.DonViTinh;
                dichVuEntity.Gia = dichVuCapNhatDTO.Gia;

                db.Entry(dichVuEntity).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
        }

        public bool XoaDichVu(int maDichVu)
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                var dichVuEntity = db.DichVu.Find(maDichVu);
                if (dichVuEntity == null) return false;

                // Kiểm tra xem dịch vụ có đang được sử dụng trong ChiTietHD không (QUAN TRỌNG)
                bool dangSuDung = db.ChiTietHoaDon.Any(cthd => cthd.MaDichVu == maDichVu);
                if (dangSuDung)
                {
                    // Không cho xóa nếu đang được sử dụng, hoặc bạn có thể implement soft delete
                    throw new InvalidOperationException("Dịch vụ đang được sử dụng trong hóa đơn, không thể xóa.");
                }

                db.DichVu.Remove(dichVuEntity);
                db.SaveChanges();
                return true;
            }
        }
    }
}
