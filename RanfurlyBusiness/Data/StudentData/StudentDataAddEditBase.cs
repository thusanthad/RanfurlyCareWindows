using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace RanfurlyBusiness
{
    public abstract class StudentDataAddEditBase
    {
        //public abstract void Add();
        //public abstract void Update();
        //public abstract void Remove();

        protected Student _student;
        protected DBCommand _dbc;
        protected DataBase _database;

        public StudentDataAddEditBase(Student student, DBCommand dbc)
        {
            _student = student;
            _dbc = dbc;
        }
    }
}
