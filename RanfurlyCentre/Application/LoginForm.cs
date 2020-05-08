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
        //public SystemUser CurrentUser { get; set; }
        public Jarvis Jarvis { get; set; }
        public LoginForm()
        {
            InitializeComponent();
            Jarvis = new Jarvis();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {

            if (CheckIfLoginDetailsProvided())
            {
                SystemUserData sd = new SystemUserData();
                Jarvis.CurrentUser = sd.GetSystemUser(txtUsername.Text, txtPassword.Text);
                if (Jarvis.CurrentUser == null)
                {
                  //  MessageBox.Show("Couldn't authenticate user", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CouldntAuthenticateUser("Password or Username is incorrect");
                    this.DialogResult = System.Windows.Forms.DialogResult.None;
                }
                else
                {
                    if (String.Compare(txtPassword.Text, Jarvis.CurrentUser.UserPassword) == 0)
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
            int daysToExpire = Jarvis.License.GetDaysToExpire();
            if (daysToExpire < 0)
            {
                MessageBox.Show("Sorry, your licese has expired. Please contact supplier and renew license", "© " + Jarvis.License.LicensedTo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
                
            else if (daysToExpire > 0 && daysToExpire <= 30)
            {
                MessageBox.Show("Your license will expire in " + (int)daysToExpire + " day(s). Please contact supplier and renew license", "© " + Jarvis.License.LicensedTo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //DoctorAppointment da = new DoctorAppointment();
            //da.Purpose = "doctor's appointment";
            ////da.UpdateAporstorpe<DoctorAppointment>(da);
            //CommonFunctions.UpdateAporstorpe<DoctorAppointment>(da);
        }

        private void CouldntAuthenticateUser(string Message)
        {
            ep.Clear();
            ep.SetError(txtUsername, Message);
            ep.SetError(txtPassword, Message);
           
        }
    }
}
