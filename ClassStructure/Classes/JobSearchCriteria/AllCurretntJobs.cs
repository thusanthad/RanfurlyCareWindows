using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;
using Microsoft.Reporting.WinForms;

namespace ClassStructure
{
    public class AllCurrentJobs : JobSearchCriteria
    {
        public AllCurrentJobs()
            : base()
        {
            SortColumnName = "JobCreatedDate";
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
            sb.Append(" AND JobStatusId <> 3");
            sb.Append(" ORDER BY " + SortColumnName + " " + SortOrder);
            return sb.ToString();
        }

        public override ReportParameter[] GetReportParameters(string UserName)
        {
            ReportParameter[] param = new ReportParameter[4];
            param[0] = new ReportParameter("ReportHeader", "J.A.R.V.I.S. - Job Report");            
            param[1] = new ReportParameter("DateRange", "");
            param[2] = new ReportParameter("JobStatus", "All Current Jobs");               
            param[3] = new ReportParameter("SearchFilter", "");
            return param;
        }
    }
}
