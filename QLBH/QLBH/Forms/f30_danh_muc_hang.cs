using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using static LibraryApi.QuanLyDanhMucHangHoa;
using QLBH.Common;
namespace QLBH.Forms
{
    public partial class f30_danh_muc_hang : Form
    {
        #region Public Interfaces
        public f30_danh_muc_hang()
        {
            InitializeComponent();
            set_define_event();
        }
        #endregion
        #region Members
        public List<HangHoaV2> m_list_hang;
        #endregion
        #region Data Structures
        #endregion
        #region Private Methods
        private void load_data_to_grid()
        {
            m_lbl_trang_thai.Text = "Đang tải dữ liệu";
            lay_danh_sach_hang_hoa_v2(this, data =>
            {
                m_list_hang = data.Data;
                m_grc_hang_hoa.DataSource = CommonFunction.list_to_data_table(m_list_hang);
                m_grv_hang_hoa.BestFitColumns();
                m_grv_hang_hoa.OptionsBehavior.Editable = false;
                m_grv_hang_hoa.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                m_grv_hang_hoa.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
                m_lbl_trang_thai.Text = "";
            });
        }
        #endregion
        #region Event Handlers
        private void set_define_event()
        {
            this.Load += F30_danh_muc_hang_Load;
            m_btn_them.Click += M_btn_them_Click;
            m_btn_xoa.Click += M_btn_xoa_Click;
            m_btn_sua.Click += M_btn_sua_Click;
        }

        private void M_btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_grv_hang_hoa.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Chọn dòng để sửa");
                    return;
                }
                string ma = m_grv_hang_hoa.GetDataRow(m_grv_hang_hoa.FocusedRowHandle)["ma_tra_cuu"].ToString();
                var hang = m_list_hang.Where(s => s.ma_tra_cuu == ma).First();
                f31_chi_tiet_hang_hoa_v2 v_f = new f31_chi_tiet_hang_hoa_v2();
               // v_f.display_sua(hang);
                load_data_to_grid();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }

        private void M_btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_grv_hang_hoa.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Chọn dòng để sửa");
                    return;
                }
                string ma = m_grv_hang_hoa.GetDataRow(m_grv_hang_hoa.FocusedRowHandle)["ma_tra_cuu"].ToString();
                decimal id = m_list_hang.Where(s => s.ma_tra_cuu == ma).First().id;
                xoa_hang_hoa_v2(id, this, data =>
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

        private void M_btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                f31_chi_tiet_hang_hoa_v2 v_d = new f31_chi_tiet_hang_hoa_v2();
                v_d.display_them_moi(m_list_hang);
                load_data_to_grid();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }

        private void F30_danh_muc_hang_Load(object sender, EventArgs e)
        {
            try
            {
                load_data_to_grid();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }
        #endregion


    }
}
