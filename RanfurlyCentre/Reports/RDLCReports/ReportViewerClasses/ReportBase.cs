using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;
using Microsoft.Reporting.WinForms;

namespace RanfurlyCentre
{
    public abstract class ReportViewerBase
    {
        protected Microsoft.Reporting.WinForms.ReportViewer _reportViewer;
        protected object _object;
        public abstract void ShowReport();

        public ReportViewerBase(Microsoft.Reporting.WinForms.ReportViewer reportViewer, object objectType)
        {
            _reportViewer = reportViewer;
            _object = objectType;
            ShowReport();
        }
    }
}
