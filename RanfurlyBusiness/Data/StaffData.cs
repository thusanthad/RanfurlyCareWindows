using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;

namespace RanfurlyBusiness
{
    public class StaffData : DataBase
    {
        public StaffData()
        {

        }

        public StaffData(DBCommand dbc) : base(dbc)
        {

        }

        //public StaffData(DBCommand.TransactionType trType):base(trType)
        //{

        //}
        public override List<Person> GetList(string sql)
        {
            List<Person> staffList = new List<Person>();
            DataTable dt = dbc.GetDataTable(sql);
            foreach (DataRow dr in dt.Rows)
            {
                staffList.Add(GetStaff(dr));
            }
            return staffList;
        }
        
        public override List<Person> GetList()
        {
            List<Person> staffList = new List<Person>();
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_Staff");
            foreach (DataRow dr in dt.Rows)
            {                
                staffList.Add(GetStaff(dr));
            }
            return staffList;
        }

        private Staff GetStaff(DataRow dr)
        {
            var staff = new Staff
            {
                PersonId = (int)dr["StaffId"],
                FirstName = dr["FirstName"].ToString(),
                LastName = dr["LastName"].ToString(),
                FullName = dr["FullName"].ToString(),
                HomePhone = dr["HomePhone"].ToString(),
                MobilePhone = dr["MobilePhone"].ToString(),
                Addr1 = dr["Addr1"].ToString(),
                Addr2 = dr["Addr2"].ToString(),
                Addr3 = dr["Addr3"].ToString(),
                Addr4 = dr["Addr4"].ToString(),
                Postcode = dr["Postcode"].ToString(),
                Title = dr["Title"].ToString(),
                Email = dr["Email"].ToString(),
                TitleId = (int)dr["TitleId"],
            };
            staff.FullAddress = staff.GetFullAddress();
            staff.Locations = GetLocations(staff.PersonId);
            return staff;
        }

        private List<Location> GetLocations(int staffId)
        {
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_StaffLocation Where StaffId=" + staffId);

            List<Location> list = new List<Location>();
            foreach (DataRow dr in dt.Rows)
            {
                Location title = new Location
                {
                    LocationId = (int)dr["LocationId"],
                    LocationName = dr["LocationName"].ToString(),
                    LocationNameWithoutAbbreviation = dr["LocationName"].ToString(),
                    Abbreviation = dr["Abbreviation"].ToString()
                };
                list.Add(title);
            }
            return list;
        }

        public override List<Person> GetList(int PersonId)
        {
            List<Person> staffList = new List<Person>();
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_Staff WHERE StaffId=" + PersonId);
            dbc.CloseConnection();

            foreach (DataRow dr in dt.Rows)
            {
                Person staff = new Staff
                {
                    PersonId = (int)dr["StaffId"],
                    //ServiceTypeId = (int)dr["ServiceTypeId"],
                    FirstName = dr["FirstName"].ToString(),
                    LastName = dr["LastName"].ToString(),
                    HomePhone = dr["HomePhone"].ToString(),
                    MobilePhone = dr["MobilePhone"].ToString(),
                    Addr1 = dr["Addr1"].ToString(),
                    Addr2 = dr["Addr2"].ToString(),
                    Addr3 = dr["Addr3"].ToString(),
                    Addr4 = dr["Addr4"].ToString(),
                    Postcode = dr["Postcode"].ToString(),
                    Email = dr["Email"].ToString()
                };
                staff.FullAddress = staff.GetFullAddress();
                staffList.Add(staff);
            }
            return staffList;
        }

        public override void Update(List<Person> persons)
        {

        }

        public override void Update(Person person)
        {
            Staff staff = (Staff)person;
            CommonFunctions.UpdateApostrophe(staff);
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Staff SET ");
            sb.Append("firstName='" + staff.FirstName + "'");
            sb.Append(",LastName='" + staff.LastName + "'");
            sb.Append(",Addr1='" + staff.Addr1.Trim() + "'");
            sb.Append(",Addr2='" + staff.Addr2.Trim() + "'");
            sb.Append(",Addr3='" + staff.Addr3.Trim() + "'");
            if (staff.Addr4 != string.Empty)
                sb.Append(",Addr4='" + staff.Addr4.Trim() + "'");
            else
                sb.Append(",Addr4=null");
            sb.Append(",Postcode='" + staff.Postcode.Trim() + "'");
            
            if (staff.HomePhone != string.Empty)
                sb.Append(",HomePhone='" + staff.HomePhone.Trim() + "'");
            else
                sb.Append(",HomePhone=null");
            //if (staff.Email != string.Empty)
            //    sb.Append(",Email='" + staff.Email.Trim() + "'");
            sb.Append(",TitleId=" + staff.TitleId);
            //sb.Append(",MobilePhone='" + staff.MobilePhone+"'");
            if (staff.MobilePhone != string.Empty)
                sb.Append(",MobilePhone='" + staff.MobilePhone.Trim() + "'");
            else
                sb.Append(",MobilePhone=null");
            if (staff.Email != string.Empty)
                sb.Append(",Email='" + staff.Email.Trim() + "'");
            else
                sb.Append(",Email=null");

            sb.Append(" WHERE StaffId=" + person.PersonId);
            
            string sql = sb.ToString();
            //DBCommand db = new DBCommand();
            dbc.ExecuteCommand(sql);

            sql = "DELETE FROM StaffLocation WHERE StaffId = " + staff.PersonId;
            dbc.ExecuteCommand(sql);

            foreach (Location wc in staff.Locations)
            {
                sql = "INSERT INTO StaffLocation (StaffId,LocationId) VALUES (" + staff.PersonId + "," + wc.LocationId + ")";
                dbc.ExecuteCommand(sql);
            }
            //dbc.CommitTransactions();
            //dbc.CloseConnection();
        }
        public override int Add(Person person)
        {
            Staff staff = (Staff)person;
            CommonFunctions.UpdateApostrophe(staff);
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO STAFF (firstName,LastName,HomePhone,MobilePhone,Email,Addr1,Addr2,Addr3,Addr4,Postcode,TitleId,PersonTypeId) VALUES (");
            sb.Append("'" + staff.FirstName + "'");
            sb.Append(",'" + staff.LastName + "'");
            if (staff.HomePhone != string.Empty)
                sb.Append(",'" + staff.HomePhone + "'");
            else
                sb.Append(",null");

            if (staff.MobilePhone != string.Empty)
                sb.Append(",'" + staff.MobilePhone + "'");
            else
                sb.Append(",null");

            if (staff.Email != string.Empty)
                sb.Append(",'" + staff.Email + "'");
            else
                sb.Append(",null");

            sb.Append(",'" + staff.Addr1 + "'");
            sb.Append(",'" + staff.Addr2 + "'");
            sb.Append(",'" + staff.Addr3 + "'");
            if (staff.Addr4 != string.Empty)
                sb.Append(",'" + staff.Addr4 + "'");
            else
                sb.Append(",null");

            sb.Append(",'" + staff.Postcode + "'");
            sb.Append(","+staff.TitleId);
            sb.Append(","+2 +")");

            string sql = sb.ToString();
            int staffId = dbc.ExecuteCommand(sql);

            foreach (Location wc in staff.Locations)
            {
                sql = "INSERT INTO StaffLocation (StaffId,LocationId) VALUES (" + staffId + "," + wc.LocationId + ")";
                dbc.ExecuteCommand(sql);
            }
            //dbc.CommitTransactions();
            //dbc.CloseConnection();
            return staffId;
        }

        public override int Add(Person person, int StudentId)
        {
            throw new NotImplementedException("not implemented");
        }

        public override void Allocate(Person person, int PersonId)
        {
            throw new NotImplementedException("not implemented");
        }

        public override void Remove(Person person, int StudentId)
        {
            throw new NotImplementedException("not implemented");
        }

        public override bool PersonExists(int PersonId, int StudentId)
        {
            throw new NotImplementedException("not implemented");
        }

        //public override DataTable GeteExportDatatable(List<object> list)
        //{
        //    throw new NotImplementedException("not implemented");
        //}
    }
}