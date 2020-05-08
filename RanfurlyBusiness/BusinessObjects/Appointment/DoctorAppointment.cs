using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace RanfurlyBusiness
{
    public class DoctorAppointment:AppointmentBase
    {
        public Doctor Doctor { get; set; }
        public string KeyCode { get; set; }
        public int DoctorId { get; set; }


        public enum VistType
        {
            Infection,
            AnnualCheckUp,
            Accident,
            Consulation,
            MedicalReview,
            Treatment,
            AntibioticsPrescribed,
            Vaccination,
            AnyOther
        }

        //public override void UpdateDisplayNames()
        //{
        //    if(this is DoctorAppointment)
        //    {
        //        DoctorAppointment da = (DoctorAppointment)this;
        //        SpecialistDisplayName = da.Doctor.FullName;
        //    }                
        //    else if (this is SpecialistAppointment)
        //    {

        //    }

        //    ResidentDisplayName = Student.FullName;
        //    StaffDisplayName = StaffAccompanying.FullName;
        //}
    }
}
