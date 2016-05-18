﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LibraryApi.QuanLyPhieuNhapXuat;
using QLBH.Common;
using DevExpress.XtraEditors;

namespace QLBH.Forms
{
    public partial class f14_danh_sach_phieu_nhap_xuat : Form
    {
        public f14_danh_sach_phieu_nhap_xuat()
        {
            InitializeComponent();
            set_define_event();
            this.CenterToScreen();
        }

        private List<PhieuNhap> m_data_phieu;

        private void set_define_event()
        {
            this.Load += F14_danh_sach_phieu_nhap_xuat_Load;
            m_btn_xem.Click += M_btn_xem_Click;
            m_btn_them_phieu.Click += M_btn_them_phieu_Click;
            m_btn_sua.Click += M_btn_sua_Click;
            m_btn_xoa.Click += M_btn_xoa_Click;
            m_btn_xem_chi_tiet.Click += M_btn_xem_chi_tiet_Click;
        }

        private void M_btn_xem_chi_tiet_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_grv_phieu_nhap.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Chọn phiếu để xem chi tiết");
                    return;
                }
                string ma = m_grv_phieu_nhap.GetDataRow(m_grv_phieu_nhap.FocusedRowHandle)["ma_phieu"].ToString();
                PhieuNhap p = m_data_phieu.Where(s => s.ma_phieu == ma).First();
                f15_phieu_nhap_chi_tiet v_f = new f15_phieu_nhap_chi_tiet();
                v_f.display_chi_tiet(p);
                load_data_to_grid();
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
                if (CommonFunction.MsgBox_Yes_No_Cancel("Bạn có chắc chắn muốn xóa?","Xác nhận xóa dữ liệu")==DialogResult.Yes)
                {
                    if (m_grv_phieu_nhap.FocusedRowHandle < 0)
                    {
                        XtraMessageBox.Show("Chọn phiếu để xem chi tiết");
                        return;
                    }
                    string ma = m_grv_phieu_nhap.GetDataRow(m_grv_phieu_nhap.FocusedRowHandle)["ma_phieu"].ToString();
                    PhieuNhap p = m_data_phieu.Where(s => s.ma_phieu == ma).First();
                    XoaPhieuNhap(p.ma_phieu, this, data =>
                    {
                        if (data.Success)
                        {
                            XtraMessageBox.Show(data.Message);
                            load_data_to_grid();
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }

        private void M_btn_sua_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_grv_phieu_nhap.FocusedRowHandle < 0)
                {
                    XtraMessageBox.Show("Chọn phiếu để xem chi tiết");
                    return;
                }
                string ma = m_grv_phieu_nhap.GetDataRow(m_grv_phieu_nhap.FocusedRowHandle)["ma_phieu"].ToString();
                PhieuNhap p = m_data_phieu.Where(s => s.ma_phieu == ma).First();
                f15_phieu_nhap_chi_tiet v_f = new f15_phieu_nhap_chi_tiet();
                v_f.display_update(p);
                load_data_to_grid();
            }
            catch (Exception ex)
            {
                //OnQueryContinueDrag;
                //XtraMessageBox.Show(ex.InnerException.Message);
            }
        }

        private void M_btn_them_phieu_Click(object sender, EventArgs e)
        {
            try
            {
                f15_phieu_nhap_chi_tiet v_f = new f15_phieu_nhap_chi_tiet();
                v_f.display_them_moi();
                load_data_to_grid();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }

        private void M_btn_xem_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_dat_ngay_bat_dau.EditValue == null | m_dat_ngay_ket_thuc.EditValue == null)
                {
                    XtraMessageBox.Show(CommonMessage.USER_INPUT_ERROR);
                    return;
                }
                load_data_to_grid();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.InnerException.Message);
            }
        }

        private void load_data_to_grid()
        {
            m_lb_trang_thai.Text = "Đang tải dữ liệu";
            LayDanhSachPhieuNhap(m_dat_ngay_bat_dau.DateTime, m_dat_ngay_ket_thuc.DateTime, this, data =>
            {
                m_data_phieu = data.Data;
                List<string> prop_name = new List<string> { "ma_phieu", "ngay_nhap", "ten_tai_khoan" };
                m_grc_phieu_nhap.DataSource = CommonFunction.convert_list_to_data_table<PhieuNhap>(prop_name, m_data_phieu);
                m_lb_trang_thai.Text = "";
            });
        }

        private void F14_danh_sach_phieu_nhap_xuat_Load(object sender, EventArgs e)
        {
            try
            {
                set_init_form_load();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(ex.Message);
            }
        }

        private void set_init_form_load()
        {
            m_dat_ngay_bat_dau.EditValue = "01/01/2015";
            m_dat_ngay_ket_thuc.EditValue = DateTime.Now;
            load_data_to_grid();
            this.CenterToScreen();
        }
    }
}
