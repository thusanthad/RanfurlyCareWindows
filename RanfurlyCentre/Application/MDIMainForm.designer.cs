namespace RanfurlyCentre
{
    partial class MDIMainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIMainForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsStudent = new System.Windows.Forms.ToolStripMenuItem();
            this.tsStaff = new System.Windows.Forms.ToolStripMenuItem();
            this.doctorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doctorsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.otherProfessionalServiceProvidersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageRollCallsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rollCallsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importRollCallToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeImportedFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.incidentsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.appointmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.jobsReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.adminChangePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.maintenanceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addWorkCentreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ethnicityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBackup = new System.Windows.Forms.ToolStripMenuItem();
            this.windowsMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.newWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tileHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrangeIconsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.AutoSize = false;
            this.menuStrip.BackColor = System.Drawing.SystemColors.MenuBar;
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(35, 35);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsStudent,
            this.tsStaff,
            this.doctorsToolStripMenuItem,
            this.manageRollCallsToolStripMenuItem,
            this.incidentsToolStripMenuItem1,
            this.appointmentsToolStripMenuItem,
            this.jobsReportToolStripMenuItem,
            this.systemUserToolStripMenuItem,
            this.maintenanceToolStripMenuItem,
            this.windowsMenu,
            this.aboutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.MdiWindowListItem = this.windowsMenu;
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(1317, 45);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            this.menuStrip.MouseEnter += new System.EventHandler(this.menuStrip_MouseEnter);
            // 
            // tsStudent
            // 
            this.tsStudent.Image = ((System.Drawing.Image)(resources.GetObject("tsStudent.Image")));
            this.tsStudent.Name = "tsStudent";
            this.tsStudent.Size = new System.Drawing.Size(100, 41);
            this.tsStudent.Text = "Students";
            this.tsStudent.Click += new System.EventHandler(this.tsStudent_Click);
            // 
            // tsStaff
            // 
            this.tsStaff.Image = ((System.Drawing.Image)(resources.GetObject("tsStaff.Image")));
            this.tsStaff.Name = "tsStaff";
            this.tsStaff.Size = new System.Drawing.Size(78, 41);
            this.tsStaff.Text = "Staff";
            this.tsStaff.Click += new System.EventHandler(this.tsStaff_Click);
            // 
            // doctorsToolStripMenuItem
            // 
            this.doctorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.doctorsToolStripMenuItem1,
            this.otherProfessionalServiceProvidersToolStripMenuItem});
            this.doctorsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("doctorsToolStripMenuItem.Image")));
            this.doctorsToolStripMenuItem.Name = "doctorsToolStripMenuItem";
            this.doctorsToolStripMenuItem.Size = new System.Drawing.Size(141, 41);
            this.doctorsToolStripMenuItem.Text = "Medical Services";
            this.doctorsToolStripMenuItem.Click += new System.EventHandler(this.doctorListToolStripMenuItem_Click);
            // 
            // doctorsToolStripMenuItem1
            // 
            this.doctorsToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("doctorsToolStripMenuItem1.Image")));
            this.doctorsToolStripMenuItem1.Name = "doctorsToolStripMenuItem1";
            this.doctorsToolStripMenuItem1.Size = new System.Drawing.Size(216, 22);
            this.doctorsToolStripMenuItem1.Text = "Doctors";
            this.doctorsToolStripMenuItem1.Click += new System.EventHandler(this.doctorsToolStripMenuItem1_Click);
            // 
            // otherProfessionalServiceProvidersToolStripMenuItem
            // 
            this.otherProfessionalServiceProvidersToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("otherProfessionalServiceProvidersToolStripMenuItem.Image")));
            this.otherProfessionalServiceProvidersToolStripMenuItem.Name = "otherProfessionalServiceProvidersToolStripMenuItem";
            this.otherProfessionalServiceProvidersToolStripMenuItem.Size = new System.Drawing.Size(216, 22);
            this.otherProfessionalServiceProvidersToolStripMenuItem.Text = "Other Professional Services";
            this.otherProfessionalServiceProvidersToolStripMenuItem.Click += new System.EventHandler(this.otherProfessionalServiceProvidersToolStripMenuItem_Click);
            // 
            // manageRollCallsToolStripMenuItem
            // 
            this.manageRollCallsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rollCallsToolStripMenuItem,
            this.importRollCallToolStripMenuItem,
            this.removeImportedFileToolStripMenuItem});
            this.manageRollCallsToolStripMenuItem.Image = global::RanfurlyCentre.Properties.Resources.rollcall;
            this.manageRollCallsToolStripMenuItem.Name = "manageRollCallsToolStripMenuItem";
            this.manageRollCallsToolStripMenuItem.Size = new System.Drawing.Size(148, 41);
            this.manageRollCallsToolStripMenuItem.Text = "Manage Roll Calls";
            // 
            // rollCallsToolStripMenuItem
            // 
            this.rollCallsToolStripMenuItem.Image = global::RanfurlyCentre.Properties.Resources.rollcall1;
            this.rollCallsToolStripMenuItem.Name = "rollCallsToolStripMenuItem";
            this.rollCallsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.rollCallsToolStripMenuItem.Text = "Roll Calls";
            this.rollCallsToolStripMenuItem.Click += new System.EventHandler(this.rollCallsToolStripMenuItem_Click);
            // 
            // importRollCallToolStripMenuItem
            // 
            this.importRollCallToolStripMenuItem.Image = global::RanfurlyCentre.Properties.Resources.importrollcall1;
            this.importRollCallToolStripMenuItem.Name = "importRollCallToolStripMenuItem";
            this.importRollCallToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.importRollCallToolStripMenuItem.Text = "Import Roll Call";
            this.importRollCallToolStripMenuItem.Click += new System.EventHandler(this.importRollCallToolStripMenuItem_Click);
            // 
            // removeImportedFileToolStripMenuItem
            // 
            this.removeImportedFileToolStripMenuItem.Image = global::RanfurlyCentre.Properties.Resources.RemoveDoctor;
            this.removeImportedFileToolStripMenuItem.Name = "removeImportedFileToolStripMenuItem";
            this.removeImportedFileToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.removeImportedFileToolStripMenuItem.Text = "Remove Imported File";
            this.removeImportedFileToolStripMenuItem.Click += new System.EventHandler(this.removeImportedFileToolStripMenuItem_Click);
            // 
            // incidentsToolStripMenuItem1
            // 
            this.incidentsToolStripMenuItem1.Image = global::RanfurlyCentre.Properties.Resources.incident1;
            this.incidentsToolStripMenuItem1.Name = "incidentsToolStripMenuItem1";
            this.incidentsToolStripMenuItem1.Size = new System.Drawing.Size(102, 41);
            this.incidentsToolStripMenuItem1.Text = "Incidents";
            this.incidentsToolStripMenuItem1.Click += new System.EventHandler(this.incidentsToolStripMenuItem1_Click);
            // 
            // appointmentsToolStripMenuItem
            // 
            this.appointmentsToolStripMenuItem.Image = global::RanfurlyCentre.Properties.Resources.appointments1;
            this.appointmentsToolStripMenuItem.Name = "appointmentsToolStripMenuItem";
            this.appointmentsToolStripMenuItem.Size = new System.Drawing.Size(130, 41);
            this.appointmentsToolStripMenuItem.Text = "Appointments";
            this.appointmentsToolStripMenuItem.Click += new System.EventHandler(this.appointmentsToolStripMenuItem_Click);
            // 
            // jobsReportToolStripMenuItem
            // 
            this.jobsReportToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("jobsReportToolStripMenuItem.Image")));
            this.jobsReportToolStripMenuItem.Name = "jobsReportToolStripMenuItem";
            this.jobsReportToolStripMenuItem.Size = new System.Drawing.Size(94, 41);
            this.jobsReportToolStripMenuItem.Text = "Reports";
            this.jobsReportToolStripMenuItem.Click += new System.EventHandler(this.jobsReportToolStripMenuItem_Click);
            // 
            // systemUserToolStripMenuItem
            // 
            this.systemUserToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewUserToolStripMenuItem,
            this.changePasswordToolStripMenuItem1,
            this.adminChangePasswordToolStripMenuItem});
            this.systemUserToolStripMenuItem.Image = global::RanfurlyCentre.Properties.Resources.systemusers2;
            this.systemUserToolStripMenuItem.Name = "systemUserToolStripMenuItem";
            this.systemUserToolStripMenuItem.Size = new System.Drawing.Size(123, 41);
            this.systemUserToolStripMenuItem.Text = "System Users";
            // 
            // createNewUserToolStripMenuItem
            // 
            this.createNewUserToolStripMenuItem.Image = global::RanfurlyCentre.Properties.Resources.systemuser2;
            this.createNewUserToolStripMenuItem.Name = "createNewUserToolStripMenuItem";
            this.createNewUserToolStripMenuItem.Size = new System.Drawing.Size(256, 42);
            this.createNewUserToolStripMenuItem.Text = "View System Users";
            this.createNewUserToolStripMenuItem.Click += new System.EventHandler(this.createNewUserToolStripMenuItem_Click_1);
            // 
            // changePasswordToolStripMenuItem1
            // 
            this.changePasswordToolStripMenuItem1.Image = global::RanfurlyCentre.Properties.Resources.changepassword1;
            this.changePasswordToolStripMenuItem1.Name = "changePasswordToolStripMenuItem1";
            this.changePasswordToolStripMenuItem1.Size = new System.Drawing.Size(256, 42);
            this.changePasswordToolStripMenuItem1.Text = "Change Current User Password";
            this.changePasswordToolStripMenuItem1.Click += new System.EventHandler(this.changePasswordToolStripMenuItem1_Click);
            // 
            // adminChangePasswordToolStripMenuItem
            // 
            this.adminChangePasswordToolStripMenuItem.Image = global::RanfurlyCentre.Properties.Resources.AdminSavepassword;
            this.adminChangePasswordToolStripMenuItem.Name = "adminChangePasswordToolStripMenuItem";
            this.adminChangePasswordToolStripMenuItem.Size = new System.Drawing.Size(256, 42);
            this.adminChangePasswordToolStripMenuItem.Text = "Admin Change Password";
            this.adminChangePasswordToolStripMenuItem.Click += new System.EventHandler(this.adminChangePasswordToolStripMenuItem_Click);
            // 
            // maintenanceToolStripMenuItem
            // 
            this.maintenanceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addWorkCentreToolStripMenuItem,
            this.ethnicityToolStripMenuItem,
            this.mnuBackup});
            this.maintenanceToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("maintenanceToolStripMenuItem.Image")));
            this.maintenanceToolStripMenuItem.Name = "maintenanceToolStripMenuItem";
            this.maintenanceToolStripMenuItem.Size = new System.Drawing.Size(123, 41);
            this.maintenanceToolStripMenuItem.Text = "Maintenance";
            // 
            // addWorkCentreToolStripMenuItem
            // 
            this.addWorkCentreToolStripMenuItem.Image = global::RanfurlyCentre.Properties.Resources.WorkCentre1;
            this.addWorkCentreToolStripMenuItem.Name = "addWorkCentreToolStripMenuItem";
            this.addWorkCentreToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.addWorkCentreToolStripMenuItem.Text = "Locations";
            this.addWorkCentreToolStripMenuItem.Click += new System.EventHandler(this.addWorkCentreToolStripMenuItem_Click);
            // 
            // ethnicityToolStripMenuItem
            // 
            this.ethnicityToolStripMenuItem.Image = global::RanfurlyCentre.Properties.Resources.ethnicity1;
            this.ethnicityToolStripMenuItem.Name = "ethnicityToolStripMenuItem";
            this.ethnicityToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.ethnicityToolStripMenuItem.Text = "Ethnicity";
            this.ethnicityToolStripMenuItem.Click += new System.EventHandler(this.ethnicityToolStripMenuItem_Click);
            // 
            // mnuBackup
            // 
            this.mnuBackup.Image = global::RanfurlyCentre.Properties.Resources.backup1;
            this.mnuBackup.Name = "mnuBackup";
            this.mnuBackup.Size = new System.Drawing.Size(167, 22);
            this.mnuBackup.Text = "Back up Database";
            this.mnuBackup.Click += new System.EventHandler(this.mnuBackup_Click);
            // 
            // windowsMenu
            // 
            this.windowsMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newWindowToolStripMenuItem,
            this.cascadeToolStripMenuItem,
            this.tileVerticalToolStripMenuItem,
            this.tileHorizontalToolStripMenuItem,
            this.closeAllToolStripMenuItem,
            this.arrangeIconsToolStripMenuItem});
            this.windowsMenu.Image = global::RanfurlyCentre.Properties.Resources.window;
            this.windowsMenu.Name = "windowsMenu";
            this.windowsMenu.Size = new System.Drawing.Size(103, 41);
            this.windowsMenu.Text = "&Windows";
            // 
            // newWindowToolStripMenuItem
            // 
            this.newWindowToolStripMenuItem.Name = "newWindowToolStripMenuItem";
            this.newWindowToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.newWindowToolStripMenuItem.Text = "&New Window";
            this.newWindowToolStripMenuItem.Visible = false;
            this.newWindowToolStripMenuItem.Click += new System.EventHandler(this.ShowNewForm);
            // 
            // cascadeToolStripMenuItem
            // 
            this.cascadeToolStripMenuItem.Name = "cascadeToolStripMenuItem";
            this.cascadeToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.cascadeToolStripMenuItem.Text = "&Cascade";
            this.cascadeToolStripMenuItem.Visible = false;
            this.cascadeToolStripMenuItem.Click += new System.EventHandler(this.CascadeToolStripMenuItem_Click);
            // 
            // tileVerticalToolStripMenuItem
            // 
            this.tileVerticalToolStripMenuItem.Name = "tileVerticalToolStripMenuItem";
            this.tileVerticalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.tileVerticalToolStripMenuItem.Text = "Tile &Vertical";
            this.tileVerticalToolStripMenuItem.Visible = false;
            this.tileVerticalToolStripMenuItem.Click += new System.EventHandler(this.TileVerticalToolStripMenuItem_Click);
            // 
            // tileHorizontalToolStripMenuItem
            // 
            this.tileHorizontalToolStripMenuItem.Name = "tileHorizontalToolStripMenuItem";
            this.tileHorizontalToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.tileHorizontalToolStripMenuItem.Text = "Tile &Horizontal";
            this.tileHorizontalToolStripMenuItem.Visible = false;
            this.tileHorizontalToolStripMenuItem.Click += new System.EventHandler(this.TileHorizontalToolStripMenuItem_Click);
            // 
            // closeAllToolStripMenuItem
            // 
            this.closeAllToolStripMenuItem.Name = "closeAllToolStripMenuItem";
            this.closeAllToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.closeAllToolStripMenuItem.Text = "C&lose All";
            this.closeAllToolStripMenuItem.Click += new System.EventHandler(this.CloseAllToolStripMenuItem_Click);
            // 
            // arrangeIconsToolStripMenuItem
            // 
            this.arrangeIconsToolStripMenuItem.Name = "arrangeIconsToolStripMenuItem";
            this.arrangeIconsToolStripMenuItem.Size = new System.Drawing.Size(151, 22);
            this.arrangeIconsToolStripMenuItem.Text = "&Arrange Icons";
            this.arrangeIconsToolStripMenuItem.Visible = false;
            this.arrangeIconsToolStripMenuItem.Click += new System.EventHandler(this.ArrangeIconsToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::RanfurlyCentre.Properties.Resources.about4;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(87, 41);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip
            // 
            this.statusStrip.Location = new System.Drawing.Point(0, 649);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1317, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // toolStrip
            // 
            this.toolStrip.Location = new System.Drawing.Point(0, 33);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1317, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            this.toolStrip.Visible = false;
            // 
            // MDIMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1317, 671);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MDIMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ranfurly Care Centre";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MDIMainForm_FormClosing);
            this.Load += new System.EventHandler(this.MDIMainForm_Load);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem tileHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem windowsMenu;
        private System.Windows.Forms.ToolStripMenuItem newWindowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tileVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem arrangeIconsToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem tsStudent;
        private System.Windows.Forms.ToolStripMenuItem tsStaff;
        private System.Windows.Forms.ToolStripMenuItem jobsReportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem systemUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem createNewUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doctorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem maintenanceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addWorkCentreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuBackup;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ethnicityToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doctorsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem otherProfessionalServiceProvidersToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripMenuItem incidentsToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem manageRollCallsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rollCallsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importRollCallToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeImportedFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem appointmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminChangePasswordToolStripMenuItem;
    }
}



