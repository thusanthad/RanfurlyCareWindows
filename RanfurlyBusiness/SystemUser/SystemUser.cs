using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace RanfurlyBusiness
{
     public class SystemUser:Person
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        //public string FirstName { get; set; }
        //public string LastName { get; set; }
        //public string Email { get; set; }
        public string UserPassword { get; set; }
        public string UserNewPassword { get; set; }
        public string UserConfirmPassword { get; set; }
        // public int? PersonId { get; set; }        
        public string[] Roles { get; set; }
        public bool IsActive { get; set; }
        public List<UserRoleAction> RoleActions { get; set; }
        public List<UserRoleAction> OriginalRoleActions { get; set; }
        public bool IsStaffMember { get; set; }

        public SystemUser()
        {
            OriginalRoleActions = new List<UserRoleAction>();
        }

        public bool UserHasPermissionForAction(string RoleName, string RoleAction)
        {
            UserRoleAction userRoleAction;
            userRoleAction = RoleActions.Find(x => x.RoleId == 1);// RoleName && x.RoleAction == RoleAction);            
            if (userRoleAction != null)
                return true;
            else
            {
                userRoleAction = RoleActions.Find(x => x.Role == RoleName && x.RoleAction == RoleAction);
                if (userRoleAction != null)
                    return true;
                else
                {
                    MessageBox.Show("Please contact System Administrator to grant access", "Access Rights", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        public void ChangePassword()
        {
            SystemUserData data = new SystemUserData();
            data.ChangePassword(this);
        }

        public bool CheckPasswordMatch()
        {
            return String.Compare(UserNewPassword, UserConfirmPassword, false)==0;
        }

        public bool CheckCurrentPassword(string password)
        {
            return String.Compare(UserPassword, password, false) == 0;
        }
        //public string WelcomeMessage { get; set; }


        //public virtual string ShowWelcomeMessage()
        //{
        //    return string.Empty;
        //}

        //public virtual string ShowWelcomeMessage(int JobCount)
        //{           
        //    if (JobCount >= 1)
        //        WelcomeMessage = "Hi " + PersonFirstName + ", welcome to J.A.R.V.I.S." + "\r\n" + "\r\n" + "You have " + JobCount + " jobs waiting for you to attend to.";
        //    else
        //        WelcomeMessage = "Hi " + PersonFirstName + ", welcome to J.A.R.V.I.S." + "\r\n" + "\r\n" + "All your jobs are up to date.";
        //    return WelcomeMessage;
        //}

        //public virtual List<Job> GetJobsForSearch()
        //{
        //    return new List<Job>();
        //}

        //public virtual DataTable GetMyJobs()
        //{
        //    return new DataTable();
        //}

    }
}

