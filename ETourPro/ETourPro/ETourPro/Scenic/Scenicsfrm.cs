using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess;

namespace ETourPro.Scenic
{
    public partial class Scenicsfrm : Form
    {

        public PowersLog Powers;

        public Scenicsfrm()
        {
            InitializeComponent();
        }

        private void Scenicsfrm_Load(object sender, EventArgs e)
        {
            grbManager.Visible = false;
            if (Powers == PowersLog.Administrator || Powers == PowersLog.Designer)
            {
                grbManager.Visible = true;
            }
                

            lvScenics_Load(DiemDL.All());
            //cbbColumn_Load();            
        }

        private void lvScenics_Load(List<DiemDL> list)
        {
            lvScenics.Items.Clear();
            ListViewItem i;
            foreach (DiemDL item in list)
            {
                i = lvScenics.Items.Add(item.ID.ToString());
                i.SubItems.Add(item.TenDiem);
                i.SubItems.Add(item.TenDD);
                i.SubItems.Add(item.DiaChi);
            }
        }

        private void lvHotels_Load(List<KhachSan> list)
        {
            lvHotels.Items.Clear();
            ListViewItem i;
            foreach (KhachSan item in list)
            {
                i = lvHotels.Items.Add(item.ID.ToString());
                i.SubItems.Add(item.TenKS);
                i.SubItems.Add(item.SoSao.ToString());
                i.SubItems.Add(item.SoDienThoai);
                i.SubItems.Add(item.DiaChi);                
            }
        }

        private void lvTours_Load(List<Tour> list)
        {
            lvTours.Items.Clear();
            ListViewItem i;
            foreach (Tour item in list)
            {
                i = lvTours.Items.Add(item.ID.ToString());
                i.SubItems.Add(item.TenTour);
                i.SubItems.Add(item.XuatPhat);
                i.SubItems.Add(item.TrangThai);
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            lvScenics_Load(DiemDL.All());
        }

        private void lvScenics_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvScenics.SelectedItems.Count > 0)
            {
                lvHotels_Load(KhachSan.FindMDiemDL(MyConvert.ToInt32(lvScenics.SelectedItems[0].SubItems[0].Text)));
                lvTours_Load(Tour.FindByCodeScenic(MyConvert.ToInt32(lvScenics.SelectedItems[0].SubItems[0].Text)));
            }
            else
            {
                lvHotels.Items.Clear();
                lvTours.Items.Clear();
            }
        }

        private void cbbColumn_Load()
        { 
            object[] s = DiemDL.ColumnNames();
            cbbColumn.Items.AddRange(s);
        }

        private void cbbColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvScenics_Load(DiemDL.SearchFields(cbbColumn.SelectedItem.ToString(), txtValueField.Text));
        }

        private void txtSearchKey_EditValueChanged(object sender, EventArgs e)
        {
            lvScenics_Load(DiemDL.SearchKey(txtSearchKey.Text));
        }

        private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            this.Close();
        }

        private void itemAdd_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Scenicfrm frm = new Scenicfrm();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                lvScenics_Load(DiemDL.All());
            }
        }

        private void itemUpdate_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (lvScenics.SelectedItems.Count > 0)
            {
                Scenicfrm frm = new Scenicfrm();
                frm.Code = MyConvert.ToInt32(lvScenics.SelectedItems[0].SubItems[0].Text);
                frm.ShowDialog();
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    lvScenics_Load(DiemDL.All());
                }
            }
        }



    }
}
