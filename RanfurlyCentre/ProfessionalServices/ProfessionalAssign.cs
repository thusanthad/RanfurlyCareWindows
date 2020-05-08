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
    public partial class ProfessionalAssign : Form
    {
        protected Student _student;// { get; set; }
        protected Specialist _selectedSpecialiast;
        //protected AddDoctorFormBase _adf;
        //protected StudentAddEditBaseClass _staebc;

       
        public ProfessionalAssign(Student student)
        {
            InitializeComponent();
            //_staebc = staebc;
            _student = student;
            //_adf = new AssignDoctorForm(this);
        }

        private void AddDoctor_Load(object sender, EventArgs e)
        {
            PopulateSpecialsist();
            //cmbDoctorName.DroppedDown = true;                
        }

        public void PopulateSpecialsist()
        {
            cmbDoctorName.DisplayMember = "DisplayName";
            //cmbDoctorName.ValueMember = "PersonId";
            DataBase db = new SpecialistData();
            List<Specialist> list = db.GetList().ConvertAll(x => x as Specialist);
            BindingSource bs = new BindingSource();
            List <Specialist> otherSpecialists = GetOtherDoctors(list, _student.ProfessionalServiceProviders.ConvertAll(x => x as Specialist));
            bs.DataSource = otherSpecialists;
            cmbDoctorName.DataSource = bs;
            cmbDoctorName.SelectedIndex = -1;
            cmbDoctorName.Refresh();
        }

        private List<Specialist> GetOtherDoctors(List<Specialist> specialists, List<Specialist> studentDoctors)
        {
            foreach (Specialist dr1 in studentDoctors)
            {
                Specialist doctor = specialists.Find(x => x.PersonId == dr1.PersonId);
                if (doctor != null)
                    specialists.Remove(doctor);
            }
            return specialists;
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
                    _selectedSpecialiast = (Specialist)cmbDoctorName.SelectedValue;
                    _student.ProfessionalServiceProviders.Add(_selectedSpecialiast);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    ep.SetError(cmbDoctorName, "Select a specialist to assign");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void addDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProfessionalAddEdit dae = new ProfessionalAddEdit(new Specialist(), "Add");
            dae.ShowDialog();
            if (dae.DialogResult == DialogResult.OK)
            {
                _student.ProfessionalServiceProviders.Add(dae.Specialist);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        
    }
}
