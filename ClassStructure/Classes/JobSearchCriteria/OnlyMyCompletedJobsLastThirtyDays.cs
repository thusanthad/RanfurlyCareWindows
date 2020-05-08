using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;
using Microsoft.Reporting.WinForms;

namespace ClassStructure
{
    public class OnlyMyCompletedJobsLastThirtyDays : JobSearchCriteria
    {

        public OnlyMyCompletedJobsLastThirtyDays()
            : base()
       {           
           SortColumnName = "JobCompletedDate";
           SortOrder = "DESC";
       }

        public override DataTable GetJobs()
        {
            return JobData.GetAllJobs(GenerateSQL());
        }

        private string GenerateSQL()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(SQLCommands.AllJobs);
            sb.Append(" WHERE CustomerName Like '%" + CustomerName + "%'");
            sb.Append(" AND DocketNo Like '%" + PrismNo + "%'");
            sb.Append(" AND JobStatusId = 3");
            sb.Append(" AND " + LoggedInPersonRole + "=" + CurrentUserId);
            sb.Append(" AND JobCompletedDate >=#" + FromDate.ToString("dd MMM yyyy") + "#");
            sb.Append(" AND JobCompletedDate <=#" + ToDate.ToString("dd MMM yyyy") + "#");
            sb.Append(" ORDER BY " + SortColumnName + " " + SortOrder);
            return sb.ToString();
        }
        public override ReportParameter[] GetReportParameters(string UserName)
        {
            ReportParameter[] param = new ReportParameter[4];
            param[0] = new ReportParameter("ReportHeader", "J.A.R.V.I.S. - Job Report");
            param[1] = new ReportParameter("DateRange", "Between " + FromDate.ToString("dd-MMM-yyyy") + " and " + ToDate.ToString("dd-MMM-yyyy"));
            param[2] = new ReportParameter("JobStatus", "Completed Jobs");
            string searchCriteria = "For " + UserName;
            if (CustomerName.Length > 0)
                searchCriteria += ", " + CustomerName;
            if (PrismNo.Length > 0)
                searchCriteria += ", " + PrismNo;
            param[3] = new ReportParameter("SearchFilter", searchCriteria); 
            return param;
        }

    }
}
