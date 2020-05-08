using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class WorkCentreAllocate: WorkCentreAllocateRemoveBase
    {
        public WorkCentreAllocate(StaffWorkCentreAllocation staffWorkCentreAllocation, Staff staff):base(staffWorkCentreAllocation,staff)
        {

        }

        public override void CommitAction()
        {
            _staff.WorkCentres.Clear();
            for (int i = 0; i < _staffWorkCentreAllocation.checkedListBox1.Items.Count; i++)
            {
                if (_staffWorkCentreAllocation.checkedListBox1.GetItemChecked(i))
                {
                    WorkCentre seleted = base.GetSelectedworkCentre(_staffWorkCentreAllocation.checkedListBox1.Items[i].ToString());
                    if (seleted != null)
                        _staff.WorkCentres.Add(seleted);
                }
            }

        }
    }
}

