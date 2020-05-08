using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;

namespace RanfurlyBusiness
{
    public class AppointmentData
    {
        protected DBCommand dbc;

        public AppointmentData(DBCommand dbCommand)
        {
            dbc = dbCommand;
        }

        public AppointmentData()
        {
            dbc = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
        }

        public List<AppointmentBase> GetList(string sql)
        {
            List<AppointmentBase> appointments = new List<AppointmentBase>();
            DataTable dt = dbc.GetDataTable(sql);
            dbc.CloseConnection();

            foreach (DataRow dr in dt.Rows)
            {
                appointments.Add(GetAppointment(dr));
            }
            return appointments;
        }

        //public List<AppointmentBase> GetList()
        //{
        //    List<AppointmentBase> appointments = new List<AppointmentBase>();
        //    DataTable dt = dbc.GetDataTable("SELECT * FROM vw_Appointments");
        //    dbc.CloseConnection();

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        appointments.Add(GetAppointment(dr));
        //    }
        //    return appointments;
        //}

        public List<AppointmentBase> GetList(int PersonId)
        {
            List<AppointmentBase> appointments = new List<AppointmentBase>();
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_Incidents WHERE StudentId=" + PersonId);
            dbc.CloseConnection();

            foreach (DataRow dr in dt.Rows)
            {               
                appointments.Add(GetAppointment(dr));
            }
            return appointments;
        }

        private AppointmentBase GetAppointment(DataRow dr)
        {
            AppointmentBase ap;// = new Incident();
            if (dr["DoctorId"].ToString() != string.Empty)
            {
                ap = new DoctorAppointment();
                ((DoctorAppointment)ap).Doctor = GetDoctor((int)dr["DoctorId"]);
                ((DoctorAppointment)ap).KeyCode = dr["KeyCode"].ToString();
                ap.AppointmentType = "Doctor";

            } 
            else
            {
                ap = new SpecialistAppointment();
                Specialist specialist = GetSpecialist((int)dr["Specialistid"]);
                ((SpecialistAppointment)ap).Specialist = specialist;
                ap.AppointmentType = specialist.SpecialistType;
            }

            ap.AmPm = dr["AMPM"].ToString();
            ap.AppointmentId= (int)dr["AppointmentId"];
            ap.ProfessionalServiceProviderTypeId = (int)dr["ProfessionalServiceProviderTypeId"];            
            ap.AppointmentDate = (DateTime)dr["AppointmentDate"];
            ap.IsFollowupNeeded = (bool)dr["IsFollowupNeeded"];
            ap.AppointmentHour=dr["AppointmentHour"].ToString();
            ap.AppointmentMinute= dr["AppointmentMinute"].ToString();
            ap.FurtherTreatmentRequired = dr["FurtherTreatmentRequired"].ToString();
            ap.TreatmentReceived= dr["TreatmentReceived"].ToString();
            ap.StaffAccompanying = GetStaffAccompanying((int)dr["StaffId"]);
            ap.IsInHouseAppointment = (bool)dr["IsInHouseAppointment"];
            ap.IsClosed = (bool)dr["IsClosed"];
            ap.Purpose = dr["Purpose"].ToString();
            ap.Comments = dr["Comments"].ToString();
            ap.StaffAccompanying = GetStaffAccompanying((int)dr["StaffId"]);
            ap.Student = GetStudent((int)dr["StudentId"]);
            ap.UpdateDisplayNames();
            return ap;
        }

        private Doctor GetDoctor(int doctorId)
        {
            DoctorData dd = new DoctorData();
            List<Person> doctors = dd.GetList();
            Person person = doctors.Find(x => x.PersonId == doctorId);
            person.FirstName = person.GetFullName();
            person.FullAddress = person.GetFullAddress();
            return (Doctor)person;
        }

        private Specialist GetSpecialist(int specialistId)
        {
            SpecialistData sd = new SpecialistData();
            List<Person> specialists = sd.GetList();
            Person person = specialists.Find(x => x.PersonId == specialistId);
            person.FirstName = person.GetFullName();
            person.FullAddress = person.GetFullAddress();
            return (Specialist)person;
        }

        private Staff GetStaffAccompanying(int personId)
        {
            StaffData sd = new StaffData();
            List<Person> specialists = sd.GetList();
            Person person = specialists.Find(x => x.PersonId == personId);
            person.FirstName = person.GetFullName();
            return (Staff)person;
        }

        private Student GetStudent(int personId)
        {
            StudentData sd = new StudentData();
            List<Person> specialists = sd.GetList();
            Person person = specialists.Find(x => x.PersonId == personId);
            person.FirstName = person.GetFullName();
            return (Student)person;
        }

        public void Update(AppointmentBase ap)
        {
            CommonFunctions.UpdateApostrophe(ap);
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Appointment SET ");
            sb.Append("StudentId=" + ap.Student.PersonId);
            sb.Append(",StaffId=" + ap.StaffAccompanying.PersonId);
            if (ap is DoctorAppointment)
            {
                sb.Append(",DoctorId=" + ((DoctorAppointment)ap).Doctor.PersonId);
                sb.Append(",SpecialistId=null");
                sb.Append(",KeyCode='" + ((DoctorAppointment)ap).KeyCode + "'");
            }
            else
            {
                sb.Append(",DoctorId=null");
                sb.Append(",SpecialistId=" + ((SpecialistAppointment)ap).Specialist.PersonId);
                sb.Append(",KeyCode=null");
            }
            sb.Append(",AppointmentDate='" + ap.AppointmentDate.ToString("dd/MM/yyyy") + "'");
            sb.Append(",AppointmentHour='" + ap.AppointmentHour + "'");
            sb.Append(",AppointmentMinute='" + ap.AppointmentMinute + "'");
            sb.Append(",AmPm='" + ap.AmPm + "'");
            sb.Append(",IsFollowupNeeded=" + ap.IsFollowupNeeded);
            sb.Append(",IsInHouseAppointment=" + ap.IsInHouseAppointment);
            sb.Append(",ProfessionalServiceProviderTypeId=" + ap.ProfessionalServiceProviderTypeId);           
            sb.Append(",Purpose='" + ap.Purpose + "'");
            if (ap.Comments != null && ap.Comments != string.Empty)
                sb.Append(",Comments='" + ap.Comments + "'");
            else
                sb.Append(",Comments=null");

            sb.Append(" WHERE AppointmentId =" + ap.AppointmentId);
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }

        public void Add(AppointmentBase ap)
        {
            CommonFunctions.UpdateApostrophe(ap);
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Appointment (StudentId,StaffId,DoctorId,SpecialistId,KeyCode,AppointmentDate,AppointmentHour,AppointmentMinute,AMPM,IsFollowupNeeded,IsInHouseAppointment,Purpose,Comments,ProfessionalServiceProviderTypeId) VALUES (");
            sb.Append(ap.Student.PersonId);
            sb.Append(","+ap.StaffAccompanying.PersonId);
            if(ap is DoctorAppointment)
            {
                sb.Append("," + ((DoctorAppointment)ap).Doctor.PersonId);
                sb.Append(",null");
                sb.Append(",'" + ((DoctorAppointment)ap).KeyCode +"'");
            }
            else
            {
                sb.Append(",null");
                sb.Append("," + ((SpecialistAppointment)ap).Specialist.PersonId);
                sb.Append(",null");
            }
            sb.Append(",'" + ap.AppointmentDate.ToString("dd/MM/yyyy") + "'");
            sb.Append(",'" + ap.AppointmentHour + "'");
            sb.Append(",'" + ap.AppointmentMinute + "'");
            sb.Append(",'" + ap.AmPm + "'");            
            sb.Append("," + ap.IsFollowupNeeded);
            sb.Append("," + ap.IsInHouseAppointment);
            sb.Append(",'" + ap.Purpose + "'");
            if (ap.Comments !=null && ap.Comments != string.Empty)
                sb.Append(",'" + ap.Comments + "'");
            else
                sb.Append(",null");
            sb.Append("," + ap.ProfessionalServiceProviderTypeId);
            sb.Append(")");
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }

        public void Remove(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM Appointment WHERE AppointmentId=" + id);      
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }
    }
}