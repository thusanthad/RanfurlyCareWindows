namespace RanfurlyCentre
{
    partial class FileExportDashBoard
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
            this.btnExport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFileLocation = new System.Windows.Forms.TextBox();
            this.txtOutputFileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.rbCSV = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbTextFile = new System.Windows.Forms.RadioButton();
            this.rbXLSFile = new System.Windows.Forms.RadioButton();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProgress = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.chkExportFields = new System.Windows.Forms.CheckBox();
            this.dgFieldList = new System.Windows.Forms.DataGridView();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.PrintName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnMoveUp = new System.Windows.Forms.Button();
            this.btnMoveDown = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFieldList)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExport
            // 
            this.btnExport.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExport.ForeColor = System.Drawing.Color.Maroon;
            this.btnExport.Location = new System.Drawing.Point(618, 44);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 23);
            this.btnExport.TabIndex = 0;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Location:";
            // 
            // txtFileLocation
            // 
            this.txtFileLocation.Location = new System.Drawing.Point(143, 46);
            this.txtFileLocation.Name = "txtFileLocation";
            this.txtFileLocation.Size = new System.Drawing.Size(452, 20);
            this.txtFileLocation.TabIndex = 2;
            // 
            // txtOutputFileName
            // 
            this.txtOutputFileName.Location = new System.Drawing.Point(143, 72);
            this.txtOutputFileName.Name = "txtOutputFileName";
            this.txtOutputFileName.Size = new System.Drawing.Size(452, 20);
            this.txtOutputFileName.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "File Name:";
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(699, 44);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // rbCSV
            // 
            this.rbCSV.AutoSize = true;
            this.rbCSV.Checked = true;
            this.rbCSV.Location = new System.Drawing.Point(15, 19);
            this.rbCSV.Name = "rbCSV";
            this.rbCSV.Size = new System.Drawing.Size(65, 17);
            this.rbCSV.TabIndex = 8;
            this.rbCSV.TabStop = true;
            this.rbCSV.Text = "CSV File";
            this.rbCSV.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbTextFile);
            this.groupBox1.Controls.Add(this.rbXLSFile);
            this.groupBox1.Controls.Add(this.rbCSV);
            this.groupBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.groupBox1.Location = new System.Drawing.Point(484, 150);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(137, 100);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Type";
            // 
            // rbTextFile
            // 
            this.rbTextFile.AutoSize = true;
            this.rbTextFile.Location = new System.Drawing.Point(15, 65);
            this.rbTextFile.Name = "rbTextFile";
            this.rbTextFile.Size = new System.Drawing.Size(65, 17);
            this.rbTextFile.TabIndex = 10;
            this.rbTextFile.TabStop = true;
            this.rbTextFile.Text = "Text File";
            this.rbTextFile.UseVisualStyleBackColor = true;
            // 
            // rbXLSFile
            // 
            this.rbXLSFile.AutoSize = true;
            this.rbXLSFile.Location = new System.Drawing.Point(15, 42);
            this.rbXLSFile.Name = "rbXLSFile";
            this.rbXLSFile.Size = new System.Drawing.Size(70, 17);
            this.rbXLSFile.TabIndex = 9;
            this.rbXLSFile.TabStop = true;
            this.rbXLSFile.Text = "Excel File";
            this.rbXLSFile.UseVisualStyleBackColor = true;
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(484, 322);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(290, 23);
            this.progressBar1.TabIndex = 10;
            this.progressBar1.Visible = false;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Location = new System.Drawing.Point(611, 302);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(48, 13);
            this.lblProgress.TabIndex = 11;
            this.lblProgress.Text = "Progress";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProgress.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(140, 110);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(146, 13);
            this.label19.TabIndex = 43;
            this.label19.Text = "Tick for selected output fields";
            // 
            // chkExportFields
            // 
            this.chkExportFields.AutoSize = true;
            this.chkExportFields.Checked = true;
            this.chkExportFields.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkExportFields.Location = new System.Drawing.Point(155, 553);
            this.chkExportFields.Name = "chkExportFields";
            this.chkExportFields.Size = new System.Drawing.Size(121, 17);
            this.chkExportFields.TabIndex = 42;
            this.chkExportFields.Text = "Select - Deselect All";
            this.chkExportFields.UseVisualStyleBackColor = true;
            this.chkExportFields.CheckedChanged += new System.EventHandler(this.chkExportFields_CheckedChanged);
            // 
            // dgFieldList
            // 
            this.dgFieldList.AllowUserToAddRows = false;
            this.dgFieldList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgFieldList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgFieldList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.PrintName,
            this.ColumnPosition});
            this.dgFieldList.Location = new System.Drawing.Point(143, 126);
            this.dgFieldList.Name = "dgFieldList";
            this.dgFieldList.RowHeadersVisible = false;
            this.dgFieldList.RowHeadersWidth = 35;
            this.dgFieldList.Size = new System.Drawing.Size(311, 417);
            this.dgFieldList.TabIndex = 44;
            this.dgFieldList.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgFieldList_CellMouseClick);
            this.dgFieldList.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgFieldList_CellMouseUp);
            // 
            // Selected
            // 
            this.Selected.DataPropertyName = "Selected";
            this.Selected.FillWeight = 20F;
            this.Selected.HeaderText = "Select";
            this.Selected.Name = "Selected";
            // 
            // PrintName
            // 
            this.PrintName.DataPropertyName = "PrintName";
            this.PrintName.HeaderText = "Field Name";
            this.PrintName.Name = "PrintName";
            this.PrintName.ReadOnly = true;
            // 
            // ColumnPosition
            // 
            this.ColumnPosition.DataPropertyName = "ColumnPosition";
            this.ColumnPosition.FillWeight = 30F;
            this.ColumnPosition.HeaderText = "Order";
            this.ColumnPosition.Name = "ColumnPosition";
            // 
            // btnMoveUp
            // 
            this.btnMoveUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoveUp.Location = new System.Drawing.Point(72, 274);
            this.btnMoveUp.Name = "btnMoveUp";
            this.btnMoveUp.Size = new System.Drawing.Size(47, 62);
            this.btnMoveUp.TabIndex = 45;
            this.btnMoveUp.Text = "MoveUp";
            this.btnMoveUp.UseVisualStyleBackColor = true;
            this.btnMoveUp.Click += new System.EventHandler(this.btnMoveUp_Click);
            // 
            // btnMoveDown
            // 
            this.btnMoveDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMoveDown.Location = new System.Drawing.Point(72, 342);
            this.btnMoveDown.Name = "btnMoveDown";
            this.btnMoveDown.Size = new System.Drawing.Size(47, 62);
            this.btnMoveDown.TabIndex = 46;
            this.btnMoveDown.Text = "MoveDown";
            this.btnMoveDown.UseVisualStyleBackColor = true;
            this.btnMoveDown.Click += new System.EventHandler(this.btnMoveDown_Click);
            // 
            // FileExportDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 597);
            this.Controls.Add(this.btnMoveDown);
            this.Controls.Add(this.btnMoveUp);
            this.Controls.Add(this.dgFieldList);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.chkExportFields);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.txtOutputFileName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFileLocation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExport);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FileExportDashBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "File Export Dashboard";
            this.Shown += new System.EventHandler(this.FileExportDashBoard_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgFieldList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFileLocation;
        private System.Windows.Forms.TextBox txtOutputFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RadioButton rbCSV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbTextFile;
        private System.Windows.Forms.RadioButton rbXLSFile;
        private System.Windows.Forms.ErrorProvider ep;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.CheckBox chkExportFields;
        private System.Windows.Forms.DataGridView dgFieldList;
        private System.Windows.Forms.Button btnMoveDown;
        private System.Windows.Forms.Button btnMoveUp;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrintName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPosition;
    }
}