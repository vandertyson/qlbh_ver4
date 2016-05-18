using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LibraryApi.QuanLyGia;
using QLBH.Common;
using DevExpress.XtraEditors;


namespace QLBH.Forms
{
    public partial class f61_gia_chi_tiet : Form
    {
        private List<LibraryApi.QuanLyDanhMucHangHoa.HangHoaVaMa> m_list_hang = new List<LibraryApi.QuanLyDanhMucHangHoa.HangHoaVaMa>();
        private GiaSanPham m_gia = new GiaSanPham();
        private string m_ma_tra_cuu;
        private string gia;

        public f61_gia_chi_tiet()
        {
            InitializeComponent();
            set_define_event();
        }

        private void set_define_event()
        {
            this.Load += F61_gia_chi_tiet_Load;
            m_btn_luu.Click += M_btn_luu_Click;
            m_txt_gia.Leave += M_txt_gia_Leave;
        }

        private void M_txt_gia_Leave(object sender, EventArgs e)
        {
            try
            {
                if (m_txt_gia.EditValue == null|String.IsNullOrEmpty(m_txt_gia.Text))
                {
                    XtraMessageBox.Show("Bạn chưa nhập giá");
                    return;
                }
                m_txt_gia.Text = String.Format("{0:#,##0}", m_txt_gia.Text);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }

        private void M_btn_luu_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_sle_hang_hoa.EditValue == null | m_txt_gia.EditValue == null)
                {
                    XtraMessageBox.Show("Vui lòng nhập đủ thông tin");
                    return;
                }
                form_to_data();
                them_gia_1_san_pham(m_ma_tra_cuu, m_gia, this, data =>
                {
                    XtraMessageBox.Show(data.Message);
                    this.Close();
                });
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }

        private void form_to_data()
        {
            m_ma_tra_cuu = m_sle_hang_hoa.EditValue.ToString();
            m_gia.ngay_ap_dung = m_dat_ngay_ap_dung.DateTime;
            m_gia.gia_tien = (decimal)m_txt_gia.EditValue;
        }

        private void F61_gia_chi_tiet_Load(object sender, EventArgs e)
        {
            try
            {
                load_data_hang_hoa();
                m_dat_ngay_ap_dung.EditValue = DateTime.Now;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }

        private void load_data_hang_hoa()
        {
            LibraryApi.QuanLyDanhMucHangHoa.LayDanhSachHangVaMaTraCuu(this, data =>
            {
                m_list_hang = data.Data;
                m_sle_hang_hoa.Properties.DataSource = CommonFunction.list_to_data_table(m_list_hang);
                m_sle_hang_hoa.Properties.DisplayMember = "ten_hanh_hoa";
                m_sle_hang_hoa.Properties.ValueMember = "ma_tra_cuu";
            });
        }

        internal void display_them_moi()
        {
            m_lbl_header.Text = "Thêm giá mới cho sản phẩm";
            this.ShowDialog();
        }
    }
}
