using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class AddDoctorToNewStudent:AddDoctorToStudentBase
    {    
        public AddDoctorToNewStudent(Student student):base(student)
        {
           
        }

        public override void AddDoctor(Doctor doctor)
        {
            throw new NotImplementedException("not implemented");
            //DataBase db = new DoctorData();
            //int doctorId = db.Add(doctor, Student.PersonId);
            //doctor.PersonId = doctorId;
        }

        public override void AllocateDoctor(Doctor doctor)
        {
            throw new NotImplementedException("not implemented");
            //DataBase db = new DoctorData();
            //db.Allocate(doctor, Student.PersonId);
        }
    }
}
