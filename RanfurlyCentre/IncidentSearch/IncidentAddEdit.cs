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
    public partial class IncidentAddEdit : Form
    {
        protected Incident _incident;
        protected Jarvis _jarvis;
        protected IncidentAddEditBase _incidentAddEditBase;
        protected IncidentTypeBase incidentTypeBase;
        public IncidentAddEdit(Incident incident, Jarvis jarvis)
        {
            InitializeComponent();
            _incident = incident;
            _jarvis = jarvis;
            if(_incident.IncidentId==0)
            {
                _incidentAddEditBase = new IncidentAdd(_incident);
                //cmbStaff.Enabled = false;
                rbStudent.Checked = true;
                _incident.IncidentDate = DateTime.Today;
                //incidentTypeBase = new StudentType(this);
            }
            else
            {
                _incidentAddEditBase = new IncidentUpdate(_incident);
                btnAddIncident.Text = "Update Incident";
                Text = "Update Incident";
                headerLabel.Text= "Update Incident";
            }
        }

        private void AddEditIncident_Load(object sender, EventArgs e)
        {
            cmbStaff.SelectedIndexChanged -= cmbStaff_SelectedIndexChanged;
            cmbStudent.SelectedIndexChanged -= cmbStudent_SelectedIndexChanged;
            cmbLocation.SelectedIndexChanged -= cmbLocation_SelectedIndexChanged;
            cmbWhoReported.SelectedIndexChanged -= cmbWhoReported_SelectedIndexChanged;
            cmbCoordinator.SelectedIndexChanged -= cmbCoordinator_SelectedIndexChanged;
            cmbManager.SelectedIndexChanged -= cmbManager_SelectedIndexChanged;
            cmbHSOfficer.SelectedIndexChanged -= cmbHSOfficer_SelectedIndexChanged;

            PopulateComboBoxes();
            //PopulateStaff();
            //PopulateStudents();

            cmbStaff.SelectedIndexChanged += cmbStaff_SelectedIndexChanged;
            cmbStudent.SelectedIndexChanged += cmbStudent_SelectedIndexChanged;
            cmbLocation.SelectedIndexChanged += cmbLocation_SelectedIndexChanged;
            cmbWhoReported.SelectedIndexChanged += cmbWhoReported_SelectedIndexChanged;
            cmbCoordinator.SelectedIndexChanged += cmbCoordinator_SelectedIndexChanged;
            cmbManager.SelectedIndexChanged += cmbManager_SelectedIndexChanged;
            cmbHSOfficer.SelectedIndexChanged += cmbHSOfficer_SelectedIndexChanged;


            txtDescription.DataBindings.Add("Text", _incident, "Description");
            dtp.DataBindings.Add("Value", _incident, "IncidentDate");
            txtPersonFullName.DataBindings.Add("Text", _incident, "PersonFullName");
            lstHour.DataBindings.Add("Text", _incident, "IncidentHour");
            lstMinute.DataBindings.Add("Text", _incident, "IncidentMinute");
            lstAmPm.DataBindings.Add("Text", _incident, "AmPm");
            txtFileLocation.DataBindings.Add("Text", _incident, "FileLocation");
            txtFileName.DataBindings.Add("Text", _incident, "FileName");
            txtComments.DataBindings.Add("Text", _incident, "Comments");
            cmbWhoReported.DataBindings.Add("SelectedValue", _incident.WhoReported, "PersonId");
            cmbManager.DataBindings.Add("SelectedValue", _incident.Manager, "PersonId");
            cmbCoordinator.DataBindings.Add("SelectedValue", _incident.Coordinator, "PersonId");
            cmbHSOfficer.DataBindings.Add("SelectedValue", _incident.HealthAnSafetyOfficer, "PersonId");
            cmbLocation.DataBindings.Add("SelectedValue", _incident.Location, "LocationId");

            if (_incident.Student !=null)
                cmbStudent.DataBindings.Add("SelectedValue", _incident.Student, "PersonId");
            if (_incident.Staff != null)
                cmbStaff.DataBindings.Add("SelectedValue", _incident.Staff, "PersonId");


            SetIncidentType();

        }

        private void SetIncidentType()
        {
            if (_incident.Staff != null && _incident.Student != null)
                rbStaffAndStudent.Checked = true;
            else if (_incident.Staff != null)
                rbStaff.Checked = true;
            else if (_incident.Student != null || _incident.IncidentId == 0)
                rbStudent.Checked = true;
            else
                rbOther.Checked = true;
        }




        private void PopulateComboBoxes()
        {
            DataBase db;
            db = new StaffData();
            List<Staff> list = db.GetList().ConvertAll(x => x as Staff);
            cmbStaff.DataSource = list;
            cmbStaff.DisplayMember = "FullName";
            cmbStaff.ValueMember = "PersonId";
            cmbStaff.SelectedIndex = -1;

            List<Staff> whoReported = new List<Staff>();
            List<Staff> coordinators = db.GetList("SELECT * FROM vw_Staff Where TitleId ="+3).ConvertAll(x => x as Staff);
            List<Staff> managers = db.GetList("SELECT * FROM vw_Staff Where TitleId =" + 4).ConvertAll(x => x as Staff);
            List<Staff> hsOfficers = db.GetList("SELECT * FROM vw_Staff Where TitleId = " + 6).ConvertAll(x => x as Staff);

            whoReported.AddRange(list);           

            cmbWhoReported.DataSource = whoReported;
            cmbWhoReported.DisplayMember = "FullName";
            cmbWhoReported.ValueMember = "PersonId";
            cmbWhoReported.SelectedIndex = -1;

            cmbCoordinator.DataSource = coordinators;
            cmbCoordinator.DisplayMember = "FullName";
            cmbCoordinator.ValueMember = "PersonId";
            cmbCoordinator.SelectedIndex = -1;

            cmbManager.DataSource = managers;
            cmbManager.DisplayMember = "FullName";
            cmbManager.ValueMember = "PersonId";
            cmbManager.SelectedIndex = -1;

            cmbHSOfficer.DataSource = hsOfficers;
            cmbHSOfficer.DisplayMember = "FullName";
            cmbHSOfficer.ValueMember = "PersonId";
            cmbHSOfficer.SelectedIndex = -1;

            db = new StudentData();
            List<Student> list5 = db.GetList().ConvertAll(x => x as Student);
            cmbStudent.DataSource = list5;
            cmbStudent.DisplayMember = "FullName";
            cmbStudent.ValueMember = "PersonId";
            cmbStudent.SelectedIndex = -1;

            LocationData ld= new LocationData();
            List<Location> list6 = ld.GetList("SELECT * FROM vw_Locations WHERE IsStudentCentre = true");
            cmbLocation.DataSource = list6;
            cmbLocation.DisplayMember = "LocationName";
            cmbLocation.ValueMember = "LocationId";
            cmbLocation.SelectedIndex = -1;
        }

       

        private void txtFileDrop_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void txtFileDrop_DragDrop(object sender, DragEventArgs e)
        {
            ep.Clear();
            var files = e.Data.GetData(DataFormats.FileDrop);
            string[] droppedFiles = (string[])files;

            try
            {

                if (droppedFiles.Length > 0)
                {
                    DMFileManager.DataFile df1 = new DMFileManager.DataFile(droppedFiles[0]);
                    txtFileLocation.Text = df1.FolderName;
                    txtFileName.Text = df1.FileName;
                    _incident.FileLocation = txtFileLocation.Text;
                    _incident.FileName = txtFileName.Text;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Drag and drop files", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool ValidateInput()
        {
            ep.Clear();
            int errorCount = 0;
            if ((rbStudent.Checked || rbStaffAndStudent.Checked) && cmbStudent.SelectedIndex == -1)
            {
                ep.SetError(cmbStudent, "Please select student");
                errorCount += 1;
            }
            if ((rbStaff.Checked || rbStaffAndStudent.Checked) && cmbStaff.SelectedIndex == -1)
            {
                ep.SetError(cmbStaff, "Please select staff");
                errorCount += 1;
            }
            if (txtPersonFullName.Text == string.Empty && rbOther.Checked)
            {
                ep.SetError(txtPersonFullName, "Please type person name for other incident type");
                errorCount += 1;
            }
            if (txtDescription.Text == string.Empty)
            {
                ep.SetError(txtDescription, "Please type description");
                errorCount += 1;
            }
            if (!dtp.Checked)
            {
                ep.SetError(dtp, "Please select date");
                errorCount += 1;
            }
            if (lstAmPm.SelectedIndex==-1)
            {
                ep.SetError(lstAmPm, "Please AM or PM");
                errorCount += 1;
            }
            if (lstHour.SelectedIndex == -1)
            {
                ep.SetError(lstHour, "Please select time");
                errorCount += 1;
            }
            if (lstMinute.SelectedIndex == -1)
            {
                ep.SetError(lstMinute, "Please select minute");
                errorCount += 1;
            }
            if (txtFileLocation.Text == string.Empty)
            {
                ep.SetError(txtFileLocation, "Please drag and drop a file");
                errorCount += 1;
            }
            if (txtFileName.Text == string.Empty)
            {
                ep.SetError(txtFileName, "Please drag and drop a file");
                errorCount += 1;
            }
            if (cmbLocation.SelectedIndex == -1)
            {
                ep.SetError(cmbLocation, "Please select location");
                errorCount += 1;
            }
            if (cmbWhoReported.SelectedIndex == -1)
            {
                ep.SetError(cmbWhoReported, "Please select who reported");
                errorCount += 1;
            }
            if (cmbCoordinator.SelectedIndex == -1)
            {
                ep.SetError(cmbCoordinator, "Please select coordinator");
                errorCount += 1;
            }
            if (cmbManager.SelectedIndex == -1)
            {
                ep.SetError(cmbManager, "Please select manager");
                errorCount += 1;
            }
            if (cmbHSOfficer.SelectedIndex == -1)
            {
                ep.SetError(cmbHSOfficer, "Please select health and safety officer");
                errorCount += 1;
            }

            return errorCount == 0;
        }

        private void btnAddIncident_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateInput())
                {
                    _incident.Comments = txtComments.Text;
                    _incidentAddEditBase.Save();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void lstHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            _incident.IncidentHour = lstHour.Text;
        }

        private void lstMinute_SelectedIndexChanged(object sender, EventArgs e)
        {
            _incident.IncidentMinute = lstMinute.Text;
        }

        private void lstAmPm_SelectedIndexChanged(object sender, EventArgs e)
        {
            _incident.AmPm = lstAmPm.Text;
        }

        private void cmbStudent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStudent.SelectedIndex == -1)
                _incident.Student = null;
            else
            {
                StudentData studentData = new StudentData();
                List<Student> list = studentData.GetList("Select * FROM vw_Students where StudentId =" + cmbStudent.SelectedValue).ConvertAll(x => x as Student); 
                if(list.Count>0)
                {
                    _incident.Student = list[0];
                }                
            }
        }

        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStaff.SelectedIndex == -1)
                _incident.Staff = null;
            else
            {
                StaffData staffData = new StaffData();
                List<Staff> list = staffData.GetList((int)cmbStaff.SelectedValue).ConvertAll(x => x as Staff); ;
                if (list.Count > 0)
                {
                    _incident.Staff = list[0];
                }
            }
        }

        //private void IncidentAddEdit_Shown(object sender, EventArgs e)
        //{
        //    cmbStaff.SelectedIndexChanged += cmbStaff_SelectedIndexChanged;
        //    cmbStudent.SelectedIndexChanged += cmbStudent_SelectedIndexChanged;
        //}

        private void rbStudent_CheckedChanged(object sender, EventArgs e)
        {
            if(rbStudent.Checked)
            {
                _incident.IncidentType = Incident.IncidentTypeEnum.Student;
                incidentTypeBase = new StudentType(this);
            }
                
        }

        private void rbStaff_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStaff.Checked)
            {
                _incident.IncidentType = Incident.IncidentTypeEnum.Staff;
                incidentTypeBase = new StaffType(this);
            }
                
        }

        private void rbStaffAndStudent_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStaffAndStudent.Checked)
            {
                _incident.IncidentType = Incident.IncidentTypeEnum.StaffAndStudent;
                incidentTypeBase = new StaffAndStudentType(this);
            }
                
        }

        private void rbOther_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOther.Checked)
            {
                _incident.IncidentType = Incident.IncidentTypeEnum.Other;
                incidentTypeBase = new OtherType(this);
            }
               
        }

        private void cmbWhoReported_SelectedIndexChanged(object sender, EventArgs e)
        {
            _incident.WhoReported.PersonId = (int)cmbWhoReported.SelectedValue;
        }

        private void cmbCoordinator_SelectedIndexChanged(object sender, EventArgs e)
        {
            _incident.Coordinator.PersonId = (int)cmbCoordinator.SelectedValue;
        }

        private void cmbManager_SelectedIndexChanged(object sender, EventArgs e)
        {
            _incident.Manager.PersonId = (int)cmbManager.SelectedValue;
        }

        private void cmbHSOfficer_SelectedIndexChanged(object sender, EventArgs e)
        {
            _incident.HealthAnSafetyOfficer.PersonId = (int)cmbHSOfficer.SelectedValue;
        }

        private void cmbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            _incident.Location.LocationId = (int)cmbLocation.SelectedValue;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
