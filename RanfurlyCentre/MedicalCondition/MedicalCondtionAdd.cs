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
    public partial class MedicalCondtionAdd : Form
    {
        protected StudentAddEditBaseClass _saeb;
        public MedicalCondtionAdd(StudentAddEditBaseClass saeb)
        {
            InitializeComponent();
            _saeb = saeb;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ep.Clear();
            if (txtMedicalCondition.Text == string.Empty)
            {
                ep.SetError(txtMedicalCondition, "Type medical condition");
                return;
            }
            else
            {
                MedicalCondition mc = new MedicalCondition();
                mc.StudentMedicalConditionId = 0;
                mc.MedicalConditionName = txtMedicalCondition.Text;
                _saeb.Add(mc);
                this.DialogResult = DialogResult.OK;
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
