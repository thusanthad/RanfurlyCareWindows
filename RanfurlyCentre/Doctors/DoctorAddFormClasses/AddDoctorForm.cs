using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RanfurlyCentre
{
    public class AddDoctorForm:AddDoctorFormBase
    {
        public AddDoctorForm(DoctorAdd da) : base(da)
        {
            _doctorAdd.cmbDoctorName.Visible = false;
            _doctorAdd.txtDoctorName.Visible = true;
            _doctorAdd.txtAddr1.Visible = true;
            _doctorAdd.txtAddr2.Visible = true;
            _doctorAdd.txtAddr3.Visible = true;
            _doctorAdd.txtAddr4.Visible = true;
            _doctorAdd.txtPostcode.Visible = true;
            _doctorAdd.txtPhone.Visible = true;
            _doctorAdd.txtEmail.Visible = true;

            _doctorAdd.label2.Visible = true;
            _doctorAdd.label3.Visible = true;
            _doctorAdd.label4.Visible = true;
            _doctorAdd.label5.Visible = true;
            _doctorAdd.label6.Visible = true;
            _doctorAdd.label7.Visible = true;
            _doctorAdd.label8.Visible = true;

            _doctorAdd.btnAdd.Text = "Add";
        }

        public override bool Validated()
        {
            //if (_doctorAdd.cmbDoctorName.Text == string.Empty && _doctorAdd.rbAllocateFromList.Checked)
            //    _doctorAdd.ep.SetError(_doctorAdd.cmbDoctorName, "Select a doctor or type new doctor name");
            if (_doctorAdd.txtDoctorName.Text == string.Empty && _doctorAdd.rbAddNewDoctor.Checked)
                _doctorAdd.ep.SetError(_doctorAdd.cmbDoctorName, "Type new doctor name");
            if (_doctorAdd.txtAddr1.Text == string.Empty)
                _doctorAdd.ep.SetError(_doctorAdd.txtAddr1, "Type Addr1");
            if (_doctorAdd.txtAddr2.Text == string.Empty)
                _doctorAdd.ep.SetError(_doctorAdd.txtAddr2, "Type Addr2");
            if (_doctorAdd.txtAddr3.Text == string.Empty)
                _doctorAdd.ep.SetError(_doctorAdd.txtAddr3, "Type Addr3");
            if (_doctorAdd.txtPostcode.Text == string.Empty)
                _doctorAdd.ep.SetError(_doctorAdd.txtPostcode, "Type Postcode");
            if (_doctorAdd.txtPhone.Text == string.Empty)
                _doctorAdd.ep.SetError(_doctorAdd.txtPhone, "Type Phone");

            bool failed = true;
            foreach (Control c in _doctorAdd.Controls)
            {
                if (_doctorAdd.ep.GetError(c).Length > 0)
                {
                    failed = false;
                    break;
                }

            }
            return failed;
        }
    }
}
