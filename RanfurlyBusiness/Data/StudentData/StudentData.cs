using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;
using DataAccess;

namespace RanfurlyBusiness
{
    public class StudentData : DataBase
    {
        public StudentData()
        {

        }

        public StudentData(DBCommand dbc) : base(dbc)
        {

        }

        public override List<Person> GetList()
        {
            List<Person> studentList = new List<Person>();
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_Students WHERE IsActive=true");

            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    var person = GetStudent(dr);
                    studentList.Add(person);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            dbc.CloseConnection();
            return studentList;
        }

        public override List<Person> GetList(string sql)
        {
            List<Person> studentList = new List<Person>();
            DataTable dt = dbc.GetDataTable(sql);

            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    var person = GetStudent(dr);
                    studentList.Add(person);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            dbc.CloseConnection();
            return studentList;
        }

        private Student GetStudent(DataRow dr)
        {
            var person = new Student();
            person.PersonId = (int)dr["StudentId"];
            person.PreferredName = dr["PreferredName"].ToString();
            if(person.PersonId==101 || person.PersonId == 56)
            {

            }
            person.FirstName = dr["FirstName"].ToString();
            person.MiddleName = dr["MiddleName"].ToString();
            person.LastName = dr["LastName"].ToString();
            if (dr["DateOfBirth"].ToString() != string.Empty)
                person.DateOfBirth = (DateTime)dr["DateOfBirth"];
            if (dr["AdmittedToActivityCentre"].ToString() != string.Empty)
                person.AdmittedToActivityCentre = (DateTime)dr["AdmittedToActivityCentre"];
            if (dr["AdmittedToResidence"].ToString() != string.Empty)
                person.AdmittedToResidence = (DateTime)dr["AdmittedToResidence"];
            if (dr["DateLeft"].ToString() != string.Empty)
                person.DateLeft = (DateTime)dr["DateLeft"];

            person.Gender = dr["Gender"].ToString();
            person.Ethnicity = dr["Ethnicity"].ToString();
            if (dr["EthnicityId"].ToString() != string.Empty)
                person.EthnicityId = (int)dr["EthnicityId"];
            person.HomePhone = dr["HomePhone"].ToString();
            person.MobilePhone = dr["MobilePhone"].ToString();
            person.NHINumber = dr["NHINumber"].ToString();
            person.IRDNumber = dr["IRDNumber"].ToString();
            person.MobilityCardNumber = dr["MobilityCardNumber"].ToString();
            if (dr["WINZNumber"].ToString() != string.Empty)
                person.WINZNumber = dr["WINZNumber"].ToString();
            else
                person.WINZNumber = "** Please update **"; ;
            person.GoldCardNumber = dr["GoldCardNumber"].ToString();
            person.CommunityServicesCardNumber = dr["CommunityServicesCardNumber"].ToString();
            person.AttendsActivityCentre = (bool)dr["AttendsActivityCentre"];
            person.Addr1 = dr["Addr1"].ToString();
            person.Addr2 = dr["Addr2"].ToString();
            person.Addr3 = dr["Addr3"].ToString();
            person.Addr4 = dr["Addr4"].ToString();
            person.Postcode = dr["Postcode"].ToString();
            person.ShortNotes = dr["ShortNotes"].ToString();
            if (dr["LocationId"].ToString() == string.Empty)
                person.LocationId = 0;//null;
            else
                person.LocationId = (int)dr["LocationId"];

            person.LocationName = dr["LocationName"].ToString();

            if (person.AdmittedToResidence.HasValue)
                person.IsResident = true;
            if (dr["ActivityCentreCoachId"].ToString() != string.Empty)
                person.ActivityCentreCoachId = (int)dr["ActivityCentreCoachId"];

            if (dr["ResidentCoachId"].ToString() != string.Empty)
                person.ResidentCoachId = (int)dr["ResidentCoachId"];

            person.ActivityCentreCoach = dr["ActivityCentreCoach"].ToString();
            person.ResidentCoach = dr["ResidentCoach"].ToString();
            person.IsActive = (bool)dr["IsActive"];
            person.IsShortStayResident = (bool)dr["IsShortStayResident"];
            person.FuneralArrangement = dr["FuneralArrangement"].ToString();
            person.PlaceOfBirth = dr["PlaceOfBirth"].ToString();
            person.FullName = person.GetFullName();
            person.FullAddress = person.GetFullAddress();
            //person.Incidents = GetIncidents(person.PersonId);

            return person;
        }



        public override void Update(List<Person> persons)
        {

        }

        public override void Update(Person person)
        {
            Student student = (Student)person;
            CommonFunctions.UpdateApostrophe(student);
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE STUDENT SET ");
            sb.Append("firstName='" + student.FirstName + "'");
            sb.Append(",LastName='" + student.LastName + "'");
            if (student.MiddleName != string.Empty)
                sb.Append(",MiddleName='" + student.MiddleName + "'");
            else
                sb.Append(",MiddleName=null");
            if (student.PreferredName != string.Empty)
                sb.Append(",PreferredName='" + student.PreferredName + "'");
            else
                sb.Append(",PreferredName=null");
            sb.Append(",Gender='" + student.Gender + "'");
            sb.Append(",DateOfBirth='" + student.DateOfBirth?.ToString("dd/MM/yyyy") + "'");
            sb.Append(",EthnicityId=" + student.EthnicityId);
            sb.Append(",AdmittedToActivityCentre='" + student.AdmittedToActivityCentre?.ToString("dd/MM/yyyy") + "'");
            if (student.AdmittedToResidence != null)
                sb.Append(",AdmittedToResidence='" + student.AdmittedToResidence?.ToString("dd/MM/yyyy") + "'");
            else
                sb.Append(",AdmittedToResidence=null");
            if (student.DateLeft != null)
                sb.Append(",DateLeft='" + student.DateLeft?.ToString("dd/MM/yyyy") + "'");
            else
                sb.Append(",DateLeft=null");

            if (student.NHINumber != string.Empty)
                sb.Append(",NHINumber='" + student.NHINumber + "'");
            else
                sb.Append(",NHINumber=null");
            sb.Append(",AttendsActivityCentre=" + student.AttendsActivityCentre);
            if (student.ActivityCentreCoachId != 0)
                sb.Append(",ActivityCentreCoachId=" + student.ActivityCentreCoachId);
            if (student.ResidentCoachId != 0)
                sb.Append(",ResidentCoachId=" + student.ResidentCoachId);
            else
                sb.Append(",ResidentCoachId=null");
            if (student.HomePhone != string.Empty)
                sb.Append(",HomePhone='" + student.HomePhone+ "'");
            else
                sb.Append(",HomePhone=null");
            if (student.MobilePhone != string.Empty)
                sb.Append(",MobilePhone='" + student.MobilePhone + "'");
            else
                sb.Append(",MobilePhone=null");
            if (student.IRDNumber != string.Empty)
                sb.Append(",IRDNumber='" + student.IRDNumber + "'");
            else
                sb.Append(",IRDNumber=null");
            if (student.WINZNumber != string.Empty)
                sb.Append(",WINZNumber='" + student.WINZNumber + "'");
            else
                sb.Append(",WINZNumber=null");
            if (student.MobilityCardNumber != string.Empty)
                sb.Append(",MobilityCardNumber='" + student.MobilityCardNumber + "'");
            else
                sb.Append(",MobilityCardNumber=null");
            if (student.GoldCardNumber != string.Empty)
                sb.Append(",GoldCardNumber='" + student.GoldCardNumber + "'");
            else
                sb.Append(",GoldCardNumber=null");
            if (student.CommunityServicesCardNumber != string.Empty)
                sb.Append(",CommunityServicesCardNumber='" + student.CommunityServicesCardNumber + "'");
            else
                sb.Append(",CommunityServicesCardNumber=null");
            sb.Append(",Addr1='" + student.Addr1 + "'");
            sb.Append(",Addr2='" + student.Addr2 + "'");
            sb.Append(",Addr3='" + student.Addr3 + "'");
            if (student.Addr4 != string.Empty)
                sb.Append(",Addr4='" + student.Addr4 + "'");
            sb.Append(",Postcode='" + student.Postcode + "'");
            if (student.ShortNotes != string.Empty)
                sb.Append(",ShortNotes='" + student.ShortNotes + "'");
            else
                sb.Append(",ShortNotes=null");
            sb.Append(",IsActive=" + student.IsActive);
            sb.Append(",IsShortStayResident=" + student.IsShortStayResident);
            if (student.LocationId > 0)
                sb.Append(",LocationId=" + student.LocationId);
            if (student.FuneralArrangement != string.Empty)
                sb.Append(",FuneralArrangement='" + student.FuneralArrangement + "'");
            else
                sb.Append(",FuneralArrangement=null");
            if (student.PlaceOfBirth != string.Empty)
                sb.Append(",PlaceOfBirth='" + student.PlaceOfBirth + "'");
            else
                sb.Append(",PlaceOfBirth=null");
            sb.Append(" WHERE StudentId =" + student.PersonId);

            string sql = sb.ToString();
            //sql = sql.Replace("'", "''");
            dbc.ExecuteCommand(sql);

            //AddUpdateDoctors(student);
            StudentDataAddEditBase studentDataAddEditBase;
            studentDataAddEditBase = new StudentDoctorAddEdit(student, dbc);
            studentDataAddEditBase = new StudentNextOfKinAddEdit(student, dbc);
            studentDataAddEditBase = new StudentEmergencyContactAddEdit(student, dbc);
            studentDataAddEditBase = new StudentMedicalConditionAddEdit(student, dbc);
            studentDataAddEditBase = new StudentNotesAddEdit(student, dbc);
            studentDataAddEditBase = new StudentRiskManagementAddEdit(student, dbc);
            studentDataAddEditBase = new StudentPersonalCareAddEdit(student, dbc);
            studentDataAddEditBase = new StudentMedicationAndTreatmentAddEdit(student, dbc);
            studentDataAddEditBase = new StudentPhysicalAbilitiesAddEdit(student, dbc);
            studentDataAddEditBase = new StudentMedicalCondtionAlertAddEdit(student, dbc);
            studentDataAddEditBase = new StudentSpecialistAddEdit(student, dbc);
            studentDataAddEditBase = new StudentBehaviourAddEdit(student, dbc);



            //AddUpdateNextOfKin(student);
            //AddEditEmergencyContacts(student);
            // AddEditMedicalConditions(student);
            //AddEditStudentNotes(student);
            //AddEditRiskManagementPlans(student);
            // AddEditPersonalCare(student);
            // AddEditMedicationAndTreatment(student);
            //AddEditPhysicalAbilities(student);
        }


        public override int Add(Person person)
        {
            Student student = (Student)person;
            CommonFunctions.UpdateApostrophe(student);
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO STUDENT (firstName,LastName,MiddleName,PreferredName,Gender,DateOfBirth,EthnicityId," +
                "AdmittedToActivityCentre,AdmittedToResidence,NHINumber,AttendsActivityCentre,ActivityCentreCoachId," +
                "ResidentCoachId,HomePhone,MobilePhone,IRDNumber,WINZNumber,MobilityCardNumber,Addr1,Addr2,Addr3,Addr4," +
                "postcode,IsShortStayResident,ShortNotes,LocationId,FuneralArrangement,PlaceOfBirth,GoldCardNumber,CommunityServicesCardNumber) VALUES (");
            sb.Append("'" + student.FirstName + "'");
            sb.Append(",'" + student.LastName + "'");
            if (student.MiddleName != string.Empty)
                sb.Append(",'" + student.MiddleName + "'");
            else
                sb.Append(",null");

            if (student.PreferredName != string.Empty)
                sb.Append(",'" + student.PreferredName + "'");
            else
                sb.Append(",null");

            sb.Append(",'" + student.Gender + "'");
            // sb.Append(",DateOfBirth='" + Convert.ToDateTime(student.DateOfBirth)+"'");
            sb.Append(",'" + student.DateOfBirth?.ToString("dd/MM/yyyy") + "'");
            sb.Append("," + student.EthnicityId);
            sb.Append(",'" + student.AdmittedToActivityCentre?.ToString("dd/MM/yyyy") + "'");
            if (student.AdmittedToResidence != null)
                sb.Append(",'" + student.AdmittedToResidence?.ToString("dd/MM/yyyy") + "'");
            else
                sb.Append(",null");

            if (student.NHINumber != string.Empty && student.NHINumber != null)
                sb.Append(",'" + student.NHINumber + "'");
            else
                sb.Append(",null");

            sb.Append("," + student.AttendsActivityCentre);
            if (student.ActivityCentreCoachId != 0)
                sb.Append("," + student.ActivityCentreCoachId);
            else
                sb.Append(",null");

            if (student.ResidentCoachId != 0)
                sb.Append("," + student.ResidentCoachId);
            else
                sb.Append(",null");

            if (student.HomePhone != string.Empty && student.HomePhone != null)
                sb.Append(",'" + student.HomePhone + "'");
            else
                sb.Append(",null");

            if (student.MobilePhone != string.Empty && student.MobilePhone != null)
                sb.Append(",'" + student.MobilePhone + "'");
            else
                sb.Append(",null");

            if (student.IRDNumber != string.Empty && student.IRDNumber != null)
                sb.Append(",'" + student.IRDNumber + "'");
            else
                sb.Append(",null");

            if (student.WINZNumber != string.Empty && student.WINZNumber != null)
                sb.Append(",'" + student.WINZNumber + "'");
            else
                sb.Append(",null");

            if (student.MobilityCardNumber != string.Empty && student.MobilityCardNumber != null)
                sb.Append(",'" + student.MobilityCardNumber + "'");
            else
                sb.Append(",null");
            sb.Append(",'" + student.Addr1 + "'");
            sb.Append(",'" + student.Addr2 + "'");
            sb.Append(",'" + student.Addr3 + "'");
            if (student.Addr4 != string.Empty && student.Addr4 != null)
                sb.Append(",'" + student.Addr4 + "'");
            else
                sb.Append(",null");
            sb.Append(",'" + student.Postcode + "'");
            //sb.Append("," + student.IsResident );
            sb.Append("," + student.IsShortStayResident);
            if (student.ShortNotes != string.Empty && student.ShortNotes != null)
                sb.Append(",'" + student.ShortNotes + "'");
            else
                sb.Append(",null");
            sb.Append("," + student.LocationId);
            string sql1 = sb.ToString();
            if (student.FuneralArrangement != string.Empty && student.FuneralArrangement != null)
                sb.Append(",'" + student.FuneralArrangement + "'");
            else
                sb.Append(",null");

            if (student.PlaceOfBirth != string.Empty && student.PlaceOfBirth != null)
                sb.Append(",'" + student.PlaceOfBirth + "'");
            else
                sb.Append(",null");
            if (student.GoldCardNumber != string.Empty && student.GoldCardNumber != null)
                sb.Append(",'" + student.GoldCardNumber + "'");
            else
                sb.Append(",null");
            if (student.CommunityServicesCardNumber != string.Empty && student.CommunityServicesCardNumber != null)
                sb.Append(",'" + student.CommunityServicesCardNumber + "'");
            else
                sb.Append(",null");
            sb.Append(")");

            string sql = sb.ToString();

            int studentid = dbc.ExecuteCommand(sql);
            // dbc.CloseConnection();
            return studentid;
        }

        //private List<Incident> GetIncidents(int studentId)
        //{
        //    IncidentData id = new IncidentData();
        //    return id.GetList(studentId);
        //}

        public override void Allocate(Person person, int PersonId)
        {
            throw new NotImplementedException("not implemented");
        }

        public override List<Person> GetList(int PersonId)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Person person, int StudentId)
        {
            throw new NotImplementedException("not implemented");
        }

        public override int Add(Person person, int StudentId)
        {
            throw new NotImplementedException("not implemented");
        }

        public override bool PersonExists(int PersonId, int StudentId)
        {
            throw new NotImplementedException("not implemented");
        }
    }
}