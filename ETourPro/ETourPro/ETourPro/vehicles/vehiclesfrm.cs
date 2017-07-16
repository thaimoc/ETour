using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataAccess;

namespace ETourPro.vehicles
{
    public partial class vehiclesfrm : DevExpress.XtraEditors.XtraForm
    {
        public PowersLog Powers;
        public vehiclesfrm()
        {
            InitializeComponent();
        }

        private void vehiclesfrm_Load(object sender, EventArgs e)
        {
            if (Powers == PowersLog.Administrator || Powers == PowersLog.Designer)
            {
                grbManager.Visible = true;
            }
            else
                grbManager.Visible = false;
            lvVehicles_Load(PhuongTien.All());
            lblInfo.Text = "";
            cbbFields_Load();
        }

        private void lvVehicles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvVehicles.SelectedItems.Count > 0)
            {
                lvTours_Load(Tour.FindByVehicleCode(MyConvert.ToInt32(lvVehicles.SelectedItems[0].SubItems[0].Text)));
                trvDestination_Load(DiemDen.FindByMaPT(MyConvert.ToInt32(lvVehicles.SelectedItems[0].SubItems[0].Text)));
                tvSupplier_Load(NCCPTien.FindByVehicleCode(MyConvert.ToInt32(lvVehicles.SelectedItems[0].SubItems[0].Text)));
            }
            else
            {
                lvTours.Items.Clear();
                trvDestination.Nodes.Clear();
                tvSupplier.Nodes.Clear();
            }
        }

        private void lvVehicles_Load(List<PhuongTien> list)
        {
            lvVehicles.Items.Clear();
            ListViewItem i;
            foreach (PhuongTien item in list)
            {
                i = lvVehicles.Items.Add(item.ID.ToString());
                i.SubItems.Add(item.TenPT);
                i.SubItems.Add(item.TienNghi);
                i.SubItems.Add(item.SoChoToiDa.ToString());
                i.SubItems.Add(item.SoChoToiThieu.ToString());
                i.SubItems.Add(item.TenNCC);
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

        private void trvDestination_Load(List<DiemDen> list)
        {
            trvDestination.Nodes.Clear();
            foreach (DiemDen item in list)
            {
                TreeNode node = trvDestination.Nodes.Add(item.TenTour);
                node.Nodes.Add("Địa điểm: " + item.TenDD);
                node.Nodes.Add("Điểm du lịch: " + item.TenDiem);
                node.Nodes.Add("Khách sạn: " + item.TenKS);
                node.Nodes.Add("Quốc gia: " + item.QuocGia);
                node.Nodes.Add("Phương tiễn: " + item.TenPT);
                node.Nodes.Add("Nhà cung cấp phương tiễn: " + item.TenNCC);
                node.Expand();
            }
        }

        private void tvSupplier_Load(NCCPTien supplier)
        {
            tvSupplier.Nodes.Clear();
            tvSupplier.Nodes.Add("Code: " + supplier.ID);
            tvSupplier.Nodes.Add("Company Name: " + supplier.TenNCC);
            tvSupplier.Nodes.Add("Phone Numbers: " + supplier.DienThoai);
            tvSupplier.Nodes.Add("Address: " + supplier.DiaChi);
        }

        private void txtSearchByName_EditValueChanged(object sender, EventArgs e)
        {
            lvVehicles_Load(PhuongTien.FindByTenPT(txtSearchByName.Text));
        }

        private void textEdit2_EditValueChanged(object sender, EventArgs e)
        {
            lvVehicles_Load(PhuongTien.FindByTienNghi(textEdit2.Text));
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            lvVehicles_Load(PhuongTien.All());
        }

        private void txtSearchKey_EditValueChanged(object sender, EventArgs e)
        {
            lvVehicles_Load(PhuongTien.FindBy_SearchKey(txtSearchKey.Text));
        }

        private void txtMxNbr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                if (lblInfo.Text != "")
                    lblInfo.Text = "";
            }
            else
                e.Handled = true;
            
        }

        private void txtMnNbr_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtMxNbr.Text == "")
            {
                txtMxNbr.Focus();
                e.Handled = true;
            }
            else
            {
                if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                    if (lblInfo.Text != "")
                        lblInfo.Text = "";
                }
                else
                    e.Handled = true;
            }
        }

        private void btnSearchTickites_Click(object sender, EventArgs e)
        {
            if (txtMxNbr.Text == "")
            {
                txtMxNbr.Focus();
                lblInfo.Text = "You must enter a value into Maximum Numbers";
                return;
            }
            if (txtMnNbr.Text == "")
            {
                txtMnNbr.Focus();
                lblInfo.Text = "You must enter a value into Minimum Numbers";
                return;
            }
            if (MyConvert.ToInt32(txtMnNbr.Text) > MyConvert.ToInt32(txtMxNbr.Text))
            {
                txtMnNbr.Focus();
                lblInfo.Text = "The value Minimum is less than the value Maximum!";
                return;
            }
            lvVehicles_Load(PhuongTien.FindBySoChoTD_TT(MyConvert.ToInt32(txtMxNbr.Text), MyConvert.ToInt32(txtMnNbr.Text)));
        }

        private void cbbFields_Load()
        {
            object[] s = PhuongTien.ColumnNames();
            cbbFields.Items.AddRange(s);
        }

        private void cbbFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvVehicles_Load(PhuongTien.SearchFields(cbbFields.SelectedItem.ToString(), txtSearchOption.Text));
        }

        private void itemAdd_ItemClick(object sender, TileItemEventArgs e)
        {
            Vehiclefrm frm = new Vehiclefrm();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                lvVehicles_Load(PhuongTien.All());
        }

        private void itemUpdate_ItemClick(object sender, TileItemEventArgs e)
        {
            if (lvVehicles.SelectedItems.Count > 0)
            {
                Vehiclefrm frm = new Vehiclefrm();
                frm.Code = MyConvert.ToInt32(lvVehicles.SelectedItems[0].SubItems[0].Text);
                frm.ShowDialog();
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                    lvVehicles_Load(PhuongTien.All());
            }
        }

        private void itemDelete_ItemClick(object sender, TileItemEventArgs e)
        {
            //Khong phat trien tinh nang nay

            //if (lvVehicles.SelectedItems.Count > 0)
            //{
            //    int _ma = MyConvert.ToInt32(lvVehicles.SelectedItems[0].SubItems[0].Text);
            //    int affected = PhuongTien.Delete(_ma);
            //    if (affected > 0)
            //    {
            //        MessageBox.Show("Deleting is successful!", "Kim Nguyễn say:", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            //        lvVehicles_Load(PhuongTien.All());
            //    }
            //    else
            //        MessageBox.Show("Deleting had been failse!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //    MessageBox.Show("You did not choose the vehicle!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void cbbFields_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }




    }
}