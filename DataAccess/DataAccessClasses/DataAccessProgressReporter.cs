using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess
{
    public class DataAccessProgressReporter
    {
        public event EventHandler<DataAccessEventMessenger> ReportProgress;
        //public DMEventMessenger Em = new DMEventMessenger();


        public void OnReportProgress(DataAccessEventMessenger e)
        {
            EventHandler<DataAccessEventMessenger> handler = ReportProgress;
            if (handler != null)
            {
                handler(this, e);
            }

        }
    }

    
}
