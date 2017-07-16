using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataAccess;
using ETourPro.Suppliers_Vehicle;

namespace ETourPro.vehicles
{
    public partial class Vehiclefrm : DevExpress.XtraEditors.XtraForm
    {
        private int _code = -1;

        public int Code
        {
            get { return _code; }
            set { _code = value; }
        }
        public Vehiclefrm()
        {
            InitializeComponent();
        }

        private void Vehiclefrm_Load(object sender, EventArgs e)
        {
            cbbSupplier_Load();
            if (Code > -1)
            {
                btnAdd.Visible = false;
                btnUpdate.Visible = true;
                controls_LoadUp();
            }
            else
            {
                btnAdd.Visible = true;
                btnAdd.Enabled = false;
                btnUpdate.Visible = false;
            }

        }

        private void cbbSupplier_Load()
        {
            cbbSupplier.DataSource = NCCPTien.All();
            cbbSupplier.DisplayMember = "TenNCC";
            cbbSupplier.ValueMember = "ID";
        }

        private void txtNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void controls_LoadUp()
        {
            PhuongTien pt = PhuongTien.Single(Code);
            txtCode.Text = pt.ID.ToString();
            txtName.Text = pt.TenPT;
            txtFacitities.Text = pt.TienNghi;
            txtMxNbr.Text = pt.SoChoToiDa.ToString();
            txtMinNbr.Text = pt.SoChoToiThieu.ToString();
            cbbSupplier.SelectedValue = pt.NhaCungCap;
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0 && txtFacitities.Text.Length > 0 && txtMxNbr.Text.Length > 0 && txtMinNbr.Text.Length > 0)
            {
                if (MyConvert.ToInt32(txtMxNbr.Text) > MyConvert.ToInt32(txtMinNbr.Text))
                {
                    btnAdd.Enabled = true;
                    btnUpdate.Enabled = true;
                }
                else
                {
                    MessageBox.Show("The maximum Number Of The Tickets must less than the minimum Number Of The Tickets", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnAdd.Enabled = false;
                    btnUpdate.Enabled = false;
                }
            }
            else
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }

        private PhuongTien controls_Load()
        {
            PhuongTien result = new PhuongTien();
            result.ID = Code;
            result.TenPT = txtName.Text;
            result.TienNghi = txtFacitities.Text;
            result.SoChoToiDa = MyConvert.ToInt32(txtMxNbr.Text);
            result.SoChoToiThieu = MyConvert.ToInt32(txtMinNbr.Text);
            NCCPTien nc = (NCCPTien)cbbSupplier.SelectedItem;
            result.NhaCungCap = nc.ID;
            return result;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            NCCPTien nc = cbbSupplier.SelectedItem as NCCPTien;
            if (PhuongTien.FindByTen_NCC(txtName.Text, nc.ID).Count > 0)
            {
                MessageBox.Show("This vehicle had been exited!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnAdd.Enabled = false;
                return;
            }
            int affected = PhuongTien.Add(controls_Load());
            if (affected > 0)
            {
                MessageBox.Show("Adding is successful!", "Kim Nguyễn say:", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                //this.Close();
            }
            else
                MessageBox.Show("Adding had been faile!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if(Code > -1)
            {
                NCCPTien nc = cbbSupplier.SelectedItem as NCCPTien;
                PhuongTien exited = PhuongTien.Single(Code);
                PhuongTien newVehicle = controls_Load();
                if (txtName.Text != exited.TenPT)
                {
                    if (PhuongTien.FindByTen_NCC(txtName.Text, nc.ID).Count > 0)
                    {
                        MessageBox.Show("This vehicle had been exited!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        btnAdd.Enabled = false;
                        return;
                    }
                }

                int affected = PhuongTien.Update(newVehicle);
                if (affected > 0)
                {
                    MessageBox.Show("Updating is sucessful!", "Kim Nguyễn say:", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                    MessageBox.Show("Updating had been failse!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Supplierform frm = new Supplierform();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                cbbSupplier_Load();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            Supplierform frm = new Supplierform();
            NCCPTien nc = cbbSupplier.SelectedItem as NCCPTien;
            frm.Code = NCCPTien.Single(nc.ID).ID;
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                cbbSupplier_Load();
        }

    }
}