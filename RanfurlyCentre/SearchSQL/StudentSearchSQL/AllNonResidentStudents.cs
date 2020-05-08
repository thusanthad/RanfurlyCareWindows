using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;
using System.Windows.Forms;

namespace RanfurlyCentre
{
    public class AllNonResidentStudents : SqlGeneratorBase
    {
        public AllNonResidentStudents(ComboBox comboBox) : base(comboBox)
        {
            
        }
        public override List<Person> GetList()
        {
            string sql = ViewName + "AdmittedToResidence is null AND IsActive=true";
            return base.GetListFromDatabase(sql);
        }
    }
}
