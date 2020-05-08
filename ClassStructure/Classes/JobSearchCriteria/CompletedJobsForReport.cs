using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;
using Microsoft.Reporting.WinForms;

namespace ClassStructure
{
    public class CompletedJobsForReport:JobSearchCriteria
    {
        public override DataTable GetJobs()
        {
            return JobData.GetAllJobs(GenerateSQL());
        }

        private string GenerateSQL()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(SQLCommands.AllJobs);
            sb.Append(" WHERE CustomerName Like '%" + CustomerName + "%'");
            sb.Append(" AND Programmer Like '%" + DeveloperName + "%'");
            sb.Append(" AND CampaignManager Like '%" + CampaignManagerName + "%'");
            sb.Append(" AND JobStatusId = 3");
            sb.Append(" AND JobCompletedDate >=#" + FromDate.ToString("dd MMM yyyy") + "#");
            sb.Append(" AND JobCompletedDate <=#" + ToDate.ToString("dd MMM yyyy") + "#");
            sb.Append(" ORDER BY " + SortColumnName + " " + SortOrder);
            return sb.ToString();
        }

        public override ReportParameter[] GetReportParameters(string UserName)
        {
            ReportParameter[] param = new ReportParameter[4];
            param[0] = new ReportParameter("ReportHeader", "J.A.R.V.I.S. - Job Report");
            param[1] = new ReportParameter("DateRange", "Between " + FromDate.ToString("dd MMM yyyy") + " and " + ToDate.ToString("dd MMM yyyy"));
            param[2] = new ReportParameter("JobStatus", "Completed Jobs");
            string searchCriteria = string.Empty;
            if (CustomerName.Length != 0 || CampaignManagerName.Length != 0 || DeveloperName.Length != 0)
            {
                searchCriteria = "Search Filter - ";
                string str = string.Empty;
                if (CustomerName.Length > 0)
                    str += ", " + CustomerName;
                if (CampaignManagerName.Length > 0)
                    str += ", " + CampaignManagerName;
                if (DeveloperName.Length > 0)
                    str += ", " + DeveloperName;
                if (str.Substring(0, 1) == ",")
                    str = str.Substring(2, str.Length - 2);
                searchCriteria += str;
            }
            param[3] = new ReportParameter("SearchFilter", searchCriteria);
            return param;
        }

    }
}
