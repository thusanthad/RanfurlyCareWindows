using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public abstract class EmergencyContactAddBase
    {
        protected Student _student;

        public EmergencyContactAddBase(Student student)
        {
            _student = student;
        }

        public abstract void Add(EmergencyContact emergencyContact);
       
    }
}
