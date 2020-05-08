namespace RanfurlyCentre
{
    partial class AppointmentSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgAppointment = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewStudentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteAppintmentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.lblTo = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.grpJobStatus = new System.Windows.Forms.GroupBox();
            this.rbPastAppointments = new System.Windows.Forms.RadioButton();
            this.rbAppointmentsPendingClosure = new System.Windows.Forms.RadioButton();
            this.rbAllActiveAppointment = new System.Windows.Forms.RadioButton();
            this.lblAppointmentCount = new System.Windows.Forms.Label();
            this.AppointmentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppointmentDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppointmentTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AppointmentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Purpose = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResidentDisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffDisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpecialistDisplayName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceProviderAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsInHouseAppointment = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAppointment)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(146, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Appointments";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82.38898F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.61103F));
            this.tableLayoutPanel2.Controls.Add(this.dgAppointment, 0, 1);
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
            // dgAppointment
            // 
            this.dgAppointment.AllowUserToAddRows = false;
            this.dgAppointment.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgAppointment.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgAppointment.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgAppointment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAppointment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.AppointmentId,
            this.AppointmentDate,
            this.AppointmentTime,
            this.AppointmentType,
            this.Purpose,
            this.ResidentDisplayName,
            this.StaffDisplayName,
            this.SpecialistDisplayName,
            this.ServiceProviderAddress,
            this.Telephone,
            this.IsInHouseAppointment});
            this.dgAppointment.ContextMenuStrip = this.contextMenuStrip1;
            this.dgAppointment.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgAppointment.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgAppointment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgAppointment.Location = new System.Drawing.Point(3, 63);
            this.dgAppointment.Name = "dgAppointment";
            this.dgAppointment.ReadOnly = true;
            this.dgAppointment.Size = new System.Drawing.Size(1069, 490);
            this.dgAppointment.TabIndex = 7;
            this.dgAppointment.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dgAppointment.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseDoubleClick_1);
            this.dgAppointment.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint_1);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewStudentToolStripMenuItem,
            this.deleteAppintmentToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(212, 76);
            // 
            // addNewStudentToolStripMenuItem
            // 
            this.addNewStudentToolStripMenuItem.Image = global::RanfurlyCentre.Properties.Resources.addappointment;
            this.addNewStudentToolStripMenuItem.Name = "addNewStudentToolStripMenuItem";
            this.addNewStudentToolStripMenuItem.Size = new System.Drawing.Size(211, 36);
            this.addNewStudentToolStripMenuItem.Text = "Add New Appointment";
            this.addNewStudentToolStripMenuItem.Click += new System.EventHandler(this.addNewStudentToolStripMenuItem_Click);
            // 
            // deleteAppintmentToolStripMenuItem
            // 
            this.deleteAppintmentToolStripMenuItem.Image = global::RanfurlyCentre.Properties.Resources.RemoveDoctor;
            this.deleteAppintmentToolStripMenuItem.Name = "deleteAppintmentToolStripMenuItem";
            this.deleteAppintmentToolStripMenuItem.Size = new System.Drawing.Size(211, 36);
            this.deleteAppintmentToolStripMenuItem.Text = "Delete Appintment";
            this.deleteAppintmentToolStripMenuItem.Click += new System.EventHandler(this.deleteAppintmentToolStripMenuItem_Click);
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
            this.panel2.Size = new System.Drawing.Size(1069, 54);
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
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Search:";
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
            this.panel3.Location = new System.Drawing.Point(1078, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(225, 54);
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
            this.panel4.Controls.Add(this.lblTo);
            this.panel4.Controls.Add(this.dtpTo);
            this.panel4.Controls.Add(this.lblFrom);
            this.panel4.Controls.Add(this.dtpFrom);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.grpJobStatus);
            this.panel4.Controls.Add(this.lblAppointmentCount);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1078, 63);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(225, 490);
            this.panel4.TabIndex = 8;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(10, 165);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(23, 13);
            this.lblTo.TabIndex = 16;
            this.lblTo.Text = "To:";
            // 
            // dtpTo
            // 
            this.dtpTo.CustomFormat = "dd/MMM/yyyy";
            this.dtpTo.Location = new System.Drawing.Point(13, 181);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.ShowCheckBox = true;
            this.dtpTo.Size = new System.Drawing.Size(200, 20);
            this.dtpTo.TabIndex = 15;
            this.dtpTo.ValueChanged += new System.EventHandler(this.dtpTo_ValueChanged);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(10, 119);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(33, 13);
            this.lblFrom.TabIndex = 14;
            this.lblFrom.Text = "From:";
            // 
            // dtpFrom
            // 
            this.dtpFrom.CustomFormat = "dd/MMM/yyyy";
            this.dtpFrom.Location = new System.Drawing.Point(13, 135);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.ShowCheckBox = true;
            this.dtpFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpFrom.TabIndex = 3;
            this.dtpFrom.ValueChanged += new System.EventHandler(this.dtpFrom_ValueChanged);
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
            this.grpJobStatus.Controls.Add(this.rbPastAppointments);
            this.grpJobStatus.Controls.Add(this.rbAppointmentsPendingClosure);
            this.grpJobStatus.Controls.Add(this.rbAllActiveAppointment);
            this.grpJobStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.grpJobStatus.Location = new System.Drawing.Point(7, 3);
            this.grpJobStatus.Name = "grpJobStatus";
            this.grpJobStatus.Size = new System.Drawing.Size(195, 100);
            this.grpJobStatus.TabIndex = 10;
            this.grpJobStatus.TabStop = false;
            this.grpJobStatus.Text = "Appointment Type";
            // 
            // rbPastAppointments
            // 
            this.rbPastAppointments.AutoSize = true;
            this.rbPastAppointments.Location = new System.Drawing.Point(6, 65);
            this.rbPastAppointments.Name = "rbPastAppointments";
            this.rbPastAppointments.Size = new System.Drawing.Size(113, 17);
            this.rbPastAppointments.TabIndex = 2;
            this.rbPastAppointments.Text = "Past Appointments";
            this.rbPastAppointments.UseVisualStyleBackColor = true;
            this.rbPastAppointments.CheckedChanged += new System.EventHandler(this.rbPastAppointments_CheckedChanged);
            // 
            // rbAppointmentsPendingClosure
            // 
            this.rbAppointmentsPendingClosure.AutoSize = true;
            this.rbAppointmentsPendingClosure.Location = new System.Drawing.Point(6, 42);
            this.rbAppointmentsPendingClosure.Name = "rbAppointmentsPendingClosure";
            this.rbAppointmentsPendingClosure.Size = new System.Drawing.Size(169, 17);
            this.rbAppointmentsPendingClosure.TabIndex = 1;
            this.rbAppointmentsPendingClosure.Text = "Appointments Pending Closure";
            this.rbAppointmentsPendingClosure.UseVisualStyleBackColor = true;
            this.rbAppointmentsPendingClosure.CheckedChanged += new System.EventHandler(this.rbAppointmentsWaitingClosure_CheckedChanged);
            // 
            // rbAllActiveAppointment
            // 
            this.rbAllActiveAppointment.AutoSize = true;
            this.rbAllActiveAppointment.Checked = true;
            this.rbAllActiveAppointment.Location = new System.Drawing.Point(6, 19);
            this.rbAllActiveAppointment.Name = "rbAllActiveAppointment";
            this.rbAllActiveAppointment.Size = new System.Drawing.Size(136, 17);
            this.rbAllActiveAppointment.TabIndex = 0;
            this.rbAllActiveAppointment.TabStop = true;
            this.rbAllActiveAppointment.Text = "All Active Appointments";
            this.rbAllActiveAppointment.UseVisualStyleBackColor = true;
            this.rbAllActiveAppointment.CheckedChanged += new System.EventHandler(this.rbActiveAppointments_CheckedChanged);
            // 
            // lblAppointmentCount
            // 
            this.lblAppointmentCount.AutoSize = true;
            this.lblAppointmentCount.Location = new System.Drawing.Point(10, 258);
            this.lblAppointmentCount.Name = "lblAppointmentCount";
            this.lblAppointmentCount.Size = new System.Drawing.Size(100, 13);
            this.lblAppointmentCount.TabIndex = 11;
            this.lblAppointmentCount.Text = "Appointment Count:";
            // 
            // AppointmentId
            // 
            this.AppointmentId.DataPropertyName = "AppointmentId";
            this.AppointmentId.HeaderText = "AppointmentId";
            this.AppointmentId.Name = "AppointmentId";
            this.AppointmentId.ReadOnly = true;
            this.AppointmentId.Visible = false;
            // 
            // AppointmentDate
            // 
            this.AppointmentDate.DataPropertyName = "AppointmentDate";
            dataGridViewCellStyle2.Format = "D";
            dataGridViewCellStyle2.NullValue = null;
            this.AppointmentDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.AppointmentDate.FillWeight = 120F;
            this.AppointmentDate.HeaderText = "Date";
            this.AppointmentDate.Name = "AppointmentDate";
            this.AppointmentDate.ReadOnly = true;
            // 
            // AppointmentTime
            // 
            this.AppointmentTime.DataPropertyName = "AppointmentTime";
            this.AppointmentTime.FillWeight = 60F;
            this.AppointmentTime.HeaderText = "Time";
            this.AppointmentTime.Name = "AppointmentTime";
            this.AppointmentTime.ReadOnly = true;
            // 
            // AppointmentType
            // 
            this.AppointmentType.DataPropertyName = "AppointmentType";
            this.AppointmentType.FillWeight = 50F;
            this.AppointmentType.HeaderText = "Type";
            this.AppointmentType.Name = "AppointmentType";
            this.AppointmentType.ReadOnly = true;
            // 
            // Purpose
            // 
            this.Purpose.DataPropertyName = "Purpose";
            this.Purpose.HeaderText = "Purpose";
            this.Purpose.Name = "Purpose";
            this.Purpose.ReadOnly = true;
            // 
            // ResidentDisplayName
            // 
            this.ResidentDisplayName.DataPropertyName = "ResidentDisplayName";
            this.ResidentDisplayName.HeaderText = "Resident Name";
            this.ResidentDisplayName.Name = "ResidentDisplayName";
            this.ResidentDisplayName.ReadOnly = true;
            // 
            // StaffDisplayName
            // 
            this.StaffDisplayName.DataPropertyName = "StaffDisplayName";
            this.StaffDisplayName.HeaderText = "Staff Accompanying";
            this.StaffDisplayName.Name = "StaffDisplayName";
            this.StaffDisplayName.ReadOnly = true;
            // 
            // SpecialistDisplayName
            // 
            this.SpecialistDisplayName.DataPropertyName = "SpecialistDisplayName";
            this.SpecialistDisplayName.HeaderText = "Service Provider";
            this.SpecialistDisplayName.Name = "SpecialistDisplayName";
            this.SpecialistDisplayName.ReadOnly = true;
            // 
            // ServiceProviderAddress
            // 
            this.ServiceProviderAddress.DataPropertyName = "ServiceProviderAddress";
            this.ServiceProviderAddress.FillWeight = 150F;
            this.ServiceProviderAddress.HeaderText = "Address";
            this.ServiceProviderAddress.Name = "ServiceProviderAddress";
            this.ServiceProviderAddress.ReadOnly = true;
            // 
            // Telephone
            // 
            this.Telephone.DataPropertyName = "ServiceProviderTelephone";
            this.Telephone.HeaderText = "Telephone";
            this.Telephone.Name = "Telephone";
            this.Telephone.ReadOnly = true;
            // 
            // IsInHouseAppointment
            // 
            this.IsInHouseAppointment.DataPropertyName = "IsInHouseAppointment";
            this.IsInHouseAppointment.FillWeight = 50F;
            this.IsInHouseAppointment.HeaderText = "In House";
            this.IsInHouseAppointment.Name = "IsInHouseAppointment";
            this.IsInHouseAppointment.ReadOnly = true;
            // 
            // AppointmentSearch
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 621);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "AppointmentSearch";
            this.Text = "Appointments";
            this.Load += new System.EventHandler(this.JobSearch_Load);
            this.Shown += new System.EventHandler(this.StudentSearch_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAppointment)).EndInit();
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
        private System.Windows.Forms.GroupBox grpJobStatus;
        private System.Windows.Forms.RadioButton rbAppointmentsPendingClosure;
        private System.Windows.Forms.RadioButton rbAllActiveAppointment;
        private System.Windows.Forms.Panel panel4;
        public System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        public System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewStudentToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem deleteAppintmentToolStripMenuItem;
        private System.Windows.Forms.RadioButton rbPastAppointments;
        public System.Windows.Forms.Label lblTo;
        public System.Windows.Forms.DateTimePicker dtpTo;
        public System.Windows.Forms.Label lblFrom;
        public System.Windows.Forms.DateTimePicker dtpFrom;
        public System.Windows.Forms.DataGridView dgAppointment;
        public System.Windows.Forms.Label lblAppointmentCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppointmentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppointmentDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppointmentTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn AppointmentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Purpose;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResidentDisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffDisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpecialistDisplayName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceProviderAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telephone;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsInHouseAppointment;
    }
}