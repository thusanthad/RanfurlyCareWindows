using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace RanfurlyBusiness
{
    public class StudentSpecialistAddEdit : StudentDataAddEditBase
    {
        //protected DoctorData doctorData;
        public StudentSpecialistAddEdit(Student student, DBCommand dbc):base(student,dbc)
        {
            _database = new SpecialistData(_dbc);            
            foreach (Specialist specialist in student.ProfessionalServiceProviders)
            {
                bool personExists = _database.PersonExists(specialist.PersonId, student.PersonId);
                if (!personExists)
                {
                    _database.Allocate(specialist, student.PersonId);
                }
            }

            foreach (object obj in student.RemovedObjects)
            {
                if (obj is Doctor)
                {
                    _database.Remove((Doctor)obj, student.PersonId);
                }
            }
        }
    }
}
