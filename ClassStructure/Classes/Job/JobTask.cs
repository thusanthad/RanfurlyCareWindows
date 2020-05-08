using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassStructure
{
    public class JobTask
    {
        public DateTime TaskDate { get; set; }
        public string Comments { get; set; }
        public  Decimal HoursSpent { get; set; }
        public int JobId { get; set; }
        public int TaskId { get; set; }
        public int JobTaskId { get; set; }
    }
}
