using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyBusiness
{ 
    public class Staff:Person
    {
        public int TitleId { get; set; }
        public int PersonTypeId { get; set; }
        public List<Location> Locations { get; set; }
        public string Title { get; set; }

        public Staff()
        {
            PersonTypeId = 2;
            Locations = new List<Location>();
        }
    }
}
