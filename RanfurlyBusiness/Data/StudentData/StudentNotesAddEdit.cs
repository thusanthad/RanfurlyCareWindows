using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace RanfurlyBusiness
{
    public class StudentNotesAddEdit : StudentDataAddEditBase
    {
        public StudentNotesAddEdit(Student student, DBCommand dbc):base(student,dbc)
        {
            StudentNoteData studentNoteData = new StudentNoteData(dbc);
            foreach (StudentNote sn in student.StudentNotes)
            {
                if (sn.StudentNoteId == 0)
                {
                    studentNoteData.Add(sn, student.PersonId);
                }
                else
                {
                    studentNoteData.Update(sn);
                }
            }

            foreach (object obj in student.RemovedObjects)
            {
                if (obj is StudentNote)
                {
                    studentNoteData.Remove(((StudentNote)obj).StudentNoteId);
                }
            }
        }
    }
}
