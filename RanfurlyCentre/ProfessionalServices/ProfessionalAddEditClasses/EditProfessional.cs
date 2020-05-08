using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class EditProfessional : AddEditProfessionalBase
    {    
        public EditProfessional(ProfessionalAddEdit doctorAddEdit) :base(doctorAddEdit)
        {
            _professionalAddEdit.Text = "Update Specialist";
        }

        public override void Commit()
        {
            DataBase db = new SpecialistData();
            db.Update(_professionalAddEdit.Specialist);
        }

        //public override void AllocateDoctor(Doctor doctor)
        //{
        //    //DataBase db = new DoctorData();
        //    //db.Allocate(doctor, Student.PersonId);
        //}
    }
}
