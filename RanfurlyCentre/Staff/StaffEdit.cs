using System;
using System.Windows.Forms;
using RanfurlyBusiness;
using System.Collections.Generic;
using System.Linq;


namespace RanfurlyCentre
{
    public partial class StaffEdit : Form
    {
        protected Person _staff;
        //protected List<Doctor> _doctorList;

        public StaffEdit(Person staff )
        {
            InitializeComponent();
            _staff = staff;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddDoctor_Load(object sender, EventArgs e)
        {
            
            PopulateTitle();
            PopulateStaff();
            PopulateWorkCentres();
        }

        private void PopulateTitle()
        {
            TitleData td = new TitleData();
            cmbTitle.DataSource = td.GetList();

            cmbTitle.DisplayMember = "TitleName";
            cmbTitle.ValueMember = "TitleId";

        }

        private void PopulateStaff()
        {
            txtFirstName.DataBindings.Add("Text", _staff, "FirstName");
            txtLastName.DataBindings.Add("Text", _staff, "LastName");
            cmbTitle.DataBindings.Add("SelectedValue", _staff, "TitleId");
            txtAddr1.DataBindings.Add("Text", _staff, "Addr1");
            txtAddr2.DataBindings.Add("Text", _staff, "Addr2");
            txtAddr3.DataBindings.Add("Text", _staff, "Addr3");
            txtAddr4.DataBindings.Add("Text", _staff, "Addr4");
            txtPostcode.DataBindings.Add("Text", _staff, "Postcode");
            txtHomePhone.DataBindings.Add("Text", _staff, "HomePhone");
            txtMobilePhone.DataBindings.Add("Text", _staff, "MobilePhone");
            txtMobilePhone.DataBindings.Add("Text", _staff, "Email");
        }

        private void PopulateWorkCentres()
        {
            Staff staff = (Staff)_staff;
            dgWorkCentres.DataSource = staff.WorkCentres;
        }

        private void CmbFullName_SelectedIndexChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    DataBase db = new StaffData();
                    
                    _staff.FirstName = txtFirstName.Text;
                    _staff.LastName = txtLastName.Text;
                    _staff.Addr1=txtAddr1.Text;
                    _staff.Addr2 = txtAddr2.Text;
                    _staff.Addr3 = txtAddr3.Text;
                    _staff.Addr4 = txtAddr4.Text;
                    _staff.Postcode = txtPostcode.Text;
                    _staff.Phone = txtHomePhone.Text;
                    _staff.Email = txtMobilePhone.Text;

                    db.Update(_staff);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateInput()
        {
            ep.Clear();
            if (txtFirstName.Text == string.Empty)
                ep.SetError(txtFirstName, "Type new first name");
            if (txtLastName.Text == string.Empty)
                ep.SetError(txtLastName, "Type new last name");
            if (txtAddr1.Text == string.Empty)
                ep.SetError(txtAddr1, "Type Addr1");
            if (txtAddr2.Text == string.Empty)
                ep.SetError(txtAddr2, "Type Addr2");
            if (txtAddr3.Text == string.Empty)
                ep.SetError(txtAddr3, "Type Addr3");
            if (txtPostcode.Text == string.Empty)
                ep.SetError(txtPostcode, "Type Postcode");
            if (txtMobilePhone.Text == string.Empty)
                ep.SetError(txtMobilePhone, "Type Mobile Phone");

            bool failed = true;
            foreach (Control c in this.tabPage1.Controls)
            {
                if (ep.GetError(c).Length > 0)
                {
                    failed = false;
                    break ;
                }
            }
            return failed;
        }

        private void addDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void removeDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
