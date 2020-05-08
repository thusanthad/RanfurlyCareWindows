using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;

namespace RanfurlyBusiness
{
    public class StudentBehaviourData//:DataBase
    {
        protected DBCommand dbc;

        public StudentBehaviourData(DBCommand dbCommand)
        {
            dbc = dbCommand;
        }

        public StudentBehaviourData()
        {
            dbc = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
        }

        public List<StudentBehaviour> GetList(int PersonId)
        {
            List<StudentBehaviour> list = new List<StudentBehaviour>();
            
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_StudentBehaviours WHERE StudentId="+ PersonId);

            foreach (DataRow dr in dt.Rows)
            {
                StudentBehaviour riskManagementPlan = new StudentBehaviour
                {
                    StudentBehaviourId = (int)dr["StudentBehaviourId"],
                    StudentId = (int)dr["StudentId"],
                    Profile = dr["Profile"].ToString(),
                    Communication = dr["Communication"].ToString(),
                    Behaviour = dr["Behaviour"].ToString(),
                    StrategyPlan = dr["StrategyPlan"].ToString()
                };
                list.Add(riskManagementPlan);
            }
            return list;
        }

        public int Add(StudentBehaviour behaviour, int StudentId)
        {
            CommonFunctions.UpdateApostrophe(behaviour);
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO StudentBehaviour (StudentId, Profile,Communication,Behaviour,StrategyPlan) VALUES (");
            sb.Append(StudentId + ",'");
            sb.Append(behaviour.Profile + "','");
            sb.Append(behaviour.Communication + "','");
            sb.Append(behaviour.Behaviour + "','");
            sb.Append(behaviour.StrategyPlan + "')");

            string sql = sb.ToString();           
            return dbc.ExecuteCommand(sql);
        }

        public void Update(StudentBehaviour behaviour)
        {
            CommonFunctions.UpdateApostrophe(behaviour);
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE StudentBehaviour SET ");
            sb.Append("Profile = '" + behaviour.Profile + "',");
            sb.Append("Communication = '" + behaviour.Communication + "',");
            sb.Append("Behaviour = '" + behaviour.Behaviour + "',");
            sb.Append("StrategyPlan = '" + behaviour.StrategyPlan + "' ");
            sb.Append("WHERE StudentBehaviourId = " + behaviour.StudentBehaviourId);
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }

        public void Remove(int StudentBehaviourtId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM StudentBehaviour WHERE StudentBehaviourId=" + StudentBehaviourtId);
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }
    }
}
