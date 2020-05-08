using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Reporting.WinForms;
using System.Data;
using RanfurlyBusiness;

namespace RanfurlyBusiness
{
    public abstract class ReportProcessor
    {
        public ReportDataSource Rds {get;set;}
        public ReportParameter[] ReportParam { get; set; }
        public string ReportName { get; set; }
        public SystemUser CurrentUser { get; set; }        

        public virtual void ProcessReport()
        {
            //DataTable dt =  CurrentUser.GetMyJobs();            
            //ReportDataSource rds1 = new ReportDataSource();
            //rds1.Name = "JobData";
            //rds1.Value = dt;
            //Rds = rds1;          
        }

        
    }
}
