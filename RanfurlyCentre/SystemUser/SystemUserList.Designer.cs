namespace RanfurlyCentre
    {
    partial class SystemUserList
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("System Administrtator");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Add");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Edit");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("View");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Student", new System.Windows.Forms.TreeNode[] {
            treeNode2,
            treeNode3,
            treeNode4});
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Add");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Edit");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("View");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Staff", new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Add");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Edit");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("View");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Medical Service", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode12});
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("View");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("Report", new System.Windows.Forms.TreeNode[] {
            treeNode14});
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Add");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Edit");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("View");
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("User", new System.Windows.Forms.TreeNode[] {
            treeNode16,
            treeNode17,
            treeNode18});
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Add");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Edit");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("View");
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Incident", new System.Windows.Forms.TreeNode[] {
            treeNode20,
            treeNode21,
            treeNode22});
            System.Windows.Forms.TreeNode treeNode24 = new System.Windows.Forms.TreeNode("Add");
            System.Windows.Forms.TreeNode treeNode25 = new System.Windows.Forms.TreeNode("Edit");
            System.Windows.Forms.TreeNode treeNode26 = new System.Windows.Forms.TreeNode("View");
            System.Windows.Forms.TreeNode treeNode27 = new System.Windows.Forms.TreeNode("RollCall", new System.Windows.Forms.TreeNode[] {
            treeNode24,
            treeNode25,
            treeNode26});
            this.dgSystemUsers = new System.Windows.Forms.DataGridView();
            this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsStaffMember = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addMNewSystemUsetrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label2 = new System.Windows.Forms.Label();
            this.lblUserCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgSystemUsers)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgSystemUsers
            // 
            this.dgSystemUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgSystemUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSystemUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserId,
            this.UserName,
            this.FirstName,
            this.LastName,
            this.Email,
            this.IsStaffMember});
            this.dgSystemUsers.ContextMenuStrip = this.contextMenuStrip1;
            this.dgSystemUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgSystemUsers.Location = new System.Drawing.Point(12, 80);
            this.dgSystemUsers.Name = "dgSystemUsers";
            this.dgSystemUsers.Size = new System.Drawing.Size(680, 588);
            this.dgSystemUsers.TabIndex = 0;
            this.dgSystemUsers.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSystemUsers_RowEnter);
            // 
            // UserId
            // 
            this.UserId.DataPropertyName = "UserId";
            this.UserId.HeaderText = "UserId";
            this.UserId.Name = "UserId";
            this.UserId.Visible = false;
            // 
            // UserName
            // 
            this.UserName.DataPropertyName = "UserName";
            this.UserName.HeaderText = "User Name";
            this.UserName.Name = "UserName";
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "FirstName";
            this.FirstName.HeaderText = "First Name";
            this.FirstName.Name = "FirstName";
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "LastName";
            this.LastName.HeaderText = "Last Name";
            this.LastName.Name = "LastName";
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.FillWeight = 200F;
            this.Email.HeaderText = "Email";
            this.Email.Name = "Email";
            // 
            // IsStaffMember
            // 
            this.IsStaffMember.DataPropertyName = "IsStaffMember";
            this.IsStaffMember.HeaderText = "Is Staff Member";
            this.IsStaffMember.Name = "IsStaffMember";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMNewSystemUsetrToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(204, 36);
            // 
            // addMNewSystemUsetrToolStripMenuItem
            // 
            this.addMNewSystemUsetrToolStripMenuItem.Image = global::RanfurlyCentre.Properties.Resources.uaseradd1;
            this.addMNewSystemUsetrToolStripMenuItem.Name = "addMNewSystemUsetrToolStripMenuItem";
            this.addMNewSystemUsetrToolStripMenuItem.Size = new System.Drawing.Size(203, 32);
            this.addMNewSystemUsetrToolStripMenuItem.Text = "Add New System Usetr";
            this.addMNewSystemUsetrToolStripMenuItem.Click += new System.EventHandler(this.addMNewSystemUsetrToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(971, 68);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.NavajoWhite;
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnSave);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(971, 68);
            this.panel2.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(874, 14);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(85, 40);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.ForeColor = System.Drawing.Color.Red;
            this.btnSave.Location = new System.Drawing.Point(783, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(85, 40);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(49, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "System Users && Permissions";
            // 
            // treeView1
            // 
            this.treeView1.CheckBoxes = true;
            this.treeView1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.treeView1.ItemHeight = 20;
            this.treeView1.Location = new System.Drawing.Point(707, 80);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "SystemAdministrtator";
            treeNode1.Text = "System Administrtator";
            treeNode2.Name = "StudentAdd";
            treeNode2.Text = "Add";
            treeNode3.Name = "StudentEdit";
            treeNode3.Text = "Edit";
            treeNode4.Name = "StudentView";
            treeNode4.Text = "View";
            treeNode5.Name = "Student";
            treeNode5.Text = "Student";
            treeNode6.Name = "StaffAdd";
            treeNode6.Text = "Add";
            treeNode7.Name = "StaffEdit";
            treeNode7.Text = "Edit";
            treeNode8.Name = "StaffView";
            treeNode8.Text = "View";
            treeNode9.Name = "Staff";
            treeNode9.Text = "Staff";
            treeNode10.Name = "MedicalServiceAdd";
            treeNode10.Text = "Add";
            treeNode11.Name = "MedicalServiceEdit";
            treeNode11.Text = "Edit";
            treeNode12.Name = "MedicalServiceView";
            treeNode12.Text = "View";
            treeNode13.Name = "MedicalService";
            treeNode13.Text = "Medical Service";
            treeNode14.Name = "ReportView";
            treeNode14.Text = "View";
            treeNode15.Name = "Report";
            treeNode15.Text = "Report";
            treeNode16.Name = "UserAdd";
            treeNode16.Text = "Add";
            treeNode17.Name = "UserEdit";
            treeNode17.Text = "Edit";
            treeNode18.Name = "UserView";
            treeNode18.Text = "View";
            treeNode19.Name = "User";
            treeNode19.Text = "User";
            treeNode20.Name = "IncidentAdd";
            treeNode20.Text = "Add";
            treeNode21.Name = "IncidentEdit";
            treeNode21.Text = "Edit";
            treeNode22.Name = "IncidentView";
            treeNode22.Text = "View";
            treeNode23.Name = "Incident";
            treeNode23.Text = "Incident";
            treeNode24.Name = "RollCallAdd";
            treeNode24.Text = "Add";
            treeNode25.Name = "RollCallEdit";
            treeNode25.Text = "Edit";
            treeNode26.Name = "RollCallView";
            treeNode26.Text = "View";
            treeNode27.Name = "RollCall";
            treeNode27.Text = "RollCall";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode5,
            treeNode9,
            treeNode13,
            treeNode15,
            treeNode19,
            treeNode23,
            treeNode27});
            this.treeView1.Size = new System.Drawing.Size(264, 496);
            this.treeView1.TabIndex = 2;
            this.treeView1.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.treeView1_BeforeCheck);
            this.treeView1.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterCheck);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(718, 646);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(204, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Right click to add new user";
            // 
            // lblUserCount
            // 
            this.lblUserCount.AutoSize = true;
            this.lblUserCount.Location = new System.Drawing.Point(718, 614);
            this.lblUserCount.Name = "lblUserCount";
            this.lblUserCount.Size = new System.Drawing.Size(35, 13);
            this.lblUserCount.TabIndex = 6;
            this.lblUserCount.Text = "label3";
            // 
            // SystemUserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 675);
            this.Controls.Add(this.lblUserCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.dgSystemUsers);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SystemUserList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "System User List";
            this.Load += new System.EventHandler(this.SystemUserList_Load);
            this.Shown += new System.EventHandler(this.SystemUserList_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgSystemUsers)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
        private System.Windows.Forms.DataGridViewTextBoxColumn UserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsStaffMember;
        public System.Windows.Forms.DataGridView dgSystemUsers;
        public System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addMNewSystemUsetrToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblUserCount;
        public System.Windows.Forms.Button btnClose;
    }
}