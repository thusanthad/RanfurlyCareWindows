using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class LocationRemove: LocationAllocateRemoveBase
    {
        public LocationRemove(StaffLocationAllocation staffWorkCentreAllocation, Staff staff):base(staffWorkCentreAllocation,staff)
        {
        }

        public override void CommitAction()
        {

        }

    }
}
