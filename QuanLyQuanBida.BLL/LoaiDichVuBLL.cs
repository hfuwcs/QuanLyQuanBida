using QuanLyQuanBida.DAL;
using QuanLyQuanBida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBida.BLL
{
    public class LoaiDichVuBLL
    {
        private LoaiDichVuDAL loaiDichVuDAL = new LoaiDichVuDAL();
        public List<string> LayDanhSachLoaiDichVu()
        {
            return loaiDichVuDAL.LayDanhSachLoaiDichVu();
        }
        public List<string> LayDanhSachLoaiDichVuToComboBox()
        {
            return loaiDichVuDAL.LoadLoaiDichVuToComboBox();
        }
    }
}
