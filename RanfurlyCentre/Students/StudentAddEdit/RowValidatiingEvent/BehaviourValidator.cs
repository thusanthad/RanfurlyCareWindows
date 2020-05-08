using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RanfurlyCentre
{
    public class BehaviourValidator : DatagridViewRowValidatorBase
    {        
        public BehaviourValidator(object sender, DataGridViewCellCancelEventArgs ee) :base(sender,ee)
        {
            //Validate();
        }

        public override void Validate()
        {
            if (DgvRow.Cells[1].Value == null || DgvRow.Cells[1].Value.ToString() == string.Empty)
            {
                DgvRow.ErrorText = "Please eneter profile";
                e.Cancel = true;
            }
            else if (DgvRow.Cells[2].Value == null || DgvRow.Cells[2].Value.ToString() == string.Empty)
            {
                DgvRow.ErrorText = "Please enter communication";
                e.Cancel = true;
            }
            else if (DgvRow.Cells[3].Value == null || DgvRow.Cells[3].Value.ToString() == string.Empty)
            {
                DgvRow.ErrorText = "Please enter behaviour";
                e.Cancel = true;
            }
            else if (DgvRow.Cells[4].Value == null || DgvRow.Cells[4].Value.ToString() == string.Empty)
            {
                DgvRow.ErrorText = "Please select strategy plan";
                e.Cancel = true;
            }

        }

    }
}
