using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using System.Threading;
using DataAccess;

using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;


namespace ETourPro.Customers
{
    public partial class Customersfrm : DevComponents.DotNetBar.Office2007RibbonForm
    {
        PowersLog _Powers;

        public PowersLog Powers
        {
            get { return _Powers; }
            set { _Powers = value; }
        }

        Thread processThread;

        public CusList cusList { get; set; }

        public Trips tripsList { get; set; }
        public OrderList ordersList { get; set; }
        public ToursList toursList { get; set; }

        public string Code { get; set; }
        private string expression = "";

        public Customersfrm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            //processThread = new Thread(new ThreadStart(ProcessStart));
            //processThread.Start();
        }

        private void Customerfrm_Load(object sender, EventArgs e)
        {
            simpleButton2.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;

            if (Powers == PowersLog.Administrator || Powers == PowersLog.Saler)
            {
                simpleButton2.Visible = true;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
            }
            cusList = new CusList();
            tripsList = new Trips();
            ordersList = new OrderList();
            toursList = new ToursList();
            
            lblExpresstion.Text = "";

            btnAll.PerformClick();

            //Thread.Sleep(2000);
            //processThread.Abort();
            ///
            //cbbColumns_Load(KhachHang.ColumnNames());
            
        }
       

        private void lvCustomers_Load(List<KhachHang> list)
        {
            lvCustomers.Items.Clear();
            foreach (KhachHang i in list)
            {
                ListViewItem item = lvCustomers.Items.Add(i.ID);
                item.SubItems.Add(i.Ho + " " + i.Ten);
                item.SubItems.Add(i.NgaySinh.ToShortDateString());
                item.SubItems.Add(i.GTinh?"Nam":"Nữ");
                item.SubItems.Add(i.SoDT);
                item.SubItems.Add(i.SoTaiKhoan);
                item.SubItems.Add(i.DiaChi);
                item.SubItems.Add(i.ThanhPho);
                item.SubItems.Add(i.QuocGia);
            }
        }

        private void lvTrips_Load(List<Chuyen> list)
        {
            lvTrips.Items.Clear();
            ListViewItem item;
            foreach (Chuyen i in list)
            {
                item = lvTrips.Items.Add(i.MChuyen.ToString());
                item.SubItems.Add(i.TenTour);
                item.SubItems.Add(i.NgayDi.ToShortDateString());
                item.SubItems.Add(i.NgayVe.ToShortDateString());
                item.SubItems.Add(i.Gia.ToString());
                item.SubItems.Add(i.TrangThai >= 1 ? "Đang mở" : (i.TrangThai == 0 ? "Đã đóng" : "Đã hủy"));
                item.SubItems.Add(i.XuatPhat);
            }
        }

        private void lvTours_Load(List<Tour> list)
        {
            lvTours.Items.Clear();
            ListViewItem item;
            foreach (Tour i in list)
            {
                item = lvTours.Items.Add(i.ID.ToString());
                item.SubItems.Add(i.TenTour);
                item.SubItems.Add(i.XuatPhat);
                item.SubItems.Add(i.TrangThai);
            }
        }

        private static void ProcessStart()
        {
            processfrm frm = new processfrm();
            frm.ShowDialog();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnAll_Click(object sender, EventArgs e)
        {
            lvCustomers_Load(cusList.List);
            ResetSearchControls();
        }

        private void btnExit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.WindowState = this.WindowState == FormWindowState.Maximized? FormWindowState.Normal: FormWindowState.Maximized;
        }

        private void btnMin_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        int i = 0;
        bool rec = true;
        private void lvCustomers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (i < 3 && rec == true)
            {
                imageSlider1.SlideNext();
                i++;
                if (i == 2)
                    rec = false;
            }
            else
            {
                imageSlider1.SlidePrev();
                i--;
                if (i == 0)
                    rec = true;
            }
            if (lvCustomers.SelectedItems.Count > 0)
            {
                Code = lvCustomers.SelectedItems[0].SubItems[0].Text;
                List<DatCho> ord = ordersList.Find(Code);
                List<Chuyen> trips = tripsList.Find(ord);
                lvTrips_Load(trips);
                lvTours_Load(toursList.Find(trips));
            }
            else
            {
                lvTrips.Items.Clear();
                lvTours.Items.Clear();
            }
        }

        private void cbbCountries_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdMale.Checked) lvCustomers_Load(cusList.Find(true));
        }

        private void rdFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rdFemale.Checked) lvCustomers_Load(cusList.Find(false));
        }

        private void cbbCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCountries.SelectedIndex >= 0)
            {
                if (cbbCountries.SelectedItem.ToString() == "Việt Nam")
                {
                    lblCity.Visible = true;
                    cbbCity.Visible = true;
                }
                else
                {
                    cbbCity.Visible = false;
                    lblCity.Visible = false;
                }
                if (cbbCountries.SelectedIndex >= 0)
                    lvCustomers_Load(cusList.FindCountry(cbbCountries.SelectedItem.ToString()));
            }
        }

        private void cbbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCity.SelectedIndex >= 0)
                lvCustomers_Load(cusList.FindByCity(cbbCity.SelectedItem.ToString()));
        }

        private void dtpSBirth_ValueChanged(object sender, EventArgs e)
        {
            if (dtpSBirth.Value.Date >= DateTime.Now.Date)
            {
                dtpSBirth.Value = DateTime.Now;
            }
            else
            {
                lvCustomers_Load(cusList.FindByBirthDate(dtpSBirth.Value));
            }
        }

        private void txtSPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSPhone.Text.Length < 24)
            {
                if (Char.IsControl(e.KeyChar) || Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                    return;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                    e.Handled = true;
            }
        }

        private void txtSAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtSAccount.Text.Length < 24)
            {
                if (Char.IsControl(e.KeyChar) || Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                    return;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                    e.Handled = true;
            }
        }

        private void txtSPhone_EditValueChanged(object sender, EventArgs e)
        {
            lvCustomers_Load(cusList.FindByPhone(txtSPhone.Text));
        }

        private void txtSAccount_EditValueChanged(object sender, EventArgs e)
        {
            lvCustomers_Load(cusList.FindByAccount(txtSAccount.Text));
        }

        private void txtSCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            if (txtSCode.Text.Length >= 0 && txtSCode.Text.Length < 2)
            {
                string test = txtSCode.Text + e.KeyChar;
                if (test == "KH" || test=="K")
                {
                    e.Handled = false;
                    return;
                }
                try
                {
                    Convert.ToInt32(test);
                    e.Handled = false;
                    return;
                }
                catch
                { 
                    
                }
                e.Handled = true;
                return;
            }


            if (Char.IsDigit(e.KeyChar))
            {
                string test = txtSCode.Text + e.KeyChar;
                if ((!txtSCode.Text.Contains("K") && !txtSCode.Text.Contains("H")) && txtSCode.Text.Length < 5)
                {
                    e.Handled = false;
                    return;
                }

                //test = txtSCode.Text + e.KeyChar;
                string t = txtSCode.Text.Substring(0, 2);
                if (t != "KH")
                {
                    e.Handled = true;
                    return;//k5h
                }
                
                if (txtSCode.Text.Length < 7)
                    e.Handled = false;
                else
                    e.Handled = true;                 

            }
            else
                e.Handled = true;
            
        }

        private void txtSCode_EditValueChanged(object sender, EventArgs e)
        {
            lvCustomers_Load(cusList.FindByCode(txtSCode.Text));
        }

        private void txtSAddress_EditValueChanged(object sender, EventArgs e)
        {
            lvCustomers_Load(cusList.FindByAdress(txtSAddress.Text));
        }

        private void txtSName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }
            if (Char.IsLetter(e.KeyChar) || e.KeyChar == ' ')
            {
                if (txtSName.Text.Length <= 40 && !(txtSName.Text + e.KeyChar).Contains("  "))
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            else
                e.Handled = true;
        }

        private void txtSName_EditValueChanged(object sender, EventArgs e)
        {
            lvCustomers_Load(cusList.FindByName(txtSName.Text));
        }

        private void txtSeachKey_EditValueChanged(object sender, EventArgs e)
        {
            lvCustomers_Load(cusList.Find(txtSeachKey.Text));
        }

        private void ResetSearchControls()
        {
            txtSCode.Text = "";
            txtSName.Text = "";
            txtSAccount.Text = "";
            txtSPhone.Text = "";
            txtSeachKey.Text = "";
            cbbCity.Visible = false;
            cbbCountries.SelectedIndex = -1;
            dtpSBirth.Value = DateTime.Now;
            rdFemale.Checked = false;
            rdMale.Checked = false;
            txtSAddress.Text = "";
        }

        private void dtpLess_ValueChanged(object sender, EventArgs e)
        {
            if (dtpLess.Value > DateTime.Now)
                dtpLess.Value = DateTime.Now;
            if (dtpLess.Value > dtpMore.Value)
            {
                dtpLess.Value = dtpLess.MinDate;
                dtpLess.Focus();
            }
            if (dtpLess.Value < dtpMore.Value)
                btnSearchtime.Enabled = true;
            else
                btnSearchtime.Enabled = false;
        }

        private void dtpMore_ValueChanged(object sender, EventArgs e)
        {
            if (dtpMore.Value > DateTime.Now)
                dtpMore.Value = DateTime.Now;
            if (dtpLess.Value > dtpMore.Value)
            {
                dtpMore.Value = dtpMore.MaxDate;
                dtpMore.Focus();
            }
            if (dtpLess.Value < dtpMore.Value)
                btnSearchtime.Enabled = true;
            else
                btnSearchtime.Enabled = false;
        }

        private void btnSearchtime_Click(object sender, EventArgs e)
        {
            lvCustomers_Load(cusList.FindByBirthDate(dtpLess.Value, dtpMore.Value));
        }

        private void btnSCbrth_Click(object sender, EventArgs e)
        {
            lvCustomers_Load(cusList.FindByMonthBirthDay(DateTime.Now.Month));
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            lvCustomers_Load(cusList.List);
        }

        #region Find Advance

        private void RadiosCheckState()
        {
            grbRelationExpression.Enabled = (lblExpresstion.Text.Length > 0);
            btnSearchAdvance.Enabled = grbRelationExpression.Enabled;
        }

        private void cbbColumns_Load(object[] items)
        {
            cbbColumns.Items.Clear();
            cbbColumns.Items.AddRange(items);
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (txtValue.Text != "")
                btnAddExpr.Enabled = true;
            else
                btnAddExpr.Enabled = false;
        }

        private void btnAddExpr_Click(object sender, EventArgs e)
        {
            string andor = "";
            if (grbRelationExpression.Enabled)
            {
                if (radAnd.Checked) andor = "AND";
                else andor = "OR";
            }
            else
            {
                lblExpresstion.Text = "";
                expression = "";
            }
            string value = txtValue.Visible ? txtValue.Text : dtpValues.Text;
            lblExpresstion.Text += andor + " " + cbbColumns.Text + ' ' + cbbperator.Text + ' ' + value + ' ';
            if (cbbperator.SelectedItem.ToString() == "LIKE")
                expression += andor + ' ' + cbbColumns.Text + '*' + cbbperator.Text + " \'%" + value + "%\' *";
            else
                expression += andor + ' ' + cbbColumns.Text + '*' + cbbperator.Text + " \'" + value + "\' *";
            
            this.RadiosCheckState();
            btnAddExpr.Enabled = false;
        }
        
        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            #region Code
            if (cbbColumns.SelectedItem.ToString() == "Code")
            {
                if (txtValue.Text.Length >= 0 && txtValue.Text.Length < 2)
                {
                    string test = txtValue.Text + e.KeyChar;
                    if (test == "KH" || test == "K")
                    {
                        e.Handled = false;
                        return;
                    }
                    try
                    {
                        Convert.ToInt32(test);
                        e.Handled = false;
                        return;
                    }
                    catch
                    {

                    }
                    e.Handled = true;
                    return;
                }


                if (Char.IsDigit(e.KeyChar))
                {
                    string test = txtValue.Text + e.KeyChar;
                    if ((!txtValue.Text.Contains("K") && !txtValue.Text.Contains("H")) && txtValue.Text.Length < 5)
                    {
                        e.Handled = false;
                        return;
                    }

                    //test = txtSCode.Text + e.KeyChar;
                    string t = txtValue.Text.Substring(0, 2);
                    if (t != "KH")
                    {
                        e.Handled = true;
                        return;//k5h
                    }

                    if (txtValue.Text.Length < 7)
                        e.Handled = false;
                    else
                        e.Handled = true;

                }
                else
                    e.Handled = true;
            }
            #endregion code

            #region Name
            if (cbbColumns.SelectedItem.ToString() == "First Name" || cbbColumns.SelectedItem.ToString() == "Last Name")
            {
                if (Char.IsLetter(e.KeyChar))
                {
                    if (txtValue.Text.Length <= 20)
                        e.Handled = false;
                    else
                        e.Handled = true;
                }
                else
                    e.Handled = true;
            }

            #endregion Name

            #region Phone or Account

            if (cbbColumns.SelectedItem.ToString() == "Phone" || cbbColumns.SelectedItem.ToString() == "Account")
            {
                if (txtValue.Text.Length < 24)
                {
                    if (Char.IsControl(e.KeyChar) || Char.IsDigit(e.KeyChar))
                    {
                        e.Handled = false;
                        return;
                    }
                    else
                    {
                        e.Handled = true;
                    }
                }
                else
                {
                    if (Char.IsControl(e.KeyChar))
                        e.Handled = false;
                    else
                        e.Handled = true;
                }
            }


            #endregion Phone or Account

        }

        private void cbbColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValue.Text = "";
            cbbperator.SelectedIndex = 0;
            if(txtValue.Visible)
                txtValue.Enabled = true;
            if (cbbColumns.SelectedItem.ToString() == "Birth date")
            {
                dtpValues.Visible = true;
                txtValue.Visible = false;
            }
            else
            {
                dtpValues.Visible = false;
                txtValue.Visible = true;
            }
        }

        private void btnSearchAdvance_Click(object sender, EventArgs e)
        {
            lvCustomers_Load(KhachHang.Find(expression));
            expression = "";
            lblExpresstion.Text = "";
            RadiosCheckState();
        }

        private void dtpValues_ValueChanged(object sender, EventArgs e)
        {
            if (dtpValues.Text.Length > 0)
                btnAddExpr.Enabled = true;
            else
                btnAddExpr.Enabled = false;
        }
       
        #endregion End Find Advance

        // ADD
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Customerfrm frm = new Customerfrm();
            frm.ListTours = this.toursList;
            frm.ListCus = this.cusList;
            frm.ListTrips = this.tripsList;
            frm.ListOrd = this.ordersList;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                btnAll.PerformClick();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvCustomers.SelectedItems.Count > 0)
            {
                Customerfrm frm = new Customerfrm();
                frm.ListTours = this.toursList;
                frm.ListCus = this.cusList;
                frm.ListTrips = this.tripsList;
                frm.ListOrd = this.ordersList;
                frm.Code = lvCustomers.SelectedItems[0].SubItems[0].Text;
                frm.ShowDialog();
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                    btnAll.PerformClick();
            }
            else
            {
                MessageBox.Show("Please choose the customer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvCustomers.SelectedItems.Count > 0)
            {
                DialogResult dlg =  MessageBox.Show("Are you want to delete this customer!", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == System.Windows.Forms.DialogResult.Yes)
                {
                    if (cusList.Delete(lvCustomers.SelectedItems[0].SubItems[0].Text))
                    {
                        MessageBox.Show("Deleting is sucessful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        ordersList.All();//Load lai hoa don
                        btnAll.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Deleting had been faile!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please choose the customer!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        

        

        

        

        

        


    }
}