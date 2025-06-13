using QuanLyQuanBida.DAL;
using QuanLyQuanBida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBida.BLL
{
    public class NhanVienBLL
    {
        private NhanVienDAL dal = new NhanVienDAL();

        public NhanVienDTO DangNhap(string tenDangNhap, string matKhau)
        {
            // Chưa cần hiện tại -  var matKhauMaHoa = MaHoaMatKhau(matKhau);
            var nhanVienEntity = dal.KiemTraDangNhap(tenDangNhap, matKhau);

            if (nhanVienEntity != null)
            {
                return new NhanVienDTO
                {
                    MaNhanVien = nhanVienEntity.MaNhanVien,
                    HoTen = nhanVienEntity.HoTen
                };
            }
            return null;
        }
    }
}