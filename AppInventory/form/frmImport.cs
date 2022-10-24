using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Globalization;

namespace AppInventory.form
{
    public partial class frmImport : Form
    {
        public frmImport()
        {
            InitializeComponent();
        }
        SqlDataAdapter da;
        DataTable dt;
        SqlCommand com;
        int supID;
        decimal Total = 0;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frmImport_Load(object sender, EventArgs e)
        {
            myOpera.OnOff(this, false);
            myOpera.myConnection();
            txtImpID.Text = "Auto Number";
            txtImpID.Enabled = false;
            txtImpSupID.Text = "Auto Number";
            txtImpSupID.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult re = DialogResult.Yes;
            re = MessageBox.Show("Do you want to Close ?","Close",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(re == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            if (btnNew.Text == "New")
            {
                myOpera.OnOff(this, true);
                btnNew.Text = "Cancel";
                btnNew.Image = AppInventory.Properties.Resources.cancel32;
                DtpImp.Focus();
                SendKeys.Send("%{DOWN}");
                myOpera.FillCbo(cboImpSupName, "supID", "supName", "tblsupplier");
                myOpera.FillCbo(cboImpCate, "catID", "category", "tblcategory");
                myOpera.FillCbo(cboImpProName, "proID", "proName", "tblProduct");
                lswImp.Clear();
                lswImp.View = View.Details;
                lswImp.Columns.Add("Product ID", 100);
                lswImp.Columns.Add("Product Name", 200);
                lswImp.Columns.Add("Quantity", 100);
                lswImp.Columns.Add("Unit Price", 100);
                lswImp.Columns.Add("Amount", 100);
                lswImp.Columns.Add("Category", 150);
                lswImp.Columns.Add("Category ID", 0);
            }
            else
            {
                DialogResult re = DialogResult.Yes;
                re = MessageBox.Show("Do you want to cancel ?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (re == DialogResult.Yes)
                {
                    myOpera.ClearData(this);
                    myOpera.OnOff(this, false);
                    lswImp.Items.Clear();
                    Total = 0;
                    btnNew.Text = "New";
                    btnNew.Image = AppInventory.Properties.Resources.add32;
                }
            }
        }

        private void DtpImp_ValueChanged(object sender, EventArgs e)
        {
            DtpImp.CustomFormat = "dd/MM/yyyy";
            cboImpSupName.Focus();
            cboImpSupName.DroppedDown = true;
        }

        private void cboImpProName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboImpProName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtImpProID.Text = cboImpProName.SelectedValue.ToString();
            com = new SqlCommand("SELECT catID FROM tblProduct WHERE proID='"
                + txtImpProID.Text + "'", myOpera.con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                cboImpCate.SelectedValue = int.Parse(dr[0].ToString());
            }
            dr.Dispose();
            com.Dispose();
        }

        private void txtImpProID_TextChanged(object sender, EventArgs e)
        {
            com = new SqlCommand("SELECT catID, proID FROM tblProduct WHERE proID='"
                + txtImpProID.Text +"'", myOpera.con);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                cboImpCate.SelectedValue = int.Parse(dr[0].ToString());
                cboImpProName.SelectedValue = txtImpProID.Text;
            }
            dr.Dispose();
            com.Dispose();
        }

        private void btnAdditem_Click(object sender, EventArgs e)
        {
            Decimal amount;
            ListViewItem item;
            string[] arr = new string[7];
            arr[0] = txtImpProID.Text;
            arr[1] = cboImpProName.Text;
            arr[2] = txtImpQty.Text;
            arr[3] = string.Format("{0:c}", txtImpPrice.Text);
            amount = decimal.Parse(txtImpQty.Text) * decimal.Parse(txtImpPrice.Text);
            arr[4] = string.Format("{0:c}", amount);
            arr[5] = cboImpCate.Text;
            arr[6] = cboImpCate.SelectedValue.ToString();
            item = new ListViewItem(arr);
            lswImp.Items.Add(item);
            Total = Total + amount;
            txtImpTotal.Text = string.Format("{0:c}", Total.ToString());
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult re;
            foreach (ListViewItem item in lswImp.Items)
            {
                if (item.Selected)
                {
                    re = MessageBox.Show("Do you want to remove this item?", "Remove",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(re == DialogResult.Yes)
                    {
                        ListViewItem it = lswImp.SelectedItems[0];
                        lswImp.Items.Remove(item);
                        var a = decimal.Parse(it.SubItems[4].Text, NumberStyles.Currency);
                        Total = Total - a;
                        txtImpTotal.Text = String.Format("{0:c}", Total);
                    }
                }
            }
        }
    }
}
