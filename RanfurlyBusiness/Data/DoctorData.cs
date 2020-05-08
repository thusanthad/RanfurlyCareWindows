using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;
using DataAccess;

namespace RanfurlyBusiness
{
    public class DoctorData : DataBase
    {
        public DoctorData()
        {

        }

        //public DoctorData(DBCommand.TransactionType trtype):base(trtype)
        //{

        //}

        public DoctorData(DBCommand dbCommand):base(dbCommand)
        {

        }
        //public DoctorData(DBCommand.TransactionType transactionType) :base(transactionType)
        //{

        //}

        public override List<Person> GetList(string sql)
        {
            throw new NotImplementedException("not implemented");
        }

        public override List<Person> GetList()
        {
            List<Person> doctorList = new List<Person>();
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_Doctors");
            dbc.CloseConnection();

            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    doctorList.Add(GetDoctor(dr));
                    //Person doctor = new Doctor
                    //{
                    //    PersonId = (int)dr["DoctorId"],
                    //    //ServiceTypeId = (int)dr["ServiceTypeId"],
                    //    FullName = dr["FullName"].ToString(),
                    //    Addr1 = dr["Addr1"].ToString(),
                    //    Addr2 = dr["Addr2"].ToString(),
                    //    Addr3 = dr["Addr3"].ToString(),
                    //    Addr4 = dr["Addr4"].ToString(),
                    //    Postcode = dr["Postcode"].ToString(),
                    //    Phone = dr["Phone"].ToString(),
                    //    //MobilePhone = dr["MobilePhone"].ToString(),
                    //    Email = dr["Email"].ToString()
                    //};
                    //doctor.FullAddress = doctor.GetFullAddress();
                    //doctorList.Add(doctor);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            return doctorList;
        }

        public override List<Person> GetList(int DoctorId)
        {
            List<Person> doctors = new List<Person>();
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_StudentDoctors WHERE StudentId=" + DoctorId);
            //dbc.CloseConnection();

            foreach (DataRow dr in dt.Rows)
            {
                doctors.Add(GetDoctor(dr));
                //Person doctor = new Doctor
                //{
                //    PersonId = (int)dr["DoctorId"],
                //    //ServiceTypeId = (int)dr["ServiceTypeId"],
                //    FullName = dr["FullName"].ToString(),
                //    Phone = dr["Phone"].ToString(),
                //    Addr1 = dr["Addr1"].ToString(),
                //    Addr2 = dr["Addr2"].ToString(),
                //    Addr3 = dr["Addr3"].ToString(),
                //    Addr4 = dr["Addr4"].ToString(),
                //    Postcode = dr["Postcode"].ToString(),
                //    Email = dr["Email"].ToString()
                //};
                //doctor.FullAddress = doctor.GetFullAddress();
                //doctors.Add(doctor);
            }
            return doctors;
        }

        private Person GetDoctor(DataRow dr)
        {
            Person doctor = new Doctor
            {
                PersonId = (int)dr["DoctorId"],
                //ServiceTypeId = (int)dr["ServiceTypeId"],
                FullName = dr["FullName"].ToString(),
                Phone = dr["Phone"].ToString(),
                Addr1 = dr["Addr1"].ToString(),
                Addr2 = dr["Addr2"].ToString(),
                Addr3 = dr["Addr3"].ToString(),
                Addr4 = dr["Addr4"].ToString(),
                Postcode = dr["Postcode"].ToString(),
                Email = dr["Email"].ToString()
            };
            doctor.FullAddress = doctor.GetFullAddress();
            return doctor;
        }

        public override void Update(List<Person> persons)
        {

        }

        public override void Update(Person person)
        {
            CommonFunctions.UpdateApostrophe(person);
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE DOCTOR SET ");
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
            //sb.Append(",ServiceTypeId=" + person.ServiceTypeId);
            sb.Append(" WHERE DoctorId=" + person.PersonId );

            string sql = sb.ToString();

            //DBCommand db = new DBCommand();
            dbc.ExecuteCommand(sql);
            //dbc.CloseConnection();
        }

        public override int Add(Person person)
        {
            CommonFunctions.UpdateApostrophe(person);
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO DOCTOR (FullName,Addr1,Addr2,Addr3,Addr4,Postcode,Phone,Email) VALUES (");
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
           // sb.Append("," + person.ServiceTypeId);

            sb.Append(")");

            string sql = sb.ToString();            
            int returnDoctorId = dbc.ExecuteCommand(sql);
            return returnDoctorId;
        }
        public override int Add(Person person, int StudentId)
        {
            CommonFunctions.UpdateApostrophe<Person>(person);
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO DOCTOR (FullName,Addr1,Addr2,Addr3,Addr4,Postcode,Phone,Email) VALUES (");
            sb.Append("'"+person.FullName+ "'");
            sb.Append(",'"+ person.Addr1 + "'");
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
           // sb.Append("," + person.ServiceTypeId);

            sb.Append(")");

            string sql = sb.ToString();

            //DBCommand db = new DBCommand(DBCommand.TransactionType.WithTransaction);
            int returnDoctorId = dbc.ExecuteCommand(sql);

            // Allocate doctor

            sb = new StringBuilder();
            sb.Append("INSERT INTO StudentDoctor ");
            sb.Append("(DoctorId,StudentId)");
            sb.Append(" VALUES ");
            sb.Append("(" + returnDoctorId + "," + StudentId + ")");
            sql = sb.ToString();

            dbc.ExecuteCommand(sql);
            //dbc.CommitTransactions();
            //dbc.CloseConnection();
            return returnDoctorId;
        }

        public override void Allocate(Person person, int StudentId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO StudentDoctor ");
            sb.Append("(DoctorId,StudentId)");
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
            sb.Append("DELETE FROM StudentDoctor WHERE DoctorId="+person.PersonId+" AND StudentId="+ StudentId);
            
            string sql = sb.ToString();

            //DBCommand db = new DBCommand();
            int returnDoctorId = dbc.ExecuteCommand(sql);
            //db.CommitTransactions();
            //db.CloseConnection();
        }

        public override bool PersonExists(int PersonId, int StudentId)
        {
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_StudentDoctors WHERE DoctorId="+PersonId + " AND StudentId="+StudentId);
            return dt.Rows.Count > 0;
        }

        //public override DataTable GeteExportDatatable(List<object> list)
        //{
        //    throw new NotImplementedException("not implemented");
        //}
    }
}