using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;
using DataAccess;

namespace RanfurlyCentre
{
    public class StaffEdit:StaffAddEditBase
    {
        public StaffEdit(StaffAddEdit staffAddEdit, Staff staff):base(staffAddEdit, staff)
        {
            //_staffEdit.btnUpdae.Visible = false;
        }

        public override bool Validated()
        {
            return base.Validated();
        }

        public override void update()
        {
            DataBase db = new StaffData();
            db.Update(Staff);
        }
    }
}
