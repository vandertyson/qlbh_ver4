using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryApi
{
    public class QuanLyKhachHang
    {
        #region CONST SERVICE URL - Chứa địa chỉ service
        //public const string URL_SERVICE = @"http://quanlybanhang.somee.com//QLBanHang.asmx/";
        public const string URL_SERVICE = @"http://localhost:32608/QLBanHang.asmx/";
        public const string URL_DO_SOMETHING = URL_SERVICE + @"tên request";
        private static string URL_LAY_DANH_SACH_KHACH_HANG = URL_SERVICE + @"lay_danh_sach_khach_hang";
        private static string URL_THEM_MOT_KHACH_HANG = URL_SERVICE + @"them_1_khach_hang_moi";
        private static string URL_SUA_MOT_KHACH_HANG = URL_SERVICE + @"sua_khach_hang_kh";
        private static string URL_XOA_KHACH_HANG = URL_SERVICE + @"xoa_khach_hang";
        #endregion

        #region STRUCT- Chứa các cấu trúc dữ liệu ( public class )
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
            public DateTime ngay_tham_gia { get; set; }
        }
        #endregion

        #region FUNCTION - Chứa các hàm lấy dữ liệu bằng request ( public static )

        public static void lay_danh_sach_khach_hang(Form f, MyNetwork.CompleteHandle<MyNetwork.TraVe<List<TaiKhoan>>> MyDelegate)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            MyNetwork.requestDataWithParam(param, URL_LAY_DANH_SACH_KHACH_HANG, f, MyDelegate);
        }

        public static void them_1_khach_hang_moi(TaiKhoan ip_khach, Form f, MyNetwork.CompleteHandle<MyNetwork.TraVe<string>> MyDelegate)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["khach"] = JsonConvert.SerializeObject(ip_khach);
            MyNetwork.requestDataWithParam(param, URL_THEM_MOT_KHACH_HANG, f, MyDelegate);
        }

        public static void sua_khach_hang(TaiKhoan ip_khach, Form f, MyNetwork.CompleteHandle<MyNetwork.TraVe<string>> MyDelegate)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["khach"] = JsonConvert.SerializeObject(ip_khach);
            MyNetwork.requestDataWithParam(param, URL_SUA_MOT_KHACH_HANG, f, MyDelegate);
        }

        public static void xoa_khach_hang(decimal id_khach_hang, Form f, MyNetwork.CompleteHandle<MyNetwork.TraVe<string>> MyDelegate)
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["id_khach"] = id_khach_hang;
            MyNetwork.requestDataWithParam(param, URL_XOA_KHACH_HANG, f, MyDelegate);
        }

        #endregion
    }
}
