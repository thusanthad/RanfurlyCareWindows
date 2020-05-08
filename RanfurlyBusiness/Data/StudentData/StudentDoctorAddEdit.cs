using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace RanfurlyBusiness
{
    public class StudentDoctorAddEdit : StudentDataAddEditBase
    {
        //protected DoctorData doctorData;
        public StudentDoctorAddEdit(Student student, DBCommand dbc):base(student,dbc)
        {
            _database = new DoctorData(_dbc);            
            foreach (Doctor doctor in student.Doctors)
            {
                bool personExists = _database.PersonExists(doctor.PersonId, student.PersonId);
                if (!personExists)
                {
                    _database.Allocate(doctor, student.PersonId);
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
