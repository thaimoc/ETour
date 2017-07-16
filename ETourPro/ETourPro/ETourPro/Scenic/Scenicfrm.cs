using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ETourPro.Locals;
using DataAccess;

namespace ETourPro.Scenic
{
    public partial class Scenicfrm : Form
    {
        private int _Code = 0;

        public int Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        public Scenicfrm()
        {
            InitializeComponent();
        }

        private void Scenicfrm_Load(object sender, EventArgs e)
        {
            cbbLocal_Load();
            lblInfo.Text = "";
            if (Code == 0)
            {
                btnUpdate.Visible = false;
            }
            else
            {
                btnAdd.Visible = false;
                controls_LoadUp();
            }
        }

        private void cbbLocal_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0 && txtAddress.Text.Length > 0 && cbbLocal.SelectedIndex >= 0)
            {
                btnAdd.Enabled = true;
                lblInfo.Text = "";
            }
            else
                btnAdd.Enabled = false;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Localfrm frm = new Localfrm();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                cbbLocal_Load();
            }
        }

        private void cbbLocal_Load()
        {
            cbbLocal.DataSource = DiaDiemDL.All();
            cbbLocal.DisplayMember = "TenDD";
            cbbLocal.ValueMember = "ID";
            cbbLocal.SelectedIndex = 0;
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private DiemDL controls_Load()
        {
            DiemDL result = new DiemDL();
            result.ID = Code;
            result.TenDiem = txtName.Text;
            result.DiaChi = txtAddress.Text;
            DiaDiemDL dd = cbbLocal.SelectedItem as DiaDiemDL;
            result.MaDD = dd.ID;
            return result;
        }

        private void controls_LoadUp()
        {
            DiemDL result = DiemDL.Single(Code);
            txtCode.Text = result.ID.ToString();
            txtName.Text = result.TenDiem;
            txtAddress.Text = result.DiaChi;

            int i = 0;
            foreach (var item in cbbLocal.Items)
            {
                DiaDiemDL d = cbbLocal.Items[i] as DiaDiemDL;
                if (d.ID == result.MaDD)
                    break;
                i++;
            }
            cbbLocal.SelectedIndex = i;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DiaDiemDL dd = cbbLocal.SelectedItem as DiaDiemDL;
            if (DiemDL.FindByTenD_MaDD(txtName.Text, dd.ID).Count > 0)
            {
                lblInfo.Text = "This Scenic had been exited!";
                txtName.Focus();
                return;
            }
            DialogResult dlg = MessageBox.Show("Do you want to add this scenic?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                if (DiemDL.Add(controls_Load()))
                {
                    MessageBox.Show("Adding is successful!", "Kim Nguyen's Say", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                    MessageBox.Show("Adding had been failse!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DiaDiemDL dd = cbbLocal.SelectedItem as DiaDiemDL;

            DiemDL exited = DiemDL.Single(Code);
            DiemDL newUp = controls_Load();
            if (exited.TenDD != newUp.TenDD || exited.MaDD != newUp.MaDD)
            {
                if (DiemDL.FindByTenD_MaDD(txtName.Text, dd.ID).Count > 0)
                {
                    lblInfo.Text = "This Scenic had been exited!";
                    txtName.Focus();
                    return;
                }
            }

            DialogResult dlg = MessageBox.Show("Do you want to Update?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                if (DiemDL.Update(newUp))
                {
                    MessageBox.Show("Updating is sucessfull!", "Kim Nguyen's Say", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                    MessageBox.Show("Updating had been failse!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        
       
    }
}
