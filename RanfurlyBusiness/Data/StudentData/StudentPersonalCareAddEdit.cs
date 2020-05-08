using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace RanfurlyBusiness
{
    public class StudentPersonalCareAddEdit : StudentDataAddEditBase
    {
        public StudentPersonalCareAddEdit(Student student, DBCommand dbc):base(student,dbc)
        {
            StudentPersonalCareData personaCareData = new StudentPersonalCareData(dbc);
            foreach (StudentPersonalCare spc in student.PersonalCare)
            {
                if (spc.StudentPersonalCareId == 0)
                {
                    personaCareData.Add(spc, student.PersonId);
                }
                else
                {
                    personaCareData.Update(spc);
                }
            }

            foreach (object obj in student.RemovedObjects)
            {
                if (obj is StudentPersonalCare)
                {
                    personaCareData.Remove(((StudentPersonalCare)obj).StudentPersonalCareId);
                }
            }
        }
    }
}
