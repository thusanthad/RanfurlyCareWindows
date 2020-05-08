using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RanfurlyCentre
{
    public class AddNextOfKinForm : AddNextOfKinFormBase
    {
        public AddNextOfKinForm(NextOfKinAdd nok) : base(nok)
        {
            _nextOfKinAdd.cmbNextOfKinName.Visible = false;
            _nextOfKinAdd.txtNextOfKinName.Visible = true;
            _nextOfKinAdd.btnAdd.Text = "Add";
        }

        public override bool Validated()
        {
           if (_nextOfKinAdd.txtRelationship.Text == string.Empty)
                _nextOfKinAdd.ep.SetError(_nextOfKinAdd.txtRelationship, "Type relationship");

            bool failed = true;
            foreach (Control c in _nextOfKinAdd.Controls)
            {
                if (_nextOfKinAdd.ep.GetError(c).Length > 0)
                {
                    failed = false;
                    break;
                }

            }
            return failed;
        }
    }
}
