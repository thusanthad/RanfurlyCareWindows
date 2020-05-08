using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Reporting.WinForms;

namespace RanfurlyCentre
{
    public class RDLCReportBase
    {
        protected string ReportName { get; set; }
        protected List<ReportDataSource> ReportDataSources { get; set; }

        public RDLCReportBase()
        {

        }

        protected virtual void Add(ReportDataSource rds)
        {
            ReportDataSources.Add(rds);
        }

    }
}
