using System;
using System.Windows.Forms;
using RanfurlyBusiness;
using System.Collections.Generic;
using System.Linq;


namespace RanfurlyCentre
{
    public partial class EmergencyContactAdd : Form
    {
        protected Student _student;
        public EmergencyContactAddBase ecb;
        protected StudentAddEditBaseClass _saebc;
        public EmergencyContactAdd(StudentAddEditBaseClass saebc)
        {
            InitializeComponent();
            _saebc = saebc;
            _student = _saebc.Student;
            //if (type == "edit")
            //    ecb = new EmergencyContactAddToExistingStudent(_student);
            //else
            //    ecb = new EmergencyContactAddToNewStudent(_student);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddDoctor_Load(object sender, EventArgs e)
        {
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ep.Clear();
           
            if (txtEmergencyContactFullName.Text == string.Empty)
                ep.SetError(txtEmergencyContactFullName, "Type new emergency contact full name");
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
            if (txtRelationship.Text == string.Empty)
                ep.SetError(txtRelationship, "Type Relationship");

            bool failed = false;
            foreach (Control c in this.Controls)
            {
                if (ep.GetError(c).Length > 0)
                    failed = true;
            }

            if (failed)
            {
                return;
            }
            else
            {
                try
                {
                    var ec = new EmergencyContact
                    {
                        PersonId = 0,
                        FullName = txtEmergencyContactFullName.Text,
                        Addr1 = txtAddr1.Text,
                        Addr2 = txtAddr2.Text,
                        Addr3 = txtAddr3.Text,
                        Addr4 = txtAddr4.Text,
                        Postcode = txtPostcode.Text,
                        Phone = txtPhone.Text,                       
                        Relationship = txtRelationship.Text
                    };

                    ec.FullAddress = ec.GetFullAddress();
                    _saebc.Add(ec);
                    //DataBase db = new EmergencyContactData();
                    //ec.StudentEmergencyContactId = db.Add(ec, _student.PersonId);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SelectOption()
        {
            ep.Clear();
            txtEmergencyContactFullName.Text = string.Empty;
            txtAddr1.Text = string.Empty;
            txtAddr2.Text = string.Empty;
            txtAddr3.Text = string.Empty;
            txtAddr4.Text = string.Empty;
            txtPostcode.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtRelationship.Text = string.Empty;
        }
    }
}
