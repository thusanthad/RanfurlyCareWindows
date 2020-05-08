using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyBusiness
{
    public class MedicalCondition
    {
        public int StudentMedicalConditionId { get; set; }
        public int StudentId { get; set; }
        public string MedicalConditionName { get; set; }
        public string DegreeOfDisability { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
    }
}
