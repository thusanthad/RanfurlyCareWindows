using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyCentre
{
    public class PastAppointmentClass : AppointmentSearchClassBase
    {
        public PastAppointmentClass(AppointmentSearch frm):base(frm)
        {
            _frm.lblFrom.Visible = true;
            _frm.lblTo.Visible = true;
            _frm.dtpFrom.Visible = true;
            _frm.dtpTo.Visible = true;           
        }

        public override void SetDataSource()
        {
            _sql = "SELECT * FROM vw_Appointments WHERE AppointmentDate Between #" + _frm.dtpFrom.Value.ToString("MM/dd/yyyy") + "# AND #" +_frm.dtpTo.Value.ToString("MM/dd/yyyy") + "# AND IsClosed=true";
            base.SetDataSource();
        }

        //public override void SetSortDataSource()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
 