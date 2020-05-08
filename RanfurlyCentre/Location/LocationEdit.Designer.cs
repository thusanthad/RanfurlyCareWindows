namespace RanfurlyCentre
{
    partial class LocationEdit
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
            this.dgLocation = new System.Windows.Forms.DataGridView();
            this.cmAddWorkCentre = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addEthnicityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.LocationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocationNameWithoutAbbreviation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Abbreviation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FullAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Telephone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RollResference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsResidence = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsRollCall = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsStudentCentre = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgLocation)).BeginInit();
            this.cmAddWorkCentre.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgLocation
            // 
            this.dgLocation.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgLocation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LocationId,
            this.LocationNameWithoutAbbreviation,
            this.Abbreviation,
            this.FullAddress,
            this.Telephone,
            this.RollResference,
            this.IsResidence,
            this.IsRollCall,
            this.IsStudentCentre});
            this.dgLocation.ContextMenuStrip = this.cmAddWorkCentre;
            this.dgLocation.Location = new System.Drawing.Point(12, 12);
            this.dgLocation.Name = "dgLocation";
            this.dgLocation.RowHeadersVisible = false;
            this.dgLocation.Size = new System.Drawing.Size(905, 302);
            this.dgLocation.TabIndex = 0;
            // 
            // cmAddWorkCentre
            // 
            this.cmAddWorkCentre.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.cmAddWorkCentre.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEthnicityToolStripMenuItem});
            this.cmAddWorkCentre.Name = "cmAddEthnicity";
            this.cmAddWorkCentre.Size = new System.Drawing.Size(182, 36);
            // 
            // addEthnicityToolStripMenuItem
            // 
            this.addEthnicityToolStripMenuItem.Image = global::RanfurlyCentre.Properties.Resources.location;
            this.addEthnicityToolStripMenuItem.Name = "addEthnicityToolStripMenuItem";
            this.addEthnicityToolStripMenuItem.Size = new System.Drawing.Size(181, 32);
            this.addEthnicityToolStripMenuItem.Text = "Add New Location";
            this.addEthnicityToolStripMenuItem.Click += new System.EventHandler(this.addEthnicityToolStripMenuItem_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(923, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 52);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Save and Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(923, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Right Click";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(923, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "to add new";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(923, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Location";
            // 
            // LocationId
            // 
            this.LocationId.DataPropertyName = "LocationId";
            this.LocationId.HeaderText = "LocationId";
            this.LocationId.Name = "LocationId";
            this.LocationId.Visible = false;
            // 
            // LocationNameWithoutAbbreviation
            // 
            this.LocationNameWithoutAbbreviation.DataPropertyName = "LocationNameWithoutAbbreviation";
            this.LocationNameWithoutAbbreviation.HeaderText = "Location";
            this.LocationNameWithoutAbbreviation.Name = "LocationNameWithoutAbbreviation";
            // 
            // Abbreviation
            // 
            this.Abbreviation.DataPropertyName = "Abbreviation";
            this.Abbreviation.FillWeight = 30F;
            this.Abbreviation.HeaderText = "Abbreviation";
            this.Abbreviation.Name = "Abbreviation";
            // 
            // FullAddress
            // 
            this.FullAddress.DataPropertyName = "FullAddress";
            this.FullAddress.HeaderText = "Full Address";
            this.FullAddress.Name = "FullAddress";
            // 
            // Telephone
            // 
            this.Telephone.DataPropertyName = "Telephone";
            this.Telephone.HeaderText = "Telephone";
            this.Telephone.Name = "Telephone";
            // 
            // RollResference
            // 
            this.RollResference.DataPropertyName = "RollReference";
            this.RollResference.FillWeight = 50F;
            this.RollResference.HeaderText = "Roll Resference";
            this.RollResference.Name = "RollResference";
            // 
            // IsResidence
            // 
            this.IsResidence.DataPropertyName = "IsResidence";
            this.IsResidence.FillWeight = 40F;
            this.IsResidence.HeaderText = "Is Residence";
            this.IsResidence.Name = "IsResidence";
            // 
            // IsRollCall
            // 
            this.IsRollCall.DataPropertyName = "IsRollCall";
            this.IsRollCall.FillWeight = 40F;
            this.IsRollCall.HeaderText = "Is Roll Call";
            this.IsRollCall.Name = "IsRollCall";
            // 
            // IsStudentCentre
            // 
            this.IsStudentCentre.DataPropertyName = "IsStudentCentre";
            this.IsStudentCentre.FillWeight = 40F;
            this.IsStudentCentre.HeaderText = "Is Student Centre";
            this.IsStudentCentre.Name = "IsStudentCentre";
            // 
            // LocationEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1005, 324);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgLocation);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocationEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Locations";
            ((System.ComponentModel.ISupportInitialize)(this.dgLocation)).EndInit();
            this.cmAddWorkCentre.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgLocation;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmAddWorkCentre;
        private System.Windows.Forms.ToolStripMenuItem addEthnicityToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationNameWithoutAbbreviation;
        private System.Windows.Forms.DataGridViewTextBoxColumn Abbreviation;
        private System.Windows.Forms.DataGridViewTextBoxColumn FullAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn Telephone;
        private System.Windows.Forms.DataGridViewTextBoxColumn RollResference;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsResidence;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsRollCall;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsStudentCentre;
    }
}