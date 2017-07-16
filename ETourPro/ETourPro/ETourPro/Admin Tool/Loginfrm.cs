using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataAccess;

namespace ETourPro.Admin_Tool
{
    public partial class Loginfrm : Form
    {
        public string Powers = "";
        public Loginfrm()
        {
            InitializeComponent();
        }

        private void Loginfrm_Load(object sender, EventArgs e)
        {
            txtUser.Text = "Administrator";
            txtPass.Text = "123456&";
            lblLoginInfo.Text = "";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            if (txtUser.Text != "" && txtPass.Text != "")
            {
                btnLogin.Enabled = true;
            }
            else
            {
                btnLogin.Enabled = false;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login us = new Login();            
            us.User = txtUser.Text;
            us.Pass = txtPass.Text;
            Login lg = Login.FunctionLogin(us);
            if (lg != null)
            {
                Powers = lg.Powers;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                //this.Close();
            }
            else
            {
                lblLoginInfo.Text = "Login had been faile! Please try again!";
            }
        }

        
    }
}