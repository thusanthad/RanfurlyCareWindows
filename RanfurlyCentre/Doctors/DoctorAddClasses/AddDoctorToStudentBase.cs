using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public abstract class AddDoctorToStudentBase
    {
        public Student Student { get; set; }
        public abstract void AddDoctor(Doctor doctor);
        public abstract void AllocateDoctor(Doctor doctor);

        public AddDoctorToStudentBase(Student student)
        {
           Student = student;
        }
    }
}
