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
using DevExpress.XtraEditors;

namespace QLBH.Forms
{
    public partial class f40_danh_muc_nha_cung_cap : Form
    {
        #region Public Interfaces 
        public f40_danh_muc_nha_cung_cap()
        {
            InitializeComponent();
            set_define_event();

        }
        #endregion
        #region Members
        public List<QuanLyNhaCungCap.NhaCungCap> m_list_ncc;
        #endregion
        private void set_define_event()
        {
            this.Load += F40_danh_muc_nha_cung_cap_Load;
            m_btn_them.Click += M_btn_them_Click;
            m_btn_sua.Click += M_btn_sua_Click;
            m_btn_xoa.Click += M_btn_xoa_Click;
        }

        private void M_btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_grv_nha_cung_cap.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Chọn dòng để sửa");
                    return;
                }
                string ma = m_grv_nha_cung_cap.GetDataRow(m_grv_nha_cung_cap.FocusedRowHandle)["ma_tra_cuu"].ToString();
                decimal id = m_list_ncc.Where(s => s.ma_nha_cung_cap == ma).First().id;
                QuanLyNhaCungCap.XoaNhaCungCap(id, this, data =>
                {
                    XtraMessageBox.Show(data.Data);
                });
                load_data_to_grid();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }

        private void M_btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_grv_nha_cung_cap.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Chọn dòng để sửa");
                    return;
                }
                string ma = m_grv_nha_cung_cap.GetDataRow(m_grv_nha_cung_cap.FocusedRowHandle)["ma_nha_cung_cap"].ToString();
                var hang = m_list_ncc.Where(s => s.ma_nha_cung_cap == ma).First();
                f41_nha_cung_cap_chi_tiet v_f = new f41_nha_cung_cap_chi_tiet();
                v_f.display_sua(m_list_ncc,hang);
                load_data_to_grid();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }

        private void M_btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                f41_nha_cung_cap_chi_tiet v_d = new f41_nha_cung_cap_chi_tiet();
                v_d.display_them_moi(m_list_ncc);
                load_data_to_grid();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }

        private void F40_danh_muc_nha_cung_cap_Load(object sender, EventArgs e)
        {
            try
            {
                load_data_to_grid(); 
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void load_data_to_grid()
        {
            m_lbl_trang_thai.Text = @"Đang tải dữ liệu";
            QuanLyNhaCungCap.LayDanhSachNhaCungCap(this, data =>
            {
                m_list_ncc = data.Data;
                m_grc_nha_cung_cap.DataSource = CommonFunction.list_to_data_table(m_list_ncc);
                m_grv_nha_cung_cap.BestFitColumns();
                m_grv_nha_cung_cap.OptionsBehavior.Editable = false;
                m_grv_nha_cung_cap.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                m_grv_nha_cung_cap.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
                m_lbl_trang_thai.Text = "";
            });
        }
        
    }
}
