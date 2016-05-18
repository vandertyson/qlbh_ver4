using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApi
{
    public class QuanLyGia
    {
        #region URL SERVICE
        //public const string URL_SERVICE = @"http://quanlybanhang.somee.com//QLBanHang.asmx/";
        public const string URL_SERVICE = @"http://localhost:32608/QLBanHang.asmx/";
        public const string URL_THEM_GIA_EXCEL = URL_SERVICE + @"ThemGiaExcel";
        private static string URL_LAY_TOAN_BO_GIA = URL_SERVICE + @"xem_toan_bo_gia";
        private static string URL_LAY_GIA_HIEN_TAI = URL_SERVICE + @"xem_gia_hien_tai";
        private static string URL_THEM_GIA_SAN_PHAM = URL_SERVICE + @"them_gia_1_san_pham";
        private static string URL_XOA_GD_GIA = URL_SERVICE + @"xoa_gd_gia";

        #endregion

        #region STRUCT- Chứa các cấu trúc dữ liệu ( public class )
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
            public DateTime ngay_ap_dung { get; set; }
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
            public DateTime ngay_ap_dung { get; set; }
        }
        #endregion

        public class GiaExcel
        {
            public string ma_tra_cuu { get; set; }
            public decimal gia_ban { get; set; }
            public string ngay_ap_dung { get; set; }
        }

        #endregion

        #region FUNCTION - Chứa các hàm lấy dữ liệu bằng request ( public static )

        public static void ThemGiaTuExcel(List<GiaExcel> list_gia, Form f, MyNetwork.CompleteHandle<MyNetwork.TraVe<string>> MyDelegate)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["ip_gia"] = JsonConvert.SerializeObject(list_gia);
            MyNetwork.requestDataWithParam(param, URL_THEM_GIA_EXCEL, f, MyDelegate);
        }

        public static void lay_toan_bo_gia( Form f, MyNetwork.CompleteHandle<MyNetwork.TraVe<List<BangGia>>> MyDelegate)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            MyNetwork.requestDataWithParam(param, URL_LAY_TOAN_BO_GIA, f, MyDelegate);
        }

        public static void lay_gia_hien_tai(Form f, MyNetwork.CompleteHandle<MyNetwork.TraVe<List<BangGia>>> MyDelegate)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            MyNetwork.requestDataWithParam(param, URL_LAY_GIA_HIEN_TAI, f, MyDelegate);
        }

        public static void them_gia_1_san_pham(string ma_tra_cuu, GiaSanPham g, Form f, MyNetwork.CompleteHandle<MyNetwork.TraVe<string>> MyDelegate)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["ma_tra_cuu"] = ma_tra_cuu;
            param["gia"] = JsonConvert.SerializeObject(g);
            MyNetwork.requestDataWithParam(param, URL_THEM_GIA_SAN_PHAM, f, MyDelegate);
        }

        public static void xoa_gd_gia(decimal id_gd_gia, Form f, MyNetwork.CompleteHandle<MyNetwork.TraVe<string>> MyDelegate)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["id_gd_gia"] = id_gd_gia;
            MyNetwork.requestDataWithParam(param, URL_XOA_GD_GIA, f, MyDelegate);
        }
        #endregion
    }
}
