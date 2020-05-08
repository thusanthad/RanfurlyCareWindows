namespace RanfurlyCentre
{
    partial class IncidentAddEdit
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
            this.headerLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAddIncident = new System.Windows.Forms.Button();
            this.txtFileDrop = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtFileLocation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.cmbStudent = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbStaff = new System.Windows.Forms.ComboBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.dtp = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPersonFullName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbOther = new System.Windows.Forms.RadioButton();
            this.rbStaffAndStudent = new System.Windows.Forms.RadioButton();
            this.rbStaff = new System.Windows.Forms.RadioButton();
            this.rbStudent = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.lstAmPm = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lstMinute = new System.Windows.Forms.ListBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lstHour = new System.Windows.Forms.ListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbCoordinator = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cmbWhoReported = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cmbHSOfficer = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.cmbManager = new System.Windows.Forms.ComboBox();
            this.label17 = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.Navy;
            this.headerLabel.Location = new System.Drawing.Point(12, 14);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(133, 26);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Add Incident";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.NavajoWhite;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnAddIncident);
            this.panel1.Controls.Add(this.headerLabel);
            this.panel1.Location = new System.Drawing.Point(8, 8);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(719, 59);
            this.panel1.TabIndex = 2;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(615, 10);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(84, 38);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAddIncident
            // 
            this.btnAddIncident.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddIncident.ForeColor = System.Drawing.Color.Maroon;
            this.btnAddIncident.Location = new System.Drawing.Point(485, 10);
            this.btnAddIncident.Name = "btnAddIncident";
            this.btnAddIncident.Size = new System.Drawing.Size(116, 38);
            this.btnAddIncident.TabIndex = 1;
            this.btnAddIncident.Text = "Add Incident";
            this.btnAddIncident.UseVisualStyleBackColor = true;
            this.btnAddIncident.Click += new System.EventHandler(this.btnAddIncident_Click);
            // 
            // txtFileDrop
            // 
            this.txtFileDrop.AllowDrop = true;
            this.txtFileDrop.BackColor = System.Drawing.Color.Thistle;
            this.txtFileDrop.Location = new System.Drawing.Point(99, 548);
            this.txtFileDrop.Multiline = true;
            this.txtFileDrop.Name = "txtFileDrop";
            this.txtFileDrop.Size = new System.Drawing.Size(214, 39);
            this.txtFileDrop.TabIndex = 8;
            this.txtFileDrop.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFileDrop_DragDrop);
            this.txtFileDrop.DragEnter += new System.Windows.Forms.DragEventHandler(this.txtFileDrop_DragEnter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(96, 530);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Drag and Drop Incident File here";
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // txtFileLocation
            // 
            this.txtFileLocation.Location = new System.Drawing.Point(99, 242);
            this.txtFileLocation.Multiline = true;
            this.txtFileLocation.Name = "txtFileLocation";
            this.txtFileLocation.ReadOnly = true;
            this.txtFileLocation.Size = new System.Drawing.Size(357, 40);
            this.txtFileLocation.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 245);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "File Location:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 291);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "File Name:";
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point(99, 288);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.ReadOnly = true;
            this.txtFileName.Size = new System.Drawing.Size(357, 20);
            this.txtFileName.TabIndex = 7;
            // 
            // cmbStudent
            // 
            this.cmbStudent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbStudent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStudent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStudent.FormattingEnabled = true;
            this.cmbStudent.Location = new System.Drawing.Point(99, 79);
            this.cmbStudent.Name = "cmbStudent";
            this.cmbStudent.Size = new System.Drawing.Size(186, 21);
            this.cmbStudent.TabIndex = 0;
            this.cmbStudent.SelectedIndexChanged += new System.EventHandler(this.cmbStudent_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Student:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 109);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Staff:";
            // 
            // cmbStaff
            // 
            this.cmbStaff.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbStaff.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbStaff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaff.FormattingEnabled = true;
            this.cmbStaff.Location = new System.Drawing.Point(99, 106);
            this.cmbStaff.Name = "cmbStaff";
            this.cmbStaff.Size = new System.Drawing.Size(186, 21);
            this.cmbStaff.TabIndex = 1;
            this.cmbStaff.SelectedIndexChanged += new System.EventHandler(this.cmbStaff_SelectedIndexChanged);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(99, 162);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(357, 74);
            this.txtDescription.TabIndex = 5;
            // 
            // dtp
            // 
            this.dtp.Checked = false;
            this.dtp.Location = new System.Drawing.Point(20, 29);
            this.dtp.Name = "dtp";
            this.dtp.ShowCheckBox = true;
            this.dtp.Size = new System.Drawing.Size(200, 20);
            this.dtp.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 136);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Person Name:";
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
            // txtPersonFullName
            // 
            this.txtPersonFullName.Location = new System.Drawing.Point(99, 136);
            this.txtPersonFullName.Name = "txtPersonFullName";
            this.txtPersonFullName.Size = new System.Drawing.Size(186, 20);
            this.txtPersonFullName.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Description:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbOther);
            this.groupBox1.Controls.Add(this.rbStaffAndStudent);
            this.groupBox1.Controls.Add(this.rbStaff);
            this.groupBox1.Controls.Add(this.rbStudent);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupBox1.Location = new System.Drawing.Point(473, 85);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 119);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Incident Type";
            // 
            // rbOther
            // 
            this.rbOther.AutoSize = true;
            this.rbOther.Location = new System.Drawing.Point(6, 88);
            this.rbOther.Name = "rbOther";
            this.rbOther.Size = new System.Drawing.Size(51, 17);
            this.rbOther.TabIndex = 3;
            this.rbOther.Text = "Other";
            this.rbOther.UseVisualStyleBackColor = true;
            this.rbOther.CheckedChanged += new System.EventHandler(this.rbOther_CheckedChanged);
            // 
            // rbStaffAndStudent
            // 
            this.rbStaffAndStudent.AutoSize = true;
            this.rbStaffAndStudent.Location = new System.Drawing.Point(6, 65);
            this.rbStaffAndStudent.Name = "rbStaffAndStudent";
            this.rbStaffAndStudent.Size = new System.Drawing.Size(108, 17);
            this.rbStaffAndStudent.TabIndex = 2;
            this.rbStaffAndStudent.Text = "Staff and Student";
            this.rbStaffAndStudent.UseVisualStyleBackColor = true;
            this.rbStaffAndStudent.CheckedChanged += new System.EventHandler(this.rbStaffAndStudent_CheckedChanged);
            // 
            // rbStaff
            // 
            this.rbStaff.AutoSize = true;
            this.rbStaff.Location = new System.Drawing.Point(6, 42);
            this.rbStaff.Name = "rbStaff";
            this.rbStaff.Size = new System.Drawing.Size(47, 17);
            this.rbStaff.TabIndex = 1;
            this.rbStaff.Text = "Staff";
            this.rbStaff.UseVisualStyleBackColor = true;
            this.rbStaff.CheckedChanged += new System.EventHandler(this.rbStaff_CheckedChanged);
            // 
            // rbStudent
            // 
            this.rbStudent.AutoSize = true;
            this.rbStudent.Location = new System.Drawing.Point(6, 19);
            this.rbStudent.Name = "rbStudent";
            this.rbStudent.Size = new System.Drawing.Size(62, 17);
            this.rbStudent.TabIndex = 0;
            this.rbStudent.Text = "Student";
            this.rbStudent.UseVisualStyleBackColor = true;
            this.rbStudent.CheckedChanged += new System.EventHandler(this.rbStudent_CheckedChanged);
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
            this.panel2.Location = new System.Drawing.Point(473, 210);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(234, 246);
            this.panel2.TabIndex = 37;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(187, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "AM/PM";
            // 
            // lstAmPm
            // 
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
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(33, 317);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "Comments:";
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(99, 314);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(357, 77);
            this.txtComments.TabIndex = 38;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(28, 427);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 13);
            this.label13.TabIndex = 43;
            this.label13.Text = "Coordinator:";
            // 
            // cmbCoordinator
            // 
            this.cmbCoordinator.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbCoordinator.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbCoordinator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCoordinator.FormattingEnabled = true;
            this.cmbCoordinator.Location = new System.Drawing.Point(99, 424);
            this.cmbCoordinator.Name = "cmbCoordinator";
            this.cmbCoordinator.Size = new System.Drawing.Size(186, 21);
            this.cmbCoordinator.TabIndex = 41;
            this.cmbCoordinator.SelectedIndexChanged += new System.EventHandler(this.cmbCoordinator_SelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 400);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label14.Size = new System.Drawing.Size(80, 13);
            this.label14.TabIndex = 42;
            this.label14.Text = "Who Reported:";
            // 
            // cmbWhoReported
            // 
            this.cmbWhoReported.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbWhoReported.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbWhoReported.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWhoReported.FormattingEnabled = true;
            this.cmbWhoReported.Location = new System.Drawing.Point(99, 397);
            this.cmbWhoReported.Name = "cmbWhoReported";
            this.cmbWhoReported.Size = new System.Drawing.Size(186, 21);
            this.cmbWhoReported.TabIndex = 40;
            this.cmbWhoReported.SelectedIndexChanged += new System.EventHandler(this.cmbWhoReported_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(21, 482);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(71, 13);
            this.label15.TabIndex = 47;
            this.label15.Text = "H && S Officer:";
            // 
            // cmbHSOfficer
            // 
            this.cmbHSOfficer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbHSOfficer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbHSOfficer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHSOfficer.FormattingEnabled = true;
            this.cmbHSOfficer.Location = new System.Drawing.Point(99, 479);
            this.cmbHSOfficer.Name = "cmbHSOfficer";
            this.cmbHSOfficer.Size = new System.Drawing.Size(186, 21);
            this.cmbHSOfficer.TabIndex = 45;
            this.cmbHSOfficer.SelectedIndexChanged += new System.EventHandler(this.cmbHSOfficer_SelectedIndexChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(40, 455);
            this.label16.Name = "label16";
            this.label16.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label16.Size = new System.Drawing.Size(52, 13);
            this.label16.TabIndex = 46;
            this.label16.Text = "Manager:";
            // 
            // cmbManager
            // 
            this.cmbManager.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbManager.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbManager.FormattingEnabled = true;
            this.cmbManager.Location = new System.Drawing.Point(99, 452);
            this.cmbManager.Name = "cmbManager";
            this.cmbManager.Size = new System.Drawing.Size(186, 21);
            this.cmbManager.TabIndex = 44;
            this.cmbManager.SelectedIndexChanged += new System.EventHandler(this.cmbManager_SelectedIndexChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(41, 509);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 13);
            this.label17.TabIndex = 49;
            this.label17.Text = "Location:";
            // 
            // cmbLocation
            // 
            this.cmbLocation.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbLocation.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(99, 506);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(186, 21);
            this.cmbLocation.TabIndex = 48;
            this.cmbLocation.SelectedIndexChanged += new System.EventHandler(this.cmbLocation_SelectedIndexChanged);
            // 
            // IncidentAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 596);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.cmbLocation);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.cmbHSOfficer);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.cmbManager);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbCoordinator);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbWhoReported);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPersonFullName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbStaff);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbStudent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFileLocation);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFileDrop);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IncidentAddEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Edit Incident";
            this.Load += new System.EventHandler(this.AddEditIncident_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtFileDrop;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ErrorProvider ep;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFileLocation;
        public System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.DateTimePicker dtp;
        private System.Windows.Forms.Button btnAddIncident;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ListBox lstAmPm;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListBox lstMinute;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ListBox lstHour;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtComments;
        public System.Windows.Forms.ComboBox cmbStaff;
        public System.Windows.Forms.ComboBox cmbStudent;
        public System.Windows.Forms.RadioButton rbOther;
        public System.Windows.Forms.RadioButton rbStaffAndStudent;
        public System.Windows.Forms.RadioButton rbStaff;
        public System.Windows.Forms.RadioButton rbStudent;
        public System.Windows.Forms.TextBox txtPersonFullName;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.ComboBox cmbLocation;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.ComboBox cmbHSOfficer;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.ComboBox cmbManager;
        private System.Windows.Forms.Label label13;
        public System.Windows.Forms.ComboBox cmbCoordinator;
        private System.Windows.Forms.Label label14;
        public System.Windows.Forms.ComboBox cmbWhoReported;
        private System.Windows.Forms.Button btnClose;
    }
}