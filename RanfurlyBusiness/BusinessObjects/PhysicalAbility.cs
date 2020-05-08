using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyBusiness
{
    public class PhysicalAbility
    {
        public int StudentPhysicalAbilityId { get; set; }
        public int StudentId { get; set; }
        public string Item { get; set; }
        public string Description { get; set; }
        public string Comments { get; set; }        

        public PhysicalAbility()
        {
            //StudentPersonalCareId = 0;
        }
    }
}
