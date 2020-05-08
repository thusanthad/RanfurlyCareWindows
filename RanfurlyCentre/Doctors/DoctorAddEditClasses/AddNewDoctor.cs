using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class AddNewDoctor:AddEditDoctorBase
    {    
        public AddNewDoctor(DoctorAddEdit doctorAddEdit) : base(doctorAddEdit)
        {
            _doctorAddEdit.Text = "Add Doctor";
            //_doctorAddEdit.btnCommit.Text = "Add Doctor";
        }

        public override void Commit()
        {
            DataBase db = new DoctorData();
            _doctorAddEdit.Doctor.PersonId = db.Add(_doctorAddEdit.Doctor);
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
