using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace RanfurlyBusiness
{
     public class SystemUser
    {
        public string UserName { get; set; }        
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string UserPassword { get; set; }
        public string PersonFullName { get; set; }
        public string PersonFirstName { get; set; }
        public string PersonLastName { get; set; }
        public int PersonId { get; set; }        
        public string[] Roles { get; set; }
        public string WelcomeMessage { get; set; }
        //public JobSearchCriteria Jsc { get; set; }
        public bool ApplyMyJobsOnly { get; set; }

        public virtual string ShowWelcomeMessage()
        {
            return string.Empty;
        }

        public virtual string ShowWelcomeMessage(int JobCount)
        {           
            if (JobCount >= 1)
                WelcomeMessage = "Hi " + PersonFirstName + ", welcome to J.A.R.V.I.S." + "\r\n" + "\r\n" + "You have " + JobCount + " jobs waiting for you to attend to.";
            else
                WelcomeMessage = "Hi " + PersonFirstName + ", welcome to J.A.R.V.I.S." + "\r\n" + "\r\n" + "All your jobs are up to date.";
            return WelcomeMessage;
        }

        //public virtual List<Job> GetJobsForSearch()
        //{
        //    return new List<Job>();
        //}
       
        public virtual DataTable GetMyJobs()
        {
            return new DataTable();
        }

    }
}

