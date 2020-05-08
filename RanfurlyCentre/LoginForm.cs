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
    public partial class LoginForm : Form
    {
        public SystemUser CurrentUser { get; set; }
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (CheckIfLoginDetailsProvided())
            {
                CurrentUser = SystemUserData.GetSystemUser(txtUsername.Text, txtPassword.Text);
                if (CurrentUser == null)
                {
                  //  MessageBox.Show("Couldn't authenticate user", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CouldntAuthenticateUser("Password or Username is incorrect");
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                }
                else
                {
                    if (String.Compare(txtPassword.Text, CurrentUser.UserPassword) == 0)
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    else
                    {
                        CouldntAuthenticateUser("Password or Username is incorrect");
                        //MessageBox.Show("Couldn't authenticate user", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.DialogResult = System.Windows.Forms.DialogResult.None;
                    }
                }
            }
            else
            {
                CouldntAuthenticateUser("Please provide login credentials");
               // MessageBox.Show("Please provide login credentials", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = System.Windows.Forms.DialogResult.None;
            }

        }

        private bool CheckIfLoginDetailsProvided()
        {
            bool loginDetailsProvided = true;
            ep.Clear();
            if (txtUsername.Text == string.Empty)
            {
                ep.SetError(txtUsername, "Please type the Username");
                loginDetailsProvided = false;
            }

            if (txtPassword.Text == string.Empty)
            {
                ep.SetError(txtPassword, "Please type the password");
                loginDetailsProvided = false;
            }

            return loginDetailsProvided; 
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void CouldntAuthenticateUser(string Message)
        {
            ep.Clear();
            ep.SetError(txtUsername, Message);
            ep.SetError(txtPassword, Message);
           
        }
    }
}
