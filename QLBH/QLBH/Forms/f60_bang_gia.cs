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
        class ChuaCoGia
        {

        }
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
        private List<LibraryApi.QuanLyDanhMucHangHoa.HangHoaVaMa> m_dt_hang_chua_co_gia = new List<LibraryApi.QuanLyDanhMucHangHoa.HangHoaVaMa>();
        private int so_hang_chua_co_gia;

        private void set_define_event()
        {
            this.Load += F60_bang_gia_Load;
            m_btn_gia_hien_tai.Click += M_btn_gia_hien_tai_Click;
            m_btn_xem_lich_su.Click += M_btn_xem_lich_su_Click;
            m_btn_them.Click += M_btn_them_Click;
            m_btn_xoa.Click += M_btn_xoa_Click;
            m_lbl_chua_co_gia.DoubleClick += M_lbl_chua_co_gia_DoubleClick;
            
        }

        private void M_lbl_chua_co_gia_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                f61_gia_chi_tiet v_f = new f61_gia_chi_tiet();
                v_f.display_bo_sung_gia(m_dt_hang_chua_co_gia);
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
            m_dt_hang_chua_co_gia = new List<LibraryApi.QuanLyDanhMucHangHoa.HangHoaVaMa>();
            so_hang_chua_co_gia = 0;
            switch (m_e_mode)
            {
                case Mode.XemHienTai:
                    m_lbl_load.Text = "Đang tải dữ liệu";
                    lay_gia_hien_tai(this, data =>
                    {
                        m_lbl_load.Text = "";
                        m_dt_gia = data.Data;
                        load_config();
                    });
                    break;
                case Mode.XemLichSu:
                    m_lbl_load.Text = "Đang tải dữ liệu";
                    lay_toan_bo_gia(this, data =>
                    {
                        m_lbl_load.Text = "";
                        m_dt_gia = data.Data;
                        load_config();
                    });
                    break;
                default:
                    break;
            }
        }

        private void load_config()
        {
            List<BangGia> v_l = new List<BangGia>();
            foreach (var item in m_dt_gia)
            {
                if (item.id_gd_gia == -1)
                {
                    LibraryApi.QuanLyDanhMucHangHoa.HangHoaVaMa h = new LibraryApi.QuanLyDanhMucHangHoa.HangHoaVaMa();
                    h.ten_hang_hoa = item.ten_hang_hoa;
                    h.ma_tra_cuu = item.ma_tra_cuu;
                    m_dt_hang_chua_co_gia.Add(h);
                    //
                    so_hang_chua_co_gia++;
                }
                else
                {
                    v_l.Add(item);
                }
            }
            if (so_hang_chua_co_gia > 0)
            {
                m_lbl_chua_co_gia.Text = "Hiện có " + so_hang_chua_co_gia + " hàng hóa chưa có giá. Nháy đúp để thêm.";
            }
            else
            {
                m_lbl_chua_co_gia.Text = "";
            }
            m_grc_gia.DataSource = CommonFunction.list_to_data_table(v_l);
            m_grv_gia.BestFitColumns();
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
                m_e_mode = Mode.XemHienTai;
                load_data_to_grid();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }

    }
}
