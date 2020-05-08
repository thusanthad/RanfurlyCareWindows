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

namespace RanfurlyCentre
{
    public partial class ReportViewer : Form
    {
        protected List<Person> _list;
        public ReportViewer(List<Person> list)
        {
            InitializeComponent();
            _list = list;
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = _list;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "RanfurlyCentre.Resources.StudentReport.rdlc";
            this.reportViewer1.RefreshReport();
        }
    }
}
