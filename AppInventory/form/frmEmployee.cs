using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using System.IO;

namespace AppInventory.form
{
    public partial class frmEmployee : Form
    {
        public frmEmployee()
        {
            InitializeComponent();
        }
        string fp;
        Boolean b;
        SqlCommand com;
        byte[] photo;
        SqlDataAdapter da;
        DataTable dt;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            da = new SqlDataAdapter("SELECT * FROM dbo.GetEmployee()", myOpera.con);
            dt = new DataTable();
            da.Fill(dt);
            dgvEmp.DataSource = dt;
        }
        private void frmEmployee_Load(object sender, EventArgs e)
        {
            myOpera.myConnection();
            myOpera.OnOff(this, false);
            txtSearch.ForeColor = Color.Gray;
            txtSearch.Text = "Search ID or Name here...";
            LoadData();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (btnNew.Text == "New")
            {
                b = true;
                myOpera.OnOff(this, true);
                btnNew.Text = "Cancel";
                btnNew.Image = AppInventory.Properties.Resources.cancel32;
                txtID.Focus();
            }
            else
            {
                DialogResult re = DialogResult.Yes;
                re = MessageBox.Show("Do you want to cancel ?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(re == DialogResult.Yes)
                {
                    myOpera.ClearData(this);
                    myOpera.OnOff(this, false);
                    btnNew.Text = "New";
                    btnNew.Image = AppInventory.Properties.Resources.add32;
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult re;
            re = MessageBox.Show("Do you want to Close ?", "Close",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(re == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dtpDob_ValueChanged(object sender, EventArgs e)
        {
            dtpDob.CustomFormat = "dd/MM/yyyy";
        }

        private void dtpHire_ValueChanged(object sender, EventArgs e)
        {
            dtpHire.CustomFormat = "dd/MM/yyyy";
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Filter = "JPEG FILE| *.jpg; *.jpeg|PNG FILE|*.png";
            fd.Title = "Open an Image...";
            if(fd.ShowDialog() == DialogResult.OK)
            {
                fp = fd.FileName;
                picEmp.Image = Image.FromFile(fp);
            }
        }

        private void txtSalary_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSalary.Text) ||
                !string.IsNullOrWhiteSpace(txtSalary.Text))
                txtSalary.Text = string.Format("{0:C}", decimal.Parse(txtSalary.Text));
        }

        private void txtSalary_KeyPress(object sender, KeyPressEventArgs e)
        {
            decimal x;
            char ch = e.KeyChar;
            if (ch == (char)8)
                e.Handled = false;
            else if (!char.IsDigit(ch) && ch != '.' ||
                !Decimal.TryParse(txtSalary.Text + ch, out x))
                e.Handled = true;
        }

        private void txtSalary_Enter(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtSalary.Text) || 
                !string.IsNullOrWhiteSpace(txtSalary.Text))
            {
                var s = decimal.Parse(txtSalary.Text, NumberStyles.Currency);
                txtSalary.Text = s.ToString();
            }
        }

        private void dtpDob_Enter(object sender, EventArgs e)
        {
            SendKeys.Send("%{DOWN}");
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if(txtSearch.Text == "Search ID or Name here...")
            {
                txtSearch.Text = null;
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                txtSearch.ForeColor = Color.Gray;
                txtSearch.Text = "Search ID or Name here...";
            }
        }
        private void Modify(string X)
        {
            var salary = Decimal.Parse(txtSalary.Text, NumberStyles.Currency);
            com = new SqlCommand(X, myOpera.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@i", txtID.Text);
            com.Parameters.AddWithValue("@n", txtName.Text);
            if (rdoF.Checked == true)
                com.Parameters.AddWithValue("@g", "ស");
            else
                com.Parameters.AddWithValue("@g", "ប");
            
            com.Parameters.AddWithValue("@d", dtpDob.Value);
            com.Parameters.AddWithValue("@po", txtPosition.Text);
            com.Parameters.AddWithValue("@s", salary);
            com.Parameters.AddWithValue("@a", txtAddress.Text);
            com.Parameters.AddWithValue("@c", txtcontact.Text);
            com.Parameters.AddWithValue("@h", dtpHire.Value);
            if (fp != null)
                photo = File.ReadAllBytes(fp);
            com.Parameters.AddWithValue("@pt", photo);
            com.ExecuteNonQuery();
            fp = null;
            myOpera.ClearData(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtID.Text.Trim()))
            {
                MessageBox.Show("Please Input ID...", "Missing",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtID.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                MessageBox.Show("Please Input Name...", "Missing",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtName.Focus();
                return;
            }
            if (rdoF.Checked == false && rdoM.Checked == false)
            {
                MessageBox.Show("Please Select Gender...");
                rdoF.Focus();
                return;
            }
            if(dtpDob.CustomFormat == "")
            {
                MessageBox.Show("Please Select Date Of Birth ...");
                dtpDob.Focus();
                SendKeys.Send("%{DOWN}");
                return;
            }
            if (string.IsNullOrEmpty(txtPosition.Text.Trim()))
            {
                MessageBox.Show("Please Input Position...", "Missing",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPosition.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtSalary.Text.Trim()))
            {
                MessageBox.Show("Please Input Salary...", "Missing",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSalary.Focus();
                return;
            }
            if (dtpHire.CustomFormat == "")
            {
                MessageBox.Show("Please Select Hired Date ...");
                dtpHire.Focus();
                SendKeys.Send("%{DOWN}");
                return;
            }
            if (string.IsNullOrEmpty(txtcontact.Text.Trim()))
            {
                MessageBox.Show("Please Input Phone Number...", "Missing",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtcontact.Focus();
                return;
            }
            if (picEmp.Image == null)
            {
                MessageBox.Show("Please Select an Image...");
                btnBrowse_Click(sender, e);
            }
            if(b == true)
            {
                Modify("InsertEmployee");
                MessageBox.Show("Your Data Was Saved...", "Save",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
