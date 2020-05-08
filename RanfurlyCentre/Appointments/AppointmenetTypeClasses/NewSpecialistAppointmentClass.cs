using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyCentre;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class NewSpecialistAppointmentClass : AppointmentClassBase
    {
        public NewSpecialistAppointmentClass(AddEditAppointment appointmentAddEdit) : base(appointmentAddEdit)
        {
            _frm.cmbSpecialistId.SelectedIndexChanged -= _frm.cmbSpecialistId_SelectedIndexChanged;
            _frm.PopulateSpecialists();
            _frm.cmbKeyCode.Enabled = false;
            _frm.cmbKeyCode.SelectedIndex = -1;
            _frm.cmbSpecialistId.SelectedIndex = -1;
            _frm.cmbSpecialistId.SelectedIndexChanged += _frm.cmbSpecialistId_SelectedIndexChanged;

        }
    }
}
