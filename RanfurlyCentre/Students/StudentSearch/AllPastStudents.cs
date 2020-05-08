using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre.Students
{
    public class AllPastStudents:SqlGeneratorBase
    {
        public override List<Person> GetList()
        {
            string sql = ViewName + "IsActive=false";
            return base.GetListFromDatabase(sql);
        }
    }
}
