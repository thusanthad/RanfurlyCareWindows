using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class DoctorFile:FileExportBase
    {        
        
        public DoctorFile(Jarvis jarvis):base(jarvis)
        {
            Jarvis.ExportOjectType = new Doctor();
            Jarvis.ExportFielFieldList = Jarvis.ResourceFileLocation + Jarvis.GetDoctorFieldList();
            Jarvis.OutputFileName = "DoctorList";
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
