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

namespace AppInventory.form
{
    public partial class frmCategory : Form
    {
        public frmCategory()
        {
            InitializeComponent();
        }
        SqlDataAdapter da;
        DataTable dt;
        Boolean b;
        SqlCommand com;
        string catID="0";

        private void LoadData()
        {
            da = new SqlDataAdapter("SELECT * FROM dbo.GetCategory()", myOpera.con);
            dt = new DataTable();
            da.Fill(dt);
            lswCate.Clear();
            lswCate.View = View.Details;
            //Add Column Header 
            lswCate.Columns.Add("ID", 90);
            lswCate.Columns.Add("Category", 260);
            //Load Data from table into listview
            string[] arr = new string[2];
            ListViewItem item;
            for(int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                arr[0] = dr[0].ToString();
                arr[1] = dr[1].ToString();
                item = new ListViewItem(arr);
                lswCate.Items.Add(item);
            }
            // Alternative Color
            foreach ( ListViewItem list in lswCate.Items)
            {
                if (( list.Index % 2 ) == 0)
                {
                    list.BackColor = Color.White;
                }else
                {
                    list.BackColor = Color.LightBlue;
                }
            }
            dt.Dispose();
            da.Dispose();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmCategory_Load(object sender, EventArgs e)
        {
            myOpera.OnOff(this, false);
            myOpera.myConnection();
            txtCateID.Text = "Auto Number";
            txtCateID.Enabled = false;
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
                btnEdit.Enabled = false;
                txtCateName.Focus();
            }
            else
            {
                DialogResult re = DialogResult.Yes;
                re = MessageBox.Show("Do you want to cancel ?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (re == DialogResult.Yes)
                {
                    myOpera.ClearData(this);
                    myOpera.OnOff(this, false);
                    btnNew.Text = "New";
                    btnNew.Image = AppInventory.Properties.Resources.add32;
                }
            }
        }

        private void Modify(string X)
        {
            com = new SqlCommand(X, myOpera.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@i", int.Parse(catID.ToString()));
            com.Parameters.AddWithValue("@c", txtCateName.Text);
            com.ExecuteNonQuery();
            com.Dispose();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult re;
            re = MessageBox.Show("Do you want to Close ?", "Close",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (re == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCateName.Text.Trim()))
            {
                MessageBox.Show("Please Input Category...", "Missing",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCateName.Focus();
                return;
            }
            if (b == true)
            {
                Modify("InsertCategory");
                MessageBox.Show("Your Data Was Saved...", "Save",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Modify("UpdateCategory");
                MessageBox.Show("Your Data Was Update...", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //frmEmployee_Load(sender, e);
            LoadData();
            myOpera.ClearData(this);
            myOpera.OnOff(this, false);
            btnNew.Text = "New";
            btnNew.Image = AppInventory.Properties.Resources.add32;
        }

        private void lswCate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lswCate.SelectedItems.Count > 0)
            {
                ListViewItem item = lswCate.SelectedItems[0]; // row
                catID = item.SubItems[0].Text; // column id
                txtCateName.Text = item.SubItems[1].Text; // column category
                btnEdit.Enabled = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            b = false;
            btnNew.Text = "Cancel";
            btnNew.Image = AppInventory.Properties.Resources.cancel32;
            myOpera.OnOff(this, true);
            txtCateName.Focus();
            btnEdit.Enabled = false;
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            com = new SqlCommand("SCat", myOpera.con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@c", txtSearch.Text);

            da = new SqlDataAdapter();
            da.SelectCommand = com;
            dt = new DataTable();
            da.Fill(dt);
            lswCate.Clear();
            string[] arr = new string[2];
            lswCate.Columns.Add("ID", 90);
            lswCate.Columns.Add("Category", 260);
            lswCate.View = View.Details;
            ListViewItem item;
            for(int i=0; i<dt.Rows.Count; i++)
            {

            }
        }
    }
}
