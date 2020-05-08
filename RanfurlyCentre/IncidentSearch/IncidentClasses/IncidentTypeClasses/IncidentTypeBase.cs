using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyCentre
{
    public abstract class IncidentTypeBase
    {
        protected IncidentAddEdit _incidentAddEdit;

        public IncidentTypeBase(IncidentAddEdit incidentAddEdit)
        {
            _incidentAddEdit = incidentAddEdit;
            _incidentAddEdit.txtPersonFullName.Enabled = false;
            //_incidentAddEdit.rbOther.Checked = false;
            //_incidentAddEdit.rbStaffAndStudent.Checked = false;
            //_incidentAddEdit.rbStaff.Checked = false;
            //_incidentAddEdit.rbStudent.Checked = false;

        }
    }
}
