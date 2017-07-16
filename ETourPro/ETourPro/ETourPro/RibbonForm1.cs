using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace ETourPro
{
    public partial class processfrm : DevComponents.DotNetBar.Office2007Form
    {
        public processfrm()
        {
            InitializeComponent();
        }

        private void RibbonForm1_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath mypath = new System.Drawing.Drawing2D.GraphicsPath();
            mypath.AddEllipse(0, 0, this.Width, this.Height);
            Region myregion = new Region(mypath);
            this.Region = myregion;
        }




    }
}