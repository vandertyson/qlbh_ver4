using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApi
{
    public class QuanLyNhaCungCap
    {
        #region const
        public const string URL_SERVICE = @"http://localhost:32608/QLBanHang.asmx/";
        public const string URL_LAY_DANH_SACH_NHA_CUNG_CAP = URL_SERVICE + @"lay_danh_sach_nha_cung_cap";
        public const string URL_THEM_NHA_CUNG_CAP = URL_SERVICE + @"them_nha_cung_cap";
        public const string URL_SUA_NHA_CUNG_CAP = URL_SERVICE + @"sua_nha_cung_cap";
        public const string URL_XOA_NHA_CUNG_CAP = URL_SERVICE + @"xoa_nha_cung_cap";
        #endregion
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
        #region function
        public static void LayDanhSachNhaCungCap( Form f, MyNetwork.CompleteHandle<MyNetwork.TraVe<List<NhaCungCap>>> MyDelegate)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            MyNetwork.requestDataWithParam(param, URL_LAY_DANH_SACH_NHA_CUNG_CAP, f, MyDelegate);
        }

        public static void ThemNhaCungCap(NhaCungCap ncc, Form f, MyNetwork.CompleteHandle<MyNetwork.TraVe<string>> MyDelegate)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["ncc"] = JsonConvert.SerializeObject(ncc);
            MyNetwork.requestDataWithParam(param, URL_THEM_NHA_CUNG_CAP, f, MyDelegate);
        }

        public static void SuaNhaCungCap(NhaCungCap ncc, Form f, MyNetwork.CompleteHandle<MyNetwork.TraVe<string>> MyDelegate)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["ncc"] = JsonConvert.SerializeObject(ncc);
            MyNetwork.requestDataWithParam(param, URL_SUA_NHA_CUNG_CAP, f, MyDelegate);
        }

        public static void XoaNhaCungCap(decimal ncc, Form f, MyNetwork.CompleteHandle<MyNetwork.TraVe<string>> MyDelegate)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["id_ncc"] = ncc;
            MyNetwork.requestDataWithParam(param, URL_XOA_NHA_CUNG_CAP, f, MyDelegate);
        }
        #endregion
    }
}
