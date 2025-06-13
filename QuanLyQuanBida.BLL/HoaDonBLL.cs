using QuanLyQuanBida.DAL;
using QuanLyQuanBida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBida.BLL
{
    public class HoaDonBLL
    {
        HoaDonDAL HoaDonDAL = new HoaDonDAL();
        private BanBidaDAL banDal = new BanBidaDAL();
        public Tuple<int, decimal> TinhTienGio(DateTime thoiGianBatDau, DateTime thoiGianKetThuc, decimal donGiaTheoGio)
        {
            if (thoiGianKetThuc <= thoiGianBatDau || donGiaTheoGio <= 0)
            {
                return Tuple.Create(0, 0m); 
            }

            // Tính tổng số phút thực tế khách đã chơi
            double tongSoPhutThucTe = (thoiGianKetThuc - thoiGianBatDau).TotalMinutes;

            // Quy tắc 1: Nếu chơi từ 60 phút trở xuống, tính tròn 1 giờ
            if (tongSoPhutThucTe <= 60)
            {
                return Tuple.Create(60, donGiaTheoGio);
            }

            // Quy tắc 2: Nếu chơi trên 60 phút
            else
            {
                // Tách phần giờ đầu và số phút chơi thêm
                int phutGioDau = 60;
                double phutChoiThem = tongSoPhutThucTe - phutGioDau;

                // Quy định kích thước block (10 phút)
                const int kichThuocBlock = 10;

                // Tính số block cần tính tiền bằng cách làm tròn lên
                int soBlockTinhTien = (int)Math.Ceiling(phutChoiThem / kichThuocBlock);

                // Tổng số phút cuối cùng cần tính tiền
                int tongSoPhutTinhTien = phutGioDau + (soBlockTinhTien * kichThuocBlock);

                decimal donGiaTheoPhut = donGiaTheoGio / 60;
                decimal tongTien = tongSoPhutTinhTien * donGiaTheoPhut;

                return Tuple.Create(tongSoPhutTinhTien, tongTien);
            }
        }
        public List<DichVuDTO> LayChiTietDichVu(int maHoaDon)
        { 
            return HoaDonDAL.LayChiTietDichVu(maHoaDon);
        }
        public HoaDonDTO LayHoaDonHienTaiCuaBan(int maBan)
        {
            return HoaDonDAL.LayHoaDonChuaThanhToanTheoMaBan(maBan);
        }

        public int TaoHoaDon(int maKH, string tenKhach, int maBan)
        {
            if (maKH <= 0 || maBan <= 0 || string.IsNullOrEmpty(tenKhach))
            {
                throw new ArgumentException("Thông tin khách hàng hoặc bàn không hợp lệ.");
            }

            ///Coi bàn có xài được k
            var ban = banDal.LayChiTietBan(maBan);
            if (ban == null || ban.TrangThai != "Trống")
            {
                throw new InvalidOperationException("Bàn không trống hoặc không tồn tại.");
            }
            int maHoaDon = HoaDonDAL.TaoHoaDon(maKH, tenKhach, maBan);
            if(maHoaDon <= 0)
            {
                throw new Exception("Không thể tạo hóa đơn mới.");
            }
            // Cập nhật trạng thái bàn thành "Đang chơi"
            banDal.CapNhatTrangThaiBan(maBan, "Đang chơi");
            return HoaDonDAL.TaoHoaDon(maKH,tenKhach,maBan);
        }
        public decimal LayDonGiaTheoGio(int maLoaiBan)
        {
            return banDal.LayDonGiaTheoGio(maLoaiBan);
        }

        public DateTime LayThoiGianBatDau(int maHoaDon)
        {
            return HoaDonDAL.LayThoiGianBatDau(maHoaDon);
        }
    }
}
