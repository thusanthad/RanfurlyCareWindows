using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class AddNextOfKinToExistingStudent : AddNextOfKinToStudentBase
    {    
        public AddNextOfKinToExistingStudent(Student student) :base(student)
        {
           
        }

        public override void AddNextOfKin(NextOfKin nextOfKin)
        {
            DataBase db = new NextOfKinData();
            int nextofKinId = db.Add(nextOfKin, Student.PersonId);
            nextOfKin.PersonId = nextofKinId;
        }

        public override void AllocateNextOfKin(NextOfKin nextOfKin)
        {
            DataBase db = new NextOfKinData();
           db.Allocate(nextOfKin, Student.PersonId);
        }
    }
}
