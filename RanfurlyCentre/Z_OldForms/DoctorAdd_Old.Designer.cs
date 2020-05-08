namespace RanfurlyCentre
    {
    partial class DoctorAddOld
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDoctorName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAddr1 = new System.Windows.Forms.TextBox();
            this.txtAddr2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddr3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddr4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPostcode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtDoctorName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbAddNewDoctor = new System.Windows.Forms.RadioButton();
            this.rbAllocateFromList = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Doctor Name";
            // 
            // cmbDoctorName
            // 
            this.cmbDoctorName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbDoctorName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbDoctorName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoctorName.FormattingEnabled = true;
            this.cmbDoctorName.Location = new System.Drawing.Point(178, 31);
            this.cmbDoctorName.Name = "cmbDoctorName";
            this.cmbDoctorName.Size = new System.Drawing.Size(319, 21);
            this.cmbDoctorName.TabIndex = 0;
            this.cmbDoctorName.SelectedIndexChanged += new System.EventHandler(this.cmbFullName_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Addr 1";
            // 
            // txtAddr1
            // 
            this.txtAddr1.Location = new System.Drawing.Point(178, 58);
            this.txtAddr1.Name = "txtAddr1";
            this.txtAddr1.Size = new System.Drawing.Size(319, 20);
            this.txtAddr1.TabIndex = 2;
            // 
            // txtAddr2
            // 
            this.txtAddr2.Location = new System.Drawing.Point(178, 84);
            this.txtAddr2.Name = "txtAddr2";
            this.txtAddr2.Size = new System.Drawing.Size(319, 20);
            this.txtAddr2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Addr 2";
            // 
            // txtAddr3
            // 
            this.txtAddr3.Location = new System.Drawing.Point(178, 110);
            this.txtAddr3.Name = "txtAddr3";
            this.txtAddr3.Size = new System.Drawing.Size(319, 20);
            this.txtAddr3.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Addr 3";
            // 
            // txtAddr4
            // 
            this.txtAddr4.Location = new System.Drawing.Point(178, 136);
            this.txtAddr4.Name = "txtAddr4";
            this.txtAddr4.Size = new System.Drawing.Size(319, 20);
            this.txtAddr4.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 139);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Addr 4";
            // 
            // txtPostcode
            // 
            this.txtPostcode.Location = new System.Drawing.Point(178, 162);
            this.txtPostcode.Name = "txtPostcode";
            this.txtPostcode.Size = new System.Drawing.Size(319, 20);
            this.txtPostcode.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(48, 165);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Postcode";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(178, 188);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(319, 20);
            this.txtPhone.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(48, 191);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Phone";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(178, 214);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(319, 20);
            this.txtEmail.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Email";
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Location = new System.Drawing.Point(513, 29);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(92, 23);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(611, 28);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // txtDoctorName
            // 
            this.txtDoctorName.Location = new System.Drawing.Point(178, 31);
            this.txtDoctorName.Name = "txtDoctorName";
            this.txtDoctorName.Size = new System.Drawing.Size(319, 20);
            this.txtDoctorName.TabIndex = 1;
            this.txtDoctorName.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.rbAddNewDoctor);
            this.groupBox1.Controls.Add(this.rbAllocateFromList);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupBox1.Location = new System.Drawing.Point(513, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 98);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Doctor selection";
            // 
            // rbAddNewDoctor
            // 
            this.rbAddNewDoctor.AutoSize = true;
            this.rbAddNewDoctor.Location = new System.Drawing.Point(7, 63);
            this.rbAddNewDoctor.Name = "rbAddNewDoctor";
            this.rbAddNewDoctor.Size = new System.Drawing.Size(166, 17);
            this.rbAddNewDoctor.TabIndex = 1;
            this.rbAddNewDoctor.Text = "Add New Doctor and Allocate";
            this.rbAddNewDoctor.UseVisualStyleBackColor = true;
            this.rbAddNewDoctor.CheckedChanged += new System.EventHandler(this.rbAddNewDoctor_CheckedChanged);
            // 
            // rbAllocateFromList
            // 
            this.rbAllocateFromList.AutoSize = true;
            this.rbAllocateFromList.Checked = true;
            this.rbAllocateFromList.Location = new System.Drawing.Point(6, 26);
            this.rbAllocateFromList.Name = "rbAllocateFromList";
            this.rbAllocateFromList.Size = new System.Drawing.Size(140, 17);
            this.rbAllocateFromList.TabIndex = 0;
            this.rbAllocateFromList.TabStop = true;
            this.rbAllocateFromList.Text = "Allocate Doctor from List";
            this.rbAllocateFromList.UseVisualStyleBackColor = true;
            this.rbAllocateFromList.CheckedChanged += new System.EventHandler(this.rbAllocateFromList_CheckedChanged);
            // 
            // DoctorAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 292);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtPostcode);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtAddr4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAddr3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtAddr2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAddr1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbDoctorName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDoctorName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DoctorAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Doctor";
            this.Load += new System.EventHandler(this.AddDoctor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDoctorName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAddr1;
        private System.Windows.Forms.TextBox txtAddr2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAddr3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAddr4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPostcode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ErrorProvider ep;
        private System.Windows.Forms.TextBox txtDoctorName;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbAddNewDoctor;
        private System.Windows.Forms.RadioButton rbAllocateFromList;
    }
}