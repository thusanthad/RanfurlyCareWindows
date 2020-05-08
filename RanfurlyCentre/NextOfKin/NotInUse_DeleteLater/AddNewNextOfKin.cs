using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class AddNewNextOfKin : AddNextOfKinBase
    {    
        public AddNewNextOfKin(NextOfKinAdd doctorAddEdit) : base(doctorAddEdit)
        {
            _doctorAddEdit.Text = "Add Doctor to List";
            _doctorAddEdit.btnCommit.Text = "Add Doctor";
        }

        public override void Commit()
        {
            DataBase db = new NextOfKinData();
            _doctorAddEdit.NextOfKin.PersonId = db.Add(_doctorAddEdit.NextOfKin);
        }

        //public override void AllocateDoctor(Doctor doctor)
        //{
        //    Student.Doctors.Add(doctor);
        //    //throw new NotImplementedException("not implemented");
        //    //DataBase db = new DoctorData();
        //    //db.Allocate(doctor, Student.PersonId);
        //}
    }
}
