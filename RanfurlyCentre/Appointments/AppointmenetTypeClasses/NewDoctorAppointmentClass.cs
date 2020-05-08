using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyCentre;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class NewDoctorAppointmentClass : AppointmentClassBase
    {
        //public DoctorAppointmentClass(AddEditAppointment appointmentAddEdit, AppointmentBase ap) :base(appointmentAddEdit,ap)
        //{    
        //    _frm.PopulateDoctors();         
        //    _frm.cmbSpecialistId.SelectedValue = ((DoctorAppointment)_ap).Doctor.PersonId;
        //    _frm.cmbResidentId.SelectedValue = _ap.Student.PersonId;
        //    _frm.cmbStaffAccompanyingId.SelectedValue = _ap.StaffAccompanying.PersonId;
        //    _frm.cmbKeyCode.SelectedText = ((DoctorAppointment)_ap).KeyCode;
        //    _frm.cmbAddSpecialist.Enabled = true;
        //    _frm.cmbKeyCode.Enabled = true;
        //    base.AddIndexChangedEvent();

        //}

        public NewDoctorAppointmentClass(AddEditAppointment appointmentAddEdit) : base(appointmentAddEdit)
        {
            _frm.cmbSpecialistId.SelectedIndexChanged -= _frm.cmbSpecialistId_SelectedIndexChanged;
            _frm.PopulateDoctors(); 
            _frm.cmbKeyCode.Enabled = true;
            _frm.cmbKeyCode.SelectedIndex = -1;
            _frm.cmbSpecialistId.SelectedIndex = -1;
            _frm.cmbSpecialistId.SelectedIndexChanged += _frm.cmbSpecialistId_SelectedIndexChanged;
        }
    }
}
