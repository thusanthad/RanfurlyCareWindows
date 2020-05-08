using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public abstract class StudentAddEditBaseClass
    {
        public abstract void Add(object relatedPerson);
        public abstract void Remove(object relatedPerson);
        public abstract void Save();
        public Student Student { get; set; }

        public StudentAddEditBaseClass(Student student)
        {
            Student = student;
        }
    }
}
