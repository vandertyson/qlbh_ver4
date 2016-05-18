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
using static LibraryApi.QuanLyKhachHang;
using QLBH.Common;

namespace QLBH.Forms
{
    public partial class f70_danh_sach_khach_hang : Form
    {
        public f70_danh_sach_khach_hang()
        {
            InitializeComponent();
            set_define_event();
        }
        #region Public Interfaces
        #endregion
        #region Members
        public List<TaiKhoan> m_list_tai_khoan;
        #endregion
        #region Data Structures
        #endregion
        #region Private Methods
        private void load_data_to_grid()
        {
            m_lbl_trang_thai.Text = "Đang tải dữ liệu";
            lay_danh_sach_khach_hang(this, data =>
            {
                m_list_tai_khoan = data.Data;
                m_grc_khach.DataSource = CommonFunction.list_to_data_table(m_list_tai_khoan);
                m_grv_khach.BestFitColumns();
                m_grv_khach.OptionsBehavior.Editable = false;
                m_grv_khach.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.False;
                m_grv_khach.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
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
                if (m_grv_khach.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Chọn dòng để sửa");
                    return;
                }
                string ma = m_grv_khach.GetDataRow(m_grv_khach.FocusedRowHandle)["ten_tai_khoan"].ToString();
                var hang = m_list_tai_khoan.Where(s => s.ten_tai_khoan == ma).First();
                f71_khach_hang_chi_tiet v_f = new f71_khach_hang_chi_tiet();
                v_f.display_sua(m_list_tai_khoan, hang);
                load_data_to_grid();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void M_btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_grv_khach.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Chọn dòng để sửa");
                    return;
                }
                string ma = m_grv_khach.GetDataRow(m_grv_khach.FocusedRowHandle)["ten_tai_khoan"].ToString();
                decimal id = m_list_tai_khoan.Where(s => s.ten_tai_khoan == ma).First().id;
                xoa_khach_hang(id, this, data =>
                {
                    XtraMessageBox.Show(data.Data);
                    load_data_to_grid();
                });
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void M_btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                f71_khach_hang_chi_tiet v_f = new f71_khach_hang_chi_tiet();
                v_f.display_them_moi(m_list_tai_khoan);
                load_data_to_grid();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
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
                XtraMessageBox.Show(ex.Message);
            }
        }
        #endregion
    }
}
