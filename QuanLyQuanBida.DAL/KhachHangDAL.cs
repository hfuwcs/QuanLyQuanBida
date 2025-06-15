using QuanLyQuanBida.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanBida;

namespace QuanLyQuanBida.DAL
{
    public class KhachHangDAL
    {
        private DB_QuanLyQuanBidaEntities db = new DB_QuanLyQuanBidaEntities();

        public List<KhachHangDTO> LayDanhSachKhachHangDayDu() 
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                return db.KhachHang
                    .Select(kh => new KhachHangDTO
                    {
                        MaKhachHang = kh.MaKhachHang,
                        HoTen = kh.HoTen,    
                        SoDienThoai = kh.SoDienThoai,  
                        DiemTichLuy = kh.DiemTichLuy, 
                        HangThanhVien = kh.HangThanhVien,
                        HoTenVaSDT = kh.HoTen + " - " + kh.SoDienThoai
                    })
                    .ToList();
            }
        }
        public string LayTenKhachHang(int maKhachHang)
        {
            return db.KhachHang
                .Where(kh => kh.MaKhachHang == maKhachHang)
                .Select(kh => kh.HoTen)
                .FirstOrDefault();
        }
        public List<KhachHangDTO> LayDanhSachKhachHangChoComboBox()
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                var khachHangs = db.KhachHang
                    .Select(kh => new KhachHangDTO
                    {
                        MaKhachHang = kh.MaKhachHang,
                        HoTenVaSDT = kh.HoTen + " - " + kh.SoDienThoai 
                    })
                    .ToList();
                return khachHangs;
            }
        }
        public KhachHangDTO LayThongTinKhachHang(int maKhachHang)
        {
            return db.KhachHang
                .Where(kh => kh.MaKhachHang == maKhachHang)
                .Select(kh => new KhachHangDTO
                {
                    MaKhachHang = kh.MaKhachHang,
                    HoTen = kh.HoTen,
                    SoDienThoai = kh.SoDienThoai,
                    DiemTichLuy = kh.DiemTichLuy,
                    HangThanhVien = kh.HangThanhVien
                })
                .FirstOrDefault();
        }
        public KhachHangDTO ThemKhachHang(KhachHangDTO khachHangMoiDTO)
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                var khachHangEntity = new KhachHang
                {
                    HoTen = khachHangMoiDTO.HoTen,
                    SoDienThoai = khachHangMoiDTO.SoDienThoai,
                    DiemTichLuy = khachHangMoiDTO.DiemTichLuy,
                    HangThanhVien = khachHangMoiDTO.HangThanhVien,
                    NgayTao = DateTime.Now
                };
                db.KhachHang.Add(khachHangEntity);
                db.SaveChanges();

                khachHangMoiDTO.MaKhachHang = khachHangEntity.MaKhachHang;

                return khachHangMoiDTO;
            }
        }

        public bool SuaKhachHang(KhachHangDTO khachHangCapNhatDTO)
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                var khachHangEntity = db.KhachHang.Find(khachHangCapNhatDTO.MaKhachHang);
                if (khachHangEntity == null) return false;

                khachHangEntity.HoTen = khachHangCapNhatDTO.HoTen;
                khachHangEntity.SoDienThoai = khachHangCapNhatDTO.SoDienThoai;
                khachHangEntity.DiemTichLuy = khachHangCapNhatDTO.DiemTichLuy;
                khachHangEntity.HangThanhVien = khachHangCapNhatDTO.HangThanhVien;

                db.Entry(khachHangEntity).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
        }

        public bool XoaKhachHang(int maKhachHang)
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                var khachHangEntity = db.KhachHang.Find(maKhachHang);
                if (khachHangEntity == null) return false;

                bool coHoaDon = db.HoaDon.Any(hd => hd.MaKhachHang == maKhachHang);
                if (coHoaDon)
                {
                    throw new InvalidOperationException("Khách hàng đã có hóa đơn, không thể xóa trực tiếp. Cân nhắc vô hiệu hóa khách hàng.");
                }

                db.KhachHang.Remove(khachHangEntity);
                db.SaveChanges();
                return true;
            }
        }
        public List<KhachHangDTO> LayDanhSachThanhVien(int pageNumber, int pageSize, string searchTerm)
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                var query = db.KhachHang
                              .Where(kh => kh.MaKhachHang != 3);

                if (!string.IsNullOrEmpty(searchTerm))
                {
                    query = query.Where(kh => kh.HoTen.Contains(searchTerm) || kh.SoDienThoai.Contains(searchTerm));
                }

                return query.OrderBy(kh => kh.HoTen)
                            .Skip((pageNumber - 1) * pageSize)
                            .Take(pageSize)
                            .Select(kh => new KhachHangDTO
                            {
                                MaKhachHang = kh.MaKhachHang,
                                HoTen = kh.HoTen,
                                SoDienThoai = kh.SoDienThoai,
                                DiemTichLuy = kh.DiemTichLuy,
                                HangThanhVien = kh.HangThanhVien,
                                HoTenVaSDT = kh.HoTen + " - " + kh.SoDienThoai
                            })
                            .ToList();
            }
        }
    }
}
