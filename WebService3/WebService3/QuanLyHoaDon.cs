using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace WebService3
{
    public class QuanLyHoaDon
    {
        #region Struct
        public class CuaHang
        {
            public string ten_cua_hang { get; set; }
            public string dia_chi { get; set; }
            public string so_dien_thoai { get; set; }
        }
        public class HangHoa
        {
            public decimal id_hang { get; set; }
            public string ma_hang_hoa { get; set; }
            public string ten_hang_hoa { get; set; }
            public decimal gia_hien_tai { get; set; }
        }
        public class SizeSoLuongHienTai
        {
            public string ten_size { get; set; }
            public int so_luong { get; set; }
        }
        public class KhuyenMaiDangApDung
        {
            public string ma_dot_khuyen_mai { get; set; }
            public string mo_ta { get; set; }
            public decimal muc_khuyen_mai { get; set; }
        }
        public class KhachHang
        {
            public decimal id_tai_khoan { get; set; }
            public string ten_khach_hang { get; set; }
            public string ten_tai_khoan { get; set; }
            public decimal diem_giam_tru { get; set; }
            public string ngay_gia_nhap { get; set; }
        }
        public class HoaDonChiTiet
        {
            public decimal gia_goc { get; set; }
            public string dot_khuyen_mai { get; set; }
            public decimal muc_khuyen_mai { get; set; }
            public string ma_hang { get; set; }
            public string ten_size { get; set; }
            public int so_luong { get; set; }
            public decimal gia_ban { get; set; }
        }
        public class HoaDon
        {
            public string ma_hoa_don { get; set; }
            public string thoi_gian_tao { get; set; }
            public string ten_cua_hang { get; set; }
            public string tai_khoan_tao { get; set; }
            public decimal id_khach_hang { get; set; }
            public string ten_khach_hang { get; set; }
            public string loai_thanh_toan { get; set; }
        }
        #endregion

        #region Function

        public static List<KhachHang> get_danh_sach_khach_hang(string ngay)
        {
            List<KhachHang> result = new List<KhachHang>();
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var n = Convert.ToDateTime(ngay);
                var list_khach = context.DM_KHACH_HANG.Where(s => s.NGAY_THAM_GIA <= n).ToList();
                foreach (var khach in list_khach)
                {
                    KhachHang cus = new KhachHang();
                    var acc = context.DM_TAI_KHOAN.Where(s => s.ID == khach.ID_TAI_KHOAN).First();
                    cus.ten_khach_hang = acc.HO_DEM + " " + acc.TEN;
                    cus.id_tai_khoan = acc.ID;
                    cus.ngay_gia_nhap = khach.NGAY_THAM_GIA.ToString();
                    cus.ten_tai_khoan = acc.TEN_TAI_KHOAN;
                    if (acc.ID != 67)
                    {
                        cus.diem_giam_tru = tinh_diem_giam_tru_cua_khac_hang(ngay, acc.ID);
                    }
                    result.Add(cus);
                }
                return result;
            }
        }

        private static decimal tinh_tong_tien_da_mua_cua_khach_hang(string ngay_hien_Tai, decimal? id_tai_khoan)
        {
            decimal result = 0;
            if (id_tai_khoan == null | id_tai_khoan == 67)
            {
                return 0;
            }
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var n = Convert.ToDateTime(ngay_hien_Tai);
                var hd = context.GD_HOA_DON.Where(s => s.ID_TAI_KHOAN == id_tai_khoan & s.THOI_GIAN_TAO < n).ToList();
                if (hd.Count == 0)
                {
                    return 0;
                }
                foreach (var item in hd)
                {
                    var ct = context.GD_HOA_DON_CHI_TIET.Where(s => s.ID_HOA_DON == item.ID).ToList();
                    foreach (var hdct in ct)
                    {
                        result += hdct.GIA_BAN * hdct.SO_LUONG;
                    }
                }
            }
            return result;
        }

        private static decimal tinh_diem_giam_tru_cua_khac_hang(string ngay_hien_Tai, decimal? id_tai_khoan)
        {
            if (id_tai_khoan == null | id_tai_khoan == 67)
            {
                return 0;
            }
            decimal result = 0;
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var tong_tien_da_mua = tinh_tong_tien_da_mua_cua_khach_hang(ngay_hien_Tai, id_tai_khoan);
                var n = Convert.ToDateTime(ngay_hien_Tai);
                var so_thang = context.DM_KHACH_HANG.Where(s => s.ID_TAI_KHOAN == id_tai_khoan).First().NGAY_THAM_GIA.Month - n.Month;
                result = Convert.ToInt32(tong_tien_da_mua / 1000);
            }
            return result;
        }

        public static List<HangHoa> get_danh_sach_hang_hien_tai(decimal id_cua_hang, string ngay_hien_tai)
        {
            List<HangHoa> result = new List<HangHoa>();
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var ds_hang = context.DM_HANG_HOA.Where(s => s.DA_XOA == "N").ToList();
                foreach (var hang in ds_hang)
                {
                    HangHoa sp = new HangHoa();
                    sp.id_hang = hang.ID;
                    sp.ten_hang_hoa = hang.TEN_HANG_HOA;
                    sp.ma_hang_hoa = hang.MA_TRA_CUU;
                    sp.gia_hien_tai = tinh_gia_san_pham_tai_thoi_diem(ngay_hien_tai, hang.ID);
                    result.Add(sp);
                }
            }
            return result;
        }

        public static decimal tinh_gia_san_pham_tai_thoi_diem(string ngay_hien_tai, decimal id_hang)
        {
            decimal result = 0;
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var p = context.GD_GIA.Where(s => s.ID_HANG_HOA == id_hang).ToList();
                if (p.Count == 0)
                {
                    var id_phieu_nhap = context.GD_PHIEU_NHAP_CHI_TIET.Where(s => s.ID_HANG_HOA == id_hang).Select(s => s.ID_PHIEU_NHAP_XUAT).ToList();
                    if (p.Count == 0)
                    {
                        return 0;
                    }
                    var cac_phieu = context.GD_PHIEU_NHAP_XUAT.Where(s => id_phieu_nhap.Contains(s.ID)).ToList();
                    var n = Convert.ToDateTime(ngay_hien_tai);
                    var cp = cac_phieu.Where(s => s.NGAY_NHAP <= n).OrderByDescending(s => s.NGAY_NHAP).First();
                    result = context.GD_PHIEU_NHAP_CHI_TIET.Where(s => s.ID_PHIEU_NHAP_XUAT == cp.ID & s.ID_HANG_HOA == id_hang).First().GIA_NHAP_BINH_QUAN;
                }
                else
                {
                    var n = Convert.ToDateTime(ngay_hien_tai);
                    var gia = context.GD_GIA.Where(s => s.ID_HANG_HOA == id_hang & s.NGAY_LUU_HANH <= n).OrderByDescending(s => s.NGAY_LUU_HANH).First();
                    result = gia.GIA;
                }
            }
            return result;
        }

        public static KhuyenMaiDangApDung get_khuyen_mai_cua_san_pham(string ngay_hien_tai, decimal id_hang)
        {
            KhuyenMaiDangApDung result = new KhuyenMaiDangApDung();
            KhuyenMaiDangApDung ko_km = new KhuyenMaiDangApDung();
            ko_km.ma_dot_khuyen_mai = "";
            ko_km.mo_ta = "Không áp dụng khuyến mãi";
            ko_km.muc_khuyen_mai = 0;
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var n = Convert.ToDateTime(ngay_hien_tai);
                var km = context.GD_KHUYEN_MAI.Where(s => s.THOI_GIAN_BAT_DAU <= n & n < s.THOI_GIAN_KET_THUC).FirstOrDefault();
                if (km != null)
                {
                    var kmct = context.GD_KHUYEN_MAI_CHI_TIET.Where(s => s.ID_KHUYEN_MAI == km.ID & s.ID_HANG_HOA == id_hang).FirstOrDefault();
                    if (kmct != null)
                    {
                        KhuyenMaiDangApDung km_ad = new KhuyenMaiDangApDung();
                        km_ad.ma_dot_khuyen_mai = km.MA_DOT;
                        km_ad.mo_ta = km.MO_TA;
                        km_ad.muc_khuyen_mai = kmct.MUC_KHUYEN_MAI;
                        result = km_ad;
                    }
                    else
                    {
                        result = ko_km;
                    }
                }
                else
                {
                    result = ko_km;
                }
            }
            return result;
        }

        public static List<SizeSoLuongHienTai> tinh_so_luong_ton_kho_hien_tai(decimal id_cua_hang, decimal id_hang, string ngay_hien_tai)
        {
            List<SizeSoLuongHienTai> result = new List<SizeSoLuongHienTai>();
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                foreach (var ten_size in new List<string> { "S", "M", "L", "XL", "XXL" })
                {
                    SizeSoLuongHienTai ssl = new SizeSoLuongHienTai();
                    ssl.ten_size = ten_size;

                    decimal id_size = context.GD_TAG.Where(s => s.TEN_TAG == ten_size).First().ID;

                    // tinh tong da nhap ve den thoi diem hien tai
                    decimal tong_nhap_ve = 0;
                    var n = Convert.ToDateTime(ngay_hien_tai);
                    var p1 = context.GD_PHIEU_NHAP_XUAT_CHI_TIET.Where(s => s.GD_PHIEU_NHAP_XUAT.NGAY_NHAP <= n && s.GD_PHIEU_NHAP_XUAT.ID_CUA_HANG == id_cua_hang
                                                        && s.ID_HANG_HOA == id_hang
                                                        && s.ID_SIZE == id_size).ToArray();
                    tong_nhap_ve = p1.Count() == 0 ? 0 : p1.Sum(s => s.SO_LUONG);

                    //tinh tong ban di den thoi diem hien tai
                    decimal tong_ban_di = 0;
                    var p2 = context.GD_HOA_DON_CHI_TIET.Where(s => s.GD_HOA_DON.THOI_GIAN_TAO < n
                                                                     && s.GD_HOA_DON.ID_CUA_HANG == id_cua_hang
                                                                     && s.ID_HANG_HOA == id_hang
                                                                     && s.ID_SIZE == id_size
                                                                    ).ToArray();
                    tong_ban_di = p2.Count() == 0 ? 0 : p2.Sum(s => s.SO_LUONG);
                    ssl.so_luong = Convert.ToInt32(tong_nhap_ve - tong_ban_di);
                    result.Add(ssl);
                }
            }
            return result;
        }

        public static void them_hoa_don(HoaDon hoa_don, List<HoaDonChiTiet> hoa_don_chi_tiet)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    using (var context = new TKHTQuanLyBanHangEntities())
                    {
                        //them hoa don
                        GD_HOA_DON hd = new GD_HOA_DON();
                        hd.ID_CUA_HANG = context.DM_CUA_HANG.Where(s => s.TEN_CUA_HANG == hoa_don.ten_cua_hang).First().ID;
                        hd.ID_TAI_KHOAN = hoa_don.id_khach_hang;
                        hd.THOI_GIAN_TAO = Convert.ToDateTime(hoa_don.thoi_gian_tao);
                        hd.MA_HOA_DON = hoa_don.ma_hoa_don;
                        hd.LOAI_THANH_TOAN = hoa_don.loai_thanh_toan;
                        hd.ID_TAI_KHOAN_TAO = context.DM_TAI_KHOAN.Where(s => s.TEN_TAI_KHOAN == hoa_don.tai_khoan_tao).First().ID;
                        context.GD_HOA_DON.Add(hd);
                        context.SaveChanges();
                        decimal id_hd = context.GD_HOA_DON.Where(s => s.MA_HOA_DON == hoa_don.ma_hoa_don).First().ID;

                        //them hoa don chi tiet
                        foreach (var chi_tiet in hoa_don_chi_tiet)
                        {
                            GD_HOA_DON_CHI_TIET ct = new GD_HOA_DON_CHI_TIET();
                            ct.ID_HOA_DON = id_hd;

                            var id_hang_hoa = context.DM_HANG_HOA.Where(s => s.MA_TRA_CUU == chi_tiet.ma_hang).First().ID;
                            var id_size = context.GD_TAG.Where(s => s.TEN_TAG == chi_tiet.ten_size).First().ID;

                            ct.ID_HANG_HOA = id_hang_hoa;
                            ct.ID_SIZE = id_size;
                            ct.SO_LUONG = chi_tiet.so_luong;
                            ct.GIA_BAN = chi_tiet.gia_ban;
                            ct.DA_THANH_TOAN = "Y";
                            context.GD_HOA_DON_CHI_TIET.Add(ct);
                            context.SaveChanges();
                        }
                        scope.Complete();
                    }
                }
                catch (Exception v_e)
                {
                    scope.Dispose();
                    throw v_e;
                }
            }
        }

        public static void sua_so_luong()
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    using (var context = new TKHTQuanLyBanHangEntities())
                    {
                        var p = context.GD_HOA_DON_CHI_TIET.ToList();
                        foreach (var item in p)
                        {

                            // tinh tong da nhap ve den thoi diem hien tai
                            decimal tong_nhap_ve = 0;
                            var n = Convert.ToDateTime(item.GD_HOA_DON.THOI_GIAN_TAO);
                            var ve = context.GD_PHIEU_NHAP_XUAT_CHI_TIET.Where(s => s.GD_PHIEU_NHAP_XUAT.NGAY_NHAP <= n && s.GD_PHIEU_NHAP_XUAT.ID_CUA_HANG == 1
                                                                && s.ID_HANG_HOA == item.ID_HANG_HOA
                                                                && s.ID_SIZE == item.ID_SIZE)
                                                                .ToArray();
                            tong_nhap_ve = ve.Count() == 0 ? 0 : ve.Sum(s => s.SO_LUONG);
                            //tinh tong ban di den thoi diem hien tai
                            decimal tong_ban_di = 0;
                            var di = context.GD_HOA_DON_CHI_TIET.Where(s => s.GD_HOA_DON.THOI_GIAN_TAO < n
                                                                             && s.GD_HOA_DON.ID_CUA_HANG == 1
                                                                             && s.ID_HANG_HOA == item.ID_HANG_HOA
                                                                             && s.ID_SIZE == item.ID_SIZE
                                                                            ).ToArray();
                            tong_ban_di = di.Count() == 0 ? 0 : di.Sum(s => s.SO_LUONG);
                            var so_luong = Convert.ToInt32(tong_nhap_ve - tong_ban_di);
                            if (item.SO_LUONG > so_luong)
                            {
                                context.GD_HOA_DON_CHI_TIET.Remove(item);
                                context.SaveChanges();
                            }

                        }
                        scope.Complete();
                    }
                }
                catch (Exception v_e)
                {
                    scope.Dispose();
                    throw v_e;
                }
            }
        }

        public static List<HoaDon> danh_sach_hoa_don(string ngay_hien_tai)
        {
            List<HoaDon> result = new List<HoaDon>();
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var list_hoa_don = new List<GD_HOA_DON>();
                if (ngay_hien_tai == null)
                {
                    list_hoa_don = context.GD_HOA_DON.ToList();
                }
                else
                {
                    var ngay = Convert.ToDateTime(ngay_hien_tai);
                    list_hoa_don = context.GD_HOA_DON.ToList().Where(s => s.THOI_GIAN_TAO.Date == ngay.Date).ToList();
                }
                foreach (var gdhd in list_hoa_don)
                {
                    HoaDon hd = new HoaDon();
                    hd.thoi_gian_tao = gdhd.THOI_GIAN_TAO.ToString();
                    hd.loai_thanh_toan = gdhd.LOAI_THANH_TOAN;
                    hd.ma_hoa_don = gdhd.MA_HOA_DON;

                    hd.ten_cua_hang = context.DM_CUA_HANG.Where(s => s.ID == gdhd.ID_CUA_HANG).First().TEN_CUA_HANG;
                    hd.tai_khoan_tao = context.DM_TAI_KHOAN.Where(s => s.ID == gdhd.ID_TAI_KHOAN_TAO).First().TEN_TAI_KHOAN;

                    hd.id_khach_hang = context.DM_TAI_KHOAN.Where(s => s.ID == gdhd.ID_TAI_KHOAN).First().ID;
                    hd.ten_khach_hang = context.DM_TAI_KHOAN.Where(s => s.ID == gdhd.ID_TAI_KHOAN).First().HO_DEM
                                            + " " + context.DM_TAI_KHOAN.Where(s => s.ID == gdhd.ID_TAI_KHOAN).First().TEN;
                    result.Add(hd);
                }
            }
            return result.OrderByDescending(s => s.ma_hoa_don).ToList();
        }

        public static List<HoaDonChiTiet> get_hoa_don_chi_tiet(string ma_hoa_don)
        {
            List<HoaDonChiTiet> resul = new List<HoaDonChiTiet>();
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var hd = context.GD_HOA_DON.Where(s => s.MA_HOA_DON == ma_hoa_don).First();
                var hdct = context.GD_HOA_DON_CHI_TIET.Where(s => s.ID_HOA_DON == hd.ID).ToList();
                foreach (var item in hdct)
                {
                    HoaDonChiTiet ct = new HoaDonChiTiet();
                    var hang = context.DM_HANG_HOA.Where(s => s.ID == item.ID_HANG_HOA).First();

                    ct.ma_hang = hang.MA_TRA_CUU;
                    ct.gia_ban = item.GIA_BAN;
                    ct.ten_size = context.GD_TAG.Where(s => s.ID == item.ID_SIZE).First().TEN_TAG;
                    ct.so_luong = Convert.ToInt16(item.SO_LUONG);

                    ct.gia_goc = tinh_gia_san_pham_tai_thoi_diem(hd.THOI_GIAN_TAO.ToString(), hang.ID);

                    var km = get_khuyen_mai_cua_san_pham(hd.THOI_GIAN_TAO.ToString(), hang.ID);
                    ct.muc_khuyen_mai = km.muc_khuyen_mai;
                    ct.dot_khuyen_mai = km.mo_ta;

                    resul.Add(ct);
                }
            }
            return resul;
        }

        private static decimal get_so_tien_giam_tru_km_cua_hoa_don(decimal iD_hoa_don)
        {
            decimal result = 0;
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var hoa_don = context.GD_HOA_DON.Where(s => s.ID == iD_hoa_don).First();
                var ngay_tao_hoa_don = hoa_don.THOI_GIAN_TAO.Date;
                var km = context.GD_KHUYEN_MAI.Where(s => s.THOI_GIAN_BAT_DAU <= ngay_tao_hoa_don & ngay_tao_hoa_don <= s.THOI_GIAN_KET_THUC).First();
                if (km == null)
                {
                    return result;
                }
                var hoa_don_ct = context.GD_HOA_DON_CHI_TIET.Where(s => s.ID_HOA_DON == hoa_don.ID).ToList();
                foreach (var ct in hoa_don_ct)
                {
                    var kmct = km.GD_KHUYEN_MAI_CHI_TIET.Where(s => s.ID_HANG_HOA == ct.ID_HANG_HOA).FirstOrDefault();
                    if (kmct == null)
                    {
                        continue;
                    }
                    var gia = context.GD_GIA.Where(s => s.ID_HANG_HOA == ct.ID_HANG_HOA & s.NGAY_LUU_HANH <= ngay_tao_hoa_don)
                                     .OrderByDescending(s => s.NGAY_LUU_HANH).First()
                                     .GIA;
                    var muc_km = kmct.MUC_KHUYEN_MAI;
                    result += ct.SO_LUONG * (gia - ct.GIA_BAN);
                }
            }
            return result;
        }

        public static string get_ma_hoa_don()
        {
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var last_hd = context.GD_HOA_DON.OrderByDescending(s => s.THOI_GIAN_TAO).First();
                if (last_hd == null)
                {
                    return "HD000001";
                }
                return Common.GenMa("HD", 6, last_hd.MA_HOA_DON);
            }
        }

        public static void xoa_hoa_don(string ma_hoa_don)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                   new System.TimeSpan(0, 15, 0)))
            {
                try
                {
                    using (var context = new TKHTQuanLyBanHangEntities())
                    {
                        var phieu = context.GD_HOA_DON.Where(s => s.MA_HOA_DON == ma_hoa_don).FirstOrDefault();

                        //xoa chi tiet
                        var ct = context.GD_HOA_DON_CHI_TIET.Where(s => s.ID_HOA_DON == phieu.ID).ToList();
                        foreach (var item in ct)
                        {
                            context.GD_HOA_DON_CHI_TIET.Remove(item);
                        }
                        context.SaveChanges();
                        context.GD_HOA_DON.Remove(phieu);
                        context.SaveChanges();
                        scope.Complete();
                    }
                }
                catch (Exception)
                {
                    scope.Dispose();
                    throw;
                }
            }
        }

        public static void sua_hoa_don(HoaDon hoa_don, List<HoaDonChiTiet> hdct)
        {
            using (var scope = new TransactionScope(TransactionScopeOption.Required,
                                  new System.TimeSpan(0, 15, 0)))
            {
                try
                {
                    using (var context = new TKHTQuanLyBanHangEntities())
                    {
                        var id_phieu_nhap_xuat = context.GD_HOA_DON.Where(s => s.MA_HOA_DON == hoa_don.ma_hoa_don).FirstOrDefault();
                        xoa_hoa_don(hoa_don.ma_hoa_don);
                        them_hoa_don(hoa_don, hdct);
                        context.SaveChanges();
                        scope.Complete();
                    }
                }
                catch (Exception)
                {
                    scope.Dispose();
                    throw;
                }
            }
        }


        #endregion
    }
}