using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyBusiness
{
    public abstract class StudentMedicalConditionAlertBase
    {
        public int StudentMedicalConditionAlertId { get; set; }
        public int StudentId { get; set; }
        public string Definition { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public int MedicalTypeAlertTypeId { get; set; }        
    }
}
