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
    public partial class StaffWorkCentreAllocation : Form
    {
        protected WorkCentreAllocateRemoveBase wcalb;
        public StaffWorkCentreAllocation(Staff staff,string allocateType)
        {
            InitializeComponent();
            if (allocateType == "allocate")
                wcalb = new WorkCentreAllocate(this, staff);
            else
                wcalb = new WorkCentreRemove(this, staff);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAllocate_Click(object sender, EventArgs e)
        {
            wcalb.CommitAction();            
            this.DialogResult = DialogResult.OK;
        }

        //private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    wcalb.CommitAction();
        //}
    }
}
