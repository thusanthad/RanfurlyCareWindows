using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace RanfurlyBusiness
{
    public class ResidentRollCall
    {
        public int ResidentRollCallId { get; set; }
        public int StudentId { get; set; }
        public int MonthNumber { get; set; }
        public string MonthName { get; set; }
        public int YearNumber { get; set; }
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string Abbreviation { get; set; }
        public DataTable RollTable { get; set; }
        public string FileLocation { get; set; }
        public string FileName { get; set; }
        public string RollReference { get; set; }       
        public string ResidentName { get; set; }
        public string LocationReference { get; set; }
        public string d1 { get; set; }
        public string d2 { get; set; }
        public string d3 { get; set; }
        public string d4 { get; set; }
        public string d5 { get; set; }
        public string d6 { get; set; }
        public string d7 { get; set; }
        public string d8 { get; set; }
        public string d9 { get; set; }
        public string d10 { get; set; }
        public string d11 { get; set; }
        public string d12 { get; set; }
        public string d13 { get; set; }
        public string d14 { get; set; }
        public string d15 { get; set; }
        public string d16 { get; set; }
        public string d17 { get; set; }
        public string d18 { get; set; }
        public string d19 { get; set; }
        public string d20 { get; set; }
        public string d21 { get; set; }
        public string d22 { get; set; }
        public string d23 { get; set; }
        public string d24 { get; set; }
        public string d25 { get; set; }
        public string d26 { get; set; }
        public string d27 { get; set; }
        public string d28 { get; set; }
        public string d29 { get; set; }
        public string d30 { get; set; }
        public string d31 { get; set; }

        public string GetMonthName()
        {
            return CommonFunctions.GetMonthName(MonthNumber);
        }

        public void Update()
        {
            ResidentRollCallData rcd = new ResidentRollCallData();
            rcd.Update(this);            
        }
    }


}
