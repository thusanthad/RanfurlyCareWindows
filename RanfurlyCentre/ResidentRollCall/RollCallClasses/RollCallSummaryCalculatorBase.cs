using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;
using System.Reflection;

namespace RanfurlyCentre
{
    public abstract class RollCallSummaryCalculatorBase
    {
        public abstract ResidentCallSummaryBase FindSummaryItems(ResidentRollCall call);
        public abstract void Calculate();
        protected List<ResidentRollCall> _rollCallList;
        public List<ResidentCallSummaryBase> ResidentCallSummaryListBase { get; set; }

        public RollCallSummaryCalculatorBase(List<ResidentRollCall> rollCallList)
        {
            _rollCallList = rollCallList;
            ResidentCallSummaryListBase = new List<ResidentCallSummaryBase>();
        }

        
        public PropertyInfo[] GetRollCallProperties()
        {
            PropertyInfo[] properties = typeof(ResidentRollCall).GetProperties();
            return properties;
        }
    }
}
