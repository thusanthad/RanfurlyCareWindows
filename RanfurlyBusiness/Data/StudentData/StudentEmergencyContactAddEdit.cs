using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace RanfurlyBusiness
{
    public class StudentEmergencyContactAddEdit : StudentDataAddEditBase
    {
        public StudentEmergencyContactAddEdit(Student student, DBCommand dbc):base(student,dbc)
        {
            _database = new EmergencyContactData(_dbc);            
            foreach (EmergencyContact ec in student.EmergencyContacts)
            {
                if (ec.StudentEmergencyContactId == 0)
                {
                    _database.Add(ec, student.PersonId);
                }
                else
                {
                    _database.Update(ec);
                }
            }

            foreach (object obj in student.RemovedObjects)
            {
                if (obj is EmergencyContact)
                {
                    _database.Remove((EmergencyContact)obj, student.PersonId);
                }
            }
        }
    }
}
