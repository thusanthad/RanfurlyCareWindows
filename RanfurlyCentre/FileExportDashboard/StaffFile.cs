using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class StaffFile:FileExportBase
    {        
        
        public StaffFile(Jarvis jarvis):base(jarvis)
        {
            Jarvis.ExportOjectType = new Staff();
            Jarvis.ExportFielFieldList = Jarvis.ResourceFileLocation + Jarvis.GetStaffFieldList();
            Jarvis.OutputFileName = "StaffList";
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
