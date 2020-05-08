using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;

namespace RanfurlyBusiness
{
    public class RiskManagementPlanData//:DataBase
    {
        protected DBCommand dbc;

        public RiskManagementPlanData(DBCommand dbCommand)
        {
            dbc = dbCommand;
        }

        public RiskManagementPlanData()
        {
            dbc = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
        }

        public List<RiskManagementPlan> GetList(int PersonId)
        {
            List<RiskManagementPlan> list = new List<RiskManagementPlan>();
            
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_StudentRiskManagement WHERE StudentId="+ PersonId);

            foreach (DataRow dr in dt.Rows)
            {
                RiskManagementPlan riskManagementPlan = new RiskManagementPlan
                {
                    StudentRiskManagementId = (int)dr["StudentRiskManagementId"],
                    StudentId = (int)dr["StudentId"],
                    Risk = dr["Risk"].ToString(),
                    RiskManagementName = dr["RiskManagementName"].ToString(),
                    EmergencyResponse = dr["EmergencyResponse"].ToString()
                };
                list.Add(riskManagementPlan);
            }
            return list;
        }

        public int Add(RiskManagementPlan riskManagementPlan, int StudentId)
        {
            CommonFunctions.UpdateApostrophe(riskManagementPlan);
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO StudentRiskManagement (StudentId, Risk,RiskManagementName,EmergencyResponse) VALUES (");
            sb.Append(StudentId + ",'");
            sb.Append(riskManagementPlan.Risk + "','");
            sb.Append(riskManagementPlan.RiskManagementName + "','");
            sb.Append(riskManagementPlan.EmergencyResponse + "')");

            string sql = sb.ToString();           
            return dbc.ExecuteCommand(sql);
        }

        public void Update(RiskManagementPlan riskManagementPlan)
        {
            CommonFunctions.UpdateApostrophe(riskManagementPlan);
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE StudentRiskManagement SET ");
            sb.Append("Risk = '" + riskManagementPlan.Risk + "',");
            sb.Append("RiskManagementName = '" + riskManagementPlan.RiskManagementName + "',");
            sb.Append("EmergencyResponse = '" + riskManagementPlan.EmergencyResponse + "' ");
            sb.Append("WHERE StudentRiskManagementId = " + riskManagementPlan.StudentRiskManagementId);
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }

        public void Remove(int StudentRiskManagementId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM StudentRiskManagement WHERE StudentRiskManagementId=" + StudentRiskManagementId);
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }
    }
}
