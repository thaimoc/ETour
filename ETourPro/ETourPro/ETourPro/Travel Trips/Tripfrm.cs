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
    public partial class Tripfrm : Form
    {
        private int _MChuyen = 0;

        public int MChuyen
        {
            get { return _MChuyen; }
            set { _MChuyen = value; }
        }

        //List<PhanCongHDV> listPCHDV;
        List<HuongDanVien> listGuideNoChoose;
        List<HuongDanVien> listGuideChoose;
        List<Chuyen> listTrips;
        List<Chuyen> listPrice;

        Chuyen current;

        public Tripfrm()
        {
            InitializeComponent();
        }

        private void Tripfrm_Load(object sender, EventArgs e)
        {
            cbbTours_Load();
            if (_MChuyen == 0)
            {
                btnUpdate.Visible = false;
                listTrips = Chuyen.FindByStatus(1);                
                cbbStatus.SelectedIndex = 0;
            }
            else
            {
                btnAdd.Visible = false;
                current = Chuyen.Single(MChuyen);
                txtCode.Text = MChuyen.ToString();
                txtPrice.Text = current.Gia.ToString();
                
                int count = cbbTours.Items.Count;
                for (int i = 0; i < count; i++)
                {
                    if ((cbbTours.Items[i] as Tour).ID == current.MTour)
                    {
                        cbbTours.SelectedIndex = i;
                        break;
                    }
                }

                dtpStart.Value = current.NgayDi;
                dtpEnd.Value = current.NgayVe;
                if (current.TrangThai >= 1)
                    cbbStatus.SelectedIndex = 0;
                else
                    if (current.TrangThai == 0)
                        cbbStatus.SelectedIndex = 1;
                else
                        cbbStatus.SelectedIndex = 2;
                
                if(current.NgayDi < DateTime.Today)
                    cbbTours.Enabled = false;
            }

        }

        private void lvGuidesNoChoose_Load(List<HuongDanVien> list)
        {
            lvGuidesNoChoose.Items.Clear();
            Lv_Load(list, lvGuidesNoChoose);
        }

        private void lvGuidesChosed_Load(List<HuongDanVien> list)
        {
            lvGuidesChosed.Items.Clear();
            Lv_Load(list, lvGuidesChosed);
        }

        private void Lv_Load(List<HuongDanVien> list, ListView lv)
        {
            ListViewItem item;
            foreach (HuongDanVien i in list)
            {
                item = lv.Items.Add(i.ID);
                item.SubItems.Add(i.Ho + " " + i.Ten);
                item.SubItems.Add(i.NgaySinh.ToShortDateString());
                item.SubItems.Add(i.GioiTinh ? "Nam" : "Nữ");
                item.SubItems.Add(i.DiaChi);
                item.SubItems.Add(i.QuocGia);
                item.SubItems.Add(i.DienThoai);
                item.SubItems.Add(i.TrangThai ? "Đang làm việc" : "Đang nghỉ làm");
            }
        }

        private void cbbStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cbbTours_Load()
        {
            List<Tour> list = Tour.FindStatus("Đang mở");
            if (MChuyen != 0)
            {
                List<Tour> list2 = Tour.FindStatus("Đã đóng");
                foreach (Tour item in list2)
                {
                    list.Add(item);
                }
            }
            cbbTours.DataSource = list;
            cbbTours.DisplayMember = "TenTour";
            cbbTours.ValueMember = "ID";
            cbbTours.SelectedIndex = 0;
        }

        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (MChuyen != 0)
            {
                if (current.NgayVe < DateTime.Today)
                {
                    e.Handled = true;
                    return;
                }
            }

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

        private void cbbTours_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTours.SelectedIndex > -1)
            {
                Tour t = cbbTours.SelectedItem as Tour;
                listGuideNoChoose = HuongDanVien.FindBy_MTour_NotBusy(t.ID);
                if (MChuyen == 0)
                {
                    listGuideChoose = new List<HuongDanVien>();                    
                    lvGuidesChosed.Items.Clear();
                }
                else
                {
                    //Load ds huong dan vien duoc phan cong len
                    listGuideChoose = HuongDanVien.FindByMChuyen(MChuyen);
                    lvGuidesChosed_Load(listGuideChoose);
                    //Chuyen thanh tour khac
                    if (current != null && (cbbTours.SelectedItem as Tour).ID != current.MTour)
                    {
                        DialogResult dlg = MessageBox.Show("Program remove all guides had been chose! Are you wanting repair this trip?", "Wraning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (dlg == System.Windows.Forms.DialogResult.Yes)
                        {
                            PhanCongHDV.DeletePhanCong(MChuyen);
                            lvGuidesChosed.Items.Clear();
                            listGuideChoose = new List<HuongDanVien>();
                            listGuideNoChoose = HuongDanVien.FindBy_MTour_NotBusy((cbbTours.SelectedItem as Tour).ID);
                            lvGuidesNoChoose_Load(listGuideNoChoose);
                            //btnAdd.Enabled = false;
                            //btnUpdate.Enabled = false;
                        }
                        else
                        {
                            int count = cbbTours.Items.Count;
                            for (int i = 0; i < count; i++)
                            {
                                if ((cbbTours.Items[i] as Tour).ID == current.MTour)
                                {
                                    cbbTours.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }
                    
                }
                lvGuidesNoChoose_Load(listGuideNoChoose);
                //Thoong ke tinh gia
                listPrice = Chuyen.FindByMTour(t.ID);                
            }
                
        }

        private void lvGuidesNoChoose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvGuidesNoChoose.SelectedItems.Count > 0)
            {                
                if (MChuyen != 0)
                {
                    if (current.NgayVe < DateTime.Today)
                        btnChoose.Enabled = false;
                    else
                        btnChoose.Enabled = true;
                }
                else
                    btnChoose.Enabled = true;
            }
            else
                btnChoose.Enabled = false;
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (lvGuidesNoChoose.SelectedItems.Count > 0)
            { 
                string _code = lvGuidesNoChoose.SelectedItems[0].SubItems[0].Text;
                listGuideChoose.Add(listGuideNoChoose.Find(delegate(HuongDanVien hdv)
                {
                    return hdv.ID == _code;
                }));
                lvGuidesChosed.Items.Add(lvRemove(lvGuidesNoChoose));                
            }
            if (txtPrice.Text.Length > 0 && cbbStatus.SelectedIndex >= 0 && listGuideChoose != null && listGuideChoose.Count > 0)
            {
                btnAdd.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
            }
        }

        private ListViewItem lvRemove(ListView lv)
        {
            ListViewItem item = lv.SelectedItems[0];
            ListViewItem result = new ListViewItem(item.SubItems[0].Text);
            
            int count = item.SubItems.Count;
            for (int i = 1; i < count; i++)
            {
                result.SubItems.Add(item.SubItems[i]);
            }
            lv.Items.Remove(lv.SelectedItems[0]);
            return result;
        }

        private void lvGuidesChosed_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvGuidesChosed.SelectedItems.Count > 0)
            {
                if (MChuyen != 0)
                {
                    if (current.NgayVe < DateTime.Today)
                        btnRemove.Enabled = false;
                    else
                        btnRemove.Enabled = true;
                }
                else
                    btnRemove.Enabled = true;
            }
            else
                btnRemove.Enabled = false;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lvGuidesChosed.SelectedItems.Count > 0)
            {
                string _code = lvGuidesChosed.SelectedItems[0].SubItems[0].Text;

                listGuideChoose.Remove(listGuideChoose.Find(delegate(HuongDanVien hdv)
                {
                    return hdv.ID == _code;
                }));

                lvGuidesNoChoose.Items.Add(lvRemove(lvGuidesChosed));
            }

            if (txtPrice.Text.Length > 0 && cbbStatus.SelectedIndex >= 0 && listGuideChoose != null && listGuideChoose.Count > 0)
            {
                btnAdd.Enabled = true;
            }
            else
            {
                btnAdd.Enabled = false;
            }
        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {
            if (txtPrice.Text.Length > 0 && cbbStatus.SelectedIndex >= 0 && listGuideChoose != null && listGuideChoose.Count > 0)
            {
                btnAdd.Enabled = true;                
            }
            else
            {
                btnAdd.Enabled = false;
            }           

        }

        private int Sumday(DateTime start, DateTime end)
        {
            DateTime temp = new DateTime(end.Year, start.Month, start.Day);
            int year = temp.Year - start.Year;
            int totalDay = year * 365;
            int month = temp.Month - end.Month;
            totalDay += month * 30;
            totalDay += temp.Day - start.Day;
            return totalDay;
        }

        private bool TestPrice()
        {
            //chi cho phep gia nhap vao chenh lech khong qua 10% trên ngày so voi gia trung binh cua 5 chuyen cung tour gan nhat;
            if (listPrice.Count >= 5)
            {
                int index = listPrice.Count - 1;
                double sum = 0, avg = 0, min = 0, max = 0, pr = 0;
                int i = 0;
                int date = 0, avgdate = 0;
                while (i < 5)
                {
                    sum += listPrice[index--].Gia;
                    date += Sumday(listPrice[i].NgayDi, listPrice[i].NgayVe);
                    i++;
                }

                avgdate = date / 5;//Lay so ngay trung binh
                int sumdate = Sumday(dtpStart.Value, dtpEnd.Value);//so ngay dang chon
                if (Math.Abs(((double)sumdate - (double)avgdate)) > 2)
                {
                    MessageBox.Show(String.Format("Total day in this tour must not be less than (or more than) {0}", avgdate), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                avg = sum / 5;
                min = avg - avg / 10;
                max = avg + avg / 10;
                pr = MyConvert.ToDouble(txtPrice.Text);
                if (pr < min || pr > max)
                {
                    MessageBox.Show(String.Format("Price must not be less than {0} and must not be huger than {1}!", min, max), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnAdd.Enabled = false;
                    return false;
                }
            }
            return true;
        }

        private Chuyen controls_Load()
        {
            Chuyen result = new Chuyen();
            result.MChuyen = _MChuyen;
            Tour t = cbbTours.SelectedItem as Tour;
            result.MTour = t.ID;
            result.NgayDi = dtpStart.Value;
            result.NgayVe = dtpEnd.Value;
            result.Gia = MyConvert.ToDouble(txtPrice.Text);
            result.TrangThai = cbbStatus.SelectedItem.ToString() == "Đang mở" ? 1 : cbbStatus.SelectedItem.ToString() == "Đã hủy" ? -1 : 0;
            return result;
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (MChuyen == 0)
            {
                if (DateTime.Parse(dtpStart.Text) < DateTime.Today)
                {
                    dtpStart.Value = DateTime.Today;
                    MessageBox.Show("Start date must not be less than current day!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (current.NgayVe < DateTime.Today)
                {
                    if (dtpStart.Value != current.NgayDi)
                    {
                        MessageBox.Show("Do not update time in this trip!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dtpStart.Value = current.NgayDi;
                    }
                }
                else
                {
                    if (current.NgayDi <= DateTime.Today && current.NgayVe >= DateTime.Today)
                    {
                        if (dtpStart.Value != current.NgayDi)
                        {
                            MessageBox.Show("Do not update start date in this trip!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dtpStart.Value = current.NgayDi;
                        }
                    }
                    else
                    {
                        if (dtpEnd.Value.Date < dtpStart.Value.Date)
                        {
                            MessageBox.Show("End date must not be less than start date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //dtpEnd.Value = dtpEnd.MaxDate;
                            dtpStart.Value = current.NgayDi;
                            dtpEnd.Value = current.NgayVe;
                        }
                    }
                }
            }
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (MChuyen == 0)
            {
                if (DateTime.Parse(dtpEnd.Text) < DateTime.Parse(dtpStart.Text))
                {
                    dtpEnd.Value = DateTime.Today;
                    MessageBox.Show("End date must not be less than start date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (current.NgayVe < DateTime.Today)
                {
                    if (dtpEnd.Value != current.NgayVe)
                    {
                        MessageBox.Show("Do not update time in this trips", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        dtpEnd.Value = current.NgayVe;
                    }
                }
                else
                {
                    if (current.NgayDi <= DateTime.Today && current.NgayVe >= DateTime.Today)
                    {
                        if (dtpEnd.Value <= DateTime.Today)
                        {
                            MessageBox.Show("End date must not be less than today!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            dtpEnd.Value = current.NgayVe;
                        }
                    }
                    else
                    {
                        if (dtpEnd.Value.Date < dtpStart.Value.Date)
                        {
                            MessageBox.Show("End date must not be less than start date!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //dtpEnd.Value = dtpEnd.MaxDate;
                            dtpStart.Value = current.NgayDi;
                            dtpEnd.Value = current.NgayVe;
                            //return;
                        }
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (TestPrice())
            {
                if (listGuideChoose == null || listGuideChoose.Count == 0)
                {
                    MessageBox.Show("You do not choose the Guiders!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnAdd.Enabled = false;
                    return;
                }

                DialogResult dlg = MessageBox.Show("Are you adding this trip?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlg == System.Windows.Forms.DialogResult.Yes)
                {
                    Chuyen ch = controls_Load();
                    int _MT = (cbbTours.SelectedItem as Tour).ID;
                    int _MC = Chuyen.Add(ch);
                    if (_MC > 0)
                    {
                        PhanCongHDV pc;
                        List<PhanCongHDV> listPC = new List<PhanCongHDV>();
                        foreach (HuongDanVien item in listGuideChoose)
                        {
                            pc = new PhanCongHDV();
                            pc.MChuyen = _MC;
                            pc.MTour = _MT;
                            pc.MHDV = item.ID;
                            if (!PhanCongHDV.Add(pc))
                            {
                                DialogResult dl = MessageBox.Show(String.Format("Division had been failse with the guide has code: {0} and name: {1} {2}! Are you wanting to continue?", item.ID, item.Ho, item.Ten), "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                                if (dl == System.Windows.Forms.DialogResult.No)
                                    return;
                            }
                        }
                        MessageBox.Show("Adding is successful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        int index = cbbTours.SelectedIndex;
                        cbbTours.SelectedIndex = -1;
                        cbbTours.SelectedIndex = index;
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Adding had been failse!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void cbbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (MChuyen != 0)
            {
                if (current.NgayVe < DateTime.Today)
                {
                    for (int i = 0; i < cbbStatus.Items.Count; i++)
                    {
                        if (cbbStatus.Items[i].ToString() == "Đang mở")
                        {
                            cbbStatus.Items.RemoveAt(i);
                        }
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (listGuideChoose.Count > 0)
            {
                if (TestPrice())
                {
                    current.TrangThai = cbbStatus.SelectedItem.ToString() == "Đang mở" ? 1 : cbbStatus.SelectedItem.ToString() == "Đã đóng" ? 0 : -1;
                    current.MTour = (cbbTours.SelectedItem as Tour).ID;
                    current.NgayDi = dtpStart.Value;
                    current.NgayVe = dtpEnd.Value;
                    current.Gia = MyConvert.ToDouble(txtPrice.Text);
                    if (Chuyen.Update(current))
                    {
                        MessageBox.Show("Updating is sucessful!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    }
                    else
                        MessageBox.Show("Updating had been failse!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            MessageBox.Show("You need choose the guiders!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        

    }
}
