using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;
using DataAccess;

namespace RanfurlyCentre
{
    public  class StudentAddEditClass: StudentAddEditBaseClass
    {
        public StudentAddEditClass(Student student):base(student)
        {
           
        }

        public override void Add(object objetType)
        {
            if (objetType is Doctor)
            {
                Doctor doctor = (Doctor)objetType;
                Student.Doctors.Add(doctor);
            }

            if (objetType is NextOfKin)
            {
                NextOfKin nextOfKin = (NextOfKin)objetType;
                Student.NextOfKin.Add(nextOfKin);
            }

            if (objetType is EmergencyContact)
            {
                EmergencyContact emergencyContact = (EmergencyContact)objetType;
                Student.EmergencyContacts.Add(emergencyContact);
            }

            if (objetType is MedicalCondition)
            {
                MedicalCondition medicalCondition = (MedicalCondition)objetType;
                Student.MedicalConditions.Add(medicalCondition);
            }

            if (objetType is StudentNote)
            {
                StudentNote studentNote = (StudentNote)objetType;
                Student.StudentNotes.Add(studentNote);
            }

        }

        public override void Remove(object removedObject)
        {
            Student.RemovedObjects.Add(removedObject);
        }

        public override void Save()
        {
            DBCommand dbc = new DBCommand(DBCommand.TransactionType.WithTransaction);
            try
            {               
                DataBase db = new StudentData(dbc);
                if (Student.PersonId == 0)
                {
                    int studentId = db.Add(Student);
                    if (Student.Doctors.Count > 0)
                    {
                        db = new DoctorData(dbc);
                        foreach (Doctor doctor in Student.Doctors)
                        {
                            db.Allocate(doctor, studentId);
                        }
                    }

                    if (Student.NextOfKin.Count > 0)
                    {
                        db = new NextOfKinData(dbc);
                        foreach (NextOfKin nok in Student.NextOfKin)
                        {
                            if (nok.PersonId == 0)
                            {
                                nok.PersonId = db.Add(nok, studentId);
                            }
                            else
                            {
                                db.Allocate(nok, studentId);
                            }

                        }
                    }

                    if (Student.EmergencyContacts.Count > 0)
                    {
                        db = new EmergencyContactData(dbc);
                        foreach (EmergencyContact ec in Student.EmergencyContacts)
                        {
                            //if (ec.PersonId == 0)
                            //{
                                ec.PersonId = db.Add(ec, studentId);
                            //}
                            //db.Allocate(ec, studentId);
                        }
                    }

                    if (Student.MedicalConditions.Count > 0)
                    {
                        MedicalConditionData  mdc = new MedicalConditionData(dbc);
                        foreach (MedicalCondition mc in Student.MedicalConditions)
                        {
                            mdc.Add(mc, studentId);
                        }
                    }
                }
                else
                {
                    db.Update(Student);
                }
                dbc.CommitTransactions();
                dbc.CloseConnection();
                Student.RemovedObjects.Clear();
            }
            catch (Exception ex)
            {
                dbc.rollbackTransactions();
                dbc.CloseConnection();
                throw new Exception(ex.Message);
            }
            
        }
    }
}
