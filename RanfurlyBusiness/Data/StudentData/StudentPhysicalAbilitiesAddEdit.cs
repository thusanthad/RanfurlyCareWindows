using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace RanfurlyBusiness
{
    public class StudentPhysicalAbilitiesAddEdit : StudentDataAddEditBase
    {
        public StudentPhysicalAbilitiesAddEdit(Student student, DBCommand dbc):base(student,dbc)
        {
            StudentAbilityData data = new StudentAbilityData(dbc);
            foreach (StudentAbilityBase mt in student.StudentAbilities)
            {
                if (mt.StudentAbilityId == 0)
                {
                    data.Add(mt, student.PersonId);
                }
                else
                {
                    data.Update(mt);
                }
            }

            foreach (object obj in student.RemovedObjects)
            {
                if (obj is StudentAbilityBase)
                {
                    data.Remove(((StudentAbilityBase)obj).StudentAbilityId);
                }
            }
        }
    }
}
