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
    public partial class DoctorAdd_Copy : Form
    {
        protected Student _student;// { get; set; }
        //protected AddDoctorToStudentBase _astb;
        protected Doctor _selectedDoctor;
        //protected AddDoctorFormBase _adf;
        protected StudentAddEditBaseClass _staebc;

        //public DoctorAdd()
        //{
        //    InitializeComponent();
        //}

        //public DoctorAdd(Student student)
        //{
        //    InitializeComponent();
        //    //_student = student;
        //    _student = _astb.Student;
        //}

        //public DoctorAdd(AddDoctorToStudentBase addDoctorToStudentBase)
        //{
        //    InitializeComponent();
        //    //_astb = addDoctorToStudentBase;
        //    //_student = _astb.Student;
        //    //_adf = new AssignDoctorForm(this);
        //}

        public DoctorAdd_Copy(StudentAddEditBaseClass staebc)
        {
            InitializeComponent();
            _staebc = staebc;
            _student = _staebc.Student;
            //_adf = new AssignDoctorForm(this);
        }

        private void AddDoctor_Load(object sender, EventArgs e)
        {
            cmbDoctorName.SelectedIndexChanged -= cmbFullName_SelectedIndexChanged;
            PopulateDoctors();
            cmbDoctorName.SelectedIndexChanged += cmbFullName_SelectedIndexChanged;
        }

        private void PopulateDoctors()
        {
            cmbDoctorName.DisplayMember = "FullName";
            cmbDoctorName.ValueMember = "DoctorId";
            DataBase db = new DoctorData();
            List<Doctor> list = db.GetList().ConvertAll(x => x as Doctor);
            List<Doctor> doctors = list.Except(_student.Doctors.ConvertAll(x => x as Doctor)).ToList();
            cmbDoctorName.DataSource = GetOtherDoctors(list, _student.Doctors.ConvertAll(x => x as Doctor));// db.GetList();            
            cmbDoctorName.DataSource = list;
            cmbDoctorName.SelectedIndex = -1;
            cmbDoctorName.Refresh();
        }

        private List<Doctor> GetOtherDoctors(List<Doctor> doctors, List<Doctor> studentDoctors)
        {
            foreach (Doctor dr1 in studentDoctors)
            {
                Doctor doctor = doctors.Find(x => x.PersonId == dr1.PersonId);
                if (doctor != null)
                    doctors.Remove(doctor);
            }
            return doctors;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (_adf.Validated())
                //if (InputValidated())
                {
                    try
                    {
                        //DataBase db = new DoctorData();
                        if (_selectedDoctor == null) // add doctor and assign to student
                        {
                            Person doctor = new Doctor
                            {
                                FullName = txtDoctorName.Text,
                                Addr1 = txtAddr1.Text,
                                Addr2 = txtAddr2.Text,
                                Addr3 = txtAddr3.Text,
                                Addr4 = txtAddr4.Text,
                                Postcode = txtPostcode.Text,
                                Phone = txtPhone.Text,
                                Email = txtEmail.Text
                            };
                        doctor.FullAddress = doctor.GetFullAddress();
                        _staebc.Add(doctor);

                        // _astb.AddDoctor((Doctor)doctor);

                        //int doctorId = db.Add(doctor, _student.PersonId);
                        //doctor.PersonId = doctorId;
                    }
                        else // add doctor to student
                        {
                        // db.Allocate(_selectedDoctor, _student.PersonId);
                        // _astb.AllocateDoctor(_selectedDoctor);
                        _staebc.Add(_selectedDoctor);

                        }
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            }
        }

        private bool InputValidated()
        {
            ep.Clear();
            if (cmbDoctorName.Text == string.Empty && rbAllocateFromList.Checked)
                ep.SetError(cmbDoctorName, "Select a doctor from list");
            if (txtDoctorName.Text == string.Empty && rbAddNewDoctor.Checked)
                ep.SetError(cmbDoctorName, "Type new doctor name");
            if (txtAddr1.Text == string.Empty)
                ep.SetError(txtAddr1, "Type Addr1");
            if (txtAddr2.Text == string.Empty)
                ep.SetError(txtAddr2, "Type Addr2");
            if (txtAddr3.Text == string.Empty)
                ep.SetError(txtAddr3, "Type Addr3");
            if (txtPostcode.Text == string.Empty)
                ep.SetError(txtPostcode, "Type Postcode");
            if (txtPhone.Text == string.Empty)
                ep.SetError(txtPhone, "Type Phone");

            bool failed = true;
            foreach (Control c in this.Controls)
            {
                if (ep.GetError(c).Length > 0)
                {
                    failed = false;
                    break;
                }  
            }
            return failed;
        }

        private void cmbFullName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ep.Clear();
                if (cmbDoctorName.SelectedIndex >= 0)
                {
                    _selectedDoctor = (Doctor)cmbDoctorName.SelectedValue;
                    txtAddr1.Text = _selectedDoctor.Addr1;
                    txtAddr2.Text = _selectedDoctor.Addr2;
                    txtAddr3.Text = _selectedDoctor.Addr3;
                    txtAddr4.Text = _selectedDoctor.Addr4;
                    txtPostcode.Text = _selectedDoctor.Postcode;
                    txtPhone.Text = _selectedDoctor.Phone;
                    txtEmail.Text = _selectedDoctor.Email;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbAllocateFromList_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAllocateFromList.Checked)
            {
                //SelectOption();
                //cmbDoctorName.Focus();
               // _adf = new AssignDoctorForm(this);
            }
        }

        private void rbAddNewDoctor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAddNewDoctor.Checked)
            {
                //SelectOption();
                //txtDoctorName.Focus();
                //_adf = new AddDoctorForm(this);
            }
        }

        private void SelectOption()
        {
            ep.Clear();
            if (rbAllocateFromList.Checked)
            {
                cmbDoctorName.Visible = true;
                txtDoctorName.Visible = false;
            }
            else
            {
                cmbDoctorName.Visible = false;
                txtDoctorName.Visible = true;
            }

            cmbDoctorName.SelectedIndex = -1;
            txtDoctorName.Text = string.Empty;
            txtAddr1.Text = string.Empty;
            txtAddr2.Text = string.Empty;
            txtAddr3.Text = string.Empty;
            txtAddr4.Text = string.Empty;
            txtPostcode.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtEmail.Text = string.Empty;
        }

    }
}
