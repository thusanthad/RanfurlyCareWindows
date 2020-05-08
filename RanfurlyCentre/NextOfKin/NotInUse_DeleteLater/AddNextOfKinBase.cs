using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;
using System.Windows.Forms;

namespace RanfurlyCentre
{
    public abstract class AddNextOfKinBase
    {
        public abstract void Commit();
        //public Doctor Doctor { get; set; }
        //public abstract void AddDoctor(Doctor doctor);
        //public abstract void AllocateDoctor(Doctor doctor);
        protected NextOfKinAdd _doctorAddEdit;

        public AddNextOfKinBase(NextOfKinAdd doctorAddEdit)
        {
            _doctorAddEdit = doctorAddEdit;
            AddBindingToDoctor();
        }

        private void AddBindingToDoctor()
        {
            _doctorAddEdit.txtFirstName.DataBindings.Add("Text", _doctorAddEdit.NextOfKin, "FullName");
            _doctorAddEdit.txtAddr1.DataBindings.Add("Text", _doctorAddEdit.NextOfKin, "Addr1");
            _doctorAddEdit.txtAddr2.DataBindings.Add("Text", _doctorAddEdit.NextOfKin, "Addr2");
            _doctorAddEdit.txtAddr3.DataBindings.Add("Text", _doctorAddEdit.NextOfKin, "Addr3");
            _doctorAddEdit.txtAddr4.DataBindings.Add("Text", _doctorAddEdit.NextOfKin, "Addr4");
            _doctorAddEdit.txtPostcode.DataBindings.Add("Text", _doctorAddEdit.NextOfKin, "Postcode");
            //_doctorAddEdit.txtPostcode.DataBindings.Add("Text", _doctorAddEdit.Doctor, "Postcode");
            _doctorAddEdit.txtPhone.DataBindings.Add("Text", _doctorAddEdit.NextOfKin, "Phone");
            _doctorAddEdit.txtEmail.DataBindings.Add("Text", _doctorAddEdit.NextOfKin, "Email");
        }

        public bool ValidateInput()
        {
            _doctorAddEdit.ep.Clear();
            if (_doctorAddEdit.txtFirstName.Text == string.Empty)
                _doctorAddEdit.ep.SetError(_doctorAddEdit.txtFirstName, "Type new doctor name");
            if (_doctorAddEdit.txtAddr1.Text == string.Empty)
                _doctorAddEdit.ep.SetError(_doctorAddEdit.txtAddr1, "Type Addr1");
            if (_doctorAddEdit.txtAddr2.Text == string.Empty)
                _doctorAddEdit.ep.SetError(_doctorAddEdit.txtAddr2, "Type Addr2");
            if (_doctorAddEdit.txtAddr3.Text == string.Empty)
                _doctorAddEdit.ep.SetError(_doctorAddEdit.txtAddr3, "Type Addr3");
            if (_doctorAddEdit.txtPostcode.Text == string.Empty)
                _doctorAddEdit.ep.SetError(_doctorAddEdit.txtPostcode, "Type Postcode");
            if (_doctorAddEdit.txtPhone.Text == string.Empty)
                _doctorAddEdit.ep.SetError(_doctorAddEdit.txtPhone, "Type Phone");

            bool failed = true;
            foreach (Control c in _doctorAddEdit.Controls)
            {
                if (_doctorAddEdit.ep.GetError(c).Length > 0)
                {
                    failed = false;
                    break;
                }
            }
            return failed;
        }
    }
}
