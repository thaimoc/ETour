using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess;

namespace ETourPro.Suppliers_Vehicle
{
    public partial class Supplierform : Form
    {
        
        private int _Code = 0;//0

        public int Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        public Supplierform()
        {
            InitializeComponent();
        }

        private void Supplierform_Load(object sender, EventArgs e)
        {
            
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

        private void controls_LoadUp()
        {
            NCCPTien nc = NCCPTien.Single(Code);
            txtName.Text = nc.TenNCC;
            txtAddress.Text = nc.DiaChi;
            txtPhone.Text = nc.DienThoai;
        }

        private NCCPTien controls_Load()
        {
            NCCPTien result = new NCCPTien();
            result.ID = Code;
            result.TenNCC = txtName.Text;
            result.DiaChi = txtAddress.Text;
            result.DienThoai = txtPhone.Text;
            return result;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar) || Char.IsDigit(e.KeyChar))
            {
                if (txtPhone.Text.Length < 24)
                    e.Handled = false;
                else
                    if (Char.IsControl(e.KeyChar))
                        e.Handled = false;
                    else
                        e.Handled = true;
            }
            else
                e.Handled = true;
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0 && txtAddress.Text.Length > 0)
                btnAdd.Enabled = true;
            else
                btnAdd.Enabled = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NCCPTien nc = NCCPTien.FindByTenNCC(txtName.Text);
            if (nc != null)
            {
                MessageBox.Show("This supplier had been exited!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAdd.Enabled = false;
                return;
            }
            int affected = NCCPTien.Add(controls_Load());
            if (affected > 0)
            {
                MessageBox.Show("Adding is successful!", "Kim Nguyễn say:", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Adding had been failse!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnCencel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            NCCPTien exited = NCCPTien.Single(Code);
            NCCPTien newAdd = controls_Load();
            if (exited.TenNCC != newAdd.TenNCC)
            {
                if (NCCPTien.FindByTenNCC(newAdd.TenNCC) != null)
                {
                    MessageBox.Show("This supplier had been exited!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnAdd.Enabled = false;
                    return;
                }
            }

            int affected = NCCPTien.Update(newAdd);
            if (affected > 0)
            {
                MessageBox.Show("Updating is successfull!", "Kim Nguyễn say:", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Updating had been failse!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }




    }
}
