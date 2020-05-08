using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyCentre;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class AppointmentClassBase
    {
        protected AddEditAppointment _frm;

        public AppointmentClassBase(AddEditAppointment appointmentAddEdit)
        {
            _frm = appointmentAddEdit;
            _frm.cmbKeyCode.Enabled = false;
            //_frm.cmbKeyCode.SelectedIndex = -1;            
        }

        protected virtual void setComboBoxValues()
        {
            _frm.cmbStaffAccompanyingId.SelectedValue = _frm._appointmentBase.StaffAccompanying.PersonId;
            _frm.cmbResidentId.SelectedValue = _frm._appointmentBase.Student.PersonId;
        }

        //protected void RemoveIndexChangedEvent()
        //{
        //    _frm.cmbAppointmentType.SelectedIndexChanged -= _frm.cmbAppointmentType_SelectedIndexChanged;
        //    _frm.cmbStaffAccompanyingId.SelectedIndexChanged -= _frm.cmbStaffAccompanyingId_SelectedIndexChanged;
        //    _frm.cmbResidentId.SelectedIndexChanged -= _frm.cmbResidentId_SelectedIndexChanged;
        //    _frm.cmbSpecialistId.SelectedIndexChanged -= _frm.cmbSpecialistId_SelectedIndexChanged;
        //    _frm.cmbKeyCode.SelectedIndexChanged -= _frm.cmbKeyCode_SelectedIndexChanged;
        //}
        //protected void AddIndexChangedEvent()
        //{
        //    _frm.cmbAppointmentType.SelectedIndexChanged += _frm.cmbAppointmentType_SelectedIndexChanged;
        //    _frm.cmbStaffAccompanyingId.SelectedIndexChanged += _frm.cmbStaffAccompanyingId_SelectedIndexChanged;
        //    _frm.cmbResidentId.SelectedIndexChanged += _frm.cmbResidentId_SelectedIndexChanged;
        //    _frm.cmbSpecialistId.SelectedIndexChanged += _frm.cmbSpecialistId_SelectedIndexChanged;
        //    _frm.cmbKeyCode.SelectedIndexChanged += _frm.cmbKeyCode_SelectedIndexChanged;

        //}

    }
}
