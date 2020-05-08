using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;
using System.Windows.Forms;

namespace RanfurlyCentre
{
    public abstract class AddEditProfessionalBase
    {
        public abstract void Commit();
        protected ProfessionalAddEdit _professionalAddEdit;

        public AddEditProfessionalBase(ProfessionalAddEdit professionalAddEdit)
        {
            _professionalAddEdit = professionalAddEdit;
            //PopulateProfessionTypeComboBox();
            AddBindingToDoctor();
        }

        private void AddBindingToDoctor()
        {
            _professionalAddEdit.txtSpecialistName.DataBindings.Add("Text", _professionalAddEdit.Specialist, "FullName");
            _professionalAddEdit.txtAddr1.DataBindings.Add("Text", _professionalAddEdit.Specialist, "Addr1");
            _professionalAddEdit.txtAddr2.DataBindings.Add("Text", _professionalAddEdit.Specialist, "Addr2");
            _professionalAddEdit.txtAddr3.DataBindings.Add("Text", _professionalAddEdit.Specialist, "Addr3");
            _professionalAddEdit.txtAddr4.DataBindings.Add("Text", _professionalAddEdit.Specialist, "Addr4");
            _professionalAddEdit.txtPostcode.DataBindings.Add("Text", _professionalAddEdit.Specialist, "Postcode");
            //_doctorAddEdit.txtPostcode.DataBindings.Add("Text", _doctorAddEdit.Doctor, "Postcode");
            _professionalAddEdit.txtPhone.DataBindings.Add("Text", _professionalAddEdit.Specialist, "Phone");
            _professionalAddEdit.txtEmail.DataBindings.Add("Text", _professionalAddEdit.Specialist, "Email");
        }

        public bool ValidateInput()
        {
            _professionalAddEdit.ep.Clear();
            if (_professionalAddEdit.txtSpecialistName.Text == string.Empty)
                _professionalAddEdit.ep.SetError(_professionalAddEdit.txtSpecialistName, "Type new specialist name");
            if (_professionalAddEdit.txtAddr1.Text == string.Empty)
                _professionalAddEdit.ep.SetError(_professionalAddEdit.txtAddr1, "Type Addr1");
            if (_professionalAddEdit.txtAddr2.Text == string.Empty)
                _professionalAddEdit.ep.SetError(_professionalAddEdit.txtAddr2, "Type Addr2");
            if (_professionalAddEdit.txtAddr3.Text == string.Empty)
                _professionalAddEdit.ep.SetError(_professionalAddEdit.txtAddr3, "Type Addr3");
            if (_professionalAddEdit.txtPostcode.Text == string.Empty)
                _professionalAddEdit.ep.SetError(_professionalAddEdit.txtPostcode, "Type Postcode");
            if (_professionalAddEdit.txtPhone.Text == string.Empty)
                _professionalAddEdit.ep.SetError(_professionalAddEdit.txtPhone, "Type Phone");
            if (_professionalAddEdit.cmbPersonType.SelectedIndex == -1) 
                _professionalAddEdit.ep.SetError(_professionalAddEdit.cmbPersonType, "Select Service Type");

            bool failed = true;
            foreach (Control c in _professionalAddEdit.Controls)
            {
                if (_professionalAddEdit.ep.GetError(c).Length > 0)
                {
                    failed = false;
                    break;
                }
            }
            return failed;
        }

        //private void PopulateProfessionTypeComboBox()
        //{

        //}
    }
}
