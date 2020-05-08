using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;

namespace RanfurlyBusiness
{
    public class StudentPhysicalAbilityData
    {
        protected DBCommand dbc;

        public StudentPhysicalAbilityData(DBCommand dbCommand)
        {
            dbc = dbCommand;
        }

        public StudentPhysicalAbilityData()
        {
            dbc = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
        }

        public List<PhysicalAbility> GetList(int PersonId)
        {
            List<PhysicalAbility> list = new List<PhysicalAbility>();
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_StudentPhysicalAbility WHERE StudentId=" + PersonId);
            dbc.CloseConnection();

            foreach (DataRow dr in dt.Rows)
            {
                PhysicalAbility pc = new PhysicalAbility();
                pc.StudentPhysicalAbilityId = (int)dr["StudentPhysicalAbilityId"];
                pc.StudentId = (int)dr["StudentId"];
                pc.Item = dr["Item"].ToString();
                pc.Description=dr["Description"].ToString();
                pc.Comments = dr["Comments"].ToString();
                
                list.Add(pc);
            }
            return list;
        }

        public void Update(PhysicalAbility pc)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE StudentPhysicalAbility SET ");
            sb.Append("Item='"+ pc.Item + "'");
            sb.Append(",Description='" + pc.Description.Replace("'", "''") + "'");
            if (pc.Comments != null && pc.Comments != string.Empty)
                sb.Append(",Comments='" + pc.Comments.Replace("'", "''") + "'"); 
            else
                sb.Append(",Comments=null");
            sb.Append(" WHERE StudentPhysicalAbilityId =" + pc.StudentPhysicalAbilityId);
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }

        public void Add(PhysicalAbility Pa, int StudentId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO StudentPhysicalAbility (StudentId,Item,Description,Comments) VALUES (");
            sb.Append(StudentId);            
            sb.Append(",'" + Pa.Item.Replace("'", "''") + "'");
            sb.Append(",'" + Pa.Description.Replace("'", "''") + "'");
            if(Pa.Comments !=null && Pa.Comments!=string.Empty)
                sb.Append(",'" + Pa.Comments.Replace("'", "''") + "'");
            else
                sb.Append(",null");

            sb.Append(")");
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }

        public void Remove(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM StudentPhysicalAbility WHERE StudentPhysicalAbilityId=" + id);      
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }
    }
}