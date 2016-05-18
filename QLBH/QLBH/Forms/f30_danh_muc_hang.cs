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
using LibraryApi;

namespace QLBH.Forms
{
    public partial class f30_danh_muc_hang : Form
    {
        #region Member
        int page;
        List<QuanLyDanhMucHangHoa.ThemHangHoa> m_data;
        #endregion
        #region Public Interfaces
        public f30_danh_muc_hang()
        {
            InitializeComponent();
            set_define_event();
            load_danh_muc_loai_hang();
            
        }

        private void load_danh_muc_loai_hang()
        {
            lbl_loading.Text = "Đang tải danh mục loại hàng...";
            QuanLyDanhMucHangHoa.GetDanhSachLoaiHang(this, data => 
            {
                lbl_loading.Text = "Xong!";
                var list = data.Data;
                var tatCa = new QuanLyDanhMucHangHoa.LoaiHang();
                tatCa.ten_tag = "Tất cả";
                tatCa.id = -1;
                list.Add(tatCa);
                m_cbb_loai_hang.DataSource = list;
                m_cbb_loai_hang.DisplayMember = "ten_tag";
                m_cbb_loai_hang.ValueMember = "id";

                
            });
        }

        

        private void set_define_event()
        {
            this.Load += F30_danh_muc_hang_Load;
            m_btn_them.Click += M_btn_them_Click;
            m_btn_xoa.Click += M_btn_xoa_Click;
            m_btn_sua.Click += M_btn_sua_Click;
            c01_search_box1.Search += Search;

            m_cbb_loai_hang.SelectedIndexChanged += M_cbb_loai_hang_SelectedIndexChanged;
        }

        private void Search(string key)
        {
            page = 0;
            lbl_loading.Text = "Đang tải dữ liệu";
            QuanLyDanhMucHangHoa.TimKiemHangHoaLv0(key, 100, page, this, data =>
                {
                    lbl_loading.Text = "Xong";
                    m_data = data.Data;
                    loadDataToGrid();
                });
        }

        private void M_cbb_loai_hang_SelectedIndexChanged(object sender, EventArgs e)
        {
            var select = m_cbb_loai_hang.SelectedValue as decimal?;
            if (select == -1)
            {
                lbl_loading.Text = "Đang tải dữ liệu";
                QuanLyDanhMucHangHoa.TatCaHangHoa(this, data => 
                {
                    lbl_loading.Text = "Xong";
                    m_data = data.Data;
                    loadDataToGrid();
                });
            }
            else
            {
                var item = m_cbb_loai_hang.SelectedItem as QuanLyDanhMucHangHoa.LoaiHang;
                Search(item.ten_tag);
            }
        }
        void loadDataToGrid()
        {
            
            m_grc_hang_hoa.DataSource = m_data;
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

                var row = m_grv_hang_hoa.GetSelectedRows().First();
                v_f.display_update(m_data[row]);
                load_danh_muc_loai_hang();
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
                    XtraMessageBox.Show("Chọn dòng để xóa");
                    return;
                }
                var row = m_grv_hang_hoa.GetRow(m_grv_hang_hoa.GetSelectedRows().First()) as QuanLyDanhMucHangHoa.ThemHangHoa;
                var hang = m_data.Where(s => s.ma_tra_cuu == row.ma_tra_cuu).FirstOrDefault();

                QuanLyDanhMucHangHoa.XoaHangHoa(hang.id, this, data =>
                {
                    MessageBox.Show(data.Message);
                    load_danh_muc_loai_hang();
                });
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
                var f31 = new f31_chi_tiet_hang_hoa();
                f31.display_add();
                load_danh_muc_loai_hang();
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
                c01_search_box1.SetPlaceHolder();
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
