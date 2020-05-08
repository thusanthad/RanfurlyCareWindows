using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DataAccess;
using System.Data;

namespace RanfurlyBusiness
{
    public abstract class DataBase:IData
    {        
        public abstract List<Person> GetList();
        public abstract List<Person> GetList(string sql);
        public abstract List<Person> GetList(int PersonId);
       // public abstract DataTable GeteExportDatatable(List<object> list);
        public abstract bool PersonExists(int PersonId, int studentId);
        public abstract void Update(List<Person> persons);
        public abstract void Update(Person persons);
        public abstract int Add(Person person);
        public abstract int Add(Person person, int StudentId);
        public abstract void Allocate(Person person, int StudentId);
        public abstract void Remove(Person person, int StudentId);

        protected DBCommand dbc;
        //public DataBase(DBCommand.TransactionType transactionType )
        //{
        //    dbc = new DBCommand(transactionType);
        //}

        public DataBase()
        {
            dbc = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
        }

        public DataBase(DBCommand dbommand)
        {
            dbc = dbommand;
        }

        
    }
}
