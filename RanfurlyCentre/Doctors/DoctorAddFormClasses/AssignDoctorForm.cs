using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyCentre
{
    public class AssignDoctorForm:AddDoctorFormBase
    {
        public AssignDoctorForm(DoctorAdd da) : base(da)
        {
            _doctorAdd.cmbDoctorName.Visible = true;
            _doctorAdd.txtDoctorName.Visible = false;
            _doctorAdd.txtAddr1.Visible = false;
            _doctorAdd.txtAddr2.Visible = false;
            _doctorAdd.txtAddr3.Visible = false;
            _doctorAdd.txtAddr4.Visible = false;
            _doctorAdd.txtPostcode.Visible = false;
            _doctorAdd.txtPhone.Visible = false;
            _doctorAdd.txtEmail.Visible = false;
            _doctorAdd.cmbDoctorName.Focus();

            _doctorAdd.label2.Visible = false;
            _doctorAdd.label3.Visible = false;
            _doctorAdd.label4.Visible = false;
            _doctorAdd.label5.Visible = false;
            _doctorAdd.label6.Visible = false;
            _doctorAdd.label7.Visible = false;
            _doctorAdd.label8.Visible = false;

            _doctorAdd.btnAdd.Text = "Assign";
        }

        public override bool Validated()
        {
            if (_doctorAdd.cmbDoctorName.SelectedIndex != -1)
                return true;
            else
            {
                _doctorAdd.ep.SetError(_doctorAdd.cmbDoctorName, "Select a doctor from list");
                return false;
            }
        }
    }
}
