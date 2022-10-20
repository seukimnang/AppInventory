namespace AppInventory.form
{
    partial class frmSuppiler
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSupID = new System.Windows.Forms.TextBox();
            this.txtSupName = new System.Windows.Forms.TextBox();
            this.txtSupContact = new System.Windows.Forms.TextBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtSupSearch = new System.Windows.Forms.TextBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(629, 77);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Font = new System.Drawing.Font("Khmer OS Bokor", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(625, 77);
            this.label1.TabIndex = 1;
            this.label1.Text = "ព័ត៍មានអ្នកផ្គត់ផ្គង់";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(56, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 36);
            this.label2.TabIndex = 1;
            this.label2.Text = "លេខសម្គាល់";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(56, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 36);
            this.label3.TabIndex = 2;
            this.label3.Text = "អ្នកផ្គត់ផ្គង់";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(56, 211);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 36);
            this.label4.TabIndex = 3;
            this.label4.Text = "ទំនាក់ទំនង";
            // 
            // txtSupID
            // 
            this.txtSupID.Location = new System.Drawing.Point(206, 109);
            this.txtSupID.Multiline = true;
            this.txtSupID.Name = "txtSupID";
            this.txtSupID.Size = new System.Drawing.Size(243, 42);
            this.txtSupID.TabIndex = 4;
            // 
            // txtSupName
            // 
            this.txtSupName.Location = new System.Drawing.Point(206, 157);
            this.txtSupName.Name = "txtSupName";
            this.txtSupName.Size = new System.Drawing.Size(243, 45);
            this.txtSupName.TabIndex = 5;
            // 
            // txtSupContact
            // 
            this.txtSupContact.Location = new System.Drawing.Point(206, 208);
            this.txtSupContact.Name = "txtSupContact";
            this.txtSupContact.Size = new System.Drawing.Size(243, 45);
            this.txtSupContact.TabIndex = 6;
            // 
            // btnNew
            // 
            this.btnNew.Image = global::AppInventory.Properties.Resources.add32;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(475, 109);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(112, 45);
            this.btnNew.TabIndex = 7;
            this.btnNew.Text = "New";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Image = global::AppInventory.Properties.Resources.save32;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(475, 159);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 41);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            this.btnEdit.Image = global::AppInventory.Properties.Resources.update32;
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(475, 206);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(112, 43);
            this.btnEdit.TabIndex = 9;
            this.btnEdit.Text = "Edit";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::AppInventory.Properties.Resources.cancel32;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(475, 255);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(112, 40);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // txtSupSearch
            // 
            this.txtSupSearch.Location = new System.Drawing.Point(56, 259);
            this.txtSupSearch.Name = "txtSupSearch";
            this.txtSupSearch.Size = new System.Drawing.Size(393, 45);
            this.txtSupSearch.TabIndex = 11;
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(56, 311);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(393, 159);
            this.listView1.TabIndex = 12;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // frmSuppiler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 482);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.txtSupSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.txtSupContact);
            this.Controls.Add(this.txtSupName);
            this.Controls.Add(this.txtSupID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Khmer OS Content", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmSuppiler";
            this.Text = "frmSuppiler";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtSupID;
        private TextBox txtSupName;
        private TextBox txtSupContact;
        private Button btnNew;
        private Button btnSave;
        private Button btnEdit;
        private Button btnClose;
        private TextBox txtSupSearch;
        private ListView listView1;
    }
}