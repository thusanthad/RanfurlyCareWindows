namespace RanfurlyCentre
{
    partial class WorkCentreEdit
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
            this.dgWorkCentre = new System.Windows.Forms.DataGridView();
            this.WorkCentreId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkCentreName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Abbreviation = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmAddWorkCentre = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addEthnicityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgWorkCentre)).BeginInit();
            this.cmAddWorkCentre.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgWorkCentre
            // 
            this.dgWorkCentre.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgWorkCentre.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgWorkCentre.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.WorkCentreId,
            this.WorkCentreName,
            this.Abbreviation});
            this.dgWorkCentre.ContextMenuStrip = this.cmAddWorkCentre;
            this.dgWorkCentre.Location = new System.Drawing.Point(12, 12);
            this.dgWorkCentre.Name = "dgWorkCentre";
            this.dgWorkCentre.RowHeadersVisible = false;
            this.dgWorkCentre.Size = new System.Drawing.Size(319, 302);
            this.dgWorkCentre.TabIndex = 0;
            // 
            // WorkCentreId
            // 
            this.WorkCentreId.DataPropertyName = "WorkCentreId";
            this.WorkCentreId.HeaderText = "EthnicityId";
            this.WorkCentreId.Name = "WorkCentreId";
            this.WorkCentreId.Visible = false;
            // 
            // WorkCentreName
            // 
            this.WorkCentreName.DataPropertyName = "WorkCentreName";
            this.WorkCentreName.FillWeight = 75F;
            this.WorkCentreName.HeaderText = "Work Centre";
            this.WorkCentreName.Name = "WorkCentreName";
            // 
            // Abbreviation
            // 
            this.Abbreviation.DataPropertyName = "Abbreviation";
            this.Abbreviation.FillWeight = 25F;
            this.Abbreviation.HeaderText = "Abbreviation";
            this.Abbreviation.Name = "Abbreviation";
            // 
            // cmAddWorkCentre
            // 
            this.cmAddWorkCentre.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.cmAddWorkCentre.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEthnicityToolStripMenuItem});
            this.cmAddWorkCentre.Name = "cmAddEthnicity";
            this.cmAddWorkCentre.Size = new System.Drawing.Size(181, 48);
            // 
            // addEthnicityToolStripMenuItem
            // 
            this.addEthnicityToolStripMenuItem.Name = "addEthnicityToolStripMenuItem";
            this.addEthnicityToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.addEthnicityToolStripMenuItem.Text = "Add Work Centre";
            this.addEthnicityToolStripMenuItem.Click += new System.EventHandler(this.addEthnicityToolStripMenuItem_Click);
            // 
            // btnClose
            // 
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(337, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // WorkCentreEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 324);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgWorkCentre);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WorkCentreEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Work Centres";
            ((System.ComponentModel.ISupportInitialize)(this.dgWorkCentre)).EndInit();
            this.cmAddWorkCentre.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgWorkCentre;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ContextMenuStrip cmAddWorkCentre;
        private System.Windows.Forms.ToolStripMenuItem addEthnicityToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkCentreId;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkCentreName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Abbreviation;
    }
}