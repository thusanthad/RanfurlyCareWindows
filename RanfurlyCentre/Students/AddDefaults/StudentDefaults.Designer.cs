namespace RanfurlyCentre.Students.AddDefaults
{
    partial class StudentDefaults
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
            this.dgData = new System.Windows.Forms.DataGridView();
            this.lblDeafaultType = new System.Windows.Forms.Label();
            this.Seclected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnProceed = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgData
            // 
            this.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seclected,
            this.Item});
            this.dgData.Location = new System.Drawing.Point(2, 77);
            this.dgData.Name = "dgData";
            this.dgData.Size = new System.Drawing.Size(902, 375);
            this.dgData.TabIndex = 0;
            // 
            // lblDeafaultType
            // 
            this.lblDeafaultType.AutoSize = true;
            this.lblDeafaultType.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeafaultType.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblDeafaultType.Location = new System.Drawing.Point(12, 26);
            this.lblDeafaultType.Name = "lblDeafaultType";
            this.lblDeafaultType.Size = new System.Drawing.Size(70, 26);
            this.lblDeafaultType.TabIndex = 1;
            this.lblDeafaultType.Text = "label1";
            // 
            // Seclected
            // 
            this.Seclected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Seclected.DataPropertyName = "Selected";
            this.Seclected.HeaderText = "Select";
            this.Seclected.Name = "Seclected";
            this.Seclected.Width = 43;
            // 
            // Item
            // 
            this.Item.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Item.DataPropertyName = "Item";
            this.Item.HeaderText = "Item";
            this.Item.Name = "Item";
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.ForeColor = System.Drawing.Color.Red;
            this.btnCancel.Location = new System.Drawing.Point(804, 24);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 34);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnProceed
            // 
            this.btnProceed.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProceed.ForeColor = System.Drawing.Color.Maroon;
            this.btnProceed.Location = new System.Drawing.Point(723, 24);
            this.btnProceed.Name = "btnProceed";
            this.btnProceed.Size = new System.Drawing.Size(75, 34);
            this.btnProceed.TabIndex = 3;
            this.btnProceed.Text = "Proceed";
            this.btnProceed.UseVisualStyleBackColor = true;
            this.btnProceed.Click += new System.EventHandler(this.btnProceed_Click);
            // 
            // StudentDefaults
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 450);
            this.Controls.Add(this.btnProceed);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblDeafaultType);
            this.Controls.Add(this.dgData);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentDefaults";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Student Defaults";
            this.Load += new System.EventHandler(this.StudentDefaults_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgData;
        public System.Windows.Forms.Label lblDeafaultType;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Seclected;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnProceed;
    }
}