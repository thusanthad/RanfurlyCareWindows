using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyBusiness
{
    public class EmergencyContact:Person
    {
        public int StudentEmergencyContactId { get; set; }
        public int StudentId { get; set; }       
        public string Relationship { get; set; }
        
        
    }
}
