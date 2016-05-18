﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using WebService3.Old;

namespace WebService3
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    [System.Web.Script.Services.ScriptService]
    public class QLBanHang : System.Web.Services.WebService
    {
        #region Dùng chung
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void SQLQueryRequest(string query)
        {
            try
            {
                var data = Function.SQLQuerry(query);
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void UploadFile(string binary, string file_name)
        {
            try
            {
                var data = Function.upLoadFile(binary, file_name);
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }

        void TraKetQua(KetQuaTraVe result)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(js.Serialize(result));
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void Test()
        {
            try
            {
                //QuanLyDanhMucHangHoa.Test3(key, id);
                QuanLyHoaDon.sua_so_luong();
                var result = new KetQuaTraVe(true, "Thành công", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }
        #endregion

        #region Quản lý danh mục hàng hóa

        #region Báo cáo chi tiết hàng hóa
        //[WebMethod]
        //[ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        //public void TinhTrangKinhDoanhMatHang(decimal id_hang_hoa, string thoi_gian_bat_dau, string thoi_gian_ket_thuc)
        //{
        //    try
        //    {
        //        var data = Function.tinh_trang_kinh_doanh(id_hang_hoa, thoi_gian_bat_dau, thoi_gian_ket_thuc);
        //        var result = new KetQuaTraVe(true, "Thành công", data);
        //        TraKetQua(result);
        //    }
        //    catch (Exception e)
        //    {
        //        var result = new KetQuaTraVe(false, "Thất bại", e.Message);
        //        TraKetQua(result);
        //    }
        //}
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void BaoCaoPhanHoiKhachHang(string bat_dau, int so_thang, decimal id_hang_hoa)
        {
            try
            {
                var data = BaoCaoChiTietHangHoa.bao_cao_phan_hoi_khach_hang(bat_dau, so_thang, id_hang_hoa);
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }
        //[WebMethod]
        //[ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        //public void TinhTrangKinhDoanhHangHoa(decimal id_hang_hoa, string bat_dau, string ket_thuc)
        //{
        //    try
        //    {
        //        var data = Function.ThongTinKinhDoanhHangHoa(id_hang_hoa, bat_dau, ket_thuc);
        //        var result = new KetQuaTraVe(true, "Thành công", data);
        //        TraKetQua(result);
        //    }
        //    catch (Exception e)
        //    {
        //        var result = new KetQuaTraVe(false, "Thất bại", e.Message);
        //        TraKetQua(result);
        //    }
        //}
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void BaoCaoChiTietKhuyenMai(decimal id_san_pham, string ngay_hien_tai)
        {
            try
            {
                var data = BaoCaoChiTietHangHoa.bao_cao_khuyen_mai_san_pham(id_san_pham, ngay_hien_tai);
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }
        #endregion

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void DanhSachLoaiHang()
        {
            try
            {
                var data = QuanLyDanhMucHangHoa.DanhMucLoaiHang();
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void TimKiemHangHoa(string keyword)
        {
            try
            {
                var page = Context.Request["page"];
                var length = Context.Request["length"];

                var data = QuanLyDanhMucHangHoa.TimKiemHangHoa(keyword,
                    length == null ? 20 : int.Parse(length),
                    page == null ? 0 : int.Parse(page));
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void DanhSachLoaiTag()
        {
            try
            {
                var data = Function.LayDanhSachTag();
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void ChiTietHangHoa(decimal id_hang_hoa)
        {
            try
            {
                var data = Function.ChiTietHangHoa(id_hang_hoa);
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void LayDanhSachHangHoaTheoLoaiHangHoa(decimal id_loai_hang_hoa)
        {
            try
            {
                //var data = Function.DanhSachHangHoa(id_loai_hang_hoa);
                //var result = new KetQuaTraVe(true, "Thành công", data);
                //TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }      
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void ThemHangHoa(string list_hang_hoa)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var listHangHoa = js.Deserialize<List<ThemHangHoa>>(list_hang_hoa);
                Function.ThemHangHoa(listHangHoa);
                var result = new KetQuaTraVe(true, "Thành công", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void LayDanhSachNhaCungCap()
        {
            var data = QuanLyDanhMucHangHoa.LayDanhSachNhaCungCap();
            var result = new KetQuaTraVe(true, "Thành công", data);
            TraKetQua(result);
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void LayHangHoaVaMaTraCuu()
        {
            try
            {
                var data = QuanLyDanhMucHangHoa.lay_danh_sach_hang_va_ma_tra_cuu();
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }
        #endregion

        #region Quản lý danh mục hàng hóa v2
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void lay_danh_sach_hang_hoa_v2()
        {
            try
            {
                var data = QuanLyDanhMucHangHoa.lay_danh_muc_hang_hoa();
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void them_hang_hoa_v2(string hang)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var hd = js.Deserialize<QuanLyDanhMucHangHoa.HangHoaV2>(hang);
                QuanLyDanhMucHangHoa.them_hang_hoa_v2(hd);
                var result = new KetQuaTraVe(true, "Thành công", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void sua_hang_hoa_v2(string hang)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var hd = js.Deserialize<QuanLyDanhMucHangHoa.HangHoaV2>(hang);
                QuanLyDanhMucHangHoa.sua_hang_hoa_v2(hd);
                var result = new KetQuaTraVe(true, "Thành công", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void xoa_hang_hoa_v2(decimal id_hang)
        {
            try
            {
                var data = QuanLyDanhMucHangHoa.xoa_hang_hoa_v2(id_hang);
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void lay_nha_cung_cap_v2()
        {
            try
            {
                var data = QuanLyDanhMucHangHoa.lay_nha_cung_cap_v2();
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }
        #endregion

        #region Quản lý tag hàng hóa
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void ThemTag(string ten_tag)
        {
            try
            {
                string link_anh = Context.Request["link_anh"];
                string ten_loai_tag = Context.Request["ten_loai_tag"];
                QuanLyTagHangHoa.ThemTagHangHoa(ten_tag, ten_loai_tag, link_anh);
                var result = new KetQuaTraVe(true, "Thành công", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GanTagHangHoa(string ten_tag,string ten_hang_hoa)
        {
            try
            {
                QuanLyTagHangHoa.GanTagHangHoa(ten_hang_hoa, ten_tag);
                var result = new KetQuaTraVe(true, "Thành công", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void LayDanhSachTag()
        {
            try
            {
                var data = QuanLyTagHangHoa.LayDanhSachTag();
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void LayDanhSachHangHoa()
        {
            try
            {
                var data = QuanLyTagHangHoa.LayDanhSachHangHoa();
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }
        #endregion

        #region Quản lý khuyến mại
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void ThemDotKhuyenMai(string ma_dot,string mo_ta,string tg_bd,string tg_kt)
        {
            try
            {

                QuanLyKhuyenMai.ThemDotKhuyenMai(ma_dot, mo_ta, tg_bd, tg_kt);
                var result = new KetQuaTraVe(true, "Thành công", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void ThemHangHoaKhuyenMai(string list_hang_hoa)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var listhanghoa = js.Deserialize<List<QuanLyKhuyenMai.KhuyenMai_HangHoa>>(list_hang_hoa);
                QuanLyKhuyenMai.ThemHangHoaKhuyenMai(listhanghoa);
                var result = new KetQuaTraVe(true, "Thành công", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void SuaMucKhuyenMai(string ma_hang_hoa, string ma_dot, decimal muc_km)
        {
            try
            {
                QuanLyKhuyenMai.SuaMucKhuyenMai(ma_hang_hoa, ma_dot, muc_km);
                var result = new KetQuaTraVe(true, "Thành công", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void LayThongTinKhuyenMai()
        {
            try
            {
                var data=QuanLyKhuyenMai.LayThongTinKhuyenMai();
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void GenMaKhuyenMai()
        {
            try
            {
                var data = QuanLyKhuyenMai.GenMaKhuyenMai();
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }
        
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void LayDanhSachHangKhuyenMaiTheoDot(string ma_dot)
        {
            try
            {
                var data = QuanLyKhuyenMai.LayDanhSachHangKhuyenMaiTheoDot(ma_dot);
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void XoaMatHangKhuyenMai(string ma_dot,string ma_hang)
        {
            try
            {
                var data = QuanLyKhuyenMai.XoaMatHangKhuyenMai(ma_dot,ma_hang);
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void SuaMatHangKhuyenMai(string ma_dot, string ma_hang, decimal muc_km)
        {
            try
            {
                QuanLyKhuyenMai.SuaMatHangKhuyenMai(ma_dot, ma_hang, muc_km);
                var result = new KetQuaTraVe(true, "Thành công", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void XoaDotKhuyenMai(string ma_dot)
        {
            try
            {
                var data = QuanLyKhuyenMai.XoaDotKhuyenMai(ma_dot);
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }
        
        #endregion

        #region Quản lý khách hàng
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void ChiTietThanhVien(decimal id_thanh_vien)
        {
            try
            {
                var data = Function.ChiTietThanhVien(id_thanh_vien);
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, "Thất bại", e.Message);
                TraKetQua(result);
            }
        }
        #endregion
       
        #region Quản lý phiếu nhập xuất
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void ThemPhieuNhapExcel(string list_phieu_nhap)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var listPhieu = js.Deserialize<List<QuanLyPhieuNhapXuat.PhieuNhap>>(list_phieu_nhap);
                QuanLyPhieuNhapXuat.ThemPhieuNhapXuat(listPhieu);
                var result = new KetQuaTraVe(true, "Thành công", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void XoaPhieuNhap(string ma_phieu)
        {
            try
            {
                QuanLyPhieuNhapXuat.xoa_phieu_nhap_xuat(ma_phieu);
                var result = new KetQuaTraVe(true, "Thành công", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void LayPhieuChiTiet(string ma_phieu)
        {
            try
            {
                var data = QuanLyPhieuNhapXuat.lay_phieu_nhap_chi_tiet(ma_phieu);
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void SuaPhieuNhap(string phieu)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var listPhieu = js.Deserialize<QuanLyPhieuNhapXuat.PhieuNhap>(phieu);
                QuanLyPhieuNhapXuat.sua_phieu_nhap_xuat(listPhieu);
                var result = new KetQuaTraVe(true, "Thành công", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void ThemMotPhieuNhap(string phieu)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var listPhieu = js.Deserialize<QuanLyPhieuNhapXuat.PhieuNhap>(phieu);
                QuanLyPhieuNhapXuat.ThemMotPhieuNhap(listPhieu);
                var result = new KetQuaTraVe(true, "Thành công", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void LayDanhSachPhieuNhap(string nbd, string nkt)
        {
            try
            {
                var data = QuanLyPhieuNhapXuat.lay_danh_sach_phieu_nhap(nbd,nkt);
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void LayMaPhieuMoi()
        {
            try
            {
                var data = QuanLyPhieuNhapXuat.lay_ma_phieu_nhap_moi();
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        #endregion

        #region Quản lý hóa đơn
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void LayDanhSachKhachHang(string ip_ngay_hien_tai)
        {
            try
            {
                var data = QuanLyHoaDon.get_danh_sach_khach_hang(ip_ngay_hien_tai);
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void LayDanhSachHangHoaByCuaHangAndNgay(decimal ip_id_cua_hang, string ip_ngay_hien_tai)
        {
            try
            {
                var data = QuanLyHoaDon.get_danh_sach_hang_hien_tai(ip_id_cua_hang, ip_ngay_hien_tai);
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void ThemHoaDon(string ip_hoa_don, string ip_hoa_don_chi_tiet)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var hd = js.Deserialize<QuanLyHoaDon.HoaDon>(ip_hoa_don);
                var hdct = js.Deserialize<List<QuanLyHoaDon.HoaDonChiTiet>>(ip_hoa_don_chi_tiet);
                QuanLyHoaDon.them_hoa_don(hd,hdct);
                var result = new KetQuaTraVe(true, "Thành công", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void LaySizeSoLuong(decimal id_cua_hang, string ngay_hien_tai, decimal id_hang)
        {
            try
            {
                var data = QuanLyHoaDon.tinh_so_luong_ton_kho_hien_tai(id_cua_hang, id_hang, ngay_hien_tai);
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void LayKhuyenMai(string ngay_hien_tai, decimal id_hang)
        {
            try
            {
                var data = QuanLyHoaDon.get_khuyen_mai_cua_san_pham(ngay_hien_tai, id_hang);
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void LayDanhSachHoaDon()
        {
            try
            {
                List<QuanLyHoaDon.HoaDon> data;
                var ngay_hien_tai = Context.Request["ngay_hien_tai"];
                if (ngay_hien_tai==null)
                {
                    data = QuanLyHoaDon.danh_sach_hoa_don(null);
                }
                else
                {
                    data = QuanLyHoaDon.danh_sach_hoa_don(ngay_hien_tai);
                }
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void LayHoaDonChiTiet(string ma_hoa_don)
        {
            try
            {
                var data = QuanLyHoaDon.get_hoa_don_chi_tiet(ma_hoa_don);
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void LayMaHoaDon()
        {
            try
            {
                var data = QuanLyHoaDon.get_ma_hoa_don();
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void XoaHoaDon(string ma_hoa_don)
        {
            try
            {
                QuanLyHoaDon.xoa_hoa_don(ma_hoa_don);
                var result = new KetQuaTraVe(true, "Thành công", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void SuaHoaDon(string ip_hoa_don, string ip_chi_tiet)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var hd = js.Deserialize<QuanLyHoaDon.HoaDon>(ip_hoa_don);
                var hdct = js.Deserialize<List<QuanLyHoaDon.HoaDonChiTiet>>(ip_chi_tiet);
                QuanLyHoaDon.sua_hoa_don(hd,hdct);
                var result = new KetQuaTraVe(true, "Thành công", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        #endregion

        #region Quản lý giá hàng hóa
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void LayBangGia(string ip_ngay_hien_tai)
        {
            try
            {
                var data = QuanLyGiaSanPham.get_bang_gia(ip_ngay_hien_tai);
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void ThemGiaExcel(string ip_gia)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var hd = js.Deserialize<List<QuanLyGiaSanPham.ThemGiaExcel>>(ip_gia);
                QuanLyGiaSanPham.thay_doi_gia_exel(hd);
                var result = new KetQuaTraVe(true, "Thành công", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void xem_toan_bo_gia()
        {
            try
            {
                var data = QuanLyGiaSanPham.xem_toan_bo_gia();
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void xem_gia_hien_tai()
        {
            try
            {
                var data = QuanLyGiaSanPham.xem_gia_hien_tai();
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void xoa_gd_gia(decimal id_gd_gia)
        {
            try
            {
                QuanLyGiaSanPham.xoa_gia(id_gd_gia);
                var result = new KetQuaTraVe(true, "Thành công", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void them_gia_1_san_pham(string ma_tra_cuu, string gia)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var hd = js.Deserialize<QuanLyGiaSanPham.GiaSanPham>(gia);
                QuanLyGiaSanPham.them_gia(ma_tra_cuu, hd);
                var result = new KetQuaTraVe(true, "Thành công", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }
        #endregion

        #region Báo cáo kinh doanh
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void LayDoanhThuDoanhSoTheoThang(string thang_bd, string thang_kt)
        {
            try
            {
                var data = BaoCaoKinhDoanh.get_doanh_thu_doanh_so_theo_thang(thang_bd, thang_kt);
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }
        #endregion

        #region Quản lý nhà cung cấp
        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void lay_danh_sach_nha_cung_cap()
        {
            try
            {
                var data = QuanLyNhaCungCap.lay_danh_sach_nha_cung_cap();
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void them_nha_cung_cap(string ncc)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var hd = js.Deserialize<QuanLyNhaCungCap.NhaCungCap>(ncc);
                QuanLyNhaCungCap.them_nha_cung_cap(hd);
                var result = new KetQuaTraVe(true, "Thành công", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void sua_nha_cung_cap(string ncc)
        {
            try
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                var hd = js.Deserialize<QuanLyNhaCungCap.NhaCungCap>(ncc);
                QuanLyNhaCungCap.sua_nha_cung_cap(hd);
                var result = new KetQuaTraVe(true, "Thành công", null);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }

        [WebMethod]
        [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
        public void xoa_nha_cung_cap(decimal id_ncc)
        {
            try
            {
                var data = QuanLyNhaCungCap.xoa_nha_cung_cap(id_ncc);
                var result = new KetQuaTraVe(true, "Thành công", data);
                TraKetQua(result);
            }
            catch (Exception e)
            {
                var result = new KetQuaTraVe(false, e.Message, null);
                TraKetQua(result);
            }
        }
        #endregion
    }
}
