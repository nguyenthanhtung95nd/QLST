namespace QLST
{
    partial class NCC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NCC));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtSDTNCC = new DevExpress.XtraEditors.TextEdit();
            this.txtDCNCC = new DevExpress.XtraEditors.TextEdit();
            this.txtTenNCC = new DevExpress.XtraEditors.TextEdit();
            this.txtMaNCC = new DevExpress.XtraEditors.TextEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.lblMaNCC = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblTenNCC = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblDiaChiNCC = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblSDTNCC = new DevExpress.XtraLayout.LayoutControlItem();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnTaiDanhSachNCC = new DevExpress.XtraBars.BarButtonItem();
            this.btnThemNCC = new DevExpress.XtraBars.BarButtonItem();
            this.btnXoaNCC = new DevExpress.XtraBars.BarButtonItem();
            this.btnSuaNCC = new DevExpress.XtraBars.BarButtonItem();
            this.btnLuuNCC = new DevExpress.XtraBars.BarButtonItem();
            this.btnHuyNCC = new DevExpress.XtraBars.BarButtonItem();
            this.btnThoatNCC = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MaNCC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TenNCC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.DCNCC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.SDTNCC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDTNCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDCNCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMaNCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTenNCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDiaChiNCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSDTNCC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtSDTNCC);
            this.layoutControl1.Controls.Add(this.txtDCNCC);
            this.layoutControl1.Controls.Add(this.txtTenNCC);
            this.layoutControl1.Controls.Add(this.txtMaNCC);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.layoutControl1.Location = new System.Drawing.Point(0, 40);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(712, 117);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtSDTNCC
            // 
            this.txtSDTNCC.Location = new System.Drawing.Point(114, 84);
            this.txtSDTNCC.Name = "txtSDTNCC";
            this.txtSDTNCC.Properties.Mask.EditMask = "\\d{10,11}";
            this.txtSDTNCC.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSDTNCC.Size = new System.Drawing.Size(586, 20);
            this.txtSDTNCC.StyleController = this.layoutControl1;
            this.txtSDTNCC.TabIndex = 4;
            // 
            // txtDCNCC
            // 
            this.txtDCNCC.Location = new System.Drawing.Point(114, 60);
            this.txtDCNCC.Name = "txtDCNCC";
            this.txtDCNCC.Size = new System.Drawing.Size(586, 20);
            this.txtDCNCC.StyleController = this.layoutControl1;
            this.txtDCNCC.TabIndex = 3;
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Location = new System.Drawing.Point(114, 36);
            this.txtTenNCC.Name = "txtTenNCC";
            this.txtTenNCC.Size = new System.Drawing.Size(586, 20);
            this.txtTenNCC.StyleController = this.layoutControl1;
            this.txtTenNCC.TabIndex = 2;
            // 
            // txtMaNCC
            // 
            this.txtMaNCC.Location = new System.Drawing.Point(114, 12);
            this.txtMaNCC.Name = "txtMaNCC";
            this.txtMaNCC.Size = new System.Drawing.Size(586, 20);
            this.txtMaNCC.StyleController = this.layoutControl1;
            this.txtMaNCC.TabIndex = 0;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lblMaNCC,
            this.lblTenNCC,
            this.lblDiaChiNCC,
            this.lblSDTNCC});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(712, 117);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // lblMaNCC
            // 
            this.lblMaNCC.Control = this.txtMaNCC;
            this.lblMaNCC.Location = new System.Drawing.Point(0, 0);
            this.lblMaNCC.Name = "lblMaNCC";
            this.lblMaNCC.Size = new System.Drawing.Size(692, 24);
            this.lblMaNCC.Text = "Mã nhà cung cấp";
            this.lblMaNCC.TextSize = new System.Drawing.Size(99, 13);
            // 
            // lblTenNCC
            // 
            this.lblTenNCC.Control = this.txtTenNCC;
            this.lblTenNCC.Location = new System.Drawing.Point(0, 24);
            this.lblTenNCC.Name = "lblTenNCC";
            this.lblTenNCC.Size = new System.Drawing.Size(692, 24);
            this.lblTenNCC.Text = "Tên nhà cung cấp";
            this.lblTenNCC.TextSize = new System.Drawing.Size(99, 13);
            // 
            // lblDiaChiNCC
            // 
            this.lblDiaChiNCC.Control = this.txtDCNCC;
            this.lblDiaChiNCC.Location = new System.Drawing.Point(0, 48);
            this.lblDiaChiNCC.Name = "lblDiaChiNCC";
            this.lblDiaChiNCC.Size = new System.Drawing.Size(692, 24);
            this.lblDiaChiNCC.Text = "Địa chỉ nhà cung cấp";
            this.lblDiaChiNCC.TextSize = new System.Drawing.Size(99, 13);
            // 
            // lblSDTNCC
            // 
            this.lblSDTNCC.Control = this.txtSDTNCC;
            this.lblSDTNCC.Location = new System.Drawing.Point(0, 72);
            this.lblSDTNCC.Name = "lblSDTNCC";
            this.lblSDTNCC.Size = new System.Drawing.Size(692, 25);
            this.lblSDTNCC.Text = "SDT nhà cung cấp";
            this.lblSDTNCC.TextSize = new System.Drawing.Size(99, 13);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThemNCC,
            this.btnTaiDanhSachNCC,
            this.btnXoaNCC,
            this.btnSuaNCC,
            this.btnLuuNCC,
            this.btnHuyNCC,
            this.btnThoatNCC});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 7;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnTaiDanhSachNCC, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThemNCC, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnXoaNCC, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnSuaNCC, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnLuuNCC, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnHuyNCC, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnThoatNCC, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnTaiDanhSachNCC
            // 
            this.btnTaiDanhSachNCC.Caption = "Tải danh sách";
            this.btnTaiDanhSachNCC.Glyph = ((System.Drawing.Image)(resources.GetObject("btnTaiDanhSachNCC.Glyph")));
            this.btnTaiDanhSachNCC.Id = 1;
            this.btnTaiDanhSachNCC.Name = "btnTaiDanhSachNCC";
            this.btnTaiDanhSachNCC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnTaiDanhSachNCC_ItemClick);
            // 
            // btnThemNCC
            // 
            this.btnThemNCC.Caption = "Thêm";
            this.btnThemNCC.Glyph = ((System.Drawing.Image)(resources.GetObject("btnThemNCC.Glyph")));
            this.btnThemNCC.Id = 0;
            this.btnThemNCC.Name = "btnThemNCC";
            this.btnThemNCC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThemNCC_ItemClick);
            // 
            // btnXoaNCC
            // 
            this.btnXoaNCC.Caption = "Xoá";
            this.btnXoaNCC.Glyph = ((System.Drawing.Image)(resources.GetObject("btnXoaNCC.Glyph")));
            this.btnXoaNCC.Id = 2;
            this.btnXoaNCC.Name = "btnXoaNCC";
            this.btnXoaNCC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnXoaNCC_ItemClick);
            // 
            // btnSuaNCC
            // 
            this.btnSuaNCC.Caption = "Sửa";
            this.btnSuaNCC.Glyph = ((System.Drawing.Image)(resources.GetObject("btnSuaNCC.Glyph")));
            this.btnSuaNCC.Id = 3;
            this.btnSuaNCC.Name = "btnSuaNCC";
            this.btnSuaNCC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSuaNCC_ItemClick);
            // 
            // btnLuuNCC
            // 
            this.btnLuuNCC.Caption = "Lưu";
            this.btnLuuNCC.Glyph = ((System.Drawing.Image)(resources.GetObject("btnLuuNCC.Glyph")));
            this.btnLuuNCC.Id = 4;
            this.btnLuuNCC.Name = "btnLuuNCC";
            this.btnLuuNCC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnLuuNCC_ItemClick);
            // 
            // btnHuyNCC
            // 
            this.btnHuyNCC.Caption = "Huỷ";
            this.btnHuyNCC.Glyph = ((System.Drawing.Image)(resources.GetObject("btnHuyNCC.Glyph")));
            this.btnHuyNCC.Id = 5;
            this.btnHuyNCC.Name = "btnHuyNCC";
            this.btnHuyNCC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnHuyNCC_ItemClick);
            // 
            // btnThoatNCC
            // 
            this.btnThoatNCC.Caption = "Thoát";
            this.btnThoatNCC.Glyph = ((System.Drawing.Image)(resources.GetObject("btnThoatNCC.Glyph")));
            this.btnThoatNCC.Id = 6;
            this.btnThoatNCC.Name = "btnThoatNCC";
            this.btnThoatNCC.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnThoatNCC_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(712, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 418);
            this.barDockControlBottom.Size = new System.Drawing.Size(712, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 378);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(712, 40);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 378);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.MaNCC,
            this.TenNCC,
            this.DCNCC,
            this.SDTNCC});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // MaNCC
            // 
            this.MaNCC.Caption = "Mã nhà cung cấp";
            this.MaNCC.FieldName = "MaNCC";
            this.MaNCC.Name = "MaNCC";
            this.MaNCC.OptionsColumn.AllowEdit = false;
            this.MaNCC.OptionsColumn.ReadOnly = true;
            this.MaNCC.Visible = true;
            this.MaNCC.VisibleIndex = 0;
            // 
            // TenNCC
            // 
            this.TenNCC.Caption = "Tên nhà cung cấp";
            this.TenNCC.FieldName = "TenNCC";
            this.TenNCC.Name = "TenNCC";
            this.TenNCC.OptionsColumn.AllowEdit = false;
            this.TenNCC.OptionsColumn.ReadOnly = true;
            this.TenNCC.Visible = true;
            this.TenNCC.VisibleIndex = 1;
            // 
            // DCNCC
            // 
            this.DCNCC.Caption = "Địa chỉ nhà cung cấp";
            this.DCNCC.FieldName = "DCNCC";
            this.DCNCC.Name = "DCNCC";
            this.DCNCC.OptionsColumn.AllowEdit = false;
            this.DCNCC.OptionsColumn.ReadOnly = true;
            this.DCNCC.Visible = true;
            this.DCNCC.VisibleIndex = 2;
            // 
            // SDTNCC
            // 
            this.SDTNCC.Caption = "SDT nhà cung cấp";
            this.SDTNCC.FieldName = "SDTNCC";
            this.SDTNCC.Name = "SDTNCC";
            this.SDTNCC.OptionsColumn.AllowEdit = false;
            this.SDTNCC.OptionsColumn.ReadOnly = true;
            this.SDTNCC.Visible = true;
            this.SDTNCC.VisibleIndex = 3;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 157);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(712, 261);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Click += new System.EventHandler(this.gridControl1_Click);
            // 
            // NCC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(712, 418);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.layoutControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "NCC";
            this.Text = "NHÀ CUNG CẤP";
            this.Load += new System.EventHandler(this.NCC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSDTNCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDCNCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMaNCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblMaNCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblTenNCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDiaChiNCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblSDTNCC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtSDTNCC;
        private DevExpress.XtraEditors.TextEdit txtDCNCC;
        private DevExpress.XtraEditors.TextEdit txtTenNCC;
        private DevExpress.XtraEditors.TextEdit txtMaNCC;
        private DevExpress.XtraLayout.LayoutControlItem lblMaNCC;
        private DevExpress.XtraLayout.LayoutControlItem lblTenNCC;
        private DevExpress.XtraLayout.LayoutControlItem lblDiaChiNCC;
        private DevExpress.XtraLayout.LayoutControlItem lblSDTNCC;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem btnTaiDanhSachNCC;
        private DevExpress.XtraBars.BarButtonItem btnThemNCC;
        private DevExpress.XtraBars.BarButtonItem btnXoaNCC;
        private DevExpress.XtraBars.BarButtonItem btnSuaNCC;
        private DevExpress.XtraBars.BarButtonItem btnLuuNCC;
        private DevExpress.XtraBars.BarButtonItem btnHuyNCC;
        private DevExpress.XtraBars.BarButtonItem btnThoatNCC;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn MaNCC;
        private DevExpress.XtraGrid.Columns.GridColumn TenNCC;
        private DevExpress.XtraGrid.Columns.GridColumn DCNCC;
        private DevExpress.XtraGrid.Columns.GridColumn SDTNCC;
    }
}