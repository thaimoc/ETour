using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace ETourPro.Hotels
{
    public partial class RibbonForm1 : DevComponents.DotNetBar.Office2007RibbonForm
    {
        public RibbonForm1()
        {
            InitializeComponent();
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RibbonForm1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'eTourDataSet.HDV' table. You can move, or remove it, as needed.
            this.hDVTableAdapter.Fill(this.eTourDataSet.HDV);

        }
    }
}