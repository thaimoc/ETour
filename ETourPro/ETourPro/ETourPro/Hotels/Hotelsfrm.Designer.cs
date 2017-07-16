namespace ETourPro.Hotels
{
    partial class Hotelsfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Hotelsfrm));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnCencel = new DevComponents.DotNetBar.ButtonX();
            this.btnUpdate = new DevComponents.DotNetBar.ButtonX();
            this.btnAdd = new DevComponents.DotNetBar.ButtonX();
            this.btnAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearchKey = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtSearchKey = new DevExpress.XtraEditors.TextEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSearchOption = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cbbColumn = new System.Windows.Forms.ComboBox();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtValueField = new DevExpress.XtraEditors.TextEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.superTabControl1 = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel3 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.lvHotels = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.superTabItem2 = new DevComponents.DotNetBar.SuperTabItem();
            this.tbControl = new DevComponents.DotNetBar.SuperTabControl();
            this.superTabControlPanel1 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.lvScenics = new System.Windows.Forms.ListView();
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tbpvehicles = new DevComponents.DotNetBar.SuperTabItem();
            this.superTabControlPanel2 = new DevComponents.DotNetBar.SuperTabControlPanel();
            this.lvTours = new System.Windows.Forms.ListView();
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.superTabItem1 = new DevComponents.DotNetBar.SuperTabItem();
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchKey.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValueField.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).BeginInit();
            this.superTabControl1.SuspendLayout();
            this.superTabControlPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbControl)).BeginInit();
            this.tbControl.SuspendLayout();
            this.superTabControlPanel1.SuspendLayout();
            this.superTabControlPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitContainer1.Location = new System.Drawing.Point(731, 1);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.progressPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.btnUpdate);
            this.splitContainer1.Panel1.Controls.Add(this.btnAdd);
            this.splitContainer1.Panel1.Controls.Add(this.btnAll);
            this.splitContainer1.Panel1.Controls.Add(this.btnSearchKey);
            this.splitContainer1.Panel1.Controls.Add(this.labelControl1);
            this.splitContainer1.Panel1.Controls.Add(this.txtSearchKey);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCencel);
            this.splitContainer1.Size = new System.Drawing.Size(369, 591);
            this.splitContainer1.SplitterDistance = 479;
            this.splitContainer1.TabIndex = 1;
            // 
            // btnCencel
            // 
            this.btnCencel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCencel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnCencel.Location = new System.Drawing.Point(282, 31);
            this.btnCencel.Name = "btnCencel";
            this.btnCencel.Size = new System.Drawing.Size(75, 23);
            this.btnCencel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCencel.TabIndex = 25;
            this.btnCencel.Text = "Cencel";
            this.btnCencel.Click += new System.EventHandler(this.btnCencel_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUpdate.Location = new System.Drawing.Point(196, 184);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUpdate.TabIndex = 24;
            this.btnUpdate.Text = "Update";
            // 
            // btnAdd
            // 
            this.btnAdd.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAdd.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(115, 184);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAdd.TabIndex = 23;
            this.btnAdd.Text = "Add";
            // 
            // btnAll
            // 
            this.btnAll.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.btnAll.Appearance.BackColor2 = System.Drawing.Color.Teal;
            this.btnAll.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAll.Appearance.Options.UseBackColor = true;
            this.btnAll.Appearance.Options.UseFont = true;
            this.btnAll.Appearance.Options.UseForeColor = true;
            this.btnAll.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.btnAll.Location = new System.Drawing.Point(9, 182);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(97, 23);
            this.btnAll.TabIndex = 14;
            this.btnAll.Text = "All";
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // btnSearchKey
            // 
            this.btnSearchKey.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.btnSearchKey.Appearance.BackColor2 = System.Drawing.Color.Teal;
            this.btnSearchKey.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchKey.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSearchKey.Appearance.Options.UseBackColor = true;
            this.btnSearchKey.Appearance.Options.UseFont = true;
            this.btnSearchKey.Appearance.Options.UseForeColor = true;
            this.btnSearchKey.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.btnSearchKey.Enabled = false;
            this.btnSearchKey.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchKey.Image")));
            this.btnSearchKey.Location = new System.Drawing.Point(268, 158);
            this.btnSearchKey.Name = "btnSearchKey";
            this.btnSearchKey.Size = new System.Drawing.Size(98, 20);
            this.btnSearchKey.TabIndex = 22;
            this.btnSearchKey.Text = "Search";
            this.btnSearchKey.Click += new System.EventHandler(this.btnSearchKey_Click);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelControl1.Location = new System.Drawing.Point(9, 138);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(97, 14);
            this.labelControl1.TabIndex = 20;
            this.labelControl1.Text = "Search key words";
            // 
            // txtSearchKey
            // 
            this.txtSearchKey.Location = new System.Drawing.Point(15, 158);
            this.txtSearchKey.Name = "txtSearchKey";
            this.txtSearchKey.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.txtSearchKey.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchKey.Properties.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtSearchKey.Properties.Appearance.Options.UseBackColor = true;
            this.txtSearchKey.Properties.Appearance.Options.UseFont = true;
            this.txtSearchKey.Properties.Appearance.Options.UseForeColor = true;
            this.txtSearchKey.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txtSearchKey.Size = new System.Drawing.Size(230, 20);
            this.txtSearchKey.TabIndex = 18;
            this.txtSearchKey.EditValueChanged += new System.EventHandler(this.txtSearchKey_EditValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSearchOption);
            this.groupBox2.Controls.Add(this.labelControl2);
            this.groupBox2.Controls.Add(this.cbbColumn);
            this.groupBox2.Controls.Add(this.labelControl9);
            this.groupBox2.Controls.Add(this.txtValueField);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Location = new System.Drawing.Point(7, 32);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(360, 100);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Search Option";
            // 
            // btnSearchOption
            // 
            this.btnSearchOption.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.btnSearchOption.Appearance.BackColor2 = System.Drawing.Color.Teal;
            this.btnSearchOption.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchOption.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnSearchOption.Appearance.Options.UseBackColor = true;
            this.btnSearchOption.Appearance.Options.UseFont = true;
            this.btnSearchOption.Appearance.Options.UseForeColor = true;
            this.btnSearchOption.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.Style3D;
            this.btnSearchOption.Enabled = false;
            this.btnSearchOption.Image = ((System.Drawing.Image)(resources.GetObject("btnSearchOption.Image")));
            this.btnSearchOption.Location = new System.Drawing.Point(4, 68);
            this.btnSearchOption.Name = "btnSearchOption";
            this.btnSearchOption.Size = new System.Drawing.Size(352, 26);
            this.btnSearchOption.TabIndex = 13;
            this.btnSearchOption.Text = "Search";
            this.btnSearchOption.Click += new System.EventHandler(this.btnSearchOption_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelControl2.Location = new System.Drawing.Point(8, 45);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(90, 14);
            this.labelControl2.TabIndex = 11;
            this.labelControl2.Text = "Input key words";
            // 
            // cbbColumn
            // 
            this.cbbColumn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.cbbColumn.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.cbbColumn.FormattingEnabled = true;
            this.cbbColumn.Location = new System.Drawing.Point(108, 15);
            this.cbbColumn.Name = "cbbColumn";
            this.cbbColumn.Size = new System.Drawing.Size(246, 22);
            this.cbbColumn.TabIndex = 12;
            this.cbbColumn.SelectedIndexChanged += new System.EventHandler(this.cbbColumn_SelectedIndexChanged);
            this.cbbColumn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbbColumn_KeyPress);
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl9.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelControl9.Location = new System.Drawing.Point(8, 18);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(83, 14);
            this.labelControl9.TabIndex = 11;
            this.labelControl9.Text = "Choose column";
            // 
            // txtValueField
            // 
            this.txtValueField.Enabled = false;
            this.txtValueField.Location = new System.Drawing.Point(108, 42);
            this.txtValueField.Name = "txtValueField";
            this.txtValueField.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.txtValueField.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValueField.Properties.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtValueField.Properties.Appearance.Options.UseBackColor = true;
            this.txtValueField.Properties.Appearance.Options.UseFont = true;
            this.txtValueField.Properties.Appearance.Options.UseForeColor = true;
            this.txtValueField.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txtValueField.Size = new System.Drawing.Size(248, 20);
            this.txtValueField.TabIndex = 6;
            this.txtValueField.EditValueChanged += new System.EventHandler(this.txtValueField_EditValueChanged);
            this.txtValueField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValueField_KeyPress);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(5, 1);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.superTabControl1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.tbControl);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(726, 591);
            this.splitContainerControl1.SplitterPosition = 358;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // superTabControl1
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.superTabControl1.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.superTabControl1.ControlBox.MenuBox.Name = "";
            this.superTabControl1.ControlBox.Name = "";
            this.superTabControl1.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabControl1.ControlBox.MenuBox,
            this.superTabControl1.ControlBox.CloseBox});
            this.superTabControl1.Controls.Add(this.superTabControlPanel3);
            this.superTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControl1.Location = new System.Drawing.Point(0, 0);
            this.superTabControl1.Name = "superTabControl1";
            this.superTabControl1.ReorderTabsEnabled = true;
            this.superTabControl1.SelectedTabFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.superTabControl1.SelectedTabIndex = 0;
            this.superTabControl1.Size = new System.Drawing.Size(726, 358);
            this.superTabControl1.TabFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.superTabControl1.TabIndex = 7;
            this.superTabControl1.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.superTabItem2});
            // 
            // superTabControlPanel3
            // 
            this.superTabControlPanel3.Controls.Add(this.lvHotels);
            this.superTabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel3.Location = new System.Drawing.Point(0, 32);
            this.superTabControlPanel3.Name = "superTabControlPanel3";
            this.superTabControlPanel3.Size = new System.Drawing.Size(726, 326);
            this.superTabControlPanel3.TabIndex = 1;
            this.superTabControlPanel3.TabItem = this.superTabItem2;
            // 
            // lvHotels
            // 
            this.lvHotels.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.lvHotels.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvHotels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvHotels.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvHotels.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lvHotels.FullRowSelect = true;
            this.lvHotels.GridLines = true;
            this.lvHotels.Location = new System.Drawing.Point(0, 0);
            this.lvHotels.MultiSelect = false;
            this.lvHotels.Name = "lvHotels";
            this.lvHotels.Size = new System.Drawing.Size(726, 326);
            this.lvHotels.TabIndex = 9;
            this.lvHotels.UseCompatibleStateImageBehavior = false;
            this.lvHotels.View = System.Windows.Forms.View.Details;
            this.lvHotels.SelectedIndexChanged += new System.EventHandler(this.lvHotels_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Code";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Hotel Name";
            this.columnHeader5.Width = 180;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Start Number";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Phone";
            this.columnHeader7.Width = 120;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Address";
            this.columnHeader8.Width = 250;
            // 
            // superTabItem2
            // 
            this.superTabItem2.AttachedControl = this.superTabControlPanel3;
            this.superTabItem2.GlobalItem = false;
            this.superTabItem2.Name = "superTabItem2";
            this.superTabItem2.Text = "Hotels";
            // 
            // tbControl
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tbControl.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.tbControl.ControlBox.MenuBox.Name = "";
            this.tbControl.ControlBox.Name = "";
            this.tbControl.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tbControl.ControlBox.MenuBox,
            this.tbControl.ControlBox.CloseBox});
            this.tbControl.Controls.Add(this.superTabControlPanel1);
            this.tbControl.Controls.Add(this.superTabControlPanel2);
            this.tbControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbControl.Location = new System.Drawing.Point(0, 0);
            this.tbControl.Name = "tbControl";
            this.tbControl.ReorderTabsEnabled = true;
            this.tbControl.SelectedTabFont = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbControl.SelectedTabIndex = 0;
            this.tbControl.Size = new System.Drawing.Size(726, 228);
            this.tbControl.TabFont = new System.Drawing.Font("Tahoma", 8.25F);
            this.tbControl.TabIndex = 7;
            this.tbControl.Tabs.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tbpvehicles,
            this.superTabItem1});
            // 
            // superTabControlPanel1
            // 
            this.superTabControlPanel1.Controls.Add(this.lvScenics);
            this.superTabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel1.Location = new System.Drawing.Point(0, 32);
            this.superTabControlPanel1.Name = "superTabControlPanel1";
            this.superTabControlPanel1.Size = new System.Drawing.Size(726, 196);
            this.superTabControlPanel1.TabIndex = 1;
            this.superTabControlPanel1.TabItem = this.tbpvehicles;
            // 
            // lvScenics
            // 
            this.lvScenics.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.lvScenics.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13});
            this.lvScenics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvScenics.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvScenics.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lvScenics.FullRowSelect = true;
            this.lvScenics.GridLines = true;
            this.lvScenics.Location = new System.Drawing.Point(0, 0);
            this.lvScenics.MultiSelect = false;
            this.lvScenics.Name = "lvScenics";
            this.lvScenics.Size = new System.Drawing.Size(726, 196);
            this.lvScenics.TabIndex = 10;
            this.lvScenics.UseCompatibleStateImageBehavior = false;
            this.lvScenics.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Code";
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "Scenic Name";
            this.columnHeader11.Width = 200;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "Local Name";
            this.columnHeader12.Width = 180;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "Address";
            this.columnHeader13.Width = 300;
            // 
            // tbpvehicles
            // 
            this.tbpvehicles.AttachedControl = this.superTabControlPanel1;
            this.tbpvehicles.GlobalItem = false;
            this.tbpvehicles.Name = "tbpvehicles";
            this.tbpvehicles.Text = "Scenic";
            // 
            // superTabControlPanel2
            // 
            this.superTabControlPanel2.Controls.Add(this.lvTours);
            this.superTabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.superTabControlPanel2.Location = new System.Drawing.Point(0, 0);
            this.superTabControlPanel2.Name = "superTabControlPanel2";
            this.superTabControlPanel2.Size = new System.Drawing.Size(726, 228);
            this.superTabControlPanel2.TabIndex = 0;
            this.superTabControlPanel2.TabItem = this.superTabItem1;
            // 
            // lvTours
            // 
            this.lvTours.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.lvTours.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader14,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvTours.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTours.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTours.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lvTours.FullRowSelect = true;
            this.lvTours.GridLines = true;
            this.lvTours.Location = new System.Drawing.Point(0, 0);
            this.lvTours.MultiSelect = false;
            this.lvTours.Name = "lvTours";
            this.lvTours.Size = new System.Drawing.Size(726, 228);
            this.lvTours.TabIndex = 8;
            this.lvTours.UseCompatibleStateImageBehavior = false;
            this.lvTours.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "Code";
            this.columnHeader14.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Start Place";
            this.columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Status";
            this.columnHeader3.Width = 300;
            // 
            // superTabItem1
            // 
            this.superTabItem1.AttachedControl = this.superTabControlPanel2;
            this.superTabItem1.GlobalItem = false;
            this.superTabItem1.Name = "superTabItem1";
            this.superTabItem1.Text = "Tours";
            // 
            // progressPanel1
            // 
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.progressPanel1.AppearanceCaption.Options.UseFont = true;
            this.progressPanel1.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.progressPanel1.AppearanceDescription.Options.UseFont = true;
            this.progressPanel1.Location = new System.Drawing.Point(15, 213);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(200, 66);
            this.progressPanel1.TabIndex = 25;
            this.progressPanel1.Text = "progressPanel1";
            // 
            // Hotelsfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1105, 594);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Hotelsfrm";
            this.Text = "Hotels Manager";
            this.Load += new System.EventHandler(this.Hotelsfrm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchKey.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtValueField.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.superTabControl1)).EndInit();
            this.superTabControl1.ResumeLayout(false);
            this.superTabControlPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbControl)).EndInit();
            this.tbControl.ResumeLayout(false);
            this.superTabControlPanel1.ResumeLayout(false);
            this.superTabControlPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtSearchKey;
        private System.Windows.Forms.GroupBox groupBox2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ComboBox cbbColumn;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.TextEdit txtValueField;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevComponents.DotNetBar.SuperTabControl superTabControl1;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel3;
        private System.Windows.Forms.ListView lvHotels;
        private DevComponents.DotNetBar.SuperTabItem superTabItem2;
        private DevComponents.DotNetBar.SuperTabControl tbControl;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel1;
        private DevComponents.DotNetBar.SuperTabItem tbpvehicles;
        private DevComponents.DotNetBar.SuperTabControlPanel superTabControlPanel2;
        private System.Windows.Forms.ListView lvTours;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private DevComponents.DotNetBar.SuperTabItem superTabItem1;
        private System.Windows.Forms.ListView lvScenics;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private DevExpress.XtraEditors.SimpleButton btnSearchOption;
        private DevExpress.XtraEditors.SimpleButton btnSearchKey;
        private DevExpress.XtraEditors.SimpleButton btnAll;
        private DevComponents.DotNetBar.ButtonX btnCencel;
        private DevComponents.DotNetBar.ButtonX btnUpdate;
        private DevComponents.DotNetBar.ButtonX btnAdd;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
    }
}