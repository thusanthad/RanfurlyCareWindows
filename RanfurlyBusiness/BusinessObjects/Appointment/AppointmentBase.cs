using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace RanfurlyBusiness
{
    public abstract class AppointmentBase//:IProperty
    {
        //public abstract void UpdateDisplayNames();

        public int AppointmentId { get; set; }
        public DateTime AppointmentDate { get; set; }
        public Student Student { get; set; }
        public Staff StaffAccompanying { get; set; }
        //public int StudentId { get; set; }
        //public int StaffId { get; set; }
        public string AppointmentHour { get; set; }
        public string AppointmentMinute { get; set; }
        public string AmPm { get; set; }
        public string Purpose { get; set; }
        public bool IsFollowupNeeded  { get; set; }
        public DateTime AppointmentCloseDate { get; set; }
        public bool IsInHouseAppointment { get; set; }        
        public string TreatmentReceived { get; set; }
        public string FurtherTreatmentRequired  { get; set; }
        public bool IsClosed { get; set; }
        public string Comments { get; set; }
        public string AppointmentType { get; set; }
        public string SpecialistDisplayName { get; set; }
        public string ResidentDisplayName { get; set; }
        public string StaffDisplayName { get; set; }
        public string AppointmentTime { get; set; }
        public string ServiceProviderAddress { get; set; }
        public string ServiceProviderTelephone { get; set; }
        public int ProfessionalServiceProviderTypeId { get; set; }

        //public AppointmentBase()
        //{
        //    Student = new Student();
        //    StaffAccomnaying = new Staff();
        //}

        public virtual void UpdateDisplayNames()
        {
            if (this is DoctorAppointment)
            {
                DoctorAppointment da = (DoctorAppointment)this;
                SpecialistDisplayName = da.Doctor.FullName;
                AppointmentType = "Doctor";
                ServiceProviderAddress = da.Doctor.FullAddress;
                ServiceProviderTelephone = da.Doctor.Phone;
            }
            else if (this is SpecialistAppointment)
            {
                SpecialistAppointment sa = (SpecialistAppointment)this;
                SpecialistDisplayName = sa.Specialist.FullName;
                AppointmentType = sa.Specialist.SpecialistType;
                ServiceProviderAddress = sa.Specialist.FullAddress;
                ServiceProviderTelephone = sa.Specialist.Phone;
            }

            ResidentDisplayName = Student.FullName;
            StaffDisplayName = StaffAccompanying.FullName;
            AppointmentTime = AppointmentHour + ":" + AppointmentMinute + ":" + AmPm;
        }

        public void Delete()
        {
            if (!IsClosed)
            {
                AppointmentData data = new AppointmentData();
                data.Remove(AppointmentId);
            }
            else
                throw new Exception("Appointment closed, cannot delete");
           
        }

        public void Save()
        {
            AppointmentData data = new AppointmentData();
            if (this.AppointmentId == 0)
                data.Add(this);
            else
                data.Update(this);
        }
    }
}
