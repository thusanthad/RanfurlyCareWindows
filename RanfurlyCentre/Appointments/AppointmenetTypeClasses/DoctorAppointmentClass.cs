using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyCentre;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class DoctorAppointmentClass : AppointmentClassBase
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

        public DoctorAppointmentClass(AddEditAppointment appointmentAddEdit) : base(appointmentAddEdit)
        {
            _frm.cmbSpecialistId.SelectedIndexChanged -= _frm.cmbSpecialistId_SelectedIndexChanged;
            _frm.cmbAppointmentType.SelectedValue = _frm._appointmentBase.ProfessionalServiceProviderTypeId;
            _frm.PopulateDoctors();
            DoctorAppointment ap = (DoctorAppointment)_frm._appointmentBase;
            //if(ap.Doctor !=null)
            _frm.cmbSpecialistId.SelectedValue = ap.Doctor.PersonId;
            _frm.cmbKeyCode.Text = ap.KeyCode;
            base.setComboBoxValues();
            //_frm.cmbAddSpecialist.Enabled = true;
            _frm.cmbKeyCode.Enabled = true;
            _frm.lblHeader.Text = "Edit Appointment";
            _frm.Text = "Edit Appointment";
            _frm.cmbSpecialistId.SelectedIndexChanged += _frm.cmbSpecialistId_SelectedIndexChanged;
            //_frm.cmbKeyCode.SelectedIndex = -1;

        }
    }
}
