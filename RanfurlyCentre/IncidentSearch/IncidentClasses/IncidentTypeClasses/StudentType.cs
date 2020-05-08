using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyCentre
{
    public class StudentType:IncidentTypeBase
    {
        public StudentType(IncidentAddEdit incidentAddEdit):base(incidentAddEdit)
        {
            //_incidentAddEdit.rbStudent.Checked = true;
            _incidentAddEdit.cmbStaff.SelectedIndex = -1;
            _incidentAddEdit.cmbStaff.Enabled = false;
            _incidentAddEdit.cmbStudent.Enabled = true;
            _incidentAddEdit.txtPersonFullName.Text = string.Empty;
        }
    }
}
