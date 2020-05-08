using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyBusiness
{
    public class Location
    {
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public string Abbreviation { get; set; }
        public string LocationNameWithoutAbbreviation { get; set; }
        public string FullAddress { get; set; }
        public string RollReference { get; set; }
        public string Telephone { get; set; }
        public bool IsResidence { get; set; }
        public bool IsRollCall { get; set; }
        public bool IsStudentCentre { get; set; }
    }
}
