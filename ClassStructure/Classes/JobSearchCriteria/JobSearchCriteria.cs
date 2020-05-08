using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.Reporting.WinForms;


namespace ClassStructure
{
    public class JobSearchCriteria
    {
        public string CustomerName { get; set; }
        public string DeveloperName { get; set; }
        public string CampaignManagerName { get; set; }
        public string PrismNo { get; set; }
        public string SortColumnName { get; set; }
        public string SortOrder { get; set; }
        public string LoggedInPersonRole { get; set; }
        public int CurrentUserId { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        public JobSearchCriteria()
        {
            CustomerName = string.Empty;
            DeveloperName = string.Empty;
            CampaignManagerName = string.Empty;
            PrismNo = string.Empty;
        }
       
        public virtual DataTable GetJobs()
        {
            return new DataTable();
        }
        public virtual ReportParameter[] GetReportParameters(string userName)
        {
            return new ReportParameter[1];
        }


    }
}