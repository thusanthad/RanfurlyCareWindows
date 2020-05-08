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
    public partial class DoctorAssign : Form
    {
        protected Student _student;// { get; set; }
        protected Doctor _selectedDoctor;
        //protected AddDoctorFormBase _adf;
        //protected StudentAddEditBaseClass _staebc;

       
        public DoctorAssign(Student student)
        {
            InitializeComponent();
            //_staebc = staebc;
            _student = student;
            //_adf = new AssignDoctorForm(this);
        }

        private void AddDoctor_Load(object sender, EventArgs e)
        {
            PopulateDoctors();
            //cmbDoctorName.DroppedDown = true;                
        }

        public void PopulateDoctors()
        {
            cmbDoctorName.DisplayMember = "FullName";
            //cmbDoctorName.ValueMember = "PersonId";
            DataBase db = new DoctorData();
            List<Doctor> list = db.GetList().ConvertAll(x => x as Doctor);
            BindingSource bs = new BindingSource();
            List < Doctor > otherDoctors = GetOtherDoctors(list, _student.Doctors.ConvertAll(x => x as Doctor));
            bs.DataSource = otherDoctors;
            cmbDoctorName.DataSource = bs;
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
            ep.Clear();
            try
            {
                if (cmbDoctorName.SelectedIndex != -1)
                {
                    _selectedDoctor = (Doctor)cmbDoctorName.SelectedValue;
                    _student.Doctors.Add(_selectedDoctor);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ep.SetError(cmbDoctorName, "Select a doctor to assign");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoctorAddEdit dae = new DoctorAddEdit(new Doctor(), "Add");
            dae.ShowDialog();
            if (dae.DialogResult == DialogResult.OK)
            {
                _student.Doctors.Add(dae.Doctor);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        
    }
}
