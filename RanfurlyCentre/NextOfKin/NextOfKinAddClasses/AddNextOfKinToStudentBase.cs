using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public abstract class AddNextOfKinToStudentBase
    {
        public Student Student { get; set; }
        public abstract void AddNextOfKin(NextOfKin nextofKin);
        public abstract void AllocateNextOfKin(NextOfKin nextofKin);

        public AddNextOfKinToStudentBase(Student student)
        {
            Student = student;
        }
    }
}
