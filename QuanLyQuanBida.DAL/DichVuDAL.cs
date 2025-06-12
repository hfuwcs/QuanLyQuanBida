﻿using QuanLyQuanBida.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanBida.DAL
{
    public class DichVuDAL
    {
        private DB_QuanLyQuanBidaEntities db = new DB_QuanLyQuanBidaEntities();

        public List<DichVuDTO> LayDanhSachDichVu(string category = "All")
        {
            var services = new List<DichVuDTO>() ?? null;

            try
            {
                if (string.IsNullOrEmpty(category) || category == "All")
                {
                    //Lấy hết
                    services = db.DichVu
                        .Join(
                            db.LoaiDichVu,
                            ldv => ldv.MaLoaiDV,
                            dv => dv.MaLoaiDV,
                            (dv,ldv) => new
                            {
                                dv.MaDichVu,
                                dv.TenDichVu,
                                dv.MaLoaiDV,
                                dv.DonViTinh,
                                dv.Gia,
                                ldv.TenLoaiDV
                            }
                        )
                        .Select(dv => new 
                        {
                            dv.MaDichVu,
                            dv.TenDichVu,
                            dv.MaLoaiDV,
                            dv.DonViTinh,
                            dv.TenLoaiDV,
                            dv.Gia
                        })
                        .ToList()
                        .Select(dv => new DichVuDTO
                        {
                            MaDichVu = dv.MaDichVu,
                            TenDichVu = dv.TenDichVu,
                            MaLoaiDV = dv.MaLoaiDV,
                            DonViTinh = dv.DonViTinh,
                            LoaiDichVu = dv.TenLoaiDV,
                            Gia = dv.Gia
                        })
                        .ToList();
                }
                else
                {
                    services = db.DichVu
                        .Join(
                            db.LoaiDichVu,
                            ldv => ldv.MaLoaiDV,
                            dv => dv.MaLoaiDV,
                            (dv, ldv) => new
                            {
                                dv.MaDichVu,
                                dv.TenDichVu,
                                dv.MaLoaiDV,
                                dv.DonViTinh,
                                dv.Gia,
                                ldv.TenLoaiDV
                            }
                        )
                        .Where(ldv => ldv.TenLoaiDV == category)
                        .Select(dv => new
                        {
                            dv.MaDichVu,
                            dv.TenDichVu,
                            dv.MaLoaiDV,
                            dv.DonViTinh,
                            dv.TenLoaiDV,
                            dv.Gia
                        })
                        .ToList()
                        .Select(dv => new DichVuDTO
                        {
                            MaDichVu = dv.MaDichVu,
                            TenDichVu = dv.TenDichVu,
                            MaLoaiDV = dv.MaLoaiDV,
                            DonViTinh = dv.DonViTinh,
                            LoaiDichVu = dv.TenLoaiDV,
                            Gia = dv.Gia
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching services: {ex.Message}");
                return new List<DichVuDTO>();
            }

            return services;
        }

    }
}
