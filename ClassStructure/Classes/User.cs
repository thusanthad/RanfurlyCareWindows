using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassStructure
{
    public class SystemUser:Person
    {
        public int UserId { get; set; }
        public int PersonId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string[] Role { get; set; }
    }
}
