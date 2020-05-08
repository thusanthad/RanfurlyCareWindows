using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public abstract class FileExportBase
    {        
        public Jarvis Jarvis { get; set; }
        public abstract void Save();
        public bool ConvertFieldsToRows { get; set; }
        public FileExportBase(Jarvis jarvis)
        {
            Jarvis = jarvis;
        }

        protected virtual void PopulateFields()
        {

        }

    }
}
