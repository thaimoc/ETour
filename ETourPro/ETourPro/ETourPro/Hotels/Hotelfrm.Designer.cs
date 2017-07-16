namespace ETourPro.Hotels
{
    partial class Hotelfrm
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
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtStartNumber = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtAddress = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.clbleft = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.clbright = new DevExpress.XtraEditors.CheckedListBoxControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.btnLeftGoTo = new DevExpress.XtraEditors.SimpleButton();
            this.btnRightGoTo = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnUpdate = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clbleft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clbright)).BeginInit();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(222, 6);
            this.txtName.Name = "txtName";
            this.txtName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.txtName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Properties.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtName.Properties.Appearance.Options.UseBackColor = true;
            this.txtName.Properties.Appearance.Options.UseFont = true;
            this.txtName.Properties.Appearance.Options.UseForeColor = true;
            this.txtName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txtName.Size = new System.Drawing.Size(539, 20);
            this.txtName.TabIndex = 21;
            this.txtName.EditValueChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtName_KeyPress);
            // 
            // txtCode
            // 
            this.txtCode.EditValue = "--New--";
            this.txtCode.Enabled = false;
            this.txtCode.Location = new System.Drawing.Point(61, 9);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.txtCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCode.Properties.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtCode.Properties.Appearance.Options.UseBackColor = true;
            this.txtCode.Properties.Appearance.Options.UseFont = true;
            this.txtCode.Properties.Appearance.Options.UseForeColor = true;
            this.txtCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txtCode.Size = new System.Drawing.Size(75, 20);
            this.txtCode.TabIndex = 20;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelControl2.Location = new System.Drawing.Point(152, 12);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(64, 14);
            this.labelControl2.TabIndex = 17;
            this.labelControl2.Text = "Hotel Name";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelControl3.Location = new System.Drawing.Point(12, 38);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(36, 14);
            this.labelControl3.TabIndex = 16;
            this.labelControl3.Text = "Số sao";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(28, 14);
            this.labelControl1.TabIndex = 18;
            this.labelControl1.Text = "Code";
            // 
            // txtStartNumber
            // 
            this.txtStartNumber.Location = new System.Drawing.Point(61, 35);
            this.txtStartNumber.Name = "txtStartNumber";
            this.txtStartNumber.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.txtStartNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStartNumber.Properties.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtStartNumber.Properties.Appearance.Options.UseBackColor = true;
            this.txtStartNumber.Properties.Appearance.Options.UseFont = true;
            this.txtStartNumber.Properties.Appearance.Options.UseForeColor = true;
            this.txtStartNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txtStartNumber.Size = new System.Drawing.Size(75, 20);
            this.txtStartNumber.TabIndex = 21;
            this.txtStartNumber.EditValueChanged += new System.EventHandler(this.txtStartNumber_EditValueChanged);
            this.txtStartNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStartNumber_KeyPress);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelControl4.Location = new System.Drawing.Point(12, 64);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(43, 14);
            this.labelControl4.TabIndex = 17;
            this.labelControl4.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(61, 61);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.txtAddress.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAddress.Properties.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtAddress.Properties.Appearance.Options.UseBackColor = true;
            this.txtAddress.Properties.Appearance.Options.UseFont = true;
            this.txtAddress.Properties.Appearance.Options.UseForeColor = true;
            this.txtAddress.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txtAddress.Size = new System.Drawing.Size(700, 20);
            this.txtAddress.TabIndex = 21;
            this.txtAddress.EditValueChanged += new System.EventHandler(this.txt_TextChanged);
            this.txtAddress.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAddress_KeyPress);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelControl5.Location = new System.Drawing.Point(152, 38);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(35, 14);
            this.labelControl5.TabIndex = 17;
            this.labelControl5.Text = "Phone";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(222, 32);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.txtPhone.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPhone.Properties.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtPhone.Properties.Appearance.Options.UseBackColor = true;
            this.txtPhone.Properties.Appearance.Options.UseFont = true;
            this.txtPhone.Properties.Appearance.Options.UseForeColor = true;
            this.txtPhone.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.txtPhone.Size = new System.Drawing.Size(539, 20);
            this.txtPhone.TabIndex = 21;
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // clbleft
            // 
            this.clbleft.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.clbleft.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbleft.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.clbleft.Appearance.Options.UseBackColor = true;
            this.clbleft.Appearance.Options.UseFont = true;
            this.clbleft.Appearance.Options.UseForeColor = true;
            this.clbleft.CheckOnClick = true;
            this.clbleft.Location = new System.Drawing.Point(2, 126);
            this.clbleft.Name = "clbleft";
            this.clbleft.Size = new System.Drawing.Size(339, 202);
            this.clbleft.TabIndex = 26;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelControl6.Location = new System.Drawing.Point(5, 106);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(300, 14);
            this.labelControl6.TabIndex = 17;
            this.labelControl6.Text = "Choose the scenics witch is this hotel had been saved:";
            // 
            // clbright
            // 
            this.clbright.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.clbright.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clbright.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.clbright.Appearance.Options.UseBackColor = true;
            this.clbright.Appearance.Options.UseFont = true;
            this.clbright.Appearance.Options.UseForeColor = true;
            this.clbright.CheckOnClick = true;
            this.clbright.Location = new System.Drawing.Point(424, 126);
            this.clbright.Name = "clbright";
            this.clbright.Size = new System.Drawing.Size(337, 202);
            this.clbright.TabIndex = 26;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.labelControl7.Location = new System.Drawing.Point(428, 108);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(259, 14);
            this.labelControl7.TabIndex = 17;
            this.labelControl7.Text = "The scenics witch is this hotel had been saved:";
            // 
            // btnLeftGoTo
            // 
            this.btnLeftGoTo.Appearance.BackColor = System.Drawing.Color.Lime;
            this.btnLeftGoTo.Appearance.BackColor2 = System.Drawing.Color.Red;
            this.btnLeftGoTo.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnLeftGoTo.Appearance.Options.UseBackColor = true;
            this.btnLeftGoTo.Appearance.Options.UseForeColor = true;
            this.btnLeftGoTo.Location = new System.Drawing.Point(352, 164);
            this.btnLeftGoTo.Name = "btnLeftGoTo";
            this.btnLeftGoTo.Size = new System.Drawing.Size(61, 23);
            this.btnLeftGoTo.TabIndex = 27;
            this.btnLeftGoTo.Text = ">>";
            this.btnLeftGoTo.Click += new System.EventHandler(this.btnLeftGoTo_Click);
            // 
            // btnRightGoTo
            // 
            this.btnRightGoTo.Appearance.BackColor = System.Drawing.Color.Lime;
            this.btnRightGoTo.Appearance.BackColor2 = System.Drawing.Color.Red;
            this.btnRightGoTo.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnRightGoTo.Appearance.Options.UseBackColor = true;
            this.btnRightGoTo.Appearance.Options.UseForeColor = true;
            this.btnRightGoTo.Location = new System.Drawing.Point(352, 240);
            this.btnRightGoTo.Name = "btnRightGoTo";
            this.btnRightGoTo.Size = new System.Drawing.Size(61, 23);
            this.btnRightGoTo.TabIndex = 27;
            this.btnRightGoTo.Text = "<<";
            this.btnRightGoTo.Click += new System.EventHandler(this.btnRightGoTo_Click);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.Lime;
            this.simpleButton1.Appearance.BackColor2 = System.Drawing.Color.Red;
            this.simpleButton1.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Appearance.Options.UseForeColor = true;
            this.simpleButton1.Location = new System.Drawing.Point(684, 84);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(77, 23);
            this.simpleButton1.TabIndex = 27;
            this.simpleButton1.Text = "Cencel";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.BackColor = System.Drawing.Color.Lime;
            this.btnAdd.Appearance.BackColor2 = System.Drawing.Color.Red;
            this.btnAdd.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnAdd.Appearance.Options.UseBackColor = true;
            this.btnAdd.Appearance.Options.UseForeColor = true;
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(601, 84);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(77, 23);
            this.btnAdd.TabIndex = 27;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Appearance.BackColor = System.Drawing.Color.Lime;
            this.btnUpdate.Appearance.BackColor2 = System.Drawing.Color.Red;
            this.btnUpdate.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.btnUpdate.Appearance.Options.UseBackColor = true;
            this.btnUpdate.Appearance.Options.UseForeColor = true;
            this.btnUpdate.Location = new System.Drawing.Point(590, 84);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(77, 23);
            this.btnUpdate.TabIndex = 27;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // Hotelfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(764, 331);
            this.Controls.Add(this.btnRightGoTo);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnLeftGoTo);
            this.Controls.Add(this.clbright);
            this.Controls.Add(this.clbleft);
            this.Controls.Add(this.txtStartNumber);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Hotelfrm";
            this.Text = "Hotel Manager";
            this.Load += new System.EventHandler(this.Hotelfrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clbleft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clbright)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtCode;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtStartNumber;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtAddress;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.CheckedListBoxControl clbleft;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.CheckedListBoxControl clbright;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton btnLeftGoTo;
        private DevExpress.XtraEditors.SimpleButton btnRightGoTo;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnUpdate;
    }
}