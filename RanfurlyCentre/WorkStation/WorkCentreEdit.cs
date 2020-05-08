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
    public partial class WorkCentreEdit : Form
    {
        protected List<WorkCentre> _list;
        public WorkCentreEdit()
        {
            InitializeComponent();
            PopulateWorkCentres();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PopulateWorkCentres()
        {
            try
            {
                WorkCentreData db =  new WorkCentreData();
            _list = db.GetList();
            dgWorkCentre.AutoGenerateColumns = false;
            dgWorkCentre.DataSource = _list;
            dgWorkCentre.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addEthnicityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                WorkCentreAdd ed = new WorkCentreAdd();
                ed.ShowDialog();
                if (ed.DialogResult == DialogResult.OK)
                    PopulateWorkCentres();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }           
        }
    }
}
