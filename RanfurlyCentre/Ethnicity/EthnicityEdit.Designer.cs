namespace RanfurlyCentre
{
    partial class EthnicityEdit
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
            this.dgEthnicity = new System.Windows.Forms.DataGridView();
            this.EthnicityId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ethnicity1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmAddEthnicity = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addEthnicityToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnClose = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgEthnicity)).BeginInit();
            this.cmAddEthnicity.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgEthnicity
            // 
            this.dgEthnicity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgEthnicity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgEthnicity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.EthnicityId,
            this.Ethnicity1});
            this.dgEthnicity.ContextMenuStrip = this.cmAddEthnicity;
            this.dgEthnicity.Location = new System.Drawing.Point(12, 12);
            this.dgEthnicity.Name = "dgEthnicity";
            this.dgEthnicity.RowHeadersVisible = false;
            this.dgEthnicity.Size = new System.Drawing.Size(319, 302);
            this.dgEthnicity.TabIndex = 0;
            this.dgEthnicity.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgEthnicity_CellEndEdit);
            // 
            // EthnicityId
            // 
            this.EthnicityId.DataPropertyName = "EthnicityId";
            this.EthnicityId.HeaderText = "EthnicityId";
            this.EthnicityId.Name = "EthnicityId";
            this.EthnicityId.Visible = false;
            // 
            // Ethnicity1
            // 
            this.Ethnicity1.DataPropertyName = "EthnicityName";
            this.Ethnicity1.HeaderText = "Ethnicity";
            this.Ethnicity1.Name = "Ethnicity1";
            // 
            // cmAddEthnicity
            // 
            this.cmAddEthnicity.ImageScalingSize = new System.Drawing.Size(25, 25);
            this.cmAddEthnicity.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addEthnicityToolStripMenuItem});
            this.cmAddEthnicity.Name = "cmAddEthnicity";
            this.cmAddEthnicity.Size = new System.Drawing.Size(155, 36);
            // 
            // addEthnicityToolStripMenuItem
            // 
            this.addEthnicityToolStripMenuItem.Image = global::RanfurlyCentre.Properties.Resources.addethnicity;
            this.addEthnicityToolStripMenuItem.Name = "addEthnicityToolStripMenuItem";
            this.addEthnicityToolStripMenuItem.Size = new System.Drawing.Size(154, 32);
            this.addEthnicityToolStripMenuItem.Text = "Add Ethnicity";
            this.addEthnicityToolStripMenuItem.Click += new System.EventHandler(this.addEthnicityToolStripMenuItem_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(337, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(334, 171);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Ethnicity";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(334, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Right Click";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(337, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "to add";
            // 
            // EthnicityEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 324);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgEthnicity);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EthnicityEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ethnicity";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EthnicityEdit_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgEthnicity)).EndInit();
            this.cmAddEthnicity.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgEthnicity;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn EthnicityId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ethnicity1;
        private System.Windows.Forms.ContextMenuStrip cmAddEthnicity;
        private System.Windows.Forms.ToolStripMenuItem addEthnicityToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}