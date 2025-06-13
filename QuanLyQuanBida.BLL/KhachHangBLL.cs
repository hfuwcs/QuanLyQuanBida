using QuanLyQuanBida.DAL;
using QuanLyQuanBida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBida.BLL
{
    namespace QuanLyQuanBida.BLL
    {
        public class KhachHangBLL
        {
            private KhachHangDAL khachHangDAL = new KhachHangDAL();

            public List<KhachHangDTO> LayDanhSachKhachHangDayDu()
            {
                return khachHangDAL.LayDanhSachKhachHangDayDu();
            }

            public List<KhachHangDTO> LayDanhSachKhachHangChoComboBox()
            {
                return khachHangDAL.LayDanhSachKhachHangChoComboBox();
            }


            public KhachHangDTO LayThongTinKhachHang(int maKhachHang)
            {
                return khachHangDAL.LayThongTinKhachHang(maKhachHang);
            }

            public KhachHangDTO ThemKhachHang(KhachHangDTO khachHangMoi)
            {
                if (string.IsNullOrWhiteSpace(khachHangMoi.HoTen))
                    throw new ArgumentException("Họ tên khách hàng không được để trống.");
                if (string.IsNullOrWhiteSpace(khachHangMoi.SoDienThoai))
                    throw new ArgumentException("Số điện thoại không được để trống.");

                var danhSachHienCo = khachHangDAL.LayDanhSachKhachHangDayDu();
                if (danhSachHienCo.Any(kh => kh.SoDienThoai == khachHangMoi.SoDienThoai))
                {
                    throw new InvalidOperationException($"Số điện thoại '{khachHangMoi.SoDienThoai}' đã tồn tại.");
                }

                khachHangMoi.HangThanhVien = XacDinhHangThanhVien(khachHangMoi.DiemTichLuy);

                return khachHangDAL.ThemKhachHang(khachHangMoi);
            }

            public bool SuaKhachHang(KhachHangDTO khachHangCapNhat)
            {
                if (khachHangCapNhat.MaKhachHang <= 0)
                    throw new ArgumentException("Mã khách hàng không hợp lệ.");
                if (string.IsNullOrWhiteSpace(khachHangCapNhat.HoTen))
                    throw new ArgumentException("Họ tên khách hàng không được để trống.");
                if (string.IsNullOrWhiteSpace(khachHangCapNhat.SoDienThoai))
                    throw new ArgumentException("Số điện thoại không được để trống.");

                var danhSachHienCo = khachHangDAL.LayDanhSachKhachHangDayDu();
                if (danhSachHienCo.Any(kh => kh.SoDienThoai == khachHangCapNhat.SoDienThoai && kh.MaKhachHang != khachHangCapNhat.MaKhachHang))
                {
                    throw new InvalidOperationException($"Số điện thoại '{khachHangCapNhat.SoDienThoai}' đã tồn tại cho khách hàng khác.");
                }

                khachHangCapNhat.HangThanhVien = XacDinhHangThanhVien(khachHangCapNhat.DiemTichLuy);
                return khachHangDAL.SuaKhachHang(khachHangCapNhat);
            }

            public bool XoaKhachHang(int maKhachHang)
            {
                if (maKhachHang <= 0)
                    throw new ArgumentException("Mã khách hàng không hợp lệ.");
                return khachHangDAL.XoaKhachHang(maKhachHang);
            }

            public string XacDinhHangThanhVien(int diem)
            {
                if (diem >= 1000) return "Kim Cương";
                if (diem >= 500) return "Vàng";
                if (diem >= 100) return "Bạc";
                return "Thân thiết";
            }
        }
    }
}
