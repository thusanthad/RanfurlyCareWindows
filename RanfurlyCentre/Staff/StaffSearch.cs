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
    public partial class StaffSearch : Form
    {         
       // SystemUser currentUser;
        public MDIMainForm _mdiForm {get;set;}
        private BindingSource _bs;
        //private List<Person> _allStaff;
        //private List<Person> _filteredStaffList;
        private List<Person> _allStaff;
        private List<Person> _filteredStaffList;
        private bool _sorted;
        //JobSearchCriteria originalJsc;

        public StaffSearch(MDIMainForm mdiForm)
        {
            InitializeComponent();
            _bs = new BindingSource();
            _mdiForm = mdiForm;
            //currentUser = user;
            //originalJsc = user.Jsc;
        }       

        private void JobSearch_Load(object sender, EventArgs e)
        {
            //FormInitialiserBase fi = new GenericFormIntialiser(this);
            LoadStaffList();
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
            LoadStaffList();
        }

        public void SetDataSource()
        {
            dgStaff.AutoGenerateColumns = false;
            _bs.DataSource = _filteredStaffList.ConvertAll(x=>x as Staff);
            dgStaff.DataSource = _bs;
            dgStaff.Refresh();
            //dataGridView1.Columns[4].DefaultCellStyle.Format = "dd-MMM-yyyy";
            lblStudentCount.Text = "Staff Count: " + dgStaff.Rows.Count.ToString(); 
        }

        public void LoadStaffList()
        {
            ep.SetError(dgStaff, "");
            try
            {                
                //DataBase db;
                //if(rbAllStudents.Checked)
                //    db = new StudenData();
                //else
                DataBase db = new StaffData();

                _allStaff = db.GetList();
                _filteredStaffList = _allStaff;
            }
            catch (Exception ex)
            {
                ep.SetError(dgStaff, ex.Message);
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
            LoadStaffList();
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
                ReportViewer frm = new ReportViewer(_allStaff)
                {
                    MdiParent = _mdiForm,
                    Dock = DockStyle.Fill,
                    FormBorderStyle = FormBorderStyle.Sizable
                };
                frm.Show();
            }
        }       

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (dgStaff.Rows[e.RowIndex].Cells[5].Value.ToString() == string.Empty)
                dgStaff.Rows[e.RowIndex].Cells[5].Style.BackColor = Color.Orange;
                //dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Beige;
                //dgStaff.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248,253,197);
                //if (dgStaff.Rows[e.RowIndex].Cells[5].Value.ToString() == "In Progress")
                //    dgStaff.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(243, 252, 255);
                //if (dgStaff.Rows[e.RowIndex].Cells[5].Value.ToString() == "Proof")
                //    dgStaff.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(196, 254, 207);
                //if (dgStaff.Rows[e.RowIndex].Cells[5].Value.ToString() == "Completed")
                //    dgStaff.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(252, 236, 232);
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

        //private void SetDateColumnsVisible()
        //{
        //    if (rbResidentStudents.Checked)
        //    {
        //        dataGridView1.Columns["JobCreatedDate"].Visible = false;
        //        dataGridView1.Columns["JobCompletedDate"].Visible = true;                
        //    }
        //    else
        //    {                
        //        dataGridView1.Columns["JobCreatedDate"].Visible = true;
        //        dataGridView1.Columns["JobCompletedDate"].Visible = false;               
        //    }
           
        //}

        //private void rdStudents_CheckedChanged(object sender, EventArgs e)
        //{
        //    LoadStaffList();
        //}

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void btnGenerateReport_Click_1(object sender, EventArgs e)
        //{

        //    if (Application.OpenForms["ReportViewer"] as ReportViewer == null)
        //    {
        //        ReportViewer frm = new ReportViewer(_filteredStaffList)
        //        {
        //            MdiParent = _mdiForm,
        //            Dock = DockStyle.Fill,
        //            FormBorderStyle = FormBorderStyle.FixedSingle
        //        };
        //        frm.Show();
        //    }
        //}

        private void btnClear_Click_1(object sender, EventArgs e)
        {

            //txtCustomer.Text = string.Empty ;
            txtSearch.Text = string.Empty;
            _filteredStaffList = _allStaff;
            //SetSearchType();
            SetDataSource();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            if (txtSearch.Text != string.Empty)
            {
                _filteredStaffList = _allStaff.FindAll(x =>x.FirstName.ToUpper().Contains(txtSearch.Text.ToUpper()) || x.LastName.ToUpper().Contains(txtSearch.Text.ToUpper()));                
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
            try
            {
                int index = e.RowIndex;
                int personId = (int)dgStaff.Rows[e.RowIndex].Cells[0].Value;
                Person person = _allStaff.Find(x => x.PersonId == personId);
                if (person != null)
                {
                    StaffAddEdit frm = new StaffAddEdit(person,"edit");
                    frm.Jarvis = _mdiForm.Jarvis;
                    frm.ShowDialog();
                    //if (frm.DialogResult == DialogResult.OK)
                    //{
                        this.LoadStaffList();
                        this.SetDataSource();
                   // }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //private void rbAllStudents_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (rbAllStudents.Checked)
        //    {
        //        _filteredStaffList = _allStaff;
        //        SetDataSource();
        //    }           
        //}

        //private void rbResidentStudents_CheckedChanged(object sender, EventArgs e)
        //{
        //    //if (rbResidentStudents.Checked)
        //    //{
        //    //    _filteredStaffList = _allStaff.FindAll(x => x.AdmissionToResidence.HasValue);
        //    //    SetDataSource();
        //    //}
        //}

        //private void rbActivityCentreStudents_CheckedChanged(object sender, EventArgs e)
        //{
        //    //if (rbActivityCentreStudents.Checked)
        //    //{
        //    //    _filteredStaffList = _allStaff.FindAll(x => x.AdmissionToResidence.HasValue == false);
        //    //    SetDataSource();
        //    //}
        //}

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.ColumnIndex;
            string propertyName = dgStaff.Columns[index].DataPropertyName;
            if (!_sorted)
            {
                _filteredStaffList = _filteredStaffList.OrderBy(p => p.GetType()
                               .GetProperty(propertyName)
                               .GetValue(p, null)).ToList();
                _sorted = true;
            }
            else
            {
                _filteredStaffList = _filteredStaffList.OrderByDescending(p => p.GetType()
                               .GetProperty(propertyName)
                               .GetValue(p, null)).ToList();
                _sorted = false;
            }


            SetDataSource();
        }

        private void btnExportFile_Click(object sender, EventArgs e)
        {
            //_mdiForm.Jarvis.OutputFileName = sqlBase.GetType().Name;// "Export Student List";
            //_mdiForm.Jarvis.ExportOjectType = new Student();
            _mdiForm.Jarvis.ExportFileData = _filteredStaffList.ConvertAll(x => x as object);
            FileExportBase efb = new StaffFile(_mdiForm.Jarvis);
            //FileExportDashBoard fed = new FileExportDashBoard(_mdiForm.Jarvis);
            FileExportDashBoard fed = new FileExportDashBoard(efb);
            fed.ShowDialog();
        }

        private void addNewStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StaffAddEdit sa = new StaffAddEdit(new Staff(), "add");
            sa.Jarvis = _mdiForm.Jarvis;
            sa.ShowDialog();
            if (sa.DialogResult == DialogResult.OK)
            {
                //if (Application.OpenForms["StaffSearch"] as StaffSearch != null)
                //{
                   // StaffSearch frm1 = (StaffSearch)Application.OpenForms["StaffSearch"];
                    LoadStaffList();
                    SetDataSource();
                //}
            }
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
