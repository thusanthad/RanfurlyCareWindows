using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyBusiness
{
    public class StudentPersonalCare
    {
        public int StudentPersonalCareId { get; set; }
        public int StudentId { get; set; }
        public string Item { get; set; }
        public string Assistance { get; set; }
        public string Comments { get; set; }
        public string Frequency { get; set; }

        public StudentPersonalCare()
        {
            //StudentPersonalCareId = 0;
        }
    }
}
