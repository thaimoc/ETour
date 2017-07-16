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
    public partial class Suppliersfrm : Form
    {
        public PowersLog Powers;
        public Suppliersfrm()
        {
            InitializeComponent();
        }

        private void Suppliersfrm_Load(object sender, EventArgs e)
        {
            if (Powers == PowersLog.Administrator || Powers == PowersLog.Designer)
            {
                grbManager.Visible = true;
            }
            else
                grbManager.Visible = false;
            cbbFields_Load();
            lvSuppliers_Load(NCCPTien.All());

        }

        private void lvSuppliers_Load(List<NCCPTien> list)
        {
            lvSuppliers.Items.Clear();
            ListViewItem it;
            foreach (NCCPTien item in list)
            {
                it = lvSuppliers.Items.Add(item.ID.ToString());
                it.SubItems.Add(item.TenNCC);
                it.SubItems.Add(item.DienThoai);
                it.SubItems.Add(item.DiaChi);
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

        private void cbbFields_Load()
        {
            object[] bjs = NCCPTien.ColumnNames();
            cbbFields.Items.AddRange(bjs);
        }

        private void lvSuppliers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSuppliers.SelectedItems.Count > 0)
            {
                lvVehicles_Load(PhuongTien.FindByMaNCC(MyConvert.ToInt32(lvSuppliers.SelectedItems[0].SubItems[0].Text)));
            }
            else
                lvVehicles.Items.Clear();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            lvSuppliers_Load(NCCPTien.All());
        }

        private void txtSearchKey_EditValueChanged(object sender, EventArgs e)
        {
            lvSuppliers_Load(NCCPTien.SearchKeyWords(txtSearchKey.Text));
        }

        private void cbbFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvSuppliers_Load(NCCPTien.SearchFields(cbbFields.SelectedItem.ToString(), txtValueField.Text));
        }

        private void itemAdd_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Supplierform frm = new Supplierform();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                lvSuppliers_Load(NCCPTien.All());
        }

        private void itemUpdate_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (lvSuppliers.SelectedItems.Count > 0)
            {
                Supplierform frm = new Supplierform();
                frm.Code = MyConvert.ToInt32(lvSuppliers.SelectedItems[0].SubItems[0].Text);
                frm.ShowDialog();
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                    lvSuppliers_Load(NCCPTien.All());
            }
        }

        private void itemDelete_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            //Khong phat trien tinh nang nay
        }

        private void tileItem2_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            this.Close();
        }

        private void cbbFields_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        
    }
}
