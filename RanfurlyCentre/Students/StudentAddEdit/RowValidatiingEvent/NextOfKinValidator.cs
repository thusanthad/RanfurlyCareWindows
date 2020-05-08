using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RanfurlyCentre
{
    public class NextOfKinValidator : DatagridViewRowValidatorBase
    {        
        public NextOfKinValidator(object sender, DataGridViewCellCancelEventArgs ee) :base(sender,ee)
        {
            //Validate();
        }

        public override void Validate()
        {
            foreach (DataGridViewCell cell in DgvRow.Cells)
            {
                if (cell.Value == null && cell.OwningColumn.HeaderText != "Addr4" && cell.OwningColumn.HeaderText != "Email")
                {
                    DgvRow.ErrorText = "Type " + cell.OwningColumn.HeaderText;
                    //dgEmergencyContact.CurrentCell = dgvRow.Cells[cell.OwningColumn.Name];
                    e.Cancel = true;
                    break;
                }
            }


        }

    }
}
