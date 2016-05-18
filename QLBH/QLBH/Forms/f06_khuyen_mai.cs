using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibraryApi;
using QLBH.Common;
using static LibraryApi.QuanLyDanhMucHangHoa;
using DevExpress.XtraEditors;

namespace QLBH.Forms
{
    public partial class f06_khuyen_mai : Form
    {
        #region Public Interfaces
        internal void display()
        {
            this.ShowDialog();
        }
        #endregion
        #region Members
        private List<QuanLyKhuyenMai.KhuyenMai_HangHoa> list_hang_hoa;
        private List<QuanLyKhuyenMai.KhuyenMai_HangHoa> list_hh_km;
        private DataTable m_data_table;
        private object m_btn_save;
        #endregion
        #region Data Structures
        #endregion
        #region Private Methods
        #endregion
        #region Event Handlers
        #endregion
        public f06_khuyen_mai()
        {
            InitializeComponent();
            this.CenterToParent();
            load_form();
            set_defined_event();
        }

        private void load_form()
        {
            m_data_table = CommonFunction.create_table_form_struct(typeof(QuanLyKhuyenMai.KhuyenMai_HangHoa));
            QuanLyKhuyenMai.gen_ma_khuyen_mai(this, data => 
            {
                m_lbl_ma_dot_khuyen_mai.Text = data.Data;
            });
            LibraryApi.QuanLyTagHangHoa.LayDanhSachHangHoa(this, data =>
            {
                load_data_to_sle(data.Data);
            });
            LibraryApi.QuanLyKhuyenMai.lay_thong_tin_khuyen_mai(this, data =>
             {
                 m_sle_dot_km.Properties.DataSource = Common.CommonFunction.list_to_data_table(data.Data);
                 m_sle_dot_km.Properties.DisplayMember = @"ma_dot";
                 m_sle_dot_km.Properties.ValueMember = @"ma_dot";
             });

        }

        private void inti_table_data()
        {
            throw new NotImplementedException();
        }

        private void set_defined_event()
        {
            m_btn_them_hang_hoa.Click += M_btn_them_hang_hoa_Click;
            //m_btn_save.Click += M_btn_save_Click;
            m_btn_them_dot.Click += M_btn_them_dot_Click;
            m_btn_lam_moi.Click += M_btn_lam_moi_Click;
            m_btn_thoat.Click += M_btn_thoat_Click;
            m_sle_dot_km.EditValueChanged += M_sle_dot_km_EditValueChanged;
            this.Load += F06_khuyen_mai_Load;
        }

        private void M_sle_dot_km_EditValueChanged(object sender, EventArgs e)
        {
            load_grid();
            
        }

        private void load_grid()
        {
            QuanLyKhuyenMai.lay_thong_in_khuyen_mai_theo_dot(m_sle_dot_km.EditValue.ToString(), this, data =>
            {
                list_hh_km = data.Data;
                m_grc_chi_tiet.DataSource = CommonFunction.list_to_data_table(list_hh_km);
                m_grv_chi_tiet.BestFitColumns();
                m_grv_chi_tiet.OptionsBehavior.Editable = false;
                m_grv_chi_tiet.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                m_grv_chi_tiet.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            });
        }

        private void F06_khuyen_mai_Load(object sender, EventArgs e)
        {
            try
            {
                load_form();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void load_data_to_sle(List<QuanLyTagHangHoa.HangHoa> data)
        {    
            m_sle_hang_hoa.Properties.DataSource = CommonFunction.list_to_data_table(data);
            m_sle_hang_hoa.Properties.DisplayMember = "ten_hang_hoa";
            m_sle_hang_hoa.Properties.ValueMember = "ma_hang_hoa";
        }

        private void M_btn_thoat_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void M_btn_lam_moi_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_grv_chi_tiet.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Chọn dòng để sửa");
                    return;
                }
                string ma = m_grv_chi_tiet.GetDataRow(m_grv_chi_tiet.FocusedRowHandle)["ma_hang_hoa"].ToString();
                string ma_dot = m_sle_dot_km.EditValue.ToString();
                QuanLyKhuyenMai.xoa_mat_hang_khuyen_mai(ma_dot, ma, this, data =>
                {
                    XtraMessageBox.Show(data.Data);
                    load_grid();
                });
                    
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void M_btn_them_dot_Click(object sender, EventArgs e)
        {
            try
            {
                if (check_null_input())
                {
                    QuanLyKhuyenMai.them_dot_khuyen_mai(m_lbl_ma_dot_khuyen_mai.Text
                                                    , m_txt_mo_ta.Text, m_dat_ngay_bat_dau.DateTime
                                                    , m_dat_ngay_ket_thuc.DateTime
                                                    , this, data =>
                                                    {
                                                        if (data.Success)
                                                        {
                                                            XtraMessageBox.Show(@"Bạn đã thêm đợt thành công");
                                                        }
                                                        else XtraMessageBox.Show(@"Đã xảy ra lỗi, vui lòng kiểm tra lại giá trị nhập");
                                                    });
                }
                else
                {
                    XtraMessageBox.Show(@"Chưa nhập đủ thông tin");
                }
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private bool check_null_input()
        {
            if (m_txt_mo_ta.Text == null) return false;
            if (m_dat_ngay_bat_dau.DateTime == null) return false;
            if (m_dat_ngay_ket_thuc.DateTime == null) return false;
            return true;
        }

        private void M_btn_them_hang_hoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_sle_dot_km.EditValue==null| m_sle_hang_hoa.EditValue==null| m_txt_muc_km.Text==null)
                {
                    XtraMessageBox.Show("Chưa nhập đủ thông tin đầu vào");
                    return;
                }
                var hh = list_hh_km.Where(s => s.ma_hang_hoa == m_sle_hang_hoa.EditValue.ToString()).First();
                if (hh==null)
                {
                    var temp = new QuanLyKhuyenMai.KhuyenMai_HangHoa();
                    temp.ma_dot = m_sle_dot_km.EditValue.ToString();
                    temp.ma_hang_hoa = m_sle_hang_hoa.EditValue.ToString();
                    temp.muc_km = decimal.Parse(m_txt_muc_km.Text);
                    var list = new List<QuanLyKhuyenMai.KhuyenMai_HangHoa>();
                    list.Add(temp);
                    QuanLyKhuyenMai.them_hang_hoa_khuyen_mai(list, this, data =>
                    {
                        if (data.Success) XtraMessageBox.Show(@"Đã thêm hàng hóa cho đợt khuyến mãi thành công");
                        else XtraMessageBox.Show(@"Đã xảy ra lỗi, vui lòng kiểm tra lại giá trị nhập");
                        load_grid();
                    });

                }
                else
                {
                    QuanLyKhuyenMai.sua_mat_hang_khuyen_mai(m_sle_dot_km.EditValue.ToString(),
                                                            m_sle_hang_hoa.EditValue.ToString(),
                                                            decimal.Parse(m_txt_muc_km.Text),
                                                            this,
                                                            data =>
                                                            {
                                                                XtraMessageBox.Show(data.Data);
                                                                load_grid();
                                                            });
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void m_lbl_header_Click(object sender, EventArgs e)
        {

        }
    }
}
