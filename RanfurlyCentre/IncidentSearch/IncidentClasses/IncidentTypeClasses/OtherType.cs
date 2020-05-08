using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyCentre
{
    public class OtherType:IncidentTypeBase
    {
        public OtherType(IncidentAddEdit incidentAddEdit):base(incidentAddEdit)
        {
            //_incidentAddEdit.rbOther.Checked = true;
            _incidentAddEdit.cmbStudent.SelectedIndex = -1;
            _incidentAddEdit.cmbStaff.SelectedIndex = -1;
            _incidentAddEdit.cmbStudent.Enabled = false;
            _incidentAddEdit.cmbStaff.Enabled = false;
            _incidentAddEdit.txtPersonFullName.Enabled = true;
            _incidentAddEdit.txtPersonFullName.Focus();            
        }
    }
}
