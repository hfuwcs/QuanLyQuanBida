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
        public DichVuDTO ThemDichVu(DichVuDTO dichVuMoi)
        {
            if (string.IsNullOrWhiteSpace(dichVuMoi.TenDichVu))
                throw new ArgumentException("Tên dịch vụ không được để trống.");
            if (!dichVuMoi.MaLoaiDV.HasValue || dichVuMoi.MaLoaiDV.Value <= 0)
                throw new ArgumentException("Loại dịch vụ không hợp lệ.");
            if (dichVuMoi.Gia <= 0)
                throw new ArgumentException("Giá bán phải lớn hơn 0.");

            return dichVuDAL.ThemDichVu(dichVuMoi);
        }

        public bool SuaDichVu(DichVuDTO dichVuCapNhat)
        {
            if (dichVuCapNhat.MaDichVu <= 0)
                throw new ArgumentException("Mã dịch vụ không hợp lệ để cập nhật.");
            if (string.IsNullOrWhiteSpace(dichVuCapNhat.TenDichVu))
                throw new ArgumentException("Tên dịch vụ không được để trống.");
            if (!dichVuCapNhat.MaLoaiDV.HasValue || dichVuCapNhat.MaLoaiDV.Value <= 0)
                throw new ArgumentException("Loại dịch vụ không hợp lệ.");
            if (dichVuCapNhat.Gia <= 0)
                throw new ArgumentException("Giá bán phải lớn hơn 0.");
            return dichVuDAL.SuaDichVu(dichVuCapNhat);
        }

        public bool XoaDichVu(int maDichVu)
        {
            if (maDichVu <= 0)
                throw new ArgumentException("Mã dịch vụ không hợp lệ để xóa.");
            return dichVuDAL.XoaDichVu(maDichVu);
        }
    }
}
