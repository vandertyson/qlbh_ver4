﻿using DevExpress.XtraEditors;
using LinqToExcel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LibraryApi.QuanLyPhieuNhapXuat;
using QLBH.Common;

namespace QLBH.Forms
{
    public partial class f15_phieu_nhap_chi_tiet : Form
    {
        #region Public Interfaces
        public f15_phieu_nhap_chi_tiet()
        {
            InitializeComponent();
            this.CenterToScreen();
            set_define_event();
            m_dt_data_source = CommonFunction.create_table_form_struct(typeof(MotPhieuNhapExcel));
        }

        public void display_chi_tiet(PhieuNhap p)
        {
            m_e_mode = Mode.XemChiTiet;
            m_phieu_nhap = p;
            m_ma_phieu = p.ma_phieu;
            this.ShowDialog();
        }

        public void display_update(PhieuNhap p)
        {
            m_e_mode = Mode.Sua;
            m_phieu_nhap = p;
            m_ma_phieu = p.ma_phieu;
            this.ShowDialog();
        }

        public void display_them_moi()
        {
            m_e_mode = Mode.ThemMoi;
            this.ShowDialog();
           
        }
        #endregion

        #region Data Stucture
        enum Mode
        {
            XemChiTiet,
            Sua,
            ThemMoi
        }
        #endregion

        #region Member
        private string m_file_name;
        public List<MotPhieuNhapExcel> data_from_excel { get; private set; }
        private DataTable m_dt_data_source { get; set; }

        private PhieuNhap m_phieu_nhap = new PhieuNhap();
        private List<HangHoa> m_list_chi_tiet { get; set; }
        private string m_ma_phieu { get; set; }

        private Mode m_e_mode;
        #endregion

        #region Private Methods

        private void load_data_to_grid()
        {
            List<MotPhieuNhapExcel> result = new List<MotPhieuNhapExcel>();
            foreach (var item in m_list_chi_tiet)
            {
                MotPhieuNhapExcel dong = new MotPhieuNhapExcel();
                dong.ma_tra_cuu = item.ma_tra_cuu_hang_hoa;
                dong.gia_nhap = item.gia_nhap.ToString();
                foreach (var item2 in new List<string> { "S", "M", "L", "XL", "XXL" })
                {
                    var size = item.size_sl.Where(s => s.ten_size == item2).FirstOrDefault();
                    int sl = size == null ? 0 : size.so_luong;
                    dong.GetType().GetProperty(item2).SetValue(dong, sl.ToString());
                }
                result.Add(dong);
            }
            //
            m_dt_data_source = CommonFunction.list_to_data_table(result);
            m_grc_phieu_nhap.DataSource = m_dt_data_source;
        }

        private List<MotPhieuNhapExcel> to_list()
        {
            List<MotPhieuNhapExcel> result = new List<MotPhieuNhapExcel>();
            var data = m_grc_phieu_nhap.DataSource as DataTable;
            foreach (var row in data.Rows)
            {
                DataRow dt_row = row as DataRow;
                MotPhieuNhapExcel phieu = new MotPhieuNhapExcel();
                phieu.ma_tra_cuu = dt_row["ma_tra_cuu"].ToString();
                phieu.S = dt_row["S"].ToString();
                phieu.M = dt_row["M"].ToString();
                phieu.L = dt_row["L"].ToString();
                phieu.XL = dt_row["XL"].ToString();
                phieu.XXL = dt_row["XXL"].ToString();
                phieu.gia_nhap = dt_row["gia_nhap"].ToString();
                result.Add(phieu);
            }
            return result;
        }

        private void load_data_to_sle_ma()
        {
            try
            {
                m_lbl_loading.Text = "Loading";
                LibraryApi.QuanLyDanhMucHangHoa.LayDanhSachHangVaMaTraCuu(this, data =>
                {
                    m_lbl_loading.Text = "Done";
                    m_sle_ma_tra_cuu.DataSource = CommonFunction.list_to_data_table<LibraryApi.QuanLyDanhMucHangHoa.HangHoaVaMa>(data.Data);
                    m_sle_ma_tra_cuu.ValueMember = "ma_tra_cuu";
                    m_sle_ma_tra_cuu.DisplayMember = "ma_tra_cuu";

                    m_sle_hang_hoa.Properties.DataSource = CommonFunction.list_to_data_table<LibraryApi.QuanLyDanhMucHangHoa.HangHoaVaMa>(data.Data);
                    m_sle_hang_hoa.Properties.ValueMember = "ma_tra_cuu";
                    m_sle_hang_hoa.Properties.DisplayMember = "ma_tra_cuu";
                });
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }

        private void open_file()
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.Filter = "Office Files|*.xlsx;*.xls;";
            opf.Multiselect = false;

            if (opf.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            if (String.IsNullOrEmpty(opf.FileName))
            {
                return;
            }
            m_file_name = opf.FileName;
            var excel = new ExcelQueryFactory(m_file_name);
            data_from_excel = (from a in excel.Worksheet<MotPhieuNhapExcel>("PHIEU_NHAP")
                               select a).ToList();
            //bat buoc phai co ma tra cuu va gia nhap. thieu phat end luon
            add_data_from_excel_to_grid();
        }

        private void add_data_from_excel_to_grid()
        {
            foreach (var item in data_from_excel)
            {
                var l = new List<object>();
                l.Add(item.ma_tra_cuu);
                l.Add(item.S);
                l.Add(item.M);
                l.Add(item.L);
                l.Add(item.XL);
                l.Add(item.XXL);
                l.Add(item.gia_nhap);
                m_dt_data_source.Rows.Add(l.ToArray());
            }
        }

        private bool check_data()
        {
            foreach (var item in data_from_excel)
            {
                if (String.IsNullOrEmpty(item.ma_tra_cuu))
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại thông tin mã tra cứu hàng hóa");
                    return false;
                }
                if (String.IsNullOrEmpty(item.gia_nhap) | Convert.ToDecimal(item.gia_nhap) < 0)
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại thông tin giá nhập mặt hàng "
                                         + item.ma_tra_cuu.ToString());
                    return false;
                }
            }
            return true;
        }

        private void form_to_data()
        {
            data_from_excel = to_list();
            if (check_data())
            {
                m_phieu_nhap = new PhieuNhap();
                m_phieu_nhap.ma_phieu = m_ma_phieu;
                m_phieu_nhap.ngay_nhap = m_dat_ngay_lap.DateTime;
                m_phieu_nhap.ten_tai_khoan = SystemInfo.ten_tai_khoan;
                m_phieu_nhap.id_cua_hang = SystemInfo.id_cua_hang;
                m_phieu_nhap.list_hang_hoa = new List<HangHoa>();

                var hang_nhap_trong_ngay = data_from_excel;
                foreach (var hang in hang_nhap_trong_ngay)
                {
                    var hang_hoa = new HangHoa();
                    hang_hoa.gia_nhap = decimal.Parse(hang.gia_nhap);
                    hang_hoa.ma_tra_cuu_hang_hoa = hang.ma_tra_cuu;
                    hang_hoa.size_sl = new List<SizeSL>();
                    foreach (var item2 in new List<string> { "S", "M", "L", "XL", "XXL" })
                    {
                        var sl = int.Parse(hang.GetType().GetProperty(item2).GetValue(hang).ToString());
                        if (sl == 0)
                        {
                            continue;
                        }
                        SizeSL s = new SizeSL();
                        s.ten_size = item2;
                        s.so_luong = sl;
                        hang_hoa.size_sl.Add(s);
                    }
                    m_phieu_nhap.list_hang_hoa.Add(hang_hoa);
                }
            }
            else
            {
                XtraMessageBox.Show("Vui lòng kiểm tra lại dữ liệu");
            }
        }
        #endregion

        #region Event Handlers
        private void set_define_event()
        {
            this.Load += F03_them_phieu_nhap_excel_Load;
            //m_btn_chon_file.Click += M_btn_chon_file_Click;
            m_btn_save.Click += M_btn_save_Click;
            m_btn_them_chi_tiet.Click += M_btn_them_chi_tiet_Click;
        }

        private void M_btn_them_chi_tiet_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_dat_ngay_lap.EditValue == null)
                {
                    XtraMessageBox.Show("Chọn ngày nhập trước");
                    return;
                }
                if (m_sle_hang_hoa.EditValue == null)
                {
                    XtraMessageBox.Show("Chọn hng hóa trước khi thêm");
                    return;
                }
                foreach (DataRow item in m_dt_data_source.Rows)
                {
                    if (item["ma_tra_cuu"] == m_sle_hang_hoa.EditValue)
                    {
                        XtraMessageBox.Show("hàng hóa đã tồn tại");
                        return;
                    }
                }
                var list = new List<object>();
                list.Add(m_sle_hang_hoa.EditValue);
                m_dt_data_source.Rows.Add(list.ToArray());
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }

        private void M_btn_thoat_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                CommonFunction.exception_handle(ex);
            }
        }

        private void F03_them_phieu_nhap_excel_Load(object sender, EventArgs e)
        {
            try
            {
                switch (m_e_mode)
                {
                    case Mode.XemChiTiet:
                        m_lbl_ma_phieu.Text = "Mã phiếu: " + m_phieu_nhap.ma_phieu;
                        m_lbl_nguoi_lap.Text = "Người tạo: " + m_phieu_nhap.ten_tai_khoan;
                        m_dat_ngay_lap.EditValue = m_phieu_nhap.ngay_nhap;
                        LayPhieuNhapChiTiet(m_phieu_nhap.ma_phieu, this, data =>
                        {
                            m_list_chi_tiet = data.Data;
                            load_data_to_grid();

                        });
                        break;
                    case Mode.Sua:
                        m_lbl_ma_phieu.Text = "Mã phiếu: " + m_phieu_nhap.ma_phieu;
                        m_lbl_nguoi_lap.Text = "Người tạo: " + m_phieu_nhap.ten_tai_khoan;
                        m_dat_ngay_lap.EditValue = m_phieu_nhap.ngay_nhap;
                        LayPhieuNhapChiTiet(m_phieu_nhap.ma_phieu, this, data =>
                        {
                            m_list_chi_tiet = data.Data;
                            load_data_to_grid();

                        });
                        break;
                    case Mode.ThemMoi:
                        LayMaPhieuNhap(this, data =>
                        {
                            m_ma_phieu = data.Data;
                            m_lbl_ma_phieu.Text = "Mã phiếu: " + m_ma_phieu;
                            m_lbl_nguoi_lap.Text = "Người lập: " + SystemInfo.ten_tai_khoan;
                            m_dat_ngay_lap.EditValue = DateTime.Now;
                        });
                        break;
                    default:
                        break;
                }
                this.CenterToScreen();
                load_data_to_sle_ma();
                m_grc_phieu_nhap.DataSource = m_dt_data_source;
            }
            catch (Exception ex)
            {
                CommonFunction.exception_handle(ex);
            }
        }

        private void M_btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                data_from_excel = to_list();
                if (check_data())
                {
                    switch (m_e_mode)
                    {
                        case Mode.XemChiTiet:
                            break;
                        case Mode.Sua:
                            form_to_data();
                            SuaPhieuNhap(m_phieu_nhap, this, data =>
                            {
                                XtraMessageBox.Show(data.Message);
                            });
                            break;
                        case Mode.ThemMoi:
                            form_to_data();
                            ThemMotPhieuNhap(m_phieu_nhap, this, data =>
                            {
                                XtraMessageBox.Show(data.Message);
                            });
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra lại dữ liệu");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Vui lòng kiểm tra lại dữ liệu");
            }
        }

        private void M_btn_chon_file_Click(object sender, EventArgs e)
        {
            try
            {
                open_file();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }

        #endregion
    }
}
