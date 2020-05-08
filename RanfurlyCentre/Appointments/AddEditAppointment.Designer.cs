namespace RanfurlyCentre
{
    partial class AddEditAppointment
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
            this.cmbAppointmentType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbResidentId = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbStaffAccompanyingId = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.lstAmPm = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lstMinute = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lstHour = new System.Windows.Forms.ListBox();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddAppontment = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblHeader = new System.Windows.Forms.Label();
            this.txtPurpose = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkIsFollowupNeeded = new System.Windows.Forms.CheckBox();
            this.chkIsInHouseAppointment = new System.Windows.Forms.CheckBox();
            this.lblServiceProvider = new System.Windows.Forms.Label();
            this.cmbSpecialistId = new System.Windows.Forms.ComboBox();
            this.cmbAddSpecialist = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbKeyCode = new System.Windows.Forms.ComboBox();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbAppointmentType
            // 
            this.cmbAppointmentType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbAppointmentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAppointmentType.FormattingEnabled = true;
            this.cmbAppointmentType.Location = new System.Drawing.Point(143, 102);
            this.cmbAppointmentType.Name = "cmbAppointmentType";
            this.cmbAppointmentType.Size = new System.Drawing.Size(222, 21);
            this.cmbAppointmentType.TabIndex = 0;
            this.cmbAppointmentType.SelectedIndexChanged += new System.EventHandler(this.cmbAppointmentType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(41, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Appointment Type:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 159);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Resident:";
            // 
            // cmbResidentId
            // 
            this.cmbResidentId.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbResidentId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbResidentId.FormattingEnabled = true;
            this.cmbResidentId.Location = new System.Drawing.Point(143, 156);
            this.cmbResidentId.Name = "cmbResidentId";
            this.cmbResidentId.Size = new System.Drawing.Size(222, 21);
            this.cmbResidentId.TabIndex = 2;
            this.cmbResidentId.SelectedIndexChanged += new System.EventHandler(this.cmbResidentId_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 186);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Staff Accompanying:";
            // 
            // cmbStaffAccompanyingId
            // 
            this.cmbStaffAccompanyingId.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbStaffAccompanyingId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaffAccompanyingId.FormattingEnabled = true;
            this.cmbStaffAccompanyingId.Location = new System.Drawing.Point(143, 183);
            this.cmbStaffAccompanyingId.Name = "cmbStaffAccompanyingId";
            this.cmbStaffAccompanyingId.Size = new System.Drawing.Size(222, 21);
            this.cmbStaffAccompanyingId.TabIndex = 4;
            this.cmbStaffAccompanyingId.SelectedIndexChanged += new System.EventHandler(this.cmbStaffAccompanyingId_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.lstAmPm);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.lstMinute);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.lstHour);
            this.panel2.Controls.Add(this.dtp);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(627, 102);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 246);
            this.panel2.TabIndex = 38;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(181, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "AM/PM";
            // 
            // lstAmPm
            // 
            this.lstAmPm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstAmPm.FormattingEnabled = true;
            this.lstAmPm.Items.AddRange(new object[] {
            "AM",
            "PM"});
            this.lstAmPm.Location = new System.Drawing.Point(190, 73);
            this.lstAmPm.Name = "lstAmPm";
            this.lstAmPm.Size = new System.Drawing.Size(30, 30);
            this.lstAmPm.TabIndex = 33;
            this.lstAmPm.SelectedIndexChanged += new System.EventHandler(this.lstAmPm_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(103, 57);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 13);
            this.label10.TabIndex = 32;
            this.label10.Text = "Minute:";
            // 
            // lstMinute
            // 
            this.lstMinute.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstMinute.FormattingEnabled = true;
            this.lstMinute.Items.AddRange(new object[] {
            "00",
            "05",
            "10",
            "15",
            "20",
            "25",
            "30",
            "35",
            "40",
            "45",
            "50",
            "55"});
            this.lstMinute.Location = new System.Drawing.Point(106, 73);
            this.lstMinute.Name = "lstMinute";
            this.lstMinute.Size = new System.Drawing.Size(30, 160);
            this.lstMinute.TabIndex = 31;
            this.lstMinute.SelectedIndexChanged += new System.EventHandler(this.lstMinute_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(33, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Hour:";
            // 
            // lstHour
            // 
            this.lstHour.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstHour.FormattingEnabled = true;
            this.lstHour.Items.AddRange(new object[] {
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.lstHour.Location = new System.Drawing.Point(20, 73);
            this.lstHour.Name = "lstHour";
            this.lstHour.Size = new System.Drawing.Size(30, 160);
            this.lstHour.TabIndex = 29;
            this.lstHour.SelectedIndexChanged += new System.EventHandler(this.lstHour_SelectedIndexChanged);
            // 
            // dtp
            // 
            this.dtp.Checked = false;
            this.dtp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dtp.Location = new System.Drawing.Point(20, 29);
            this.dtp.Name = "dtp";
            this.dtp.ShowCheckBox = true;
            this.dtp.Size = new System.Drawing.Size(200, 20);
            this.dtp.TabIndex = 3;
            this.dtp.ValueChanged += new System.EventHandler(this.dtp_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 13);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 28;
            this.label7.Text = "Date:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(624, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 39;
            this.label5.Text = "Appointment Date:";
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(809, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 38);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddAppontment
            // 
            this.btnAddAppontment.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddAppontment.ForeColor = System.Drawing.Color.Maroon;
            this.btnAddAppontment.Location = new System.Drawing.Point(687, 10);
            this.btnAddAppontment.Name = "btnAddAppontment";
            this.btnAddAppontment.Size = new System.Drawing.Size(116, 38);
            this.btnAddAppontment.TabIndex = 1;
            this.btnAddAppontment.Text = "Save Appointment";
            this.btnAddAppontment.UseVisualStyleBackColor = true;
            this.btnAddAppontment.Click += new System.EventHandler(this.btnAddAppontment_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.NavajoWhite;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnAddAppontment);
            this.panel1.Controls.Add(this.lblHeader);
            this.panel1.Location = new System.Drawing.Point(2, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(907, 59);
            this.panel1.TabIndex = 40;
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Navy;
            this.lblHeader.Location = new System.Drawing.Point(28, 14);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(180, 26);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "Add Appointment";
            // 
            // txtPurpose
            // 
            this.txtPurpose.Location = new System.Drawing.Point(143, 212);
            this.txtPurpose.Multiline = true;
            this.txtPurpose.Name = "txtPurpose";
            this.txtPurpose.Size = new System.Drawing.Size(222, 150);
            this.txtPurpose.TabIndex = 41;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 42;
            this.label4.Text = "Purpose:";
            // 
            // chkIsFollowupNeeded
            // 
            this.chkIsFollowupNeeded.AutoSize = true;
            this.chkIsFollowupNeeded.Location = new System.Drawing.Point(374, 322);
            this.chkIsFollowupNeeded.Name = "chkIsFollowupNeeded";
            this.chkIsFollowupNeeded.Size = new System.Drawing.Size(112, 17);
            this.chkIsFollowupNeeded.TabIndex = 43;
            this.chkIsFollowupNeeded.Text = "Follow up Needed";
            this.chkIsFollowupNeeded.UseVisualStyleBackColor = true;
            // 
            // chkIsInHouseAppointment
            // 
            this.chkIsInHouseAppointment.AutoSize = true;
            this.chkIsInHouseAppointment.Location = new System.Drawing.Point(374, 345);
            this.chkIsInHouseAppointment.Name = "chkIsInHouseAppointment";
            this.chkIsInHouseAppointment.Size = new System.Drawing.Size(131, 17);
            this.chkIsInHouseAppointment.TabIndex = 44;
            this.chkIsInHouseAppointment.Text = "In-House Appointment";
            this.chkIsInHouseAppointment.UseVisualStyleBackColor = true;
            // 
            // lblServiceProvider
            // 
            this.lblServiceProvider.AutoSize = true;
            this.lblServiceProvider.Location = new System.Drawing.Point(46, 131);
            this.lblServiceProvider.Name = "lblServiceProvider";
            this.lblServiceProvider.Size = new System.Drawing.Size(88, 13);
            this.lblServiceProvider.TabIndex = 46;
            this.lblServiceProvider.Text = "Service Provider:";
            // 
            // cmbSpecialistId
            // 
            this.cmbSpecialistId.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSpecialistId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSpecialistId.FormattingEnabled = true;
            this.cmbSpecialistId.Location = new System.Drawing.Point(143, 128);
            this.cmbSpecialistId.Name = "cmbSpecialistId";
            this.cmbSpecialistId.Size = new System.Drawing.Size(222, 21);
            this.cmbSpecialistId.TabIndex = 47;
            this.cmbSpecialistId.SelectedIndexChanged += new System.EventHandler(this.cmbSpecialistId_SelectedIndexChanged);
            // 
            // cmbAddSpecialist
            // 
            this.cmbAddSpecialist.ForeColor = System.Drawing.Color.Navy;
            this.cmbAddSpecialist.Location = new System.Drawing.Point(374, 126);
            this.cmbAddSpecialist.Name = "cmbAddSpecialist";
            this.cmbAddSpecialist.Size = new System.Drawing.Size(60, 23);
            this.cmbAddSpecialist.TabIndex = 48;
            this.cmbAddSpecialist.Text = "Add New";
            this.cmbAddSpecialist.UseVisualStyleBackColor = true;
            this.cmbAddSpecialist.Click += new System.EventHandler(this.cmbAddSpecialist_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(371, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 13);
            this.label6.TabIndex = 50;
            this.label6.Text = "Key Code:";
            // 
            // cmbKeyCode
            // 
            this.cmbKeyCode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbKeyCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbKeyCode.FormattingEnabled = true;
            this.cmbKeyCode.Items.AddRange(new object[] {
            "Accident (A)",
            "Annual Check Up (AA)",
            "Consulation (C)",
            "Infection (I)",
            "Medical Review (M)",
            "Treatment (T)",
            "Antibiotics Prescribed (AB)",
            "Vaccination (V)",
            "Any Other (O)"});
            this.cmbKeyCode.Location = new System.Drawing.Point(441, 102);
            this.cmbKeyCode.Name = "cmbKeyCode";
            this.cmbKeyCode.Size = new System.Drawing.Size(151, 21);
            this.cmbKeyCode.TabIndex = 49;
            this.cmbKeyCode.SelectedIndexChanged += new System.EventHandler(this.cmbKeyCode_SelectedIndexChanged);
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(75, 368);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 52;
            this.label9.Text = "Comments:";
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(143, 368);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(222, 70);
            this.txtComments.TabIndex = 51;
            // 
            // AddEditAppointment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(910, 450);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cmbKeyCode);
            this.Controls.Add(this.cmbAddSpecialist);
            this.Controls.Add(this.cmbSpecialistId);
            this.Controls.Add(this.lblServiceProvider);
            this.Controls.Add(this.chkIsInHouseAppointment);
            this.Controls.Add(this.chkIsFollowupNeeded);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtPurpose);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbStaffAccompanyingId);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbResidentId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbAppointmentType);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddEditAppointment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Appointment";
            this.Load += new System.EventHandler(this.AddEditAppointment_Load);
            this.Shown += new System.EventHandler(this.AddEditAppointment_Shown);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox lstAmPm;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lstMinute;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lstHour;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.TextBox txtPurpose;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkIsFollowupNeeded;
        private System.Windows.Forms.CheckBox chkIsInHouseAppointment;
        private System.Windows.Forms.Label lblServiceProvider;
        public System.Windows.Forms.ComboBox cmbAppointmentType;
        public System.Windows.Forms.ComboBox cmbSpecialistId;
        public System.Windows.Forms.Button cmbAddSpecialist;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cmbKeyCode;
        private System.Windows.Forms.ErrorProvider ep;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtComments;
        public System.Windows.Forms.ComboBox cmbResidentId;
        public System.Windows.Forms.ComboBox cmbStaffAccompanyingId;
        public System.Windows.Forms.Button btnAddAppontment;
    }
}