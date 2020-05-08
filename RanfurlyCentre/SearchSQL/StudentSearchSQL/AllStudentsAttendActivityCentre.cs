using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;
using System.Windows.Forms;

namespace RanfurlyCentre
{
    public class AllStudentsAttendActivityCentre : SqlGeneratorBase
    {
        public AllStudentsAttendActivityCentre(ComboBox comboBox) : base(comboBox)
        {

        }

        public override List<Person> GetList()
        {
            string sql = ViewName + "AttendsActivityCentre=true AND IsActive=true";
            return base.GetListFromDatabase(sql);
        }
    }
}
