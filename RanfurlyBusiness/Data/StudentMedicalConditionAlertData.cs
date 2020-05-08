using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;

namespace RanfurlyBusiness
{
    public class StudentMedicalConditionAlertData
    {
        protected DBCommand dbc;

        public StudentMedicalConditionAlertData(DBCommand dbCommand)
        {
            dbc = dbCommand;
        }

        public StudentMedicalConditionAlertData()
        {
            dbc = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
        }

        public List<StudentMedicalConditionAlertBase> GetList(int PersonId)
        {
            List<StudentMedicalConditionAlertBase> mecicalConditionsAlerts = new List<StudentMedicalConditionAlertBase>();
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_StudentMedicalConditionAlerts WHERE StudentId=" + PersonId);
            dbc.CloseConnection();

            foreach (DataRow dr in dt.Rows)
            {
                StudentMedicalConditionAlertBase smca;
                int medicationAlertTypeId = (int)dr["MedicalTypeAlertTypeId"];
                switch (medicationAlertTypeId)
                {
                    case 1:
                        smca = new Asthma();
                        break;
                    case 2:
                        smca = new Allergy();
                        break;
                    default:
                        smca = new Epilepsy();
                        break;
                }
                smca.StudentMedicalConditionAlertId = (int)dr["StudentMedicalConditionAlertId"];
                smca.MedicalTypeAlertTypeId = medicationAlertTypeId;
                smca.Definition = dr["Definition"].ToString();                

                if (dr["Description"].ToString() != string.Empty)
                    smca.Description = dr["Description"].ToString();
                else
                    smca.Description = "** please update **";


                smca.Comments = dr["Comments"].ToString();
                mecicalConditionsAlerts.Add(smca);
            }
            return mecicalConditionsAlerts;
        }

        public void Update(StudentMedicalConditionAlertBase smca)
        {
            CommonFunctions.UpdateApostrophe(smca);
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE StudentMedicalConditionAlert SET ");
            sb.Append("Definition='"+ smca.Definition.Trim() + "' ");            
            sb.Append(",Description='" + smca.Description.Trim() + "' ");
            if (smca.Comments != null && smca.Comments != string.Empty)
                sb.Append(",Comments='" + smca.Comments.Trim() + "' ");
            else
                sb.Append(",Comments=null ");
            sb.Append(",MedicalTypeAlertTypeId=" + smca.MedicalTypeAlertTypeId);
            sb.Append(" WHERE StudentMedicalConditionAlertId =" + smca.StudentMedicalConditionAlertId);
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }

        public void Add(StudentMedicalConditionAlertBase smca, int StudentId)
        {
            CommonFunctions.UpdateApostrophe(smca);
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO StudentMedicalConditionAlert (Definition,Description,Comments,StudentId,MedicalTypeAlertTypeId) VALUES (");
            sb.Append("'" + smca.Definition.Trim() + "'");            
            sb.Append(",'" + smca.Description.Trim() + "'");
            if(smca.Comments !=null && smca.Comments !=string.Empty)
                sb.Append(",'" + smca.Comments + "'");
            else
                sb.Append(",null");
            sb.Append("," + StudentId);
            sb.Append("," + smca.MedicalTypeAlertTypeId + ")");
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }

        public void Remove(int studentMedicalConditionAlertId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM StudentMedicalConditionAlert WHERE StudentMedicalConditionAlertId=" + studentMedicalConditionAlertId); 
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }
    }
}