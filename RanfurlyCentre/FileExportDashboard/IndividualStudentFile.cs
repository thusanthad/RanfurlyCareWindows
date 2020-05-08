using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class IndividualStudentFile : FileExportBase
    {        
        
        public IndividualStudentFile(Jarvis jarvis):base(jarvis)
        {
            Jarvis.ExportOjectType = new Student();
            //Jarvis.ExportFielFieldList = Jarvis.ResourceFileLocation + Jarvis.GetIndividualStudentFieldList();
            ConvertFieldsToRows = true;
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
