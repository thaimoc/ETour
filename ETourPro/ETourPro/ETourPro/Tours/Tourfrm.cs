using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccess;
using ETourPro.Locals;
using ETourPro.Scenic;
using ETourPro.Hotels;
using ETourPro.vehicles;
using ETourPro.Suppliers_Vehicle;

namespace ETourPro.Tours
{
    public partial class Tourfrm : Form
    {

        private int _ID = 0;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        List<DiemDL> listScenic;
        List<DiemDen> listDes;

        public Tourfrm()
        {
            InitializeComponent();
        }

        private void Tourfrm_Load(object sender, EventArgs e)
        {
            tvtours_Load(Tour.All());
            listDes = new List<DiemDen>();
            listScenic = new List<DiemDL>();
            cbbLocal_Load(DiaDiemDL.All());
            cbbSupplier_Load(NCCPTien.All());
            cbbStatus.SelectedIndex = 0;
            if (_ID != 0)
            {
                btnUpdateTour.Enabled = true;
                Controls_LoadUp();
            }
        }

        private void cbbStatus_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void tvtours_Load(List<Tour> list)
        {
            TreeNode node, nodeDS, nodeStatus;
            tvtours.Nodes.Clear();
            foreach (Tour item in list)
            {
                node = tvtours.Nodes.Add(item.TenTour);
                node.Nodes.Add("Mã số: " + item.ID).ImageIndex = 1;
                node.Nodes.Add("Xuất phát: " + item.XuatPhat).ImageIndex = 2;
                nodeStatus = node.Nodes.Add("Trạng thái: " + item.TrangThai);
                if (nodeStatus.Text == "Trạng thái: Đang mở")
                    nodeStatus.ImageIndex = 4;
                else
                    nodeStatus.ImageIndex = 5;
                nodeDS = node.Nodes.Add("Danh sách điểm đến: ");
                nodeDS.ImageIndex = 3;
                List<DiemDen> listDD = DiemDen.FindByMTour(item.ID);
                foreach (DiemDen i in listDD)
                {
                    nodeDS.Nodes.Add(i.TenDiem);
                    nodeDS.Expand();
                }
                node.ImageIndex = 0;
                node.Expand();
                node.ForeColor = Color.DeepPink;
            }
        }

        private void Controls_LoadUp()
        {
            Tour t = Tour.Single(_ID);
            txtCode.Text = t.ID.ToString();
            txtName.Text = t.TenTour;
            txtStartPlace.Text = t.XuatPhat;
            int i = 0;
            foreach (var item in cbbStatus.Items)
            {
                if (item.ToString() == t.TrangThai)
                {
                    cbbStatus.SelectedIndex = i;
                    break;
                }
                i++;
            }
            btnAddTour.Enabled = false;
            btnUpdateTour.Enabled = true;
            //btnDeleteTour.Enabled = true;

            //
            listScenic = new List<DiemDL>();
            listDes = DiemDen.FindByMTour(ID);
            lvDestination.Items.Clear();
            foreach (DiemDen j in listDes)
            {
                ListViewItem item = lvDestination.Items.Add(j.TenDD);
                item.SubItems.Add(j.TenDiem);
                item.SubItems.Add(j.TenKS);
                item.SubItems.Add(j.TenPT);
                item.SubItems.Add(j.TenNCC);
                listScenic.Add(DiemDL.Single(j.MDiemDL));
            }
            cbbLocal_Load(DiaDiemDL.All());
            cbbLocal.SelectedIndex = 0;
            cbbHotel.Items.Clear();
            cbbHotel.Text = "";
            tvHotel.Nodes.Clear();
        }

        private void cbbLocal_Load(List<DiaDiemDL> list)
        {
            cbbLocal.Items.Clear();
            foreach (DiaDiemDL item in list)
                cbbLocal.Items.Add(item);
            cbbLocal.DisplayMember = "TenDD";
            cbbLocal.SelectedValue = "ID";
            cbbLocal.Items.Insert(0, "---All---");
            cbbLocal.SelectedIndex = 0;
        }

        private void tvtours_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvtours.SelectedNode.Level == 0)
            {
                string[] s = tvtours.SelectedNode.Nodes[0].Text.Split(' ');
                ID = MyConvert.ToInt32(s[2]);
                Controls_LoadUp();
            }
        }

        private void cbbLocal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLocal.SelectedIndex > 0)
            {
                DiaDiemDL dd = cbbLocal.SelectedItem as DiaDiemDL;
                cbbScenic_Load(DiemDL.FindByMaDD(dd.ID));
            }
            else
            {
                cbbScenic_Load(DiemDL.All());
            }
            tvScenic.Nodes.Clear();
            btnAddDes.Enabled = false;
            cbbScenic.Text = "";
        }

        private void cbbScenic_Load(List<DiemDL> list)
        {
            bool result;
            cbbScenic.Items.Clear();
            foreach (DiemDL item in list)
            {
                result = true;
                if (listScenic.Count > 0)
                {
                    foreach (DiemDL i in listScenic)
                        if (item.ID == i.ID)
                        {
                            result = false;
                            break;
                        }
                    if (result)
                        cbbScenic.Items.Add(item);
                }
                else
                    if (ID == 0)
                        cbbScenic.Items.Add(item);
            }
            cbbScenic.DisplayMember = "TenDiem";
            cbbScenic.ValueMember = "ID";
            cbbScenic.Text = "";
        }

        private void cbbScenic_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbScenic.SelectedIndex >= 0)
            {
                DiemDL dl = cbbScenic.SelectedItem as DiemDL;
                cbbHotel_Load(KhachSan.FindMDiemDL(dl.ID));
                tvScenic_Load(dl);
            }
            else
            {
                cbbHotel.Items.Clear();                
            }
            cbbHotel.Text = "";
            tvHotel.Nodes.Clear();
            btnAddDes.Enabled = false;
        }

        private void cbbHotel_Load(List<KhachSan> list)
        {
            cbbHotel.Items.Clear();
            foreach (KhachSan item in list)
                cbbHotel.Items.Add(item);
            cbbHotel.DisplayMember = "TenKS";
            cbbHotel.ValueMember = "ID";
        }

        private void tvScenic_Load(DiemDL _Diem)
        {
            tvScenic.Nodes.Clear();
            TreeNode node = tvScenic.Nodes.Add("Scenic: " + _Diem.TenDiem);
            node.Nodes.Add("Code: " + _Diem.ID);
            node.Nodes.Add("Local: " + _Diem.TenDD);
            node.Nodes.Add("Address: " + _Diem.DiaChi);
            node.Expand();
        }

        private void cbbHotel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbHotel.SelectedIndex >= 0)
            {
                KhachSan ks = cbbHotel.SelectedItem as KhachSan;
                tvHotel_Load(ks);
            }            
        }

        private void tvHotel_Load(KhachSan ks)
        {
            tvHotel.Nodes.Clear();
            tvHotel.Nodes.Add("Hotel: " + ks.TenKS);
            tvHotel.Nodes.Add("Start Number: " + ks.SoSao);
            tvHotel.Nodes.Add("Address: " + ks.DiaChi);
            tvHotel.Nodes.Add("Phone: " + ks.SoDienThoai);
            if (tvHotel.Nodes.Count > 0 && tvVehical.Nodes.Count > 0)
                btnAddDes.Enabled = true;
            else
                btnAddDes.Enabled = false;
        }

        private void cbbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbSupplier.SelectedIndex > 0)
            {
                NCCPTien ncc = cbbSupplier.SelectedItem as NCCPTien;
                cbbPhuongTien_Load(PhuongTien.FindByMaNCC(ncc.ID));
            }
            else
                cbbPhuongTien_Load(PhuongTien.All());
            cbbVehical.Text = "";
            tvVehical.Nodes.Clear();
            btnAddDes.Enabled = false;
        }

        private void cbbSupplier_Load(List<NCCPTien> list)
        {
            cbbSupplier.Items.Clear();
            cbbSupplier.Items.Add("---All---");
            foreach (NCCPTien item in list)
                cbbSupplier.Items.Add(item);
            cbbSupplier.DisplayMember = "TenNCC";
            cbbSupplier.ValueMember = "ID";
            cbbSupplier.SelectedIndex = 0;
        }

        private void cbbPhuongTien_Load(List<PhuongTien> list)
        {
            cbbVehical.Items.Clear();
            foreach (PhuongTien item in list)
                cbbVehical.Items.Add(item);
            cbbVehical.DisplayMember = "TenPT";
            cbbVehical.ValueMember = "ID";
        }

        private void cbbVehical_SelectedIndexChanged(object sender, EventArgs e)
        {
            PhuongTien pt = cbbVehical.SelectedItem as PhuongTien;
            tvVehical_Load(pt);
        }

        private void tvVehical_Load(PhuongTien pt)
        {
            tvVehical.Nodes.Clear();
            tvVehical.Nodes.Add("Vehical: " + pt.TenPT);
            tvVehical.Nodes.Add("Facilities: " + pt.TienNghi);
            tvVehical.Nodes.Add("Maximum number of tickets: " + pt.SoChoToiDa);
            tvVehical.Nodes.Add("Minimum number of tickets: " + pt.SoChoToiThieu);
            tvVehical.Nodes.Add("Supplier: " + pt.TenNCC);
            if (tvHotel.Nodes.Count > 0 && tvVehical.Nodes.Count > 0)
                btnAddDes.Enabled = true;
            else
                btnAddDes.Enabled = false;
        }

        private void btnNewLocal_Click(object sender, EventArgs e)
        {
            Localfrm frm = new Localfrm();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                cbbLocal_Load(DiaDiemDL.All());
        }

        private void bntNewScenic_Click(object sender, EventArgs e)
        {
            Scenicfrm frm = new Scenicfrm();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
            {
                int i = cbbLocal.SelectedIndex;
                cbbLocal_Load(DiaDiemDL.All());
                cbbLocal.SelectedIndex = i;
            }
        }

        private void btnNewHotel_Click(object sender, EventArgs e)
        {
            Hotelfrm frm = new Hotelfrm();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                cbbHotel_Load(KhachSan.All());
        }

        private void btnNewVehical_Click(object sender, EventArgs e)
        {
            Vehiclefrm frm = new Vehiclefrm();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                cbbSupplier_Load(NCCPTien.All());
        }

        private void btnNewSupplier_Click(object sender, EventArgs e)
        {
            Supplierform frm = new Supplierform();
            frm.ShowDialog();
            if (frm.DialogResult == System.Windows.Forms.DialogResult.OK)
                cbbSupplier_Load(NCCPTien.All());
        }

        private void btnAddDes_Click(object sender, EventArgs e)
        {
            DiemDL ddl = cbbScenic.SelectedItem as DiemDL;
            listScenic.Add(ddl);
            cbbScenic.Items.Remove(ddl);
            ListViewItem i = lvDestination.Items.Add(ddl.TenDD);
            i.SubItems.Add(ddl.TenDiem);

            KhachSan ks = cbbHotel.SelectedItem as KhachSan;
            i.SubItems.Add(ks.TenKS);

            PhuongTien pt = cbbVehical.SelectedItem as PhuongTien;
            i.SubItems.Add(pt.TenPT);
            i.SubItems.Add(pt.TenNCC);

            DiemDen dd = new DiemDen();
            dd.MTour = 0;
            dd.MDiemDL = ddl.ID;
            dd.MaKS = ks.ID;

            dd.MaPT = pt.ID;
            listDes.Add(dd);
            btnAddDes.Enabled = false;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddTour_Click(object sender, EventArgs e)
        {
            if (Tour.FindByName(txtName.Text).Count > 0)
            {
                MessageBox.Show("This tour had been exited!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (lvDestination.Items.Count == 0)
            {
                MessageBox.Show("Do not choose the destinations!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dlg = MessageBox.Show("Do you want to adding this tour?", "Question!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == System.Windows.Forms.DialogResult.No)
                return;

            int affected = Tour.Add(controls_Load());
            if (affected > 0)
            {                
                //Thêm danh sách điểm đến
                //Gán mã tour cho danh sách điểm đến
                foreach (DiemDen item in listDes)
                    item.MTour = affected;

                DiemDen.Add(listDes);

                listDes = new List<DiemDen>();
                listScenic = new List<DiemDL>();
                lvDestination.Items.Clear();
                txtName.Text = "";
                txtStartPlace.Text = "";
                tvtours_Load(Tour.All());

                MessageBox.Show("Adding is successful!", "Message!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private Tour controls_Load()
        {
            Tour result = new Tour();
            result.ID = ID;
            result.TenTour = txtName.Text;
            result.XuatPhat = txtStartPlace.Text;
            result.TrangThai = cbbStatus.SelectedItem.ToString();
            return result;
        }

        private void btnUpdateTour_Click(object sender, EventArgs e)
        {
            Tour exited = Tour.Single(ID);
            Tour newToour = controls_Load();
            if (exited.TenTour != newToour.TenTour)
            {
                if (Tour.FindByName(txtName.Text).Count > 0)
                {
                    MessageBox.Show("This tour had been exited!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            if (lvDestination.Items.Count == 0)
            {
                MessageBox.Show("Do not choose the destinations!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult dlg = MessageBox.Show("Do you want to update this tour?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                Tour.Update(newToour);
                DiemDen.DeleteByMTour(ID);
                //Gán mã tour cho danh sách điểm đến
                foreach (DiemDen item in listDes)
                    item.MTour = ID;
                DiemDen.Add(listDes);
                tvtours_Load(Tour.All());
                MessageBox.Show("Updating had been successful!", "Message!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0)
            {
                btnAddTour.Enabled = true;
                btnUpdateTour.Enabled = true;
            }
            else
            {
                btnAddTour.Enabled = false;
                btnUpdateTour.Enabled = false;
            }
        }        


    }
}
