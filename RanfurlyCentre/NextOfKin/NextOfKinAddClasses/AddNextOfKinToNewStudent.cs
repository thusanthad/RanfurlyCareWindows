using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class AddNextOfKinToNewStudent : AddNextOfKinToStudentBase
    {    
        public AddNextOfKinToNewStudent(Student student) :base(student)
        {
           
        }

        public override void AddNextOfKin(NextOfKin nextOfKin)
        {
            throw new NotImplementedException("not implemented");
            //DataBase db = new NextOfKinData();
            //int nextofKinId = db.Add(nextOfKin, Student.PersonId);
            //nextOfKin.PersonId = nextofKinId;
        }

        public override void AllocateNextOfKin(NextOfKin nextOfKin)
        {
            throw new NotImplementedException("not implemented");
            // DataBase db = new NextOfKinData();
            //db.Allocate(nextOfKin, Student.PersonId);
        }
    }
}
