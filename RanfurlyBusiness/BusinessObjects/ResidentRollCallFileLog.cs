using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace RanfurlyBusiness
{
    public class ResidentRollCallFileLog
    {
        public int ResidentRollCallImportId { get; set; }       
        public string FileLocation { get; set; }
        public string FileName { get; set; }

        public void RemoveFile()
        {
            ResidentRollCallData data = new ResidentRollCallData();
            data.RemoveFile(this);
        }
    }

   


}
