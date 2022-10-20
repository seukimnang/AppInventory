using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Data;

namespace AppInventory
{
    internal class myOpera
    {
        public static SqlConnection con;
        public static void myConnection()
        {
            string conStr;
            conStr = "Data Source=DESKTOP-1LEHUS5\\SQLEXPRESS; initial Catalog=AppInventory; Integrated Security=true;";
            try
            {
                con = new SqlConnection(conStr);
                con.Open();
                //MessageBox.Show("Connection is Open...");

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void OnOff(Form frm, Boolean b)
        {
            foreach(Control ct in frm.Controls)
            {
                if(!(ct is Label))
                    if(ct.Tag==null)
                        ct.Enabled = b;
                
            }
        }

        public static void ClearData(Form frm)
        {
            foreach(Control ct in frm.Controls)
            {
                if (ct is TextBox || ct is MaskedTextBox || ct is ComboBox)
                {
                    if (ct.Tag == null)
                        ct.Text = null;
                }
                else if (ct is RadioButton)
                    ((RadioButton)ct).Checked = false;
                else if (ct is DateTimePicker)
                    ((DateTimePicker)ct).CustomFormat = " ";
                else if (ct is PictureBox)
                    ((PictureBox)ct).Image = null;
            }
        }
        public static void FillCbo(ComboBox cbo, string fd1,string fd2, string tb)
        {
            SqlDataAdapter da;
            DataTable dt;
            da = new SqlDataAdapter("SELECT " + fd1 + "," + fd2 +" FROM " + tb, con);
            dt = new DataTable();
            da.Fill(dt);
            cbo.DataSource = null;
            cbo.Items.Clear();
            cbo.DataSource = dt;
            cbo.DisplayMember = fd2;
            cbo.ValueMember = fd1;
            cbo.Text = null;
        }
    }
}
