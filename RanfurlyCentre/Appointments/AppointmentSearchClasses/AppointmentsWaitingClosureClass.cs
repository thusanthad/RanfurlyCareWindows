using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyCentre
{
    public class AppointmentsWaitingClosureClass : AppointmentSearchClassBase
    {
        public AppointmentsWaitingClosureClass(AppointmentSearch frm):base(frm)
        {

        }

        public override void SetDataSource()
        {
            _sql = "SELECT * FROM vw_Appointments WHERE AppointmentDate <#" + DateTime.Today.ToString("dd/MM/yyyy") + "# AND IsClosed=false";
            base.SetDataSource();
        }

        //public override void SetSortDataSource()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
