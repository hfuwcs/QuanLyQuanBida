using QuanLyQuanBida.DAL;
using QuanLyQuanBida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBida.BLL
{

    public class DichVuBLL
    {
        DichVuDAL dichVuDAL = new DichVuDAL();
        
        public List<DichVuDTO> LayDanhSachDichVu(string tenLoaiDichVu = "All")
        {
            return dichVuDAL.LayDanhSachDichVu(tenLoaiDichVu);
        }
        
        public DichVuDTO LayDichVuTheoID(int maDichVu = 1)
        {
            return dichVuDAL.LayDichVuTheoID(maDichVu);
        }
        public Tuple<string, decimal> LayTenVaGiaDichVu(int maDichVu = 1)
        {
            return dichVuDAL.LayTenVaGiaDichVu(maDichVu);
        }
        public string LayTenDichVu(int maDV)
        {
            return dichVuDAL.LayTenDichVu(maDV);
        }
    }
}
