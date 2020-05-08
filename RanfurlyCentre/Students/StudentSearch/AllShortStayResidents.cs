using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre.Students
{
    public class AllShortStayResidents : SqlGeneratorBase
    {
        public override List<Person> GetList()
        {
            string sql = ViewName + "IsShortStayresident=true AND IsActive=true";
            return base.GetListFromDatabase(sql);
        }
    }
}
