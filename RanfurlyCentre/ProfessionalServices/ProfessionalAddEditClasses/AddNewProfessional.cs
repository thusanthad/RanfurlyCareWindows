using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class AddNewProfessional : AddEditProfessionalBase
    {    
        public AddNewProfessional(ProfessionalAddEdit addEdit) : base(addEdit)
        {
            _professionalAddEdit.Text = "Add Specialist";
            //_doctorAddEdit.btnCommit.Text = "Add Doctor";
        }

        public override void Commit()
        {
            DataBase db = new SpecialistData();
            _professionalAddEdit.Specialist.PersonId = db.Add(_professionalAddEdit.Specialist);
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
