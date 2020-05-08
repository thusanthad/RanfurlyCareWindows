using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyBusiness
{
    public class StudentAbilityBase
    {
        public int StudentAbilityId { get; set; }
        public int StudentId { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }
        public int StudentAbilityTypeId { get; set; }
        public string StudentAbilityType { get; set; }
        public bool Selected { get; set; }

        public StudentAbilityBase()
        {
            //StudentPersonalCareId = 0;
        }
    }
}
