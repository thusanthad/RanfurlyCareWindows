using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using RanfurlyBusiness;
using Microsoft.Reporting.WinForms;

namespace RanfurlyCentre
{
    public partial class StudentReportViewer : Form
    {
        protected Student _student;
        public StudentReportViewer(Student student)
        {
            InitializeComponent();
            _student = student;
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
           // bindingSource1.DataSource = _student.Doctors;

            //studentBindingSource.DataSource = student;
            //ReportParameter[] p = new ReportParameter[1];
            //p[0] = new ReportParameter("FirstName", "gfgfdgdfg", true);
            
            reportViewer1.LocalReport.ReportEmbeddedResource = "RanfurlyCentre.Application.Reports.StudentReport.Report1.rdlc";
            //this.reportViewer1.LocalReport.SetParameters(p);
            //this.reportViewer1.LocalReport.DisplayName = "Student Report for '"+ student.FullName + "'";
            reportViewer1.RefreshReport();

            //ReportParameter[] p = new ReportParameter[8];
            //p[0] = new ReportParameter("FullName", student.FullName, true);            

            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "DMDataMaster.Reports.AuditReport.rdlc";
            //this.reportViewer1.LocalReport.SetParameters(p);
            //this.reportViewer1.LocalReport.DisplayName = currentJob.CustomerName + "_" + currentJob.PrismNumber + "_AuditReport";
            //this.reportViewer1.RefreshReport();
        }
    }
}
