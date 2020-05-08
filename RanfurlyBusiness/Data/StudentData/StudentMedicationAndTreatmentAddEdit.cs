using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace RanfurlyBusiness
{
    public class StudentMedicationAndTreatmentAddEdit : StudentDataAddEditBase
    {
        public StudentMedicationAndTreatmentAddEdit(Student student, DBCommand dbc):base(student,dbc)
        {
            StudentMedicalConditionAndTreatmentData smtd = new StudentMedicalConditionAndTreatmentData(dbc);
            foreach (MedicationAndTreatment mt in student.MedicationAndTreatments)
            {
                if (mt.StudentMedicationAndTreatmentId == 0)
                {
                    smtd.Add(mt, student.PersonId);
                }
                else
                {
                    smtd.Update(mt);
                }
            }

            foreach (object obj in student.RemovedObjects)
            {
                if (obj is MedicationAndTreatment)
                {
                    smtd.Remove(((MedicationAndTreatment)obj).StudentMedicationAndTreatmentId);
                }
            }
        }
    }
}
