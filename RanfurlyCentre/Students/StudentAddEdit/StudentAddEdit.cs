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
using RanfurlyCentre.Students.AddDefaults;

namespace RanfurlyCentre
{
    public partial class StudentAddEdit : Form
    {
        //public Student _student { get; set; }
        protected Student _student;
        public bool _changedOccured;
        protected FormInitialiserBase fi;
        protected DataBase db;
        protected StudentAddEditBaseClass _saebc;
        //protected Jarvis _jarvis;
        protected StudentSearch _studentSearch;
        protected DateTimePicker dtp;
        protected Student _originalStudent;
        protected List<StudentAbilityBase> _defaults;

        public StudentAddEdit(Person person,StudentSearch studentSearch)
            //public StudentAddEdit(Person person, Jarvis jarvis)
        {
            InitializeComponent();
            _student = (Student)person;
            //tudent = RePopulateStudent(person);
            _saebc = new StudentAddEditClass(_student);
            //_jarvis = jarvis;
            _studentSearch = studentSearch;
            _originalStudent = new Student();
            CommonFunctions.TransferPropertyValues(_student, _originalStudent);
            toolTip1.SetToolTip(this.dgStudentNote, "Right Click to Add new note");
        }

        private void StudentEdit_Load(object sender, EventArgs e)
        {
            try
            {
                txtStudentId.DataBindings.Add("Text", _student, "PersonId");
                txtPreferredName.DataBindings.Add("Text", _student, "PreferredName");
                txtFirstName.DataBindings.Add("Text", _student, "FirstName");
                txtMiddleName.DataBindings.Add("Text", _student, "MiddleName");
                txtLastName.DataBindings.Add("Text", _student, "LastName");
                txtHomePhone.DataBindings.Add("Text", _student, "HomePhone");
                txtMobilePhone.DataBindings.Add("Text", _student, "MobilePhone");
                chkIsResident.DataBindings.Add("Checked", _student, "IsResident");
                chkIsShortStayResident.DataBindings.Add("Checked", _student, "IsShortStayResident");
                chkIsActive.DataBindings.Add("Checked", _student, "IsActive");
                chkAttendsActivityCentre.DataBindings.Add("Checked", _student, "AttendsActivityCentre");
                txtNHINumber.DataBindings.Add("Text", _student, "NHINumber");
                txtMobilityCardNumber.DataBindings.Add("Text", _student, "MobilityCardNumber");
                txtIRDNumber.DataBindings.Add("Text", _student, "IRDNumber");
                txtWINZNumber.DataBindings.Add("Text", _student, "WINZNumber");
                txtGoldCardNumber.DataBindings.Add("Text", _student, "GoldCardNumber");                
                txtCommunityServicesCardNumber.DataBindings.Add("Text", _student, "CommunityServicesCardNumber");
                txtPlaceOfBirth.DataBindings.Add("Text", _student, "PlaceOfBirth");

                txtAddr1.DataBindings.Add("Text", _student, "Addr1");
                txtAddr2.DataBindings.Add("Text", _student, "Addr2");
                txtAddr3.DataBindings.Add("Text", _student, "Addr3");
                txtAddr4.DataBindings.Add("Text", _student, "Addr4");
                txtPostcode.DataBindings.Add("Text", _student, "Postcode");
                txtShortNotes.DataBindings.Add("Text", _student, "ShortNotes");
                txtFuneralArrangement.DataBindings.Add("Text", _student, "FuneralArrangement");

                if (_student.Gender == "Male")
                    rbMale.Checked = true;
                else if (_student.Gender == "Female")
                    rbFemale.Checked = true;

                if (_student.DateOfBirth != DateTime.MinValue && _student.DateOfBirth.HasValue)
                {
                    dtpDateOfBirth.Checked = true;
                    dtpDateOfBirth.Value = (DateTime)_student.DateOfBirth;
                    //dtpDateOfBirth.DataBindings.Add("Value", _student, "DateOfBirth");                   
                }
                dtpDateOfBirth.Format = DateTimePickerFormat.Custom;
                dtpDateOfBirth.CustomFormat = "dd MMM yyyy";

                if (_student.AdmittedToActivityCentre != DateTime.MinValue && _student.AdmittedToActivityCentre.HasValue)
                {
                    dtpDateOfAdmissionToActivityCentre.Checked = true;
                    dtpDateOfAdmissionToActivityCentre.Value = (DateTime)_student.AdmittedToActivityCentre;
                    //dtpDateOfAdmissionToActivityCentre.DataBindings.Add("Value", _student, "AdmittedToActivityCentre");                   
                }
                dtpDateOfAdmissionToActivityCentre.Format = DateTimePickerFormat.Custom;
                dtpDateOfAdmissionToActivityCentre.CustomFormat = "dd MMM yyyy";

                if (_student.AdmittedToResidence != DateTime.MinValue && _student.AdmittedToResidence.HasValue)
                {
                    dtpDateOfAdmissionToResidence.Checked = true;
                    dtpDateOfAdmissionToResidence.Value = (DateTime)_student.AdmittedToResidence;
                    //dtpDateOfAdmissionToResidence.DataBindings.Add("Value", _student, "AdmittedToResidence");                    
                }
                dtpDateOfAdmissionToResidence.Format = DateTimePickerFormat.Custom;
                dtpDateOfAdmissionToResidence.CustomFormat = "dd MMM yyyy";

                if (_student.DateLeft != DateTime.MinValue && _student.DateLeft.HasValue)
                {
                    dtpDateLeft.Checked = true;
                    dtpDateLeft.Value = (DateTime)_student.DateLeft;
                    //dtpDateLeft.DataBindings.Add("Value", _student, "DateLeft");
                }
                dtpDateLeft.Format = DateTimePickerFormat.Custom;
                dtpDateLeft.CustomFormat = "dd MMM yyyy";

                PopulateLists();
                //PopulateMedicalConditionAlerts();
                //PopulateDoctors();
                //PopulateProfessionalServiceProviders();
                //PopulateNextOfKin();
                //PopulateMedicalConditions();
                //PopulateEmergencyContacts();
                //PopulateRiskManagementPlans();
                //PopulateStudentNotes();
                //PopulatePersonalCare();
                //PopulateMedicationAndTreatment();
                //PopulateStudenAbilities();
                //PopulateBehaviours();
                //PopulateIncidents();
                PopulateStaffComboBoxes();
                PopulateEthnicityComboBox();
                PopulateLocationCombobox();

                if (_student.PersonId == 0)
                    btnGenerateReport.Visible = false;

                //cmbEthnicity.SelectedIndexChanged -= cmbEthnicity_SelectedIndexChanged;
                //cmbLocation.SelectedIndexChanged -= cmbLocation_SelectedIndexChanged;
                //cmbActivityCentreCoach.SelectedIndexChanged -= cmbActivityCentreCoach_SelectedIndexChanged;
                //cmbResidentCoach.SelectedIndexChanged -= cmbResidentCoach_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Errorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PopulateLists()
        {            
            db = new DoctorData();
            _student.Doctors = db.GetList(_student.PersonId);

            db = new NextOfKinData();
            _student.NextOfKin = db.GetList(_student.PersonId).ConvertAll(c => c as NextOfKin);

            db = new EmergencyContactData();
            _student.EmergencyContacts = db.GetList(_student.PersonId).ConvertAll(x => x as EmergencyContact);

            MedicalConditionData md = new MedicalConditionData();
            _student.MedicalConditions = md.GetList(_student.PersonId);

            StudentNoteData sn = new StudentNoteData();
            _student.StudentNotes = sn.GetList(_student.PersonId);

            RiskManagementPlanData rmp = new RiskManagementPlanData();
            _student.RiskManagementPlans = rmp.GetList(_student.PersonId);

            StudentBehaviourData bd = new StudentBehaviourData();
            _student.Behaviours = bd.GetList(_student.PersonId);

            StudentPersonalCareData pc = new StudentPersonalCareData();
            _student.PersonalCare = pc.GetList(_student.PersonId);

            StudentMedicalConditionAndTreatmentData mt = new StudentMedicalConditionAndTreatmentData();
            _student.MedicationAndTreatments = mt.GetList(_student.PersonId);

            StudentAbilityData pa = new StudentAbilityData();
            _student.StudentAbilities = pa.GetList(_student.PersonId);
            _defaults = pa.GetDefaults();

            StudentMedicalConditionAlertData mca = new StudentMedicalConditionAlertData();
            _student.MedicalConditionAlerts = mca.GetList(_student.PersonId);

            SpecialistData ps = new SpecialistData();
            _student.ProfessionalServiceProviders = ps.GetList(_student.PersonId).ConvertAll(x=>x as Specialist);

            PopulateMedicalConditionAlerts();
            PopulateDoctors();
            PopulateProfessionalServiceProviders();
            PopulateNextOfKin();
            PopulateMedicalConditions();
            PopulateEmergencyContacts();
            PopulateRiskManagementPlans();
            PopulateStudentNotes();
            PopulatePersonalCare();
            PopulateMedicationAndTreatment();
            PopulateStudenAbilities();
            PopulateBehaviours();
            PopulateIncidents();
            
        }

        private void PopulateDoctors()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = _student.Doctors;            
            dgDoctor.AutoGenerateColumns = false;
            dgDoctor.DataSource = bs;// _student.Doctors.ConvertAll(c => c as Doctor);
            dgDoctor.Refresh();
        }

        private void PopulateMedicalConditionAlerts()
        {
            BindingSource bs = new BindingSource();
            _student.AsthmaList = _student.MedicalConditionAlerts.FindAll(x=>x.MedicalTypeAlertTypeId==1).ConvertAll(x => x as Asthma);
            _student.Allergies = _student.MedicalConditionAlerts.FindAll(x => x.MedicalTypeAlertTypeId == 2).ConvertAll(x => x as Allergy);
            _student.EpilepsyList = _student.MedicalConditionAlerts.FindAll(x => x.MedicalTypeAlertTypeId == 3).ConvertAll(x => x as Epilepsy);

            bs.DataSource = _student.AsthmaList;
            dgAsthma.AutoGenerateColumns = false;
            dgAsthma.DataSource = bs;// _student.Doctors.ConvertAll(c => c as Doctor);
            dgAsthma.Refresh();

            BindingSource bs1 = new BindingSource();
            bs1.DataSource = _student.Allergies;
            dgAllergy.AutoGenerateColumns = false;
            dgAllergy.DataSource = bs1;// _student.Doctors.ConvertAll(c => c as Doctor);
            dgAllergy.Refresh();

            BindingSource bs2 = new BindingSource();
            bs2.DataSource = _student.EpilepsyList;
            dgEpilepsy.AutoGenerateColumns = false;
            dgEpilepsy.DataSource = bs2;// _student.Doctors.ConvertAll(c => c as Doctor);
            dgEpilepsy.Refresh();

            //chkAsthma.Checked = _student.AsthmaList.Count > 0;
            //chkAllergies.Checked = _student.Allergies.Count > 0;
            //chkEpilepsy.Checked = _student.EpilepsyList.Count > 0;
        }

        private void PopulateProfessionalServiceProviders()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = _student.ProfessionalServiceProviders;
            dgProfessionalServiceProvider.AutoGenerateColumns = false;
            dgProfessionalServiceProvider.DataSource = bs;// _student.Doctors.ConvertAll(c => c as Doctor);
            dgProfessionalServiceProvider.Refresh();
        }

        private void PopulateNextOfKin()
        {
            //db = new NextOfKinData();           
            //_student.NextOfKin = db.GetList(_student.PersonId).ConvertAll(c => c as NextOfKin);
            BindingSource bs = new BindingSource();
            bs.DataSource = _student.NextOfKin;        
            dgNextOfKin.AutoGenerateColumns = false;
            dgNextOfKin.DataSource = bs;// _student.NextOfKin;// _student.NextOfKin;//.ConvertAll(c => c as NextOfKin); ;
            dgNextOfKin.Refresh();
        }

        private void PopulateEmergencyContacts()
        {
            //db = new EmergencyContactData();
            //_student.EmergencyContacts = db.GetList(_student.PersonId).ConvertAll(x=>x as EmergencyContact);
            BindingSource bs = new BindingSource();
            bs.DataSource = _student.EmergencyContacts;
            dgEmergencyContact.AutoGenerateColumns = false;
            dgEmergencyContact.DataSource = bs;
            dgEmergencyContact.Refresh();
        }

        private void PopulateMedicalConditions()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = _student.MedicalConditions;            
            dgMedicalCondition.AutoGenerateColumns = false;
            dgMedicalCondition.DataSource = bs;
            dgMedicalCondition.Refresh();
        }

        private void PopulateStudentNotes()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = _student.StudentNotes;
            dgStudentNote.AutoGenerateColumns = false;
            dgStudentNote.DataSource = bs;
            dgStudentNote.Refresh();
        }

        private void PopulateRiskManagementPlans()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = _student.RiskManagementPlans;
            dgRiskManagementPlan.AutoGenerateColumns = false;
            dgRiskManagementPlan.DataSource = bs;
            dgRiskManagementPlan.Refresh();
        }

        private void PopulateBehaviours()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = _student.Behaviours;
            dgBehaviours.AutoGenerateColumns = false;
            dgBehaviours.DataSource = bs;
            dgBehaviours.Refresh();
        }

        private void PopulatePersonalCare()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = _student.PersonalCare;
            dgPersonalCare.AutoGenerateColumns = false;
            dgPersonalCare.DataSource = bs;
            dgPersonalCare.Refresh();
        }

        private void PopulateMedicationAndTreatment()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = _student.MedicationAndTreatments;
            dgMedicationAndTreatment.AutoGenerateColumns = false;
            dgMedicationAndTreatment.DataSource = bs;
            dgMedicationAndTreatment.Refresh();
        }

        private void PopulateStudenAbilities()
        {
            BindingSource bs = new BindingSource();
            _student.PhysicalAbilities = _student.StudentAbilities.FindAll(x => x.StudentAbilityTypeId == 1).ConvertAll(x => x as PhysicalAbility);
            _student.CommunityOrientations = _student.StudentAbilities.FindAll(x => x.StudentAbilityTypeId == 2).ConvertAll(x => x as CommunityOrientation);
            _student.CommunityInteractions = _student.StudentAbilities.FindAll(x => x.StudentAbilityTypeId == 3).ConvertAll(x => x as CommunityInteraction);

            bs.DataSource = _student.PhysicalAbilities;
            dgPhysicalAbilities.AutoGenerateColumns = false;
            dgPhysicalAbilities.DataSource = bs;// _student.Doctors.ConvertAll(c => c as Doctor);
            dgPhysicalAbilities.Refresh();

            BindingSource bs1 = new BindingSource();
            bs1.DataSource = _student.CommunityOrientations;
            dgCommunityOrientation.AutoGenerateColumns = false;
            dgCommunityOrientation.DataSource = bs1;// _student.Doctors.ConvertAll(c => c as Doctor);
            dgCommunityOrientation.Refresh();

            BindingSource bs2 = new BindingSource();
            bs2.DataSource = _student.CommunityInteractions;
            dgCommunityInterraction.AutoGenerateColumns = false;
            dgCommunityInterraction.DataSource = bs2;// _student.Doctors.ConvertAll(c => c as Doctor);
            dgCommunityInterraction.Refresh();

            //BindingSource bs = new BindingSource();
            //bs.DataSource = _student.StudentAbilities;
            //dgPhysicalAbilities.AutoGenerateColumns = false;
            //dgPhysicalAbilities.DataSource = bs;
            //dgPhysicalAbilities.Refresh();
        }

        private void PopulateIncidents()
        {
            _student.Incidents = _student.GetIncidents();
            dgIncidents.AutoGenerateColumns = false;
            dgIncidents.DataSource = _student.Incidents;
            dgIncidents.Refresh();
        }

        private void PopulateStaffComboBoxes()
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

            cmbActivityCentreCoach.SelectedIndexChanged += cmbActivityCentreCoach_SelectedIndexChanged;
            cmbResidentCoach.SelectedIndexChanged += cmbResidentCoach_SelectedIndexChanged;
        }        

        public void PopulateEthnicityComboBox()
        {
            EthnicityData et = new EthnicityData();
            cmbEthnicity.DataSource = null;
            cmbEthnicity.DataSource = et.GetList();
            cmbEthnicity.ValueMember = "EthnicityId";
            cmbEthnicity.DisplayMember = "EthnicityName";
            cmbEthnicity.DataBindings.Clear();
            cmbEthnicity.DataBindings.Add("SelectedValue", _student, "EthnicityId");
            cmbEthnicity.SelectedIndexChanged += cmbEthnicity_SelectedIndexChanged;
        }

        public void PopulateLocationCombobox()
        {
            LocationData ld = new LocationData();
            List<Location> locations = ld.GetList("SELECT * FROM vw_Locations WHERE IsStudentCentre=true");

            cmbLocation.DataSource = locations;
            cmbLocation.ValueMember = "LocationId";
            cmbLocation.DisplayMember = "LocationName";
            cmbLocation.DataBindings.Add("SelectedValue", _student, "LocationId");
            cmbLocation.SelectedIndexChanged += cmbLocation_SelectedIndexChanged;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // CommonFunctions.CheckIfPropertyVluesHaveChanged(_originalPerson, _person);

            if (_changedOccured)
            {
                if (MessageBox.Show("Do you want to save changes?", "Save changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (!_studentSearch._mdiForm.Jarvis.CurrentUser.UserHasPermissionForAction("Staff", "Edit"))
                        return;
                    if (InputValidated())
                    {
                        try
                        {
                            SaveChanges();
                            MessageBox.Show("Student record saved", "Save record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (Application.OpenForms["StudentSearch"] as StudentSearch != null)
                            {
                                StudentSearch frm1 = (StudentSearch)Application.OpenForms["StudentSearch"];
                                frm1.LoadStudentList();
                                frm1.SetDataSource();
                            }
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                       
                    }
                }
                else
                {
                    CommonFunctions.TransferPropertyValues(_originalStudent, _student);
                    this.Close();
                }
            }
            else
            {
                this.Close();
            }
            
        }

        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            _student.DateOfBirth = dtpDateOfBirth.Value;
        }

        private void addDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoctorAssign ad = new DoctorAssign(_student);
            ad.ShowDialog();
            if (ad.DialogResult == DialogResult.OK)
            {
                fi.ValueChanged(sender, e);
                PopulateDoctors();
            }
        }

        private void addNextOfKin_Click(object sender, EventArgs e)
        {
            NextOfKinAssign ad = new NextOfKinAssign(_student);
            ad.ShowDialog();
            if (ad.DialogResult == DialogResult.OK)
            {
                //DataBase db = new NextOfKinData();
                //_student.NextOfKin = db.GetList(_student.PersonId).ConvertAll(x=>x as NextOfKin);
                fi.ValueChanged(sender, e);
                PopulateNextOfKin();                
            }
        }        

        private void StudentEdit_Shown(object sender, EventArgs e)
        {
            //EnableFieldChangeEvent();

            fi = new StudentEditIntialiser(this);
            dgMedicalCondition.CellValueChanged += CellValueChanged;
            dgEmergencyContact.CellValueChanged += CellValueChanged;
            dgStudentNote.CellValueChanged += CellValueChanged;
            dgRiskManagementPlan.CellValueChanged += CellValueChanged;
            dgNextOfKin.CellValueChanged += CellValueChanged;
            dgPersonalCare.CellValueChanged += CellValueChanged;
            dgMedicationAndTreatment.CellValueChanged += CellValueChanged;
            dgPhysicalAbilities.CellValueChanged += CellValueChanged;
            dgCommunityOrientation.CellValueChanged += CellValueChanged;
            dgCommunityInterraction.CellValueChanged += CellValueChanged;
            dgAsthma.CellValueChanged += CellValueChanged;
            dgAllergy.CellValueChanged += CellValueChanged;
            dgEpilepsy.CellValueChanged += CellValueChanged;
            dgBehaviours.CellValueChanged += CellValueChanged;

            dgDoctor.UserDeletingRow += RowsRemoving;
            dgMedicalCondition.UserDeletingRow += RowsRemoving;
            dgEmergencyContact.UserDeletingRow += RowsRemoving;
            dgRiskManagementPlan.UserDeletingRow += RowsRemoving;
            dgNextOfKin.UserDeletingRow += RowsRemoving;
            dgStudentNote.UserDeletingRow += RowsRemoving;
            dgPersonalCare.UserDeletingRow += RowsRemoving;
            dgMedicationAndTreatment.UserDeletingRow += RowsRemoving;
            dgPhysicalAbilities.UserDeletingRow += RowsRemoving;
            dgCommunityOrientation.UserDeletingRow += RowsRemoving;
            dgCommunityInterraction.UserDeletingRow += RowsRemoving;
            dgAsthma.UserDeletingRow += RowsRemoving;
            dgAllergy.UserDeletingRow += RowsRemoving;
            dgEpilepsy.UserDeletingRow += RowsRemoving;
            dgBehaviours.UserDeletingRow += RowsRemoving;

            //dgDoctor.CellMouseDoubleClick += CellMouseDoubleClick;
            //dgMedicalCondition.CellMouseDoubleClick += CellMouseDoubleClick;
            dgNextOfKin.CellMouseDoubleClick += CellMouseDoubleClick;
            dgEmergencyContact.CellMouseDoubleClick += CellMouseDoubleClick;
            dgMedicalCondition.CellMouseDoubleClick += CellMouseDoubleClick;
            dgStudentNote.CellMouseDoubleClick += CellMouseDoubleClick;
            dgRiskManagementPlan.CellMouseDoubleClick += CellMouseDoubleClick;
            dgMedicationAndTreatment.CellMouseDoubleClick += CellMouseDoubleClick;
            dgPhysicalAbilities.CellMouseDoubleClick += CellMouseDoubleClick;
            dgCommunityOrientation.CellMouseDoubleClick += CellMouseDoubleClick;
            dgCommunityInterraction.CellMouseDoubleClick += CellMouseDoubleClick;
            dgAsthma.CellMouseDoubleClick += CellMouseDoubleClick;
            dgAllergy.CellMouseDoubleClick += CellMouseDoubleClick;
            dgEpilepsy.CellMouseDoubleClick += CellMouseDoubleClick;
            dgBehaviours.CellMouseDoubleClick += CellMouseDoubleClick;
            dgPersonalCare.CellMouseDoubleClick += CellMouseDoubleClick;

            dgAsthma.RowsAdded += dgMedicalConditionAlert_RowsAdded;
            dgAllergy.RowsAdded += dgMedicalConditionAlert_RowsAdded;
            dgEpilepsy.RowsAdded += dgMedicalConditionAlert_RowsAdded;

            dgAsthma.RowsRemoved += dgMedicalConditionAlert_RowsRemoved;
            dgAllergy.RowsRemoved += dgMedicalConditionAlert_RowsRemoved;
            dgEpilepsy.RowsRemoved += dgMedicalConditionAlert_RowsRemoved;

            //cmbEthnicity.SelectedIndexChanged += cmbEthnicity_SelectedIndexChanged;
            //cmbLocation.SelectedIndexChanged += cmbLocation_SelectedIndexChanged;
            //cmbActivityCentreCoach.SelectedIndexChanged += cmbActivityCentreCoach_SelectedIndexChanged;
            //cmbResidentCoach.SelectedIndexChanged += cmbResidentCoach_SelectedIndexChanged;
        }

        private void cmbEthnicity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEthnicity.SelectedIndex != -1)
            {
                _student.Ethnicity = cmbEthnicity.Text;
            }

        }

        private void cmbActivityCentreCoach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbActivityCentreCoach.SelectedIndex != -1)
            {
                _student.ActivityCentreCoach = cmbActivityCentreCoach.Text;
            }
        }

        private void cmbResidentCoach_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbResidentCoach.SelectedIndex != -1)
            {
                _student.ResidentCoach = cmbResidentCoach.Text;
            }

        }

        private void cmbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLocation.SelectedIndex != -1)
            {
                _student.LocationName = cmbLocation.Text;
            }

        }



        //private void dgMedicalConditionAlert_UserAdded_DeletedRow(object sender, DataGridViewRowEventArgs e)
        //{
        //    if (!e.Row.IsNewRow)
        //    {
        //        //dgAllergy.Refresh();
        //        chkAsthma.Checked = _student.AsthmaList.Count > 0;
        //        chkAllergies.Checked = _student.Allergies.Count > 0;
        //        chkEpilepsy.Checked = _student.EpilepsyList.Count > 0;
        //    }

        //}

        private void dgMedicalConditionAlert_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            chkAsthma.Checked = _student.AsthmaList.Count > 0;
            chkAllergies.Checked = _student.Allergies.Count > 0;
            chkEpilepsy.Checked = _student.EpilepsyList.Count > 0;
        }

        private void dgMedicalConditionAlert_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            chkAsthma.Checked = _student.AsthmaList.Count > 0;
            chkAllergies.Checked = _student.Allergies.Count > 0;
            chkEpilepsy.Checked = _student.EpilepsyList.Count > 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_studentSearch._mdiForm.Jarvis.CurrentUser.UserHasPermissionForAction("Student", "Edit"))
                return;
            if (_changedOccured && InputValidated())
            {
                try
                {
                    _student.DateOfBirth = dtpDateOfBirth.Value;
                    if (cmbEthnicity.SelectedIndex != -1)
                        _student.Ethnicity = cmbEthnicity.Text;
                    if (!dtpDateOfAdmissionToResidence.Checked)
                    {
                        _student.IsResident = false;
                        _student.AdmittedToResidence = null;
                    }
                    else
                    {
                        _student.IsResident = true;
                        _student.AdmittedToResidence = dtpDateOfAdmissionToResidence.Value;
                    }
                    if (dtpDateOfAdmissionToActivityCentre.Checked)
                    {
                        _student.AdmittedToActivityCentre = dtpDateOfAdmissionToActivityCentre.Value;
                    }
                    else
                    {
                        _student.AdmittedToActivityCentre = null;
                    }

                    if (!dtpDateOfBirth.Checked)
                    {
                        _student.DateOfBirth = dtpDateOfBirth.Value;
                    }

                    if (dtpDateLeft.Checked)
                    {
                        _student.DateLeft = dtpDateLeft.Value;
                        _student.IsActive = false;
                    }
                    else
                    {
                        _student.DateLeft = null;
                        _student.IsActive = true;
                    }

                    SaveChanges();
                   // _changedOccured = false;
                    //btnSave.Enabled = false;
                    RePopulateStudentAfterSave();
                    MessageBox.Show("Student record saved", "Save record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Errorr", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("There are validation errors. Please check all tabs", "Save record", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RePopulateStudentAfterSave()
        {
            _studentSearch.LoadStudentList();
            _studentSearch.SetDataSource();
            _studentSearch.PopulateGridAfterSelection();
            //StudentData sd = new StudentData();
            //List<Person> persons = sd.GetList("SELECT* FROM vw_Students WHERE StudentId=" + person.PersonId);
            //Student student = (Student)persons[0];
            //return student;
            ////PopulateLists();
        }

        private bool InputValidated()
        {
            ep.Clear();
            int errors = 0;
            if (rbFemale.Checked)
                _student.Gender = "Female";
            else
                _student.Gender = "Male";

            if (txtFirstName.Text == string.Empty)
            {
                errors += 1;
                ep.SetError(txtFirstName, "Type First Name");
            }
                
            if (txtLastName.Text == string.Empty)
            {
                errors += 1;
                ep.SetError(txtLastName, "Type Last Name");
            }
                

            if (!dtpDateOfBirth.Checked)
            {
                errors += 1;
                ep.SetError(dtpDateOfBirth, "Select Date of Birth");
            }
                

            if (!dtpDateOfAdmissionToActivityCentre.Checked)
            {
                errors += 1;
                ep.SetError(dtpDateOfAdmissionToActivityCentre, "Select Date of admission to Activity centre");
            }
                

            if (cmbEthnicity.SelectedIndex == -1)
            {
                errors += 1;
                ep.SetError(cmbEthnicity, "Select Ethnicity");
            }
                
            if (cmbLocation.SelectedIndex == -1)
            {
                errors += 1;
                ep.SetError(cmbLocation, "Select Location");
            }
                

            if (txtAddr1.Text == string.Empty)
            {
                errors += 1;
                ep.SetError(txtAddr1, "Type Addr 1");
            }
                
            if (txtAddr2.Text == string.Empty)
            {
                errors += 1;
                ep.SetError(txtAddr2, "Type Addr 2");
            }
                
            if (txtAddr3.Text == string.Empty)
            {
                errors += 1;
                ep.SetError(txtAddr3, "Type Addr 3");
            }
                
            if (txtPostcode.Text == string.Empty)
            {
                errors += 1;
                ep.SetError(txtPostcode, "Type Postcode");
            }
                
            if (txtWINZNumber.Text == string.Empty)
            {
                errors += 1;
                ep.SetError(txtWINZNumber, "Type WINZ Number");
            }
               
            if (chkIsResident.Checked && txtCommunityServicesCardNumber.Text == string.Empty)
            {
                errors += 1;
                ep.SetError(txtCommunityServicesCardNumber, "Need to enter Community services Card Number for resident students");
            }

            return errors == 0;
           // return !fi.EPHasErrors();
            //if (fi.EPHasErrors())
            //    return;
        }

        private void SaveChanges()
        {
            //StudenData sd = new StudenData(DBCommand.TransactionType.WithTransaction);
            //sd.Update(_student);
            _student.MedicalConditionAlerts.Clear();
            _student.MedicalConditionAlerts.AddRange(_student.AsthmaList);
            _student.MedicalConditionAlerts.AddRange(_student.Allergies);
            _student.MedicalConditionAlerts.AddRange(_student.EpilepsyList);

            _student.StudentAbilities.Clear();
            _student.StudentAbilities.AddRange(_student.PhysicalAbilities);
            _student.StudentAbilities.AddRange(_student.CommunityOrientations);
            _student.StudentAbilities.AddRange(_student.CommunityInteractions);


            _saebc.Save();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dtpDateOfAdmissionToResidence_ValueChanged(object sender, EventArgs e)
        {
            _student.AdmittedToResidence = dtpDateOfAdmissionToResidence.Value;
            chkIsResident.Checked = dtpDateOfAdmissionToResidence.Checked;
        }

        private void AddEmergencyContact_Click(object sender, EventArgs e)
        {
            //EmergencyContactAdd ad = new EmergencyContactAdd(_student,"edit");
            EmergencyContactAdd ad = new EmergencyContactAdd(_saebc);            
            ad.ShowDialog();
            if (ad.DialogResult == DialogResult.OK)
            {
                //DataBase db = new EmergencyContactData();
                //_student.EmergencyContacts = db.GetList(_student.PersonId).ConvertAll(x=>x as EmergencyContact);
                fi.ValueChanged(sender, e);
                PopulateEmergencyContacts();
            }
        }

       

        //private void StudentEdit_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    //if (_changedOccured)
        //    //{
        //    //    if (MessageBox.Show("Do you want to save changes?", "Save changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //    //    {
        //    //        if(InputValidated())
        //    //         SaveChanges();
        //    //    }
        //    //    else
        //    //    {
        //    //        if (Application.OpenForms["StudentSearch"] as StudentSearch != null)
        //    //        {
        //    //            StudentSearch frm1 = (StudentSearch)Application.OpenForms["StudentSearch"];
        //    //            frm1.LoadStudentList();
        //    //            frm1.SetDataSource();
        //    //        }
                        
        //    //    }
        //    //}
        //}

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MedicalCondtionAdd mca = new MedicalCondtionAdd(_saebc);
            mca.ShowDialog();
            if (mca.DialogResult == DialogResult.OK)
            {
                fi.ValueChanged(sender, e);
                PopulateMedicalConditions();
            }
        }

       
        private void CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                _changedOccured = true;
                btnSave.Enabled = true;
            }
        }

        private void dgEmergencyContacts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        

        private void RowsRemoving(object sender, DataGridViewRowCancelEventArgs e)
        {
            object ob;
            string objectType = string.Empty;
            string objectName = string.Empty;
            int id;
            DataGridView dgv = (DataGridView)sender;
            if (dgv.Name == "dgDoctor")
            {
                ob = (Doctor)_student.Doctors[e.Row.Index];
                objectType = "Doctor";
                objectName = ((Doctor)ob).FullName;
                id = ((Doctor)ob).PersonId;
                //_saebc.Remove(ob);
            }
            else if (dgv.Name == "dgNextOfKin")
            {
                ob = _student.NextOfKin[e.Row.Index];
                objectType = "Next of Kin";
                objectName = ((NextOfKin)ob).FullName;
                id = ((NextOfKin)ob).PersonId;
                //_saebc.Remove(ob);
            }
            else if (dgv.Name == "dgEmergencyContact")
            {
                ob = _student.EmergencyContacts[e.Row.Index];
                objectType = "Emergency contact";
                objectName = ((EmergencyContact)ob).FullName;
                id = ((EmergencyContact)ob).PersonId;
                //_saebc.Remove(ob);
            }

            else if (dgv.Name == "dgStudentNote")
            {
                ob = _student.StudentNotes[e.Row.Index];
                objectType = "Student Note";
                objectName = ((StudentNote)ob).StudentNoteName;
                id = ((StudentNote)ob).StudentNoteId;
                //_saebc.Remove(ob);
            }
            else if (dgv.Name == "dgMedicationAndTreatment")
            {
                ob = _student.MedicationAndTreatments[e.Row.Index];
                objectType = "Medicaton and treatment";
                objectName = ((MedicationAndTreatment)ob).Medication;
                id = ((MedicationAndTreatment)ob).StudentMedicationAndTreatmentId;
                //_saebc.Remove(ob);
            }
            else if (dgv.Name == "dgRiskManagementPlan")
            {
                ob = _student.RiskManagementPlans[e.Row.Index];
                objectType = "Risk Management Plan";
                objectName = ((RiskManagementPlan)ob).Risk;
                id = ((RiskManagementPlan)ob).StudentRiskManagementId;
                //_saebc.Remove(ob);
            }
            else if (dgv.Name == "dgMedicalCondition")
            {
                ob = _student.MedicalConditions[e.Row.Index];
                objectType = "Medical condition";
                objectName = ((MedicalCondition)ob).MedicalConditionName;
                id = ((MedicalCondition)ob).StudentMedicalConditionId;
                //_saebc.Remove(ob);
            }

            else if (dgv.Name == "dgPhysicalAbilities")
            {
                ob = _student.StudentAbilities[e.Row.Index];
                objectType = "Physical Ability";
                objectName = ((PhysicalAbility)ob).Item;
                id = ((PhysicalAbility)ob).StudentAbilityId;
                //_saebc.Remove(ob);
            }

            else if (dgv.Name == "dgCommunityOrientation")
            {
                ob = _student.CommunityOrientations[e.Row.Index];
                objectType = "Community Orientation";
                objectName = ((CommunityOrientation)ob).Item;
                id = ((CommunityOrientation)ob).StudentAbilityId;
                //_saebc.Remove(ob);
            }

            else if (dgv.Name == "dgCommunityInterraction")
            {
                ob = _student.CommunityInteractions[e.Row.Index];
                objectType = "Community Interraction";
                objectName = ((CommunityInteraction)ob).Item;
                id = ((CommunityInteraction)ob).StudentAbilityId;
                //_saebc.Remove(ob);
            }

            else if (dgv.Name == "dgAsthma")
            {
                ob = _student.AsthmaList[e.Row.Index];
                objectType = "Asthma";
                objectName = ((Asthma)ob).Definition;
                id = ((Asthma)ob).StudentMedicalConditionAlertId;
                //_saebc.Remove(ob);
            }

            else if (dgv.Name == "dgAllergy")
            {
                ob = _student.Allergies[e.Row.Index];
                objectType = "Allergy";
                objectName = ((Allergy)ob).Definition;
                id = ((Allergy)ob).StudentMedicalConditionAlertId;
                //_saebc.Remove(ob);
            }

            else if (dgv.Name == "dgEpilepsy")
            {
                ob = _student.EpilepsyList[e.Row.Index];
                objectType = "Epilepsy";
                objectName = ((Epilepsy)ob).Definition;
                id = ((Epilepsy)ob).StudentMedicalConditionAlertId;
                //_saebc.Remove(ob);
            }

            else if (dgv.Name == "dgBehaviours")
            {
                ob = _student.Behaviours[e.Row.Index];
                objectType = "Behaviour";
                objectName = ((StudentBehaviour)ob).Profile;
                id = ((StudentBehaviour)ob).StudentBehaviourId;
                //_saebc.Remove(ob);
            }

            else  // Personal care
            {
                ob = _student.PersonalCare[e.Row.Index];
                objectType = "Persona Care";
                objectName = ((StudentPersonalCare)ob).Item;
                id = ((StudentPersonalCare)ob).StudentPersonalCareId;
                //_saebc.Remove(ob);
            }

            if (MessageBox.Show("Are you sure you want to remove " + objectType + " '" + objectName + " '" + "' from this student?", "Remove Medical condition", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if(id!=0)
                {
                    _saebc.Remove(ob);
                    btnSave.Enabled = true;
                    _changedOccured = true;
                }                
            }
            else
                e.Cancel = true;
        }

        private void dtpDateOfAdmissionToActivityCentre_ValueChanged(object sender, EventArgs e)
        {
            _student.AdmittedToActivityCentre = dtpDateOfAdmissionToActivityCentre.Value;
        }

        private void CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                {
                    DataGridViewCell currentCell = dgv.CurrentCell;
                    EditBox eb = new EditBox();
                    eb.txtContent.Text = currentCell.Value.ToString();
                    eb.ShowDialog();
                    if (eb.DialogResult == DialogResult.OK)
                    {
                        currentCell.Value = eb.txtContent.Text;
                        _changedOccured = true;
                        btnSave.Enabled = true;
                    }
                        
                }
            }
            catch { }
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {                
                ReportViewer frm = new ReportViewer(_student);
                frm.Jarvis = _studentSearch._mdiForm.Jarvis;
                frm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FuneralArrangement_TextChanged(object sender, EventArgs e)
        {
            _changedOccured = true;
            btnSave.Enabled = true;
        }

        //private void dgStudentNote_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.ColumnIndex == 1)
        //    {
        //        dtp = new DateTimePicker();
        //        //dtp.Value = DateTime.Today;
        //        dgStudentNote.Controls.Add(dtp);
        //        dtp.Format = DateTimePickerFormat.Long;
        //        Rectangle Rectangle = dgStudentNote.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
        //        dtp.Size = new Size(Rectangle.Width, Rectangle.Height);
        //        dtp.Location = new Point(Rectangle.X, Rectangle.Y);

        //        dtp.CloseUp += new EventHandler(dtp_CloseUp);
        //        dtp.TextChanged += new EventHandler(dtp_OnTextChange);


        //        dtp.Visible = true;
        //    }
        //}

        //private void dtp_OnTextChange(object sender, EventArgs e)
        //{
        //    //DataGridView dg = (DataGridView)sender;
        //    dgStudentNote.CurrentCell.Value = dtp.Text.ToString();
        //}
        //void dtp_CloseUp(object sender, EventArgs e)
        //{
        //    dgStudentNote.Visible = true;
        //}

        private void dgRiskManagementPlan_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DatagridViewRowValidatorBase dgrv = new RiskManagementValidator(sender, e);
        }

        private void dgMedicalCondition_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DatagridViewRowValidatorBase dgrv = new MedicalConditionValidator(sender, e);
        }

        private void dgPersonalCare_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DatagridViewRowValidatorBase dgrv = new PersonalCareValidator(sender, e);            
        }

        private void dgMedicationAndTreatment_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DatagridViewRowValidatorBase dgrv = new MedicationAndTreatmentValidator(sender, e);
        }

        private void dgNextOfKin_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DatagridViewRowValidatorBase dgrv = new NextOfKinValidator(sender, e);
        }

        private void dgEmergencyContacts_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DatagridViewRowValidatorBase dgrv = new EmergencyContactsValidator(sender, e);
        }

        private void dgEpilepsy_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DatagridViewRowValidatorBase dgrv = new EpilepsyValidator(sender, e);
        }

        private void dgAllergy_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DatagridViewRowValidatorBase dgrv = new AllergyValidator(sender, e);
        }

        private void dgAsthma_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DatagridViewRowValidatorBase dgrv = new AsthmaValidator(sender, e);
        }

        private void dgPhysicalAbilities_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DatagridViewRowValidatorBase dgrv = new PhysicalAbilityValidator(sender, e);
        }

        private void dgCommunityOrientation_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DatagridViewRowValidatorBase dgrv = new CommunityOrientationValidator(sender, e);
        }

        private void dgyCommunityInterraction_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DatagridViewRowValidatorBase dgrv = new CommunityInterractionValidator(sender, e);
        }

        private void dgStudentNote_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DatagridViewRowValidatorBase dgrv = new CommunicationNoteValidator(sender, e);
        }

        private void dgBehaviours_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            DatagridViewRowValidatorBase dgrv = new BehaviourValidator(sender, e);
        }

        private void dtpDateLeft_ValueChanged(object sender, EventArgs e)
        {
            _student.DateLeft = dtpDateLeft.Value;
            chkIsActive.Checked = !dtpDateLeft.Checked; 
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            ProfessionalAssign ad = new ProfessionalAssign(_student);
            ad.ShowDialog();
            if (ad.DialogResult == DialogResult.OK)
            {
                fi.ValueChanged(sender, e);
                PopulateProfessionalServiceProviders();
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            AddEditCommunicationNote cn = new AddEditCommunicationNote(_student);
            cn.ShowDialog();
            if (cn.DialogResult == DialogResult.OK)
            {
                PopulateStudentNotes();
                //_changedOccured = true;
                //btnSave.Enabled = true;
                fi.ValueChanged(sender,e);
                //dgStudentNote.Refresh();
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 8)
                lblNote.Visible = true;
            else
                lblNote.Visible = false;
        }

        private void dgIncidents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 6)
                {
                    string filename = dgIncidents.Rows[e.RowIndex].Cells[5].Value.ToString() + "\\" + dgIncidents.Rows[e.RowIndex].Cells[6].Value.ToString();
                    System.Diagnostics.Process.Start(filename);
                }

                if (e.RowIndex >= 0 && e.ColumnIndex == 5)
                {
                    string folderName = dgIncidents.Rows[e.RowIndex].Cells[5].Value.ToString() + "\\";
                    System.Diagnostics.Process.Start(folderName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot find file", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e) // Add Community Orientations
        {
            bool itemsAdded = false; ;
            StudentDefaults studentDefaults = new StudentDefaults(_defaults, 2);
            studentDefaults.ShowDialog();
            if (studentDefaults.DialogResult==DialogResult.OK)
            {
                foreach(StudentAbilityBase studentDefault in studentDefaults.SelectedList)
                {
                    CommunityOrientation newDefault = _student.CommunityOrientations.Find(x => x.Item == studentDefault.Item);
                    if(newDefault ==null)
                    {
                        studentDefault.Description = "*";
                        studentDefault.StudentId = _student.PersonId;
                        _student.CommunityOrientations.Add((CommunityOrientation)studentDefault);
                        itemsAdded = true;
                    }
                }

                BindingSource bs1 = new BindingSource();
                bs1.DataSource = _student.CommunityOrientations;
                dgCommunityOrientation.AutoGenerateColumns = false;
                dgCommunityOrientation.DataSource = bs1;// _student.Doctors.ConvertAll(c => c as Doctor);
                dgCommunityOrientation.Refresh();
                if (itemsAdded)
                {
                    btnSave.Enabled = true;
                    _changedOccured = true;
                }
                    
            }
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e)// Add Default interactions
        {
            bool itemsAdded = false; ;
            StudentDefaults studentDefaults = new StudentDefaults(_defaults, 3);
            studentDefaults.ShowDialog();
            if (studentDefaults.DialogResult == DialogResult.OK)
            {
                foreach (StudentAbilityBase studentDefault in studentDefaults.SelectedList)
                {
                    CommunityInteraction newDefault = _student.CommunityInteractions.Find(x => x.Item == studentDefault.Item);
                    if (newDefault == null)
                    {
                        studentDefault.Description = "*";
                        studentDefault.StudentId = _student.PersonId;
                        _student.CommunityInteractions.Add((CommunityInteraction)studentDefault);
                        itemsAdded = true;
                    }
                }

                BindingSource bs1 = new BindingSource();
                bs1.DataSource = _student.CommunityInteractions;
                dgCommunityInterraction.AutoGenerateColumns = false;
                dgCommunityInterraction.DataSource = bs1;// _student.Doctors.ConvertAll(c => c as Doctor);
                dgCommunityInterraction.Refresh();
                if (itemsAdded)
                {
                    btnSave.Enabled = true;
                    _changedOccured = true;
                }
            }
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e) // Add Physical Ability Items
        {
            bool itemsAdded = false; ;
            StudentDefaults studentDefaults = new StudentDefaults(_defaults, 1);
            studentDefaults.ShowDialog();
            if (studentDefaults.DialogResult == DialogResult.OK)
            {
                foreach (StudentAbilityBase studentDefault in studentDefaults.SelectedList)
                {
                    PhysicalAbility newDefault = _student.PhysicalAbilities.Find(x => x.Item == studentDefault.Item);
                    if (newDefault == null)
                    {
                        studentDefault.Description = "*";
                        studentDefault.StudentId = _student.PersonId;
                        _student.PhysicalAbilities.Add((PhysicalAbility)studentDefault);
                        itemsAdded = true;
                    }
                }

                BindingSource bs1 = new BindingSource();
                bs1.DataSource = _student.PhysicalAbilities;
                dgPhysicalAbilities.AutoGenerateColumns = false;
                dgPhysicalAbilities.DataSource = bs1;// _student.Doctors.ConvertAll(c => c as Doctor);
                dgPhysicalAbilities.Refresh();
                if (itemsAdded)
                {
                    btnSave.Enabled = true;
                    _changedOccured = true;
                }
            }
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e)
        {
            bool itemsAdded = false; ;
            StudentDefaults studentDefaults = new StudentDefaults(_defaults, 4);
            studentDefaults.ShowDialog();
            if (studentDefaults.DialogResult == DialogResult.OK)
            {
                foreach (StudentAbilityBase studentDefault in studentDefaults.SelectedList)
                {
                    StudentPersonalCare newDefault = _student.PersonalCare.Find(x => x.Item == studentDefault.Item);
                    if (newDefault == null)
                    {
                        StudentPersonalCare newItem = new StudentPersonalCare();
                        newItem.Frequency = "Daily";
                        newItem.Item = studentDefault.Item;
                        newItem.Assistance = "*";
                        newItem.StudentId = _student.PersonId;
                        _student.PersonalCare.Add(newItem);
                        itemsAdded = true;
                    }
                }

                BindingSource bs1 = new BindingSource();
                bs1.DataSource = _student.PersonalCare;
                dgPersonalCare.AutoGenerateColumns = false;
                dgPersonalCare.DataSource = bs1;// _student.Doctors.ConvertAll(c => c as Doctor);
                dgPersonalCare.Refresh();
                if (itemsAdded)
                {
                    btnSave.Enabled = true;
                    _changedOccured = true;
                }
            }
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e)
        {
            bool itemsAdded = false; ;
            StudentDefaults studentDefaults = new StudentDefaults(_defaults, 5);
            studentDefaults.ShowDialog();
            if (studentDefaults.DialogResult == DialogResult.OK)
            {
                string defaultNotes = string.Empty;
                foreach (StudentAbilityBase studentDefault in studentDefaults.SelectedList)
                {                    
                    if (!txtShortNotes.Text.Contains(studentDefault.Item))
                    {
                        defaultNotes += studentDefault.Item + Environment.NewLine + Environment.NewLine;
                        itemsAdded = true;
                    }
                }
                
                if (itemsAdded)
                {
                    btnSave.Enabled = true;
                    _changedOccured = true;

                    if(txtShortNotes.Text.Length>0)
                    {
                        txtShortNotes.Text += Environment.NewLine + Environment.NewLine + defaultNotes;
                    }
                    else
                    {
                        txtShortNotes.Text= defaultNotes;
                    }
                    _student.ShortNotes = txtShortNotes.Text;
                }
            }
        }





        //private void EnableFieldChangeEvent()
        //{
        //    var c = GetAll(this.Controls["tableLayoutPanel2"], typeof(TextBox));
        //    //var c = GetAll(this, typeof(TextBox));


        //    //foreach (Control ctrl in this.Controls)
        //    //{
        //    //    if (ctrl is TableLayoutPanel)
        //    //    {
        //    //        foreach (Control ctr11 in ctrl.Controls)
        //    //        {
        //    //            if (ctr11 is Panel)
        //    //            {
        //    //                foreach (Control ctr12 in ctr11.Controls)
        //    //                {
        //    //                    if (ctr12 is TabControl)
        //    //                    {

        //    //                    }
        //    //                }
        //    //            }
        //    //        }
        //    //    }
        //    //}

        //}

        //public IEnumerable<Control> GetAll(Control control, Type type)
        //{
        //    var controls = control.Controls.Cast<Control>();

        //    return controls.SelectMany(ctrl => GetAll(ctrl, type))
        //                              .Concat(controls)
        //                              .Where(c => c.GetType() == type);
        //}

        //private void ControlTextChanged(object sender, EventArgs e)
        //{

        //}
    }
}

//private void removeDoctorToolStripMenuItem_Click(object sender, EventArgs e)
//{
//    int rowindex = dgDoctor.CurrentCell.RowIndex;
//    int doctorid = (int)dgDoctor.Rows[rowindex].Cells[0].Value;
//    Person doctor;
//    if (doctorid == 0)
//    {
//        string doctorName = dgDoctor.Rows[rowindex].Cells[1].Value.ToString();
//        doctor = _student.Doctors.Find(x => x.FullName == doctorName);
//    }                
//    else
//        doctor = _student.Doctors.Find(x => x.PersonId == doctorid);

//    if (doctor != null)
//    {
//        if (MessageBox.Show("Are you sure you want to remove doctor '" + doctor.FullName + "' from this student?", "Remove Doctor", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
//        {
//            _saebc.Remove(doctor);
//            //DataBase db = new DoctorData();
//            //db.Remove(doctor, _student.PersonId);
//            //_student.Doctors = db.GetList(_student.PersonId);
//            fi.ValueChanged(sender, e);
//            PopulateDoctors();

//        }
//    }
//}

//private void removeNextOfKin_Click(object sender, EventArgs e)
//{
//    int rowindex = dgNextOfKin.CurrentCell.RowIndex;
//    int nextOfKinId = (int)dgNextOfKin.Rows[rowindex].Cells[0].Value;
//    Person nextOfKin;
//    if (nextOfKinId == 0)
//    {
//        string nextPfKinName = dgNextOfKin.Rows[rowindex].Cells[1].Value.ToString();
//        nextOfKin = _student.NextOfKin.Find(x => x.FirstName == nextPfKinName);
//    }
//    else
//        nextOfKin = _student.NextOfKin.Find(x => x.PersonId == nextOfKinId);

//    //Person nextOfKin = _student.NextOfKin.Find(x => x.PersonId == nextOfKinId);
//    if (nextOfKin != null)
//    {
//        if (MessageBox.Show("Are you sure you want to remove Next of kin '" + nextOfKin.FullName + "' from this student?", "Remove Next of kin", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
//        {
//            //DataBase db = new NextOfKinData();
//            //db.Remove(nextOfKin, _student.PersonId);
//            //_student.Doctors = db.GetList(_student.PersonId);
//            _saebc.Remove(nextOfKin);
//            fi.ValueChanged(sender, e);
//            PopulateNextOfKin();
//        }
//    }
//}

//private void RemoveEmergencyContact_Click(object sender, EventArgs e)
//{
//    int rowindex = dgEmergencyContact.CurrentCell.RowIndex;
//    int studentEmergencyContactId = (int)dgEmergencyContact.Rows[rowindex].Cells[0].Value;

//    EmergencyContact ec;
//    if (studentEmergencyContactId == 0)
//    {
//        string ecName = dgEmergencyContact.Rows[rowindex].Cells[1].Value.ToString();
//        ec = _student.EmergencyContacts.Find(x => x.FullName == ecName);
//    }
//    else
//        ec = _student.EmergencyContacts.Find(x => x.StudentEmergencyContactId == studentEmergencyContactId);


//    //EmergencyContact ec = _student.EmergencyContacts.Find(x => x.StudentEmergencyContactId == studentEmergencyContactId);




//    if (ec != null)
//    {
//        if (MessageBox.Show("Are you sure you want to remove emergency contact '" + ec.FullName + "' from this student?", "Remove Emergency Contact", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
//        {
//            //DataBase db = new EmergencyContactData();
//            //db.Remove(new Person(), studentEmergencyContactId);
//            //_student.EmergencyContacts= db.GetList(_student.PersonId).ConvertAll(x=>x as EmergencyContact);
//            _saebc.Remove(ec);
//            fi.ValueChanged(sender, e);
//            PopulateEmergencyContacts();
//        }
//    }
//}

//private void toolStripMenuItem2_Click(object sender, EventArgs e)
//{
//    int rowindex = dgMedicalCondition.CurrentCell.RowIndex;
//    int studentMedicalConsitionId = (int)dgMedicalCondition.Rows[rowindex].Cells[0].Value;

//    MedicalCondition mc;
//    if (studentMedicalConsitionId == 0)
//    {
//        string mcName = dgMedicalCondition.Rows[rowindex].Cells[1].Value.ToString();
//        mc = _student.MedicalConditions.Find(x => x.MedicalConditionName == mcName);
//    }
//    else
//        mc = _student.MedicalConditions.Find(x => x.StudentMedicalConditionId == studentMedicalConsitionId);

//    if (mc != null)
//    {
//        if (MessageBox.Show("Are you sure you want to remove medical condion '" + mc.MedicalConditionName + "' from this student?", "Remove Medical condition", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
//        {
//            //DataBase db = new EmergencyContactData();
//            //db.Remove(new Person(), studentEmergencyContactId);
//            //_student.EmergencyContacts= db.GetList(_student.PersonId).ConvertAll(x=>x as EmergencyContact);
//            _saebc.Remove(mc);
//            fi.ValueChanged(sender, e);
//            PopulateMedicalConditions();
//        }
//    }

//}

//if (dgEmergencyContacts.Rows[e.RowIndex].Cells["ECFullName"].Value==null)
//{
//    dgEmergencyContacts.Rows[e.RowIndex].ErrorText="Type Full name";
//    dgEmergencyContacts.CurrentCell = dgEmergencyContacts.Rows[e.RowIndex].Cells["ECFullName"];
//    e.Cancel = true;
//}


//if (dgEmergencyContacts.Rows[e.RowIndex].Cells["ECRelationship"].Value == null)
//{
//    dgEmergencyContacts.Rows[e.RowIndex].ErrorText = "Type relationship";
//    dgEmergencyContacts.CurrentCell = dgEmergencyContacts.Rows[e.RowIndex].Cells["ECRelationship"];
//    e.Cancel = true;
//}
