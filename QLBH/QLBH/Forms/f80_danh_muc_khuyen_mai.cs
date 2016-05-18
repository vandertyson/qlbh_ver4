using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LibraryApi.QuanLyKhuyenMai;
using QLBH.Common;
using DevExpress.XtraEditors;

namespace QLBH.Forms
{
    public partial class f80_danh_muc_khuyen_mai : Form
    {
        #region Public Interfaces
        public f80_danh_muc_khuyen_mai()
        {
            InitializeComponent();
            set_define_events();
        }
        #endregion

        #region Private members
        List<KhuyenMai> list_km = new List<KhuyenMai>();
        #endregion

        private void set_define_events()
        {
            this.Load += F80_danh_muc_khuyen_mai_Load;
            m_btn_chi_tiet.Click += M_btn_chi_tiet_Click;
            m_btn_xoa_dot_km.Click += M_btn_xoa_dot_km_Click;
        }

        private void M_btn_xoa_dot_km_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_grv_khuyen_mai.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Chọn dòng để sửa");
                    return;
                }
                string ma = m_grv_khuyen_mai.GetDataRow(m_grv_khuyen_mai.FocusedRowHandle)["ma_dot"].ToString();
                xoa_dot_khuyen_mai(ma, this, data =>
                {
                    XtraMessageBox.Show(data.Data);
                    load_data_to_grid();
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void M_btn_chi_tiet_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    f06_khuyen_mai v_d = new f06_khuyen_mai();
                    v_d.display();
                    load_data_to_grid();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(ex.InnerException.Message);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void F80_danh_muc_khuyen_mai_Load(object sender, EventArgs e)
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
            lay_thong_tin_khuyen_mai(this, data =>
            {
                list_km = data.Data;
                m_grc_khuyen_mai.DataSource = CommonFunction.list_to_data_table(list_km);
                m_grv_khuyen_mai.BestFitColumns();
                m_grv_khuyen_mai.OptionsBehavior.Editable = false;
                m_grv_khuyen_mai.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                m_grv_khuyen_mai.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            });
        }
    }
}
