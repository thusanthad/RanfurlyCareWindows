using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class EmergencyContactAddToExistingStudent:EmergencyContactAddBase
    {
        public EmergencyContactAddToExistingStudent(Student student) : base(student)
        {

        }

        public override void Add(EmergencyContact emergencyContact)
        {
            DataBase db = new EmergencyContactData();
            emergencyContact.StudentEmergencyContactId = db.Add(emergencyContact, _student.PersonId);
        }
    }
}
