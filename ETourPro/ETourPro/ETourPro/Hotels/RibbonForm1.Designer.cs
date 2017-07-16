namespace ETourPro.Hotels
{
    partial class RibbonForm1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RibbonForm1));
            this.btnCencel = new DevComponents.DotNetBar.ButtonX();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.imageSlider1 = new DevExpress.XtraEditors.Controls.ImageSlider();
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.checkButton1 = new DevExpress.XtraEditors.CheckButton();
            this.dxValidationProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(this.components);
            this.xtraTreeListBlending1 = new DevExpress.XtraTreeList.Blending.XtraTreeListBlending();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.vGridControl1 = new DevExpress.XtraVerticalGrid.VGridControl();
            this.hDVBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.eTourDataSet = new ETourPro.ETourDataSet();
            this.rowID = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowHo = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTen = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowNgaySinh = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowGioiTinh = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowDiaChi = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowQuocGia = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowDienThoai = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.rowTrangThai = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.hDVTableAdapter = new ETourPro.ETourDataSetTableAdapters.HDVTableAdapter();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTen = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgaySinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGioiTinh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDiaChi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQuocGia = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDienThoai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrangThai = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridSplitContainer1 = new DevExpress.XtraGrid.GridSplitContainer();
            this.imageSlider2 = new DevExpress.XtraEditors.Controls.ImageSlider();
            this.filterControl1 = new DevExpress.XtraEditors.FilterControl();
            this.ribbonViewSelector1 = new DevExpress.XtraScheduler.UI.RibbonViewSelector(this.components);
            this.hdvTableAdapter1 = new ETourPro.ETourDataSetTableAdapters.HDVTableAdapter();
            this.searchLookUpEdit1 = new DevExpress.XtraEditors.SearchLookUpEdit();
            this.searchLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lookUpEdit1 = new DevExpress.XtraEditors.LookUpEdit();
            this.eTourDataSet1 = new ETourPro.ETourDataSet();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hDVBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eTourDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1)).BeginInit();
            this.gridSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonViewSelector1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eTourDataSet1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCencel
            // 
            this.btnCencel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCencel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCencel.Location = new System.Drawing.Point(932, 510);
            this.btnCencel.Name = "btnCencel";
            this.btnCencel.Size = new System.Drawing.Size(75, 23);
            this.btnCencel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCencel.TabIndex = 28;
            this.btnCencel.Text = "Cencel";
            this.btnCencel.Click += new System.EventHandler(this.btnCencel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpdate.Location = new System.Drawing.Point(770, 510);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUpdate.TabIndex = 27;
            this.btnUpdate.Text = "Update";
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(851, 510);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd.TabIndex = 26;
            this.btnAdd.Text = "Add";
            // 
            // progressPanel1
            // 
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progressPanel1.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.Appearance.Options.UseFont = true;
            this.progressPanel1.Appearance.Options.UseForeColor = true;
            this.progressPanel1.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.progressPanel1.AppearanceCaption.Options.UseFont = true;
            this.progressPanel1.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.progressPanel1.AppearanceDescription.Options.UseFont = true;
            this.progressPanel1.Description = "Etour Pro ...";
            this.progressPanel1.Location = new System.Drawing.Point(867, 13);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(140, 37);
            this.progressPanel1.TabIndex = 29;
            this.progressPanel1.Text = "Hello";
            // 
            // imageSlider1
            // 
            this.imageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("imageSlider1.Images"))));
            this.imageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("imageSlider1.Images1"))));
            this.imageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("imageSlider1.Images2"))));
            this.imageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("imageSlider1.Images3"))));
            this.imageSlider1.Images.Add(((System.Drawing.Image)(resources.GetObject("imageSlider1.Images4"))));
            this.imageSlider1.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.Stretch;
            this.imageSlider1.Location = new System.Drawing.Point(639, 56);
            this.imageSlider1.Name = "imageSlider1";
            this.imageSlider1.Size = new System.Drawing.Size(359, 220);
            this.imageSlider1.TabIndex = 30;
            this.imageSlider1.Text = "imageSlider1";
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Location = new System.Drawing.Point(610, 346);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Size = new System.Drawing.Size(333, 18);
            this.progressBarControl1.TabIndex = 31;
            // 
            // checkButton1
            // 
            this.checkButton1.Location = new System.Drawing.Point(368, 286);
            this.checkButton1.Name = "checkButton1";
            this.checkButton1.Size = new System.Drawing.Size(75, 23);
            this.checkButton1.TabIndex = 32;
            this.checkButton1.Text = "checkButton1";
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // vGridControl1
            // 
            this.vGridControl1.DataSource = this.hDVBindingSource;
            this.vGridControl1.Location = new System.Drawing.Point(43, 13);
            this.vGridControl1.Name = "vGridControl1";
            this.vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.rowID,
            this.rowHo,
            this.rowTen,
            this.rowNgaySinh,
            this.rowGioiTinh,
            this.rowDiaChi,
            this.rowQuocGia,
            this.rowDienThoai,
            this.rowTrangThai});
            this.vGridControl1.Size = new System.Drawing.Size(400, 200);
            this.vGridControl1.TabIndex = 33;
            // 
            // hDVBindingSource
            // 
            this.hDVBindingSource.DataMember = "HDV";
            this.hDVBindingSource.DataSource = this.eTourDataSet;
            // 
            // eTourDataSet
            // 
            this.eTourDataSet.DataSetName = "ETourDataSet";
            this.eTourDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // rowID
            // 
            this.rowID.Name = "rowID";
            this.rowID.Properties.Caption = "ID";
            this.rowID.Properties.FieldName = "ID";
            // 
            // rowHo
            // 
            this.rowHo.Name = "rowHo";
            this.rowHo.Properties.Caption = "Ho";
            this.rowHo.Properties.FieldName = "Ho";
            // 
            // rowTen
            // 
            this.rowTen.Name = "rowTen";
            this.rowTen.Properties.Caption = "Ten";
            this.rowTen.Properties.FieldName = "Ten";
            // 
            // rowNgaySinh
            // 
            this.rowNgaySinh.Name = "rowNgaySinh";
            this.rowNgaySinh.Properties.Caption = "Ngay Sinh";
            this.rowNgaySinh.Properties.FieldName = "NgaySinh";
            // 
            // rowGioiTinh
            // 
            this.rowGioiTinh.Name = "rowGioiTinh";
            this.rowGioiTinh.Properties.Caption = "Gioi Tinh";
            this.rowGioiTinh.Properties.FieldName = "GioiTinh";
            // 
            // rowDiaChi
            // 
            this.rowDiaChi.Name = "rowDiaChi";
            this.rowDiaChi.Properties.Caption = "Dia Chi";
            this.rowDiaChi.Properties.FieldName = "DiaChi";
            // 
            // rowQuocGia
            // 
            this.rowQuocGia.Name = "rowQuocGia";
            this.rowQuocGia.Properties.Caption = "Quoc Gia";
            this.rowQuocGia.Properties.FieldName = "QuocGia";
            // 
            // rowDienThoai
            // 
            this.rowDienThoai.Name = "rowDienThoai";
            this.rowDienThoai.Properties.Caption = "Dien Thoai";
            this.rowDienThoai.Properties.FieldName = "DienThoai";
            // 
            // rowTrangThai
            // 
            this.rowTrangThai.Name = "rowTrangThai";
            this.rowTrangThai.Properties.Caption = "Trang Thai";
            this.rowTrangThai.Properties.FieldName = "TrangThai";
            // 
            // hDVTableAdapter
            // 
            this.hDVTableAdapter.ClearBeforeFill = true;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.hDVBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(17, 230);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.ShowOnlyPredefinedDetails = true;
            this.gridControl1.Size = new System.Drawing.Size(400, 200);
            this.gridControl1.TabIndex = 34;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colHo,
            this.colTen,
            this.colNgaySinh,
            this.colGioiTinh,
            this.colDiaChi,
            this.colQuocGia,
            this.colDienThoai,
            this.colTrangThai});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            // 
            // colHo
            // 
            this.colHo.FieldName = "Ho";
            this.colHo.Name = "colHo";
            this.colHo.Visible = true;
            this.colHo.VisibleIndex = 1;
            // 
            // colTen
            // 
            this.colTen.FieldName = "Ten";
            this.colTen.Name = "colTen";
            this.colTen.Visible = true;
            this.colTen.VisibleIndex = 2;
            // 
            // colNgaySinh
            // 
            this.colNgaySinh.FieldName = "NgaySinh";
            this.colNgaySinh.Name = "colNgaySinh";
            this.colNgaySinh.Visible = true;
            this.colNgaySinh.VisibleIndex = 3;
            // 
            // colGioiTinh
            // 
            this.colGioiTinh.FieldName = "GioiTinh";
            this.colGioiTinh.Name = "colGioiTinh";
            this.colGioiTinh.Visible = true;
            this.colGioiTinh.VisibleIndex = 4;
            // 
            // colDiaChi
            // 
            this.colDiaChi.FieldName = "DiaChi";
            this.colDiaChi.Name = "colDiaChi";
            this.colDiaChi.Visible = true;
            this.colDiaChi.VisibleIndex = 5;
            // 
            // colQuocGia
            // 
            this.colQuocGia.FieldName = "QuocGia";
            this.colQuocGia.Name = "colQuocGia";
            this.colQuocGia.Visible = true;
            this.colQuocGia.VisibleIndex = 6;
            // 
            // colDienThoai
            // 
            this.colDienThoai.FieldName = "DienThoai";
            this.colDienThoai.Name = "colDienThoai";
            this.colDienThoai.Visible = true;
            this.colDienThoai.VisibleIndex = 7;
            // 
            // colTrangThai
            // 
            this.colTrangThai.FieldName = "TrangThai";
            this.colTrangThai.Name = "colTrangThai";
            this.colTrangThai.Visible = true;
            this.colTrangThai.VisibleIndex = 8;
            // 
            // gridSplitContainer1
            // 
            this.gridSplitContainer1.Grid = null;
            this.gridSplitContainer1.Location = new System.Drawing.Point(520, -188);
            this.gridSplitContainer1.Name = "gridSplitContainer1";
            this.gridSplitContainer1.Panel1.Controls.Add(this.imageSlider2);
            this.gridSplitContainer1.Panel1.Text = "Panel1";
            this.gridSplitContainer1.Panel2.Text = "Panel2";
            this.gridSplitContainer1.Size = new System.Drawing.Size(400, 400);
            this.gridSplitContainer1.TabIndex = 35;
            this.gridSplitContainer1.Text = "gridSplitContainer1";
            // 
            // imageSlider2
            // 
            this.imageSlider2.AnimationTime = 0;
            this.imageSlider2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("imageSlider2.BackgroundImage")));
            this.imageSlider2.Images.Add(((System.Drawing.Image)(resources.GetObject("imageSlider2.Images"))));
            this.imageSlider2.Images.Add(((System.Drawing.Image)(resources.GetObject("imageSlider2.Images1"))));
            this.imageSlider2.Images.Add(((System.Drawing.Image)(resources.GetObject("imageSlider2.Images2"))));
            this.imageSlider2.LayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.Stretch;
            this.imageSlider2.Location = new System.Drawing.Point(4, 51);
            this.imageSlider2.Name = "imageSlider2";
            this.imageSlider2.Size = new System.Drawing.Size(392, 298);
            this.imageSlider2.TabIndex = 30;
            this.imageSlider2.Text = "imageSlider2";
            // 
            // filterControl1
            // 
            this.filterControl1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.filterControl1.Location = new System.Drawing.Point(449, 264);
            this.filterControl1.Name = "filterControl1";
            this.filterControl1.Size = new System.Drawing.Size(200, 100);
            this.filterControl1.TabIndex = 36;
            this.filterControl1.Text = "filterControl1";
            // 
            // ribbonViewSelector1
            // 
            this.ribbonViewSelector1.TargetRibbonPageName = null;
            // 
            // hdvTableAdapter1
            // 
            this.hdvTableAdapter1.ClearBeforeFill = true;
            // 
            // searchLookUpEdit1
            // 
            this.searchLookUpEdit1.Location = new System.Drawing.Point(467, 395);
            this.searchLookUpEdit1.Name = "searchLookUpEdit1";
            this.searchLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.searchLookUpEdit1.Properties.View = this.searchLookUpEdit1View;
            this.searchLookUpEdit1.Size = new System.Drawing.Size(100, 20);
            this.searchLookUpEdit1.TabIndex = 37;
            // 
            // searchLookUpEdit1View
            // 
            this.searchLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.searchLookUpEdit1View.Name = "searchLookUpEdit1View";
            this.searchLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.searchLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // lookUpEdit1
            // 
            this.lookUpEdit1.Location = new System.Drawing.Point(449, 210);
            this.lookUpEdit1.Name = "lookUpEdit1";
            this.lookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit1.Size = new System.Drawing.Size(100, 20);
            this.lookUpEdit1.TabIndex = 38;
            // 
            // eTourDataSet1
            // 
            this.eTourDataSet1.DataSetName = "ETourDataSet";
            this.eTourDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // RibbonForm1
            // 
            this.ClientSize = new System.Drawing.Size(1015, 537);
            this.Controls.Add(this.lookUpEdit1);
            this.Controls.Add(this.searchLookUpEdit1);
            this.Controls.Add(this.filterControl1);
            this.Controls.Add(this.gridSplitContainer1);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.vGridControl1);
            this.Controls.Add(this.checkButton1);
            this.Controls.Add(this.progressBarControl1);
            this.Controls.Add(this.imageSlider1);
            this.Controls.Add(this.progressPanel1);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnCencel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RibbonForm1";
            this.Text = "RibbonForm1";
            this.Load += new System.EventHandler(this.RibbonForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxValidationProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hDVBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eTourDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1)).EndInit();
            this.gridSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonViewSelector1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eTourDataSet1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnCencel;
        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private DevExpress.XtraEditors.Controls.ImageSlider imageSlider1;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private DevExpress.XtraEditors.CheckButton checkButton1;
        private DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider dxValidationProvider1;
        private DevExpress.XtraTreeList.Blending.XtraTreeListBlending xtraTreeListBlending1;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevExpress.XtraVerticalGrid.VGridControl vGridControl1;
        private ETourDataSet eTourDataSet;
        private System.Windows.Forms.BindingSource hDVBindingSource;
        private ETourDataSetTableAdapters.HDVTableAdapter hDVTableAdapter;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowID;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowHo;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTen;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowNgaySinh;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowGioiTinh;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDiaChi;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowQuocGia;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowDienThoai;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow rowTrangThai;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colHo;
        private DevExpress.XtraGrid.Columns.GridColumn colTen;
        private DevExpress.XtraGrid.Columns.GridColumn colNgaySinh;
        private DevExpress.XtraGrid.Columns.GridColumn colGioiTinh;
        private DevExpress.XtraGrid.Columns.GridColumn colDiaChi;
        private DevExpress.XtraGrid.Columns.GridColumn colQuocGia;
        private DevExpress.XtraGrid.Columns.GridColumn colDienThoai;
        private DevExpress.XtraGrid.Columns.GridColumn colTrangThai;
        private DevExpress.XtraGrid.GridSplitContainer gridSplitContainer1;
        private DevExpress.XtraEditors.Controls.ImageSlider imageSlider2;
        private DevExpress.XtraEditors.FilterControl filterControl1;
        private DevExpress.XtraScheduler.UI.RibbonViewSelector ribbonViewSelector1;
        private ETourDataSetTableAdapters.HDVTableAdapter hdvTableAdapter1;
        private DevExpress.XtraEditors.SearchLookUpEdit searchLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView searchLookUpEdit1View;
        private DevExpress.XtraEditors.LookUpEdit lookUpEdit1;
        private ETourDataSet eTourDataSet1;
    }
}