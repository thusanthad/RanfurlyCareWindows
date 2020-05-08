using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;
using System.Windows.Forms;

namespace RanfurlyCentre
{
    public abstract class SqlGeneratorBase
    {
        protected string ViewName;
        public abstract List<Person> GetList();
        protected ComboBox _comboBox;

        public SqlGeneratorBase(ComboBox comboBox)
        {
            ViewName = "SELECT* FROM vw_Students WHERE ";
            _comboBox=comboBox;
            _comboBox.Visible = false;
            //_comboBox.SelectedIndex = -1;
    }

        protected virtual List<Person> GetListFromDatabase(string sql)
        {
            DataBase db = new StudentData();
            return db.GetList(sql);
        }

        
    }
}
