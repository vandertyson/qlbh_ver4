namespace QLBH.Forms
{
    partial class f30_danh_muc_hang
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f30_danh_muc_hang));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cbb_loai_hang = new System.Windows.Forms.ComboBox();
            this.lbl_loading = new System.Windows.Forms.Label();
            this.c01_search_box1 = new QLBH.Controls.c01_search_box();
            this.m_btn_them = new DevExpress.XtraEditors.SimpleButton();
            this.m_btn_sua = new DevExpress.XtraEditors.SimpleButton();
            this.m_btn_xoa = new DevExpress.XtraEditors.SimpleButton();
            this.m_grc_hang_hoa = new DevExpress.XtraGrid.GridControl();
            this.themHangHoaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.m_grv_hang_hoa = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colten_hang_hoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colma_tra_cuu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colten_nha_cung_cap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colma_nha_cung_cap = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colmo_ta = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colda_xoa = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem7 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_grc_hang_hoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.themHangHoaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_grv_hang_hoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.panel1);
            this.layoutControl1.Controls.Add(this.lbl_loading);
            this.layoutControl1.Controls.Add(this.c01_search_box1);
            this.layoutControl1.Controls.Add(this.m_btn_them);
            this.layoutControl1.Controls.Add(this.m_btn_sua);
            this.layoutControl1.Controls.Add(this.m_btn_xoa);
            this.layoutControl1.Controls.Add(this.m_grc_hang_hoa);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(51, 128, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(963, 439);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_cbb_loai_hang);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 43);
            this.panel1.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(261, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "hoặc tìm kiếm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Loại hàng:";
            // 
            // m_cbb_loai_hang
            // 
            this.m_cbb_loai_hang.FormattingEnabled = true;
            this.m_cbb_loai_hang.Location = new System.Drawing.Point(81, 11);
            this.m_cbb_loai_hang.Name = "m_cbb_loai_hang";
            this.m_cbb_loai_hang.Size = new System.Drawing.Size(158, 21);
            this.m_cbb_loai_hang.TabIndex = 0;
            // 
            // lbl_loading
            // 
            this.lbl_loading.Location = new System.Drawing.Point(12, 389);
            this.lbl_loading.Name = "lbl_loading";
            this.lbl_loading.Size = new System.Drawing.Size(251, 38);
            this.lbl_loading.TabIndex = 10;
            this.lbl_loading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // c01_search_box1
            // 
            this.c01_search_box1.BackColor = System.Drawing.SystemColors.Control;
            this.c01_search_box1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.c01_search_box1.ForeColor = System.Drawing.Color.Black;
            this.c01_search_box1.Location = new System.Drawing.Point(361, 12);
            this.c01_search_box1.Name = "c01_search_box1";
            this.c01_search_box1.SearchBackColor = System.Drawing.SystemColors.Control;
            this.c01_search_box1.SearchForceColor = System.Drawing.Color.Black;
            this.c01_search_box1.SearchPlaceHolder = "Mã hàng hóa, mã tra cứu, tên, tag, v.v";
            this.c01_search_box1.SearchPlaceHolderColor = System.Drawing.Color.Gray;
            this.c01_search_box1.SearchText = "";
            this.c01_search_box1.Size = new System.Drawing.Size(590, 43);
            this.c01_search_box1.TabIndex = 9;
            // 
            // m_btn_them
            // 
            this.m_btn_them.Image = ((System.Drawing.Image)(resources.GetObject("m_btn_them.Image")));
            this.m_btn_them.Location = new System.Drawing.Point(522, 389);
            this.m_btn_them.Name = "m_btn_them";
            this.m_btn_them.Size = new System.Drawing.Size(150, 38);
            this.m_btn_them.StyleController = this.layoutControl1;
            this.m_btn_them.TabIndex = 8;
            this.m_btn_them.Text = "Thêm hàng hóa";
            // 
            // m_btn_sua
            // 
            this.m_btn_sua.Image = ((System.Drawing.Image)(resources.GetObject("m_btn_sua.Image")));
            this.m_btn_sua.Location = new System.Drawing.Point(676, 389);
            this.m_btn_sua.Name = "m_btn_sua";
            this.m_btn_sua.Size = new System.Drawing.Size(159, 38);
            this.m_btn_sua.StyleController = this.layoutControl1;
            this.m_btn_sua.TabIndex = 6;
            this.m_btn_sua.Text = "Sửa thông tin hàng hóa";
            // 
            // m_btn_xoa
            // 
            this.m_btn_xoa.Image = ((System.Drawing.Image)(resources.GetObject("m_btn_xoa.Image")));
            this.m_btn_xoa.Location = new System.Drawing.Point(839, 389);
            this.m_btn_xoa.Name = "m_btn_xoa";
            this.m_btn_xoa.Size = new System.Drawing.Size(112, 38);
            this.m_btn_xoa.StyleController = this.layoutControl1;
            this.m_btn_xoa.TabIndex = 5;
            this.m_btn_xoa.Text = "Xóa hàng hóa";
            // 
            // m_grc_hang_hoa
            // 
            this.m_grc_hang_hoa.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_grc_hang_hoa.DataSource = this.themHangHoaBindingSource;
            this.m_grc_hang_hoa.Location = new System.Drawing.Point(12, 59);
            this.m_grc_hang_hoa.MainView = this.m_grv_hang_hoa;
            this.m_grc_hang_hoa.Name = "m_grc_hang_hoa";
            this.m_grc_hang_hoa.Size = new System.Drawing.Size(939, 326);
            this.m_grc_hang_hoa.TabIndex = 4;
            this.m_grc_hang_hoa.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.m_grv_hang_hoa});
            // 
            // themHangHoaBindingSource
            // 
            this.themHangHoaBindingSource.DataSource = typeof(LibraryApi.QuanLyDanhMucHangHoa.ThemHangHoa);
            // 
            // m_grv_hang_hoa
            // 
            this.m_grv_hang_hoa.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colid,
            this.colten_hang_hoa,
            this.colma_tra_cuu,
            this.colten_nha_cung_cap,
            this.colma_nha_cung_cap,
            this.colmo_ta,
            this.colda_xoa});
            this.m_grv_hang_hoa.GridControl = this.m_grc_hang_hoa;
            this.m_grv_hang_hoa.Name = "m_grv_hang_hoa";
            // 
            // colid
            // 
            this.colid.Caption = "ID";
            this.colid.FieldName = "id";
            this.colid.Name = "colid";
            this.colid.Visible = true;
            this.colid.VisibleIndex = 0;
            this.colid.Width = 64;
            // 
            // colten_hang_hoa
            // 
            this.colten_hang_hoa.Caption = "Tên hàng hóa";
            this.colten_hang_hoa.FieldName = "ten_hang_hoa";
            this.colten_hang_hoa.Name = "colten_hang_hoa";
            this.colten_hang_hoa.Visible = true;
            this.colten_hang_hoa.VisibleIndex = 2;
            this.colten_hang_hoa.Width = 378;
            // 
            // colma_tra_cuu
            // 
            this.colma_tra_cuu.Caption = "Mã tra cứu";
            this.colma_tra_cuu.FieldName = "ma_tra_cuu";
            this.colma_tra_cuu.Name = "colma_tra_cuu";
            this.colma_tra_cuu.Visible = true;
            this.colma_tra_cuu.VisibleIndex = 1;
            this.colma_tra_cuu.Width = 116;
            // 
            // colten_nha_cung_cap
            // 
            this.colten_nha_cung_cap.Caption = "Tên nhà cung cấp";
            this.colten_nha_cung_cap.FieldName = "ten_nha_cung_cap";
            this.colten_nha_cung_cap.Name = "colten_nha_cung_cap";
            this.colten_nha_cung_cap.Visible = true;
            this.colten_nha_cung_cap.VisibleIndex = 3;
            this.colten_nha_cung_cap.Width = 256;
            // 
            // colma_nha_cung_cap
            // 
            this.colma_nha_cung_cap.FieldName = "ma_nha_cung_cap";
            this.colma_nha_cung_cap.Name = "colma_nha_cung_cap";
            // 
            // colmo_ta
            // 
            this.colmo_ta.FieldName = "mo_ta";
            this.colmo_ta.Name = "colmo_ta";
            // 
            // colda_xoa
            // 
            this.colda_xoa.Caption = "Đã xóa";
            this.colda_xoa.FieldName = "da_xoa";
            this.colda_xoa.Name = "colda_xoa";
            this.colda_xoa.Visible = true;
            this.colda_xoa.VisibleIndex = 4;
            this.colda_xoa.Width = 107;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.layoutControlItem6,
            this.layoutControlItem7});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(963, 439);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.m_grc_hang_hoa;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 47);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(943, 330);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.m_btn_xoa;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(827, 377);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(116, 42);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.m_btn_sua;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(664, 377);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(163, 42);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.m_btn_them;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(510, 377);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(154, 42);
            this.layoutControlItem5.Text = "layoutControlItem5";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextToControlDistance = 0;
            this.layoutControlItem5.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(255, 377);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(255, 42);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.c01_search_box1;
            this.layoutControlItem4.CustomizationFormText = "layoutControlItem4";
            this.layoutControlItem4.Location = new System.Drawing.Point(349, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(594, 47);
            this.layoutControlItem4.Text = "layoutControlItem4";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextToControlDistance = 0;
            this.layoutControlItem4.TextVisible = false;
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.Control = this.lbl_loading;
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 377);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(255, 42);
            this.layoutControlItem6.Text = "layoutControlItem6";
            this.layoutControlItem6.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem6.TextToControlDistance = 0;
            this.layoutControlItem6.TextVisible = false;
            // 
            // layoutControlItem7
            // 
            this.layoutControlItem7.Control = this.panel1;
            this.layoutControlItem7.CustomizationFormText = "layoutControlItem7";
            this.layoutControlItem7.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem7.Name = "layoutControlItem7";
            this.layoutControlItem7.Size = new System.Drawing.Size(349, 47);
            this.layoutControlItem7.Text = "layoutControlItem7";
            this.layoutControlItem7.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem7.TextToControlDistance = 0;
            this.layoutControlItem7.TextVisible = false;
            // 
            // f30_danh_muc_hang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(963, 439);
            this.Controls.Add(this.layoutControl1);
            this.Name = "f30_danh_muc_hang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "F30 - Danh mục hàng hóa";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_grc_hang_hoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.themHangHoaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_grv_hang_hoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem7)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraEditors.SimpleButton m_btn_them;
        private DevExpress.XtraEditors.SimpleButton m_btn_sua;
        private DevExpress.XtraEditors.SimpleButton m_btn_xoa;
        private DevExpress.XtraGrid.GridControl m_grc_hang_hoa;
        private DevExpress.XtraGrid.Views.Grid.GridView m_grv_hang_hoa;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox m_cbb_loai_hang;
        private System.Windows.Forms.Label lbl_loading;
        private Controls.c01_search_box c01_search_box1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem7;
        private System.Windows.Forms.BindingSource themHangHoaBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colid;
        private DevExpress.XtraGrid.Columns.GridColumn colten_hang_hoa;
        private DevExpress.XtraGrid.Columns.GridColumn colma_tra_cuu;
        private DevExpress.XtraGrid.Columns.GridColumn colten_nha_cung_cap;
        private DevExpress.XtraGrid.Columns.GridColumn colma_nha_cung_cap;
        private DevExpress.XtraGrid.Columns.GridColumn colmo_ta;
        private DevExpress.XtraGrid.Columns.GridColumn colda_xoa;
    }
}