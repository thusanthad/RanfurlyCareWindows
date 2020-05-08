using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassStructure
{
    public class CampaignManager:SystemUser
    {
        public CampaignManager(JobSearchCriteria jsc)
        {
            Jsc = jsc;
            ApplyMyJobsOnly = true;
            //Jsc.SortColumnName = "JobCreatedDate";
            //Jsc.SortOrder = "DESC";
            //Jsc.LoggedInPersonRole = "CampaignManagerId";
                    }
        public override string ShowWelcomeMessage()
        {         
            JobSearchCriteria jsc1 = new OnlyMyCurrentJobs();
            jsc1.CurrentUserId = PersonId;
            jsc1.LoggedInPersonRole = "CampaignManagerId";
            return base.ShowWelcomeMessage(jsc1.GetJobs().Rows.Count); 
        }       

       public override DataTable GetMyJobs()
        {
            Jsc.CurrentUserId = PersonId;
            Jsc.LoggedInPersonRole = "CampaignManagerId";
            return Jsc.GetJobs();
        }
    }
}
