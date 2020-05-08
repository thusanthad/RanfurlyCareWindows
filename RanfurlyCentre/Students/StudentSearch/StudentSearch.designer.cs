namespace RanfurlyCentre
{
    partial class StudentSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.PersonId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreferredName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateOfBirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ethnicity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HomePhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MobilePhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NHINumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsResident = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpJobStatus = new System.Windows.Forms.GroupBox();
            this.rbPastStudents = new System.Windows.Forms.RadioButton();
            this.rbNonResidentStudents = new System.Windows.Forms.RadioButton();
            this.rbResidentStudents = new System.Windows.Forms.RadioButton();
            this.rbShortStayStudents = new System.Windows.Forms.RadioButton();
            this.rbAllCurrentStudents = new System.Windows.Forms.RadioButton();
            this.rbAttendsActivityCentre = new System.Windows.Forms.RadioButton();
            this.lblStudentCount = new System.Windows.Forms.Label();
            this.cmbLocation = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.grpJobStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 59F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1312, 621);
            this.tableLayoutPanel1.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.NavajoWhite;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1312, 59);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(49, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Students && Residents";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.43798F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.56202F));
            this.tableLayoutPanel2.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 62);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1306, 556);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PersonId,
            this.FirstName,
            this.LastName,
            this.PreferredName,
            this.DateOfBirth,
            this.Gender,
            this.Ethnicity,
            this.Location,
            this.HomePhone,
            this.MobilePhone,
            this.NHINumber,
            this.IsResident});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 63);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1149, 490);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dataGridView1.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseDoubleClick_1);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint_1);
            // 
            // PersonId
            // 
            this.PersonId.DataPropertyName = "PersonId";
            this.PersonId.FillWeight = 40F;
            this.PersonId.HeaderText = "Student Id";
            this.PersonId.Name = "PersonId";
            this.PersonId.ReadOnly = true;
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.FillWeight = 59.03165F;
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "LastName";
            this.LastName.FillWeight = 59.03165F;
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            // 
            // PreferredName
            // 
            this.PreferredName.DataPropertyName = "PreferredName";
            this.PreferredName.FillWeight = 59.03165F;
            this.PreferredName.HeaderText = "Preferred Name";
            this.PreferredName.Name = "PreferredName";
            this.PreferredName.ReadOnly = true;
            // 
            // DateOfBirth
            // 
            this.DateOfBirth.DataPropertyName = "DateOfBirth";
            dataGridViewCellStyle13.Format = "D";
            dataGridViewCellStyle13.NullValue = null;
            this.DateOfBirth.DefaultCellStyle = dataGridViewCellStyle13;
            this.DateOfBirth.FillWeight = 68.32618F;
            this.DateOfBirth.HeaderText = "Date of Birth";
            this.DateOfBirth.Name = "DateOfBirth";
            this.DateOfBirth.ReadOnly = true;
            // 
            // Gender
            // 
            this.Gender.DataPropertyName = "Gender";
            this.Gender.FillWeight = 59.03165F;
            this.Gender.HeaderText = "Gender";
            this.Gender.Name = "Gender";
            this.Gender.ReadOnly = true;
            // 
            // Ethnicity
            // 
            this.Ethnicity.DataPropertyName = "Ethnicity";
            this.Ethnicity.FillWeight = 59.03165F;
            this.Ethnicity.HeaderText = "Ethnicity";
            this.Ethnicity.Name = "Ethnicity";
            this.Ethnicity.ReadOnly = true;
            // 
            // Location
            // 
            this.Location.DataPropertyName = "LocationName";
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            // 
            // HomePhone
            // 
            this.HomePhone.DataPropertyName = "HomePhone";
            dataGridViewCellStyle14.Format = "d";
            dataGridViewCellStyle14.NullValue = null;
            this.HomePhone.DefaultCellStyle = dataGridViewCellStyle14;
            this.HomePhone.FillWeight = 59.03165F;
            this.HomePhone.HeaderText = "Home Phone";
            this.HomePhone.Name = "HomePhone";
            this.HomePhone.ReadOnly = true;
            // 
            // MobilePhone
            // 
            this.MobilePhone.DataPropertyName = "MobilePhone";
            this.MobilePhone.FillWeight = 59.03165F;
            this.MobilePhone.HeaderText = "Mobile Phone";
            this.MobilePhone.Name = "MobilePhone";
            this.MobilePhone.ReadOnly = true;
            // 
            // NHINumber
            // 
            this.NHINumber.DataPropertyName = "NHINumber";
            this.NHINumber.FillWeight = 84.73031F;
            this.NHINumber.HeaderText = "NHI Number";
            this.NHINumber.Name = "NHINumber";
            this.NHINumber.ReadOnly = true;
            // 
            // IsResident
            // 
            this.IsResident.DataPropertyName = "IsResident";
            this.IsResident.FillWeight = 59.03165F;
            this.IsResident.HeaderText = "Is Resident";
            this.IsResident.Name = "IsResident";
            this.IsResident.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewStudentToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(182, 40);
            // 
            // addNewStudentToolStripMenuItem
            // 
            this.addNewStudentToolStripMenuItem.Image = global::RanfurlyCentre.Properties.Resources.AddStudent;
            this.addNewStudentToolStripMenuItem.Name = "addNewStudentToolStripMenuItem";
            this.addNewStudentToolStripMenuItem.Size = new System.Drawing.Size(181, 36);
            this.addNewStudentToolStripMenuItem.Text = "Add New Student";
            this.addNewStudentToolStripMenuItem.Click += new System.EventHandler(this.addNewStudentToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExport);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnSearch);
            this.panel2.Controls.Add(this.txtSearch);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1149, 54);
            this.panel2.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.ForeColor = System.Drawing.Color.Maroon;
            this.btnExport.Location = new System.Drawing.Point(648, 8);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(113, 41);
            this.btnExport.TabIndex = 19;
            this.btnExport.Text = "Export List";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Student Name:";
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.ForeColor = System.Drawing.Color.Red;
            this.btnClear.Location = new System.Drawing.Point(545, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(97, 41);
            this.btnClear.TabIndex = 15;
            this.btnClear.Text = "Clear Filter";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
            // 
            // btnSearch
            // 
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.Location = new System.Drawing.Point(444, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(95, 41);
            this.btnSearch.TabIndex = 14;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click_1);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(146, 17);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(204, 20);
            this.txtSearch.TabIndex = 12;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-75, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Student Name:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(1158, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(145, 54);
            this.panel3.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(28, 8);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 40);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click_1);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.cmbLocation);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.grpJobStatus);
            this.panel4.Controls.Add(this.lblStudentCount);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1158, 63);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(145, 490);
            this.panel4.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(10, 370);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Add New Student";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(10, 347);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 12;
            this.label4.Text = "Right Click to";
            // 
            // grpJobStatus
            // 
            this.grpJobStatus.Controls.Add(this.rbPastStudents);
            this.grpJobStatus.Controls.Add(this.rbNonResidentStudents);
            this.grpJobStatus.Controls.Add(this.rbResidentStudents);
            this.grpJobStatus.Controls.Add(this.rbShortStayStudents);
            this.grpJobStatus.Controls.Add(this.rbAllCurrentStudents);
            this.grpJobStatus.Controls.Add(this.rbAttendsActivityCentre);
            this.grpJobStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.grpJobStatus.Location = new System.Drawing.Point(7, 3);
            this.grpJobStatus.Name = "grpJobStatus";
            this.grpJobStatus.Size = new System.Drawing.Size(145, 162);
            this.grpJobStatus.TabIndex = 10;
            this.grpJobStatus.TabStop = false;
            this.grpJobStatus.Text = "Student Type";
            // 
            // rbPastStudents
            // 
            this.rbPastStudents.AutoSize = true;
            this.rbPastStudents.Location = new System.Drawing.Point(6, 134);
            this.rbPastStudents.Name = "rbPastStudents";
            this.rbPastStudents.Size = new System.Drawing.Size(91, 17);
            this.rbPastStudents.TabIndex = 13;
            this.rbPastStudents.Text = "Past Students";
            this.rbPastStudents.UseVisualStyleBackColor = true;
            this.rbPastStudents.CheckedChanged += new System.EventHandler(this.rbPastStudents_CheckedChanged);
            // 
            // rbNonResidentStudents
            // 
            this.rbNonResidentStudents.AutoSize = true;
            this.rbNonResidentStudents.Location = new System.Drawing.Point(6, 65);
            this.rbNonResidentStudents.Name = "rbNonResidentStudents";
            this.rbNonResidentStudents.Size = new System.Drawing.Size(135, 17);
            this.rbNonResidentStudents.TabIndex = 2;
            this.rbNonResidentStudents.Text = "Non-Resident Students";
            this.rbNonResidentStudents.UseVisualStyleBackColor = true;
            this.rbNonResidentStudents.CheckedChanged += new System.EventHandler(this.rbANonResidentStudents_CheckedChanged);
            // 
            // rbResidentStudents
            // 
            this.rbResidentStudents.AutoSize = true;
            this.rbResidentStudents.Location = new System.Drawing.Point(6, 42);
            this.rbResidentStudents.Name = "rbResidentStudents";
            this.rbResidentStudents.Size = new System.Drawing.Size(112, 17);
            this.rbResidentStudents.TabIndex = 1;
            this.rbResidentStudents.Text = "Resident Students";
            this.rbResidentStudents.UseVisualStyleBackColor = true;
            this.rbResidentStudents.CheckedChanged += new System.EventHandler(this.rbResidentStudents_CheckedChanged);
            // 
            // rbShortStayStudents
            // 
            this.rbShortStayStudents.AutoSize = true;
            this.rbShortStayStudents.Location = new System.Drawing.Point(6, 111);
            this.rbShortStayStudents.Name = "rbShortStayStudents";
            this.rbShortStayStudents.Size = new System.Drawing.Size(119, 17);
            this.rbShortStayStudents.TabIndex = 12;
            this.rbShortStayStudents.Text = "Short Stay Students";
            this.rbShortStayStudents.UseVisualStyleBackColor = true;
            this.rbShortStayStudents.CheckedChanged += new System.EventHandler(this.rbShortStayStudents_CheckedChanged);
            // 
            // rbAllCurrentStudents
            // 
            this.rbAllCurrentStudents.AutoSize = true;
            this.rbAllCurrentStudents.Checked = true;
            this.rbAllCurrentStudents.Location = new System.Drawing.Point(6, 19);
            this.rbAllCurrentStudents.Name = "rbAllCurrentStudents";
            this.rbAllCurrentStudents.Size = new System.Drawing.Size(118, 17);
            this.rbAllCurrentStudents.TabIndex = 0;
            this.rbAllCurrentStudents.TabStop = true;
            this.rbAllCurrentStudents.Text = "All Current Students";
            this.rbAllCurrentStudents.UseVisualStyleBackColor = true;
            this.rbAllCurrentStudents.CheckedChanged += new System.EventHandler(this.rbAllCurrentStudents_CheckedChanged);
            // 
            // rbAttendsActivityCentre
            // 
            this.rbAttendsActivityCentre.AutoSize = true;
            this.rbAttendsActivityCentre.Location = new System.Drawing.Point(6, 88);
            this.rbAttendsActivityCentre.Name = "rbAttendsActivityCentre";
            this.rbAttendsActivityCentre.Size = new System.Drawing.Size(132, 17);
            this.rbAttendsActivityCentre.TabIndex = 3;
            this.rbAttendsActivityCentre.Text = "Attends Activity Centre";
            this.rbAttendsActivityCentre.UseVisualStyleBackColor = true;
            this.rbAttendsActivityCentre.CheckedChanged += new System.EventHandler(this.rbAttendsActivityCentre_CheckedChanged);
            // 
            // lblStudentCount
            // 
            this.lblStudentCount.AutoSize = true;
            this.lblStudentCount.Location = new System.Drawing.Point(3, 236);
            this.lblStudentCount.Name = "lblStudentCount";
            this.lblStudentCount.Size = new System.Drawing.Size(78, 13);
            this.lblStudentCount.TabIndex = 11;
            this.lblStudentCount.Text = "Student Count:";
            // 
            // cmbLocation
            // 
            this.cmbLocation.FormattingEnabled = true;
            this.cmbLocation.Location = new System.Drawing.Point(3, 184);
            this.cmbLocation.Name = "cmbLocation";
            this.cmbLocation.Size = new System.Drawing.Size(136, 21);
            this.cmbLocation.TabIndex = 14;
            this.cmbLocation.Visible = false;
            this.cmbLocation.SelectedIndexChanged += new System.EventHandler(this.cmbLocation_SelectedIndexChanged);
            // 
            // StudentSearch
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 621);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "StudentSearch";
            this.Text = "Students";
            this.Load += new System.EventHandler(this.JobSearch_Load);
            this.Shown += new System.EventHandler(this.StudentSearch_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.grpJobStatus.ResumeLayout(false);
            this.grpJobStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider ep;
        //private System.Windows.Forms.Label lblStudentCount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox grpJobStatus;
        private System.Windows.Forms.RadioButton rbResidentStudents;
        private System.Windows.Forms.RadioButton rbAllCurrentStudents;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblStudentCount;
        private System.Windows.Forms.RadioButton rbNonResidentStudents;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.RadioButton rbPastStudents;
        private System.Windows.Forms.RadioButton rbShortStayStudents;
        private System.Windows.Forms.RadioButton rbAttendsActivityCentre;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewStudentToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PreferredName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateOfBirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn Gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ethnicity;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn HomePhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn MobilePhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn NHINumber;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsResident;
        public System.Windows.Forms.ComboBox cmbLocation;
    }
}