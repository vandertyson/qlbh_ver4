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
    public partial class f60_bang_gia : Form
    {
        #region Public Interfaces
        #endregion
        #region Members
        #endregion
        #region Data Structures
        #endregion
        #region Private Methods
        #endregion
        #region Event Handlers
        #endregion

        public f60_bang_gia()
        {
            InitializeComponent();
            set_define_event();
        }
        enum Mode
        {
            XemHienTai,
            XemLichSu
        }
        private Mode m_e_mode;
        private List<BangGia> m_dt_gia;

        private void set_define_event()
        {
            this.Load += F60_bang_gia_Load;
            m_btn_gia_hien_tai.Click += M_btn_gia_hien_tai_Click;
            m_btn_xem_lich_su.Click += M_btn_xem_lich_su_Click;
            m_btn_them.Click += M_btn_them_Click;
            m_btn_xoa.Click += M_btn_xoa_Click;
            
        }

        private void M_btn_xoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_grv_gia.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Chọn dòng để sửa");
                    return;
                }
                if (CommonFunction.MsgBox_Yes_No_Cancel("Bạn có chắc chắn muốn xóa dữ liệu này?","Xác nhận xóa dữ liệu")==DialogResult.Yes)
                {
                    var p1 = Convert.ToDateTime(m_grv_gia.GetDataRow(m_grv_gia.FocusedRowHandle)["ngay_ap_dung"].ToString());
                    var p2 = m_grv_gia.GetDataRow(m_grv_gia.FocusedRowHandle)["ma_tra_cuu"].ToString();
                    var p = m_dt_gia.Where(s => s.ma_tra_cuu == p2 & s.ngay_ap_dung == p1).First();
                    xoa_gd_gia(p.id_gd_gia, this, data =>
                    {
                        XtraMessageBox.Show(data.Message);
                        load_data_to_grid();
                    });
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }

        private void load_data_to_grid()
        {
            switch (m_e_mode)
            {
                case Mode.XemHienTai:
                    m_lbl_load.Text = "Đang tải dữ liệu";
                    lay_gia_hien_tai(this, data =>
                    {
                        m_lbl_load.Text = "";
                        m_dt_gia = data.Data;
                        m_grc_gia.DataSource = CommonFunction.list_to_data_table(m_dt_gia);
                        m_grv_gia.BestFitColumns();
                    });
                    break;
                case Mode.XemLichSu:
                    m_lbl_load.Text = "Đang tải dữ liệu";
                    lay_toan_bo_gia(this, data =>
                    {
                        m_lbl_load.Text = "";
                        m_dt_gia = data.Data;
                        m_grc_gia.DataSource = CommonFunction.list_to_data_table(m_dt_gia);
                        m_grv_gia.BestFitColumns();
                    });
                    break;
                default:
                    break;
            }
        }

        private void M_btn_them_Click(object sender, EventArgs e)
        {
            try
            {
                f61_gia_chi_tiet v_f = new f61_gia_chi_tiet();
                v_f.display_them_moi();
                load_data_to_grid();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }

        private void M_btn_xem_lich_su_Click(object sender, EventArgs e)
        {
            try
            {
                m_e_mode = Mode.XemLichSu;
                load_data_to_grid();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }

        private void M_btn_gia_hien_tai_Click(object sender, EventArgs e)
        {
            try
            {
                m_e_mode = Mode.XemHienTai;
                load_data_to_grid();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }

        private void F60_bang_gia_Load(object sender, EventArgs e)
        {
            try
            {
                set_init_form_load();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }

        private void set_init_form_load()
        {
            m_lbl_load.Text = "Đang tải dữ liệu";
            lay_gia_hien_tai(this, data =>
            {
                m_lbl_load.Text = "";
                m_dt_gia = data.Data;
                m_grc_gia.DataSource =  CommonFunction.list_to_data_table(m_dt_gia);
                m_grv_gia.BestFitColumns();
            });
        }
    }
}
