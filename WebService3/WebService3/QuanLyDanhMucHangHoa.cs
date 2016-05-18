using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Transactions;
namespace WebService3
{
    public class QuanLyDanhMucHangHoa
    {
        #region Constant
        public const string DANH_MUC_SP = @"DANH_MUC_SAN_PHAM";
        public const string SIZE = @"SIZE_QUAN_AO";

        #endregion

        #region Struct
        #region Struct V1
        public class LoaiHang
        {
            public decimal id { get; set; }
            public string ma_tag { get; set; }
            public string ten_tag { get; set; }
            public string link_anh { get; set; }
        }
        public class ThemHangHoa
        {
            public decimal id { get; set; }
            public string ten_hang_hoa { get; set; }
            public string ma_tra_cuu { get; set; }
            public string ten_nha_cung_cap { get; set; }
            public string ma_nha_cung_cap { get; set; }
            public string mo_ta { get; set; }
            public List<string> link_anh { get; set; }
            public List<Tag> tag { get; set; }
            public string da_xoa { get; set; }
        }
        public class HangHoaMaster : ThemHangHoa
        {
            public string ma_hang_hoa { get; set; }
            public decimal gia { get; set; }
            public float do_giam_gia { get; set; }
            public int so_comment { get; set; }
            public decimal diem { get; set; }
            public int luot_click { get; set; }
        }
        public class Tag
        {
            public decimal id { get; set; }
            public string ten_tag { get; set; }
        }
        public class LoaiTag
        {
            public decimal id { get; set; }
            public string ma_loai_tag { get; set; }
            public string ten_loai_tag { get; set; }
            public List<Tag> ds_tag { get; set; }
        }
        public class HangHoa
        {
            public decimal id { get; set; }
            public string ma_hang_hoa { get; set; }
            public string ma_vach { get; set; }
            public string ten { get; set; }
            public string mo_ta { get; set; }
            public NhaCungCap nha_cung_cap { get; set; }
            public List<string> link_anh { get; set; }
            public List<Tag> ds_tag { get; set; }
            public decimal gia { get; set; }
            public decimal khuyen_mai { get; set; }
            public decimal luot_xem { get; set; }
            public decimal diem_danh_gia { get; set; }
            public List<NhanXet> nhan_xet { get; set; }
            public List<CuaHang> cua_hang { get; set; }
        }
        public class NhaCungCap
        {
            public decimal id { get; set; }
            public string ten { get; set; }
            public string ten_nguoi_dai_dien { get; set; }
            public string so_dien_thoai { get; set; }
            public string email { get; set; }
        }
        public class CuaHang
        {
            public decimal id { get; set; }
            public string ten_cua_hang { get; set; }
            public List<SoLuong> ton_kho { get; set; }
        }
        public class SoLuong
        {
            public decimal id_size { get; set; }
            public string ten_size { get; set; }
            public decimal so_luong { get; set; }
        }
        public class NhanXet
        {
            public decimal id { get; set; }
            public decimal id_tai_khoan { get; set; }
            public string ten_tai_khoan { get; set; }
            public string nhan_xet { get; set; }
            public DateTime thoi_gian { get; set; }
        }
        public class HoaDonMaster
        {
            public decimal id { get; set; }
            public DateTime ngay_mua { get; set; }
            public List<HoaDonSimple> hang_hoa { get; set; }
        }
        public class HoaDonSimple
        {
            public HangHoaMaster hang_hoa { get; set; }
            public decimal id_size { get; set; }
            public decimal so_luong { get; set; }
            public decimal gia_ban { get; set; }
        }
        public class HangHoaDaXem
        {
            public DateTime thoi_gian { get; set; }
            public HangHoaMaster hang_hoa { get; set; }
            public decimal so_click { get; set; }
        }
        public class CommentMaster
        {
            public HangHoaMaster hang_hoa { get; set; }
            public string comment { get; set; }
            public DateTime thoi_gian { get; set; }
        }
        public class PhieuNhapXuat
        {
            public decimal id { get; set; }
            public string ma_phieu { get; set; }
            public string loai_phieu { get; set; }
            public DateTime ngay_nhap_xuat { get; set; }
            public List<HoaDonSimple> thong_tin_chi_tiet { get; set; }
        }
        
        public class NhaCungCapV2
        {
            public string ma_nha_cung_cap { get; set; }
            public string ten_nha_cung_cap { get; set; }
            public string dia_chi { get; set; }
        }
        public class HangHoaVaMa
        {
            public string ten_hang_hoa { get; set; }
            public string ma_tra_cuu { get; set; }
        }
        #endregion

        #region Struct V2
        public class HangHoaV2
        {
            public decimal id { get; set; }
            public string ma_tra_cuu { get; set; }
            public string ten_hang_hoa { get; set; }
            public decimal id_nha_cung_cap { get; set; }
            public string ten_nha_cung_cap { get; set; }
            public string dang_kinh_doanh { get; set; }
            public string mo_ta { get; set; }
        }
        public class NhaCungCap3
        {
            public decimal id { get; set; }
            public string ten_nha_cung_cap { get; set; }
            public string ma_nha_cung_cap { get; set; }
        }
        public class TagV2
        {
            public decimal id { get; set; }
            public string ten_tag { get; set; }
        }
        public class LinkAnh
        {
            public decimal id { get; set; }
            public string link { get; set; }
        }
        #endregion
        #endregion

        #region Functions
        public static List<LoaiHang> DanhMucLoaiHang()
        {
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var idLoaiTag = context.DM_LOAI_TAG.Where(s => s.MA_LOAI_TAG == DANH_MUC_SP).First().ID;
                var listDs = new List<LoaiHang>();
                var dsLoaiHang = context.GD_LOAI_TAG_CHI_TIET.Where(s => s.ID_LOAI_TAG == idLoaiTag).ToList();
                foreach (var item in dsLoaiHang)
                {
                    var loaiHang = new LoaiHang();
                    loaiHang.id = item.ID;
                    loaiHang.ten_tag = item.GD_TAG.TEN_TAG;
                    loaiHang.link_anh = item.GD_TAG.LINK_ANH;
                    listDs.Add(loaiHang);
                }
                return listDs;
            }
        }

        public static object TimKiemHangHoa(string keyword, int length, int page,int level)
        {
            keyword = keyword.ToLower();

            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var listTag = context.GD_TAG.Where(s => keyword.Contains(s.TEN_TAG)).ToArray();

                var listHH = context.DM_HANG_HOA.ToArray();
                var listKey = keyword.Split(' ').ToList();
                var listID = new List<DM_HANG_HOA>();
                foreach (var hang in listHH)
                {
                    if (hang.MA_TRA_CUU.ToLower() == keyword)
                    {
                        listID.Add(hang);

                    }
                    else if (hang.MA_HANG_HOA.ToLower() == keyword)
                    {
                        listID.Add(hang);

                    }
                    else if (kiemTraNamTrong(listKey, hang.TEN_HANG_HOA.ToLower().Split(' ').ToList(), (a, b) =>
                               {
                                   return a == b;
                               }))
                    {
                        listID.Add(hang);

                    }
                    else
                    {
                        var lTag = hang.GD_HANG_HOA_TAG.Select(s => s.GD_TAG.TEN_TAG.ToLower());
                        string str = "";
                        foreach (var item in lTag)
                        {
                            str += item + " ";
                        }
                        bool co = true;
                        foreach (var item in listKey)
                        {
                            if (!str.Contains(item))
                            {
                                co = false;
                            }
                        }
                        if (co)
                        {
                            listID.Add(hang);
                        }
                    }
                }
                if (level==1)
                {
                    var ketQua = new List<HangHoaMaster>();
                    for (int i = length * page; i < length * page + length && i < listID.Count; i++)
                    {
                        ketQua.Add(toHangHoaMaster(listID[i]));
                    }
                    return ketQua;
                }
                else
                {
                    var ketQua = new List<ThemHangHoa>();
                    for (int i = length * page; i < length * page + length && i < listID.Count; i++)
                    {
                        ketQua.Add(toThemHangHoa(listID[i]));
                    }
                    return ketQua;
                }
            }
        }
        public static List<ThemHangHoa> DanhSachTatCaHangHoa()
        {
            using(var context = new TKHTQuanLyBanHangEntities())
            {
                var hangHoa = context.DM_HANG_HOA;
                var kq = new List<ThemHangHoa>();
                foreach (var item in hangHoa)
                {
                    kq.Add(toThemHangHoa(item));
                }
                return kq;
            }
        }

        delegate bool bangNhau<T>(T t1, T t2);

        static bool kiemTraNamTrong<T>(List<T> list1, List<T> list2, bangNhau<T> bangNhau)
        {
            for (int i = 0; i < list1.Count; i++)
            {
                bool boo = false;
                for (int j = 0; j < list2.Count; j++)
                {
                    if (bangNhau(list1[i], list2[j]))
                    {
                        boo = true;
                        break;
                    }
                }
                if (!boo)
                {
                    return false;
                }
            }
            return true;
        }

        static HangHoaMaster toHangHoaMaster(DM_HANG_HOA hh)
        {
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var hhMaster = new HangHoaMaster();
                var id = hh.ID;
                hhMaster.id = id;
                hhMaster.ma_hang_hoa = hh.MA_HANG_HOA;
                hhMaster.ten_hang_hoa = hh.TEN_HANG_HOA;
                hhMaster.ten_nha_cung_cap = hh.DM_NHA_CUNG_CAP.TEN_NHA_CUNG_CAP;
                hhMaster.ma_nha_cung_cap = hh.DM_NHA_CUNG_CAP.MA_NHA_CUNG_CAP;
                var listLink = new List<string>();
                var dsLink = context.DM_LINK_ANH.Where(s => s.ID_HANG_HOA == id).ToList();
                foreach (var link in dsLink)
                {
                    listLink.Add(link.LINK_ANH);
                }
                hhMaster.link_anh = listLink;
                var dsTag = context.GD_HANG_HOA_TAG.Where(s => s.ID_HANG_HOA == id).Select(s => s.GD_TAG);
                var listTag = new List<Tag>();
                foreach (var tag in dsTag)
                {
                    var t = new Tag();
                    t.id = tag.ID;
                    t.ten_tag = tag.TEN_TAG;
                    listTag.Add(t);
                }
                hhMaster.tag = listTag;
                var gia = layGia(context, id);
                hhMaster.gia = gia.Count == 0 ? 0 : gia[0];
                hhMaster.do_giam_gia = (float)(gia.Count < 2 ? 0 : 1 - gia[0] / gia[1]);
                var diem = hh.GD_DANH_GIA.Where(s => s.ID_HANG_HOA == id).ToArray();
                hhMaster.diem = diem.Count() > 0 ? diem.Average(s => s.DIEM) : 0;
                hhMaster.ma_tra_cuu = hh.MA_TRA_CUU;
                hhMaster.so_comment = hh.GD_NHAN_XET.Where(s => s.ID_HANG_HOA == id).Count();
                hhMaster.luot_click = hh.GD_CLICK_HANG_HOA.Where(s => s.ID_HANG_HOA == id).Count();
                hhMaster.da_xoa = hh.DA_XOA;
                return hhMaster;
            }
        }
        static ThemHangHoa toThemHangHoa(DM_HANG_HOA hh)
        {
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var hhMaster = new ThemHangHoa();
                var id = hh.ID;
                hhMaster.id = id;
                hhMaster.ten_hang_hoa = hh.TEN_HANG_HOA;
                hhMaster.ten_nha_cung_cap = hh.DM_NHA_CUNG_CAP.TEN_NHA_CUNG_CAP;
                hhMaster.ma_nha_cung_cap = hh.DM_NHA_CUNG_CAP.MA_NHA_CUNG_CAP;
                var listLink = new List<string>();
                var dsLink = context.DM_LINK_ANH.Where(s => s.ID_HANG_HOA == id).ToList();
                foreach (var link in dsLink)
                {
                    listLink.Add(link.LINK_ANH);
                }
                hhMaster.link_anh = listLink;
                var dsTag = context.GD_HANG_HOA_TAG.Where(s => s.ID_HANG_HOA == id).Select(s => s.GD_TAG);
                var listTag = new List<Tag>();
                foreach (var tag in dsTag)
                {
                    var t = new Tag();
                    t.id = tag.ID;
                    t.ten_tag = tag.TEN_TAG;
                    listTag.Add(t);
                }
                hhMaster.tag = listTag;
                hhMaster.ma_tra_cuu = hh.MA_TRA_CUU;
                hhMaster.da_xoa = hh.DA_XOA;
                return hhMaster;
            }
        }

        public static ThemHangHoa ChiTietHangHoa(decimal id_hang_hoa)
        {
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var hangHoa = context.DM_HANG_HOA.Where(s => s.ID == id_hang_hoa).FirstOrDefault();
                if(hangHoa == null)
                {
                    throw new Exception("Không có hàng hóa này");
                }
                var kq = new ThemHangHoa();
                kq.id = hangHoa.ID;
                kq.ten_hang_hoa = hangHoa.TEN_HANG_HOA;
                kq.ma_nha_cung_cap = hangHoa.DM_NHA_CUNG_CAP.MA_NHA_CUNG_CAP;
                kq.ten_nha_cung_cap = hangHoa.DM_NHA_CUNG_CAP.TEN_NHA_CUNG_CAP;
                kq.ma_tra_cuu = hangHoa.MA_TRA_CUU;
                kq.mo_ta = hangHoa.MO_TA;
                var dsTag = context.GD_HANG_HOA_TAG
                    .Where(s => s.ID_HANG_HOA == id_hang_hoa).Select(s => s.GD_TAG);
                kq.tag = new List<Tag>();
                foreach (var item in dsTag)
                {
                    var tag = new Tag();
                    tag.id = item.ID;
                    tag.ten_tag = item.TEN_TAG;
                    kq.tag.Add(tag);
                }
                var dsLink = context.DM_LINK_ANH.Where(s => s.ID_HANG_HOA == id_hang_hoa);
                kq.link_anh = new List<string>();
                foreach (var item in dsLink)
                {
                    kq.link_anh.Add(item.LINK_ANH);
                }
                return kq;
            }
        }
        public static void SuaHangHoa(ThemHangHoa hangHoa)
        {
            var scope = new TransactionScope();
            try
            {
                using (var context = new TKHTQuanLyBanHangEntities())
                {
                    var hang = context.DM_HANG_HOA.Where(s => s.ID == hangHoa.id).FirstOrDefault();
                    if (hang == null)
                    {
                        throw new Exception("Không có hàng hóa này");
                    }
                    hang.MA_TRA_CUU = hangHoa.ma_tra_cuu;
                    hang.TEN_HANG_HOA = hangHoa.ten_hang_hoa;
                    var ncc = context.DM_NHA_CUNG_CAP
                        .Where(s => s.MA_NHA_CUNG_CAP == hangHoa.ma_nha_cung_cap).FirstOrDefault();
                    if (ncc == null)
                    {
                        throw new Exception("Không có nhà cung cấp này");
                    }
                    hang.ID_NHA_CUNG_CAP = ncc.ID;
                    hang.MO_TA = hangHoa.mo_ta;
                    hang.DA_XOA = hangHoa.da_xoa;
                    var dsLink = context.DM_LINK_ANH.Where(s => s.ID_HANG_HOA == hang.ID).ToArray();
                    foreach (var item in dsLink)
                    {
                        bool co = false;
                        foreach (var item2 in hangHoa.link_anh)
                        {
                            if (item.LINK_ANH == item2)
                            {
                                co = true;
                                break;
                            }
                        }
                        if (!co)
                        {
                            context.DM_LINK_ANH.Remove(item);
                            context.SaveChanges();
                        }
                    }
                    dsLink = context.DM_LINK_ANH.Where(s => s.ID_HANG_HOA == hang.ID).ToArray();
                    foreach (var item in hangHoa.link_anh)
                    {
                        bool co = false;
                        foreach (var item2 in dsLink)
                        {
                            if (item2.LINK_ANH == item)
                            {
                                co = true;
                            }
                        }
                        if (!co)
                        {
                            var link = new DM_LINK_ANH();
                            link.ID_HANG_HOA = hang.ID;
                            link.LINK_ANH = item;
                            context.DM_LINK_ANH.Add(link);
                            context.SaveChanges();
                        }
                    }
                    var dsTag = context.GD_HANG_HOA_TAG
                        .Where(s => s.ID_HANG_HOA == hang.ID)
                        .Select(s=>s.GD_TAG)
                        .ToArray();
                    foreach (var item in dsTag)
                    {
                        bool co = false;
                        foreach (var item2 in hangHoa.tag)
                        {
                            if (item.TEN_TAG == item2.ten_tag)
                            {
                                co = true;
                                break;
                            }
                        }
                        if (!co)
                        {
                            context.GD_TAG.Remove(item);
                            context.SaveChanges();
                        }
                    }
                    dsTag = context.GD_HANG_HOA_TAG
                        .Where(s => s.ID_HANG_HOA == hang.ID)
                        .Select(s => s.GD_TAG)
                        .ToArray();
                    foreach (var item in hangHoa.tag)
                    {
                        bool co = false;
                        foreach (var item2 in dsTag)
                        {
                            if (item2.TEN_TAG == item.ten_tag)
                            {
                                co = true;
                            }
                        }
                        if (!co)
                        {
                            var old = context.GD_TAG.Where(s => s.TEN_TAG == item.ten_tag).FirstOrDefault();
                            if (old == null)
                            {
                                var tag = new GD_TAG();
                                tag.TEN_TAG = item.ten_tag;
                                context.GD_TAG.Add(tag);
                                context.SaveChanges();
                                var neww = context.GD_TAG
                                    .Where(s => s.TEN_TAG == item.ten_tag).FirstOrDefault();
                                var hht = new GD_HANG_HOA_TAG();
                                hht.ID_HANG_HOA = hang.ID;
                                hht.ID_TAG = neww.ID;
                                context.GD_HANG_HOA_TAG.Add(hht);
                                context.SaveChanges();
                            }
                            else
                            {
                                var hht = new GD_HANG_HOA_TAG();
                                hht.ID_HANG_HOA = hang.ID;
                                hht.ID_TAG = old.ID;
                                context.GD_HANG_HOA_TAG.Add(hht);
                                context.SaveChanges();
                            }
                        }
                    }
                    context.SaveChanges();
                    scope.Complete();
                    scope.Dispose();
                }
            }
            catch (Exception e)
            {
                scope.Dispose();
                throw;
            }
        }
        public static void XoaHangHoa(decimal id_hang_hoa)
        {
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var hangHoa = context.DM_HANG_HOA.Where(s => s.ID == id_hang_hoa).FirstOrDefault();
                if (hangHoa == null)
                {
                    throw new Exception("Không có hàng hóa này");
                }
                var dsLink = context.DM_LINK_ANH.Where(s => s.ID_HANG_HOA == id_hang_hoa);
                foreach (var item in dsLink)
                {
                    context.DM_LINK_ANH.Remove(item);
                }
                context.SaveChanges();
                var dsTag = context.GD_HANG_HOA_TAG.Where(s => s.ID_HANG_HOA == id_hang_hoa);
                foreach (var item in dsTag)
                {
                    context.GD_HANG_HOA_TAG.Remove(item);
                }
                context.SaveChanges();
                context.DM_HANG_HOA.Remove(hangHoa);
                context.SaveChanges();
            }
        }
        public static void ThemMoiHangHoa(ThemHangHoa hangHoa)
        {
            var scope = new TransactionScope();
            try
            {
                using(var context = new TKHTQuanLyBanHangEntities())
                {
                    var hang = new DM_HANG_HOA();
                    var ncc = context.DM_NHA_CUNG_CAP.Where(s => s.MA_NHA_CUNG_CAP == hangHoa.ma_nha_cung_cap).FirstOrDefault();
                    hang.ID_NHA_CUNG_CAP = ncc.ID;
                    var lastMa = context.DM_HANG_HOA.OrderByDescending(s => s.MA_HANG_HOA).First();
                    var ma = Common.GenMa("H", 6, lastMa.MA_HANG_HOA);
                    hang.MA_HANG_HOA = ma;
                    hang.MA_TRA_CUU = hangHoa.ma_tra_cuu;
                    hang.MO_TA = hangHoa.mo_ta;
                    hang.TEN_HANG_HOA = hangHoa.ten_hang_hoa;
                    hang.DA_XOA = "N";
                    context.DM_HANG_HOA.Add(hang);
                    context.SaveChanges();
                    var h = context.DM_HANG_HOA.Where(s => s.MA_HANG_HOA == ma).FirstOrDefault();
                    foreach (var item in hangHoa.link_anh)
                    {
                        var link = new DM_LINK_ANH();
                        link.ID_HANG_HOA = h.ID;
                        link.LINK_ANH = item;
                        context.DM_LINK_ANH.Add(link);
                    }
                    context.SaveChanges();
                    foreach (var item in hangHoa.tag)
                    {
                        var old = context.GD_TAG.Where(s => s.TEN_TAG == item.ten_tag).FirstOrDefault();
                        if (old==null)
                        {
                            var tag = new GD_TAG();
                            tag.TEN_TAG = item.ten_tag;
                            context.GD_TAG.Add(tag);
                            context.SaveChanges();
                            var ne = context.GD_TAG.Where(s => s.TEN_TAG == item.ten_tag).FirstOrDefault();
                            var hhTag = new GD_HANG_HOA_TAG();
                            hhTag.ID_HANG_HOA = h.ID;
                            hhTag.ID_TAG = ne.ID;
                            context.GD_HANG_HOA_TAG.Add(hhTag);
                            context.SaveChanges();
                        }
                        else
                        {
                            var hhTag = new GD_HANG_HOA_TAG();
                            hhTag.ID_HANG_HOA = h.ID;
                            hhTag.ID_TAG = old.ID;
                            context.GD_HANG_HOA_TAG.Add(hhTag);
                            context.SaveChanges();
                        }
                    }
                    scope.Complete();
                    scope.Dispose();
                }
            }
            catch (Exception e)
            {
                scope.Dispose();
                throw;
            }
        }
        internal static List<NhaCungCapV2> LayDanhSachNhaCungCap()
        {
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                List<NhaCungCapV2> rsul = new List<NhaCungCapV2>();
                var ncc = context.DM_NHA_CUNG_CAP.ToList();
                foreach (var item in ncc)
                {
                    NhaCungCapV2 cc = new NhaCungCapV2();
                    cc.dia_chi = item.DIA_CHI;
                    cc.ma_nha_cung_cap = item.MA_NHA_CUNG_CAP;
                    cc.ten_nha_cung_cap = item.TEN_NHA_CUNG_CAP;
                    rsul.Add(cc);
                }
                return rsul;
            }
        }

        public static List<decimal> layGia(TKHTQuanLyBanHangEntities context, decimal idHh)
        {
            var gia = context.GD_GIA.Where(s => s.ID_HANG_HOA == idHh)
                .OrderByDescending(s => s.NGAY_LUU_HANH)
                .Take(2)
                .Select(s => s.GIA)
                .ToList();
            return gia;
        }

        //public static void Test3(string keyword, decimal id_tag)
        //{
        //    using (var scope = new TransactionScope())
        //    {
        //        try
        //        {
        //            using (var context = new TKHTQuanLyBanHangEntities())
        //            {
        //                if (keyword == "namnu")
        //                {
        //                    var hh = context.DM_HANG_HOA.ToArray();
        //                    foreach (var item in hh)
        //                    {
        //                        if (item.ID < 45)
        //                        {
        //                            var hhtag = context.GD_HANG_HOA_TAG
        //                        .Where(s => s.ID_HANG_HOA == item.ID && s.ID_TAG == 2)
        //                        .FirstOrDefault();
        //                            if (hhtag == null)
        //                            {
        //                                var hangtag = new GD_HANG_HOA_TAG();
        //                                hangtag.ID_HANG_HOA = item.ID;
        //                                hangtag.ID_TAG = 2;
        //                                context.GD_HANG_HOA_TAG.Add(hangtag);
        //                            }
        //                        }
        //                        else
        //                        {
        //                            var hhtag = context.GD_HANG_HOA_TAG
        //                        .Where(s => s.ID_HANG_HOA == item.ID && s.ID_TAG == 1)
        //                        .FirstOrDefault();
        //                            if (hhtag == null)
        //                            {
        //                                var hangtag = new GD_HANG_HOA_TAG();
        //                                hangtag.ID_HANG_HOA = item.ID;
        //                                hangtag.ID_TAG = 1;
        //                                context.GD_HANG_HOA_TAG.Add(hangtag);
        //                            }
        //                        }
        //                    }
        //                    context.SaveChanges();
        //                    scope.Complete();
        //                    return;
        //                }
        //                var list = TimKiemHangHoa(keyword, 100, 0);
        //                foreach (var item in list)
        //                {
        //                    var hh = context.DM_HANG_HOA.Where(s => s.ID == item.id).First();
        //                    var hhtag = context.GD_HANG_HOA_TAG
        //                        .Where(s => s.ID_HANG_HOA == item.id && s.ID_TAG == id_tag)
        //                        .FirstOrDefault();
        //                    if (hhtag == null)
        //                    {
        //                        var hangtag = new GD_HANG_HOA_TAG();
        //                        hangtag.ID_HANG_HOA = item.id;
        //                        hangtag.ID_TAG = id_tag;
        //                        context.GD_HANG_HOA_TAG.Add(hangtag);
        //                    }
        //                }
        //                context.SaveChanges();
        //                scope.Complete();
        //            }

        //        }
        //        catch (Exception e)
        //        {
        //            scope.Dispose();
        //            throw;
        //        }
        //    }
        //}

        public static List<HangHoaVaMa> lay_danh_sach_hang_va_ma_tra_cuu()
        {
            List<HangHoaVaMa> result = new List<HangHoaVaMa>();
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var hanghoa = context.DM_HANG_HOA.Where(s => s.DA_XOA == "N").ToList();
                foreach (var item in hanghoa)
                {
                    var temp = new HangHoaVaMa();
                    temp.ma_tra_cuu = item.MA_TRA_CUU;
                    temp.ten_hang_hoa = item.TEN_HANG_HOA;
                    result.Add(temp);
                }
                return result;
            }
        }

        #region Function V2

        #region Truy Xuat
        public static List<HangHoaV2> lay_danh_muc_hang_hoa()
        {
            List<HangHoaV2> res = new List<HangHoaV2>();
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var ds = context.DM_HANG_HOA.ToList();
                foreach (var item in ds)
                {
                    HangHoaV2 h = new HangHoaV2();
                    h.id = item.ID;
                    h.ma_tra_cuu = item.MA_TRA_CUU;
                    h.ten_hang_hoa = item.TEN_HANG_HOA;
                    h.ten_nha_cung_cap = item.DM_NHA_CUNG_CAP.TEN_NHA_CUNG_CAP;
                    h.id_nha_cung_cap = item.DM_NHA_CUNG_CAP.ID;
                    h.dang_kinh_doanh = item.DA_XOA;
                    h.mo_ta = item.MO_TA;
                    res.Add(h);
                }
            }
            return res;
        }

        public static List<TagV2> lay_danh_sach_tag(decimal id_hang_hoa)
        {
            List<TagV2> res = new List<TagV2>();
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var ds = context.GD_HANG_HOA_TAG.Where(s => s.ID_HANG_HOA == id_hang_hoa).ToList();
                foreach (var item in ds)
                {
                    TagV2 t = new TagV2();
                    t.id = item.ID;
                    t.ten_tag = item.GD_TAG.TEN_TAG;
                    res.Add(t);
                }
            }
            return res;
        }

        public static List<LinkAnh> lay_link_anh(decimal id_hang_hoa)
        {
            List<LinkAnh> res = new List<LinkAnh>();
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var ds = context.DM_LINK_ANH.Where(s => s.ID_HANG_HOA == id_hang_hoa).ToList();
                foreach (var item in ds)
                {
                    LinkAnh l = new LinkAnh();
                    l.id = item.ID;
                    l.link = item.LINK_ANH;
                    res.Add(l);
                }
            }
            return res;
        }

        public static string lay_bai_viet(decimal id_hang_hoa)
        {
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                return context.DM_HANG_HOA.Where(s => s.ID == id_hang_hoa).First().MO_TA;
            }
        }
        #endregion

        #region Them sua xoa

        public static void them_hang_hoa_v2(HangHoaV2 hang)
        {
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                DM_HANG_HOA dm = new DM_HANG_HOA();
                //
                var last_ma = context.DM_HANG_HOA.OrderByDescending(s => s.ID).First().MA_HANG_HOA;
                var ma_moi = Common.GenMa("H", 6, last_ma);
                //
                dm.MA_HANG_HOA = ma_moi;
                dm.MA_TRA_CUU = hang.ma_tra_cuu;
                dm.TEN_HANG_HOA = hang.ten_hang_hoa;
                dm.ID_NHA_CUNG_CAP = hang.id_nha_cung_cap;
                dm.MO_TA = hang.mo_ta;
                dm.DA_XOA = "N";

                context.DM_HANG_HOA.Add(dm);
                context.SaveChanges();
            }
        }

        public static void sua_hang_hoa_v2(HangHoaV2 hang)
        {
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                var dm = context.DM_HANG_HOA.Where(s => s.ID == hang.id).First();
                //
                dm.MA_TRA_CUU = hang.ma_tra_cuu;
                dm.TEN_HANG_HOA = hang.ten_hang_hoa;
                dm.ID_NHA_CUNG_CAP = hang.id_nha_cung_cap;
                dm.MO_TA = hang.mo_ta;

                context.SaveChanges();
            }
        }

        public static string xoa_hang_hoa_v2(decimal id_hang)
        {
            string res = "";
            using (var context = new TKHTQuanLyBanHangEntities())
            {
                //hoa don chi tiet
                if (context.GD_HOA_DON_CHI_TIET.Select(s => s.ID_HANG_HOA).ToList().Contains(id_hang))
                {
                    res = "Không thể xóa do đã có thông tin trong hóa đơn";
                    return res;
                }
                //click
                if (context.GD_CLICK_HANG_HOA.Select(s => s.ID_HANG_HOA).ToList().Contains(id_hang))
                {
                    res = "Không thể xóa do liên quan tới lượt xem khách hàng";
                    return res;
                }
                //comment
                if (context.GD_NHAN_XET.Select(s => s.ID_HANG_HOA).ToList().Contains(id_hang))
                {
                    res = "Không thể xóa do đã liên quan tới nhận xét khách hàng";
                    return res;
                }
                //yeu thich
                if (context.GD_SAN_PHAM_UA_THICH.Select(s => s.ID_HANG_HOA).ToList().Contains(id_hang))
                {
                    res = "Không thể xóa do liên quan tới sở thích khách hàng";
                    return res;
                }
                //rating
                if (context.GD_DANH_GIA.Select(s => s.ID_HANG_HOA).ToList().Contains(id_hang))
                {
                    res = "Không thể xóa do đã có thông tin trong nhận xét khách hàng";
                    return res;
                }
                //phieu nhap chi tiet
                if (context.GD_PHIEU_NHAP_CHI_TIET.Select(s => s.ID_HANG_HOA).ToList().Contains(id_hang))
                {
                    res = "Không thể xóa do đã có thông tin phiếu nhập xuất";
                    return res;
                }
                //phieu nhap xuat chi tiet
                if (context.GD_PHIEU_NHAP_XUAT_CHI_TIET.Select(s => s.ID_HANG_HOA).ToList().Contains(id_hang))
                {
                    res = "Không thể xóa do đã có thông tin phiếu nhập";
                    return res;
                }
                //khuyen mai chi tiet
                if (context.GD_KHUYEN_MAI_CHI_TIET.Select(s => s.ID_HANG_HOA).ToList().Contains(id_hang))
                {
                    res = "Không thể xóa do đã có thông tin trong khuyến mãi";
                    return res;
                }
                //ton kho
                if (context.GD_TON_KHO.Select(s => s.ID_HANG_HOA).ToList().Contains(id_hang))
                {
                    res = "Không thể xóa do đã có thông tin trong tồn kho";
                    return res;
                }


                //link anh
                var l = context.DM_LINK_ANH.Where(s => s.ID_HANG_HOA == id_hang).ToList();
                foreach (var item in l)
                {
                    context.DM_LINK_ANH.Remove(item);
                }
                //tag
                var t = context.GD_HANG_HOA_TAG.Where(s => s.ID_HANG_HOA == id_hang).ToList();
                foreach (var item in t)
                {
                    context.GD_HANG_HOA_TAG.Remove(item);
                }
                //dm_hang_hoa
                var h = context.DM_HANG_HOA.Where(s => s.ID == id_hang).First();
                context.DM_HANG_HOA.Remove(h);

                //gd_gia
                var g = context.GD_GIA.Where(s => s.ID_HANG_HOA == id_hang).ToList();
                foreach (var item in g)
                {
                    context.GD_GIA.Remove(item);
                }

                context.SaveChanges();
                res = "Đã xóa hàng hóa thành công";
            }
            return res;
        }

        #endregion

        #endregion
        #endregion
    }
}