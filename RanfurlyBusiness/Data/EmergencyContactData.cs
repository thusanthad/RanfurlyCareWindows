using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;

namespace RanfurlyBusiness
{
    public class EmergencyContactData : DataBase
    {
        public EmergencyContactData()
        {

        }

        public EmergencyContactData(DBCommand dbCommand) : base(dbCommand)
        {


        }
        public override List<Person> GetList(string sql)
        {
            throw new NotImplementedException("not implemented");
        }

        public override List<Person> GetList()
        {
            List<Person> emergencyContactList = new List<Person>();
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_StudentEmergencyContacts");
            foreach (DataRow dr in dt.Rows)
            {
                var emergencyContact = new EmergencyContact
                {
                    PersonId = (int)dr["StudentId"],
                    //FirstName = dr["FirstName"].ToString(),
                    //LastName = dr["LastName"].ToString(),
                    FullName = dr["FullName"].ToString(),
                    Phone = dr["Phone"].ToString(),
                    Addr1 = dr["Addr1"].ToString(),
                    Addr2 = dr["Addr2"].ToString(),
                    Addr3 = dr["Addr3"].ToString(),
                    Addr4 = dr["Addr4"].ToString(),
                    Postcode = dr["Postcode"].ToString(),
                    Relationship = dr["Relationship"].ToString()                               
            };
                emergencyContact.FullAddress = emergencyContact.GetFullAddress();
                emergencyContactList.Add(emergencyContact);
            }
            return emergencyContactList;
        }

        public override List<Person> GetList(int PersonId)
        {
            List<Person> emergencyContactList = new List<Person>();
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_StudentEmergencyContacts WHERE StudentId="+ PersonId);
            foreach (DataRow dr in dt.Rows)
            {
                var emergencyContact = new EmergencyContact
                {
                    StudentEmergencyContactId = (int)dr["StudentEmergencyContactId"],
                    PersonId = (int)dr["StudentId"],
                    //FirstName = dr["FirstName"].ToString(),
                    //LastName = dr["LastName"].ToString(),
                    FullName = dr["FullName"].ToString(),
                    Phone = dr["Phone"].ToString(),
                    Addr1 = dr["Addr1"].ToString(),
                    Addr2 = dr["Addr2"].ToString(),
                    Addr3 = dr["Addr3"].ToString(),
                    Addr4 = dr["Addr4"].ToString(),
                    Postcode = dr["Postcode"].ToString(),
                    Relationship = dr["Relationship"].ToString()
                };
                emergencyContact.FullAddress = emergencyContact.GetFullAddress();
                emergencyContactList.Add(emergencyContact);
            }
            return emergencyContactList;
        }

        public override void Update(List<Person> persons)
        {

        }

        public override void Update(Person person)
        {
            EmergencyContact ec = (EmergencyContact)person;
            CommonFunctions.UpdateApostrophe<EmergencyContact>(ec);
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE StudentEmergencyContact SET ");
            sb.Append("FullName ='" + ec.FullName + "'");
            sb.Append(",Addr1='" + ec.Addr1 + "'");
            sb.Append(",Addr2='" + ec.Addr2 + "'");
            sb.Append(",Addr3='" + ec.Addr3 + "'");
            if (ec.Addr4 != string.Empty)
                sb.Append(",Addr4='" + ec.Addr4 + "'");
            sb.Append(",Postcode='" + ec.Postcode + "'");
            sb.Append(",Phone='" + ec.Phone + "'");
            sb.Append(",Relationship='" + ec.Relationship + "'");
            sb.Append(" WHERE StudentEmergencyContactId =" + ec.StudentEmergencyContactId);

            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }
        public override int Add(Person person)
        {
            throw new NotImplementedException();
        }

        public override int Add(Person person, int StudentId)
        {
            EmergencyContact ec = (EmergencyContact)person;
            CommonFunctions.UpdateApostrophe<EmergencyContact>(ec);
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO StudentEmergencyContact (StudentId,FullName,Addr1,Addr2,Addr3,Addr4,Postcode,Phone,Relationship) VALUES (");
            sb.Append(StudentId);
            sb.Append(",'" + ec.FullName + "'");
            sb.Append(",'" + ec.Addr1 + "'");
            sb.Append(",'" + ec.Addr2 + "'");
            sb.Append(",'" + ec.Addr3 + "'");
            if (ec.Addr4 != string.Empty)
                sb.Append(",'" + ec.Addr4 + "'");
            else
                sb.Append(",null");

            sb.Append(",'" + ec.Postcode + "'");
            sb.Append(",'" + ec.Phone + "'");
            sb.Append(",'" + ec.Relationship + "')");
            //sb.Append(")");

            string sql = sb.ToString();

            //DBCommand db = new DBCommand(DBCommand.TransactionType.WithTransaction);
            int returnValue = dbc.ExecuteCommand(sql);
            //db.CommitTransactions();
            //db.CloseConnection();
            return returnValue;


        }

        public override void Allocate(Person person, int PersonId)
        {

        }

        public override void Remove(Person person, int StudentEmergencyContactId)
        {
            EmergencyContact ec = (EmergencyContact)person;
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM StudentEmergencyContact WHERE StudentEmergencyContactId="+ ec.StudentEmergencyContactId);
            string sql = sb.ToString();

            //DBCommand db = new DBCommand(DBCommand.TransactionType.WithTransaction);
            dbc.ExecuteCommand(sql);
            //db.CommitTransactions();
            //dbc.CloseConnection();
        }

        public override bool PersonExists(int StudentEmergencyContactId, int StudentId)
        {
            //DataTable dt = dbc.GetDataTable("SELECT * FROM vw_StudentEmergencyContacts WHERE StudentEmergencyContactId=" + StudentEmergencyContactId);
            //return dt.Rows.Count > 0;
            throw new NotImplementedException();

        }

        //public override DataTable GeteExportDatatable(List<object> list)
        //{
        //    throw new NotImplementedException("not implemented");
        //}
    }
}