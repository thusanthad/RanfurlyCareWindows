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
    public partial class AddNewSystemUser : Form
    {
        protected List<SystemUser> _systemUsers;

        public AddNewSystemUser(List<SystemUser> systemUsers)
        {
            InitializeComponent();
            _systemUsers = systemUsers;
        }

        private void isStaffMember_CheckedChanged(object sender, EventArgs e)
        {
            if (isStaffMember.Checked)
            {
                cmbStaff.Enabled = true;
                txtFirstName.Enabled = false;
                txtLastName.Enabled = false;
                //txtEmail.Enabled = false;               
            }
            else
            {
                cmbStaff.Enabled = false;
                txtFirstName.Enabled = true;
                txtLastName.Enabled = true;
               // txtEmail.Enabled = true;

            }
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtUserName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            cmbStaff.SelectedIndex = -1;
        }

        private void cmbStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            ep.Clear();
            if (cmbStaff.SelectedIndex != -1)
            {
                Staff staff = (Staff)cmbStaff.SelectedItem;                
                txtFirstName.Text = staff.FirstName;
                txtLastName.Text = staff.LastName;
                txtEmail.Text = staff.Email; ;
                txtUserName.Text = staff.FirstName.Replace(" ","") + staff.LastName.Substring(0, 1).ToUpper(); 
            }
            
        }

        private void AddNewSystemUser_Load(object sender, EventArgs e)
        {
            isStaffMember_CheckedChanged(sender, e);
            PopulateStaff();
        }

        private void PopulateStaff()
        {
            cmbStaff.SelectedIndexChanged -= cmbStaff_SelectedIndexChanged;
            DataBase db = new StaffData();            
            List<Staff> staffList = db.GetList().ConvertAll(x => x as Staff); 
            cmbStaff.DataSource = GetStaffListWithoutSystemUserLogin(staffList);
            cmbStaff.DisplayMember = "FullName";
            cmbStaff.ValueMember = "PersonId";
            cmbStaff.SelectedIndex = -1;
            cmbStaff.SelectedIndexChanged += cmbStaff_SelectedIndexChanged;
        }

        private List<Staff> GetStaffListWithoutSystemUserLogin(List<Staff> staffList)
        {
            List<Staff> newStaffList = new List<Staff>();
            foreach (Staff staff in staffList)
            {
                SystemUser user = _systemUsers.Find(x => x.PersonId == staff.PersonId);
                if (user == null)
                {
                    newStaffList.Add(staff);
                }
            }
            return newStaffList;
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            
            if (ValidateControls())
            {
                try
                {
                    SystemUser systemUser = new SystemUser();
                    if (cmbStaff.SelectedIndex != -1)
                    {
                        Staff staff = (Staff)cmbStaff.SelectedItem;
                        systemUser.PersonId = staff.PersonId;
                        if (staff.Email == string.Empty)
                        {
                            staff.Email = txtEmail.Text;
                            StaffData sd = new StaffData();
                            sd.Update(staff);
                        }
                    }

                    SystemUserData sud = new SystemUserData();                    
                    systemUser.FirstName = txtFirstName.Text;
                    systemUser.LastName = txtLastName.Text;
                    systemUser.UserName = txtUserName.Text;
                    systemUser.Email = txtEmail.Text;
                    systemUser.UserPassword = "password";
                    
                    sud.CreateUser(systemUser);
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool ValidateControls()
        {
            ep.Clear();
            int errorCount = 0;
            if (txtFirstName.Text == string.Empty)
            {
                ep.SetError(txtFirstName, "Type first name");
                errorCount += 1;
            }
                
            if (txtLastName.Text == string.Empty)
            {
                ep.SetError(txtLastName, "Type last name");
                errorCount += 1;
            }
                
            if (txtUserName.Text == string.Empty)
            {
                ep.SetError(txtUserName, "Type user name");
                errorCount += 1;
            }
                
            if (txtEmail.Text == string.Empty)
            {
                ep.SetError(txtEmail, "Type email");
                errorCount += 1;
            }

            return errorCount == 0;
        }

        

        private void txtFirstName_Validated(object sender, EventArgs e)
        {
            ValidateUserName();
        }

        private void txtLastName_Validated(object sender, EventArgs e)
        {
            ValidateUserName();
        }

        private void ValidateUserName()
        {
            if (txtFirstName.Text != string.Empty && txtLastName.Text != string.Empty)
            {
                string firstChar = txtFirstName.Text.Replace(" ", "").Substring(0, 1).ToUpper();
                string restOfFirstName = txtFirstName.Text.Replace(" ", "").Substring(1, txtFirstName.Text.Length-1).ToLower();
                string firstName = firstChar + restOfFirstName;
                txtUserName.Text = firstName + txtLastName.Text.Substring(0, 1).ToUpper();
            }
                
        }
    }
}

