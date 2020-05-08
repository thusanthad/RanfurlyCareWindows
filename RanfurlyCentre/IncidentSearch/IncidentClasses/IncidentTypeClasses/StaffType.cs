using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyCentre
{
    public class StaffType:IncidentTypeBase
    {
        public StaffType(IncidentAddEdit incidentAddEdit):base(incidentAddEdit)
        {
            //_incidentAddEdit.rbStaff.Checked = true;
            _incidentAddEdit.cmbStudent.SelectedIndex = -1;
            _incidentAddEdit.cmbStudent.Enabled = false;
            _incidentAddEdit.cmbStaff.Enabled = true;
            _incidentAddEdit.txtPersonFullName.Text = string.Empty;
        }
    }
}
