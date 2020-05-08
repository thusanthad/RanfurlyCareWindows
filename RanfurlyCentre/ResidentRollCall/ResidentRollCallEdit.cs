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
    public partial class ResidentRollCallEdit : Form
    {
        protected List<ResidentRollCall> _rollCallList;
        public ResidentRollCallEdit(List<ResidentRollCall>rollCallList)
        {
            InitializeComponent();
             _rollCallList= rollCallList;
        }

        private void ResidentRollCallEdit_Load(object sender, EventArgs e)
        {
            dgRollCallData.AutoGenerateColumns = false;
            dgRollCallData.DataSource = _rollCallList;
        }

        private void LoadData()
        {
           

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           // ep.Clear();
            try
            {
                foreach (ResidentRollCall call in _rollCallList)
                {
                    call.Update();
                    this.DialogResult = DialogResult.OK;                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
