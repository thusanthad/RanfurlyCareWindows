using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class ActiveAppointmentsClass:AppointmentSearchClassBase
    {
        public ActiveAppointmentsClass(AppointmentSearch frm):base(frm)
        {
           
        }

        public override void SetDataSource()
        {
            _sql = "SELECT * FROM vw_Appointments WHERE AppointmentDate >=#" + DateTime.Today.ToString("dd/MM/yyyy") + "#";
            base.SetDataSource();
            //EnableIndexChangedEvents();
        }

        //public override void SetSortDataSource()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
