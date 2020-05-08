using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyBusiness
{
    public class ResidentMonthlyCallSummary:ResidentCallSummaryBase
    {
        public int StudentId { get; set; }
        public string ResidentName { get; set; }
        //public string LocationName { get; set; }
        public int MonthNumber { get; set; }
        //public int YearNumber { get; set; }
        //public int CPA { get; set; }
        //public int DH { get; set; }
        //public int M { get; set; }
        //public int RH { get; set; }
        //public int H { get; set; }
        //public int AL { get; set; }
        //public int W { get; set; }
        //public int ST { get; set; }
        public override void CalculateTotal()
        {
            base.CalculateTotal();
        }
        
    }
}
