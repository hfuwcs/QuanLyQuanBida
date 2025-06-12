using QuanLyQuanBida.DAL;
using QuanLyQuanBida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBida.BLL
{
    public class KhachHangBLL
    {
        KhachHangDAL khachHangDAL = new KhachHangDAL();
        public List<KhachHangDTO> LayDanhSachKhachHang()
        {
            return khachHangDAL.LayDanhSachKhachHang();
        }
    }
}
