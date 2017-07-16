using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DataAccess;
using ETourPro.Scenic;
using ETourPro.Hotels;
using ETourPro.vehicles;
using ETourPro.travel_guide;

namespace ETourPro.Tours
{
    public partial class Toursfrm : DevExpress.XtraEditors.XtraForm
    {
        PowersLog _Powers;

        public PowersLog Powers
        {
            get { return _Powers; }
            set { _Powers = value; }
        }

        private string expression = "";

        public Toursfrm()
        {
            InitializeComponent();
        }

        private void Toursfrm_Load(object sender, EventArgs e)
        {
            btnAll.PerformClick();
            grbManager.Visible = false;
            if (Powers == PowersLog.Administrator || Powers == PowersLog.Designer)
            {
                grbManager.Visible = true;
            }
            else
            {
                updateToolStripMenuItem.Visible = false;
                toolStripMenuItem3.Visible = false;
                toolStripMenuItem7.Visible = false;
                updateToolStripMenuItem1.Visible = false;
                btnAdd.Visible = false;
                btnUpdate.Visible = false;
                btnDelete.Visible = false;
            }
            cbbColumn_Load();
            cbbStatus_Load();
            cbbperator.SelectedIndex = 0;
            RadiosCheckState();
            cbbColumnLoad(Tour.ColumnNames());
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
                item.SubItems.Add(i.TrangThai ? "Đang làm việc" : "Đang nghỉ làm");
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            lvTours_Load(Tour.All());
        }

        private void lvTours_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTours.SelectedItems.Count > 0)
            {
                int _MaTour = MyConvert.ToInt32(lvTours.SelectedItems[0].SubItems[0].Text);
                lvScenics_Load(DiemDL.FindByMTour(_MaTour));
                lvHotels_Load(KhachSan.FindByMTour(_MaTour));
                lvVehicles_Load(PhuongTien.FindByMTour(_MaTour));
                lvGuide_Load(HuongDanVien.FindByMTour(_MaTour));
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                lvGuide.Items.Clear();
                lvHotels.Items.Clear();
                lvScenics.Items.Clear();
                lvVehicles.Items.Clear();
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e)
        {
            btnAll.PerformClick();
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scenicsfrm frm = new Scenicsfrm();
            frm.Powers = this.Powers;
            frm.ShowDialog();
            if (lvTours.SelectedItems.Count > 0)
            {
                int _MaTour = MyConvert.ToInt32(lvTours.SelectedItems[0].SubItems[0].Text);
                lvScenics_Load(DiemDL.FindByMTour(_MaTour));
            }
        }

        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvTours.SelectedItems.Count > 0 && lvScenics.SelectedItems.Count > 0)
            {
                int cod = MyConvert.ToInt32(lvScenics.SelectedItems[0].SubItems[0].Text);
                Scenicfrm frm = new Scenicfrm();
                frm.Code = cod;
                frm.ShowDialog();
                if(frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                    lvScenics_Load(DiemDL.FindByMTour(MyConvert.ToInt32(lvTours.SelectedItems[0].SubItems[0].Text)));
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Hotelsfrm frm = new Hotelsfrm();
            frm.Powers = this.Powers;
            frm.ShowDialog();
            if (lvTours.SelectedItems.Count > 0)
            {
                int _MaTour = MyConvert.ToInt32(lvTours.SelectedItems[0].SubItems[0].Text);
                lvHotels_Load(KhachSan.FindByMTour(_MaTour));
            }
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            if (lvTours.SelectedItems.Count > 0 && lvHotels.SelectedItems.Count > 0)
            {
                int cod = MyConvert.ToInt32(lvHotels.SelectedItems[0].SubItems[0].Text);
                Hotelfrm frm = new Hotelfrm();
                frm.Code = cod;
                frm.ShowDialog();
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                    lvHotels_Load(KhachSan.FindByMTour(MyConvert.ToInt32(lvTours.SelectedItems[0].SubItems[0].Text)));
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            vehiclesfrm frm = new vehiclesfrm();
            frm.Powers = this.Powers;
            frm.ShowDialog();
            if (lvTours.SelectedItems.Count > 0)
            {
                int _MaTour = MyConvert.ToInt32(lvTours.SelectedItems[0].SubItems[0].Text);
                lvVehicles_Load(PhuongTien.FindByMTour(_MaTour));
                //lvGuide_Load(HuongDanVien.FindByMTour(_MaTour));
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)
        {
            if (lvTours.SelectedItems.Count > 0 && lvVehicles.SelectedItems.Count > 0)
            {
                int cod = MyConvert.ToInt32(lvVehicles.SelectedItems[0].SubItems[0].Text);
                Vehiclefrm frm = new Vehiclefrm();
                frm.Code = cod;
                frm.ShowDialog();
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                    lvVehicles_Load(PhuongTien.FindByMTour(MyConvert.ToInt32(lvTours.SelectedItems[0].SubItems[0].Text)));
            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            travelGuidefrm frm = new travelGuidefrm();
            frm.Powers = this.Powers;
            frm.ShowDialog();
            if (lvTours.SelectedItems.Count > 0)
            {
                int _MaTour = MyConvert.ToInt32(lvTours.SelectedItems[0].SubItems[0].Text);
                lvGuide_Load(HuongDanVien.FindByMTour(_MaTour));
            }
        }

        private void updateToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            if (lvTours.SelectedItems.Count > 0 && lvGuide.SelectedItems.Count > 0)
            {
                Guiderfrm frm = new Guiderfrm();
                frm.MaSo = lvGuide.SelectedItems[0].SubItems[0].Text;
                frm.ShowDialog();
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                    lvVehicles_Load(PhuongTien.FindByMTour(MyConvert.ToInt32(lvTours.SelectedItems[0].SubItems[0].Text)));
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbbColumn_Load()
        {
            object[] s = Tour.ColumnNames();
            cbbColumn.Items.AddRange(s);
        }

        private void cbbColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbColumn.SelectedIndex > -1)
            {
                txtValueField.Enabled = true;
            }
            else
                txtValueField.Enabled = false;
            txtValueField.Text = "";
        }

        private void txtValueField_EditValueChanged(object sender, EventArgs e)
        {
            if (txtValueField.Text != "")
                btnSearchOption.Enabled = true;
            else
                btnSearchOption.Enabled = false;
        }

        private void txtValueField_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }
            if (cbbColumn.SelectedItem.ToString() == "Mã số")
            {
                if (Char.IsDigit(e.KeyChar)) e.Handled = false;
                else e.Handled = true;
                return;
            }
        }

        private void btnSearchOption_Click(object sender, EventArgs e)
        {
            lvTours_Load(Tour.SearchFields(cbbColumn.SelectedItem.ToString(), txtValueField.Text));
        }

        private void txtSearchKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            if (txtSearchKey.Text.Length >= 100)
            { e.Handled = true; }
            else e.Handled = false;
        }

        private void txtSearchKey_EditValueChanged(object sender, EventArgs e)
        {
            if (txtSearchKey.Text != "")
                btnSearchKey.Enabled = true;
            else
                btnSearchKey.Enabled = false;
        }

        private void btnSearchKey_Click(object sender, EventArgs e)
        {
            lvTours_Load(Tour.SearchByKey(txtSearchKey.Text));
        }

        private void cbbStatus_Load()
        {
            List<Tour> list = Tour.StatusAll();
            cbbStatus.Items.Add("--All--");
            foreach (Tour item in list)
            {
                cbbStatus.Items.Add(item.TrangThai);
            }            
        }

        private void cbbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbStatus.SelectedIndex > 0)
            {
                lvTours_Load(Tour.FindStatus(cbbStatus.SelectedItem.ToString()));
            }
            else
            {
                btnAll.PerformClick();
            }
        }

        #region Find Advance

        private void RadiosCheckState()
        {
            grbRelationExpression.Enabled = (lv.Items.Count > 0);
            btnSearchAdvance.Enabled = grbRelationExpression.Enabled;
        }

        public void cbbColumnLoad(object[] items)
        {
            cbbColumns.Items.Clear();
            cbbColumns.Items.AddRange(items);
            if (items.Length > 0)
                cbbColumns.SelectedIndex = 0;
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if(txtValue.Text != "")
                btnAddExpr.Enabled = true;
            else
                btnAddExpr.Enabled = false;
        }

        private void btnAddExpr_Click(object sender, EventArgs e)
        {
            string andor = "";
            if (grbRelationExpression.Enabled)
            {
                if (radAnd.Checked) andor = "AND";
                else andor = "OR";
            }

            ListViewItem item = new ListViewItem(andor);
            item.SubItems.Add(cbbColumns.Text + ' ' + cbbperator.Text + ' ' + txtValue.Text + ' ');
            if (cbbperator.SelectedItem.ToString() == "LIKE")
                expression += andor + ' ' + cbbColumns.Text + '*' + cbbperator.Text + " \'%" + txtValue.Text + "%\' *";
            else
                expression += andor + ' ' + cbbColumns.Text + '*' + cbbperator.Text + " \'" + txtValue.Text + "\' *";
            lv.Items.Add(item);
            this.RadiosCheckState();
            btnAdd.Enabled = false;
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }
            if (cbbColumns.SelectedItem.ToString() == "Mã số")
            {
                if (Char.IsDigit(e.KeyChar)) e.Handled = false;
                else e.Handled = true;
                return;
            }
        }

        private void btnSearchAdvance_Click(object sender, EventArgs e)
        {
            lvTours_Load(Tour.Find(expression));
            expression = "";
            lv.Items.Clear();
            RadiosCheckState();
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Tourfrm frm = new Tourfrm();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                btnAll.PerformClick();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (lvTours.SelectedItems.Count > 0)
            {
                Tourfrm frm = new Tourfrm();
                frm.ID = MyConvert.ToInt32(lvTours.SelectedItems[0].SubItems[0].Text);
                frm.ShowDialog();
                if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                    btnAll.PerformClick();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lvTours.SelectedItems.Count > 0)
            {
                DialogResult dlg = MessageBox.Show("Are you want to delete this tour?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dlg == System.Windows.Forms.DialogResult.Yes)
                {
                    if (Tour.Delete(MyConvert.ToInt32(lvTours.SelectedItems[0].SubItems[0].Text)))
                    {
                        MessageBox.Show("Deleting is successful?", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        btnAll.PerformClick();
                    }
                    else
                    {
                        MessageBox.Show("Deleting had been faile!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);                        
                    }
                }
            }
        }

        

        

        

        

    }
}