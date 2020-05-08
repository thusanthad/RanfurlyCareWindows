using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;
using Microsoft.Reporting.WinForms;

namespace RanfurlyCentre
{
    public class YearlyResidentRollCallByResident : ReportViewerBase
    {
        public YearlyResidentRollCallByResident(Microsoft.Reporting.WinForms.ReportViewer reportViewer, object objectType):base(reportViewer,objectType)
        {
            
        }

        public override void ShowReport()
        {
            ReportContainer rc = (ReportContainer)_object;
            ReportParameter[] p = new ReportParameter[1];
            p[0] = new ReportParameter("Year", rc.Year.ToString(), true);
            //p[1] = new ReportParameter("Month", rc.Month.ToString(), true);

            ReportDataSource dataSource = new ReportDataSource();
            dataSource.Name = "ResidentRollCall";
            dataSource.Value = rc.RollCallSummaryList.ConvertAll(x=>x as ResidentYearlyCallSummaryByResident);
                        
            _reportViewer.LocalReport.ReportEmbeddedResource = "RanfurlyCentre.Reports.RDLCReports.YearlyResidentRollCallReportByResident.rdlc";
            _reportViewer.LocalReport.SetParameters(p);
            _reportViewer.LocalReport.DataSources.Clear();
            _reportViewer.LocalReport.DataSources.Add(dataSource);

            _reportViewer.LocalReport.DisplayName = "Yearly Resident Roll Call Report by Resident for - " + rc.Year.ToString() + "'";
            _reportViewer.RefreshReport();
            //_reportViewer.RefreshReport();
        }
    }

    
}
