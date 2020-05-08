using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Data;

namespace RanfurlyBusiness
{
    public interface IData
    {
        List<Person> GetList();
        List<Person> GetList(string sql);
        List<Person> GetList(int PersonId);
        //DataTable GeteExportDatatable(List<object> list);
        bool PersonExists(int PersonId,int studentId);
        //List<Person> GetList(int PersonId);
        void Update(List<Person> persons);
        void Update(Person person);
        int Add(Person person);
        int Add(Person person, int StudentId);
        void Allocate(Person person, int StudentId);
        void Remove(Person person, int StudentId);
    }
}
