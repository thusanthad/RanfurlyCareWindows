using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;

namespace RanfurlyBusiness
{
    public class LocationData
    {
        public List<Location> GetList()
        {
            List<Location> list = new List<Location>();

            DBCommand db = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
            DataTable dt = db.GetDataTable("SELECT * FROM vw_Locations");

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(GetLocation(dr));
            }
            return list;
        }


        public List<Location> GetList(string sql)
        {
            List<Location> list = new List<Location>();

            DBCommand db = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
            DataTable dt = db.GetDataTable(sql);

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(GetLocation(dr));
            }
            return list;
        }

        public List<Location> GetList(int locationId)
        {
            List<Location> list = new List<Location>();

            DBCommand db = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
            DataTable dt = db.GetDataTable("SELECT * FROM vw_Locations Where LocationId="+locationId);

            foreach (DataRow dr in dt.Rows)
            {
                list.Add(GetLocation(dr));
            }
            return list;
        }

        private Location GetLocation(DataRow dr)
        {
            Location location = new Location
            {
                LocationId = (int)dr["LocationId"],
                LocationName = dr["LocationName"].ToString() + " (" + dr["Abbreviation"].ToString() + ")",
                LocationNameWithoutAbbreviation = dr["LocationName"].ToString(),
                Abbreviation = dr["Abbreviation"].ToString(),
                FullAddress = dr["FullAddress"].ToString(),
                Telephone = dr["Telephone"].ToString(),
                IsResidence = (bool)dr["IsResidence"],
                IsRollCall = (bool)dr["IsRollCall"],
                IsStudentCentre = (bool)dr["IsStudentCentre"],
                RollReference = dr["RollReference"].ToString()
            };
            if (location.FullAddress == string.Empty)
                location.FullAddress = "** please update **";
            if (location.Telephone == string.Empty)
                location.Telephone = "** please update **";
           return location;
        }

        public int Add(Location location)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO LOCATION (LocationName,Abbreviation,FullAddress,Telephone,IsResidence,IsStudentCentre,IsRollCall,RollReference) VALUES ('");
            sb.Append(location.LocationName +"'");
            sb.Append(",'" +location.Abbreviation + "'");
            if(location.FullAddress!=null && location.Telephone!=string.Empty)
                sb.Append(",'" + location.FullAddress + "'");
            else
                sb.Append(",null");
            if (location.Telephone != null && location.Telephone != string.Empty)
                sb.Append(",'" + location.Telephone + "'");
            else
                sb.Append(",null");
            sb.Append("," + location.IsResidence);
            sb.Append("," + location.IsStudentCentre);
            sb.Append("," + location.IsRollCall);
            if(location.RollReference != null && location.RollReference != string.Empty)
                sb.Append("," + location.RollReference);
            else
                sb.Append(",null");

            sb.Append(")");
            string sql = sb.ToString();
            DBCommand db = new DBCommand();
            return db.ExecuteCommand(sql);
        }

        public void Update(Location location)
        {
            DBCommand db = new DBCommand();
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE Location SET ");
            sb.Append("LocationName = '" + location.LocationNameWithoutAbbreviation + "'");
            sb.Append(",Abbreviation = '" + location.Abbreviation + "' ");
            if (location.FullAddress != null && location.Telephone != string.Empty)
                sb.Append(",FullAddress='" + location.FullAddress + "'");
            else
                sb.Append(",FullAddress=null");
            if (location.Telephone != null && location.Telephone != string.Empty)
                sb.Append(",Telephone='" + location.Telephone + "'");
            else
                sb.Append(",Telephone=null");
            sb.Append(",IsResidence=" + location.IsResidence);
            sb.Append(",IsStudentCentre=" + location.IsStudentCentre);
            sb.Append(",IsRollCall=" + location.IsRollCall);
            if (location.RollReference != null && location.RollReference != string.Empty)
                sb.Append(",RollReference='" + location.RollReference + "'");
            else
                sb.Append(",RollReference=null");
            sb.Append(" WHERE LocationId = " + location.LocationId);
            
            string sql = sb.ToString();
            db.ExecuteCommand(sql);
            db.CloseConnection();
        }

        public Location GetLocationFromReference(string reference)
        {
            DBCommand db = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
            DataTable dt = db.GetDataTable("SELECT * FROM vw_Locations Where RollReference ='"+reference +"'");
            if (dt.Rows.Count > 0)
                return GetLocation(dt.Rows[0]);
            else
                return null;


        }
    }
}
