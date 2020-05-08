using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public partial class StudentEdit : Form
    {
        protected Person _person;
        protected Person _originalPerson;

        public StudentEdit(Person person)
        {
            InitializeComponent();
            _person = person;
            _originalPerson = person;
        }

        private void StudentEdit_Load(object sender, EventArgs e)
        {
            txtPreferredName.DataBindings.Add("Text", _person, "PreferredName");
            txtFirstName.DataBindings.Add("Text", _person, "FirstName");
            txtMiddleName.DataBindings.Add("Text", _person, "MiddleName");
            txtLastName.DataBindings.Add("Text", _person, "LastName");
            txtHomePhone.DataBindings.Add("Text", _person, "HomePhone");
            txtMobilePhone.DataBindings.Add("Text", _person, "MobilePhone");
            chkIsResident.DataBindings.Add("Checked", _person, "IsResident");
            if (_person.Gender == "Male")
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            if (_person.DateOfBirth != null)
            {
                try
                {
                    DateTime dob;
                    if (DateTime.TryParse(_person.DateOfBirth.ToString(), out dob))
                    {
                        dtpDateOfBirth.DataBindings.Add("Value", _person, "DateOfBirth");
                    }    
                }
                catch { }
            }

            doctorGridView1.AutoGenerateColumns = false;
            doctorGridView1.DataSource = _person.Doctors;
            doctorGridView1.Refresh();

            nextOfKinGridView1.AutoGenerateColumns = false;
            nextOfKinGridView1.DataSource = _person.NextOfKin;
            nextOfKinGridView1.Refresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           // CommonFunctions.CheckIfPropertyVluesHaveChanged(_originalPerson, _person);
            this.Close();
        }

        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            _person.DateOfBirth = dtpDateOfBirth.Value;
        }

        //private void txtPreferredName_Validated(object sender, EventArgs e)
        //{

        //}
    }
}
