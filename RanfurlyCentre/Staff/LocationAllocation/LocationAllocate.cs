using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class LocationAllocate: LocationAllocateRemoveBase
    {
        public LocationAllocate(StaffLocationAllocation staffWorkCentreAllocation, Staff staff):base(staffWorkCentreAllocation,staff)
        {

        }

        public override void CommitAction()
        {
            _staff.Locations.Clear();
            for (int i = 0; i < _staffLocationAllocation.checkedListBox1.Items.Count; i++)
            {
                if (_staffLocationAllocation.checkedListBox1.GetItemChecked(i))
                {
                    Location seleted = base.GetSelectedLocation(_staffLocationAllocation.checkedListBox1.Items[i].ToString());
                    if (seleted != null)
                        _staff.Locations.Add(seleted);
                }
            }

        }
    }
}

