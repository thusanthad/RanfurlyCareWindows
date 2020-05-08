using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public abstract class WorkCentreAllocateRemoveBase
    {
        public abstract void CommitAction();
        protected Staff _staff;        
        protected StaffWorkCentreAllocation _staffWorkCentreAllocation;
        public List<WorkCentre> WorkCentres { get; set; }

        public WorkCentreAllocateRemoveBase(StaffWorkCentreAllocation staffWorkCentreAllocation, Staff staff)
        {
            _staffWorkCentreAllocation = staffWorkCentreAllocation;
            _staff = staff;
            populateWorkCentres();
        }

        private void populateWorkCentres()
        {
            WorkCentreData wcd = new WorkCentreData();
            WorkCentres = wcd.GetList();
            int i = 0;
            foreach (WorkCentre wc in WorkCentres)
            {
                _staffWorkCentreAllocation.checkedListBox1.Items.Add(wc.WorkCentreName);
                if(FindWorkCentre(wc.WorkCentreName))
                    _staffWorkCentreAllocation.checkedListBox1.SetItemChecked(i, true);
                i += 1;
            }            
        }

        private bool FindWorkCentre(string wc)
        {
            WorkCentre workCentre = _staff.WorkCentres.Find(x => x.WorkCentreName == wc);
            return workCentre != null;
        }

        protected WorkCentre GetSelectedworkCentre(string wc)
        {
            WorkCentre workCentre = WorkCentres.Find(x => x.WorkCentreName == wc);
            return workCentre;
        }

    }
}
