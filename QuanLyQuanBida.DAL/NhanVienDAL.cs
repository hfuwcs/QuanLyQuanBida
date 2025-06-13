using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBida.DAL
{
    public class NhanVienDAL
    {
        public NhanVien KiemTraDangNhap(string tenDangNhap, string matKhau)
        {
            using (var db = new DB_QuanLyQuanBidaEntities())
            {

                return db.NhanVien.FirstOrDefault(nv => nv.TenDangNhap == tenDangNhap && nv.MatKhau == matKhau);
            }
        }
    }
}
