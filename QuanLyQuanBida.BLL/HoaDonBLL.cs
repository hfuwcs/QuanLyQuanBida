using QuanLyQuanBida.DAL;
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

                // Tính tổng tiền dựa trên số phút đã được quy đổi
                decimal donGiaTheoPhut = donGiaTheoGio / 60;
                decimal tongTien = tongSoPhutTinhTien * donGiaTheoPhut;

                return Tuple.Create(tongSoPhutTinhTien, tongTien);
            }
        }

        public DateTime LayThoiGianBatDau(int maHoaDon)
        {
            return HoaDonDAL.LayThoiGianBatDau(maHoaDon);
        }
    }
}
