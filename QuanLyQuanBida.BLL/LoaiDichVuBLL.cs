using QuanLyQuanBida.DTO; // Thêm
using System.Collections.Generic;
// ... other usings

public class LoaiDichVuBLL
{
    private LoaiDichVuDAL loaiDichVuDAL = new LoaiDichVuDAL();

    public List<string> LayDanhSachTenLoaiDichVu() 
    {
        return loaiDichVuDAL.LayDanhSachTenLoaiDichVu();
    }

    public List<LoaiDichVuDTO> LayDanhSachLoaiDichVuDayDu()
    {
        return loaiDichVuDAL.LayDanhSachLoaiDichVuDayDu();
    }

    public int? LayMaLoaiDichVuTheoTen(string tenLoaiDV)
    {
        return loaiDichVuDAL.LayMaLoaiDichVuTheoTen(tenLoaiDV);
    }
}