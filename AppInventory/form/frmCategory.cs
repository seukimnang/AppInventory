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
        string catID;

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
            LoadData();
        }
    }
}
