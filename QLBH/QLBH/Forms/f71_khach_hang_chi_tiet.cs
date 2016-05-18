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
using QLBH.Common;
using static LibraryApi.QuanLyKhachHang;

namespace QLBH.Forms
{
    public partial class f71_khach_hang_chi_tiet : Form
    {
        public f71_khach_hang_chi_tiet()
        {
            InitializeComponent();
            set_define_event();
        }

        internal void display_sua(List<TaiKhoan> list_tai_khoan, TaiKhoan hang)
        {
            m_e_mode = Mode.Sua;
            m_tai_khoan = hang;
            m_list_tai_khoan = list_tai_khoan;
            m_list_tai_khoan.Remove(m_tai_khoan);
            this.ShowDialog();
        }

        internal void display_them_moi(List<TaiKhoan> list_tai_khoan)
        {
            m_e_mode = Mode.Them;
            m_list_tai_khoan = list_tai_khoan;
            this.ShowDialog();
        }
        #region Public Interfaces

        #endregion
        #region Members
        private List<TaiKhoan> m_list_tai_khoan = new List<TaiKhoan>();
        private Mode m_e_mode;
        private TaiKhoan m_tai_khoan = new TaiKhoan();
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
            m_tai_khoan.ten = m_txt_ten.Text.Trim();
            m_tai_khoan.ho_dem = m_txt_ho_dem.Text.Trim();
            m_tai_khoan.email = m_txt_email.Text.Trim();
            m_tai_khoan.lien_lac = m_txt_lien_lac.Text.Trim();
            m_tai_khoan.ten_tai_khoan = m_txt_ten_tai_khoan.Text.Trim();
            m_tai_khoan.so_dien_thoai = m_txt_sdt.Text.Trim();
            m_tai_khoan.ngay_tham_gia = m_dat_ngay_tham_gia.DateTime;
        }

        private bool check_data()
        {
            if (String.IsNullOrEmpty(m_txt_email.Text.Trim())
                | String.IsNullOrEmpty(m_txt_ten.Text.Trim())
                | String.IsNullOrEmpty(m_txt_ten_tai_khoan.Text.Trim())
                | String.IsNullOrEmpty(m_txt_ho_dem.Text.Trim())
                | m_dat_ngay_tham_gia.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng nhập đủ thông tin");
                return false;
            }
            var ten_tai_khoan = m_txt_ten_tai_khoan.Text.Trim();
            var p = m_list_tai_khoan.Where(s => s.ten_tai_khoan == ten_tai_khoan).FirstOrDefault();
            if (p != null)
            {
                XtraMessageBox.Show("Tên tài khoản đã tồn tại");
                return false;
            }
            return true;
        }

        private void data_to_form()
        {
            m_txt_ten.Text = m_tai_khoan.ten;
            m_txt_ho_dem.Text = m_tai_khoan.ho_dem;
            m_txt_email.Text = m_tai_khoan.email;
            m_txt_lien_lac.Text = m_tai_khoan.lien_lac;
            m_txt_ten_tai_khoan.Text = m_tai_khoan.ten_tai_khoan;
            m_txt_sdt.Text = m_tai_khoan.so_dien_thoai;
            m_dat_ngay_tham_gia.EditValue = m_tai_khoan.ngay_tham_gia;
        }

        #endregion
        #region Event Handlers
        private void set_define_event()
        {
            this.Load += F31_chi_tiet_hang_hoa_v2_Load;
            m_btn_luu.Click += M_btn_save_Click;
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
                                them_1_khach_hang_moi(m_tai_khoan, this, data =>
                                {
                                    XtraMessageBox.Show(data.Message);
                                });
                                break;
                            case Mode.Sua:
                                sua_khach_hang(m_tai_khoan, this, data =>
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
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void F31_chi_tiet_hang_hoa_v2_Load(object sender, EventArgs e)
        {
            try
            {
                switch (m_e_mode)
                {
                    case Mode.Them:
                        m_lbl_header.Text = "Thêm khách hàng mới";
                        m_dat_ngay_tham_gia.EditValue = DateTime.Now;
                        break;
                    case Mode.Sua:
                        m_lbl_header.Text = "Sửa thông tin khách hàng";
                        m_txt_ten_tai_khoan.Enabled = false;
                        data_to_form();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        #endregion
    }
}
