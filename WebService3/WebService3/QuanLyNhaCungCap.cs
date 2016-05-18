using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService3
{
    public class QuanLyNhaCungCap
    {
        #region Struct
        public class NhaCungCap
        {
            public decimal id { get; set; }
            public string ma_nha_cung_cap { get; set; }
            public string ten_nha_cung_cap { get; set; }
            public string so_dien_thoai { get; set; }
            public string email { get; set; }
            public string dia_chi { get; set; }
            public string ten_nguoi_dai_dien { get; set; }
        }
        #endregion

        #region Function
        public static List<NhaCungCap> lay_danh_sach_nha_cung_cap()
        {
            List<NhaCungCap> res = new List<NhaCungCap>();
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var ds = context.DM_NHA_CUNG_CAP.ToList();
                foreach (var item in ds)
                {
                    NhaCungCap n = new NhaCungCap();
                    n.id = item.ID;
                    n.ma_nha_cung_cap = item.MA_NHA_CUNG_CAP;
                    n.ten_nha_cung_cap = item.TEN_NHA_CUNG_CAP;
                    n.so_dien_thoai = item.SO_DIEN_THOAI;
                    n.email = item.EMAIL;
                    n.dia_chi = item.DIA_CHI;
                    n.ten_nguoi_dai_dien = item.TEN_NGUOI_DAI_DIEN;
                    res.Add(n);
                }
            }
            return res;
        }

        public static void them_nha_cung_cap(NhaCungCap ncc)
        {
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                DM_NHA_CUNG_CAP dm = new DM_NHA_CUNG_CAP();
                dm.MA_NHA_CUNG_CAP = ncc.ma_nha_cung_cap;
                dm.TEN_NHA_CUNG_CAP = ncc.ten_nha_cung_cap;
                dm.EMAIL = ncc.email;
                dm.DIA_CHI = ncc.dia_chi;
                dm.SO_DIEN_THOAI = ncc.so_dien_thoai;
                dm.TEN_NGUOI_DAI_DIEN = ncc.ten_nguoi_dai_dien;
                context.DM_NHA_CUNG_CAP.Add(dm);
                context.SaveChanges();
            }
        }

        public static void sua_nha_cung_cap(NhaCungCap ncc)
        {
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var dm = context.DM_NHA_CUNG_CAP.Where(s=>s.ID == ncc.id).First();

                dm.MA_NHA_CUNG_CAP = ncc.ma_nha_cung_cap;
                dm.TEN_NHA_CUNG_CAP = ncc.ten_nha_cung_cap;
                dm.EMAIL = ncc.email;
                dm.DIA_CHI = ncc.dia_chi;
                dm.SO_DIEN_THOAI = ncc.so_dien_thoai;
                dm.TEN_NGUOI_DAI_DIEN = ncc.ten_nguoi_dai_dien;

                context.SaveChanges();
            }
        }

        public static string xoa_nha_cung_cap(decimal id_nha_cung_cap)
        {
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var ds = context.DM_HANG_HOA.Where(s => s.ID_NHA_CUNG_CAP == id_nha_cung_cap).FirstOrDefault();
                if (ds == null)
                {
                    var ncc = context.DM_NHA_CUNG_CAP.Where(s => s.ID == id_nha_cung_cap).First();
                    context.DM_NHA_CUNG_CAP.Remove(ncc);
                    context.SaveChanges();
                    return "Đã xóa thành công";
                }
                return "Không thể xóa do có thông tin liên quan tới hàng hóa";
            }
        }
        #endregion
    }
}