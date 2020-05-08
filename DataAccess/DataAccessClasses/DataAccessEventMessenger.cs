using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class DataAccessEventMessenger : EventArgs
    {        
        public double ProgressPercent { get; set; }
        public string Message1 { get; set; }
        public string FileName { get; set; }
        public bool Cancel { get; set; }
    }
}
