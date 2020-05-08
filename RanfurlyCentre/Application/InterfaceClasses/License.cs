using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyCentre
{
    public class License
    {
        public string LicensedTo { get; set; }
        public DateTime ExpiryDate { get; set; }        

        public int GetDaysToExpire()
        {
            return ExpiryDate.Subtract(DateTime.Today).Days;
        }
    }
}
