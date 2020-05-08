namespace RanfurlyCentre
{
    partial class NextOfKinAssign
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNextOfKinName = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.txtNextOfKinName = new System.Windows.Forms.TextBox();
            this.txtRelationship = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Next of Kin Name";
            // 
            // cmbNextOfKinName
            // 
            this.cmbNextOfKinName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbNextOfKinName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbNextOfKinName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNextOfKinName.FormattingEnabled = true;
            this.cmbNextOfKinName.Location = new System.Drawing.Point(178, 68);
            this.cmbNextOfKinName.Name = "cmbNextOfKinName";
            this.cmbNextOfKinName.Size = new System.Drawing.Size(319, 21);
            this.cmbNextOfKinName.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Location = new System.Drawing.Point(513, 66);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "Assign";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.ForeColor = System.Drawing.Color.Red;
            this.btnClose.Location = new System.Drawing.Point(620, 66);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // txtNextOfKinName
            // 
            this.txtNextOfKinName.Location = new System.Drawing.Point(178, 68);
            this.txtNextOfKinName.Name = "txtNextOfKinName";
            this.txtNextOfKinName.Size = new System.Drawing.Size(319, 20);
            this.txtNextOfKinName.TabIndex = 1;
            this.txtNextOfKinName.Visible = false;
            // 
            // txtRelationship
            // 
            this.txtRelationship.BackColor = System.Drawing.Color.Yellow;
            this.txtRelationship.Location = new System.Drawing.Point(178, 105);
            this.txtRelationship.Name = "txtRelationship";
            this.txtRelationship.Size = new System.Drawing.Size(319, 20);
            this.txtRelationship.TabIndex = 21;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(48, 108);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(65, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "Relationship";
            // 
            // NextOfKinAssign
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 215);
            this.Controls.Add(this.txtRelationship);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbNextOfKinName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNextOfKinName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NextOfKinAssign";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Assign Next of Kin";
            this.Load += new System.EventHandler(this.AddDoctor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnClose;
        public System.Windows.Forms.ComboBox cmbNextOfKinName;
        public System.Windows.Forms.Button btnAdd;
        public System.Windows.Forms.TextBox txtRelationship;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.ErrorProvider ep;
        public System.Windows.Forms.TextBox txtNextOfKinName;
    }
}