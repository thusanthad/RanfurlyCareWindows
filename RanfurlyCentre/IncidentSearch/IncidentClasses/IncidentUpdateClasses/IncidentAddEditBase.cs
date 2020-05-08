using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public abstract class IncidentAddEditBase
    {
        public abstract void Save();
        protected Incident _incident;

        public IncidentAddEditBase(Incident incident)
        {
            _incident = incident;
           
        }
    }
}
