using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;
using System.Windows.Forms;

namespace RanfurlyCentre
{
    public class AllPastStudents:SqlGeneratorBase
    {
        public AllPastStudents(ComboBox comboBox) : base(comboBox)
        {
           
        }

        public override List<Person> GetList()
        {
            string sql = ViewName + "IsActive=false";
            return base.GetListFromDatabase(sql);
        }
    }
}
