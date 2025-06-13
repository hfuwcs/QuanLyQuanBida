using QuanLyQuanBida.DAL;
using QuanLyQuanBida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

public class LoaiDichVuDAL
{

    public List<string> LayDanhSachTenLoaiDichVu()
    {
        using (var db = new DB_QuanLyQuanBidaEntities())
        {
            try
            {
                return db.LoaiDichVu.Select(ldv => ldv.TenLoaiDV).ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading service categories names: {ex.Message}");
                return new List<string>();
            }
        }
    }

    // Lấy danh sách LoaiDichVuDTO (bao gồm cả Mã và Tên)
    public List<LoaiDichVuDTO> LayDanhSachLoaiDichVuDayDu()
    {
        using (var db = new DB_QuanLyQuanBidaEntities())
        {
            try
            {
                return db.LoaiDichVu
                    .Select(ldv => new LoaiDichVuDTO
                    {
                        MaLoaiDV = ldv.MaLoaiDV,
                        TenLoaiDV = ldv.TenLoaiDV
                    })
                    .ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading full service categories: {ex.Message}");
                return new List<LoaiDichVuDTO>();
            }
        }
    }


    public int? LayMaLoaiDichVuTheoTen(string tenLoaiDV)
    {
        if (string.IsNullOrEmpty(tenLoaiDV)) return null;
        using (var db = new DB_QuanLyQuanBidaEntities())
        {
            var loaiDV = db.LoaiDichVu.FirstOrDefault(ldv => ldv.TenLoaiDV == tenLoaiDV);
            return loaiDV?.MaLoaiDV;
        }
    }
}