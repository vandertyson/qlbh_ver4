using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LibraryApi.QuanLyNhaCungCap;
using QLBH.Common;

namespace QLBH.Forms
{
    public partial class f41_nha_cung_cap_chi_tiet : Form
    {
        #region Public Interfaces
        public f41_nha_cung_cap_chi_tiet()
        {
            InitializeComponent();
            set_define_event();
        }

        internal void display_sua(List<NhaCungCap> lst, NhaCungCap ncc)
        {
            m_e_mode = Mode.Sua;
            m_ncc = ncc;
            m_list_ncc = lst;
            m_list_ncc.Remove(m_ncc);
            this.ShowDialog();
        }

        internal void display_them_moi(List<NhaCungCap> ncc)
        {
            m_e_mode = Mode.Them;
            this.m_list_ncc = ncc;
            this.ShowDialog();
        }
        #endregion
        #region Members
        private List<NhaCungCap> m_list_ncc;
        private Mode m_e_mode;
        private NhaCungCap m_ncc = new NhaCungCap();
        #endregion
        #region Data Structures
        enum Mode
        {
            Them,
            Sua
        }
        #endregion
        #region Private Methods
        private void form_to_data()
        {
            m_ncc.ten_nha_cung_cap = m_txt_ten.Text.Trim();
            m_ncc.ma_nha_cung_cap = m_txt_ma.Text.Trim();
            m_ncc.dia_chi = m_txt_dia_chi.Text.Trim();
            m_ncc.email = m_txt_email.Text.Trim();
            m_ncc.so_dien_thoai = m_txt_sdt.Text.Trim();
            m_ncc.ten_nguoi_dai_dien = m_txt_dai_dien.Text.Trim();
        }

        private bool check_data()
        {
            var ma = m_txt_ma.Text.Trim();
            var c2 = m_list_ncc.Where(s => s.ma_nha_cung_cap == ma).FirstOrDefault();

            if (c2 != null)
            {
                XtraMessageBox.Show("Mã này đã tồn tại");
                return false;
            }
    
            return true;
        }

        private void data_to_form()
        {
            m_txt_ten.Text = m_ncc.ten_nha_cung_cap;
            m_txt_ma.Text = m_ncc.ma_nha_cung_cap;
            m_txt_dai_dien.Text = m_ncc.ten_nguoi_dai_dien;
            m_txt_email.Text = m_ncc.email;
            m_txt_sdt.Text = m_ncc.so_dien_thoai;
            m_txt_dia_chi.Text = m_ncc.dia_chi;
        }
        #endregion
        #region Event Handlers
        private void set_define_event()
        {
            this.Load += F41_nha_cung_cap_chi_tiet_Load;
            m_btn_save.Click += M_btn_save_Click;
        }

        private void F41_nha_cung_cap_chi_tiet_Load(object sender, EventArgs e)
        {
            try
            {
                switch (m_e_mode)
                {
                    case Mode.Them:
                        m_lbl_header.Text = "Thêm hàng hóa mới";
                        break;
                    case Mode.Sua:
                        m_lbl_header.Text = "Sửa thông tin hàng hóa";
                        data_to_form();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }

        private void M_btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (check_data())
                {
                    if (CommonFunction.MsgBox_Yes_No_Cancel("Bạn có chắc chắn muốn lưu dữ liệu?", "Xác nhận lưu dữ liệu") == DialogResult.Yes)
                    {
                        form_to_data();
                        switch (m_e_mode)
                        {
                            case Mode.Them:
                                ThemNhaCungCap(m_ncc, this, data =>
                                {
                                    XtraMessageBox.Show(data.Message);
                                });
                                break;
                            case Mode.Sua:
                                SuaNhaCungCap(m_ncc, this, data =>
                                {
                                    XtraMessageBox.Show(data.Message);
                                });
                                break;
                            default:
                                break;
                        }

                    }
                }
                else
                {
                    XtraMessageBox.Show("Vui lòng kiểm tra dữ liệu nhập vào");
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }


        #endregion
    }
}
