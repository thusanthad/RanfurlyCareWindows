using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMFileManager
{
    public class DMEProgressReporter
    {
        public event EventHandler<DMEventMessenger> ReportProgress;

        public void OnReportProgress(DMEventMessenger e)
        {
            EventHandler<DMEventMessenger> handler = ReportProgress;
            if (handler != null)
            {
                handler(this, e);
            }

        }
    }

    
}
