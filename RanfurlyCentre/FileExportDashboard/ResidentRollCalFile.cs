using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class ResidentRollCalFile : FileExportBase
    {        
        
        public ResidentRollCalFile(Jarvis jarvis):base(jarvis)
        {
            Jarvis.ExportOjectType = new ResidentRollCall();
            Jarvis.ExportFielFieldList = Jarvis.ResourceFileLocation + Jarvis.GetResidentRollCallFieldList();
            Jarvis.OutputFileName = "ResidentRollCallList";
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
