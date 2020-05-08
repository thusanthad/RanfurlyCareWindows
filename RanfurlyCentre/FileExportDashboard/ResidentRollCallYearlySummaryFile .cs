using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class ResidentRollCallYearlySummaryFile : FileExportBase
    {        
        
        public ResidentRollCallYearlySummaryFile(Jarvis jarvis):base(jarvis)
        {
            Jarvis.ExportOjectType = new ResidentYearlyCallSummaryByResident();
            Jarvis.ExportFielFieldList = Jarvis.ResourceFileLocation + Jarvis.GetResidetnRollCallYearlySummaryFieldList();
            Jarvis.OutputFileName = "Roll CallYearly Summary By Resident";
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
