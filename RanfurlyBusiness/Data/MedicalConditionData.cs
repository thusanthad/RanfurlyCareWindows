using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;

namespace RanfurlyBusiness
{
    public class MedicalConditionData
    {
        protected DBCommand dbc;

        public MedicalConditionData(DBCommand dbCommand)
        {
            dbc = dbCommand;
        }

        public MedicalConditionData()
        {
            dbc = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
        }

        public List<MedicalCondition> GetList(int PersonId)
        {
            List<MedicalCondition> mecicalConditions = new List<MedicalCondition>();
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_StudentMedicalConditions WHERE StudentId=" + PersonId);
            dbc.CloseConnection();

            foreach (DataRow dr in dt.Rows)
            {
                MedicalCondition mc = new MedicalCondition();
                mc.StudentMedicalConditionId = (int)dr["StudentMedicalConditionId"];
                mc.StudentId = (int)dr["StudentId"];
                mc.MedicalConditionName = dr["MedicalCondition"].ToString();
                if (dr["Description"].ToString() != string.Empty)
                    mc.Description = dr["Description"].ToString();
                else
                    mc.Description = "** please update **";
                if (dr["DegreeOfDisability"].ToString() != string.Empty)
                    mc.DegreeOfDisability = dr["DegreeOfDisability"].ToString();
                else
                    mc.DegreeOfDisability = "** please update **";

                mc.Comments = dr["Comments"].ToString();
                mecicalConditions.Add(mc);
            }
            return mecicalConditions;
        }

        public void Update(MedicalCondition mc)
        {
            CommonFunctions.UpdateApostrophe(mc);
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE STUDENTMEDICALCONDITION SET ");
            sb.Append("MedicalCondition='"+ mc.MedicalConditionName.Trim() + "' ");
            sb.Append(",DegreeOfDisability='" + mc.DegreeOfDisability.Trim() + "' ");
            sb.Append(",Description='" + mc.Description.Trim() + "' ");
            if (mc.Comments != null && mc.Comments != string.Empty)
                sb.Append(",Comments='" + mc.Comments.Trim() + "' ");
            else
                sb.Append(",Comments=null ");            
            sb.Append("WHERE StudentMedicalConditionId =" + mc.StudentMedicalConditionId);
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }

        public void Add(MedicalCondition mc, int StudentId)
        {
            CommonFunctions.UpdateApostrophe(mc);
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO STUDENTMEDICALCONDITION (MedicalCondition,DegreeOfDisability,Description,Comments,StudentId) VALUES (");
            sb.Append("'" + mc.MedicalConditionName.Trim() + "'");
            sb.Append(",'" + mc.DegreeOfDisability.Trim() + "'");
            sb.Append(",'" + mc.Description.Trim() + "'");
            if(mc.Comments !=null && mc.Comments !=string.Empty)
                sb.Append(",'" + mc.Comments + "'");
            else
                sb.Append(",null");
            sb.Append("," + StudentId + ")");
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }

        public void Remove(int medicalConditionId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM STUDENTMEDICALCONDITION WHERE StudentMedicalConditionId=" + medicalConditionId); 
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }
    }
}