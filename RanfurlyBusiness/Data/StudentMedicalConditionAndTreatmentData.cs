using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;

namespace RanfurlyBusiness
{
    public class StudentMedicalConditionAndTreatmentData
    {
        protected DBCommand dbc;

        public StudentMedicalConditionAndTreatmentData(DBCommand dbCommand)
        {
            dbc = dbCommand;
        }

        public StudentMedicalConditionAndTreatmentData()
        {
            dbc = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
        }

        public List<MedicationAndTreatment> GetList(int PersonId)
        {
            List<MedicationAndTreatment> medicationAndTreatment = new List<MedicationAndTreatment>();
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_StudentMedicationAndTreatment WHERE StudentId=" + PersonId);
            dbc.CloseConnection();

            foreach (DataRow dr in dt.Rows)
            {
                MedicationAndTreatment at = new MedicationAndTreatment();
                at.StudentMedicationAndTreatmentId = (int)dr["StudentMedicationAndTreatmentId"];
                at.StudentId = (int)dr["StudentId"];
                at.Frequency = dr["Frequency"].ToString();
                at.Medication = dr["Medication"].ToString();
                if (dr["Description"].ToString() != string.Empty)
                    at.Description = dr["Description"].ToString();
                else
                    at.Description = "** please update **";
                at.Comments = dr["Comments"].ToString();
                medicationAndTreatment.Add(at);
            }
            return medicationAndTreatment;
        }

        public void Update(MedicationAndTreatment mt)
        {
            CommonFunctions.UpdateApostrophe(mt);
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE StudentMedicationAndTreatment SET ");
            sb.Append("Frequency='" + mt.Frequency.Trim() + "' ");
            sb.Append(",Medication='"+ mt.Medication.Trim() + "' ");
            sb.Append(",Description='" + mt.Description.Trim() + "' ");
            if (mt.Comments != null && mt.Comments != string.Empty)
                sb.Append(",Comments='" + mt.Comments.Trim() + "' ");
            else
                sb.Append(",Comments=null ");            
            sb.Append("WHERE StudentMedicationAndTreatmentId =" + mt.StudentMedicationAndTreatmentId);
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }

        public void Add(MedicationAndTreatment mt, int StudentId)
        {
            CommonFunctions.UpdateApostrophe(mt);
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO StudentMedicationAndTreatment (Frequency,Medication,Description,Comments,StudentId) VALUES (");
            sb.Append("'" + mt.Frequency.Trim() + "'");
            sb.Append(",'" + mt.Medication.Trim() + "'");
            sb.Append(",'" + mt.Description.Trim() + "'");            
            if (mt.Comments !=null && mt.Comments !=string.Empty)
                sb.Append(",'" + mt.Comments + "'");
            else
                sb.Append(",null");
            sb.Append("," + StudentId + ")");
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }

        public void Remove(int sudentMedicationAndTreatmentId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM StudentMedicationAndTreatment WHERE StudentMedicationAndTreatmentId=" + sudentMedicationAndTreatmentId); 
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }
    }
}