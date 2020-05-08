using System;
using System.Windows.Forms;
using RanfurlyBusiness;
using System.Collections.Generic;
using System.Linq;


namespace RanfurlyCentre
{
    public partial class ProfessionalAddEdit : Form
    {
        public Specialist Specialist { get; set; }
        public int DefaultSelectedValue { get; set; }
        protected AddEditProfessionalBase _addEditProfessional;  

        public ProfessionalAddEdit(Specialist person, string addEdit )
        {
            InitializeComponent();
            Specialist = person;
            if (addEdit == "add")
            {;
                //Text = "Add Specialist";
                _addEditProfessional = new AddNewProfessional(this);                
            }
                
            else
            {
               // Text = "Edit Specialist";
                _addEditProfessional = new EditProfessional(this);
            }

                
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void AddDoctor_Load(object sender, EventArgs e)
        {
            PopulateComboBox();
        }

        private void PopulateComboBox()
        {
            SpecialistData ps = new SpecialistData();
            List<ProfessionalServiceType> list = ps.GetProfessionalServiceTypes();
            List<ProfessionalServiceType> listExcludingDoctors = list.FindAll(x => x.ProfessionalServiceProviderTypeId != 1);
            cmbPersonType.DataSource = listExcludingDoctors;
            cmbPersonType.DisplayMember = "ProfessionalServiceProviderType";
            cmbPersonType.ValueMember = "ProfessionalServiceProviderTypeId";
            cmbPersonType.Refresh();

            cmbPersonType.DataBindings.Add("SelectedValue", Specialist, "ProfessionalServiceProviderTypeId");
            if (DefaultSelectedValue != 0)
                cmbPersonType.SelectedValue = DefaultSelectedValue;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            if (_addEditProfessional.ValidateInput())
            {
                try
                {
                    Specialist.SpecialistType = cmbPersonType.Text;
                    _addEditProfessional.Commit();
                    //DataBase db = new DoctorData();

                    //_doctor.FullName = txtDoctorName.Text;
                    //_doctor.Addr1 = txtAddr1.Text;
                    //_doctor.Addr2 = txtAddr2.Text;
                    //_doctor.Addr3 = txtAddr3.Text;
                    //_doctor.Addr4 = txtAddr4.Text;
                    //_doctor.Postcode = txtPostcode.Text;
                    //_doctor.Phone = txtPhone.Text;
                    //_doctor.Email = txtEmail.Text;

                    //db.Update(_doctor);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
