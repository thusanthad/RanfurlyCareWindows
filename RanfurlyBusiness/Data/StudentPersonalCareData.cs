using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;

namespace RanfurlyBusiness
{
    public class StudentPersonalCareData
    {
        protected DBCommand dbc;

        public StudentPersonalCareData(DBCommand dbCommand)
        {
            dbc = dbCommand;
        }

        public StudentPersonalCareData()
        {
            dbc = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
        }

        public List<StudentPersonalCare> GetList(int PersonId)
        {
            List<StudentPersonalCare> personalCate = new List<StudentPersonalCare>();
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_StudentPersonalCare WHERE StudentId=" + PersonId);
            dbc.CloseConnection();

            foreach (DataRow dr in dt.Rows)
            {
                StudentPersonalCare pc = new StudentPersonalCare();
                pc.StudentPersonalCareId = (int)dr["StudentPersonalCareId"];
                pc.StudentId = (int)dr["StudentId"];
                pc.Item = dr["Item"].ToString();
                pc.Assistance=dr["Assistance"].ToString();
                pc.Comments = dr["Comments"].ToString();
                pc.Frequency = dr["Frequency"].ToString();
                personalCate.Add(pc);
            }
            return personalCate;
        }

        public void Update(StudentPersonalCare pc)
        {
            CommonFunctions.UpdateApostrophe(pc);
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE StudentPersonalCare SET ");
            sb.Append("Item='"+ pc.Item + "'");
            sb.Append(",Assistance='" + pc.Assistance + "'");
            if (pc.Comments != null && pc.Comments != string.Empty)
                sb.Append(",Comments='" + pc.Comments + "'");
            else
                sb.Append(",Comments=null");
            sb.Append(",Frequency='" + pc.Frequency + "'");
            sb.Append(" WHERE StudentPersonalCareId =" + pc.StudentPersonalCareId);
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }

        public void Add(StudentPersonalCare pc, int StudentId)
        {
            CommonFunctions.UpdateApostrophe(pc);
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO StudentPersonalCare (StudentId,Frequency,Item,Assistance,Comments) VALUES (");
            sb.Append(StudentId);
            sb.Append(",'" + pc.Frequency + "'");
            sb.Append(",'" + pc.Item + "'");
            sb.Append(",'" + pc.Assistance + "'");
            if(pc.Comments !=null && pc.Comments!=string.Empty)
                sb.Append(",'" + pc.Comments + "'");
            else
                sb.Append(",null");
            sb.Append(")");
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }

        public void Remove(int StudentPersonalCareId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM StudentPersonalCare WHERE StudentPersonalCareId=" + StudentPersonalCareId);      
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }
    }
}