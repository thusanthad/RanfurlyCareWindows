using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Globalization;
using DataAccess;

namespace RanfurlyBusiness
{
    public class NextOfKinData : DataBase
    {
        public NextOfKinData()
        {

        }

        public NextOfKinData(DBCommand dbCommand) : base(dbCommand)
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
            //throw new NotImplementedException("not implemented");
            List<Person> nextOfKinList = new List<Person>();
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_NextOfKin");

            foreach (DataRow dr in dt.Rows)
            {
                try
                {
                    Person nextOfKin = new NextOfKin
                    {
                        //StudentNextOfKinId = (int)dr["StudentNextOfKinId"],
                        PersonId = (int)dr["NextOfKinId"],
                        FullName = dr["FullName"].ToString(),
                        Addr1 = dr["Addr1"].ToString(),
                        Addr2 = dr["Addr2"].ToString(),
                        Addr3 = dr["Addr3"].ToString(),
                        Addr4 = dr["Addr4"].ToString(),
                        Postcode = dr["Postcode"].ToString(),
                        Phone = dr["Phone"].ToString(),
                        MobilePhone = dr["MobilePhone"].ToString(),
                        Email = dr["Email"].ToString()
                    };
                    nextOfKin.FullAddress = nextOfKin.GetFullAddress();
                    nextOfKinList.Add(nextOfKin);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }

            }
            return nextOfKinList;
        }

        public override List<Person> GetList(int StudentId)
        {
            List<Person> nextOfKins = new List<Person>();
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_StudentNextOfKin WHERE StudentId=" + StudentId);
            dbc.CloseConnection();

            foreach (DataRow dr in dt.Rows)
            {
                Person nextOfKin = new NextOfKin
                {
                    StudentNextOfKinId = (int)dr["StudentNextOfKinId"],
                    PersonId = (int)dr["NextOfKinId"],
                    Phone = dr["Phone"].ToString(),
                    MobilePhone = dr["MobilePhone"].ToString(),
                    Relationship = dr["Relationship"].ToString(),
                    FullName = dr["FullName"].ToString(),
                    Addr1 = dr["Addr1"].ToString(),
                    Addr2 = dr["Addr2"].ToString(),
                    Addr3 = dr["Addr3"].ToString(),
                    Addr4 = dr["Addr4"].ToString(),
                    Postcode = dr["Postcode"].ToString(),
                    Email = dr["Email"].ToString()
                };
                //var nextOfKin = new NextOfKin();
                //
                //if (nextOfKin.FullAddress == string.Empty)
                //{
                    nextOfKin.FullAddress = nextOfKin.GetFullAddress();
                //}

                nextOfKins.Add(nextOfKin);
            }
            return nextOfKins;
        }

        public override void Update(List<Person> persons)
        {

        }

        public override void Update(Person person)
        {
            NextOfKin nok = (NextOfKin)person;
            CommonFunctions.UpdateApostrophe(nok);
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE StudentNextOfKin SET Relationship = '" + nok.Relationship + "' WHERE StudentNextOfKinId="+nok.StudentNextOfKinId);
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
            
            sb = new StringBuilder();
            sb.Append("UPDATE NextOfKin SET ");
            sb.Append("FullName ='" + nok.FullName + "'");
            sb.Append(",Addr1='" + nok.Addr1 + "'");
            sb.Append(",Addr2='" + nok.Addr2 + "'");
            sb.Append(",Addr3='" + nok.Addr3 + "'");
            if (nok.Addr4 != string.Empty)
                sb.Append(",Addr4='" + nok.Addr4 + "'");
            else
                sb.Append(",Addr4=null");
            sb.Append(",Postcode='" + nok.Postcode + "'");
            sb.Append(",Phone='" + nok.Phone + "'");
            if (nok.MobilePhone != string.Empty)
                sb.Append(",MobilePhone='" + nok.MobilePhone + "'");
            else
                sb.Append(",MobilePhone=null");
            if (nok.Email != string.Empty)
                sb.Append(",Email='" + nok.Email + "'");
            else
                sb.Append(",Email=null");
            //sb.Append(",Relationship='" + ec.Relationship + "'");
            sb.Append(" WHERE NextOfKinId =" + nok.PersonId);

            sql = sb.ToString();
            dbc.ExecuteCommand(sql);

        }

        public override int Add(Person person, int StudentId)
        {
            // Add Next of Kin
            NextOfKin nok = (NextOfKin)person;
            CommonFunctions.UpdateApostrophe(nok);
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO NextOfKin (FullName, Addr1, Addr2, Addr3, Addr4, Postcode, Phone, Email,MobilePhone) VALUES (");
            sb.Append("'" + nok.FullName + "'");            
            sb.Append(",'" + nok.Addr1 + "'");
            sb.Append(",'" + nok.Addr2 + "'");
            sb.Append(",'" + nok.Addr3 + "'");
            if (nok.Addr4 != string.Empty)
                sb.Append(",'" + nok.Addr4 + "'");
            else
                sb.Append(",null");
            sb.Append(",'" + nok.Postcode + "'");
            sb.Append(",'" + nok.Phone + "'");
            if (nok.Email != string.Empty)
                sb.Append(",'" + nok.Email + "'");
            else
                sb.Append(",null");
            if (nok.MobilePhone != string.Empty)
                sb.Append(",'" + nok.MobilePhone + "'");
            else
                sb.Append(",null");

            sb.Append(")");

            string sql = sb.ToString();
            //DBCommand db = new DBCommand(DBCommand.TransactionType.WithTransaction);
            int returnNextOfKinId = dbc.ExecuteCommand(sb.ToString());
            nok.PersonId = returnNextOfKinId;

            // Assign Next of kin
            sb = new StringBuilder();
            sb.Append("INSERT INTO StudentNextOfKin ");
            sb.Append("(NextOfKinId,StudentId,Relationship)");
            sb.Append(" VALUES ");
            sb.Append("(" + nok.PersonId + "," + StudentId + ",'" + nok.Relationship + "')");
            sql = sb.ToString();
            
            dbc.ExecuteCommand(sql);
            //db.CommitTransactions();
            //db.CloseConnection();

            return returnNextOfKinId;

        }

        public override void Allocate(Person person,int StudentId)
        {
            NextOfKin nextofKin = (NextOfKin)person;
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO StudentNextOfKin ");
            sb.Append("(NextOfKinId,StudentId,Relationship)");
            sb.Append(" VALUES ");
            sb.Append("(" + nextofKin.PersonId + "," + StudentId + ",'" + nextofKin.Relationship + "')");
            string sql = sb.ToString();

            //DBCommand db = new DBCommand(DBCommand.TransactionType.WithTransaction);
            int nokId = dbc.ExecuteCommand(sql);
            //dbc.CommitTransactions();
            //db.CloseConnection();

        }

        public override void Remove(Person person, int StudentId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM StudentNextOfKin WHERE NextOfKinId=" + person.PersonId + " AND StudentId=" + StudentId);

            string sql = sb.ToString();

            DBCommand db = new DBCommand(DBCommand.TransactionType.WithTransaction);
            int returnDoctorId = db.ExecuteCommand(sql);
            db.CommitTransactions();
            db.CloseConnection();
        }

        public override int Add(Person person)
        {
            throw new NotImplementedException("not implemented");
            //return 1;
        }

        public override bool PersonExists(int PersonId, int StudentId)
        {
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_StudentNextOfKin WHERE NextOfKinId=" + PersonId + " AND StudentId=" + StudentId);
            return dt.Rows.Count > 0;
        }

        //public override DataTable GeteExportDatatable(List<object> list)
        //{
        //    throw new NotImplementedException("not implemented");
        //}

    }
}