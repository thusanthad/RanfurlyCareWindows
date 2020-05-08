using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace RanfurlyBusiness
{
    public class SpecialistAppointment : AppointmentBase
    {
        public Specialist Specialist { get; set; }
        public int SpecialistId { get; set; }


        //public override void UpdateDisplayNames()
        //{
        //    SpecialistDisplayName = Specialist.FullName;
        //}
    }
}
