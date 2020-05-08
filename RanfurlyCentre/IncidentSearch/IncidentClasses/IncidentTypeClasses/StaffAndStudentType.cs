using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyCentre
{
    public class StaffAndStudentType:IncidentTypeBase
    {
        public StaffAndStudentType(IncidentAddEdit incidentAddEdit):base(incidentAddEdit)
        {
            //_incidentAddEdit.rbStaffAndStudent.Checked = true;            
            _incidentAddEdit.cmbStudent.Enabled = true;
            _incidentAddEdit.cmbStaff.Enabled = true;
            _incidentAddEdit.txtPersonFullName.Text = string.Empty;
        }
    }
}
