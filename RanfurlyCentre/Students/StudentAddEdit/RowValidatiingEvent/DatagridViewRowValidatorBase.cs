using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RanfurlyCentre
{
    public abstract class DatagridViewRowValidatorBase
    {
        protected DataGridViewRow DgvRow;
        protected DataGridViewCellCancelEventArgs e;
        public abstract void Validate();
        public DatagridViewRowValidatorBase(object sender, DataGridViewCellCancelEventArgs ee)
        {
            DataGridView dgv = (DataGridView)sender;
            if (ee.RowIndex != -1 && !dgv.Rows[ee.RowIndex].IsNewRow)
            {
                DgvRow = dgv.Rows[ee.RowIndex];
                e = ee;
                DgvRow.ErrorText = "";
                Validate();
            }
                
        }

    }
}
