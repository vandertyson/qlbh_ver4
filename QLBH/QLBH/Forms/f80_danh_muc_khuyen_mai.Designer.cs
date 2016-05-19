namespace QLBH.Forms
{
    partial class f80_danh_muc_khuyen_mai
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f80_danh_muc_khuyen_mai));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.m_btn_xoa_dot_km = new DevExpress.XtraEditors.SimpleButton();
            this.m_btn_chi_tiet = new DevExpress.XtraEditors.SimpleButton();
            this.m_grc_khuyen_mai = new DevExpress.XtraGrid.GridControl();
            this.m_grv_khuyen_mai = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_grc_khuyen_mai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_grv_khuyen_mai)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.m_btn_xoa_dot_km);
            this.layoutControl1.Controls.Add(this.m_btn_chi_tiet);
            this.layoutControl1.Controls.Add(this.m_grc_khuyen_mai);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(613, 122, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(753, 424);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // m_btn_xoa_dot_km
            // 
            this.m_btn_xoa_dot_km.Image = ((System.Drawing.Image)(resources.GetObject("m_btn_xoa_dot_km.Image")));
            this.m_btn_xoa_dot_km.Location = new System.Drawing.Point(521, 374);
            this.m_btn_xoa_dot_km.Name = "m_btn_xoa_dot_km";
            this.m_btn_xoa_dot_km.Size = new System.Drawing.Size(220, 38);
            this.m_btn_xoa_dot_km.StyleController = this.layoutControl1;
            this.m_btn_xoa_dot_km.TabIndex = 6;
            this.m_btn_xoa_dot_km.Text = "Xóa đợt khuyến mãi";
            // 
            // m_btn_chi_tiet
            // 
            this.m_btn_chi_tiet.Image = ((System.Drawing.Image)(resources.GetObject("m_btn_chi_tiet.Image")));
            this.m_btn_chi_tiet.Location = new System.Drawing.Point(298, 374);
            this.m_btn_chi_tiet.Name = "m_btn_chi_tiet";
            this.m_btn_chi_tiet.Size = new System.Drawing.Size(219, 38);
            this.m_btn_chi_tiet.StyleController = this.layoutControl1;
            this.m_btn_chi_tiet.TabIndex = 5;
            this.m_btn_chi_tiet.Text = "Chi tiết khuyến mãi";
            // 
            // m_grc_khuyen_mai
            // 
            this.m_grc_khuyen_mai.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_grc_khuyen_mai.Location = new System.Drawing.Point(12, 12);
            this.m_grc_khuyen_mai.MainView = this.m_grv_khuyen_mai;
            this.m_grc_khuyen_mai.Name = "m_grc_khuyen_mai";
            this.m_grc_khuyen_mai.Size = new System.Drawing.Size(729, 358);
            this.m_grc_khuyen_mai.TabIndex = 4;
            this.m_grc_khuyen_mai.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.m_grv_khuyen_mai});
            // 
            // m_grv_khuyen_mai
            // 
            this.m_grv_khuyen_mai.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4});
            this.m_grv_khuyen_mai.GridControl = this.m_grc_khuyen_mai;
            this.m_grv_khuyen_mai.Name = "m_grv_khuyen_mai";
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã đợt";
            this.gridColumn1.FieldName = "ma_dot";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Mô tả";
            this.gridColumn2.FieldName = "mo_ta";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Thời gian bắt đầu";
            this.gridColumn3.FieldName = "tg_bat_dau";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Thời gian kết thúc";
            this.gridColumn4.FieldName = "tg_ket_thuc";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(753, 424);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.m_grc_khuyen_mai;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(733, 362);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.m_btn_chi_tiet;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(286, 362);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(223, 42);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.CustomizationFormText = "emptySpaceItem1";
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 362);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(286, 42);
            this.emptySpaceItem1.Text = "emptySpaceItem1";
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.m_btn_xoa_dot_km;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(509, 362);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(224, 42);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // f80_danh_muc_khuyen_mai
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(753, 424);
            this.Controls.Add(this.layoutControl1);
            this.Name = "f80_danh_muc_khuyen_mai";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "f80_danh_muc_khuyen_mai";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_grc_khuyen_mai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_grv_khuyen_mai)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SimpleButton m_btn_chi_tiet;
        private DevExpress.XtraGrid.GridControl m_grc_khuyen_mai;
        private DevExpress.XtraGrid.Views.Grid.GridView m_grv_khuyen_mai;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton m_btn_xoa_dot_km;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}