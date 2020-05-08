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
    public partial class StudentAdd : Form
    {
        public MDIMainForm _mdiForm { get; set; }
        protected Student _student;
        protected Student _originalStudent;
        protected Address _address;

        public StudentAdd(MDIMainForm mdiform)
        {
            InitializeComponent();
            _mdiForm = mdiform;
            _student = new Student();
            _address = new Address();
            _student.Addresses.Add(_address);
        }

        private void StudentEdit_Load(object sender, EventArgs e)
        {
            txtPreferredName.DataBindings.Add("Text", _student, "PreferredName");
            txtFirstName.DataBindings.Add("Text", _student, "FirstName");
            txtMiddleName.DataBindings.Add("Text", _student, "MiddleName");
            txtLastName.DataBindings.Add("Text", _student, "LastName");
            txtHomePhone.DataBindings.Add("Text", _student, "HomePhone");
            txtMobilePhone.DataBindings.Add("Text", _student, "MobilePhone");
            
            chkAttendsActivityCentre.DataBindings.Add("Checked", _student, "AttendsActivityCentre");
            txtNHINumber.DataBindings.Add("Text", _student, "NHINumber");
            txtMobilityCardNumber.DataBindings.Add("Text", _student, "MobilityCardNumber");
            txtIRDNumber.DataBindings.Add("Text", _student, "IRDNumber");
            txtWINZNumber.DataBindings.Add("Text", _student, "WINZNumber");

            txtAddr1.DataBindings.Add("Text", _address, "Addr1");
            txtAddr2.DataBindings.Add("Text", _address, "Addr2");
            txtAddr3.DataBindings.Add("Text", _address, "Addr3");
            txtAddr4.DataBindings.Add("Text", _address, "Addr4");
            txtPostcode.DataBindings.Add("Text", _address, "Postcode");

            dtpDateOfBirth.Checked = false;
            dtpDateOfAdmissionToActivityCentre.Checked = false;
            dtpDateOfAdmissionToResidence.Checked = false;

           // dtpDateOfBirth.DataBindings.Add("Value", _student, "DateOfBirth");
            dtpDateOfBirth.Format = DateTimePickerFormat.Custom;
            dtpDateOfBirth.CustomFormat = "dd MMMM yyyy";

            //dtpDateOfAdmissionToActivityCentre.DataBindings.Add("Value", _student, "DateOfAdmissionToActivityCentre");
            dtpDateOfAdmissionToActivityCentre.Format = DateTimePickerFormat.Custom;
            dtpDateOfAdmissionToActivityCentre.CustomFormat = "dd MMMM yyyy";

            //dtpDateOfAdmissionToResidence.DataBindings.Add("Value", _student, "DateOfAdmissionToResidence");
            dtpDateOfAdmissionToResidence.Format = DateTimePickerFormat.Custom;
            dtpDateOfAdmissionToResidence.CustomFormat = "dd MMMM yyyy";
        }

        private void PopulateDoctors()
        {
            doctorGridView1.AutoGenerateColumns = false;
            doctorGridView1.DataSource = _student.Doctors.ConvertAll(c => c as Doctor);
            doctorGridView1.Refresh();
        }

        private void PopulateNextOfKin()
        {
            nextOfKinGridView1.AutoGenerateColumns = false;
            nextOfKinGridView1.DataSource = _student.NextOfKin.ConvertAll(c => c as NextOfKin); ;
            nextOfKinGridView1.Refresh();
        }

        private void PopulateMedication()
        {
            dgMedicalCondition.AutoGenerateColumns = false;
            dgMedicalCondition.DataSource = _student.MedicalConditions;
            dgMedicalCondition.Refresh();
        }

        private void PopulateEmergencyContacts()
        {
            dgEmergencyContacts.AutoGenerateColumns = false;
            dgEmergencyContacts.DataSource = _student.EmergencyContacts;
            dgEmergencyContacts.Refresh();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
           // CommonFunctions.CheckIfPropertyVluesHaveChanged(_originalPerson, _person);
            this.Close();
        }

        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            _student.DateOfBirth = dtpDateOfBirth.Value;
        }

        private void addDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DoctorAdd ad = new DoctorAdd(_student);
            //ad.ShowDialog();
            //if (ad.DialogResult == DialogResult.OK)
            //{
            //    DataBase db = new DoctorData();
            //    _student.Doctors = db.GetList(_student.PersonId);
            //    PopulateDoctors();
            //}
        }

        private void removeDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int rowindex = doctorGridView1.CurrentCell.RowIndex;
            int doctorid = (int)doctorGridView1.Rows[rowindex].Cells[0].Value;
            Person doctor = _student.Doctors.Find(x => x.PersonId == doctorid);
            if (doctor != null)
            {
                if (MessageBox.Show("Are you sure you want to remove doctor '" + doctor.FullName + "' from this student?", "Remove Doctor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataBase db = new DoctorData();
                    db.Remove(doctor, _student.PersonId);
                    _student.Doctors = db.GetList(_student.PersonId);
                    PopulateDoctors();
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }
    }
}
