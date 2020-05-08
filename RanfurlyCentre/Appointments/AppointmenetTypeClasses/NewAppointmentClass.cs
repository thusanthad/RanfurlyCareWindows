using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyCentre;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class NewAppointmentClass : AppointmentClassBase
    {
        //public NewAppointmentClass(AddEditAppointment appointmentAddEdit, AppointmentBase ap) :base(appointmentAddEdit,ap)
        //{
        //    //_frm.PopulateCmboBoxes();
        //    _frm.cmbAddSpecialist.Enabled = false;
        //    _frm.cmbKeyCode.Enabled = false;
        //    base.AddIndexChangedEvent();
        //}

        public NewAppointmentClass(AddEditAppointment appointmentAddEdit) : base(appointmentAddEdit)
        {
            _frm.cmbAddSpecialist.Enabled = false;
            _frm.cmbKeyCode.Enabled = false;
            _frm.cmbSpecialistId.SelectedIndex = -1;
            _frm.cmbAppointmentType.SelectedIndex = -1;
            _frm.cmbResidentId.SelectedIndex = -1;
            _frm.lblHeader.Text = "Add Appointment";
            _frm.cmbStaffAccompanyingId.SelectedIndex = -1;
        }
    }
}
