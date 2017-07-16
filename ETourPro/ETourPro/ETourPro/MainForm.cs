using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using ETourPro.travel_guide;
using ETourPro.Admin_Tool;
using ETourPro.vehicles;
using ETourPro.Suppliers_Vehicle;
using ETourPro.Locals;
using ETourPro.Scenic;
using ETourPro.Hotels;
using ETourPro.Tours;
using ETourPro.Travel_Trips;
using ETourPro.Customers;

namespace ETourPro
{
    public enum PowersLog
    {
        Administrator,
        Designer,
        Saler,
        User
    }
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public PowersLog Powers = PowersLog.User;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void tileItem1_ItemClick(object sender, TileItemEventArgs e)
        {
            Toursfrm frm = new Toursfrm();
            frm.Powers = Powers;
            frm.ShowDialog();
        }

        private void tileItem8_ItemClick(object sender, TileItemEventArgs e)
        {
            travelGuidefrm frm = new travelGuidefrm();
            frm.Powers = Powers;
            frm.ShowDialog();
        }

        private void tileItem12_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Opacity = 0.6;
            Loginfrm frm = new Loginfrm();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                Powers = (PowersLog)Enum.Parse(typeof(PowersLog), frm.Powers);
            }
            this.Opacity = 1;
        }

        private void tileItem7_ItemClick(object sender, TileItemEventArgs e)
        {
            vehiclesfrm frm = new vehiclesfrm();
            frm.Powers = Powers;
            frm.Show();
        }

        private void tileItem9_ItemClick(object sender, TileItemEventArgs e)
        {
            Suppliersfrm frm = new Suppliersfrm();
            frm.Powers = Powers;
            frm.ShowDialog();
        }

        private void tileItem5_ItemClick(object sender, TileItemEventArgs e)
        {
            Localsfrm frm = new Localsfrm();
            frm.Powers = Powers;
            frm.ShowDialog();
        }

        private void tileItem6_ItemClick(object sender, TileItemEventArgs e)
        {
            Scenicsfrm frm = new Scenicsfrm();
            frm.Powers = Powers;
            frm.ShowDialog();
        }

        private void tileItem4_ItemClick(object sender, TileItemEventArgs e)
        {
            Hotelsfrm frm = new Hotelsfrm();
            frm.Powers = Powers;
            frm.ShowDialog();
        }

        private void tileItem2_ItemClick(object sender, TileItemEventArgs e)
        {
            if (this.Powers == PowersLog.Designer)
            {
                alertControl1.Show(this, "This use is designer which had been allowed using this action!", "Error");
                return;
            }
            Tripsfrm frm = new Tripsfrm();
            frm.Powers = Powers;
            frm.ShowDialog();
        }

        private void tileItem3_ItemClick(object sender, TileItemEventArgs e)
        {
            if (this.Powers == PowersLog.Designer)
            {
                alertControl1.Show(this, "This use is designer which had been allowed using this action!", "Error");
                return;
            }
            Customersfrm frm = new Customersfrm();
            frm.Powers = Powers;
            frm.ShowDialog();
        }
    }
}