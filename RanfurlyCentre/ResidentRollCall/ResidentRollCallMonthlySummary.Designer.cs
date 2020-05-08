namespace RanfurlyCentre
{
    partial class ResidentRollCallMonthlySummary
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.lblRowCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelMonthly = new System.Windows.Forms.Panel();
            this.dgRollCallMonthlySummary = new System.Windows.Forms.DataGridView();
            this.StudentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ResidentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LocationName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RollReference = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonthNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YearNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.M = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CPA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.W = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ST = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.H = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelMonthly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgRollCallMonthlySummary)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelMonthly, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1117, 685);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.NavajoWhite;
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnGenerateReport);
            this.panel1.Controls.Add(this.btnExport);
            this.panel1.Controls.Add(this.lblRowCount);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1111, 62);
            this.panel1.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(989, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(113, 41);
            this.btnClose.TabIndex = 22;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGenerateReport.ForeColor = System.Drawing.Color.Maroon;
            this.btnGenerateReport.Location = new System.Drawing.Point(751, 9);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(113, 41);
            this.btnGenerateReport.TabIndex = 21;
            this.btnGenerateReport.Text = "GenerateReport";
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // btnExport
            // 
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.ForeColor = System.Drawing.Color.Maroon;
            this.btnExport.Location = new System.Drawing.Point(870, 9);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(113, 41);
            this.btnExport.TabIndex = 20;
            this.btnExport.Text = "Export List";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // lblRowCount
            // 
            this.lblRowCount.AutoSize = true;
            this.lblRowCount.Location = new System.Drawing.Point(582, 28);
            this.lblRowCount.Name = "lblRowCount";
            this.lblRowCount.Size = new System.Drawing.Size(63, 13);
            this.lblRowCount.TabIndex = 2;
            this.lblRowCount.Text = "Row Count:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(27, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(369, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monthly Resident Roll Call Summary";
            // 
            // panelMonthly
            // 
            this.panelMonthly.Controls.Add(this.dgRollCallMonthlySummary);
            this.panelMonthly.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMonthly.Location = new System.Drawing.Point(3, 71);
            this.panelMonthly.Name = "panelMonthly";
            this.panelMonthly.Size = new System.Drawing.Size(1111, 611);
            this.panelMonthly.TabIndex = 4;
            // 
            // dgRollCallMonthlySummary
            // 
            this.dgRollCallMonthlySummary.AllowUserToAddRows = false;
            this.dgRollCallMonthlySummary.AllowUserToDeleteRows = false;
            this.dgRollCallMonthlySummary.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightYellow;
            this.dgRollCallMonthlySummary.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgRollCallMonthlySummary.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgRollCallMonthlySummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgRollCallMonthlySummary.ColumnHeadersHeight = 25;
            this.dgRollCallMonthlySummary.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgRollCallMonthlySummary.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.StudentId,
            this.ResidentName,
            this.LocationName,
            this.RollReference,
            this.MonthNumber,
            this.YearNumber,
            this.RH,
            this.M,
            this.CPA,
            this.AL,
            this.DH,
            this.W,
            this.ST,
            this.H,
            this.Total});
            this.dgRollCallMonthlySummary.Cursor = System.Windows.Forms.Cursors.Hand;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgRollCallMonthlySummary.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgRollCallMonthlySummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgRollCallMonthlySummary.Location = new System.Drawing.Point(0, 0);
            this.dgRollCallMonthlySummary.Name = "dgRollCallMonthlySummary";
            this.dgRollCallMonthlySummary.Size = new System.Drawing.Size(1111, 611);
            this.dgRollCallMonthlySummary.TabIndex = 2;
            this.dgRollCallMonthlySummary.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgRollCallMonthlySummary_ColumnHeaderMouseClick);
            this.dgRollCallMonthlySummary.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgRollCallSummary_RowPostPaint);
            // 
            // StudentId
            // 
            this.StudentId.DataPropertyName = "StudentId";
            this.StudentId.FillWeight = 70F;
            this.StudentId.HeaderText = "Id";
            this.StudentId.Name = "StudentId";
            // 
            // ResidentName
            // 
            this.ResidentName.DataPropertyName = "ResidentName";
            this.ResidentName.FillWeight = 200F;
            this.ResidentName.HeaderText = "Resident Name";
            this.ResidentName.Name = "ResidentName";
            // 
            // LocationName
            // 
            this.LocationName.DataPropertyName = "LocationName";
            this.LocationName.FillWeight = 200F;
            this.LocationName.HeaderText = "Location";
            this.LocationName.Name = "LocationName";
            // 
            // RollReference
            // 
            this.RollReference.HeaderText = "RollReference";
            this.RollReference.Name = "RollReference";
            this.RollReference.Visible = false;
            // 
            // MonthNumber
            // 
            this.MonthNumber.DataPropertyName = "MonthNumber";
            this.MonthNumber.HeaderText = "Month";
            this.MonthNumber.Name = "MonthNumber";
            // 
            // YearNumber
            // 
            this.YearNumber.DataPropertyName = "YearNumber";
            this.YearNumber.HeaderText = "Year";
            this.YearNumber.Name = "YearNumber";
            // 
            // RH
            // 
            this.RH.DataPropertyName = "RH";
            this.RH.HeaderText = "RH";
            this.RH.Name = "RH";
            // 
            // M
            // 
            this.M.DataPropertyName = "M";
            this.M.HeaderText = "M";
            this.M.Name = "M";
            // 
            // CPA
            // 
            this.CPA.DataPropertyName = "CPA";
            this.CPA.HeaderText = "CPA";
            this.CPA.Name = "CPA";
            // 
            // AL
            // 
            this.AL.DataPropertyName = "AL";
            this.AL.HeaderText = "AL";
            this.AL.Name = "AL";
            // 
            // DH
            // 
            this.DH.DataPropertyName = "DH";
            this.DH.HeaderText = "DH";
            this.DH.Name = "DH";
            // 
            // W
            // 
            this.W.DataPropertyName = "W";
            this.W.HeaderText = "W";
            this.W.Name = "W";
            // 
            // ST
            // 
            this.ST.DataPropertyName = "ST";
            this.ST.HeaderText = "ST";
            this.ST.Name = "ST";
            // 
            // H
            // 
            this.H.DataPropertyName = "H";
            this.H.HeaderText = "H";
            this.H.Name = "H";
            // 
            // Total
            // 
            this.Total.DataPropertyName = "Total";
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // ResidentRollCallMonthlySummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1117, 685);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ResidentRollCallMonthlySummary";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Resident Roll Call Monthly Summary";
            this.Load += new System.EventHandler(this.ResidentRollCallSummary_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelMonthly.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgRollCallMonthlySummary)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgRollCallMonthlySummary;
        private System.Windows.Forms.Panel panelMonthly;
        private System.Windows.Forms.Label lblRowCount;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn StudentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ResidentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn LocationName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RollReference;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonthNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn YearNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn RH;
        private System.Windows.Forms.DataGridViewTextBoxColumn M;
        private System.Windows.Forms.DataGridViewTextBoxColumn CPA;
        private System.Windows.Forms.DataGridViewTextBoxColumn AL;
        private System.Windows.Forms.DataGridViewTextBoxColumn DH;
        private System.Windows.Forms.DataGridViewTextBoxColumn W;
        private System.Windows.Forms.DataGridViewTextBoxColumn ST;
        private System.Windows.Forms.DataGridViewTextBoxColumn H;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
    }
}