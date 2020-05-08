using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class EmergencyContactAddToNewStudent : EmergencyContactAddBase
    {
        public EmergencyContactAddToNewStudent(Student student) : base(student)
        {

        }

        public override void Add(EmergencyContact emergencyContact)
        {
            emergencyContact.FullAddress = emergencyContact.GetFullAddress();
            _student.EmergencyContacts.Add(emergencyContact);
        }
    }
}
