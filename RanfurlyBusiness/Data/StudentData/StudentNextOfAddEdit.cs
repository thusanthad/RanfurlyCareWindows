using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace RanfurlyBusiness
{
    public class StudentNextOfKinAddEdit : StudentDataAddEditBase
    {
        public StudentNextOfKinAddEdit(Student student, DBCommand dbc):base(student,dbc)
        {
            _database = new NextOfKinData(_dbc);            
            foreach (NextOfKin nextOfKin in student.NextOfKin)
            {
                if (nextOfKin.PersonId == 0)
                {
                    _database.Add(nextOfKin, student.PersonId);
                }
                else
                {
                    bool personExists = _database.PersonExists(nextOfKin.PersonId, student.PersonId);
                    if (!personExists)
                    {
                        _database.Allocate(nextOfKin, student.PersonId);
                    }
                    else
                    {
                        _database.Update(nextOfKin); // update relationship
                    }
                }
            }

            foreach (object obj in student.RemovedObjects)
            {
                if (obj is NextOfKin)
                {
                    _database.Remove((NextOfKin)obj, student.PersonId);
                }
            }
        }
    }
}
