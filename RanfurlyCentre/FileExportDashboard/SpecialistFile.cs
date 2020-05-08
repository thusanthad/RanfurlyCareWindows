using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class SpecialistFile : FileExportBase
    {        
        
        public SpecialistFile(Jarvis jarvis):base(jarvis)
        {
            Jarvis.ExportOjectType = new Specialist();
            Jarvis.ExportFielFieldList = Jarvis.ResourceFileLocation + Jarvis.GetSpecialistFieldList();
            Jarvis.OutputFileName = "SpecialistList";
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
