﻿namespace RanfurlyCentre
    {
    partial class StaffAddEdit
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtLastName = new System.Windows.Forms.TextBox();
            this.cmbTitle = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMobilePhone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtHomePhone = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPostcode = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAddr4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtAddr3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAddr2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAddr1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstName = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgWorkCentres = new System.Windows.Forms.DataGridView();
            this.WorkCentreId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Abbreviation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmLocation = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addDoctorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeDoctorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgWorkCentres)).BeginInit();
            this.cmLocation.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(550, 34);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 56);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Update and Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(520, 329);
            this.tabControl1.TabIndex = 22;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.txtEmail);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.txtLastName);
            this.tabPage1.Controls.Add(this.cmbTitle);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtMobilePhone);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.txtHomePhone);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.txtPostcode);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtAddr4);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtAddr3);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtAddr2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtAddr1);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtFirstName);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(512, 303);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Staff Details";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(138, 274);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(319, 20);
            this.txtEmail.TabIndex = 10;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 277);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 13);
            this.label11.TabIndex = 43;
            this.label11.Text = "Email";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 43);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Last Name";
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(138, 40);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(319, 20);
            this.txtLastName.TabIndex = 1;
            // 
            // cmbTitle
            // 
            this.cmbTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTitle.FormattingEnabled = true;
            this.cmbTitle.Location = new System.Drawing.Point(138, 66);
            this.cmbTitle.Name = "cmbTitle";
            this.cmbTitle.Size = new System.Drawing.Size(319, 21);
            this.cmbTitle.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 69);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Title";
            // 
            // txtMobilePhone
            // 
            this.txtMobilePhone.Location = new System.Drawing.Point(138, 248);
            this.txtMobilePhone.Name = "txtMobilePhone";
            this.txtMobilePhone.Size = new System.Drawing.Size(319, 20);
            this.txtMobilePhone.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 251);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Mobile Phone";
            // 
            // txtHomePhone
            // 
            this.txtHomePhone.Location = new System.Drawing.Point(138, 222);
            this.txtHomePhone.Name = "txtHomePhone";
            this.txtHomePhone.Size = new System.Drawing.Size(319, 20);
            this.txtHomePhone.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 225);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "Home Phone";
            // 
            // txtPostcode
            // 
            this.txtPostcode.Location = new System.Drawing.Point(138, 196);
            this.txtPostcode.Name = "txtPostcode";
            this.txtPostcode.Size = new System.Drawing.Size(319, 20);
            this.txtPostcode.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Postcode";
            // 
            // txtAddr4
            // 
            this.txtAddr4.Location = new System.Drawing.Point(138, 170);
            this.txtAddr4.Name = "txtAddr4";
            this.txtAddr4.Size = new System.Drawing.Size(319, 20);
            this.txtAddr4.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Addr 4";
            // 
            // txtAddr3
            // 
            this.txtAddr3.Location = new System.Drawing.Point(138, 144);
            this.txtAddr3.Name = "txtAddr3";
            this.txtAddr3.Size = new System.Drawing.Size(319, 20);
            this.txtAddr3.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 31;
            this.label4.Text = "Addr 3";
            // 
            // txtAddr2
            // 
            this.txtAddr2.Location = new System.Drawing.Point(138, 118);
            this.txtAddr2.Name = "txtAddr2";
            this.txtAddr2.Size = new System.Drawing.Size(319, 20);
            this.txtAddr2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 28;
            this.label3.Text = "Addr 2";
            // 
            // txtAddr1
            // 
            this.txtAddr1.Location = new System.Drawing.Point(138, 92);
            this.txtAddr1.Name = "txtAddr1";
            this.txtAddr1.Size = new System.Drawing.Size(319, 20);
            this.txtAddr1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Addr 1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "First Name";
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(138, 14);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(319, 20);
            this.txtFirstName.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.dgWorkCentres);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(512, 303);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = ":Locations";
            // 
            // dgWorkCentres
            // 
            this.dgWorkCentres.AllowUserToAddRows = false;
            this.dgWorkCentres.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            this.dgWorkCentres.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgWorkCentres.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgWorkCentres.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWorkCentres.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WorkCentreId,
            this.LocationName,
            this.Abbreviation});
            this.dgWorkCentres.ContextMenuStrip = this.cmLocation;
            this.dgWorkCentres.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgWorkCentres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgWorkCentres.Location = new System.Drawing.Point(3, 3);
            this.dgWorkCentres.Name = "dgWorkCentres";
            this.dgWorkCentres.ReadOnly = true;
            this.dgWorkCentres.Size = new System.Drawing.Size(506, 297);
            this.dgWorkCentres.TabIndex = 8;
            // 
            // WorkCentreId
            // 
            this.WorkCentreId.DataPropertyName = "WorkCentreId";
            this.WorkCentreId.HeaderText = "PersonId";
            this.WorkCentreId.Name = "WorkCentreId";
            this.WorkCentreId.ReadOnly = true;
            this.WorkCentreId.Visible = false;
            // 
            // LocationName
            // 
            this.LocationName.DataPropertyName = "LocationName";
            this.LocationName.FillWeight = 69.67005F;
            this.LocationName.HeaderText = "Location";
            this.LocationName.Name = "LocationName";
            this.LocationName.ReadOnly = true;
            // 
            // Abbreviation
            // 
            this.Abbreviation.DataPropertyName = "Abbreviation";
            this.Abbreviation.FillWeight = 69.67005F;
            this.Abbreviation.HeaderText = "Abbreviation";
            this.Abbreviation.Name = "Abbreviation";
            this.Abbreviation.ReadOnly = true;
            // 
            // cmLocation
            // 
            this.cmLocation.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.cmLocation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addDoctorToolStripMenuItem,
            this.removeDoctorToolStripMenuItem});
            this.cmLocation.Name = "cmDoctors";
            this.cmLocation.Size = new System.Drawing.Size(208, 96);
            // 
            // addDoctorToolStripMenuItem
            // 
            this.addDoctorToolStripMenuItem.Image = global::RanfurlyCentre.Properties.Resources.WorkCentre;
            this.addDoctorToolStripMenuItem.Name = "addDoctorToolStripMenuItem";
            this.addDoctorToolStripMenuItem.Size = new System.Drawing.Size(207, 46);
            this.addDoctorToolStripMenuItem.Text = "Assign Location";
            this.addDoctorToolStripMenuItem.Click += new System.EventHandler(this.addStaffToolStripMenuItem_Click);
            // 
            // removeDoctorToolStripMenuItem
            // 
            this.removeDoctorToolStripMenuItem.Image = global::RanfurlyCentre.Properties.Resources.RemoveDoctor;
            this.removeDoctorToolStripMenuItem.Name = "removeDoctorToolStripMenuItem";
            this.removeDoctorToolStripMenuItem.Size = new System.Drawing.Size(207, 46);
            this.removeDoctorToolStripMenuItem.Text = "Remove WorkCentre";
            this.removeDoctorToolStripMenuItem.Visible = false;
            // 
            // StaffAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 353);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StaffAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Staff";
            //this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StaffAddEdit_FormClosing);
            this.Load += new System.EventHandler(this.AddDoctor_Load);
            this.Shown += new System.EventHandler(this.StaffAddEdit_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgWorkCentres)).EndInit();
            this.cmLocation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ContextMenuStrip cmLocation;
        private System.Windows.Forms.ToolStripMenuItem addDoctorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeDoctorToolStripMenuItem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.ComboBox cmbTitle;
        public System.Windows.Forms.TextBox txtMobilePhone;
        public System.Windows.Forms.TextBox txtHomePhone;
        public System.Windows.Forms.TextBox txtPostcode;
        public System.Windows.Forms.TextBox txtAddr4;
        public System.Windows.Forms.TextBox txtAddr3;
        public System.Windows.Forms.TextBox txtAddr2;
        public System.Windows.Forms.TextBox txtAddr1;
        public System.Windows.Forms.TextBox txtFirstName;
        public System.Windows.Forms.DataGridView dgWorkCentres;
        public System.Windows.Forms.TextBox txtLastName;
        public System.Windows.Forms.TextBox txtEmail;
        public System.Windows.Forms.ErrorProvider ep;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkCentreId;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Abbreviation;
    }
}