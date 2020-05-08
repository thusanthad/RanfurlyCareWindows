using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;
using DataAccess;

namespace RanfurlyBusiness
{
    public class SpecialistData : DataBase
    {
        public SpecialistData()
        {

        }

        //public DoctorData(DBCommand.TransactionType trtype):base(trtype)
        //{

        //}

        public SpecialistData(DBCommand dbCommand):base(dbCommand)
        {

        }
        //public DoctorData(DBCommand.TransactionType transactionType) :base(transactionType)
        //{

        //}

        public override List<Person> GetList(string sql)
        {
            List<Person> list = new List<Person>();
            DataTable dt = dbc.GetDataTable(sql);

            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    list.Add(GetSpecialist(dr));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return list;
        }

        public override List<Person> GetList()
        {
            List<Person> list = new List<Person>();
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_ProfessionalServiceProviders");
            
            //dbc.CloseConnection();

            foreach (DataRow dr in dt.Rows)
            {
                try
                {                    
                    list.Add(GetSpecialist(dr));
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            return list;
        }

        private Person GetSpecialist(DataRow dr)
        {
            Person specialist = new Specialist
            {
                PersonId = (int)dr["professionalserviceprociderid"],
                //ServiceTypeId = (int)dr["ServiceTypeId"],
                FullName = dr["FullName"].ToString(),
                Addr1 = dr["Addr1"].ToString(),
                Addr2 = dr["Addr2"].ToString(),
                Addr3 = dr["Addr3"].ToString(),
                Addr4 = dr["Addr4"].ToString(),
                Postcode = dr["Postcode"].ToString(),
                Phone = dr["Phone"].ToString(),
                SpecialistType = dr["ProfessionalServiceProviderType"].ToString(),
                ProfessionalServiceProviderTypeId = (int)dr["ProfessionalServiceProviderTypeId"],

                //MobilePhone = dr["MobilePhone"].ToString(),
                DisplayName = dr["FullName"].ToString() + " - (" + dr["ProfessionalServiceProviderType"].ToString() + ")",
                Email = dr["Email"].ToString()
            };
            specialist.FullAddress = specialist.GetFullAddress();
            return specialist;
        }

        public override List<Person> GetList(int StudentId)
        {
            List<Person> list = new List<Person>();
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_StudentProfessionalServiceProviders WHERE StudentId=" + StudentId);
            dbc.CloseConnection();

            foreach (DataRow dr in dt.Rows)
            {
                Person professionalServiceProvider = new Specialist
                {
                    PersonId = (int)dr["Professionalserviceprociderid"],
                    //ServiceTypeId = (int)dr["ServiceTypeId"],
                    FullName = dr["FullName"].ToString(),
                    Phone = dr["Phone"].ToString(),
                    Addr1 = dr["Addr1"].ToString(),
                    Addr2 = dr["Addr2"].ToString(),
                    Addr3 = dr["Addr3"].ToString(),
                    Addr4 = dr["Addr4"].ToString(),
                    Postcode = dr["Postcode"].ToString(),
                    SpecialistType = dr["ProfessionalServiceProviderType"].ToString(),
                    ProfessionalServiceProviderTypeId = (int)dr["ProfessionalServiceProviderTypeId"],
                    DisplayName = dr["FullName"].ToString() + " ("+ dr["ProfessionalServiceProviderType"].ToString() + ")",
                    Email = dr["Email"].ToString()
                };
                professionalServiceProvider.FullAddress = professionalServiceProvider.GetFullAddress();
                list.Add(professionalServiceProvider);
            }
            return list;
        }

        public override void Update(List<Person> persons)
        {

        }

        public override void Update(Person person)
        {
            CommonFunctions.UpdateApostrophe(person);
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE ProfessionalServiceProvider SET ");
            sb.Append("FullName='" + person.FullName.Trim() + "'");
            sb.Append(",Addr1='" + person.Addr1.Trim() + "'");
            sb.Append(",Addr2='" + person.Addr2.Trim() + "'");
            sb.Append(",Addr3='" + person.Addr3.Trim() + "'");
            if(person.Addr4 !=string.Empty)
                sb.Append(",Addr4='" + person.Addr4.Trim() + "'");
            else
                sb.Append(",Addr4=null");
            sb.Append(",Postcode='" + person.Postcode.Trim() + "'");
            sb.Append(",Phone='" + person.Phone.Trim() + "'");
            if (person.Email != string.Empty)
                sb.Append(",Email='" + person.Email.Trim() + "'");
            else
                sb.Append(",Email=null");
            sb.Append(",ProfessionalServiceProviderTypeId=" + person.ProfessionalServiceProviderTypeId);
            
            //sb.Append(",ServiceTypeId=" + person.ServiceTypeId);
            sb.Append(" WHERE Professionalserviceprociderid=" + person.PersonId );

            string sql = sb.ToString();

            //DBCommand db = new DBCommand();
            dbc.ExecuteCommand(sql);
            //dbc.CloseConnection();
        }

        public override int Add(Person person)
        {
            CommonFunctions.UpdateApostrophe(person);
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO ProfessionalServiceProvider (FullName,Addr1,Addr2,Addr3,Addr4,Postcode,Phone,Email,ProfessionalServiceProviderTypeId) VALUES (");
            sb.Append("'" + person.FullName + "'");
            sb.Append(",'" + person.Addr1 + "'");
            sb.Append(",'" + person.Addr2 + "'");
            sb.Append(",'" + person.Addr3 + "'");
            if (person.Addr4 != string.Empty)
                sb.Append(",'" + person.Addr4 + "'");
            else
                sb.Append(",null");

            sb.Append(",'" + person.Postcode + "'");
            sb.Append(",'" + person.Phone + "'");
            if (person.Email != string.Empty)
                sb.Append(",'" + person.Email + "'");
            else
                sb.Append(",null");
            sb.Append("," + person.ProfessionalServiceProviderTypeId);

            sb.Append(")");

            string sql = sb.ToString();            
            int returnDoctorId = dbc.ExecuteCommand(sql);
            return returnDoctorId;
        }

        public override int Add(Person person, int StudentId)
        {
            throw new NotImplementedException("not implemented");                
        }

        public List<ProfessionalServiceType> GetProfessionalServiceTypes()
        {
            List<ProfessionalServiceType> list = new List<ProfessionalServiceType>();
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_SpecialistsForAppointments");
            //dbc.CloseConnection();

            foreach (DataRow dr in dt.Rows)
            {
                ProfessionalServiceType type = new ProfessionalServiceType
                {
                    ProfessionalServiceProviderTypeId = (int)dr["ProfessionalServiceProviderTypeId"],
                    ProfessionalServiceProviderType = dr["ProfessionalServiceProviderType"].ToString(),
                };
                list.Add(type);
            }
            return list;
        }

        //public override int Add(Person person, int StudentId)
        //{
        //    // Add doctor
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("INSERT INTO DOCTOR (FullName,Addr1,Addr2,Addr3,Addr4,Postcode,Phone,Email) VALUES (");
        //    sb.Append("'"+person.FullName+ "'");
        //    sb.Append(",'"+ person.Addr1 + "'");
        //    sb.Append(",'" + person.Addr2 + "'");
        //    sb.Append(",'" + person.Addr3 + "'");
        //    if (person.Addr4 != string.Empty)
        //        sb.Append(",'" + person.Addr4 + "'");
        //    else
        //        sb.Append(",null");

        //    sb.Append(",'" + person.Postcode + "'");
        //    sb.Append(",'" + person.Phone + "'");
        //    if (person.Email != string.Empty)
        //        sb.Append(",'" + person.Email + "'");
        //    else
        //        sb.Append(",null");
        //   // sb.Append("," + person.ServiceTypeId);

        //    sb.Append(")");

        //    string sql = sb.ToString();

        //    //DBCommand db = new DBCommand(DBCommand.TransactionType.WithTransaction);
        //    int returnDoctorId = dbc.ExecuteCommand(sql);

        //    // Allocate doctor

        //    sb = new StringBuilder();
        //    sb.Append("INSERT INTO StudentDoctor ");
        //    sb.Append("(DoctorId,StudentId)");
        //    sb.Append(" VALUES ");
        //    sb.Append("(" + returnDoctorId + "," + StudentId + ")");
        //    sql = sb.ToString();

        //    dbc.ExecuteCommand(sql);
        //    //dbc.CommitTransactions();
        //    //dbc.CloseConnection();
        //    return returnDoctorId;
        //}

        public override void Allocate(Person person, int StudentId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO StudentProfessionalServiceProvider");
            sb.Append("(Professionalserviceprociderid,StudentId)");
            sb.Append(" VALUES ");
            sb.Append("(" + person.PersonId + "," + StudentId + ")");
            string sql = sb.ToString();

           // DBCommand db = new DBCommand();
            int returnDoctorId = dbc.ExecuteCommand(sql);
           // db.CommitTransactions();
            //db.CloseConnection();

        }

        public override void Remove(Person person, int StudentId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM StudentProfessionalServiceProvider WHERE Professionalserviceprociderid=" + person.PersonId+" AND StudentId="+ StudentId);
            
            string sql = sb.ToString();

            //DBCommand db = new DBCommand();
            int returnDoctorId = dbc.ExecuteCommand(sql);
            //db.CommitTransactions();
            //db.CloseConnection();
        }

        public override bool PersonExists(int PersonId, int StudentId)
        {
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_StudentProfessionalServiceProviders WHERE Professionalserviceprociderid=" + PersonId + " AND StudentId="+StudentId);
            return dt.Rows.Count > 0;
        }

        //public override DataTable GeteExportDatatable(List<object> list)
        //{
        //    throw new NotImplementedException("not implemented");
        //}
    }
}