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
    public partial class Localsfrm : Form
    {
        PowersLog _Powers;

        public PowersLog Powers
        {
            get { return _Powers; }
            set { _Powers = value; }
        }        

        public Localsfrm()
        {
            InitializeComponent();
        }

        private void Localsfrm_Load(object sender, EventArgs e)
        {
            grbManager.Visible = false;
            if (Powers == PowersLog.Administrator || Powers == PowersLog.Designer)
            {
                grbManager.Visible = true;
            }

            cbbColumn_Load();
            lvLocals_Load(DiaDiemDL.All());

        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            lvLocals_Load(DiaDiemDL.All());
        }

        private void lvLocals_Load(List<DiaDiemDL> list)
        {
            lvLocals.Items.Clear();
            foreach (DiaDiemDL item in list)
            {
                ListViewItem i = lvLocals.Items.Add(item.ID.ToString());
                i.SubItems.Add(item.TenDD);
                i.SubItems.Add(item.QuocGia);
            }
        }

        private void lvScenics_Load(List<DiemDL> list)
        {
            lvScenics.Items.Clear();
            foreach (DiemDL item in list)
            {
                ListViewItem i = lvScenics.Items.Add(item.ID.ToString());
                i.SubItems.Add(item.TenDiem);
                i.SubItems.Add(item.DiaChi);
            }
        }

        private void lvLocals_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvLocals.SelectedItems.Count > 0)
            {
                int mdd = MyConvert.ToInt32(lvLocals.SelectedItems[0].SubItems[0].Text);
                lvScenics_Load(DiemDL.FindByMaDD(mdd));
            }
            else
                lvScenics.Items.Clear();
        }

        private void cbbColumn_Load()
        {
            object[] s = DiaDiemDL.ColumnNames();
            cbbColumn.Items.AddRange(s);
            cbbCountry_Load();
        }

        private void cbbCountry_Load()
        {
            cbbCounty.DataSource = DiaDiemDL.AllCountries();
            cbbCounty.DisplayMember = "QuocGia";
            cbbCounty.ValueMember = "QuocGia";
        }

        private void cbbColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbCountry_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvLocals_Load(DiaDiemDL.SearchFields(cbbColumn.SelectedItem.ToString(), txtValueField.Text));
        }

        private void cbbCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            DiaDiemDL dd = cbbCounty.SelectedItem as DiaDiemDL;
            lvLocals_Load(DiaDiemDL.FindByContry(dd.QuocGia));
        }

        private void txtSearchKey_EditValueChanged(object sender, EventArgs e)
        {
            lvLocals_Load(DiaDiemDL.SearchKey(txtSearchKey.Text));
        }

        private void itemAdd_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Localfrm frm = new Localfrm();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                lvLocals_Load(DiaDiemDL.All());
                cbbCounty.DataSource = DiaDiemDL.AllCountries();
            }
        }

        private void itemUpdate_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (lvLocals.SelectedItems.Count > 0)
            {
                Localfrm frm = new Localfrm();
                frm.Code = MyConvert.ToInt32(lvLocals.SelectedItems[0].SubItems[0].Text);
                frm.ShowDialog();
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    lvLocals_Load(DiaDiemDL.All());
                    cbbCounty.DataSource = DiaDiemDL.AllCountries();
                }
            }
        }

        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            this.Close();
        }





    }
}
