using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre.Students
{
    public class AllCurrentStudents:SqlGeneratorBase
    {
        public override List<Person> GetList()
        {
            string sql = ViewName + "IsActive=true";
            return base.GetListFromDatabase(sql);
        }
    }
}
