using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RanfurlyBusiness;

namespace TreeViewExample
{
    public partial class AddNewIncident : Form
    {
        //public StudentIncidentLog Incident { get; set; }
        public AddNewIncident()
        {
            InitializeComponent();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(ValidateInput())
            {
                //Incident = new StudentIncidentLog
                    {
                        //StudentId=Convert.ToInt16(txtStudentId.Text),
                        //IncidentDate=dtp.Value,
                        //Description=txtDescription.Text,
                        //FileLocation=txtFileLocation.Text,
                        //FileName=txtFileName.Text
                    };
                this.DialogResult = DialogResult.OK;
            }
        }

        private void textBox3_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void textBox3_DragDrop(object sender, DragEventArgs e)
        {
            ep.Clear();
            var files = e.Data.GetData(DataFormats.FileDrop);
            string[] droppedFiles = (string[])files;

            try
            {

                if (droppedFiles.Length > 0)
                {
                    //DataFile df1 = new DataFile(droppedFiles[0]);
                    //txtFileLocation.Text = df1.FolderName;
                    //txtFileName.Text = df1.FileName;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Output files", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidateInput()
        {
            ep.Clear();
            int errorCount = 0;
            if (txtStudentId.Text == string.Empty)
            {
                ep.SetError(txtStudentId, "Please select student");
                errorCount += 1;
            }
            if (txtDescription.Text == string.Empty)
            {
                ep.SetError(txtDescription, "Please type description");
                errorCount += 1;
            }
            if (!dtp.Checked)
            {
                ep.SetError(dtp, "Please select date");
                errorCount += 1;
            }
            if (txtFileLocation.Text == string.Empty)
            {
                ep.SetError(txtFileLocation, "Please drag and drop a file");
                errorCount += 1;
            }
            if (txtFileName.Text == string.Empty)
            {
                ep.SetError(txtFileName, "Please drag and drop a file");
                errorCount += 1;
            }

            return errorCount == 0;
        }
    }
}
