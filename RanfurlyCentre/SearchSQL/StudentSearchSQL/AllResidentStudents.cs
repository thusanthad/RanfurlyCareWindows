using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;
using System.Windows.Forms;

namespace RanfurlyCentre
{
    public class AllResidentStudents : SqlGeneratorBase
    {
        public AllResidentStudents(ComboBox comboBox) : base(comboBox)
        {
            _comboBox.Visible = true;
        }

        public override List<Person> GetList()
        {
            string sql = ViewName + "AdmittedToResidence is not null AND IsActive=true";
            return base.GetListFromDatabase(sql);
        }
    }
}
