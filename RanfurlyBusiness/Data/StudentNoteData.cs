using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;

namespace RanfurlyBusiness
{
    public class StudentNoteData
    {
        protected DBCommand dbc;

        public StudentNoteData(DBCommand dbCommand)
        {
            dbc = dbCommand;
        }

        public StudentNoteData()
        {
            dbc = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
        }

        public List<StudentNote> GetList(int PersonId)
        {
            List<StudentNote> studentNotes = new List<StudentNote>();
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_StudentNotes WHERE StudentId=" + PersonId);
            dbc.CloseConnection();

            foreach (DataRow dr in dt.Rows)
            {
                StudentNote sn = new StudentNote();
                sn.StudentNoteId = (int)dr["StudentNoteId"];
                sn.StudentId = (int)dr["StudentId"];
                sn.StudentNoteName = dr["StudentNote"].ToString();
                sn.NoteDate=(DateTime) dr["NoteDate"];
                studentNotes.Add(sn);
            }
            return studentNotes;
        }

        public void Update(StudentNote sn)
        {
            CommonFunctions.UpdateApostrophe(sn);
            StringBuilder sb = new StringBuilder();
            sb.Append("UPDATE StudentNote SET ");
            sb.Append("StudentNote='"+ sn.StudentNoteName + "'");
            sb.Append(",NoteDate='" + sn.NoteDate.ToString("dd/MM/yyyy") + "' ");
            sb.Append("WHERE StudentNoteId =" + sn.StudentNoteId);
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }

        public void Add(StudentNote sn, int StudentId)
        {
            CommonFunctions.UpdateApostrophe(sn);
            StringBuilder sb = new StringBuilder();
            sb.Append("INSERT INTO StudentNote (StudentNote,StudentId,NoteDate) VALUES (");
            sb.Append("'" + sn.StudentNoteName + "'");
            sb.Append("," + StudentId + "");
            sb.Append(",'" + sn.NoteDate.ToString("dd/MM/yyyy") + "'");
            sb.Append(")");
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }

        public void Remove(int studentNoteId)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM StudentNote WHERE StudentNoteId=" + studentNoteId);      
            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);
        }
    }
}