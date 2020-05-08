using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyBusiness
{
    public class MedicalCondition
    {
        public int MedicalConditionId { get; set; }
        public int StudentId { get; set; }
        public string Condition { get; set; }
    }
}
