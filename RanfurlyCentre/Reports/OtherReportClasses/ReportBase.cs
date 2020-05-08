using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre.Students
{
    public abstract class ReportBase
    {
        protected string ViewName;
        public abstract List<Person> GetList();

        public ReportBase()
        {
            ViewName = "SELECT* FROM vw_Students WHERE ";
        }

        protected virtual List<Person> GetListFromDatabase(string sql)
        {
            DataBase db = new StudentData();
            return db.GetList(sql);
        }
    }
}
