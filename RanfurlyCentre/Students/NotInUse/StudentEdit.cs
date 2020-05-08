using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RanfurlyBusiness;
using DataAccess;

namespace RanfurlyCentre
{
    public partial class StudentEdit : Form
    {
        protected Student _student;
        protected Student _originalStudent;
        protected Address _address;
        public bool _changedOccured;
        protected FormInitialiserBase fi;
        protected DataBase db;

        public StudentEdit(Person person)
        {
            InitializeComponent();
            _student = (Student)person;
            _originalStudent = (Student)person;
            //if (_student.Addresses.Count > 0)
            //    _address = _student.Addresses[0];
            //else
            //    _address = new Address();

            //db = new StudenData();
        }

        private void StudentEdit_Load(object sender, EventArgs e)
        {
            //FormInitialiserBase fi = new StudentEditIntialiser(this);
            txtStudentId.DataBindings.Add("Text", _student, "PersonId");
            txtPreferredName.DataBindings.Add("Text", _student, "PreferredName");
            txtFirstName.DataBindings.Add("Text", _student, "FirstName");
            txtMiddleName.DataBindings.Add("Text", _student, "MiddleName");
            txtLastName.DataBindings.Add("Text", _student, "LastName");
            txtHomePhone.DataBindings.Add("Text", _student, "HomePhone");
            txtMobilePhone.DataBindings.Add("Text", _student, "MobilePhone");
            chkIsResident.DataBindings.Add("Checked", _student, "IsResident");
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

            if (_student.Gender == "Male")
                rbMale.Checked = true;
            else
                rbFemale.Checked = true;

            if (_student.DateOfBirth!= DateTime.MinValue && _student.DateOfBirth.HasValue)
            {
                dtpDateOfBirth.Checked = true;
                dtpDateOfBirth.DataBindings.Add("Value", _student, "DateOfBirth");
                dtpDateOfBirth.Format = DateTimePickerFormat.Custom;
                dtpDateOfBirth.CustomFormat = "dd MMMM yyyy";
            }

            if (_student.DateOfAdmissionToActivityCentre != DateTime.MinValue && _student.DateOfAdmissionToActivityCentre.HasValue)
            {
                dtpDateOfAdmissionToActivityCentre.Checked = true;
                dtpDateOfAdmissionToActivityCentre.DataBindings.Add("Value", _student, "DateOfAdmissionToActivityCentre");
                dtpDateOfAdmissionToActivityCentre.Format = DateTimePickerFormat.Custom;
                dtpDateOfAdmissionToActivityCentre.CustomFormat = "dd MMMM yyyy";
            }

            if (_student.DateOfAdmissionToResidence != DateTime.MinValue && _student.DateOfAdmissionToResidence.HasValue)
            {
                dtpDateOfAdmissionToResidence.Checked = true;
                dtpDateOfAdmissionToResidence.DataBindings.Add("Value", _student, "DateOfAdmissionToResidence");
                dtpDateOfAdmissionToResidence.Format = DateTimePickerFormat.Custom;
                dtpDateOfAdmissionToResidence.CustomFormat = "dd MMMM yyyy";
            }

            PopulateDoctors();
            PopulateNextOfKin();
            PopulateMedication();
            PopulateEmergencyContacts();
            PopulateStaff();
            PopulateEthnicity();

            //cmbEthnicity.DataBindings.Add("SelectedValue", _student, "EthnicityId");
        }

        private void PopulateDoctors()
        {
            //db = new DoctorData();
            //_student.Doctors = db.GetList(_student.PersonId);
            //doctorGridView1.AutoGenerateColumns = false;
            //doctorGridView1.DataSource = _student.Doctors;// _student.Doctors.ConvertAll(c => c as Doctor);
            //doctorGridView1.Refresh();
        }

        private void PopulateNextOfKin()
        {
            db = new NextOfKinData();           
            _student.NextOfKin = db.GetList(_student.PersonId).ConvertAll(c => c as NextOfKin);
            nextOfKinGridView1.AutoGenerateColumns = false;
            nextOfKinGridView1.DataSource = _student.NextOfKin;// _student.NextOfKin;//.ConvertAll(c => c as NextOfKin); ;
            nextOfKinGridView1.Refresh();
        }

        private void PopulateMedication()
        {
            MedicalConditionData md = new MedicalConditionData();
            _student.MedicalConditions = md.GetList(_student.PersonId);
            dgMedicalCondition.AutoGenerateColumns = false;
            dgMedicalCondition.DataSource = _student.MedicalConditions;
            dgMedicalCondition.Refresh();
        }

        private void PopulateStaff()
        {
            DataBase db = new StaffData();
            List<Staff> list = db.GetList().ConvertAll(x => x as Staff);
            List<Staff> list1 = db.GetList().ConvertAll(x => x as Staff);

            Staff staff = new Staff();
            staff.FullAddress = string.Empty;
            staff.PersonId = 0;

            list.Insert(0, staff);
            list1.Insert(0, staff);

            cmbActivityCentreCoach.DataSource = list;
            cmbResidentCoach.DataSource = list1;

            cmbActivityCentreCoach.DisplayMember = "FullName";
            cmbActivityCentreCoach.ValueMember = "PersonId";

            cmbResidentCoach.DisplayMember = "FullName";
            cmbResidentCoach.ValueMember = "PersonId";

            cmbActivityCentreCoach.DataBindings.Add("SelectedValue", _student, "ActivityCentreCoachId");
            cmbResidentCoach.DataBindings.Add("SelectedValue", _student, "ResidentCoachId");

        }

        private void PopulateEmergencyContacts()
        {
            db = new EmergencyContactData();
            _student.EmergencyContacts = db.GetList(_student.PersonId).ConvertAll(x=>x as EmergencyContact);
            dgEmergencyContacts.AutoGenerateColumns = false;
            dgEmergencyContacts.DataSource = _student.EmergencyContacts;
            dgEmergencyContacts.Refresh();
        }

        public void PopulateEthnicity()
        {
            EthnicityData et = new EthnicityData();
            cmbEthnicity.DataSource = null;
            cmbEthnicity.DataSource = et.GetList();
            cmbEthnicity.ValueMember = "EthnicityId";
            cmbEthnicity.DisplayMember = "EthnicityName";
            cmbEthnicity.DataBindings.Clear();
            cmbEthnicity.DataBindings.Add("SelectedValue", _student, "EthnicityId");            
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
            ////DoctorAdd ad = new DoctorAdd(new AddDoctorToExistingStudent(_student));
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
            //int rowindex = doctorGridView1.CurrentCell.RowIndex;
            //int doctorid = (int)doctorGridView1.Rows[rowindex].Cells[0].Value;
            //Person doctor = _student.Doctors.Find(x => x.PersonId == doctorid);
            //if (doctor != null)
            //{
            //    if (MessageBox.Show("Are you sure you want to remove doctor '" + doctor.FullName + "' from this student?", "Remove Doctor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //    {
            //        DataBase db = new DoctorData();
            //        db.Remove(doctor, _student.PersonId);
            //        _student.Doctors = db.GetList(_student.PersonId);
            //        PopulateDoctors();
            //    }
            //}
        }

        private void addNextOfKin_Click(object sender, EventArgs e)
        {
            ////AddNextOfKin ad = new AddNextOfKin(_student);
            //NextOfKinAdd ad = new NextOfKinAdd(new AddNextOfKinToExistingStudent(_student));
            //ad.ShowDialog();
            //if (ad.DialogResult == DialogResult.OK)
            //{
            //    DataBase db = new NextOfKinData();
            //    _student.NextOfKin = db.GetList(_student.PersonId).ConvertAll(x=>x as NextOfKin);
            //    PopulateNextOfKin();
            //}
        }

        private void removeNextOfKin_Click(object sender, EventArgs e)
        {
            int rowindex = nextOfKinGridView1.CurrentCell.RowIndex;
            int nextOfKinId = (int)nextOfKinGridView1.Rows[rowindex].Cells[0].Value;
            Person nextOfKin = _student.NextOfKin.Find(x => x.PersonId == nextOfKinId);
            if (nextOfKin != null)
            {
                if (MessageBox.Show("Are you sure you want to remove Next of kin '" + nextOfKin.FullName + "' from this student?", "Remove Doctor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataBase db = new NextOfKinData();
                    db.Remove(nextOfKin, _student.PersonId);
                    _student.Doctors = db.GetList(_student.PersonId);
                    PopulateNextOfKin();
                }
            }
        }

        private void StudentEdit_Shown(object sender, EventArgs e)
        {
            fi = new StudentEditIntialiser(this);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_changedOccured && InputValidated() )
            {
                try
                {
                    //if (txtPreferredName.Text == string.Empty)
                    //    _student.PreferredName = _student.FirstName;
                    if (cmbEthnicity.SelectedIndex != -1)
                        _student.Ethnicity = cmbEthnicity.Text;
                    if (!dtpDateOfAdmissionToResidence.Checked)
                    {
                        _student.IsResident = false;
                        _student.DateOfAdmissionToResidence = null;
                    }

                    SaveChanges();
                    _changedOccured = false;
                    MessageBox.Show("Student record saved", "Save record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
                
        }

        private bool InputValidated()
        {
            ep.Clear();
            if (rbFemale.Checked)
                _student.Gender = "Female";
            else
                _student.Gender = "Male";

            if (txtFirstName.Text == string.Empty)
                ep.SetError(txtFirstName, "Type First Name");
            if (txtLastName.Text == string.Empty)
                ep.SetError(txtLastName, "Type Last Name");

            if (!dtpDateOfBirth.Checked)
                ep.SetError(dtpDateOfBirth, "Select Date of Birth");

            if (!dtpDateOfAdmissionToActivityCentre.Checked)
                ep.SetError(dtpDateOfAdmissionToActivityCentre, "Select Date of admission to Activity centre");

            if (cmbEthnicity.SelectedIndex == -1)
                ep.SetError(cmbEthnicity, "Select Ethnicity");

            if (txtAddr1.Text == string.Empty)
                ep.SetError(txtAddr1, "Type Addr 1");
            if (txtAddr2.Text == string.Empty)
                ep.SetError(txtAddr2, "Type Addr 2");
            if (txtAddr3.Text == string.Empty)
                ep.SetError(txtAddr3, "Type Addr 3");
            if (txtPostcode.Text == string.Empty)
                ep.SetError(txtPostcode, "Type Postcode");

            return !fi.EPHasErrors();
            //if (fi.EPHasErrors())
            //    return;
        }

        private void SaveChanges()
        {
            //StudentData sd = new StudentData(DBCommand.TransactionType.WithTransaction);
            //sd.Update(_student);
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dtpDateOfAdmissionToResidence_ValueChanged(object sender, EventArgs e)
        {
            chkIsResident.Checked = dtpDateOfAdmissionToResidence.Checked;
        }

        private void AddEmergencyContact_Click(object sender, EventArgs e)
        {
            //EmergencyContactAdd ad = new EmergencyContactAdd(_student,"edit");
            //ad.ShowDialog();
            //if (ad.DialogResult == DialogResult.OK)
            //{
            //    DataBase db = new EmergencyContactData();
            //    _student.EmergencyContacts = db.GetList(_student.PersonId).ConvertAll(x=>x as EmergencyContact);
            //    PopulateEmergencyContacts();
            //}
        }

        private void RemoveEmergencyContact_Click(object sender, EventArgs e)
        {
            int rowindex = dgEmergencyContacts.CurrentCell.RowIndex;
            int studentEmergencyContactId = (int)dgEmergencyContacts.Rows[rowindex].Cells[0].Value;
            EmergencyContact ec = _student.EmergencyContacts.Find(x => x.StudentEmergencyContactId == studentEmergencyContactId);
            if (ec != null)
            {
                if (MessageBox.Show("Are you sure you want to remove emergency contact '" + ec.FullName + "' from this student?", "Remove Emergency Contact", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DataBase db = new EmergencyContactData();
                    db.Remove(new Person(), studentEmergencyContactId);
                    _student.EmergencyContacts= db.GetList(_student.PersonId).ConvertAll(x=>x as EmergencyContact);
                    PopulateEmergencyContacts();
                }
            }
        }

        private void StudentEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_changedOccured)
            {
                if (MessageBox.Show("Do you want to save changes?", "Save changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SaveChanges();
                }
                else
                {
                    StudentSearch frm1 = (StudentSearch)Application.OpenForms["StudentSearch"];
                    frm1.LoadStudentList();
                    frm1.SetDataSource();
                }
            }
        }
    }
}
