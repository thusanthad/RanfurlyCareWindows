namespace RanfurlyCentre
{
    partial class ProfessionalServicesSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgProfessionalServices = new System.Windows.Forms.DataGridView();
            this.PersonId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Addr1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Addr2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Addr3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Addr4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Postcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewDoctorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExportFile = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbOtherSpecialist = new System.Windows.Forms.RadioButton();
            this.rbAudiologist = new System.Windows.Forms.RadioButton();
            this.rbPodatrists = new System.Windows.Forms.RadioButton();
            this.rbOpticians = new System.Windows.Forms.RadioButton();
            this.rbDentists = new System.Windows.Forms.RadioButton();
            this.rbAll = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblStudentCount = new System.Windows.Forms.Label();
            this.rbSurgeon = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgProfessionalServices)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
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
            this.panel1.Size = new System.Drawing.Size(1312, 58);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(49, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Professional Services";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.43798F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.56202F));
            this.tableLayoutPanel2.Controls.Add(this.dgProfessionalServices, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel4, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 61);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1306, 557);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // dgProfessionalServices
            // 
            this.dgProfessionalServices.AllowUserToAddRows = false;
            this.dgProfessionalServices.AllowUserToDeleteRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Control;
            this.dgProfessionalServices.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgProfessionalServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgProfessionalServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProfessionalServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PersonId,
            this.FullName,
            this.Addr1,
            this.Addr2,
            this.Addr3,
            this.Addr4,
            this.Postcode,
            this.Phone,
            this.PersonType});
            this.dgProfessionalServices.ContextMenuStrip = this.contextMenuStrip1;
            this.dgProfessionalServices.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgProfessionalServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgProfessionalServices.Location = new System.Drawing.Point(3, 63);
            this.dgProfessionalServices.Name = "dgProfessionalServices";
            this.dgProfessionalServices.ReadOnly = true;
            this.dgProfessionalServices.Size = new System.Drawing.Size(1149, 491);
            this.dgProfessionalServices.TabIndex = 7;
            this.dgProfessionalServices.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_ColumnHeaderMouseClick);
            this.dgProfessionalServices.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_RowHeaderMouseDoubleClick_1);
            // 
            // PersonId
            // 
            this.PersonId.DataPropertyName = "PersonId";
            this.PersonId.HeaderText = "PersonId";
            this.PersonId.Name = "PersonId";
            this.PersonId.ReadOnly = true;
            this.PersonId.Visible = false;
            // 
            // FullName
            // 
            this.FullName.DataPropertyName = "FullName";
            this.FullName.FillWeight = 50F;
            this.FullName.HeaderText = "Full Name";
            this.FullName.Name = "FullName";
            this.FullName.ReadOnly = true;
            // 
            // Addr1
            // 
            this.Addr1.DataPropertyName = "Addr1";
            this.Addr1.FillWeight = 50F;
            this.Addr1.HeaderText = "Addr1";
            this.Addr1.Name = "Addr1";
            this.Addr1.ReadOnly = true;
            // 
            // Addr2
            // 
            this.Addr2.DataPropertyName = "Addr2";
            this.Addr2.FillWeight = 50F;
            this.Addr2.HeaderText = "Addr2";
            this.Addr2.Name = "Addr2";
            this.Addr2.ReadOnly = true;
            // 
            // Addr3
            // 
            this.Addr3.DataPropertyName = "Addr3";
            this.Addr3.FillWeight = 40F;
            this.Addr3.HeaderText = "Addr3";
            this.Addr3.Name = "Addr3";
            this.Addr3.ReadOnly = true;
            // 
            // Addr4
            // 
            this.Addr4.DataPropertyName = "Addr4";
            this.Addr4.FillWeight = 40F;
            this.Addr4.HeaderText = "Addr4";
            this.Addr4.Name = "Addr4";
            this.Addr4.ReadOnly = true;
            // 
            // Postcode
            // 
            this.Postcode.DataPropertyName = "Postcode";
            this.Postcode.FillWeight = 20F;
            this.Postcode.HeaderText = "Postcode";
            this.Postcode.Name = "Postcode";
            this.Postcode.ReadOnly = true;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.FillWeight = 30F;
            this.Phone.HeaderText = "Phone";
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // PersonType
            // 
            this.PersonType.DataPropertyName = "SpecialistType";
            this.PersonType.FillWeight = 30F;
            this.PersonType.HeaderText = "Specialist Type";
            this.PersonType.Name = "PersonType";
            this.PersonType.ReadOnly = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewDoctorToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(292, 40);
            // 
            // addNewDoctorToolStripMenuItem
            // 
            this.addNewDoctorToolStripMenuItem.Image = global::RanfurlyCentre.Properties.Resources.AddDoctor11;
            this.addNewDoctorToolStripMenuItem.Name = "addNewDoctorToolStripMenuItem";
            this.addNewDoctorToolStripMenuItem.Size = new System.Drawing.Size(291, 36);
            this.addNewDoctorToolStripMenuItem.Text = "Add New Professional Service Provider";
            this.addNewDoctorToolStripMenuItem.Click += new System.EventHandler(this.addNewDoctorToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnExportFile);
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
            // btnExportFile
            // 
            this.btnExportFile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExportFile.ForeColor = System.Drawing.Color.Maroon;
            this.btnExportFile.Location = new System.Drawing.Point(626, 7);
            this.btnExportFile.Name = "btnExportFile";
            this.btnExportFile.Size = new System.Drawing.Size(98, 41);
            this.btnExportFile.TabIndex = 20;
            this.btnExportFile.Text = "Export List";
            this.btnExportFile.UseVisualStyleBackColor = true;
            this.btnExportFile.Click += new System.EventHandler(this.btnExportFile_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Professional Name:";
            // 
            // btnClear
            // 
            this.btnClear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClear.ForeColor = System.Drawing.Color.Red;
            this.btnClear.Location = new System.Drawing.Point(535, 6);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(85, 41);
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
            this.btnSearch.Size = new System.Drawing.Size(85, 41);
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
            this.panel4.Controls.Add(this.groupBox1);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Controls.Add(this.lblStudentCount);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(1158, 63);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(145, 491);
            this.panel4.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbOtherSpecialist);
            this.groupBox1.Controls.Add(this.rbAudiologist);
            this.groupBox1.Controls.Add(this.rbSurgeon);
            this.groupBox1.Controls.Add(this.rbPodatrists);
            this.groupBox1.Controls.Add(this.rbOpticians);
            this.groupBox1.Controls.Add(this.rbDentists);
            this.groupBox1.Controls.Add(this.rbAll);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupBox1.Location = new System.Drawing.Point(6, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(133, 263);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Professional Type";
            // 
            // rbOtherSpecialist
            // 
            this.rbOtherSpecialist.AutoSize = true;
            this.rbOtherSpecialist.Location = new System.Drawing.Point(6, 169);
            this.rbOtherSpecialist.Name = "rbOtherSpecialist";
            this.rbOtherSpecialist.Size = new System.Drawing.Size(104, 17);
            this.rbOtherSpecialist.TabIndex = 5;
            this.rbOtherSpecialist.Text = "Other Specialists";
            this.rbOtherSpecialist.UseVisualStyleBackColor = true;
            this.rbOtherSpecialist.CheckedChanged += new System.EventHandler(this.rbOtherSpecialist_CheckedChanged);
            // 
            // rbAudiologist
            // 
            this.rbAudiologist.AutoSize = true;
            this.rbAudiologist.Location = new System.Drawing.Point(6, 121);
            this.rbAudiologist.Name = "rbAudiologist";
            this.rbAudiologist.Size = new System.Drawing.Size(76, 17);
            this.rbAudiologist.TabIndex = 4;
            this.rbAudiologist.Text = "Audiologist";
            this.rbAudiologist.UseVisualStyleBackColor = true;
            this.rbAudiologist.CheckedChanged += new System.EventHandler(this.rbAudiologist_CheckedChanged);
            // 
            // rbPodatrists
            // 
            this.rbPodatrists.AutoSize = true;
            this.rbPodatrists.Location = new System.Drawing.Point(6, 98);
            this.rbPodatrists.Name = "rbPodatrists";
            this.rbPodatrists.Size = new System.Drawing.Size(71, 17);
            this.rbPodatrists.TabIndex = 3;
            this.rbPodatrists.Text = "Podatrists";
            this.rbPodatrists.UseVisualStyleBackColor = true;
            this.rbPodatrists.CheckedChanged += new System.EventHandler(this.rbPodatrists_CheckedChanged);
            // 
            // rbOpticians
            // 
            this.rbOpticians.AutoSize = true;
            this.rbOpticians.Location = new System.Drawing.Point(6, 75);
            this.rbOpticians.Name = "rbOpticians";
            this.rbOpticians.Size = new System.Drawing.Size(69, 17);
            this.rbOpticians.TabIndex = 2;
            this.rbOpticians.Text = "Opticians";
            this.rbOpticians.UseVisualStyleBackColor = true;
            this.rbOpticians.CheckedChanged += new System.EventHandler(this.rbOpticians_CheckedChanged);
            // 
            // rbDentists
            // 
            this.rbDentists.AutoSize = true;
            this.rbDentists.Location = new System.Drawing.Point(6, 52);
            this.rbDentists.Name = "rbDentists";
            this.rbDentists.Size = new System.Drawing.Size(63, 17);
            this.rbDentists.TabIndex = 1;
            this.rbDentists.Text = "Dentists";
            this.rbDentists.UseVisualStyleBackColor = true;
            this.rbDentists.CheckedChanged += new System.EventHandler(this.rbDentists_CheckedChanged);
            // 
            // rbAll
            // 
            this.rbAll.AutoSize = true;
            this.rbAll.Checked = true;
            this.rbAll.Location = new System.Drawing.Point(6, 29);
            this.rbAll.Name = "rbAll";
            this.rbAll.Size = new System.Drawing.Size(36, 17);
            this.rbAll.TabIndex = 0;
            this.rbAll.TabStop = true;
            this.rbAll.Text = "All";
            this.rbAll.UseVisualStyleBackColor = true;
            this.rbAll.CheckedChanged += new System.EventHandler(this.rbAll_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(6, 384);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "Add New Professional";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(6, 361);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Right Click to";
            // 
            // lblStudentCount
            // 
            this.lblStudentCount.AutoSize = true;
            this.lblStudentCount.Location = new System.Drawing.Point(6, 308);
            this.lblStudentCount.Name = "lblStudentCount";
            this.lblStudentCount.Size = new System.Drawing.Size(98, 13);
            this.lblStudentCount.TabIndex = 11;
            this.lblStudentCount.Text = "Professional Count:";
            // 
            // rbSurgeon
            // 
            this.rbSurgeon.AutoSize = true;
            this.rbSurgeon.Location = new System.Drawing.Point(6, 146);
            this.rbSurgeon.Name = "rbSurgeon";
            this.rbSurgeon.Size = new System.Drawing.Size(70, 17);
            this.rbSurgeon.TabIndex = 6;
            this.rbSurgeon.Text = "Surgeons";
            this.rbSurgeon.UseVisualStyleBackColor = true;
            this.rbSurgeon.CheckedChanged += new System.EventHandler(this.rbSurgeon_CheckedChanged);
            // 
            // ProfessionalServicesSearch
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 621);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ProfessionalServicesSearch";
            this.Text = "Professiona Services";
            this.Load += new System.EventHandler(this.JobSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgProfessionalServices)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ErrorProvider ep;
        //private System.Windows.Forms.Label lblStudentCount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgProfessionalServices;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblStudentCount;
        private System.Windows.Forms.Button btnExportFile;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNewDoctorToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbPodatrists;
        private System.Windows.Forms.RadioButton rbOpticians;
        private System.Windows.Forms.RadioButton rbDentists;
        private System.Windows.Forms.RadioButton rbAll;
        private System.Windows.Forms.RadioButton rbOtherSpecialist;
        private System.Windows.Forms.RadioButton rbAudiologist;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Addr1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Addr2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Addr3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Addr4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Postcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonType;
        private System.Windows.Forms.RadioButton rbSurgeon;
    }
}