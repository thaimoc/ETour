using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess;

namespace ETourPro.Locals
{
    public partial class Localfrm : Form
    {
        private int _Code = 0;

        public int Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        public Localfrm()
        {
            InitializeComponent();
        }

        private void Localfrm_Load(object sender, EventArgs e)
        {
            if (Code > 0)
            {
                btnAdd.Visible = false;
                controls_LoadUp();

            }
            else
            {
                btnUpdate.Visible = false;
                cbbCountry.SelectedIndex = 0;
            }
            lblInfo.Text = "";
        }

        private void cbbCountry_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                btnAdd.Enabled = true;
                lblInfo.Text = "";
            }
            else
            {
                btnAdd.Enabled = false;
                lblInfo.Text = "You musht enter Local Name!";
                lblInfo.Focus();
            }
        }

        private DiaDiemDL controls_Load()
        {
            DiaDiemDL result = new DiaDiemDL();
            result.ID = Code;
            result.TenDD = txtName.Text;
            result.QuocGia = cbbCountry.SelectedItem.ToString();
            return result;
        }

        private void cbbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void controls_LoadUp()
        {
            DiaDiemDL result = DiaDiemDL.Single(Code);
            txtCode.Text = result.ID.ToString();
            txtName.Text = result.TenDD;
            cbbCountry.Text = result.QuocGia;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (DiaDiemDL.FindByTenDD_QuocGia(txtName.Text, cbbCountry.SelectedItem.ToString()).Count > 0)
            {
                MessageBox.Show("This local had been exited!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (DiaDiemDL.Add(controls_Load()))
            {
                MessageBox.Show("Adding successful!", "Kim Nguyen's Say", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
                MessageBox.Show("Thêm không thành công!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                lblInfo.Text = "You musht enter Local Name!";
                lblInfo.Focus();
                return;
            }

            DiaDiemDL exited = DiaDiemDL.Single(Code);
            DiaDiemDL newLocal = controls_Load();
            if (exited.QuocGia != newLocal.QuocGia || exited.TenDD != newLocal.TenDD)
            {
                if (DiaDiemDL.FindByTenDD_QuocGia(txtName.Text, cbbCountry.SelectedItem.ToString()).Count > 0)
                {
                    MessageBox.Show("This local had been exited!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (DiaDiemDL.Update(newLocal))
            {
                MessageBox.Show("Updating successful!", "Kim Nguyen's Say", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            else
                MessageBox.Show("Updating had been failse!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }



        

        
    }
}
