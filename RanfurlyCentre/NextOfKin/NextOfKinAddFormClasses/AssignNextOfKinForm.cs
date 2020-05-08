using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyCentre
{
    public class AssignNextOfKinForm : AddNextOfKinFormBase
    {
        public AssignNextOfKinForm(NextOfKinAdd da) : base(da)
        {
            _nextOfKinAdd.cmbNextOfKinName.Visible = true;
            _nextOfKinAdd.txtNextOfKinName.Visible = false;
            
            _nextOfKinAdd.cmbNextOfKinName.Focus();

            

            _nextOfKinAdd.btnAdd.Text = "Assign";
        }

        public override bool Validated()
        {
            if (_nextOfKinAdd.cmbNextOfKinName.SelectedIndex != -1 && _nextOfKinAdd.txtRelationship.Text != string.Empty)
                return true;
            else
            {
                if (_nextOfKinAdd.cmbNextOfKinName.SelectedIndex == -1)
                _nextOfKinAdd.ep.SetError(_nextOfKinAdd.cmbNextOfKinName, "Select a next of kin from list");
                if(_nextOfKinAdd.txtRelationship.Text==string.Empty)
                    _nextOfKinAdd.ep.SetError(_nextOfKinAdd.txtRelationship, "Type relationship");
                return false;
            }
        }
    }
}
