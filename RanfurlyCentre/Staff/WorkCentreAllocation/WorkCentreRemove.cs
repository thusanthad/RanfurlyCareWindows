using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class WorkCentreRemove: WorkCentreAllocateRemoveBase
    {
        public WorkCentreRemove(StaffWorkCentreAllocation staffWorkCentreAllocation, Staff staff):base(staffWorkCentreAllocation,staff)
        {
        }

        public override void CommitAction()
        {

        }

    }
}
