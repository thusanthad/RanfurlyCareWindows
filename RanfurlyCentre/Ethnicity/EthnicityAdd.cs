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
    public partial class EthnicityAdd : Form
    {
        public EthnicityAdd()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if (txtEthnicity.Text != string.Empty)
            {
                EthnicityData ed = new EthnicityData();                
                int ethnicityId = ed.Add(new Ethnicity { EthnicityName = txtEthnicity.Text });
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                ep.SetError(txtEthnicity, "Type ethnicity");
            }

        }
    }
}
