using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess;

namespace ETourPro
{
    public partial class Customerfrm : Form
    {
        public ToursList ListTours { get; set; }
        public Trips ListTrips { get; set; }
        public CusList ListCus { get; set; }
        public OrderList ListOrd { get; set; }
        public string Code { get; set; }

        private List<Chuyen> listOrder;
        private int selectTour;

        public Customerfrm()
        {
            InitializeComponent();
        }

        private void Customerfrm_Load(object sender, EventArgs e)
        { 
            //new da truyen tu frm me thi khoi load
            if(listOrder == null)
                listOrder = new List<Chuyen>();
            if (ListTours == null)
                ListTours = new ToursList();
            if (ListTrips == null)
                ListTrips = new Trips();
            if (ListCus == null)
                ListCus = new CusList();
            if (ListOrd == null)
                ListOrd = new OrderList();

            tvTours_Load(ListTours.FindByStatus("Đang mở"));
            if(Code != null)
            {
                btnAdd.Enabled = false;
                btnAdd.Visible = false;
                controls_BindData(ListCus.Single(Code));
            }
            else
            {
                btnUpdate.Visible = false;
                txtCode.Text = NewBestIDCustomer();
                Code = txtCode.Text;
            }

        }

        private void tvTours_Load(List<Tour> list)
        {
            tvTours.Nodes.Clear();
            TreeNode node;
            foreach (Tour item in list)
            {
                node = tvTours.Nodes.Add(item.TenTour);
                node.Nodes.Add("Code: " + item.ID);
                node.Nodes.Add("Start place: " + item.XuatPhat);
                node.Nodes.Add("Status: " + item.TrangThai);
                node.Expand();
            }
        }

        private void lvTrips_Load(List<Chuyen> list)
        {
            lvTrips.Items.Clear();
            ListViewItem i;
            foreach (Chuyen item in list)
            {
                bool result = true;
                if (listOrder.Count > 0)
                {
                    foreach (Chuyen j in listOrder)
                    {
                        if (j.MChuyen == item.MChuyen)
                        {
                            result = false;
                            break;
                        }
                    }
                    if (result)
                    {
                        i = lvTrips.Items.Add(item.MChuyen.ToString());
                        i.SubItems.Add(item.TenTour);
                        i.SubItems.Add(item.NgayDi.ToShortDateString());
                        i.SubItems.Add(item.NgayVe.ToShortDateString());
                        i.SubItems.Add(item.Gia.ToString());
                        i.SubItems.Add(item.TrangThai == 1 ? "Đang chờ" : item.TrangThai == 0 ? "Đã đóng" : "Đã hủy");
                    }
                }
                else
                {
                    i = lvTrips.Items.Add(item.MChuyen.ToString());
                    i.SubItems.Add(item.TenTour);
                    i.SubItems.Add(item.NgayDi.ToShortDateString());
                    i.SubItems.Add(item.NgayVe.ToShortDateString());
                    i.SubItems.Add(item.Gia.ToString());
                    i.SubItems.Add(item.TrangThai == 1 ? "Đang chờ" : item.TrangThai == 0 ? "Đã đóng" : "Đã hủy");
                }
            }
        }

        private void lvTripsOrders_Load(List<Chuyen> list)
        {
            lvTripsOrders.Items.Clear();
            ListViewItem i;
            double sum = 0;
            foreach (Chuyen item in list)
            {
                i = lvTripsOrders.Items.Add(item.MChuyen.ToString());
                i.SubItems.Add(item.TenTour);
                i.SubItems.Add(item.NgayDi.ToShortDateString());
                i.SubItems.Add(item.NgayVe.ToShortDateString());
                sum += item.Gia;
                i.SubItems.Add(item.Gia.ToString());
                i.SubItems.Add(item.TrangThai == 1 ? "Đang chờ" : item.TrangThai == 0 ? "Đã đóng" : "Đã hủy");
            }
            txtTotalPrice.Text = sum.ToString();
        }

        private void tvTours_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node, child;
            if (tvTours.SelectedNode.Level == 0)
                node = tvTours.SelectedNode;
            else
                node = tvTours.SelectedNode.Parent;
            child = node.Nodes[0];
            string[] s = child.Text.ToString().Split(' ');
            selectTour = MyConvert.ToInt32(s[1]);
            lvTrips_Load(ListTrips.FindByCodeTour(selectTour));
            rdAll.Checked = false;
            rdOppening.Checked = false;
            radioButton2.Checked = false;
        }

        private void lvTrips_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTrips.SelectedItems.Count > 0)
            {
                if (lvTrips.SelectedItems[0].SubItems[5].Text == "Đang chờ")
                    simpleButton5.Enabled = true;
                else
                    simpleButton5.Enabled = false;
            }
            else
                simpleButton5.Enabled = false;
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            if (lvTrips.SelectedItems.Count > 0)
            {
                if (AddTrip(MyConvert.ToInt32(lvTrips.SelectedItems[0].Text)))
                {
                    ListViewItem item = lvTrips.SelectedItems[0];
                    lvTrips.Items.Remove(item);
                    lvTripsOrders.Items.Add(item);
                    double sum = MyConvert.ToDouble(item.SubItems[4].Text) + MyConvert.ToDouble(txtTotalPrice.Text);
                    txtTotalPrice.Text = sum.ToString();
                }
                else
                {
                    alertControl1.Show(this, "Error", "Do not choose this trip because list of orders had been had the trip which have simple time!");
                }
            }
            if (listOrder.Count > 0)
                btnRequireOrder.Enabled = true;
            else
                btnRequireOrder.Enabled = false;
            simpleButton5.Enabled = false;
        }

        private bool AddTrip(int _codeTrip)
        {
            Chuyen newTrip = ListTrips.Single(_codeTrip);
            if (newTrip != null)
            {
                foreach (Chuyen item in listOrder)
                {
                    if (item.TrangThai == 1 && ((item.NgayDi >= newTrip.NgayDi && item.NgayVe >= newTrip.NgayVe) || (item.NgayDi <= newTrip.NgayDi && item.NgayVe >= newTrip.NgayVe) ||
                        (item.NgayDi <= newTrip.NgayDi && item.NgayVe <= newTrip.NgayVe) ))
                    {
                        return false;
                    }
                }
                listOrder.Add(newTrip);
                return true;
            }
            return false;
        }

        private void lvTripsOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTripsOrders.SelectedItems.Count > 0 && lvTripsOrders.SelectedItems[0].SubItems[5].Text == "Đang chờ")
               btnRemove.Enabled = true;
            else
                btnRemove.Enabled = false;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lvTripsOrders.SelectedItems.Count > 0)
            {
                int mChuyen = MyConvert.ToInt32(lvTripsOrders.SelectedItems[0].Text);
                for (int i = 0; i < listOrder.Count; i++)
                {
                    if (listOrder[i].MChuyen == mChuyen)
                    {
                        listOrder.RemoveAt(i);
                        ListViewItem item = lvTripsOrders.SelectedItems[0];
                        lvTripsOrders.Items.Remove(item);
                        lvTrips.Items.Add(item);
                        double sum = MyConvert.ToDouble(txtTotalPrice.Text) - MyConvert.ToDouble(item.SubItems[4].Text);
                        txtTotalPrice.Text = sum.ToString();
                        break;
                    }
                }
            }
            if (listOrder.Count > 0)
                btnRequireOrder.Enabled = true;
            else
                btnRequireOrder.Enabled = false;
            btnRemove.Enabled = false;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }
            if (txtPrice.Text == "" && !Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            if (txtPrice.Text.Contains("."))
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

        private void rdAll_CheckedChanged(object sender, EventArgs e)
        {
            if(rdAll.Checked)
                lvTrips_Load(ListTrips.List);
        }

        //Close
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
                lvTrips_Load(ListTrips.FindByStatus(0));
        }

        private void rdOppening_CheckedChanged(object sender, EventArgs e)
        {
            if(rdOppening.Checked)
                lvTrips_Load(ListTrips.FindByStatus(1));
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            lvTrips_Load(ListTrips.FindByLessThanPrice(MyConvert.ToDouble(txtPrice.Text)));
        }

        private void dtpStart_EditValueChanged(object sender, EventArgs e)
        {
            if (dtpStart.DateTime > dtpEnd.DateTime)
            {
                MessageBox.Show("The start date must be less than the end date!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpStart.DateTime = dtpEnd.DateTime;
                dtpStart.Focus();
                btnSearchTime.Enabled = false;
                return;
            }
            btnSearchTime.Enabled = true;
        }

        private void dtpEnd_EditValueChanged(object sender, EventArgs e)
        {
            if (dtpStart.DateTime > dtpEnd.DateTime)
            {
                MessageBox.Show("The end date must be not less than the start date!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //alertControl1.Show(this, "Error", "The end date must be not less than the start date!");
                dtpEnd.DateTime = dtpStart.DateTime;
                dtpEnd.Focus();
                btnSearchTime.Enabled = false;
                return;
            }
            btnSearchTime.Enabled = true;
        }

        private void btnSearchTime_Click(object sender, EventArgs e)
        {
            lvTrips_Load(ListTrips.FindByPerodTime(dtpStart.DateTime, dtpEnd.DateTime));
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Tìm mã số mới nhất
        private string NewBestIDCustomer()
        {
            List<KhachHang> l = ListCus.List;
            if (l.Count > 0)
            {
                string id = l[l.Count - 1].ID;
                string[] s = id.Split('H');
                id = s[1];
                int newMaSo = MyConvert.ToInt32(id) + 1;
                if (newMaSo >= 99999)
                {
                    MessageBox.Show("Cạn kho mã số cho khách hàng!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return "";
                }

                id = newMaSo.ToString();
                while (id.Length < 5)
                    id = "0" + id;
                id = "KH" + id;
                return id;
            }
            return "KH00000";
        }

        private void cbbCountries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtFirstName.Text != "" && TestBirthDate() && cbbCountries.SelectedIndex >= 0 && txtAddress.Text != "")
            {
                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
            }
            if (cbbCountries.SelectedItem.ToString() == "Việt Nam")
            {
                cbbCity.Enabled = true;
                cbbCity.SelectedIndex = 0;
            }
            else
            {
                cbbCity.SelectedIndex = 0;
                cbbCity.Enabled = false;
            }
        }

        private void cbbCountries_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        //Không chấp nhận trẻ em dưới 18 tháng tuổi
        private void dtpBirth_ValueChanged(object sender, EventArgs e)
        {
            if (dtpBirth.Value > DateTime.Now)
            {
                MessageBox.Show("The birth date is not correct!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpBirth.Value = dtpBirth.MinDate;
                dtpBirth.Focus();
                return;
            }

            if (!TestBirthDate())
            {
                MessageBox.Show("The birth date is not less than 540 (18 * 30) day!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpBirth.Value = dtpBirth.MinDate;
                dtpBirth.Focus();
                return;
            }

            if (txtName.Text != "" && txtFirstName.Text != "" && TestBirthDate() && cbbCountries.SelectedIndex >= 0 && txtAddress.Text != "")
            {
                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
            }
 
        }

        private bool TestBirthDate()
        {
            DateTime temp = new DateTime(DateTime.Now.Year, dtpBirth.Value.Month, dtpBirth.Value.Day);
            int year = temp.Year - dtpBirth.Value.Year;
            int totalDay = year * 365;
            int month = temp.Month - DateTime.Now.Month;
            totalDay += month * 30;
            totalDay += temp.Day - DateTime.Now.Day;
            month = totalDay / 30;
            if (month >= 18)
                return true;
            return false;
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }
            if (Char.IsLetter(e.KeyChar))
            {
                if (txtName.Text.Length <= 20)
                    e.Handled = false;
                else
                    e.Handled = true;
            }
            else
                e.Handled = true;
        }

        private void txtFirstName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
                return;
            }
            if (Char.IsLetter(e.KeyChar) || e.KeyChar == ' ')
            {
                if (txtFirstName.Text.Length <= 20)
                {
                    string test = txtFirstName.Text + e.KeyChar;
                    if(test.Contains("  "))
                        e.Handled = true;
                    else
                        e.Handled = false;
                }
                else
                    e.Handled = true;
            }
            else
                e.Handled = true;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtPhone.Text.Length < 24)
            {
                if (Char.IsControl(e.KeyChar) || Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                    return;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                    e.Handled = true;
            }
        }

        private void txtAccount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtAccount.Text.Length < 24)
            {
                if (Char.IsControl(e.KeyChar) || Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                    return;
                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {
                if (Char.IsControl(e.KeyChar))
                    e.Handled = false;
                else
                    e.Handled = true;
            }
        }

        private void txtName_EditValueChanged(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtFirstName.Text != "" && TestBirthDate() && cbbCountries.SelectedIndex > 0 && txtAddress.Text != "")
            {
                btnAdd.Enabled = true;
                btnUpdate.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
                btnUpdate.Enabled = false;
            }
        }

        private KhachHang controls_Load()
        {
            KhachHang result = new KhachHang();
            result.ID = txtCode.Text;
            result.Ho = txtFirstName.Text;
            result.Ten = txtName.Text;
            result.DiaChi = txtAddress.Text;
            result.QuocGia = cbbCountries.SelectedItem.ToString();
            result.ThanhPho = "";
            if (cbbCity.Enabled && cbbCity.SelectedIndex > 0 && cbbCountries.SelectedItem.ToString() == "Việt Nam")
            {
                result.ThanhPho = cbbCity.SelectedItem.ToString();
            }
            result.SoDT = txtPhone.Text;
            result.SoTaiKhoan = txtAccount.Text;
            result.GTinh = rdMale.Checked;
            result.NgaySinh = dtpBirth.Value;
            return result;
        }

        private void controls_BindData(KhachHang _cus)
        {
            txtCode.Text = _cus.ID;
            txtName.Text = _cus.Ten;
            txtFirstName.Text = _cus.Ho;
            txtAddress.Text = _cus.DiaChi;
            txtPhone.Text = _cus.SoDT;
            txtAccount.Text = _cus.SoTaiKhoan;
            if (_cus.GTinh) rdMale.Checked = true;
            else
                rdFemale.Checked = true;
            int i = 0;
            foreach (var item in cbbCountries.Items)
            {
                if (item.ToString().ToUpper() == _cus.QuocGia.ToUpper())
                {
                    cbbCountries.SelectedIndex = i;
                    break;
                }
                i++;
            }
            cbbCity.SelectedIndex = 0;
            if (cbbCity.Enabled)
            {
                i = 0;
                foreach (var item in cbbCity.Items)
                {
                    if (item.ToString().ToUpper() == _cus.ThanhPho.ToUpper())
                    {
                        cbbCity.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
            }

            List<DatCho> temp = ListOrd.Find(Code);
            //Lấy danh sách đặt chỗ đang mở cua khach hang hien taij
            listOrder = ListTrips.Find(temp, 1);

            lvTripsOrders_Load(listOrder);
            dtpBirth.Value = _cus.NgaySinh;
        }

        private bool TestData()
        {
            if (txtAddress.Text.ToUpper().Contains(cbbCountries.SelectedItem.ToString().ToUpper()))
            {
                MessageBox.Show("The address must not have the country!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Focus();
                return false;
            }

            if (cbbCity.Enabled && cbbCity.SelectedIndex > 0 && txtAddress.Text.ToUpper().Contains(cbbCity.SelectedItem.ToString().ToUpper()))
            {
                MessageBox.Show("The address must not have the city!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbCity.Focus();
                return false;
            }
            
            if (!ListCus.Test(txtFirstName.Text + " " + txtName.Text, txtAddress.Text, (cbbCity.Enabled && (cbbCity.SelectedIndex > 0)) ? cbbCity.SelectedItem.ToString() : "", cbbCountries.SelectedItem.ToString()))
            {
                MessageBox.Show("This customer had been exited!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Focus();
                return false;
            }
            return true;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtAddress.Text.ToUpper().Contains(cbbCountries.SelectedItem.ToString().ToUpper()))
            {
                MessageBox.Show("The address must not have the country!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAddress.Focus();
                return;
            }

            if (cbbCity.Enabled && cbbCity.SelectedIndex > 0 && txtAddress.Text.ToUpper().Contains(cbbCity.SelectedItem.ToString().ToUpper()))
            {
                MessageBox.Show("The address must not have the city!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbCity.Focus();
                return;
            }

            KhachHang oldCus = ListCus.Single(txtCode.Text);
            KhachHang newCus = controls_Load();
            if (oldCus.Ho.ToUpper() != newCus.Ho.ToUpper() || oldCus.Ten.ToUpper() != newCus.Ten.ToUpper())
            {
                if (!ListCus.Test(txtFirstName.Text + " " + txtName.Text, txtAddress.Text, (cbbCity.Enabled && (cbbCity.SelectedIndex > 0)) ? cbbCity.SelectedItem.ToString() : "", cbbCountries.SelectedItem.ToString()))
                {
                    MessageBox.Show("This customer had been exited!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAddress.Focus();
                    return;
                }
            }

            if (ListCus.Update(newCus))
            {
                MessageBox.Show("Udating is success full!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                return;
            }
            MessageBox.Show("Update had been faile!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            KhachHang newCus = controls_Load();
            if (TestData())
            {
                if (ListCus.Add(newCus))
                {
                    MessageBox.Show("Adding is success full!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    return;
                }
                MessageBox.Show("Adding had been faile!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRequireOrder_Click(object sender, EventArgs e)
        {
            if (ListCus.Single(txtCode.Text) != null)
            {
                if (listOrder.Count > 0)
                {
                    //Tao ra danh sach dat cho
                    List<DatCho> temp = new List<DatCho>();
                    DatCho t = new DatCho();
                    foreach (Chuyen item in listOrder)
                    {
                        t.MChuyen = item.MChuyen;
                        t.MKHang = txtCode.Text;
                        temp.Add(t);
                    }

                    //Tim danh sach dat cho da ton tai va co trang thai chuyen di la dang cho
                    List<Chuyen> oldTrip = ListTrips.Find(ListOrd.Find(Code), 1);//Tim ds chuyen dang mo cua ds dat cho cua khach hang
                    //Tao ds dat cho cua khach hang da ton tai va trang thai dang mo
                    List<DatCho> old = new List<DatCho>();
                    foreach (Chuyen item in oldTrip)
                    {
                        DatCho tp = new DatCho();
                        tp.MKHang = txtCode.Text;
                        tp.MChuyen = item.MChuyen;
                        old.Add(tp);
                    }

                    // So sanh voi temp de lay ra nhung cai them moi va nhung cai can xoa di
                    List<DatCho> nw = new List<DatCho>();//danh sach can them moi
                    List<DatCho> dl = new List<DatCho>();//danh sach can xoa di
                    foreach (DatCho i in temp)
                    {
                        bool s = true;
                        foreach (DatCho j in old)
                        {
                            if (i.MChuyen == j.MChuyen)//da ton tai, bo qua
                            {
                                s = false;
                                break;
                            }
                        }
                        if (s)
                            nw.Add(i);//Chua ton tai nen them duoc
                    }

                    foreach (DatCho i in old)
                    {
                        bool r = true;
                        foreach (DatCho j in temp)
                        {
                            if (i.MChuyen == j.MChuyen)
                            {
                                r = false;
                                break;
                            }
                        }
                        if (r)//co trong cai cu nhung khong co trong cai moi nen xoa di
                        {
                            dl.Add(i);
                        }
                    }
                    // duong nhien ca hai old va temp deu la danh sach dat cho cua chuyen dang mo
                    // Thuc hien xoa tren old va add tren nw la OK

                    foreach (DatCho i in nw)
                    {
                        if (ListOrd.Add(i))
                        {
                            MessageBox.Show(String.Format("You have add the trip which has code {0}!", i.MChuyen), "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show(String.Format("You had been faile the trip which has code {0}!", i.MChuyen), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    foreach (DatCho i in dl)
                    {
                        if (ListOrd.Delete(i))
                        {
                            MessageBox.Show(String.Format("You have delete the trip which has code {0}!", i.MChuyen), "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        }
                        else
                        {
                            MessageBox.Show(String.Format("You had been faile the trip which has code {0}!", i.MChuyen), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    btnRequireOrder.Enabled = false;
                }
                else
                {
                    MessageBox.Show("You have not add the trips! Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("You have not add this customer! Please try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        
    }
}
