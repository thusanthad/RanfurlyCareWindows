using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassStructure
{
   public class AnyOtherUser:SystemUser
    {
       public AnyOtherUser(JobSearchCriteria jsc)
        {
            Jsc = jsc;
            ApplyMyJobsOnly = false;
            Jsc.SortColumnName = "JobCreatedDate";
            Jsc.SortOrder = "DESC";  
        }

       public override string ShowWelcomeMessage()
       {          
          return "Hi " + PersonFirstName + ", welcome to J.A.R.V.I.S.";           
       }
   
           public override DataTable GetMyJobs()
       {
           return Jsc.GetJobs();
       }
    }
}
