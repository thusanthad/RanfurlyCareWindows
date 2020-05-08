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

        public StudentData(DBCommand dbc):base(dbc)
        {

        }

        //public StudentData(DBCommand.TransactionType transactionType):base(transactionType)
        //{

        //}
        public override List<Person> GetList()
        {
            throw new NotImplementedException("not implemented");
        }

        public override List<Person> GetList(string sql)
        {
            List<Person> studentList = new List<Person>();
            //DataTable dt = dbc.GetDataTable("SELECT * FROM vw_Students");
            DataTable dt = dbc.GetDataTable(sql);

            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    var person = new Student();
                    person.PersonId = (int)dr["StudentId"];
                    person.PreferredName = dr["PreferredName"].ToString();
                    person.FirstName = dr["FirstName"].ToString();
                    person.MiddleName = dr["MiddleName"].ToString();
                    person.LastName = dr["LastName"].ToString();
                    if (dr["DateOfBirth"].ToString() != string.Empty)
                        person.DateOfBirth = (DateTime)dr["DateOfBirth"];
                    if (dr["AdmittedToActivityCentre"].ToString() != string.Empty)
                        person.AdmittedToActivityCentre = (DateTime)dr["AdmittedToActivityCentre"];
                    if (dr["AdmittedToResidence"].ToString() != string.Empty)
                        person.AdmittedToResidence = (DateTime)dr["AdmittedToResidence"];

                    person.Gender = dr["Gender"].ToString();
                    person.Ethnicity = dr["Ethnicity"].ToString();
                    if(dr["EthnicityId"].ToString() != string.Empty)
                        person.EthnicityId = (int)dr["EthnicityId"];
                    person.HomePhone = dr["HomePhone"].ToString();
                    person.MobilePhone = dr["MobilePhone"].ToString();                   
                    person.NHINumber = dr["NHINumber"].ToString();
                    person.IRDNumber = dr["IRDNumber"].ToString();
                    person.MobilityCardNumber = dr["MobilityCardNumber"].ToString();
                    person.WINZNumber = dr["WINZNumber"].ToString();
                    person.GoldCardNumber = dr["GoldCardNumber"].ToString();
                    person.AtHopCardNumber = dr["AtHopCardNumber"].ToString();
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
                    person.IsActive= (bool)dr["IsActive"];
                    person.IsShortStayResident = (bool)dr["IsShortStayResident"];
                    person.FuneralArrangement = dr["FuneralArrangement"].ToString();
                    person.PlaceOfBirth = dr["PlaceOfBirth"].ToString();

                    // person.Doctors = GeteDocors(person.PersonId);
                    // person.NextOfKin = GeteNextOfKin(person.PersonId);
                    // person.MedicalConditions = GetMedicalConditions(person.PersonId);
                    //person.Addresses = GetAddresses(person.PersonId);
                    // person.EmergencyContacts = GetEmergencyContacts(person.PersonId);
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


       
        public override void Update(List<Person> persons)
        {

        }

        public override void Update(Person person)
        {
            Student student = (Student)person;
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE STUDENT SET ");
            sb.Append("firstName='" + student.FirstName.Replace("'", "''") + "'");
            sb.Append(",LastName='" + student.LastName.Replace("'", "''") + "'");
            if (student.MiddleName !=string.Empty)
                sb.Append(",MiddleName='" + student.MiddleName.Replace("'", "''") + "'");
            else
                sb.Append(",MiddleName=null");
            if (student.PreferredName != string.Empty)
                sb.Append(",PreferredName='" + student.PreferredName.Replace("'", "''") + "'");
            else
                sb.Append(",PreferredName=null");
            sb.Append(",Gender='" + student.Gender + "'");            
            sb.Append(",DateOfBirth='" + student.DateOfBirth?.ToString("dd/MM/yyyy") +"'");
            sb.Append(",EthnicityId=" + student.EthnicityId);
            sb.Append(",AdmittedToActivityCentre='" + student.AdmittedToActivityCentre?.ToString("dd/MM/yyyy") + "'");
            if (student.AdmittedToResidence !=null)
                sb.Append(",AdmittedToResidence='" + student.AdmittedToResidence?.ToString("dd/MM/yyyy") + "'");
            else
                sb.Append(",AdmittedToResidence=null");

            if (student.NHINumber !=string.Empty)
                sb.Append(",NHINumber='" + student.NHINumber + "'");
            else
                sb.Append(",NHINumber=null");
            sb.Append(",AttendsActivityCentre=" + student.AttendsActivityCentre);
            if (student.ActivityCentreCoachId != 0)
                sb.Append(",ActivityCentreCoachId=" + student.ActivityCentreCoachId);
            if (student.ResidentCoachId != 0)
                sb.Append(",ResidentCoachId=" + student.ResidentCoachId );
            else
                sb.Append(",ResidentCoachId=null");
            if (student.HomePhone != string.Empty)
                sb.Append(",HomePhone='" + student.HomePhone + "'");
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
            if (student.AtHopCardNumber != string.Empty)
                sb.Append(",AtHopCardNumber='" + student.AtHopCardNumber + "'");
            else
                sb.Append(",AtHopCardNumber=null");
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
            sb.Append(",IsActive=" + student.IsActive );
            sb.Append(",IsShortStayResident=" + student.IsShortStayResident);           
            if (student.LocationId >0)
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
            
            AddUpdateDoctors(student);
            AddUpdateNextOfKin(student);
            AddEditEmergencyContacts(student);
            AddEditMedicalConditions(student);
            AddEditStudentNotes(student);
            AddEditRiskManagementPlans(student);
            AddEditPersonalCare(student);
        }

       
        public override int Add(Person person)
        {
            Student student = (Student)person;
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO STUDENT (firstName,LastName,MiddleName,PreferredName,Gender,DateOfBirth,EthnicityId," +
                "AdmittedToActivityCentre,AdmittedToResidence,NHINumber,AttendsActivityCentre,ActivityCentreCoachId," +
                "ResidentCoachId,HomePhone,MobilePhone,IRDNumber,WINZNumber,MobilityCardNumber,Addr1,Addr2,Addr3,Addr4," +
                "postcode,IsShortStayResident,ShortNotes,LocationId,FuneralArrangement,PlaceOfBirth,GoldCardNumber,AdHopCardNumber,CommunityServicesCardNumber) VALUES (");
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

            if (student.NHINumber != string.Empty && student.NHINumber !=null)
                sb.Append(",'" + student.NHINumber + "'");
            else
                sb.Append(",null");

            sb.Append(","+student.AttendsActivityCentre);
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
            if (student.AtHopCardNumber != string.Empty && student.AtHopCardNumber != null)
                sb.Append(",'" + student.AtHopCardNumber + "'");
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

        private void AddUpdateDoctors(Student student)
        {
            DoctorData doctorData = new DoctorData(dbc);
            foreach (Doctor doctor in student.Doctors)
            {
                //if (doctor.PersonId == 0)
                //{
                //    doctorData.Add(doctor, student.PersonId);
                //}
                //else
                //{
                    bool personExists = doctorData.PersonExists(doctor.PersonId, student.PersonId);
                    if (!personExists)
                    {
                        doctorData.Allocate(doctor, student.PersonId);
                    }
               // }
            }

            foreach (object obj in student.RemovedObjects)
            {
                if (obj is Doctor)
                {
                    doctorData.Remove((Doctor)obj, student.PersonId);
                }
            }
        }

        private void AddUpdateNextOfKin(Student student)
        {
            NextOfKinData nextOfKinData = new NextOfKinData(dbc);
            foreach (NextOfKin nextOfKin in student.NextOfKin)
            {
                if (nextOfKin.PersonId == 0)
                {
                    nextOfKinData.Add(nextOfKin, student.PersonId);
                }
                else
                {
                    bool personExists = nextOfKinData.PersonExists(nextOfKin.PersonId, student.PersonId);
                    if (!personExists)
                    {
                        nextOfKinData.Allocate(nextOfKin, student.PersonId);
                    }
                    else
                    {
                        nextOfKinData.Update(nextOfKin); // update relationship
                    }
                }
            }

            foreach (object obj in student.RemovedObjects)
            {
                if (obj is NextOfKin)
                {
                    nextOfKinData.Remove((NextOfKin)obj, student.PersonId);
                }
            }
        }

        private void AddEditEmergencyContacts(Student student)
        {
            EmergencyContactData emergencyContactData = new EmergencyContactData(dbc);
            foreach (EmergencyContact ec in student.EmergencyContacts)
            {
                if (ec.StudentEmergencyContactId == 0)
                {
                    emergencyContactData.Add(ec, student.PersonId);
                }
                else
                {
                    emergencyContactData.Update(ec);
                }
            }

            foreach (object obj in student.RemovedObjects)
            {
                if (obj is EmergencyContact)
                {
                    emergencyContactData.Remove((EmergencyContact)obj, student.PersonId);
                }
            }
        }

        private void AddEditMedicalConditions(Student student)
        {
            MedicalConditionData medicalConditionData = new MedicalConditionData(dbc);
            foreach (MedicalCondition mc in student.MedicalConditions)
            {
                if (mc.StudentMedicalConditionId == 0)
                {
                    medicalConditionData.Add(mc, student.PersonId);
                }
                else
                {
                    medicalConditionData.Update(mc);
                }
            }

            foreach (object obj in student.RemovedObjects)
            {
                if (obj is MedicalCondition)
                {
                    medicalConditionData.Remove(((MedicalCondition)obj).StudentMedicalConditionId);
                }
            }
        }

        private void AddEditStudentNotes(Student student)
        {
            StudentNoteData studentNoteData = new StudentNoteData(dbc);
            foreach (StudentNote sn in student.StudentNotes)
            {
                if (sn.StudentNoteId == 0)
                {
                    studentNoteData.Add(sn, student.PersonId);
                }
                else
                {
                    studentNoteData.Update(sn);
                }
            }

            foreach (object obj in student.RemovedObjects)
            {
                if (obj is StudentNote)
                {
                    studentNoteData.Remove(((StudentNote)obj).StudentNoteId);
                }
            }
        }

        private void AddEditRiskManagementPlans(Student student)
        {
            RiskManagementPlanData riskManagementPlanData = new RiskManagementPlanData(dbc);
            foreach (RiskManagementPlan rmp in student.RiskManagementPlans)
            {
                if (rmp.StudentRiskManagementPlanId == 0)
                {
                    riskManagementPlanData.Add(rmp, student.PersonId);
                }
                else
                {
                    riskManagementPlanData.Update(rmp);
                }
            }

            foreach (object obj in student.RemovedObjects)
            {
                if (obj is RiskManagementPlan)
                {
                    riskManagementPlanData.Remove(((RiskManagementPlan)obj).StudentRiskManagementPlanId);
                }
            }
        }

        private void AddEditPersonalCare(Student student)
        {
            StudentPersonalCareData personaCareData = new StudentPersonalCareData(dbc);
            foreach (StudentPersonalCare spc in student.PersonalCare)
            {
                if (spc.StudentPersonalCareId == 0)
                {
                    personaCareData.Add(spc, student.PersonId);
                }
                else
                {
                    personaCareData.Update(spc);
                }
            }

            foreach (object obj in student.RemovedObjects)
            {
                if (obj is StudentPersonalCare)
                {
                    personaCareData.Remove(((StudentPersonalCare)obj).StudentPersonalCareId);
                }
            }
        }

        public override void Allocate(Person person, int PersonId)
        {

        }

        public override List<Person> GetList(int PersonId)
        {
            throw new NotImplementedException();
        }

        public override void Remove(Person person, int StudentId)
        {

        }

        public override int Add(Person person, int StudentId)
        {
            throw new NotImplementedException("not implemented");
        }

        public override bool PersonExists(int PersonId, int StudentId)
        {
            throw new NotImplementedException("not implemented");
        }

        //public override DataTable GeteExportDatatable(List<object> list)
        //{
        //    List<Student> listNew = list.ConvertAll(x => x as Student);
        //    DataTable dt=  CommonFunctions.ToDataTable<Student>(listNew);
        //    dt.Columns["PersonId"].SetOrdinal(0);
        //    dt.Columns["PersonId"].ColumnName = "StudentId";
        //    dt.Columns["FirstName"].SetOrdinal(1);
        //    dt.Columns["MiddleName"].SetOrdinal(2);
        //    dt.Columns["LastName"].SetOrdinal(3);
        //    dt.Columns["PreferredName"].SetOrdinal(4);
        //    dt.Columns["DateOfBirth"].SetOrdinal(4);
        //    dt.Columns["addr1"].SetOrdinal(5);
        //    dt.Columns["addr2"].SetOrdinal(6);
        //    dt.Columns["addr3"].SetOrdinal(7);
        //    dt.Columns["addr4"].SetOrdinal(8);
        //    dt.Columns["postcode"].SetOrdinal(9);
        //    dt.Columns.Remove("Doctors");
        //    dt.Columns.Remove("NextOfKin");
        //    dt.Columns.Remove("emergencyContacts");
        //    dt.Columns.Remove("medicalappointmentnotes");
        //    dt.Columns.Remove("residentcoachid");
        //    dt.Columns.Remove("activitycentrecoachid");
        //    dt.Columns.Remove("removedobjects");
        //    dt.Columns.Remove("medicalconditions");
        //    dt.Columns.Remove("ethnicityId");
        //    dt.Columns.Remove("fulladdress");
        //    return dt;
        //}
    }
}

//private List<MedicalCondition> GetMedicalConditions(int StudentId)
//{
//    List<MedicalCondition> mecicalConditions = new List<MedicalCondition>();
//    DataTable dt = dbc.GetDataTable("SELECT * FROM vw_MedicalConditions WHERE StudentId=" + StudentId);
//    //dbc.CloseConnection();

//    foreach (DataRow dr in dt.Rows)
//    {
//        MedicalCondition mc = new MedicalCondition();
//        mc.MedicalConditionId = (int)dr["MedicalConditionId"];
//        mc.StudentId = (int)dr["StudentId"];
//        mc.Condition = dr["MedicalCondition"].ToString();               
//        mecicalConditions.Add(mc);
//    }
//    return mecicalConditions;
//} 

//private List<Person> GeteDocors(int StudentId)
//{
////    DataBase db = new DoctorData();
////    return db.GetList(StudentId);

//    List<Person> doctors = new List<Person>();
//    DataTable dt = dbc.GetDataTable("SELECT * FROM vw_StudentDoctors WHERE StudentId=" + StudentId);

//    foreach (DataRow dr in dt.Rows)
//    {
//        Person doctor = new Doctor
//        {
//            PersonId = (int)dr["DoctorId"],
//            FullName = dr["FullName"].ToString(),
//            Phone = dr["Phone"].ToString(),
//            Addr1 = dr["Addr1"].ToString(),
//            Addr2 = dr["Addr2"].ToString(),
//            Addr3 = dr["Addr3"].ToString(),
//            Addr4 = dr["Addr4"].ToString(),
//            Postcode = dr["Postcode"].ToString(),
//            Email = dr["Email"].ToString()
//        };
//        doctor.FullAddress = doctor.GetFullAddress();
//        doctors.Add(doctor);
//    }
//    return doctors;
//}

//private List<Person> GeteNextOfKin(int StudentId)
//{
//    //DataBase db = new NextOfKinData();
//    //return db.GetList(StudentId);
//    List<Person> nextOfKins = new List<Person>();
//    DataTable dt = dbc.GetDataTable("SELECT * FROM vw_StudentNextOfKin WHERE StudentId=" + StudentId);

//    foreach (DataRow dr in dt.Rows)
//    {
//        Person nextOfKin = new NextOfKin
//        {
//            PersonId = (int)dr["NextOfKinId"],                    
//            Phone = dr["Phone"].ToString(),
//            Relationship = dr["Relationship"].ToString(),
//            FullName = dr["FullName"].ToString(),
//            Addr1 = dr["Addr1"].ToString(),
//            Addr2 = dr["Addr2"].ToString(),
//            Addr3 = dr["Addr3"].ToString(),
//            Addr4 = dr["Addr4"].ToString(),
//            Postcode = dr["Postcode"].ToString(),
//            Email = dr["Email"].ToString()                   
//    };
//        nextOfKin.FullAddress = nextOfKin.GetFullAddress();
//        nextOfKins.Add(nextOfKin);
//    }
//    return nextOfKins;
//}

//private List<Address> GetAddresses(int StudentId)
//{
//    List<Address> addresses = new List<Address>();
//    DataTable dt = dbc.GetDataTable("SELECT * FROM vw_StudentAddresses WHERE StudentId=" + StudentId);

//    foreach (DataRow dr in dt.Rows)
//    {
//        Address address = new Address();
//        address.StudentAddressId = (int)dr["StudentAddressId"];
//        address.StudentId = (int)dr["StudentId"];
//        address.Addr1 = dr["Addr1"].ToString();
//        address.Addr2 = dr["Addr2"].ToString();
//        address.Addr3 = dr["Addr3"].ToString();
//        address.Addr4 = dr["Addr4"].ToString();
//        address.Postcode = dr["Postcode"].ToString();
//        addresses.Add(address);
//    }
//    return addresses;
//}

//private List<EmergencyContact> GetEmergencyContacts(int StudentId)
//{
//    List<EmergencyContact> EmergencyContactList = new List<EmergencyContact>();
//    DataTable dt = dbc.GetDataTable("SELECT * FROM vw_StudentEmergencyContacts WHERE StudentId=" + StudentId);

//    foreach (DataRow dr in dt.Rows)
//    {
//        EmergencyContact ic = new EmergencyContact();
//        ic.StudentEmergencyContactId = (int)dr["StudentEmergencyContactId"];
//        ic.StudentId = (int)dr["StudentId"];
//        ic.FullName = dr["FullName"].ToString();
//        ic.Addr1 = dr["Addr1"].ToString();
//        ic.Addr1 = dr["Addr1"].ToString();
//        ic.Addr2 = dr["Addr2"].ToString();
//        ic.Addr3 = dr["Addr3"].ToString();
//        ic.Addr4 = dr["Addr4"].ToString();
//        ic.Postcode = dr["Postcode"].ToString();
//        ic.Phone = dr["Phone"].ToString();
//        ic.Relationship = dr["Relationship"].ToString();
//        EmergencyContactList.Add(ic);
//    }
//    return EmergencyContactList;
//}

//private string GetPropertyValue(string propertyValue)
//{
//    if (propertyValue.Length == 0)
//        return "null";
//    else
//        return propertyValue;
//}