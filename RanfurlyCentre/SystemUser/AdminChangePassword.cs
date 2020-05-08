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
    public partial class AdminChangePassword : Form
    {
        protected Jarvis _jarvis;
        public AdminChangePassword(Jarvis jarvis)
        {
            InitializeComponent();
            _jarvis = jarvis;
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            PopulateUsers();
            //txtCurrentPassword.DataBindings.Add("Text", _jarvis.CurrentUser, "UserNewPassword");
        }

        private void PopulateUsers()
        {
            SystemUserData data = new SystemUserData();
            List<SystemUser> list = data.GetList().ConvertAll(x=>x as SystemUser);
            cmbUserName.ValueMember = "PersonId";
            cmbUserName.DisplayMember = "UserName";
            cmbUserName.DataSource = list;
            cmbUserName.SelectedIndex = -1;
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if(ValidateInput())
            {
                try
                {
                    SystemUser selectedUser = (SystemUser)cmbUserName.SelectedItem;
                    selectedUser.UserNewPassword = txtNewPassword.Text;
                    selectedUser.ChangePassword();
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            
        }

        private bool ValidateInput()
        {
            int errors = 0;
            ep.Clear();  
            if(cmbUserName.SelectedIndex ==-1)
            {
                errors += 1;
                ep.SetError(cmbUserName, "select user");
            }
            if (txtNewPassword.Text == string.Empty)
            {
                errors += 1;
                ep.SetError(txtNewPassword, "type new password");
            }
            if (txtConfirmPassword.Text == string.Empty)
            {
                errors += 1;
                ep.SetError(txtConfirmPassword, "type confirm password");
            }

            if(errors == 0)
            {
                bool returnValue = true; ;
                _jarvis.CurrentUser.UserNewPassword = txtNewPassword.Text;
                _jarvis.CurrentUser.UserConfirmPassword = txtConfirmPassword.Text;
                if (!_jarvis.CurrentUser.CheckPasswordMatch())
                {
                    ep.SetError(txtNewPassword, "Passwords don't match");
                    ep.SetError(txtConfirmPassword, "Passwords don't match");
                    txtNewPassword.Text = string.Empty;
                    txtConfirmPassword.Text = string.Empty;
                    returnValue = false;
                }
                return returnValue;
            }
            else
            {
                return false;
            }
        }
    }
}
