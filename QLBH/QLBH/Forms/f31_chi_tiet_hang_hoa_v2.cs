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
using static LibraryApi.QuanLyDanhMucHangHoa;

namespace QLBH.Forms
{
    public partial class f31_chi_tiet_hang_hoa_v2 : Form
    {
        #region Public Interfaces
        public f31_chi_tiet_hang_hoa_v2()
        {
            InitializeComponent();
            set_define_event();
        }
        
        internal void display_sua(List<HangHoaV2> lst, HangHoaV2 hang)
        {
            m_e_mode = Mode.Sua;
            m_hang = hang;
            m_list_hang_hoa = lst;
            m_list_hang_hoa.Remove(m_hang);
            this.ShowDialog();
        }

        internal void display_them_moi(List<HangHoaV2> list_hang)
        {
            m_e_mode = Mode.Them;
            this.m_list_hang_hoa = list_hang;
            this.ShowDialog();
        }
        #endregion
        #region Members
        private List<NhaCungCap3> m_list_nha_cung_cap;
        private List<HangHoaV2> m_list_hang_hoa;
        private Mode m_e_mode;
        private HangHoaV2 m_hang;
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
            m_hang.ten_hang_hoa = m_txt_ten_hang.Text.Trim();
            m_hang.ma_tra_cuu = m_txt_ma_tra_cuu.Text.Trim();
            m_hang.id_nha_cung_cap = m_list_nha_cung_cap.Where(s => s.ten_nha_cung_cap == m_comb_nha_cung_cap.Text.Trim()).First().id;
            m_hang.mo_ta = m_txt_mo_ta.Text.Trim();
        }

        private bool check_data()
        {
            var ma = m_txt_ma_tra_cuu.Text.Trim();
            var c2 = m_list_hang_hoa.Where(s => s.ma_tra_cuu == ma).FirstOrDefault();

            var ncc = m_comb_nha_cung_cap.Text.Trim();
            var c1 = m_list_nha_cung_cap.Where(s => s.ten_nha_cung_cap == ncc).FirstOrDefault();

            if (c2 != null)
            {
                XtraMessageBox.Show("Mã tra cứu đã tồn tại");
                return false;
            }
            if (c1 == null)
            {
                XtraMessageBox.Show("Chưa có nhà cung cấp này");
                return false;
            }
            return true;
        }

        private void data_to_form()
        {
            m_txt_ten_hang.Text = m_hang.ten_hang_hoa;
            m_txt_ma_tra_cuu.Text = m_hang.ma_tra_cuu;
            m_txt_mo_ta.Text = m_hang.mo_ta;
            m_comb_nha_cung_cap.Text = m_hang.ten_nha_cung_cap;
        }

        private void load_data_to_nha_cc()
        {
            lay_nha_cung_cap_v2(this, data =>
            {
                m_comb_nha_cung_cap.DataSource = m_list_nha_cung_cap;
                m_comb_nha_cung_cap.DisplayMember = "ten_nha_cung_cap";
                m_comb_nha_cung_cap.ValueMember = "id";
            });
        }
        #endregion
        #region Event Handlers
        private void set_define_event()
        {
            this.Load += F31_chi_tiet_hang_hoa_v2_Load;
            m_btn_save.Click += M_btn_save_Click;
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
                                them_hang_hoa_v2(m_hang, this, data =>
                                {
                                    XtraMessageBox.Show(data.Message);
                                });
                                break;
                            case Mode.Sua:
                                sua_hang_hoa_v2(m_hang, this, data =>
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

        private void F31_chi_tiet_hang_hoa_v2_Load(object sender, EventArgs e)
        {
            try
            {
                load_data_to_nha_cc();
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


        #endregion


    }
}
