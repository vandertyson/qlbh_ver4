﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace WebService3
{
    public class QuanLyGiaSanPham
    {
        #region Struct
        public class HangHoaVaGia
        {
            public decimal id_hang_hoa { get; set; }
            public string ten_hang_hoa { get; set; }
            public string ma_tra_cuu { get; set; }
            public string con_kinh_doanh { get; set; }
            public GiaSanPham gia_hien_tai { get; set; }
            public List<GiaSanPham> gia_cu { get; set; }

        }
        public class GiaSanPham
        {
            public decimal gia_tien { get; set; }
            public string ngay_ap_dung { get; set; }
        }
        public class ThemGiaExcel
        {
            public string ma_tra_cuu { get; set; }
            public decimal gia_ban { get; set; }
            public string ngay_ap_dung { get; set; }
        }

        #region v2
        public class BangGia
        {
            public decimal id_gd_gia { get; set; }
            public decimal id_hang_hoa { get; set; }
            public string ma_tra_cuu { get; set; }
            public string ten_hang_hoa { get; set; }
            public decimal gia { get; set; }
            public string ngay_ap_dung { get; set; }
        }
        #endregion
        #endregion

        #region Function
        public static List<HangHoaVaGia> get_bang_gia(string ngay_hien_tai)
        {
            List<HangHoaVaGia> result = new List<HangHoaVaGia>();
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var ds_hang = context.DM_HANG_HOA.ToList();
                foreach (var item in ds_hang)
                {
                    var p = new HangHoaVaGia();
                    p = get_gia_san_pham(ngay_hien_tai, item.ID);
                    result.Add(p);
                }
            }
            return result;
        }

        private static HangHoaVaGia get_gia_san_pham(string ngay_hien_tai, decimal id_hang)
        {
            HangHoaVaGia result = new HangHoaVaGia();
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var hang = context.DM_HANG_HOA.Where(s => s.ID == id_hang).First();
                result.id_hang_hoa = hang.ID;
                result.ten_hang_hoa = hang.TEN_HANG_HOA;
                result.ma_tra_cuu = hang.MA_TRA_CUU;
                result.con_kinh_doanh = hang.DA_XOA == "N" ? "Đang kinh doanh" : "Đã ngừng kinh doanh";

                var n = Convert.ToDateTime(ngay_hien_tai);
                var gia = context.GD_GIA.Where(s => s.NGAY_LUU_HANH <= n & s.ID_HANG_HOA == hang.ID).OrderByDescending(s => s.NGAY_LUU_HANH).ToList();
                result.gia_cu = new List<GiaSanPham>();
                foreach (var item in gia)
                {
                    GiaSanPham p = new GiaSanPham();
                    p.gia_tien = item.GIA * 1000;
                    p.ngay_ap_dung = item.NGAY_LUU_HANH.ToString();

                    if (gia.IndexOf(item) == 0)
                    {
                        result.gia_hien_tai = p;
                    }
                    else
                    {
                        result.gia_cu.Add(p);
                    }
                }
            }
            return result;
        }

        public static void them_gia(string ma_tra_cuu, GiaSanPham gia_moi)
        {
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var gia = new GD_GIA();
                gia.ID_HANG_HOA = context.DM_HANG_HOA.Where(s => s.MA_TRA_CUU == ma_tra_cuu).First().ID;
                gia.NGAY_LUU_HANH = Convert.ToDateTime(gia_moi.ngay_ap_dung);
                gia.GIA = gia_moi.gia_tien;
                context.GD_GIA.Add(gia);
                context.SaveChanges();
            }
        }

        public static void thay_doi_gia_exel(List<ThemGiaExcel> ip_list)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                   new System.TimeSpan(0, 15, 0)))
            {
                try
                {
                    foreach (var item in ip_list)
                    {
                        var gia = new GiaSanPham();
                        gia.gia_tien = item.gia_ban;
                        gia.ngay_ap_dung = item.ngay_ap_dung;
                        them_gia(item.ma_tra_cuu, gia);
                    }
                    scope.Complete();
                }
                catch (Exception)
                {
                    scope.Dispose();
                    throw;
                }
            }
        }

        public static List<BangGia> xem_toan_bo_gia()
        {
            List<BangGia> res = new List<BangGia>();
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var ds = context.GD_GIA.ToList();
                foreach (var item in ds)
                {
                    BangGia bg = new BangGia();
                    bg.id_gd_gia = item.ID;
                    bg.id_hang_hoa = item.ID_HANG_HOA;
                    bg.ma_tra_cuu = item.DM_HANG_HOA.MA_TRA_CUU;
                    bg.ten_hang_hoa = item.DM_HANG_HOA.TEN_HANG_HOA;
                    bg.gia = item.GIA;
                    bg.ngay_ap_dung = item.NGAY_LUU_HANH.ToString();
                    res.Add(bg);
                }
            }
            return res;
        }

        public static List<BangGia> xem_gia_hien_tai()
        {
            List<BangGia> res = new List<BangGia>();
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var ds = context.DM_HANG_HOA.ToList();
                foreach (var item in ds)
                {
                    BangGia bg = new BangGia();
                    bg.id_hang_hoa = item.ID;
                    bg.ma_tra_cuu = item.MA_TRA_CUU;
                    bg.ten_hang_hoa = item.TEN_HANG_HOA;

                    var gia = context.GD_GIA.Where(s => s.ID_HANG_HOA == item.ID).OrderByDescending(s => s.NGAY_LUU_HANH).FirstOrDefault();
                    if (gia == null)
                    {
                        bg.id_gd_gia = -1;
                        bg.gia = 0;
                        bg.ngay_ap_dung = DateTime.Now.ToString();
                    }
                    else
                    {
                        bg.id_gd_gia = gia.ID;
                        bg.gia = gia.GIA;
                        bg.ngay_ap_dung = gia.NGAY_LUU_HANH.ToString();
                    }
                    res.Add(bg);
                }
            }
            return res;
        }

        public static void xoa_gia(decimal id_gd_gia)
        {
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var g = context.GD_GIA.Where(s => s.ID == id_gd_gia).First();
                context.GD_GIA.Remove(g);
                context.SaveChanges(); 
            }
        }
        #endregion
    }
}