using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public abstract class LocationAllocateRemoveBase
    {
        public abstract void CommitAction();
        protected Staff _staff;        
        protected StaffLocationAllocation _staffLocationAllocation;
        public List<Location> Locations { get; set; }

        public LocationAllocateRemoveBase(StaffLocationAllocation staffLocationAllocation, Staff staff)
        {
            _staffLocationAllocation = staffLocationAllocation;
            _staff = staff;
            populateLocations();
        }

        private void populateLocations()
        {
            LocationData ld = new LocationData();
            Locations = ld.GetList();
            int i = 0;
            foreach (Location wc in Locations)
            {
                _staffLocationAllocation.checkedListBox1.Items.Add(wc.LocationName);
                if(FindWorkCentre(wc.LocationNameWithoutAbbreviation))
                    _staffLocationAllocation.checkedListBox1.SetItemChecked(i, true);
                i += 1;
            }            
        }

        private bool FindWorkCentre(string wc)
        {
            Location workCentre = _staff.Locations.Find(x => x.LocationNameWithoutAbbreviation == wc);
            return workCentre != null;
        }

        protected Location GetSelectedLocation(string wc)
        {
            Location location = Locations.Find(x => x.LocationName == wc);
            return location;
        }

    }
}
