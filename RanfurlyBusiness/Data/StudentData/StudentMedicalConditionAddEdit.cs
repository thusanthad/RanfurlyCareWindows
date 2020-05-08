using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace RanfurlyBusiness
{
    public class StudentMedicalConditionAddEdit : StudentDataAddEditBase
    {
        public StudentMedicalConditionAddEdit(Student student, DBCommand dbc):base(student,dbc)
        {
            MedicalConditionData medicalConditionData = new MedicalConditionData(dbc);
            foreach (MedicalCondition mc in student.MedicalConditions)
            {
                if (mc.StudentMedicalConditionId == 0)
                {
                    medicalConditionData.Add(mc, student.PersonId);
                }
                else
                {
                    medicalConditionData.Update(mc);
                }
            }

            foreach (object obj in student.RemovedObjects)
            {
                if (obj is MedicalCondition)
                {
                    medicalConditionData.Remove(((MedicalCondition)obj).StudentMedicalConditionId);
                }
            }
        }
    }
}
