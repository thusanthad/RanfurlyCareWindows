using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;

namespace RanfurlyBusiness
{
    public class StudentAbilityData
    {
        protected DBCommand dbc;

        public StudentAbilityData(DBCommand dbCommand)
        {
            dbc = dbCommand;
        }

        public StudentAbilityData()
        {
            dbc = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
        }

        public List<StudentAbilityBase> GetList(int PersonId)
        {
            List<StudentAbilityBase> list = new List<StudentAbilityBase>();
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_StudentAbilities WHERE StudentId=" + PersonId);
            //dbc.CloseConnection();

            foreach (DataRow dr in dt.Rows)
            {
                int studentAbilityTypeId = (int)dr["StudentAbilityTypeId"];
                StudentAbilityBase sa;
                switch (studentAbilityTypeId)
                {
                    case 1:
                        sa = new PhysicalAbility();
                        break;
                    case 2:
                        sa = new CommunityOrientation();
                        break;
                    default:
                        sa = new CommunityInteraction();
                        break;
                }                
                sa.StudentAbilityId = (int)dr["StudentAbilityId"];
                sa.StudentId = (int)dr["StudentId"];
                sa.Item = dr["Item"].ToString();
                sa.Description=dr["Description"].ToString();
                sa.Comments = dr["Comments"].ToString();
                sa.StudentAbilityType = dr["StudentAbilityType"].ToString();

                list.Add(sa);
            }
            return list;
        }

        public void Update(StudentAbilityBase sa)
        {
            CommonFunctions.UpdateApostrophe(sa);
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE StudentAbility SET ");
            sb.Append("Item='"+ sa.Item + "'");
            sb.Append(",Description='" + sa.Description+ "'");
            if (sa.Comments != null && sa.Comments != string.Empty)
                sb.Append(",Comments='" + sa.Comments + "'"); 
            else
                sb.Append(",Comments=null");
            sb.Append(" WHERE StudentAbilityId =" + sa.StudentAbilityId);
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }

        public void Add(StudentAbilityBase sa, int StudentId)
        {
            CommonFunctions.UpdateApostrophe(sa);
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO StudentAbility (StudentId,Item,Description,Comments, StudentAbilityTypeId) VALUES (");
            sb.Append(StudentId);            
            sb.Append(",'" + sa.Item + "'");
            sb.Append(",'" + sa.Description + "'");
            if(sa.Comments !=null && sa.Comments!=string.Empty)
                sb.Append(",'" + sa.Comments + "'");
            else
                sb.Append(",null");
            sb.Append("," + sa.StudentAbilityTypeId);
            sb.Append(")");
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }

        public void Remove(int id)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM StudentAbility WHERE StudentAbilityId=" + id);      
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }

        public List<StudentAbilityBase> GetDefaults()
        {
            List<StudentAbilityBase> list = new List<StudentAbilityBase>();
            DataTable dt = dbc.GetDataTable("SELECT * FROM A_DefaultItems");

            foreach (DataRow dr in dt.Rows)
            {
                int defaultTypeId = (int)dr["DefaultType"];
                StudentAbilityBase sa;
                switch (defaultTypeId)
                {
                    case 1:
                        sa = new PhysicalAbility();
                        break;
                    case 2:
                        sa = new CommunityOrientation();
                        break;
                    case 3:
                        sa = new CommunityInteraction();
                        break;
                    default:
                        sa = new PersonalCare();
                        break;
                }
                sa.StudentAbilityTypeId = (int)dr["DefaultType"];                
                sa.Item = dr["Item"].ToString();
                sa.Selected = true;
                list.Add(sa);
            }
            return list;
        }


        }
}