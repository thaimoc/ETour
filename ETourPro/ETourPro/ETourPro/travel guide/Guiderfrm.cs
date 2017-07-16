using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataAccess;

namespace ETourPro.travel_guide
{
    public partial class Guiderfrm : DevExpress.XtraEditors.XtraForm
    {
        public string MaSo { get; set; }
        public Guiderfrm()
        {
            InitializeComponent();
        }
        private void Guiderfrm_Load(object sender, EventArgs e)
        {
            if (MaSo == null)
            {                
                txtCode.Text = HuongDanVien.NewBestID();
                itemAdd.ItemClick += new TileItemClickEventHandler(itemAdd_ItemClick);
                lvTours_Load(lvTours, Tour.All());
                lblLastName.Text = "You must enter last name!";
                lblfirstNameInfo.Text = "You must enter first name!";
                lblBirthDateInfo.Text = "Age must be less than 18!";
                cbbCountry.SelectedIndex = 0;
            }
            else
            {
                
                controlHDV_Load();
                lblLastName.Text = "";
                lblBirthDateInfo.Text = "";
            }
        }

        private void itemUpdate_ItemClick_1(object sender, TileItemEventArgs e)
        {
            if (MaSo != null)
            {
                if (txtLastName.Text.Length == 0)
                {
                    txtLastName.Focus();
                    lblLastName.Text = "You must enter last name!";
                    return;
                }

                if (txtFirstName.Text.Length == 0)
                {
                    txtFirstName.Focus();
                    lblfirstNameInfo.Text = "You must enter first name!";
                    return;
                }

                if (DateTime.Now.Year - dtpBirthDate.Value.Year < 18)
                {
                    MessageBox.Show("Age must be less than 18!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DateTime dt = new DateTime(DateTime.Now.Year - 18, DateTime.Now.Month, DateTime.Now.Day);
                    dtpBirthDate.Value = dt;
                    dtpBirthDate.Focus();
                    return;
                }

                if (MaSo != null)
                {
                    List<HDV_Tour> list = new List<HDV_Tour>();
                    HuongDanVien hdv = HDV_Load(ref list);
                    HuongDanVien exited = HuongDanVien.Single(txtCode.Text);
                    if (hdv.Ten != exited.Ten || hdv.Ho != exited.Ho)
                    {
                        if (HuongDanVien.FindByNameSingle(txtLastName.Text, txtFirstName.Text) != null)
                        {
                            DialogResult dlg = MessageBox.Show("This guider had ben exited! Do you want to add this guider?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (dlg == System.Windows.Forms.DialogResult.No)
                                return;
                        }
                    }

                    if (HuongDanVien.Update(hdv, list))
                    {
                        MessageBox.Show("Updating is successfull", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        lvTours_Load(lvSpecializedTours, HDV_Tour.FindByMHDV(MaSo));
                        lvTours_Load(lvTours, HDV_Tour.NotFindByMHDV(MaSo));
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Updating had being faile", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                    MessageBox.Show("Updating had been not allowed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        void itemAdd_ItemClick(object sender, TileItemEventArgs e)
        {
            if (txtLastName.Text.Length == 0)
            {
                txtLastName.Focus();
                lblLastName.Text = "You must enter last name!";
                return;
            }

            if (txtFirstName.Text.Length == 0)
            {
                txtFirstName.Focus();
                lblfirstNameInfo.Text = "You must enter first name!";
                return;
            }

            if (DateTime.Now.Year - dtpBirthDate.Value.Year < 18)
            {
                MessageBox.Show("Age must be less than 18!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DateTime dt = new DateTime(DateTime.Now.Year - 18, DateTime.Now.Month, DateTime.Now.Day);
                dtpBirthDate.Value = dt;
                lblBirthDateInfo.Text = "";
                dtpBirthDate.Focus();
                return;
            }

            if (HuongDanVien.FindByNameSingle(txtLastName.Text, txtFirstName.Text) != null)
            {
                DialogResult dlg = MessageBox.Show("This guider had ben exited! Do you want to add this guider?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dlg == System.Windows.Forms.DialogResult.No)
                    return;
            }

            if (MaSo == null)
            {
                List<HDV_Tour> list = new List<HDV_Tour>();
                HuongDanVien hdv = HDV_Load(ref list);
                if (HuongDanVien.Add(hdv))
                {
                    MessageBox.Show("Adding is successfull", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    MaSo = txtCode.Text;
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                    MessageBox.Show("Adding had being faile", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Adding had been not allowed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private HuongDanVien HDV_Load(ref List<HDV_Tour> list)
        {
            HuongDanVien result = new HuongDanVien();
            result.ID = txtCode.Text;
            result.Ho = txtLastName.Text;
            result.Ten = txtFirstName.Text;
            result.NgaySinh = dtpBirthDate.Value;
            if (rdMale.Checked)
                result.GioiTinh = true;
            else
                result.GioiTinh = false;
            result.DiaChi = txtAddress.Text;
            result.QuocGia = cbbCountry.Text;
            result.DienThoai = txtPhone.Text;
            result.TrangThai = ckbStatus.Checked;

            if (MaSo != null)
            {
                List<Tour> list2 = new List<Tour>();
                // DS tour da thong thuoc
                list2 = HDV_Tour.FindByMHDV(MaSo);
                // Tao ds tour thong thuoc moi them
                foreach (ListViewItem item in lvSpecializedTours.Items)
                {
                    bool rs = true;
                    foreach (Tour tour in list2)
                    {
                        if (item.SubItems[0].Text == tour.ID.ToString())
                        {
                            rs = false;
                            break;
                        }
                    }
                    if (rs)
                        list.Add(new HDV_Tour(MaSo, MyConvert.ToInt32(item.SubItems[0].Text)));
                }
            }
            else
            {
                // Tao ds tour thong thuoc
                foreach (ListViewItem item in lvSpecializedTours.Items)
                    list.Add(new HDV_Tour(txtCode.Text, MyConvert.ToInt32(item.SubItems[0].Text)));
            }
            return result;
        }

        private void controlHDV_Load()
        {
            HuongDanVien hdv = HuongDanVien.Single(MaSo);
            txtCode.Text = hdv.ID;
            txtLastName.Text = hdv.Ho;
            txtFirstName.Text = hdv.Ten;
            dtpBirthDate.Value = hdv.NgaySinh;
            rdMale.Checked = hdv.GioiTinh ? true : false;
            txtAddress.Text = hdv.DiaChi;
            txtPhone.Text = hdv.DienThoai;
            cbbCountry.Text = hdv.QuocGia;
            dtpBirthDate.Text = hdv.NgaySinh.ToShortDateString();
            ckbStatus.Checked = hdv.TrangThai;

            lvTours_Load(lvSpecializedTours, HDV_Tour.FindByMHDV(MaSo));
            lvTours_Load(lvTours, HDV_Tour.NotFindByMHDV(MaSo));
        }

        private void lvTours_Load(ListView lv, List<Tour> list)
        {
            lv.Items.Clear();
            ListViewItem item;
            foreach (Tour i in list)
            {
                item = lv.Items.Add(i.ID.ToString());
                item.SubItems.Add(i.TenTour);
                item.SubItems.Add(i.TrangThai);
                item.SubItems.Add(i.TrangThai);
            }
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsDigit(e.KeyChar) && txtPhone.Text.Length < 24) || Char.IsControl(e.KeyChar))
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void dtpBirthDate_ValueChanged(object sender, EventArgs e)
        {
            if (DateTime.Now.Year - dtpBirthDate.Value.Year < 18)
            {
                MessageBox.Show("Age must be less than 18!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DateTime dt = new DateTime(DateTime.Now.Year - 18, DateTime.Now.Month, DateTime.Now.Day);
                lblBirthDateInfo.Text = "";
                dtpBirthDate.Value = dt;
                
            }
        }

        private void itemAddTour_ItemClick(object sender, TileItemEventArgs e)
        {
            if (lvTours.CheckedItems.Count > 0)
            {
                DialogResult dlg = MessageBox.Show("Do you want to add the tours which had been checked?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == System.Windows.Forms.DialogResult.Yes)
                {
                    ListViewItem i;
                    foreach (ListViewItem item in lvTours.CheckedItems)
                    {
                        int count = item.SubItems.Count;
                        i = new ListViewItem(item.SubItems[0].Text);
                        for (int k = 1; k < count; k++)
                        {
                            i.SubItems.Add(item.SubItems[k].Text);
                        }
                        lvSpecializedTours.Items.Add(i);
                    }
                    for (int j = 0; j < lvTours.Items.Count;)
                    {
                        if (lvTours.Items[j].Checked)
                        {
                            lvTours.Items.RemoveAt(j);
                        }
                        else
                            j++;
                    }
                }
            }
            else
            {
                MessageBox.Show("You do not choose the tours which was in the List of specialized Tours", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tileItem6_ItemClick(object sender, TileItemEventArgs e)
        {
            this.Close();
        }

        private void txtLastName_EditValueChanged(object sender, EventArgs e)
        {
            if (txtLastName.Text.Length == 0)
            {
                lblLastName.Text = "You must enter last name!";
            }
            else
            {
                lblLastName.Text = "";
            }
        }

        private void txtFirstName_EditValueChanged(object sender, EventArgs e)
        {
            if (txtLastName.Text.Length == 0)
            {
                lblfirstNameInfo.Text = "You must enter first name!";
            }
            else
            {
                lblfirstNameInfo.Text = "";
            }
        }

        private void cbbCountry_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void ckbStatus_CheckedChanged(object sender, EventArgs e)
        {
            //Thoi check khi huong dan vien khong con chuyen nao dang cho
        }

        

         


    }
}