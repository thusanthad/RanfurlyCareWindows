using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyCentre;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class SpecialistAppointmentClass : AppointmentClassBase
    {
        //public SpecialistAppointmentClass(AddEditAppointment appointmentAddEdit, AppointmentBase ap) :base(appointmentAddEdit,ap)
        //{
        //    //_frm.PopulateCmboBoxes();
        //    //_frm.cmbAppointmentType.SelectedValue = _frm._
        //    _frm.cmbAppointmentType.SelectedValue = ap.ProfessionalServiceProviderTypeId;
        //    _frm.PopulateSpecialists();
        //    _frm.cmbSpecialistId.SelectedValue = ((SpecialistAppointment)_ap).Specialist.PersonId;
        //    _frm.cmbResidentId.SelectedValue = _ap.Student.PersonId;
        //    _frm.cmbStaffAccompanyingId.SelectedValue = _ap.StaffAccompanying.PersonId;
        //    _frm.cmbSpecialistId.SelectedIndex = -1;
        //    _frm.cmbAddSpecialist.Enabled = true;
        //    _frm.cmbKeyCode.Enabled = false;
        //    base.AddIndexChangedEvent();
        //}

        public SpecialistAppointmentClass(AddEditAppointment appointmentAddEdit) : base(appointmentAddEdit)
        {
            //_frm.cmbAppointmentType.SelectedValue = _frm._
            _frm.cmbSpecialistId.SelectedIndexChanged -= _frm.cmbSpecialistId_SelectedIndexChanged;
           _frm.cmbAppointmentType.SelectedValue = _frm._appointmentBase.ProfessionalServiceProviderTypeId;
            _frm.PopulateSpecialists();
            SpecialistAppointment ap = (SpecialistAppointment)_frm._appointmentBase;
            _frm.cmbSpecialistId.SelectedValue =ap.Specialist.PersonId;
            base.setComboBoxValues();
            //_frm.cmbAddSpecialist.Enabled = true;
            _frm.cmbKeyCode.Enabled = false;
            //_frm.btnAddAppontment.Text = "Edit Appointment";
            _frm.lblHeader .Text= "Edit Appointment";
            _frm.Text = "Edit Appointment";
            _frm.cmbSpecialistId.SelectedIndexChanged += _frm.cmbSpecialistId_SelectedIndexChanged;
        }
    }
}
