using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;
using Microsoft.Reporting.WinForms;

namespace RanfurlyCentre
{
    public class YearlyResidentRollCallByMonth : ReportViewerBase
    {
        public YearlyResidentRollCallByMonth(Microsoft.Reporting.WinForms.ReportViewer reportViewer, object objectType):base(reportViewer,objectType)
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
            List<ResidentYearlyCallSummaryByMonth> listNew = rc.RollCallSummaryList.ConvertAll(x => x as ResidentYearlyCallSummaryByMonth);
            listNew.ForEach(x => x.UpdateMonthName());
            listNew = listNew.OrderBy(x => x.MonthNumber).ToList();
            dataSource.Value = listNew;// rc.RollCallSummaryList.ConvertAll(x=>x as ResidentYearlyCallSummaryByMonth);
                        
            _reportViewer.LocalReport.ReportEmbeddedResource = "RanfurlyCentre.Reports.RDLCReports.YearlyResidentRollCallReportByMonth.rdlc";
            _reportViewer.LocalReport.SetParameters(p);
            _reportViewer.LocalReport.DataSources.Clear();
            _reportViewer.LocalReport.DataSources.Add(dataSource);

            _reportViewer.LocalReport.DisplayName = "Yearly Resident Roll Call Report by Month for - " + rc.Year.ToString() + "'";
            _reportViewer.RefreshReport();
            //_reportViewer.RefreshReport();
        }
    }

    
}
