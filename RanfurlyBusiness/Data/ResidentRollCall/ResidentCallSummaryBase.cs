using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyBusiness
{
    public class ResidentCallSummaryBase
    {
        public string RollReference { get; set; }       
        // public int StudentId { get; set; }
        // public string ResidentName { get; set; }
        public string LocationName { get; set; }
        //public string RollReference { get; set; }
        //public int MonthNumber { get; set; }
        public int YearNumber { get; set; }
        public int RH { get; set; }
        public int M { get; set; }
        public int CPA { get; set; }
        public int DH { get; set; }
        public int H { get; set; }
        public int AL { get; set; }
        public int W { get; set; }
        public int ST { get; set; }
        public int Total { get; set; }

        public virtual void CalculateTotal()
        {
            Total = RH + M + CPA + DH + H + AL + W + ST;
        }
    }
}
