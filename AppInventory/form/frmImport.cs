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
    public partial class frmImport : Form
    {
        public frmImport()
        {
            InitializeComponent();
        }
        SqlDataAdapter da;
        DataTable dt;
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

        private void DtpImp_ValueChanged(object sender, EventArgs e)
        {
            DtpImp.CustomFormat = "dd/MM/yyyy";
            cboImpSupName.Focus();
            cboImpSupName.DroppedDown = true;
        }

        private void cboImpProName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
