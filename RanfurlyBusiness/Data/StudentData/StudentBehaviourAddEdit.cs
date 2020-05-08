using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace RanfurlyBusiness
{
    public class StudentBehaviourAddEdit : StudentDataAddEditBase
    {
        public StudentBehaviourAddEdit(Student student, DBCommand dbc):base(student,dbc)
        {
            StudentBehaviourData studentBehaviourData = new StudentBehaviourData(dbc);
            foreach (StudentBehaviour rmp in student.Behaviours)
            {
                if (rmp.StudentBehaviourId == 0)
                {
                    studentBehaviourData.Add(rmp, student.PersonId);
                }
                else
                {
                    studentBehaviourData.Update(rmp);
                }
            }

            foreach (object obj in student.RemovedObjects)
            {
                if (obj is StudentBehaviour)
                {
                    studentBehaviourData.Remove(((StudentBehaviour)obj).StudentBehaviourId);
                }
            }
        }
    }
}
