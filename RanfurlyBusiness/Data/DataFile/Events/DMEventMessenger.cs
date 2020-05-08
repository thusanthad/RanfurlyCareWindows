using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMFileManager
{
    public class DMEventMessenger:EventArgs
    {
        public double ProgressPercent { get; set; }
        public string Message1 { get; set; }
        public string FileName { get; set; }
        //public MatchedFields MatchedFields { get; set; }
        public bool Cancel { get; set; }
    }
}
