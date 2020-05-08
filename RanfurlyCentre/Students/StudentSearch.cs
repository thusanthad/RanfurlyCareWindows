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
    public partial class StudentSearch : Form
    {         
       // SystemUser currentUser;
        public MDIMainForm _mdiForm {get;set;}
        private BindingSource _bs;
        //private List<Person> _allStudentList;
        //private List<Person> _filteredStudentList;
        private List<Student> _allStudentList;
        private List<Student> _filteredStudentList;
        private bool _sorted;
        //JobSearchCriteria originalJsc;

        public StudentSearch(MDIMainForm mdiForm)
        {
            InitializeComponent();
            _bs = new BindingSource();
            _mdiForm = mdiForm;
            //currentUser = user;
            //originalJsc = user.Jsc;
        }       

        private void JobSearch_Load(object sender, EventArgs e)
        {
            //label4.Text = CommonVariables.GetConnectionString();
            FormInitialiserBase fi = new StudentSearchIntialiser(this);
            LoadFullList();
            SetDataSource();

            if (Application.OpenForms["MDIMainForm"] as MDIMainForm != null)
            {
                MDIMainForm mfrm = Application.OpenForms["MDIMainForm"] as MDIMainForm;
            }
           
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

        public void SetDataSource()
        {
            dataGridView1.AutoGenerateColumns = false;
            _bs.DataSource = _filteredStudentList;
            dataGridView1.DataSource = _bs.DataSource;
            dataGridView1.Refresh();
            dataGridView1.Columns[4].DefaultCellStyle.Format = "dd-MMM-yyyy";
            lblStudentCount.Text = "Student Count: " + dataGridView1.Rows.Count.ToString(); 
        }

        public void LoadFullList()
        {
            ep.SetError(dataGridView1, "");
            try
            {                
                DataBase db;
                if(rbAllStudents.Checked)
                    db = new StudenData();
                else
                    db = new StaffData();

                _allStudentList = db.GetList().ConvertAll(x=>x as Student);
                _filteredStudentList = _allStudentList;
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

        //private void btnSearch_Click(object sender, EventArgs e)
        //{
        //    if (txtSearch.Text != string.Empty)
        //    {
        //        List<Person> list = _allStudentList.FindAll(x => x.PreferredName.ToUpper().Contains(txtSearch.Text.ToUpper()) || x.FirstName.ToUpper().Contains(txtSearch.Text.ToUpper()) || x.LastName.ToUpper().Contains(txtSearch.Text.ToUpper()));
        //        //_bs.Filter = "FirstName=%'" + txtSearch.Text + "'";
        //        dataGridView1.DataSource = null;
        //        _bs.DataSource = list;                
        //        dataGridView1.DataSource = _bs;
        //        dataGridView1.Refresh();

        //    }
        //    //SetSearchType();
        //    //LoadFullList();
        //}
       

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
                ReportViewer frm = new ReportViewer(_allStudentList.ConvertAll(x=>x as Person));
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
            if (rbResidentStudents.Checked)
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

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGenerateReport_Click_1(object sender, EventArgs e)
        {

            if (Application.OpenForms["ReportViewer"] as ReportViewer == null)
            {           
                ReportViewer frm = new ReportViewer(_filteredStudentList.ConvertAll(x=>x as Person));
                frm.MdiParent = _mdiForm;
                frm.Dock = DockStyle.Fill;
                frm.FormBorderStyle = FormBorderStyle.FixedSingle;
                frm.Show();
            }
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {

            //txtCustomer.Text = string.Empty ;
            txtSearch.Text = string.Empty;
            _filteredStudentList = _allStudentList;
            //SetSearchType();
            SetDataSource();
            rbAllStudents.Checked = true ;
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            if (txtSearch.Text != string.Empty)
            {
                _filteredStudentList = _allStudentList.FindAll(x => x.PreferredName.ToUpper().Contains(txtSearch.Text.ToUpper()) || x.FirstName.ToUpper().Contains(txtSearch.Text.ToUpper()) || x.LastName.ToUpper().Contains(txtSearch.Text.ToUpper()));
                ////_bs.Filter = "FirstName=%'" + txtSearch.Text + "'";
                //dataGridView1.DataSource = null;
                //_bs.DataSource = list;
                //dataGridView1.DataSource = _bs;
                //dataGridView1.Refresh();
                SetDataSource();

            }
        }

        //private void rbStudents_CheckedChanged_1(object sender, EventArgs e)
        //{
        //    LoadFullList();
        //}

        //private void rdStaff_CheckedChanged_1(object sender, EventArgs e)
        //{
        //    LoadFullList();
        //}

        private void dataGridView1_RowHeaderMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            int personId = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            Person person = _allStudentList.Find(x=>x.PersonId == personId);
            if (person != null)
            {
                if (Application.OpenForms["StudentEdit"] as StudentEdit != null)
                {
                    StudentEdit frm1 = (StudentEdit)Application.OpenForms["StudentEdit"];
                    frm1.Close();
                }
                    StudentEdit frm = new StudentEdit(person);
                    frm.MdiParent = _mdiForm;
                    frm.Dock = DockStyle.Fill;
                    frm.FormBorderStyle = FormBorderStyle.None;
                    frm.Show();               
            } 
        }

        private void rbAllStudents_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAllStudents.Checked)
            {
                _filteredStudentList = _allStudentList;
                SetDataSource();
            }           
        }

        private void rbResidentStudents_CheckedChanged(object sender, EventArgs e)
        {
            if (rbResidentStudents.Checked)
            {
                _filteredStudentList = _allStudentList.FindAll(x => x.DateOfAdmissionToResidence.HasValue);
                SetDataSource();
            }
        }

        private void rbActivityCentreStudents_CheckedChanged(object sender, EventArgs e)
        {
            if (rbActivityCentreStudents.Checked)
            {
                _filteredStudentList = _allStudentList.FindAll(x => x.DateOfAdmissionToResidence.HasValue == false);
                SetDataSource();
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.ColumnIndex;
            string propertyName = dataGridView1.Columns[index].DataPropertyName;
            if (!_sorted)
            {
                _filteredStudentList = _filteredStudentList.OrderBy(p => p.GetType()
                               .GetProperty(propertyName)
                               .GetValue(p, null)).ToList();
                _sorted = true;
            }
            else
            {
                _filteredStudentList = _filteredStudentList.OrderByDescending(p => p.GetType()
                               .GetProperty(propertyName)
                               .GetValue(p, null)).ToList();
                _sorted = false;
            }          

            
            SetDataSource();
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
