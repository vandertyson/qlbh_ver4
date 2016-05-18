using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using System.Web;

namespace WebService3
{
    public class QuanLyKhachHang
    {
        #region Struct
        public class TaiKhoan
        {
            public decimal id { get; set; }
            public string ten_tai_khoan { get; set; }
            public string mat_khau { get; set; }
            public string ho_dem { get; set; }
            public string ten { get; set; }
            public string email { get; set; }
            public decimal id_loai_tai_khoan { get; set; }
            public string lien_lac { get; set; }
            public string so_dien_thoai { get; set; }
            public string ngay_tham_gia { get; set; }
        }
        #endregion

        #region Function
        public static List<TaiKhoan> lay_danh_sach_khach_hang()
        {
            List<TaiKhoan> res = new List<TaiKhoan>();
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var t = context.DM_LOAI_TAI_KHOAN.Where(s => s.MA_LOAI == "CUSTOMER").First();
                var ds = context.DM_TAI_KHOAN.Where(s => s.ID_LOAI_TAI_KHOAN == t.ID).ToList();
                foreach (var item in ds)
                {
                    TaiKhoan tk = new TaiKhoan();
                    tk.id = item.ID;
                    tk.ten_tai_khoan = item.TEN_TAI_KHOAN;
                    tk.mat_khau = item.MAT_KHAU;
                    tk.ho_dem = item.HO_DEM;
                    tk.ten = item.TEN;
                    tk.email = item.EMAIL;
                    tk.id_loai_tai_khoan = item.ID;

                    var kh = context.DM_KHACH_HANG.Where(s => s.ID_TAI_KHOAN == item.ID).First();
                    tk.lien_lac = kh.LIEN_LAC;
                    tk.so_dien_thoai = kh.SO_DIEN_THOAI;
                    tk.ngay_tham_gia = kh.NGAY_THAM_GIA.ToString();
                    res.Add(tk);
                }
            }
            return res;
        }

        public static void them_1_khach_hang_moi(TaiKhoan tk)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    using (var context = new TKHTQuanLyBanHangEntities())
                    {
                        //them tai khoan
                        var t = context.DM_LOAI_TAI_KHOAN.Where(s => s.MA_LOAI == "CUSTOMER").First();
                        DM_TAI_KHOAN item = new DM_TAI_KHOAN();
                        item.TEN_TAI_KHOAN = tk.ten_tai_khoan;
                        item.MAT_KHAU = Common.md5("123");
                        item.HO_DEM = tk.ho_dem;
                        item.TEN = tk.ten;
                        item.EMAIL = tk.email;
                        item.ID_LOAI_TAI_KHOAN = t.ID;
                        context.DM_TAI_KHOAN.Add(item);
                        context.SaveChanges();

                        //them khach hang
                        var tkm = context.DM_TAI_KHOAN.Where(s => s.TEN_TAI_KHOAN == item.TEN_TAI_KHOAN).First();
                        DM_KHACH_HANG kh = new DM_KHACH_HANG();
                        kh.ID_TAI_KHOAN = tkm.ID;
                        kh.LIEN_LAC = tk.lien_lac;
                        kh.SO_DIEN_THOAI = tk.so_dien_thoai;
                        kh.NGAY_THAM_GIA = Convert.ToDateTime(tk.ngay_tham_gia);
                        kh.DIEM = 0;
                        kh.TONG_TIEN_DA_MUA = 0;
                        context.DM_KHACH_HANG.Add(kh);
                        context.SaveChanges();
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

        public static void sua_khach_hang(TaiKhoan tk)
        {
            using (var scope = new TransactionScope())
            {
                try
                {
                    using (var context = new TKHTQuanLyBanHangEntities())
                    {
                        //them tai khoan
                        var t = context.DM_LOAI_TAI_KHOAN.Where(s => s.MA_LOAI == "CUSTOMER").First();
                        var item = context.DM_TAI_KHOAN.Where(s => s.TEN_TAI_KHOAN == tk.ten_tai_khoan).First();
                        item.MAT_KHAU = tk.mat_khau;
                        item.HO_DEM = tk.ho_dem;
                        item.TEN = tk.ten;
                        item.EMAIL = tk.email;
                        item.ID_LOAI_TAI_KHOAN = t.ID;
                        context.SaveChanges();

                        //them khach hang
                        var tkm = context.DM_TAI_KHOAN.Where(s => s.TEN_TAI_KHOAN == item.TEN_TAI_KHOAN).First();
                        var kh = context.DM_KHACH_HANG.Where(s => s.ID_TAI_KHOAN == tkm.ID).First();
                        kh.LIEN_LAC = tk.lien_lac;
                        kh.SO_DIEN_THOAI = tk.so_dien_thoai;
                        kh.NGAY_THAM_GIA = Convert.ToDateTime(tk.ngay_tham_gia);
                        kh.DIEM = 0;
                        kh.TONG_TIEN_DA_MUA = 0;
                        context.SaveChanges();
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

        public static string xoa_khach_hang(decimal id_tai_khoan)
        {
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                try
                {
                    var t = context.DM_TAI_KHOAN.Where(s => s.ID == id_tai_khoan).First();
                    var k = context.DM_KHACH_HANG.Where(s => s.ID_TAI_KHOAN == id_tai_khoan).First();
                    context.DM_KHACH_HANG.Remove(k);
                    context.DM_TAI_KHOAN.Remove(t);
                    context.SaveChanges();
                    return "Đã xóa thành công";
                }
                catch (Exception ex)
                {
                    return "Không thể xóa do có đã có thông tin liên quan tới báo cáo";
                }
            }
        }
        #endregion
    }
}