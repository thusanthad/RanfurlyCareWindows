using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre.Students
{
    public abstract class SqlGeneratorBase
    {
        protected string ViewName;
        public abstract List<Person> GetList();

        public SqlGeneratorBase()
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
