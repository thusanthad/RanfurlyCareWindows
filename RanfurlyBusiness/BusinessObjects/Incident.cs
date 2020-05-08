using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyBusiness
{
    public class Incident
    {
        public int IncidentId { get; set; }
        public Student Student { get; set; }
        public Staff Staff { get; set; }
        public string Description { get; set; }
        public DateTime IncidentDate { get; set; }
        public string IncidentHour { get; set; }
        public string IncidentMinute { get; set; }
        public string AmPm { get; set; }
        public string FileLocation { get; set; }
        public string FileName { get; set; }
        public string Comments { get; set; }
        public string PersonFullName { get; set; }
        public Staff WhoReported { get; set; }
        public Staff Coordinator { get; set; }
        public Staff Manager { get; set; }
        public Staff HealthAnSafetyOfficer { get; set; }
        public Location Location { get; set; }
        public string WhoReportedName { get; set; }
        public string LocationName { get; set; }
        public string CoordinatorName { get; set; }
        public string ManagerName { get; set; }
        public string HealthAndSafetyOfficerName { get; set; }
        public string IncidentFullTime { get; set; }

        //public string IncidentType { get; set; }
        public IncidentTypeEnum IncidentType { get; set; }

        public Incident()
        {
            Location = new Location();
            WhoReported = new Staff();
            Coordinator = new Staff();
            Manager = new Staff();
            HealthAnSafetyOfficer = new Staff();
        }

        public enum IncidentTypeEnum
        {
            All,
            StaffAndStudent,
            Student,
            Staff,
            Other
        }

        public void UpdateIncidentType()
        {
            if (Student != null & Staff != null)
                IncidentType = IncidentTypeEnum.StaffAndStudent;// "Staff and Student";
            else if (Student != null)
                IncidentType = IncidentTypeEnum.Student;// "Student";
            else if (Staff != null)
                IncidentType = IncidentTypeEnum.Staff;// "Staff";
            else
                IncidentType = IncidentTypeEnum.Other;// "Other";
        }

        public void UpdatePersonFullName()
        {
            List<string> fullName = new List<string>();
            if (IncidentType == IncidentTypeEnum.StaffAndStudent)
            {
                fullName.Add(Staff.GetFullName());
                fullName.Add(Student.FullName);
                PersonFullName = String.Join(", ", fullName.ToArray());
            }
            else if (IncidentType == IncidentTypeEnum.Staff)
            {                
                PersonFullName = Staff.GetFullName();
            }
            else if (IncidentType == IncidentTypeEnum.Student)
            {
                PersonFullName = Student.FullName;
            }
        }

        public void UpdateNames()
        {
            LocationName = Location.Abbreviation;
            WhoReportedName = WhoReported.GetFullName();
            CoordinatorName = Coordinator.GetFullName();
            ManagerName = Manager.GetFullName();
            HealthAndSafetyOfficerName = HealthAnSafetyOfficer.GetFullName();
        }

        public void AppendFullTime()
        {
            IncidentFullTime = IncidentHour + ":" + IncidentMinute + " " + AmPm;            
        }

        public void Update()
        {

            
        }

        public void Add()
        {


        }

        public void Remove()
        {


        }
    }
}
