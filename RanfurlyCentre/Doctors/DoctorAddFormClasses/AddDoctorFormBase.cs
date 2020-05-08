using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyCentre
{
    public abstract class  AddDoctorFormBase
    {
        public abstract bool Validated();
        protected DoctorAdd _doctorAdd;

        public AddDoctorFormBase(DoctorAdd doctorAdd)
        {
            _doctorAdd = doctorAdd;
            _doctorAdd.cmbDoctorName.SelectedIndex = -1;
            _doctorAdd.txtDoctorName.Text = string.Empty;
            _doctorAdd.txtAddr1.Text = string.Empty;
            _doctorAdd.txtAddr2.Text = string.Empty;
            _doctorAdd.txtAddr3.Text = string.Empty;
            _doctorAdd.txtAddr4.Text = string.Empty;
            _doctorAdd.txtPostcode.Text = string.Empty;
            _doctorAdd.txtPhone.Text = string.Empty;
            _doctorAdd.txtEmail.Text = string.Empty;

            _doctorAdd.ep.Clear();
        }
    }
}
