using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyBusiness
{
    public class StudentBehaviour
    {
        public int StudentBehaviourId { get; set; }
        public int StudentId { get; set; }
        public string Profile { get; set; }
        public string Communication { get; set; }
        public string Behaviour { get; set; }
        public string StrategyPlan { get; set; }

        public StudentBehaviour()
        {
            //StudentPersonalCareId = 0;
        }
    }
}
