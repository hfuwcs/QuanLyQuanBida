using QuanLyQuanBida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBida.DAL
{
    public class ChiTietHoaDonDAL
    {
        public void ThemChiTietHoaDon(ChiTietHoaDon chiTietMoi)
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                db.ChiTietHoaDon.Add(chiTietMoi);
                db.SaveChanges();
            }
        }
        public ChiTietHoaDon ThemHoacCapNhatDichVu(int maHoaDon, int maDichVu, int soLuongMoi, decimal donGiaTaiThoiDiemGoi)
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                var chiTiet = db.ChiTietHoaDon.FirstOrDefault(cthd => cthd.MaHoaDon == maHoaDon && cthd.MaDichVu == maDichVu);

                if (chiTiet != null)
                {
                    if (soLuongMoi > 0)
                    {
                        chiTiet.SoLuong = soLuongMoi;
                    }
                    else
                    {
                        db.ChiTietHoaDon.Remove(chiTiet);
                        db.SaveChanges();
                        return null; // null = xóa
                    }
                }
                else // Dịch vụ mới cho hóa đơn này
                {
                    if (soLuongMoi > 0)
                    {
                        chiTiet = new ChiTietHoaDon
                        {
                            MaHoaDon = maHoaDon,
                            MaDichVu = maDichVu,
                            SoLuong = soLuongMoi,
                            DonGia = donGiaTaiThoiDiemGoi 
                        };
                        db.ChiTietHoaDon.Add(chiTiet);
                    }
                    else
                    {
                        return null; // Không thêm nếu số lượng <= 0
                    }
                }
                db.SaveChanges();
                return chiTiet; 
            }
        }

        public bool ThemDanhSachDichVuVaoHoaDon(int maHoaDon, List<ChiTietHoaDonDTO> danhSachDichVu)
        {
            if (danhSachDichVu == null || !danhSachDichVu.Any())
                return true;

            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                foreach (var dvChon in danhSachDichVu)
                {
                    var chiTiet = new ChiTietHoaDon
                    {
                        MaHoaDon = maHoaDon,
                        MaDichVu = dvChon.MaDichVu,
                        SoLuong = dvChon.SoLuong,
                        DonGia = dvChon.DonGia
                    };
                    db.ChiTietHoaDon.Add(chiTiet);
                }
                db.SaveChanges();
                return true;
            }
        }

        public List<ChiTietHoaDonDTO> LayChiTietDichVuTheoMaHD(int maHoaDon)
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {
                return db.ChiTietHoaDon
                    .Where(cthd => cthd.MaHoaDon == maHoaDon)
                    .Select(cthd => new ChiTietHoaDonDTO
                    {
                        MaCTHD = cthd.MaCTHD,
                        MaHoaDon = cthd.MaHoaDon,
                        MaDichVu = cthd.MaDichVu, 
                        SoLuong = cthd.SoLuong, 
                        DonGia = cthd.DonGia, 
                    }).ToList();
            }
        }

    }
}
