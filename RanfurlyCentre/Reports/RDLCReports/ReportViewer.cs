using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using RanfurlyBusiness;
using Microsoft.Reporting.WinForms;

namespace RanfurlyCentre
{
    public partial class ReportViewer : Form
    {
        protected List<Person> _list;
        protected object _object;
        public Jarvis Jarvis { get; set; }
        public ReportViewer(List<Person> list)             
        {
            InitializeComponent();
            _list = list;
        }

        public ReportViewer(object objectType)
        {
            InitializeComponent();
            _object = objectType;
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            try
            {
                ReportViewerBase rb;
                if (_object is Student)
                {
                    Student student = (Student)_object;
                    rb = new IndividualStudentReport(this.reportViewer1, student);
                }
                else if (_object is ReportContainer)
                {                                  
                    ReportContainer obj = (ReportContainer)_object;
                    if (obj.RollCallSummaryList[0] is ResidentMonthlyCallSummary)
                        rb = new MonthlyResidentRollCall(this.reportViewer1, obj);
                    else if (obj.RollCallSummaryList[0] is ResidentYearlyCallSummaryByResident)
                        rb = new YearlyResidentRollCallByResident(this.reportViewer1, obj);
                    else if (obj.RollCallSummaryList[0] is ResidentYearlyCallSummaryByMonth)
                        rb = new YearlyResidentRollCallByMonth(this.reportViewer1, obj);
                    else
                        throw new Exception("Cannot find report type");
                }




                Byte[] mybytes = this.reportViewer1.LocalReport.Render("PDF");
                string filename = Jarvis.OutputFileLocation + this.reportViewer1.LocalReport.DisplayName + ".pdf";
                using (FileStream fs = File.Create(filename))
                {
                    fs.Write(mybytes, 0, mybytes.Length);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
