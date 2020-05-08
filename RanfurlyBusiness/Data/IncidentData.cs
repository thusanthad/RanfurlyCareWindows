using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;

namespace RanfurlyBusiness
{
    public class IncidentData
    {
        protected DBCommand dbc;

        public IncidentData(DBCommand dbCommand)
        {
            dbc = dbCommand;
        }

        public IncidentData()
        {
            dbc = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
        }

        public List<Incident> GetList()
        {
            List<Incident> Incidents = new List<Incident>();
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_Incidents");
            dbc.CloseConnection();

            foreach (DataRow dr in dt.Rows)
            {
                Incidents.Add(GetIncident(dr));
            }
            return Incidents;
        }

        public List<Incident> GetList(int PersonId)
        {
            List<Incident> Incidents = new List<Incident>();
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_Incidents WHERE StudentId=" + PersonId);
            dbc.CloseConnection();

            foreach (DataRow dr in dt.Rows)
            {               
                Incidents.Add(GetIncident(dr));
            }
            return Incidents;
        }

        private Incident GetIncident(DataRow dr)
        {
            Incident incident = new Incident();
            incident.IncidentId = (int)dr["IncidentId"];
            List<string> fullName = new List<string>(); 
            if (dr["StudentId"].ToString() != string.Empty)
            {                
                int studentId = (int)dr["StudentId"];
                incident.Student = GetStudent(studentId);
                if(incident.Student!=null)
                    fullName.Add(incident.Student.GetFullName());
                //incident.PersonFullName = incident.Student.GetFullName();
            }

            if (dr["StaffId"].ToString() != string.Empty)
            {
                int staffId  = (int)dr["StaffId"];               
                incident.Staff = GetStaff(staffId);
                if (incident.Staff != null)
                    fullName.Add(incident.Staff.GetFullName());
                //incident.PersonFullName = incident.Staff.GetFullName();
            }

            incident.WhoReported = GetStaff((int)dr["WhoReportedId"]);
            incident.Coordinator = GetStaff((int)dr["CoordinatorId"]);
            incident.Manager = GetStaff((int)dr["ManagerId"]);
            incident.HealthAnSafetyOfficer = GetStaff((int)dr["HealthAndSafetyOfficerId"]);
            incident.Location = GetLocation((int)dr["LocationId"]);
            //incident.PersonFullName = String.Join(", ", fullName.ToArray());
            incident.PersonFullName = dr["PersonFullName"].ToString();
            incident.IncidentDate = (DateTime)dr["IncidentDate"];
            incident.IncidentHour = dr["IncidentHour"].ToString();
            incident.IncidentMinute = dr["IncidentMinute"].ToString();
            incident.AmPm = dr["AmPm"].ToString();
            incident.Description = dr["Description"].ToString();
            incident.FileLocation = dr["FileLocation"].ToString();
            incident.FileName = dr["FileName"].ToString();
            incident.Comments = dr["Comments"].ToString();            
            incident.UpdateIncidentType();
            incident.AppendFullTime();
            incident.UpdateNames();


            return incident;
        }

        public void Update(Incident incident)
        {
            CommonFunctions.UpdateApostrophe<Incident>(incident);
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Incident SET ");
            sb.Append("PersonFullName='" + incident.PersonFullName + "'");
            sb.Append(",IncidentDate='" + incident.IncidentDate.ToString("dd/MM/yyyy") + "'");
            sb.Append(",IncidentHour='" + incident.IncidentHour + "'");
            sb.Append(",IncidentMinute='" + incident.IncidentMinute + "'");
            sb.Append(",AmPm='" + incident.AmPm + "'");
            sb.Append(",Description='" + incident.Description + "'");
            sb.Append(",FileLocation='" + incident.FileLocation + "'");
            sb.Append(",FileName='" + incident.FileName + "'");
            if(incident.Comments!=string.Empty)
                sb.Append(",Comments='" + incident.Comments + "'");
            else
                sb.Append(",Comments=null");
            sb.Append(",LocationId=" + incident.Location.LocationId);
            sb.Append(",WhoReportedId=" + incident.WhoReported.PersonId);
            sb.Append(",ManagerId=" + incident.Manager.PersonId);
            sb.Append(",CoordinatorId=" + incident.Coordinator.PersonId);
            sb.Append(",HealthAndSafetyOfficerId=" + incident.HealthAnSafetyOfficer.PersonId);
            
            if (incident.Staff!=null)
            {
                sb.Append(",StaffId=" + incident.Staff.PersonId );
            }
            else
            {
                sb.Append(",StaffId=null");
            }
            if (incident.Student != null)
            {
                sb.Append(",StudentId=" + incident.Student.PersonId);
            }
            else
            {
                sb.Append(",StudentId=null");
            }
            sb.Append(" WHERE IncidentId =" + incident.IncidentId);
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }

        public void Add(Incident incident)
        {
            CommonFunctions.UpdateApostrophe<Incident>(incident);
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO Incident (StudentId,StaffId,PersonFullName,IncidentDate,IncidentHour,IncidentMinute,AmPm,Description,FileLocation,FileName,Comments,LocationId,WhoReportedId,CoordinatorId,ManagerId,HealthAndSafetyOfficerId) VALUES (");
            if (incident.Student != null)
            {
                sb.Append(incident.Student.PersonId);
            }
            else
            {
                sb.Append("null");
            }
            if (incident.Staff != null)
            {
                sb.Append(","+incident.Staff.PersonId);
            }
            else
            {
                sb.Append(",null");
            }

            sb.Append(",'" + incident.PersonFullName + "'");            
            sb.Append(",'" + incident.IncidentDate.ToString("dd/MM/yyyy") + "'");
            sb.Append(",'" + incident.IncidentHour + "'");
            sb.Append(",'" + incident.IncidentMinute + "'");
            sb.Append(",'" + incident.AmPm + "'");
            sb.Append(",'" + incident.Description + "'");
            sb.Append(",'" + incident.FileLocation + "'");
            sb.Append(",'" + incident.FileName + "'");
            if (incident.Comments != string.Empty)
                sb.Append(",'" + incident.Comments + "'");
            else
                sb.Append(",null");
            sb.Append("," + incident.Location.LocationId);
            sb.Append("," + incident.WhoReported.PersonId);
            sb.Append("," + incident.Coordinator.PersonId);
            sb.Append("," + incident.Manager.PersonId);
            sb.Append("," + incident.HealthAnSafetyOfficer.PersonId);
            sb.Append(")");
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }

        public void Remove(int incidentId)
        {
            //StringBuilder sb = new StringBuilder();
            //sb.Append("DELETE FROM StudentNote WHERE StudentNoteId=" + studentNoteId);      
            //string sql = sb.ToString();
            //dbc.ExecuteCommand(sql);
        }

        public Student GetStudent(int StudentId)
        {
            StudentData sd = new StudentData();
            List<Person> list = sd.GetList("SELECT * FROM Vw_Students WHERE StudentId=" + StudentId);
            Student st;
            if (list.Count >0)
            {
                st = (Student)list[0];
            }
            else
            {
                st = null;
            }
            return st;
        }

        public Staff GetStaff(int StaffId)
        {
            StaffData sd = new StaffData();
            List<Person> list = sd.GetList(StaffId);
            Staff st;
            if (list.Count > 0)
            {
                st = (Staff)list[0];
            }
            else
            {
                st = null;
            }
            st.FullName = st.GetFullName();
            return st;
        }

        public Location GetLocation(int locationId)
        {
            LocationData ld = new LocationData();
            List<Location> list = ld.GetList(locationId);
            Location lo = list[0];
            return lo;
        }
    }
}