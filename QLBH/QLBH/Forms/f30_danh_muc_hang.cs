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
                f31_chi_tiet_hang_hoa v_f = new f31_chi_tiet_hang_hoa();
                v_f.display_update();
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

            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }
        #endregion
        #region Members
        #endregion
        #region Data Structures
        #endregion
        #region Private Methods
        #endregion
        #region Event Handlers
        #endregion


    }
}
