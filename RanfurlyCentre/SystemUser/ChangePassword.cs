using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RanfurlyCentre
{
    public partial class ChangePassword : Form
    {
        protected Jarvis _jarvis;
        public ChangePassword(Jarvis jarvis)
        {
            InitializeComponent();
            _jarvis = jarvis;
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {
            txtUserName.DataBindings.Add("Text", _jarvis.CurrentUser,"UserName");
            //txtCurrentPassword.DataBindings.Add("Text", _jarvis.CurrentUser, "UserNewPassword");
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            if(ValidateInput())
            {
                try
                {
                    _jarvis.CurrentUser.ChangePassword();
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
            if(txtCurrentPassword.Text == string.Empty)
            {
                errors += 1;
                ep.SetError(txtCurrentPassword, "type current password");
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

                if(!_jarvis.CurrentUser.CheckCurrentPassword(txtCurrentPassword.Text))
                {
                    ep.SetError(txtCurrentPassword, "Incorrect current password");
                    txtCurrentPassword.Text = string.Empty;
                    returnValue = false;
                }

                else if (!_jarvis.CurrentUser.CheckPasswordMatch())
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
