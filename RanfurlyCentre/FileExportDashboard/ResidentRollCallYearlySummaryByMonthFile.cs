using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class ResidentRollCallYearlySummaryByMonthFile : FileExportBase
    {        
        
        public ResidentRollCallYearlySummaryByMonthFile(Jarvis jarvis):base(jarvis)
        {
            Jarvis.ExportOjectType = new ResidentYearlyCallSummaryByMonth();
            Jarvis.ExportFielFieldList = Jarvis.ResourceFileLocation + Jarvis.GetResidetnRollCallYearlySummaryByMonthFieldList();
            Jarvis.OutputFileName = "Roll Call Yearly Summary By Month";
        }

        protected override void PopulateFields()
        {

        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

    }
}
