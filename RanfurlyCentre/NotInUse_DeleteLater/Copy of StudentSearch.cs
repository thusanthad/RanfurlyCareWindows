using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public partial class CopyOfStudentSearch : Form
    {         
       // SystemUser currentUser;
        public Form _mdiForm {get;set;}
        private BindingSource _bs;
        private List<Person> _fullPersonList;
        //JobSearchCriteria originalJsc;

        public CopyOfStudentSearch()
        {
            InitializeComponent();
            _bs = new BindingSource();
            //currentUser = user;
            //originalJsc = user.Jsc;
        }       

        private void JobSearch_Load(object sender, EventArgs e)
        {
            //label4.Text = CommonVariables.GetConnectionString();
            LoadFullList();
           
            //chkMyJobsOnly.Checked = currentUser.ApplyMyJobsOnly;
            //chkMyJobsOnly.Enabled = currentUser.ApplyMyJobsOnly;

            


            //chkMyJobsOnly.Checked = currentUser.Jsc.IsLastSearchedJobsOnlyMine; // ApplyMyJobsOnly;            
           // chkMyJobsOnly.Enabled = currentUser.ApplyMyJobsOnly;
        //    lastSortColumnName =currentUser.Jsc.SortColumnName;
        //    lastSortOrder = currentUser.Jsc.SortOrder;
          //  txtCustomer.Text = currentUser.Jsc.CustomerName;
          //  txtPrismNo.Text = currentUser.Jsc.PrismNo;

            //if (currentUser.Jsc.IsLastSearchedJobStatusCurrent)
            //    rdCurrent.Checked = true;
            //else
            //    rdCompleted.Checked = true;

            //
            //this.chkMyJobsOnly.CheckedChanged += new System.EventHandler(this.chkMyJobsCheckedChanged);

            
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //txtCustomer.Text = string.Empty ;
            txtSearch.Text = string.Empty ;
            //SetSearchType();
            LoadFullList();
        }

        public void LoadFullList()
        {
            ep.SetError(dataGridView1, "");
            try
            {
                dataGridView1.AutoGenerateColumns = false;
                DataBase db;
                if(rdStudents.Checked)
                    db = new StudenData();
                else
                    db = new StaffData();

                _fullPersonList = db.GetList();
                _bs.DataSource = _fullPersonList;
                dataGridView1.DataSource = _bs.DataSource;

                if (Application.OpenForms["MDIMainForm"] as MDIMainForm != null)
                {
                    MDIMainForm mfrm = Application.OpenForms["MDIMainForm"] as MDIMainForm;
                }
                lblJobCount.Text = "Student Count - " + dataGridView1.Rows.Count.ToString(); 
            }
            catch (Exception ex)
            {
                ep.SetError(dataGridView1, ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       // private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
       // {
       //     currentUser.Jsc.SortColumnName = dataGridView1.Columns[e.ColumnIndex].DataPropertyName;
       //     if (currentUser.Jsc.SortOrder == "ASC")
       //         currentUser.Jsc.SortOrder = "DESC";
       //    else
       //         currentUser.Jsc.SortOrder = "ASC";
           
       ////     LoadData();
         
       // }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //EditJob frm = new EditJob();
            //frm.IntJobId = (int)dataGridView1.Rows[e.RowIndex].Cells["JobId"].Value;
            //frm.MdiParent = MdiForm;
            //frm.Dock = DockStyle.Fill;
            //frm.FormBorderStyle = FormBorderStyle.None;
            //frm.Show();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text != string.Empty)
            {
                List<Person> list = _fullPersonList.FindAll(x => x.PreferredName.ToUpper().Contains(txtSearch.Text.ToUpper()) || x.FirstName.ToUpper().Contains(txtSearch.Text.ToUpper()) || x.LastName.ToUpper().Contains(txtSearch.Text.ToUpper()));
                //_bs.Filter = "FirstName=%'" + txtSearch.Text + "'";
                dataGridView1.DataSource = null;
                _bs.DataSource = list;                
                dataGridView1.DataSource = _bs;
                dataGridView1.Refresh();

            }
            //SetSearchType();
            //LoadFullList();
        }
       

        //private void chkMyJobsCheckedChanged(object sender, EventArgs e)
        //{
        //    LoadFullList();
        //    //SetSearchType();
        //    //LoadFullList();
        //    //SetDateColumnsVisible();
        //}

        private void rdStaff_CheckedChanged(object sender, EventArgs e)
        {
            LoadFullList();
            //SetSearchType();
            //LoadFullList();
            //SetDateColumnsVisible();
        }

        //private void txtDocketNo_KeyPress(object sender, KeyPressEventArgs e)
        //{
        //    //InterfaceTasks.ValidateOnlyDigits(txtSearch, e);
        //}

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {

            if (Application.OpenForms["ReportViewer"] as ReportViewer == null)
            {
                //SetSearchType();
                //ReportProcessor rp = new JobReport();
                //rp.CurrentUser = currentUser;               
                ReportViewer frm = new ReportViewer(_fullPersonList);
                frm.MdiParent = _mdiForm;
                frm.Dock = DockStyle.Fill;
                frm.FormBorderStyle = FormBorderStyle.Sizable;
                frm.Show();
            }
        }       

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "QA")
                //dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Beige;
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248,253,197);
            if (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "In Progress")
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(243, 252, 255);
            if (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "Proof")
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(196, 254, 207);
            if (dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() == "Completed")
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(252, 236, 232);
        }

        private void JobSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (System.Windows.Forms.Application.OpenForms["MDIMainForm"] as MDIMainForm != null)
            //{
            //    (System.Windows.Forms.Application.OpenForms["MDIMainForm"] as MDIMainForm).OpenWelcomeForm();
            //}
            //currentUser.Jsc = originalJsc;
        }

        private void SetSearchType()
        {
            //if (rdCurrent.Checked && chkMyJobsOnly.Checked)
            //    currentUser.Jsc = new OnlyMyCurrentJobs();
            //if (rdCurrent.Checked && !chkMyJobsOnly.Checked)
            //    currentUser.Jsc = new AllCurrentJobs();
            //if (rdCompleted.Checked && chkMyJobsOnly.Checked)
            //    currentUser.Jsc = new OnlyMyCompletedJobsLastThirtyDays();
            //if (rdCompleted.Checked && !chkMyJobsOnly.Checked)
            //    currentUser.Jsc = new AllCompletedJobsLastThirtyDays();

            //currentUser.Jsc.CustomerName = txtCustomer.Text;
            //currentUser.Jsc.PrismNo = txtPrismNo.Text;
            //currentUser.Jsc.ToDate = DateTime.Today.AddDays(1);
            //currentUser.Jsc.FromDate = DateTime.Today.AddDays(-30);
        }

        private void SetDateColumnsVisible()
        {
            if (rdStaff.Checked)
            {
                dataGridView1.Columns["JobCreatedDate"].Visible = false;
                dataGridView1.Columns["JobCompletedDate"].Visible = true;                
            }
            else
            {                
                dataGridView1.Columns["JobCreatedDate"].Visible = true;
                dataGridView1.Columns["JobCompletedDate"].Visible = false;               
            }
           
        }

        private void rdStudents_CheckedChanged(object sender, EventArgs e)
        {
            LoadFullList();
        }

        //private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (e.Button == MouseButtons.Right)
        //    {
        //        ContextMenu m = new ContextMenu();
        //        m.MenuItems.Add(new MenuItem("Cut"));
        //        m.MenuItems.Add(new MenuItem("Copy"));
        //        m.MenuItems.Add(new MenuItem("Paste"));

        //        int currentMouseOverRow = dataGridView1.HitTest(e.X, e.Y).RowIndex;

        //        if (currentMouseOverRow >= 0)
        //        {
        //            m.MenuItems.Add(new MenuItem(string.Format("Do something to row {0}", currentMouseOverRow.ToString())));
        //        }

        //        m.Show(dataGridView1, new Point(e.X, e.Y));

        //    }
        //}
       }    
    }
