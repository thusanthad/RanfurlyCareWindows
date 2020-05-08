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
    public partial class EthnicityEdit : Form
    {
        protected List<Ethnicity> _changes;
        protected List<Ethnicity> _list;
        public EthnicityEdit()
        {
            InitializeComponent();
            _changes = new List<Ethnicity>();
            PopulateEthnicity();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void PopulateEthnicity()
        {
            EthnicityData db =  new EthnicityData();
            _list = db.GetList();
            dgEthnicity.AutoGenerateColumns = false;
            dgEthnicity.DataSource =_list;
        }

        private void addEthnicityToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EthnicityAdd ed = new EthnicityAdd();
            ed.ShowDialog();
            if (ed.DialogResult == DialogResult.OK)
            {
                PopulateEthnicity();
            }
                
        }

        private void dgEthnicity_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Ethnicity ethnicity = _list[e.RowIndex];
                _changes.Add(ethnicity);
            }
        }

        private void EthnicityEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_changes.Count > 0)
            {
                EthnicityData ed = new EthnicityData();
                ed.Update(_changes);

                if (Application.OpenForms["StudentAddEdit"] as StudentAddEdit != null)
                {
                    StudentAddEdit frm1 = (StudentAddEdit)Application.OpenForms["StudentAddEdit"];
                    frm1.PopulateEthnicityComboBox();
                }
            }
        }

        //private void dgEthnicity_Validated(object sender, EventArgs e)
        //{

        //}

        //private void dgEthnicity_RowValidated(object sender, DataGridViewCellEventArgs e)
        //{



        //}
    }
}
