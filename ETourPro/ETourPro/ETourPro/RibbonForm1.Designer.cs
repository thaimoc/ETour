namespace ETourPro
{
    partial class processfrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(processfrm));
            this.progressMain = new DevExpress.XtraWaitForm.ProgressPanel();
            this.SuspendLayout();
            // 
            // progressMain
            // 
            this.progressMain.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressMain.Appearance.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.progressMain.Appearance.Options.UseBackColor = true;
            this.progressMain.Appearance.Options.UseForeColor = true;
            this.progressMain.AppearanceCaption.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.progressMain.AppearanceCaption.Options.UseFont = true;
            this.progressMain.AppearanceDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.progressMain.AppearanceDescription.Options.UseFont = true;
            this.progressMain.Caption = "Please Wait Etour Customer Support";
            this.progressMain.Location = new System.Drawing.Point(111, 58);
            this.progressMain.Name = "progressMain";
            this.progressMain.Size = new System.Drawing.Size(309, 66);
            this.progressMain.TabIndex = 0;
            // 
            // processfrm
            // 
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(511, 171);
            this.Controls.Add(this.progressMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "processfrm";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.RibbonForm1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraWaitForm.ProgressPanel progressMain;
    }
}