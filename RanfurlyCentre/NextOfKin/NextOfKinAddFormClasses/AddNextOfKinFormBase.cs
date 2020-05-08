using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyCentre
{
    public abstract class AddNextOfKinFormBase
    {
        public abstract bool Validated();
        protected NextOfKinAdd _nextOfKinAdd;

        public AddNextOfKinFormBase(NextOfKinAdd doctorAdd)
        {
            _nextOfKinAdd = doctorAdd;
            _nextOfKinAdd.cmbNextOfKinName.SelectedIndex = -1;
            _nextOfKinAdd.txtNextOfKinName.Text = string.Empty;
            
            
            _nextOfKinAdd.txtRelationship.Text = string.Empty;

            _nextOfKinAdd.ep.Clear();
        }
    }
}
