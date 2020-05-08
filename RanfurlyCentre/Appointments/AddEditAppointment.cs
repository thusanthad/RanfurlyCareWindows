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
    public partial class AddEditAppointment : Form
    {
        public AppointmentBase _appointmentBase { get; set; }
        protected AppointmentClassBase _appointmentClassBase;
        public AddEditAppointment(AppointmentBase appointmentBase)
        {
            InitializeComponent();            
            _appointmentBase = appointmentBase;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddEditAppointment_Load(object sender, EventArgs e)
        {
            cmbAppointmentType.SelectedIndexChanged -= cmbAppointmentType_SelectedIndexChanged;
            cmbStaffAccompanyingId.SelectedIndexChanged -= cmbStaffAccompanyingId_SelectedIndexChanged;
            cmbResidentId.SelectedIndexChanged -= cmbResidentId_SelectedIndexChanged;
            cmbSpecialistId.SelectedIndexChanged -= cmbSpecialistId_SelectedIndexChanged;
            cmbKeyCode.SelectedIndexChanged -= cmbKeyCode_SelectedIndexChanged;

            PopulateCmboBoxes();

            txtPurpose.DataBindings.Add("Text", _appointmentBase, "Purpose");
            txtComments.DataBindings.Add("Text", _appointmentBase, "Comments");
            lstAmPm.DataBindings.Add("Text", _appointmentBase, "AmPm");
            lstHour.DataBindings.Add("Text", _appointmentBase, "AppointmentHour");
            lstMinute.DataBindings.Add("Text", _appointmentBase, "AppointmentMinute");
            chkIsFollowupNeeded.DataBindings.Add("Checked", _appointmentBase, "IsFollowupNeeded");
            chkIsInHouseAppointment.DataBindings.Add("Checked", _appointmentBase, "IsInHouseAppointment");

            if (_appointmentBase.AppointmentDate !=null && _appointmentBase.AppointmentDate != DateTime.MinValue)
                dtp.DataBindings.Add("Value", _appointmentBase, "AppointmentDate");
            //cmbKeyCode.DataBindings.Add("Text", _appointmentBase, "KeyCode");
            //cmbAppointmentType.DataBindings.Add("SelectedValue", _appointmentBase, "ProfessionalServiceProviderTypeId");

            SetAppointmentValues();
        }

        public void PopulateDoctors()
        {
            //cmbSpecialistId.SelectedIndexChanged -= cmbSpecialistId_SelectedIndexChanged;
            DoctorData dd = new DoctorData();
            List<Doctor> doctors = dd.GetList().ConvertAll(x => x as Doctor);
            cmbSpecialistId.DataSource = null;
            cmbSpecialistId.DataSource = doctors;
            cmbSpecialistId.ValueMember = "PersonId";
            cmbSpecialistId.DisplayMember = "FullName";
            cmbSpecialistId.Refresh();
            //cmbSpecialistId.SelectedIndex = -1;
            //cmbSpecialistId.SelectedIndexChanged += cmbSpecialistId_SelectedIndexChanged;
        }

        public void PopulateSpecialists()
        {
           // cmbSpecialistId.SelectedIndexChanged -= cmbSpecialistId_SelectedIndexChanged;
            string sql = "SELECT * FROM vw_ProfessionalServiceProviders WHERE ProfessionalServiceProviderTypeId = " + _appointmentBase.ProfessionalServiceProviderTypeId;// cmbAppointmentType.SelectedValue;
            SpecialistData sd = new SpecialistData();
            List<Specialist> specialists = sd.GetList(sql).ConvertAll(x => x as Specialist);
            cmbSpecialistId.DataSource = null;
            cmbSpecialistId.DataSource = specialists;
            cmbSpecialistId.ValueMember = "PersonId";
            cmbSpecialistId.DisplayMember = "FullName";
            cmbSpecialistId.Refresh();
            //cmbSpecialistId.SelectedIndex = -1;
            //cmbSpecialistId.SelectedIndexChanged += cmbSpecialistId_SelectedIndexChanged;
        }

        public void PopulateCmboBoxes()
        {
            try
            {
                SpecialistData sd = new SpecialistData();
                List<ProfessionalServiceType> list = sd.GetProfessionalServiceTypes();
                ProfessionalServiceType specialistType = new ProfessionalServiceType();

                cmbAppointmentType.DataSource = list;
                cmbAppointmentType.DisplayMember = "ProfessionalServiceProviderType";
                cmbAppointmentType.ValueMember = "ProfessionalServiceProviderTypeId";
                cmbAppointmentType.Refresh();

                StaffData staffData = new StaffData();
                List<Staff> staff = staffData.GetList().ConvertAll(x => x as Staff);
                cmbStaffAccompanyingId.DataSource = staff;
                cmbStaffAccompanyingId.ValueMember = "PersonId";
                cmbStaffAccompanyingId.DisplayMember = "FullName";
                cmbStaffAccompanyingId.Refresh();

                StudentData studentData = new StudentData();
                List<Student> students = studentData.GetList("SELECT * FROM vw_Residents").ConvertAll(x => x as Student);
                cmbResidentId.DataSource = students;
                cmbResidentId.ValueMember = "PersonId";
                cmbResidentId.DisplayMember = "FullName";
                cmbResidentId.Refresh();

                //cmbAppointmentType.SelectedIndex = -1;
                // cmbSpecialistId.SelectedIndex = -1;
                //cmbStaffAccompanyingId.SelectedIndex = -1;
                //cmbResidentId.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetAppointmentValues()
        {
            if (_appointmentBase is NewAppointment)
            {
                _appointmentClassBase = new NewAppointmentClass(this);//, appointmentBase);
            }
            else
            {
                if (_appointmentBase is DoctorAppointment)
                {
                    //this.cmbAppointmentType.SelectedItem = ((DoctorAppointment)appointmentBase).Doctor;
                    _appointmentClassBase = new DoctorAppointmentClass(this);//, appointmentBase);
                }
                else
                {
                    _appointmentClassBase = new SpecialistAppointmentClass(this);//, appointmentBase);
                }
            }
        }

        public void cmbAppointmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            AppointmentBase ap;
            if (cmbAppointmentType.SelectedIndex == 0)
            {
                ap = new DoctorAppointment();
                _appointmentClassBase = new NewDoctorAppointmentClass(this);
                
            }
            else
            {
                ap = new SpecialistAppointment();
                _appointmentBase.ProfessionalServiceProviderTypeId = (int)cmbAppointmentType.SelectedValue;
                _appointmentClassBase = new NewSpecialistAppointmentClass(this);
                
            }
            CommonFunctions.TransferPropertyValues(_appointmentBase, ap);
            _appointmentBase = ap;
            //_appointmentBase.ProfessionalServiceProviderTypeId = (int)cmbAppointmentType.SelectedValue;
        }

        public void cmbStaffAccompanyingId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbStaffAccompanyingId.SelectedIndex != -1)
            //    _appointmentBase.StaffAccompanying = (Staff)cmbStaffAccompanyingId.SelectedItem;
        }

        public void cmbResidentId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbResidentId.SelectedIndex != -1)
            //    _appointmentBase.Student = (Student)cmbResidentId.SelectedItem;
        }

        public void cmbSpecialistId_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbSpecialistId.SelectedIndex != -1 && _appointmentBase != null)
            //{
            //    if (_appointmentClassBase is DoctorAppointmentClass)
            //    {
            //        ((DoctorAppointment)_appointmentBase).Doctor = (Doctor)cmbSpecialistId.SelectedItem;
            //    }
            //    else
            //    {
            //        ((SpecialistAppointment)_appointmentBase).Specialist = (Specialist)cmbSpecialistId.SelectedItem;
            //    }
            //}
        }

        public void cmbKeyCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (cmbKeyCode.SelectedIndex != -1)
            //{
            //    ((DoctorAppointment)_appointmentBase).KeyCode = cmbKeyCode.Text;
            //}
        }

        private void lstHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            _appointmentBase.AppointmentHour = lstHour.Text.ToString();
        }

        private void lstMinute_SelectedIndexChanged(object sender, EventArgs e)
        {
            _appointmentBase.AppointmentMinute = lstMinute.Text.ToString();
        }

        private void lstAmPm_SelectedIndexChanged(object sender, EventArgs e)
        {
            _appointmentBase.AmPm = lstAmPm.Text.ToString();
        }

        private void dtp_ValueChanged(object sender, EventArgs e)
        {
            _appointmentBase.AppointmentDate = dtp.Value;
        }

        //private void AddEditAppointment_Shown(object sender, EventArgs e)
        //{
        //    cmbAppointmentType.SelectedIndexChanged += cmbAppointmentType_SelectedIndexChanged;
        //    cmbStaffAccompanyingId.SelectedIndexChanged += cmbStaffAccompanyingId_SelectedIndexChanged;
        //    cmbResidentId.SelectedIndexChanged += cmbResidentId_SelectedIndexChanged;
        //    cmbSpecialistId.SelectedIndexChanged += cmbSpecialistId_SelectedIndexChanged;
        //}

        private void cmbAddSpecialist_Click(object sender, EventArgs e)
        {
            if (_appointmentClassBase is DoctorAppointmentClass)
            {
                DoctorAddEdit dr = new DoctorAddEdit(new Doctor(), "Add");
                dr.ShowDialog();
                if (dr.DialogResult == DialogResult.OK)
                    PopulateDoctors();
            }
            else
            {
                ProfessionalAddEdit pr = new ProfessionalAddEdit(new Specialist(), "Add");
                pr.DefaultSelectedValue = (int)cmbAppointmentType.SelectedValue;
                pr.ShowDialog();
                if (pr.DialogResult == DialogResult.OK)
                    PopulateSpecialists();
            }
        }

        private void btnAddAppontment_Click(object sender, EventArgs e)
        {
            if (InputValidated())
            {
                try
                {

                    AppointmentBase newAp = GetAppointmentToUpdate();
                    newAp.Save();
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }                
        }

        private AppointmentBase GetAppointmentToUpdate()
        {
            _appointmentBase.AppointmentDate = dtp.Value;
            _appointmentBase.AmPm = lstAmPm.Text;
            _appointmentBase.AppointmentHour = lstHour.Text;
            _appointmentBase.AppointmentMinute = lstMinute.Text;
            _appointmentBase.Purpose = txtPurpose.Text;
            _appointmentBase.Comments = txtComments.Text;
            _appointmentBase.Student = (Student)cmbResidentId.SelectedItem;
            _appointmentBase.StaffAccompanying = (Staff)cmbStaffAccompanyingId.SelectedItem;
            _appointmentBase.IsFollowupNeeded = chkIsFollowupNeeded.Checked;
            _appointmentBase.IsInHouseAppointment = chkIsInHouseAppointment.Checked;
            _appointmentBase.IsFollowupNeeded = chkIsFollowupNeeded.Checked;
            _appointmentBase.ProfessionalServiceProviderTypeId = (int)cmbAppointmentType.SelectedValue;

            if (_appointmentBase is DoctorAppointment)
            {
                DoctorAppointment newAp = new DoctorAppointment();
                CommonFunctions.TransferPropertyValues(_appointmentBase, newAp);
                newAp.Doctor = (Doctor)cmbSpecialistId.SelectedItem;
                newAp.KeyCode = cmbKeyCode.Text;
                return newAp;
            }
            else
            {
                SpecialistAppointment newAp = new SpecialistAppointment();
                CommonFunctions.TransferPropertyValues(_appointmentBase, newAp);
                newAp.Specialist = (Specialist)cmbSpecialistId.SelectedItem;
                return newAp;
            }
        }

        private bool InputValidated()
        {
            int errors = 0;
            ep.Clear();        
            
            if(cmbAppointmentType.SelectedIndex==-1)
            {
                ep.SetError(cmbAppointmentType, "Select appointment type");
                errors += 1;
            }
            else
            {
                if ((int)cmbAppointmentType.SelectedValue == 1 && cmbKeyCode.SelectedIndex==-1)
                {
                    ep.SetError(cmbKeyCode, "Please select key code");
                    errors += 1;
                }
            }

            if (cmbSpecialistId.SelectedIndex == -1)
            {
                ep.SetError(cmbSpecialistId, "Select Specialist/Doctor");
                errors += 1;
            }
            if (cmbResidentId.SelectedIndex == -1)
            {
                ep.SetError(cmbResidentId, "Select Resident");
                errors += 1;
            }
            if (cmbStaffAccompanyingId.SelectedIndex == -1)
            {
                ep.SetError(cmbStaffAccompanyingId, "Select Staff");
                errors += 1;
            }
            if (!dtp.Checked)
            {
                ep.SetError(dtp, "Select appopintment date");
                errors += 1;
            }
            if (lstAmPm.SelectedIndex == -1)
            {
                ep.SetError(lstAmPm, "Please AM or PM");
                errors += 1;
            }
            if (lstHour.SelectedIndex == -1)
            {
                ep.SetError(lstHour, "Please select time");
                errors += 1;
            }
            if (txtPurpose.Text == string.Empty)
            {
                ep.SetError(txtPurpose, "Please type purpose");
                errors += 1;
            }

            return errors == 0;
        }

        private void AddEditAppointment_Shown(object sender, EventArgs e)
        {
            cmbAppointmentType.SelectedIndexChanged += cmbAppointmentType_SelectedIndexChanged;
            cmbStaffAccompanyingId.SelectedIndexChanged += cmbStaffAccompanyingId_SelectedIndexChanged;
            cmbResidentId.SelectedIndexChanged += cmbResidentId_SelectedIndexChanged;
            cmbSpecialistId.SelectedIndexChanged += cmbSpecialistId_SelectedIndexChanged;
            cmbKeyCode.SelectedIndexChanged += cmbKeyCode_SelectedIndexChanged;
        }
    }
}
