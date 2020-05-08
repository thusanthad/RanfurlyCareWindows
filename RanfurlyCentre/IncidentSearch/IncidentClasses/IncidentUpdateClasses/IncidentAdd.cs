using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class IncidentAdd:IncidentAddEditBase
    {
        public IncidentAdd(Incident incident):base(incident)
        {
            
        }

        public override void Save()
        {
            _incident.UpdatePersonFullName();
            IncidentData id = new IncidentData();
            id.Add(_incident);
        }
    }

   
}
