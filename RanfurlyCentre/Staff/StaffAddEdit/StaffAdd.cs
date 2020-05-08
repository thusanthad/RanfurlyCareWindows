using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class StaffAdd:StaffAddEditBase
    {
        public StaffAdd(StaffAddEdit staffAddEdit, Staff staff):base(staffAddEdit, staff)
        {
            //staffAddEdit.btnUpdae.Enabled = true;
            //staffAddEdit.btnUpdae.Text = "Add";
            staffAddEdit.Text = "Add Staff";
        }

        public override bool Validated()
        {
            return base.Validated();
        }

        public override void update()
        {
            DataBase db = new StaffData();
            db.Add(Staff);
        }
    }
}
