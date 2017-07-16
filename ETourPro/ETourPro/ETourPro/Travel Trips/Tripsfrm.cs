using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess;

namespace ETourPro.Travel_Trips
{
    public partial class Tripsfrm : Form
    {
        PowersLog _Powers;

        public PowersLog Powers
        {
            get { return _Powers; }
            set { _Powers = value; }
        }

        private string expression = "";

        List<Chuyen> listTrip = new List<Chuyen>();

        public Tripsfrm()
        {
            InitializeComponent();
        }

        private void Tripsfrm_Load(object sender, EventArgs e)
        {
            btnAdd.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            if (Powers == PowersLog.Administrator || Powers == PowersLog.Saler)
            {
                btnAdd.Visible = true;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
            }

            dtpValue.EditValue = DateTime.Now;
            dtpValue.Visible = false;
            listTrip = Chuyen.All();
            UpdateStatus();
            listTrip = Chuyen.All();
            btnAll.PerformClick();
            cbbColumn_Load();
            RadiosCheckState();
        }

        private void UpdateStatus()
        {
            List<Chuyen> list = listTrip.FindAll(
                delegate(Chuyen t)
                {
                    return (t.TrangThai == 1 && t.NgayDi >= DateTime.Now);
                });
            if (list.Count > 0)
            {
                foreach (Chuyen item in list)
                {
                    item.TrangThai = 0;
                    if (!Chuyen.Update(item))
                    {
                        DialogResult dlg = MessageBox.Show(String.Format("Updating had been failse at the trip which has code {0}! Do you want to be Updeting?", item.MChuyen), "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                        if (dlg == System.Windows.Forms.DialogResult.No) return;
                    }
                }
                MessageBox.Show("Updating is sucessful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                item.SubItems.Add(i.XuatPhat);
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

        private void lvCustomers_Load(List<KhachHang> list)
        {
            lvCustomers.Items.Clear();
            foreach (KhachHang i in list)
            {
                ListViewItem item = lvCustomers.Items.Add(i.ID);
                item.SubItems.Add(i.Ho + " " + i.Ten);
                item.SubItems.Add(i.NgaySinh.ToShortDateString());
                item.SubItems.Add(i.GTinh? "Nam":"Nữ");
                item.SubItems.Add(i.SoDT);
                item.SubItems.Add(i.SoTaiKhoan);
                item.SubItems.Add(i.DiaChi);
                item.SubItems.Add(i.ThanhPho);
                item.SubItems.Add(i.QuocGia);
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

        private void cbbColumn_Load()
        {
            object[] s = Chuyen.ColumnNames();
            cbbColumn.Items.AddRange(s);
            cbbColumnLoad(s);
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            lvTrips_Load(listTrip);
        }

        private void lvTrips_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTrips.SelectedItems.Count > 0)
            {
                int _Machuyen = MyConvert.ToInt32(lvTrips.SelectedItems[0].SubItems[0].Text);
                int _MaTour = 0;
                foreach (Chuyen item in listTrip)
	            {
		            if(item.MChuyen == _Machuyen)
                    {
                        _MaTour = item.MTour;
                        break;
                    }
	            }
                lvScenics_Load(DiemDL.FindByMTour(_MaTour));
                lvGuide_Load(HuongDanVien.FindByMChuyen(_Machuyen));
                lvHotels_Load(KhachSan.FindByMTour(_MaTour));
                lvVehicles_Load(PhuongTien.FindByMTour(_MaTour));
                lvCustomers_Load(KhachHang.FindByMChuyen(_Machuyen));
                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
            else
            {
                lvGuide.Items.Clear();
                lvHotels.Items.Clear();
                lvScenics.Items.Clear();
                lvCustomers.Items.Clear();
                btnUpdate.Enabled = false;
                btnDelete.Enabled = false;
            }
        }

        private void cbbColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbColumn.SelectedItem.ToString() == "Start Date" || cbbColumn.SelectedItem.ToString() == "End Date")
            {
                txtValueField.Visible = false;
                dtpValue.Visible = true;
                btnSearchOption.Enabled = true;
                return;
            }
            btnSearchOption.Enabled = false;
            txtValueField.Visible = true;
            dtpValue.Visible = false;
            if (cbbColumn.SelectedIndex >= 0)
                txtValueField.Enabled = true;
            else
                txtValueField.Enabled = false;
            txtValueField.Text = "";
        }

        private void txtValueField_KeyPress(object sender, KeyPressEventArgs e)
        {            
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            if (cbbColumn.SelectedItem.ToString() == "Code")
            {
                if (Char.IsDigit(e.KeyChar)) e.Handled = false;
                else e.Handled = true;
                return;
            }

            if (cbbColumn.SelectedItem.ToString() == "Price")
            {
                if (txtValueField.Text == "" && !Char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }

                if (txtValueField.Text.Contains("."))
                {
                    if (Char.IsDigit(e.KeyChar))
                        e.Handled = false;
                    else
                        e.Handled = true;
                }
                else
                {
                    if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.')
                        e.Handled = false;
                    else
                        e.Handled = true;
                }
                return;
            }

        }

        private void txtValueField_EditValueChanged(object sender, EventArgs e)
        {
            if (txtValueField.Text != "") btnSearchOption.Enabled = true;
            else btnSearchOption.Enabled = false;
        }

        private void btnSearchOption_Click(object sender, EventArgs e)
        {
            foreach (Chuyen item in listTrip)
            {
                switch (cbbColumn.SelectedItem.ToString())
                {
                    case "Code":
                        lvTrips_Load(FindByCode(MyConvert.ToInt32(txtValueField.Text)));
                        return;
                    case "Tour":
                        lvTrips_Load(FindByTour(txtValueField.Text));
                        return;
                    case "Start Date":
                        lvTrips_Load(FindByStartDate(MyConvert.ToDateTime(dtpValue.EditValue)));
                        return;
                    case "End Date":
                        lvTrips_Load(FindByEndDate(MyConvert.ToDateTime(dtpValue.EditValue)));
                        return;
                    case "Price":
                        lvTrips_Load(FindByPrice(MyConvert.ToDouble(txtValueField.Text)));
                        return;
                    case "Start Place":
                        lvTrips_Load(FindByStartPlace(txtValueField.Text));
                        return;
                    default:
                        btnAll.PerformClick();
                        break;
                }
            }
        }

        private List<Chuyen> FindByCode(int _Code)
        { 
            string code = _Code.ToString();
            List<Chuyen> results = listTrip.FindAll(
             delegate(Chuyen t)
             {
                 string m = t.MChuyen.ToString();
                 return m.Contains(code);
             }
             );
            IOrderedEnumerable<Chuyen> l = results.OrderByDescending(x => x.MChuyen, new IntComparer());
            results = new List<Chuyen>();
            foreach (Chuyen item in l)
            {
                results.Add(item);
            }
            return results;
        }

        private List<Chuyen> FindByTour(string _Tour)
        {
            List<Chuyen> results = listTrip.FindAll(
             delegate(Chuyen t)
             {
                 return t.TenTour.Contains(_Tour);
             }
             );
            results.Sort(ScenicCompare.CompareScenicByTourName);
            return results;
        }

        private List<Chuyen> FindByStartDate(DateTime _date)
        {
            List<Chuyen> results = listTrip.FindAll(
            delegate(Chuyen t)
            {
                return t.NgayDi < _date;
            });
            IOrderedEnumerable<Chuyen> l = results.OrderByDescending(m => m.NgayDi.ToShortDateString(), new DateTimeComparer());
            results = new List<Chuyen>();
            foreach (Chuyen item in l)
            {
                results.Add(item);
            }
            return results;
        }

        private List<Chuyen> FindByEndDate(DateTime _date)
        {
            List<Chuyen> results = listTrip.FindAll(
            delegate(Chuyen t)
            {
                return t.NgayVe < _date;
            });
            IOrderedEnumerable<Chuyen> l = results.OrderByDescending(m => m.NgayVe.ToShortDateString(), new DateTimeComparer());
            results = new List<Chuyen>();
            foreach (Chuyen item in l)
            {
                results.Add(item);
            }
            return results;
        }

        private List<Chuyen> FindByPrice(double _price)
        {
            List<Chuyen> results = listTrip.FindAll(
            delegate(Chuyen t)
            {
                return t.Gia < _price;
            }
            );
            IOrderedEnumerable<Chuyen> l = results.OrderByDescending(m => m.Gia, new DoubleComparer());
            results = new List<Chuyen>();
            foreach (Chuyen item in l)
            {
                results.Add(item);
            }
            return results;
        }

        private List<Chuyen> FindByStartPlace(string _StartPlace)
        {
            List<Chuyen> results = listTrip.FindAll(
             delegate(Chuyen t)
             {
                 return t.XuatPhat.Contains(_StartPlace);
             }
             );
            results.Sort(ScenicCompare.CompareScenicByStartPlace);
            return results;
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
            lvTrips_Load(listTrip.FindAll(FindKey));          
        }

        private bool FindKey(Chuyen t)
        {
            string value = txtSearchKey.Text;
            if (t.MChuyen.ToString().Contains(value)) return true;
            else if (t.TenTour.ToString().Contains(value)) return true;
            else if (t.TrangThai.ToString().Contains(value)) return true;
            else if (t.XuatPhat.ToString().Contains(value)) return true;
            else if (t.NgayDi.ToShortDateString().Contains(value)) return true;
            else if (t.NgayVe.ToShortDateString().Contains(value)) return true;
            else return false;
        }

        private void cbbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbStatus.SelectedIndex >= 0)
            {
                //lvTrips_Load(listTrip.FindAll(
                //    delegate(Chuyen t)
                //    {
                //        return t.TrangThai == (cbbStatus.SelectedItem.ToString() == "Đang mở" ? 1 : cbbStatus.SelectedItem.ToString() == "Đã hủy" ? -1 : 0);
                //    }
                //    ));
                lvTrips_Load(Chuyen.FindByStatus(cbbStatus.SelectedItem.ToString() == "Đang mở" ? 1 : cbbStatus.SelectedItem.ToString() == "Đã hủy" ? -1 : 0));
            }
            else
                btnAll.PerformClick();
        }

        private void dtpStart_EditValueChanged(object sender, EventArgs e)
        {
            if (dtpStart.Text != "")
            {
                dtpEnd.Enabled = true;
                dtpEnd.Text = dtpStart.Text;
            }
            else
                dtpEnd.Enabled = false;            
        }

        private void dtpEnd_EditValueChanged(object sender, EventArgs e)
        {
            DateTime start = DateTime.Parse(dtpStart.Text);
            DateTime end = DateTime.Parse(dtpEnd.Text);
            if (start > end)
            {
                MessageBox.Show("The end date must be less than the start date!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpEnd.Text = dtpStart.Text;
                dtpEnd.Focus();
                return;
            }
            btnSearchTime.Enabled = true;
        }

        private void btnSearchTime_Click(object sender, EventArgs e)
        {
            DateTime start = DateTime.Parse(dtpStart.Text);
            DateTime end = DateTime.Parse(dtpEnd.Text);
            lvTrips_Load(listTrip.FindAll(
                delegate(Chuyen t)
                {
                    return t.NgayDi.Date >= start.Date && t.NgayVe.Date <= end.Date;
                }
                ));
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
            {
                cbbColumns.SelectedIndex = 0;
                cbbperator.SelectedIndex = 0;
            }
        }

        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (txtValue.Text != "")
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
            else
            {
                expression = "";
            }

            ListViewItem item = new ListViewItem(andor);
            string value = txtValue.Visible ? txtValue.Text : dtpValues.Text;
            item.SubItems.Add(cbbColumns.Text + ' ' + cbbperator.Text + ' ' + value + ' ');
            if(cbbperator.SelectedItem.ToString() == "LIKE")
                expression += andor + ' ' + cbbColumns.Text + '*' + cbbperator.Text + " \'%" + value + "%\' *";
            else
                expression += andor + ' ' + cbbColumns.Text + '*' + cbbperator.Text + " \'" + value + "\' *";
            lv.Items.Add(item);
            this.RadiosCheckState();
            btnAddExpr.Enabled = false;
        }

        private void txtValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }

            if (cbbColumns.SelectedItem.ToString() == "Code")
            {
                if (Char.IsDigit(e.KeyChar)) e.Handled = false;
                else e.Handled = true;
                return;
            }

            if (cbbColumns.SelectedItem.ToString() == "Price")
            {
                if (txtValue.Text == "" && !Char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                    return;
                }

                if (txtValue.Text.Contains("."))
                {
                    if (Char.IsDigit(e.KeyChar))
                        e.Handled = false;
                    else
                        e.Handled = true;
                }
                else
                {
                    if (Char.IsDigit(e.KeyChar) || e.KeyChar == '.')
                        e.Handled = false;
                    else
                        e.Handled = true;
                }
                return;
            }           

        }

        private void btnSearchAdvance_Click(object sender, EventArgs e)
        {
            lvTrips_Load(Chuyen.Find(expression));
            expression = "";
            lv.Items.Clear();
            RadiosCheckState();
        }

        private void cbbColumns_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtValue.Text = "";
            btnSearchAdvance.Enabled = false;
            if (cbbColumns.SelectedItem.ToString() == "Start Date" || cbbColumns.SelectedItem.ToString() == "End Date")
            {
                txtValue.Visible = false;
                dtpValues.Visible = true;
                return;
            }
            txtValue.Visible = true;
            dtpValues.Visible = false;
            btnAddExpr.Enabled = false;
        }

        private void dtpValues_TextChanged(object sender, EventArgs e)
        {
            if (dtpValues.Text.Length > 0)
                btnAddExpr.Enabled = true;
            else
                btnAddExpr.Enabled = false;
        }

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Tripfrm frm = new Tripfrm();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                listTrip = Chuyen.All();
                btnAll.PerformClick();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Tripfrm frm = new Tripfrm();
            frm.MChuyen = MyConvert.ToInt32(lvTrips.SelectedItems[0].SubItems[0].Text);
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                listTrip = Chuyen.All();
                btnAll.PerformClick();
            }
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Are you want to delete this trip?", "Quession", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                if (!Chuyen.Delete(MyConvert.ToInt32(lvTrips.SelectedItems[0].SubItems[0].Text)))
                {
                    MessageBox.Show("Deleting had been faile", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Deleting is sucessful", "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    btnAll.PerformClick();
                }
            }
        }

        

        


    }

    


}
