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
    public partial class travelGuidefrm : DevExpress.XtraEditors.XtraForm
    {
        public PowersLog Powers;

        public travelGuidefrm()
        {
            InitializeComponent();
        }

        private void travelGuidefrm_Load(object sender, EventArgs e)
        {
            if (Powers == PowersLog.Administrator || Powers == PowersLog.Designer)
            {
                expbarManager.Visible = true;
            }
            else
                expbarManager.Visible = false;

            lvGuide_Load(HuongDanVien.All());
            cbbCountry_Load();
            //cbbFields_Load();
        }        

        private void lvGuide_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvGuide.SelectedItems.Count > 0)
            {
                lvTours_Load(Tour.FindByMHDV(lvGuide.SelectedItems[0].SubItems[0].Text));
                lvTrips_Load(Chuyen.FindByHDV(lvGuide.SelectedItems[0].SubItems[0].Text));
                btnUpdate.Enabled = true;
            }
            else
            {
                btnUpdate.Enabled = false;
            }
        }

        private void txtSearchName_TextChanged(object sender, EventArgs e)
        {
            lvGuide_Load(HuongDanVien.FindByName(txtSearchName.Text));
        }

        private void txtKeySreach_TextChanged(object sender, EventArgs e)
        {
            lvGuide_Load(HuongDanVien.Search(txtKeySreach.Text));
        }

        private void cbbFields_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvGuide_Load(HuongDanVien.SearchFields(cbbFields.SelectedItem.ToString(), txtKeyOption.Text));
        }

        private void cbbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbStatus.SelectedIndex > 0)
            {
                if (cbbStatus.SelectedItem.ToString() == "Đang làm việc") lvGuide_Load(HuongDanVien.FindStatus(true));
                else
                    lvGuide_Load(HuongDanVien.FindStatus(false));
            }
            else
            {
                lvGuide_Load(HuongDanVien.All());
            }
        }

        private void lvGuide_Load(List<HuongDanVien> list)
        {
            lvGuide.Items.Clear();
            ListViewItem item;
            foreach (HuongDanVien i in list)
            {
                item = lvGuide.Items.Add(i.ID);
                item.SubItems.Add(i.Ho + " " + i.Ten);
                item.SubItems.Add(i.NgaySinh.ToShortDateString());
                item.SubItems.Add(i.GioiTinh ? "Nam" : "Nữ");
                item.SubItems.Add(i.DiaChi);
                item.SubItems.Add(i.QuocGia);
                item.SubItems.Add(i.DienThoai);
                item.SubItems.Add(i.TrangThai?"Đang làm việc":"Đang nghỉ làm");
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

        private void lvTrips_Load(List<Chuyen> list)
        {
            lvTrips.Items.Clear();
            ListViewItem item;
            foreach (Chuyen i in list)
            {
                item = lvTrips.Items.Add(i.MChuyen.ToString());
                item.SubItems.Add(i.TenTour);
                item.SubItems.Add(i.NgayDi.ToShortDateString());
                item.SubItems.Add(i.NgayVe.ToShortDateString());
                item.SubItems.Add(i.Gia.ToString());
                item.SubItems.Add(i.TrangThai >= 1 ? "Đang mở" : (i.TrangThai == 0 ? "Đã đóng" : "Đã hủy"));
            }
        }

        private void cbbCountry_Load()
        {
            List<HuongDanVien> list = HuongDanVien.FindAllCountries();
            cbbCountry.Items.Clear();
            cbbCountry.Items.Add("---All---");
            foreach (HuongDanVien item in list)
            {
                cbbCountry.Items.Add(item.QuocGia);
            }
        }

        private void cbbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gender = cbbGender.SelectedIndex > 0 ? cbbGender.SelectedItem.ToString() : "";
            string country = cbbCountry.SelectedIndex > 0 ? cbbCountry.SelectedItem.ToString() : "";
            if (gender == "" && country == "")
            {
                lvGuide_Load(HuongDanVien.All());
                return;
            }
            if (gender != "" && country == "")
            {
                if (gender == "Nam") 
                    lvGuide_Load(HuongDanVien.FindGender(true));
                else
                    lvGuide_Load(HuongDanVien.FindGender(false));
                return;
            }
            if (gender == "" && country != "")
            {
                lvGuide_Load(HuongDanVien.FindByCountry(country));
                return;
            }
            if (gender != "" && country != "")
            { 
                if(gender == "Nam") lvGuide_Load(HuongDanVien.FindByGenderAndCountry(true, country));
                else
                    lvGuide_Load(HuongDanVien.FindByGenderAndCountry(false, country));
                return;
            }
        }

        private void cbbFields_Load()
        {
            object[] s = HuongDanVien.ColumnNames();
            cbbFields.Items.AddRange(s);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Guiderfrm frm = new Guiderfrm();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                lvGuide_Load(HuongDanVien.All());
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvGuide.SelectedItems.Count > 0)
            {
                Guiderfrm frm = new Guiderfrm();
                frm.MaSo = lvGuide.SelectedItems[0].SubItems[0].Text;
                frm.ShowDialog();
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    lvGuide_Load(HuongDanVien.All());
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvGuide.CheckedItems.Count > 0)
            {
                DialogResult dlg =  MessageBox.Show("You want to delete the guiders who had been checked!", "Warrning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dlg == System.Windows.Forms.DialogResult.Yes)
                {
                    foreach (ListViewItem item in lvGuide.CheckedItems)
                    {
                        if (!HuongDanVien.Delete(item.SubItems[0].Text))
                            MessageBox.Show(String.Format("Delete guider who has id = {0} hab been faile!", item.SubItems[0].Text), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    lvGuide_Load(HuongDanVien.All());
                }
            }
            else
            {
                MessageBox.Show("You had been not choose the guiders!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

       

        
    }
}