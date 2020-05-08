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
    public partial class WorkCentreAdd : Form
    {
        public WorkCentreAdd()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if (txtWorkCentre.Text != string.Empty && txtAbbreviation.Text != string.Empty)
            {
                try { 
                    WorkCentreData ed = new WorkCentreData();                
                    int ethnicityId = ed.Add(new WorkCentre { WorkCentreName = txtWorkCentre.Text, Abbreviation = txtAbbreviation.Text });
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }
            else
            {
                if (txtWorkCentre.Text == string.Empty)
                    ep.SetError(txtWorkCentre, "Type Workcentre name");
                if (txtAbbreviation.Text == string.Empty)
                    ep.SetError(txtAbbreviation, "Type Abbreviation");
            }

        }
    }
}
