using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace RanfurlyBusiness
{
    public class StudentMedicalCondtionAlertAddEdit : StudentDataAddEditBase
    {
        public StudentMedicalCondtionAlertAddEdit(Student student, DBCommand dbc):base(student,dbc)
        {
            StudentMedicalConditionAlertData studentMedicalConditionAlertData = new StudentMedicalConditionAlertData(dbc);
            foreach (StudentMedicalConditionAlertBase rmp in student.MedicalConditionAlerts)
            {
                if (rmp.StudentMedicalConditionAlertId == 0)
                {
                    studentMedicalConditionAlertData.Add(rmp, student.PersonId);
                }
                else
                {
                    studentMedicalConditionAlertData.Update(rmp);
                }
            }

            foreach (object obj in student.RemovedObjects)
            {
                if (obj is Asthma || obj is Allergy || obj is Epilepsy)
                {
                    studentMedicalConditionAlertData.Remove(((StudentMedicalConditionAlertBase)obj).StudentMedicalConditionAlertId);
                }
            }
        }
    }
}
