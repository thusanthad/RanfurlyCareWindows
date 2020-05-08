using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RanfurlyCentre
{
    public class PersonalCareValidator : DatagridViewRowValidatorBase
    {        
        public PersonalCareValidator(object sender, DataGridViewCellCancelEventArgs ee) :base(sender,ee)
        {
            //Validate();
        }

        public override void Validate()
        {
            if (DgvRow.Cells[1].Value == null || DgvRow.Cells[1].Value.ToString() == string.Empty)
            {
                DgvRow.ErrorText = "Please select frequency";
                e.Cancel = true;
            }
            else if (DgvRow.Cells[2].Value == null || DgvRow.Cells[2].Value.ToString() == string.Empty)
            {
                DgvRow.ErrorText = "Please enter item";
                e.Cancel = true;
            }
            else if (DgvRow.Cells[3].Value == null || DgvRow.Cells[3].Value.ToString() == string.Empty)
            {
                DgvRow.ErrorText = "Please enter assistance";
                e.Cancel = true;
            }
            //else if (DgvRow.Cells[2].Value.ToString() == "N/A" || DgvRow.Cells[3].Value.ToString() == "N/A")
            //{
            //    DgvRow.ErrorText = "N/A is not acceptable on manadatory field";
            //    e.Cancel = true;
            //}
            
        }

    }
}
