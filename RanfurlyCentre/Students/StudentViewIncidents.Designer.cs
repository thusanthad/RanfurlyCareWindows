namespace RanfurlyCentre.Students
{
    partial class StudentViewIncidents
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.headerLabel = new System.Windows.Forms.Label();
            this.dgIncidents = new System.Windows.Forms.DataGridView();
            this.PersonId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PersonFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileLocation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Comments = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WhoReported = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Location = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IncidentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgIncidents)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.NavajoWhite;
            this.panel1.Controls.Add(this.headerLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1312, 59);
            this.panel1.TabIndex = 3;
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.headerLabel.ForeColor = System.Drawing.Color.Navy;
            this.headerLabel.Location = new System.Drawing.Point(60, 18);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(169, 26);
            this.headerLabel.TabIndex = 0;
            this.headerLabel.Text = "Student Incident";
            // 
            // dgIncidents
            // 
            this.dgIncidents.AllowUserToAddRows = false;
            this.dgIncidents.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Info;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgIncidents.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgIncidents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgIncidents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgIncidents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PersonId,
            this.FirstName,
            this.LastName,
            this.PersonFullName,
            this.Description,
            this.FileLocation,
            this.FileName,
            this.Comments,
            this.WhoReported,
            this.Location,
            this.IncidentType});
            this.dgIncidents.Cursor = System.Windows.Forms.Cursors.Hand;
            this.dgIncidents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgIncidents.Location = new System.Drawing.Point(0, 59);
            this.dgIncidents.Name = "dgIncidents";
            this.dgIncidents.ReadOnly = true;
            this.dgIncidents.Size = new System.Drawing.Size(1312, 562);
            this.dgIncidents.TabIndex = 8;
            // 
            // PersonId
            // 
            this.PersonId.DataPropertyName = "IncidentId";
            this.PersonId.FillWeight = 20F;
            this.PersonId.HeaderText = "IncidentId";
            this.PersonId.Name = "PersonId";
            this.PersonId.ReadOnly = true;
            this.PersonId.Visible = false;
            // 
            // FirstName
            // 
            this.FirstName.DataPropertyName = "IncidentDate";
            this.FirstName.FillWeight = 59.03165F;
            this.FirstName.HeaderText = "Incident Date";
            this.FirstName.Name = "FirstName";
            this.FirstName.ReadOnly = true;
            // 
            // LastName
            // 
            this.LastName.DataPropertyName = "IncidentFullTime";
            this.LastName.FillWeight = 59.03165F;
            this.LastName.HeaderText = "Incident Time";
            this.LastName.Name = "LastName";
            this.LastName.ReadOnly = true;
            // 
            // PersonFullName
            // 
            this.PersonFullName.DataPropertyName = "PersonFullName";
            dataGridViewCellStyle2.Format = "D";
            dataGridViewCellStyle2.NullValue = null;
            this.PersonFullName.DefaultCellStyle = dataGridViewCellStyle2;
            this.PersonFullName.FillWeight = 68.32618F;
            this.PersonFullName.HeaderText = "Person Name";
            this.PersonFullName.Name = "PersonFullName";
            this.PersonFullName.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.FillWeight = 59.03165F;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            // 
            // FileLocation
            // 
            this.FileLocation.DataPropertyName = "FileLocation";
            this.FileLocation.FillWeight = 59.03165F;
            this.FileLocation.HeaderText = "File Location";
            this.FileLocation.Name = "FileLocation";
            this.FileLocation.ReadOnly = true;
            // 
            // FileName
            // 
            this.FileName.DataPropertyName = "FileName";
            dataGridViewCellStyle3.Format = "d";
            this.FileName.DefaultCellStyle = dataGridViewCellStyle3;
            this.FileName.FillWeight = 59.03165F;
            this.FileName.HeaderText = "File Name";
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            this.FileName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FileName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Comments
            // 
            this.Comments.DataPropertyName = "Comments";
            this.Comments.FillWeight = 70F;
            this.Comments.HeaderText = "Comments";
            this.Comments.Name = "Comments";
            this.Comments.ReadOnly = true;
            // 
            // WhoReported
            // 
            this.WhoReported.DataPropertyName = "WhoReportedName";
            this.WhoReported.FillWeight = 75F;
            this.WhoReported.HeaderText = "Who Reported";
            this.WhoReported.Name = "WhoReported";
            this.WhoReported.ReadOnly = true;
            // 
            // Location
            // 
            this.Location.DataPropertyName = "LocationName";
            this.Location.FillWeight = 75F;
            this.Location.HeaderText = "Location";
            this.Location.Name = "Location";
            this.Location.ReadOnly = true;
            // 
            // IncidentType
            // 
            this.IncidentType.DataPropertyName = "IncidentType";
            this.IncidentType.HeaderText = "Incident Type";
            this.IncidentType.Name = "IncidentType";
            this.IncidentType.ReadOnly = true;
            // 
            // StudentViewIncidents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 621);
            this.Controls.Add(this.dgIncidents);
            this.Controls.Add(this.panel1);
            this.Name = "StudentViewIncidents";
            this.Text = "StudentViewIncidents";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgIncidents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.DataGridView dgIncidents;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonId;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PersonFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileLocation;
        private System.Windows.Forms.DataGridViewLinkColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comments;
        private System.Windows.Forms.DataGridViewTextBoxColumn WhoReported;
        private System.Windows.Forms.DataGridViewTextBoxColumn Location;
        private System.Windows.Forms.DataGridViewTextBoxColumn IncidentType;
    }
}