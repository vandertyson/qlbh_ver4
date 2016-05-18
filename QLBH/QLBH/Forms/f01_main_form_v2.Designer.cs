namespace QLBH.Forms
{
    partial class f01_main_form_v2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f01_main_form_v2));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.m_btn_dm_hang = new DevExpress.XtraBars.BarButtonItem();
            this.m_btn_nha_cung_cap = new DevExpress.XtraBars.BarButtonItem();
            this.m_btn_khach_hang = new DevExpress.XtraBars.BarButtonItem();
            this.m_btn_hoa_don = new DevExpress.XtraBars.BarButtonItem();
            this.m_btn_phieu_nhap_xuat = new DevExpress.XtraBars.BarButtonItem();
            this.m_btn_gia = new DevExpress.XtraBars.BarButtonItem();
            this.m_btn_khuyen_mai = new DevExpress.XtraBars.BarButtonItem();
            this.m_btn_doanh_thu = new DevExpress.XtraBars.BarButtonItem();
            this.m_btn_khuyen_mai_hang = new DevExpress.XtraBars.BarButtonItem();
            this.m_btn_phan_hoi = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.m_btn_dm_hang,
            this.m_btn_nha_cung_cap,
            this.m_btn_khach_hang,
            this.m_btn_hoa_don,
            this.m_btn_phieu_nhap_xuat,
            this.m_btn_gia,
            this.m_btn_khuyen_mai,
            this.m_btn_doanh_thu,
            this.m_btn_khuyen_mai_hang,
            this.m_btn_phan_hoi});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 12;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.Size = new System.Drawing.Size(1018, 142);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2,
            this.ribbonPageGroup3});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Chức năng";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.m_btn_dm_hang);
            this.ribbonPageGroup1.ItemLinks.Add(this.m_btn_nha_cung_cap);
            this.ribbonPageGroup1.ItemLinks.Add(this.m_btn_khach_hang);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "Danh mục";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.m_btn_hoa_don);
            this.ribbonPageGroup2.ItemLinks.Add(this.m_btn_phieu_nhap_xuat);
            this.ribbonPageGroup2.ItemLinks.Add(this.m_btn_gia);
            this.ribbonPageGroup2.ItemLinks.Add(this.m_btn_khuyen_mai);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "Nghiệp vụ";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.m_btn_doanh_thu);
            this.ribbonPageGroup3.ItemLinks.Add(this.m_btn_khuyen_mai_hang);
            this.ribbonPageGroup3.ItemLinks.Add(this.m_btn_phan_hoi);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "Báo cáo";
            // 
            // m_btn_dm_hang
            // 
            this.m_btn_dm_hang.Caption = "Danh mục hàng hóa";
            this.m_btn_dm_hang.Glyph = ((System.Drawing.Image)(resources.GetObject("m_btn_dm_hang.Glyph")));
            this.m_btn_dm_hang.Id = 1;
            this.m_btn_dm_hang.Name = "m_btn_dm_hang";
            this.m_btn_dm_hang.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));

            // 
            // m_btn_nha_cung_cap
            // 
            this.m_btn_nha_cung_cap.Caption = "Danh mục nhà cung cấp";
            this.m_btn_nha_cung_cap.Glyph = ((System.Drawing.Image)(resources.GetObject("m_btn_nha_cung_cap.Glyph")));
            this.m_btn_nha_cung_cap.Id = 2;
            this.m_btn_nha_cung_cap.Name = "m_btn_nha_cung_cap";
            this.m_btn_nha_cung_cap.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
           
            // 
            // m_btn_khach_hang
            // 
            this.m_btn_khach_hang.Caption = "Danh mục khách hàng";
            this.m_btn_khach_hang.Glyph = ((System.Drawing.Image)(resources.GetObject("m_btn_khach_hang.Glyph")));
            this.m_btn_khach_hang.Id = 4;
            this.m_btn_khach_hang.Name = "m_btn_khach_hang";
            this.m_btn_khach_hang.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // m_btn_hoa_don
            // 
            this.m_btn_hoa_don.Caption = "Quản lý hóa đơn";
            this.m_btn_hoa_don.Glyph = ((System.Drawing.Image)(resources.GetObject("m_btn_hoa_don.Glyph")));
            this.m_btn_hoa_don.Id = 5;
            this.m_btn_hoa_don.Name = "m_btn_hoa_don";
            this.m_btn_hoa_don.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // m_btn_phieu_nhap_xuat
            // 
            this.m_btn_phieu_nhap_xuat.Caption = "Quản lý phiếu nhập xuất";
            this.m_btn_phieu_nhap_xuat.Glyph = ((System.Drawing.Image)(resources.GetObject("m_btn_phieu_nhap_xuat.Glyph")));
            this.m_btn_phieu_nhap_xuat.Id = 6;
            this.m_btn_phieu_nhap_xuat.Name = "m_btn_phieu_nhap_xuat";
            this.m_btn_phieu_nhap_xuat.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // m_btn_gia
            // 
            this.m_btn_gia.Caption = "Quản lý giá";
            this.m_btn_gia.Glyph = ((System.Drawing.Image)(resources.GetObject("m_btn_gia.Glyph")));
            this.m_btn_gia.Id = 7;
            this.m_btn_gia.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("m_btn_gia.LargeGlyph")));
            this.m_btn_gia.Name = "m_btn_gia";
            this.m_btn_gia.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
          
            // 
            // m_btn_khuyen_mai
            // 
            this.m_btn_khuyen_mai.Caption = "Quản lý khuyến mãi";
            this.m_btn_khuyen_mai.Glyph = ((System.Drawing.Image)(resources.GetObject("m_btn_khuyen_mai.Glyph")));
            this.m_btn_khuyen_mai.Id = 8;
            this.m_btn_khuyen_mai.Name = "m_btn_khuyen_mai";
            this.m_btn_khuyen_mai.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            
            // 
            // m_btn_doanh_thu
            // 
            this.m_btn_doanh_thu.Caption = "Báo cáo doanh thu";
            this.m_btn_doanh_thu.Glyph = ((System.Drawing.Image)(resources.GetObject("m_btn_doanh_thu.Glyph")));
            this.m_btn_doanh_thu.Id = 9;
            this.m_btn_doanh_thu.Name = "m_btn_doanh_thu";
            this.m_btn_doanh_thu.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // m_btn_khuyen_mai_hang
            // 
            this.m_btn_khuyen_mai_hang.Caption = "Báo cáo khuyến mãi hàng hóa";
            this.m_btn_khuyen_mai_hang.Glyph = ((System.Drawing.Image)(resources.GetObject("m_btn_khuyen_mai_hang.Glyph")));
            this.m_btn_khuyen_mai_hang.Id = 10;
            this.m_btn_khuyen_mai_hang.Name = "m_btn_khuyen_mai_hang";
            this.m_btn_khuyen_mai_hang.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            
            // 
            // m_btn_phan_hoi
            // 
            this.m_btn_phan_hoi.Caption = "Thống kê phản hồi về hàng hóa";
            this.m_btn_phan_hoi.Glyph = ((System.Drawing.Image)(resources.GetObject("m_btn_phan_hoi.Glyph")));
            this.m_btn_phan_hoi.Id = 11;
            this.m_btn_phan_hoi.Name = "m_btn_phan_hoi";
            this.m_btn_phan_hoi.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
          
            // 
            // f01_main_form_v2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 540);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "f01_main_form_v2";
            this.Text = "Quản lý bán hàng";
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem m_btn_dm_hang;
        private DevExpress.XtraBars.BarButtonItem m_btn_nha_cung_cap;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem m_btn_khach_hang;
        private DevExpress.XtraBars.BarButtonItem m_btn_hoa_don;
        private DevExpress.XtraBars.BarButtonItem m_btn_phieu_nhap_xuat;
        private DevExpress.XtraBars.BarButtonItem m_btn_gia;
        private DevExpress.XtraBars.BarButtonItem m_btn_khuyen_mai;
        private DevExpress.XtraBars.BarButtonItem m_btn_doanh_thu;
        private DevExpress.XtraBars.BarButtonItem m_btn_khuyen_mai_hang;
        private DevExpress.XtraBars.BarButtonItem m_btn_phan_hoi;
    }
}