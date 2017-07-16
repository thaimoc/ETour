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
    public partial class Hotelfrm : Form
    {
        private int _Code = 0;

        List<int> listf = new List<int>();

        public int Code
        {
            get { return _Code; }
            set { _Code = value; }
        }

        public Hotelfrm()
        {
            InitializeComponent();
        }

        private void Hotelfrm_Load(object sender, EventArgs e)
        {
            if (Code == 0)
            {
                btnUpdate.Visible = false;
                clbleft_Load(DiemDL.All());
            }
            else
            {
                btnAdd.Visible = false;
                btnRightGoTo.Visible = false;
                controls_LoadUp();
            }
        }

        private void control_Load()
        {
            KhachSan rs = KhachSan.Single(Code);
            txtAddress.Text = rs.DiaChi;
            txtCode.Text = rs.ID.ToString();
            txtName.Text = rs.TenKS;
            txtPhone.Text = rs.SoDienThoai;
            txtStartNumber.Text = rs.SoSao.ToString();
        }

        private KhachSan control_LoadUp()
        {
            KhachSan result = new KhachSan();
            result.ID = Code;
            result.TenKS = txtName.Text;
            result.SoSao = MyConvert.ToDouble(txtStartNumber.Text);
            result.SoDienThoai = txtPhone.Text;
            result.DiaChi = txtAddress.Text;
            return result;
        }

        private void txtStartNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((MyConvert.ToInt32(e.KeyChar.ToString()) <= 7 && Char.IsDigit(e.KeyChar)) || Char.IsControl(e.KeyChar) || e.KeyChar == '.')
            {
                if (Char.IsControl(e.KeyChar) || (txtStartNumber.Text.Length == 0 && Char.IsDigit(e.KeyChar))) e.Handled = false;
                else if (txtStartNumber.Text.Length == 1 && e.KeyChar == '.') e.Handled = false;
                else if (txtStartNumber.Text.Length == 2 && MyConvert.ToInt32(e.KeyChar.ToString()) == 5) e.Handled = false;
                else e.Handled = true;
            }
            else
                e.Handled = true;
        }

        private void txtPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar) || Char.IsControl(e.KeyChar))
            {
                if (Char.IsControl(e.KeyChar) || txtPhone.Text.Length <= 24) e.Handled = false;
                else e.Handled = true;
            }
            else
                e.Handled = true;
        }

        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtName.Text.Length <= 50)
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar)) e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtAddress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtAddress.Text.Length <= 150)
                e.Handled = false;
            else if (Char.IsControl(e.KeyChar)) e.Handled = false;
            else
                e.Handled = true;
        }

        private void clbleft_Load(List<DiemDL> list)
        {
            foreach (DiemDL item in list)
            {
                clbleft.Items.Add(item.ID + " " + item.TenDiem);
            }
        }

        private void controls_LoadUp()
        {
            KhachSan ks = KhachSan.Single(Code);
            txtCode.Text = ks.ID.ToString();
            txtName.Text = ks.TenKS;
            txtStartNumber.Text = ks.SoSao.ToString();
            txtPhone.Text = ks.SoDienThoai;
            txtAddress.Text = ks.DiaChi;
            clbclbright_Load(DiemDL.FindByMaKS(Code));
            clbleft_Load(DiemDL.FindByNotMaKS(Code));
        }

        private void clbclbright_Load(List<DiemDL> list)
        {
            foreach (DiemDL item in list)
            {
                clbright.Items.Add(item.ID + " " + item.TenDiem);
            }
        }

        private KhachSan controls_Load()
        {
            KhachSan ks = new KhachSan();
            ks.ID = Code;
            ks.TenKS = txtName.Text;
            ks.SoSao = MyConvert.ToInt32(txtStartNumber.Text);
            ks.SoDienThoai = txtPhone.Text;
            ks.DiaChi = txtAddress.Text;
            return ks;
        }

        private void txtStartNumber_EditValueChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0 && txtAddress.Text.Length > 0 && txtStartNumber.Text.Length > 0)
                btnAdd.Enabled = true;
            else
                btnAdd.Enabled = false;
        }

        private void txt_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text.Length > 0 && txtAddress.Text.Length > 0 && txtStartNumber.Text.Length > 0)
                btnAdd.Enabled = true;
            else
                btnAdd.Enabled = false;
        }

        private void btnLeftGoTo_Click(object sender, EventArgs e)
        {
            if (Code == 0)
            {
                for (int i = 0; i < clbleft.Items.Count; i++)
                {
                    if (clbleft.GetItemChecked(i))
                    {
                        clbright.Items.Add(clbleft.Items[i]);
                        clbleft.Items.RemoveAt(i);
                        i--;
                    }
                }
            }
            else
            {
                for (int i = 0; i < clbleft.Items.Count; i++)
                {
                    if (clbleft.GetItemChecked(i))
                    {
                        clbright.Items.Add(clbleft.Items[i]);
                        string[] s = clbleft.Items[i].ToString().Split(' ');
                        listf.Add(MyConvert.ToInt32(s[0]));
                        clbleft.Items.RemoveAt(i);
                        i--;
                    }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (clbright.Items.Count <= 0)
            {
                MessageBox.Show("You do not choose the Sinics Witch are had been saved by this hotels!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (KhachSan.FindByName(txtName.Text, txtAddress.Text).Count > 0)
            {
                MessageBox.Show("This the hotel had been exited! Try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtName.Focus();
                return;
            }

            KhachSan ks = controls_Load();
            int id = KhachSan.Add(ks);
            if (id > 0)
            {
                MessageBox.Show("Adding is sucessful!", "Kim Nguyen Say", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                //Khu vực thêm các KSanDLich
                for (int i = 0; i < clbright.Items.Count; i++)
                {
                    KSanDLich rs = new KSanDLich();
                    rs.MKS = id;
                    string[] s = clbright.Items[i].ToString().Split(' ');
                    rs.MDiemDL = MyConvert.ToInt32(s[0]);
                    KSanDLich.Add(rs);
                }
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                return;
            }
            else
                MessageBox.Show("Adding had been failse!", "Kim Nguyen Say", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnRightGoTo_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clbright.Items.Count; i++)
            {
                if (clbright.GetItemChecked(i))
                {
                    clbleft.Items.Add(clbright.Items[i]);
                    clbright.Items.RemoveAt(i);
                    i--;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dlg = MessageBox.Show("Do you want to update this hotel?", "Kim Nguyen say:", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dlg == System.Windows.Forms.DialogResult.Yes)
            {
                if (KhachSan.Update(controls_Load()))
                {
                    if (listf.Count > 0)
                    {
                        foreach (var item in listf)
                        {
                            KSanDLich ks = new KSanDLich();
                            ks.MKS = Code;
                            ks.MDiemDL = item;
                            if (!KSanDLich.Add(ks))
                            {
                                MessageBox.Show(String.Format("Updating had been failse with the scenic witch had been code {0}?", item), "Kim Nguyen say:", MessageBoxButtons.OK, MessageBoxIcon.Question);
                            }
                        }
                    }
                    MessageBox.Show("Updating is successful?", "Kim Nguyen say:", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                    MessageBox.Show("Updating had been failse?", "Kim Nguyen say:", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }


       


        
    }
}
