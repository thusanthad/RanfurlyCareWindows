using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class IncidentFile:FileExportBase
    {        
        
        public IncidentFile(Jarvis jarvis):base(jarvis)
        {
            Jarvis.ExportOjectType = new Incident();
            Jarvis.ExportFielFieldList = Jarvis.ResourceFileLocation + Jarvis.GetIncidentFieldList();
            Jarvis.OutputFileName = "IncidentsList";
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
