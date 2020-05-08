using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;

namespace RanfurlyBusiness
{
    public class WorkCentreData
    {
        public List<WorkCentre> GetList()
        {
            List<WorkCentre> list = new List<WorkCentre>();

            DBCommand db = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
            DataTable dt = db.GetDataTable("SELECT * FROM vw_WorkCentre");

            foreach (DataRow dr in dt.Rows)
            {
                WorkCentre title = new WorkCentre
                {
                    WorkCentreId = (int)dr["WorkCentreId"],
                    WorkCentreName = dr["WorkCentre"].ToString(),
                    Abbreviation = dr["Abbreviation"].ToString()
                };
                list.Add(title);
            }
            return list;
        }

        public int Add(WorkCentre workCentre)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO WORKCENTRE (WorkCentre,Abbreviation) VALUES ('");
            sb.Append(workCentre.WorkCentreName + "','");
            sb.Append(workCentre.Abbreviation + "')");

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
