using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre.Students
{
    public class AllResidentStudents : SqlGeneratorBase
    {
        public override List<Person> GetList()
        {
            string sql = ViewName + "AdmittedToResidence is not null AND IsActive=true";
            return base.GetListFromDatabase(sql);
        }
    }
}
