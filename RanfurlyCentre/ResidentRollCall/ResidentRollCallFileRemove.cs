using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public partial class ResidentRollCallFileRemove : Form
    {
        public ResidentRollCallFileRemove()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        private void Search()
        {
            if (IsValidated())
            {
                try
                {
                    ResidentRollCallData data = new ResidentRollCallData();
                    List<ResidentRollCallFileLog> list = data.GetImportFiles(cmbMonth.Text, cmbYear.Text);
                    ListBox listBox = (ListBox)lstFiles;
                    listBox.DataSource = list;
                    listBox.DisplayMember = "FileName";
                    listBox.ValueMember = "ResidentRollCallImportId";
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (this.lstFiles.CheckedItems.Count > 0)
            {
                if (MessageBox.Show("All records will be removed from the seleted file(s) Are you sure you want to proceed?", "Remove files", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    bool filesRemoved = false;
                    foreach (object item in this.lstFiles.CheckedItems)
                    {
                        ResidentRollCallFileLog file = (ResidentRollCallFileLog)item;
                        file.RemoveFile();
                        filesRemoved = true;                        
                    }

                    if (filesRemoved)
                    {
                        MessageBox.Show("Selected file(s) removed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ListBox listBox = (ListBox)lstFiles;
                        listBox.DataSource = null;
                    }
                        
                }
            }
        }

        private void ResidentRollCallFileRemove_Load(object sender, EventArgs e)
        {
            //SetComboBoxDefaults();
        }

        private bool IsValidated()
        {
            int errors = 0;
            ep.Clear();
            if (cmbMonth.SelectedIndex == -1)
            {
                ep.SetError(cmbMonth, "Select Month");
                errors += 1;
            }
                
            if (cmbYear.SelectedIndex == -1)
            {
                ep.SetError(cmbYear, "Select Year");
                errors += 1;
            }
            return errors == 0;
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            Search();
        }
    }
}
