using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class ResidentRollCallMonthlySummaryFile : FileExportBase
    {        
        
        public ResidentRollCallMonthlySummaryFile(Jarvis jarvis):base(jarvis)
        {
            Jarvis.ExportOjectType = new ResidentMonthlyCallSummary();
            Jarvis.ExportFielFieldList = Jarvis.ResourceFileLocation + Jarvis.GetResidetnRollCallMonthlySummaryFieldList();
            Jarvis.OutputFileName = "RollCallMonthlySummary";
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
