using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class EditDoctor:AddEditDoctorBase
    {    
        public EditDoctor(DoctorAddEdit doctorAddEdit) :base(doctorAddEdit)
        {
            _doctorAddEdit.Text = "Update Doctor";
        }

        public override void Commit()
        {
            DataBase db = new DoctorData();
            db.Update(_doctorAddEdit.Doctor);
        }

        //public override void AllocateDoctor(Doctor doctor)
        //{
        //    //DataBase db = new DoctorData();
        //    //db.Allocate(doctor, Student.PersonId);
        //}
    }
}
