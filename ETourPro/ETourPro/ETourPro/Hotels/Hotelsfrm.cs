using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess;

namespace ETourPro.Hotels
{
    public partial class Hotelsfrm : DevComponents.DotNetBar.Office2007RibbonForm
    {
        PowersLog _Powers = PowersLog.User;

        public PowersLog Powers
        {
            get { return _Powers; }
            set { _Powers = value; }
        }      

        public Hotelsfrm()
        {
            InitializeComponent();
        }

        private void Hotelsfrm_Load(object sender, EventArgs e)
        {
            //grbManager.Visible = false;
            //if (Powers == PowersLog.Administrator || Powers == PowersLog.Designer)
            //{
            //    grbManager.Visible = true;
            //}
            lvHotels_Load(KhachSan.All());
            cbbColumn_Load();
        }

        private void lvHotels_Load(List<KhachSan> list)
        {
            lvHotels.Items.Clear();
            ListViewItem it;
            foreach (KhachSan item in list)
            {
                it = lvHotels.Items.Add(item.ID.ToString());
                it.SubItems.Add(item.TenKS);
                it.SubItems.Add(item.SoSao.ToString());
                it.SubItems.Add(item.SoDienThoai);
                it.SubItems.Add(item.DiaChi);
            }
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

        private void lvHotels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvHotels.SelectedItems.Count > 0)
            {
                lvScenics_Load(DiemDL.FindByMaKS(MyConvert.ToInt32(lvHotels.SelectedItems[0].SubItems[0].Text)));
                lvTours_Load(Tour.FindByMKSan(MyConvert.ToInt32(lvHotels.SelectedItems[0].SubItems[0].Text)));
            }
            else
            {
                lvTours.Items.Clear();
                lvScenics.Items.Clear();
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            lvHotels_Load(KhachSan.All());
        }

        private void cbbColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbColumn_Load()
        {
            object[] s = KhachSan.ColumnNames();
            cbbColumn.Items.AddRange(s);
        }

        private void cbbColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbColumn.SelectedIndex > -1)
            {
                txtValueField.Enabled = true;
            }
        }

        private void txtValueField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbbColumn.SelectedItem.ToString() == "Mã số" || cbbColumn.SelectedItem.ToString() == "Số điện thoại")
            {
                if (Char.IsControl(e.KeyChar) || Char.IsDigit(e.KeyChar))
                    e.Handled = false;
                else
                    e.Handled = true;
                return;
            }

            if (cbbColumn.SelectedItem.ToString() == "Số sao")
            {
                if ((MyConvert.ToInt32(e.KeyChar.ToString()) <= 7 && Char.IsDigit(e.KeyChar)) || Char.IsControl(e.KeyChar) || e.KeyChar == '.')
                {
                    if (Char.IsControl(e.KeyChar) || (txtValueField.Text.Length == 0 && Char.IsDigit(e.KeyChar))) e.Handled = false;
                    else if (txtValueField.Text.Length == 1 && e.KeyChar == '.') e.Handled = false;
                    else if (txtValueField.Text.Length == 2 && MyConvert.ToInt32(e.KeyChar.ToString()) == 5) e.Handled = false;
                    else e.Handled = true;
                }
                else
                    e.Handled = true;

                //if (txtValueField.Text == "")
                //{
                //    if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
                //        e.Handled = false;
                //    else
                //        e.Handled = true;
                //}
                //else if (txtValueField.Text.Contains("."))
                //{
                //    if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
                //        e.Handled = false;
                //    else
                //        e.Handled = true;
                //}
                //else
                //{
                //    if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar) || e.KeyChar == '.')
                //        e.Handled = false;
                //    else
                //        e.Handled = true;
                //}
            }

        }

        private void txtValueField_EditValueChanged(object sender, EventArgs e)
        {
            if (txtValueField.Text != "")
                btnSearchOption.Enabled = true;
            else
                btnSearchOption.Enabled = false;
        }

        private void btnSearchOption_Click(object sender, EventArgs e)
        {
            lvHotels_Load(KhachSan.SearchFields(cbbColumn.SelectedItem.ToString(), txtValueField.Text));
        }

        private void txtSearchKey_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSearchKey.Text == "")
                btnSearchKey.Enabled = false;
            else
                btnSearchKey.Enabled = true;
        }

        private void btnSearchKey_Click(object sender, EventArgs e)
        {
            lvHotels_Load(KhachSan.SearchKey(txtSearchKey.Text));
        }

        private void itemAdd_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            Hotelfrm frm = new Hotelfrm();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                btnAll.PerformClick();
        }

        private void itemUpdate_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            if (lvHotels.SelectedItems.Count > 0)
            {
                Hotelfrm frm = new Hotelfrm();
                frm.Code = MyConvert.ToInt32(lvHotels.SelectedItems[0].SubItems[0].Text);
                frm.ShowDialog();
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                    btnAll.PerformClick();
            }
        }

        private void itemDelete_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        {
            MessageBox.Show("Chưa phát triển tính năng này!");
        }

        //private void tileItem1_ItemClick(object sender, DevExpress.XtraEditors.TileItemEventArgs e)
        //{
        //    this.Close();
        //}

        private void btnCencel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        


        





    }
}
