using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class ReportContainer
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public List<ResidentCallSummaryBase> RollCallSummaryList { get; set; }
    }
}
