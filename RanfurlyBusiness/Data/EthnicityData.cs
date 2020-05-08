using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;

namespace RanfurlyBusiness
{
    public class EthnicityData
    {
        public List<Ethnicity> GetList()
        {
            List<Ethnicity> list = new List<Ethnicity>();

            DBCommand db = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
            DataTable dt = db.GetDataTable("SELECT * FROM vw_Ethnicity");

            foreach (DataRow dr in dt.Rows)
            {
                Ethnicity eth = new Ethnicity
                {
                    EthnicityId = (int)dr["EthnicityId"],
                    EthnicityName = dr["Ethnicity"].ToString()
                };
                list.Add(eth);
            }
            return list;
        }

        public int Add(Ethnicity ethnicity)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO ETHNICITY (Ethnicity) VALUES ('");
            sb.Append(ethnicity.EthnicityName + "')");

            string sql = sb.ToString();
            DBCommand db = new DBCommand();
            return db.ExecuteCommand(sql);
        }

        public void Update(List<Ethnicity> list)
        {
            DBCommand db = new DBCommand();
            foreach (Ethnicity eth in list)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append("UPDATE ETHNICITY SET ");
                sb.Append("Ethnicity = '" + eth.EthnicityName + "' ");
                sb.Append("WHERE EthnicityId = " + eth.EthnicityId);
                string sql = sb.ToString();
                db.ExecuteCommand(sql);
            }
        }
    }
}
