﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBH.Forms;

namespace QLBH.Controls.Cửa_hàng
{
    public partial class c03_nv_cua_hang_v2 : UserControl
    {
        public c03_nv_cua_hang_v2()
        {
            InitializeComponent();
            set_define_event();
        }

        private void set_define_event()
        {
            m_tile_nhap_kho.ItemClick += M_tile_nhap_kho_ItemClick;
            m_tile_tao_khuyen_mai.ItemClick += M_tile_tao_khuyen_mai_ItemClick;
            m_tile_them_hang_hoa.ItemClick += M_tile_them_hang_hoa_ItemClick;
            m_tile_gia_excel.ItemClick += M_tile_gia_excel_ItemClick;
            m_tile_thong_tin_phieu_nhap.ItemClick += M_tile_thong_tin_ton_kho_ItemClick;
            m_tile_tra_cuu_hoa_don.ItemClick += M_tile_tra_cuu_hoa_don_ItemClick;
            m_tile_dm_hang_hoa.ItemClick += M_tile_dm_hang_hoa_ItemClick;
            m_tile_khach_hang.ItemClick += M_tile_khach_hang_ItemClick;
            m_tile_nha_cung_cap.ItemClick += M_tile_nha_cung_cap_ItemClick;
            m_tile_gia.ItemClick += M_tile_gia_ItemClick;
        }

        private void M_tile_gia_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            f60_bang_gia v_f = new f60_bang_gia();
            v_f.ShowDialog();
        }

        private void M_tile_nha_cung_cap_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            f40_danh_muc_nha_cung_cap v_f = new f40_danh_muc_nha_cung_cap();
            v_f.ShowDialog();
        }

        private void M_tile_khach_hang_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            f70_danh_sach_khach_hang v_d = new f70_danh_sach_khach_hang();
            v_d.ShowDialog();
        }

        private void M_tile_dm_hang_hoa_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            f30_danh_muc_hang v_f = new f30_danh_muc_hang();
            v_f.ShowDialog();
        }

        private void M_tile_tra_cuu_hoa_don_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            f20_danh_sach_hoa_don v_f = new f20_danh_sach_hoa_don();
            v_f.ShowDialog();
        }

        private void M_tile_thong_tin_ton_kho_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            f14_danh_sach_phieu_nhap_xuat v_f = new f14_danh_sach_phieu_nhap_xuat();
            v_f.Show();
        }

        private void M_tile_gia_excel_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            f12_gia_ban_excel v_f = new f12_gia_ban_excel();
            v_f.Show();
        }

        private void M_tile_them_hang_hoa_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            f10_them_hang_hoa_excal v_f = new f10_them_hang_hoa_excal();
            v_f.Show();
        }

        private void M_tile_tao_khuyen_mai_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            f80_danh_muc_khuyen_mai v_f = new f80_danh_muc_khuyen_mai();
            v_f.ShowDialog();
        }

        private void M_tile_nhap_kho_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            f03_them_phieu_nhap_excel f = new f03_them_phieu_nhap_excel();
            f.ShowDialog();
        }

        private void M_tile_them_ban_hang_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            f02_them_hoa_don_v2 f = new f02_them_hoa_don_v2();
            f.ShowDialog();
        }
    }
}

