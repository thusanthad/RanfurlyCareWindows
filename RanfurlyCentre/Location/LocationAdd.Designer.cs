namespace RanfurlyCentre
{
    partial class LocationAdd
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
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtLocation = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ep = new System.Windows.Forms.ErrorProvider(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.txtAbbreviation = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFullAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.chkIsResidence = new System.Windows.Forms.CheckBox();
            this.chkIsStudentCentre = new System.Windows.Forms.CheckBox();
            this.chkIsRollCall = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRollReference = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.ep)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.ForeColor = System.Drawing.Color.Maroon;
            this.btnAdd.Location = new System.Drawing.Point(163, 286);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtLocation
            // 
            this.txtLocation.Location = new System.Drawing.Point(150, 32);
            this.txtLocation.Name = "txtLocation";
            this.txtLocation.Size = new System.Drawing.Size(222, 20);
            this.txtLocation.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(73, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Location:";
            // 
            // ep
            // 
            this.ep.ContainerControl = this;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(57, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Abbreviation:";
            // 
            // txtAbbreviation
            // 
            this.txtAbbreviation.Location = new System.Drawing.Point(150, 58);
            this.txtAbbreviation.Name = "txtAbbreviation";
            this.txtAbbreviation.Size = new System.Drawing.Size(222, 20);
            this.txtAbbreviation.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Full Address:";
            // 
            // txtFullAddress
            // 
            this.txtFullAddress.Location = new System.Drawing.Point(150, 84);
            this.txtFullAddress.Name = "txtFullAddress";
            this.txtFullAddress.Size = new System.Drawing.Size(222, 20);
            this.txtFullAddress.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(63, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Telephone:";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Location = new System.Drawing.Point(150, 110);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(222, 20);
            this.txtTelephone.TabIndex = 7;
            // 
            // chkIsResidence
            // 
            this.chkIsResidence.AutoSize = true;
            this.chkIsResidence.Location = new System.Drawing.Point(150, 147);
            this.chkIsResidence.Name = "chkIsResidence";
            this.chkIsResidence.Size = new System.Drawing.Size(88, 17);
            this.chkIsResidence.TabIndex = 9;
            this.chkIsResidence.Text = "Is Residence";
            this.chkIsResidence.UseVisualStyleBackColor = true;
            // 
            // chkIsStudentCentre
            // 
            this.chkIsStudentCentre.AutoSize = true;
            this.chkIsStudentCentre.Location = new System.Drawing.Point(150, 170);
            this.chkIsStudentCentre.Name = "chkIsStudentCentre";
            this.chkIsStudentCentre.Size = new System.Drawing.Size(108, 17);
            this.chkIsStudentCentre.TabIndex = 10;
            this.chkIsStudentCentre.Text = "Is Student Centre";
            this.chkIsStudentCentre.UseVisualStyleBackColor = true;
            // 
            // chkIsRollCall
            // 
            this.chkIsRollCall.AutoSize = true;
            this.chkIsRollCall.Location = new System.Drawing.Point(150, 193);
            this.chkIsRollCall.Name = "chkIsRollCall";
            this.chkIsRollCall.Size = new System.Drawing.Size(75, 17);
            this.chkIsRollCall.TabIndex = 11;
            this.chkIsRollCall.Text = "Is Roll Call";
            this.chkIsRollCall.UseVisualStyleBackColor = true;
            this.chkIsRollCall.CheckedChanged += new System.EventHandler(this.chkIsRollCall_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Roll Call Refrencee:";
            // 
            // txtRollReference
            // 
            this.txtRollReference.Enabled = false;
            this.txtRollReference.Location = new System.Drawing.Point(150, 227);
            this.txtRollReference.Name = "txtRollReference";
            this.txtRollReference.Size = new System.Drawing.Size(222, 20);
            this.txtRollReference.TabIndex = 12;
            // 
            // LocationAdd
            // 
            this.AcceptButton = this.btnAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 363);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtRollReference);
            this.Controls.Add(this.chkIsRollCall);
            this.Controls.Add(this.chkIsStudentCentre);
            this.Controls.Add(this.chkIsResidence);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFullAddress);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtAbbreviation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLocation);
            this.Controls.Add(this.btnAdd);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocationAdd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Location";
            ((System.ComponentModel.ISupportInitialize)(this.ep)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider ep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAbbreviation;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtFullAddress;
        private System.Windows.Forms.CheckBox chkIsRollCall;
        private System.Windows.Forms.CheckBox chkIsStudentCentre;
        private System.Windows.Forms.CheckBox chkIsResidence;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRollReference;
    }
}