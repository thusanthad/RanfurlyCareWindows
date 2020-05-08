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
    public partial class ReportViewer : Form
    {
        protected List<Person> _list;
        protected Student _student;
        public ReportViewer(List<Person> list)
        {
            InitializeComponent();
            _list = list;
        }

        public ReportViewer(Student student)
        {
            InitializeComponent();
            _student = student;
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            _student.FullName = _student.GetFullName();
            _student.FullAddress = _student.GetFullAddress();
            ReportDataSource rdsDoctors = new ReportDataSource();
            rdsDoctors.Name = "Doctors";
            rdsDoctors.Value = _student.Doctors;

            ReportDataSource rdsNextOfKin = new ReportDataSource();
            rdsNextOfKin.Name = "NextOfKin";
            rdsNextOfKin.Value = _student.NextOfKin;

            ReportParameter[] p = new ReportParameter[11];
            p[0] = new ReportParameter("FullName", _student.FullName, true);
            p[1] = new ReportParameter("Gender", _student.Gender, true);
            p[2] = new ReportParameter("DateOfBirth", _student.DateOfBirth?.ToString("dd MMM yyyy"), true);
            p[3] = new ReportParameter("Ethnicity", _student.Ethnicity, true);
            p[4] = new ReportParameter("AdmittedToCareCentre", _student.AdmittedToActivityCentre?.ToString("dd MMM yyyy"), true);
            p[5] = new ReportParameter("PlaceOfBirth", _student.PlaceOfBirth, true);
            p[6] = new ReportParameter("AdmittedToResidence", _student.AdmittedToResidence?.ToString("dd MMM yyyy"), true);
            p[7] = new ReportParameter("NHINumber", _student.NHINumber, true);
            p[8] = new ReportParameter("HomePhone", _student.HomePhone, true);
            p[9] = new ReportParameter("MobilePhone", _student.MobilePhone, true);
            p[10] = new ReportParameter("FullAddress", _student.FullAddress, true);

            this.reportViewer1.LocalReport.ReportEmbeddedResource = "RanfurlyCentre.Application.Reports.RDLCReports.IndividualStudentReport.rdlc";
            this.reportViewer1.LocalReport.SetParameters(p);
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(rdsDoctors);
            this.reportViewer1.LocalReport.DataSources.Add(rdsNextOfKin);
            this.reportViewer1.LocalReport.DisplayName = "Student Report for '"+ _student.FullName + "'";
            this.reportViewer1.RefreshReport();

            //ReportParameter[] p = new ReportParameter[8];
            //p[0] = new ReportParameter("FullName", student.FullName, true);            

            //this.reportViewer1.LocalReport.ReportEmbeddedResource = "DMDataMaster.Reports.AuditReport.rdlc";
            //this.reportViewer1.LocalReport.SetParameters(p);
            //this.reportViewer1.LocalReport.DisplayName = currentJob.CustomerName + "_" + currentJob.PrismNumber + "_AuditReport";
            //this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
