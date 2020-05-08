using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;
using System.Windows.Forms;

namespace RanfurlyCentre
{
    public class AllCurrentStudents : SqlGeneratorBase
    { 

        public AllCurrentStudents(ComboBox comboBox) : base(comboBox)
        {


        }
   
        public override List<Person> GetList()
        {
            string sql = ViewName + "IsActive=true";
            return base.GetListFromDatabase(sql);
        }
    }
}
