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
    public partial class DoctorSearch : Form
    {
        // SystemUser currentUser;
        public MDIMainForm _mdiForm { get; set; }
        private BindingSource _bs;
        //private List<Person> _allStaff;
        //private List<Person> _filteredStaffList;
        private List<Person> _allDoctors;
        private List<Person> _filteredDoctorList;
        private bool _sorted;
        //JobSearchCriteria originalJsc;

        public DoctorSearch(MDIMainForm mdiForm)
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
            LoadFullList();
            SetDataSource();

            if (Application.OpenForms["MDIMainForm"] as MDIMainForm != null)
            {
                MDIMainForm mfrm = Application.OpenForms["MDIMainForm"] as MDIMainForm;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //txtCustomer.Text = string.Empty ;
            txtSearch.Text = string.Empty;
            //SetSearchType();
            LoadFullList();
        }

        public void SetDataSource()
        {
            dgDoctor.AutoGenerateColumns = false;
            _bs.DataSource = _filteredDoctorList.ConvertAll(x => x as Doctor);
            dgDoctor.DataSource = _bs.DataSource;
            dgDoctor.Refresh();
            //dataGridView1.Columns[4].DefaultCellStyle.Format = "dd-MMM-yyyy";
            lblStudentCount.Text = "Doctor Count: " + dgDoctor.Rows.Count.ToString();
        }

        public void LoadFullList()
        {
            ep.SetError(dgDoctor, "");
            try
            {
                //DataBase db;
                //if(rbAllStudents.Checked)
                //    db = new StudenData();
                //else
                DataBase db = new DoctorData();

                _allDoctors = db.GetList();
                _filteredDoctorList = _allDoctors;
            }
            catch (Exception ex)
            {
                ep.SetError(dgDoctor, ex.Message);
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

        //private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        //{
        //    //EditJob frm = new EditJob();
        //    //frm.IntJobId = (int)dataGridView1.Rows[e.RowIndex].Cells["JobId"].Value;
        //    //frm.MdiParent = MdiForm;
        //    //frm.Dock = DockStyle.Fill;
        //    //frm.FormBorderStyle = FormBorderStyle.None;
        //    //frm.Show();
        //}

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
                ReportViewer frm = new ReportViewer(_allDoctors);
                frm.MdiParent = _mdiForm;
                frm.Dock = DockStyle.Fill;
                frm.FormBorderStyle = FormBorderStyle.Sizable;
                frm.Show();
            }
        }

        //private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        //{
        //    if (dgDoctor.Rows[e.RowIndex].Cells[5].Value.ToString() == "QA")
        //        //dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.Beige;
        //        dgDoctor.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(248, 253, 197);
        //    if (dgDoctor.Rows[e.RowIndex].Cells[5].Value.ToString() == "In Progress")
        //        dgDoctor.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(243, 252, 255);
        //    if (dgDoctor.Rows[e.RowIndex].Cells[5].Value.ToString() == "Proof")
        //        dgDoctor.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(196, 254, 207);
        //    if (dgDoctor.Rows[e.RowIndex].Cells[5].Value.ToString() == "Completed")
        //        dgDoctor.Rows[e.RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(252, 236, 232);
        //}

        //private void JobSearch_FormClosed(object sender, FormClosedEventArgs e)
        //{
        //    //if (System.Windows.Forms.Application.OpenForms["MDIMainForm"] as MDIMainForm != null)
        //    //{
        //    //    (System.Windows.Forms.Application.OpenForms["MDIMainForm"] as MDIMainForm).OpenWelcomeForm();
        //    //}
        //    //currentUser.Jsc = originalJsc;
        //}

        //private void SetSearchType()
        //{
        //    //if (rdCurrent.Checked && chkMyJobsOnly.Checked)
        //    //    currentUser.Jsc = new OnlyMyCurrentJobs();
        //    //if (rdCurrent.Checked && !chkMyJobsOnly.Checked)
        //    //    currentUser.Jsc = new AllCurrentJobs();
        //    //if (rdCompleted.Checked && chkMyJobsOnly.Checked)
        //    //    currentUser.Jsc = new OnlyMyCompletedJobsLastThirtyDays();
        //    //if (rdCompleted.Checked && !chkMyJobsOnly.Checked)
        //    //    currentUser.Jsc = new AllCompletedJobsLastThirtyDays();

        //    //currentUser.Jsc.CustomerName = txtCustomer.Text;
        //    //currentUser.Jsc.PrismNo = txtPrismNo.Text;
        //    //currentUser.Jsc.ToDate = DateTime.Today.AddDays(1);
        //    //currentUser.Jsc.FromDate = DateTime.Today.AddDays(-30);
        //}

        //private void SetDateColumnsVisible()
        //{
        //    //if (rbResidentStudents.Checked)
        //    //{
        //    //    dataGridView1.Columns["JobCreatedDate"].Visible = false;
        //    //    dataGridView1.Columns["JobCompletedDate"].Visible = true;                
        //    //}
        //    //else
        //    //{                
        //    //    dataGridView1.Columns["JobCreatedDate"].Visible = true;
        //    //    dataGridView1.Columns["JobCompletedDate"].Visible = false;               
        //    //}

        //}

        private void rdStudents_CheckedChanged(object sender, EventArgs e)
        {
            LoadFullList();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void btnGenerateReport_Click_1(object sender, EventArgs e)
        //{

        //    if (Application.OpenForms["ReportViewer"] as ReportViewer == null)
        //    {
        //        ReportViewer frm = new ReportViewer(_filteredDoctorList);
        //        frm.MdiParent = _mdiForm;
        //        frm.Dock = DockStyle.Fill;
        //        frm.FormBorderStyle = FormBorderStyle.FixedSingle;
        //        frm.Show();
        //    }
        //}

        private void btnClear_Click_1(object sender, EventArgs e)
        {

            //txtCustomer.Text = string.Empty ;
            txtSearch.Text = string.Empty;
            _filteredDoctorList = _allDoctors;
            //SetSearchType();
            SetDataSource();
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            if (txtSearch.Text != string.Empty)
            {
                _filteredDoctorList = _allDoctors.FindAll(x => x.FullName.ToUpper().Contains(txtSearch.Text.ToUpper()));
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
            int personId = (int)dgDoctor.Rows[e.RowIndex].Cells[0].Value;
            Person person = _allDoctors.Find(x => x.PersonId == personId);
            if (person != null)
            {
                //if (Application.OpenForms["EditDoctor"] as StudentEdit != null)
                //{
                //    EditDoctor frm1 = (EditDoctor)Application.OpenForms["EditDoctor"];
                //    frm1.Close();
                //}
                DoctorAddEdit frm = new DoctorAddEdit((Doctor)person,"Edit");
                //frm.MdiParent = _mdiForm;
                //frm.Dock = DockStyle.Fill;
                //frm.FormBorderStyle = FormBorderStyle.None;
                frm.ShowDialog();
                //if (frm.DialogResult == DialogResult.OK)
                //{
                    LoadFullList();
                    SetDataSource();
                //}
            }
        }

            private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
            {
                int index = e.ColumnIndex;
                string propertyName = dgDoctor.Columns[index].DataPropertyName;
                if (!_sorted)
                {
                    _filteredDoctorList = _filteredDoctorList.OrderBy(p => p.GetType()
                                   .GetProperty(propertyName)
                                   .GetValue(p, null)).ToList();
                    _sorted = true;
                }
                else
                {
                    _filteredDoctorList = _filteredDoctorList.OrderByDescending(p => p.GetType()
                                   .GetProperty(propertyName)
                                   .GetValue(p, null)).ToList();
                    _sorted = false;
                }


                SetDataSource();
            }

        private void btnExportFile_Click(object sender, EventArgs e)
        {
            _mdiForm.Jarvis.ExportFileData = _filteredDoctorList.ConvertAll(x => x as object);
            FileExportBase efb = new DoctorFile(_mdiForm.Jarvis);
            FileExportDashBoard fed = new FileExportDashBoard(efb);
            fed.ShowDialog();
        }

        private void addNewDoctorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoctorAddEdit sa = new DoctorAddEdit(new Doctor(), "add");
            sa.ShowDialog();
            if (sa.DialogResult == DialogResult.OK)
            {
                //if (Application.OpenForms["DoctorSearch"] as DoctorSearch != null)
                //{
                    //DoctorSearch frm1 = (DoctorSearch)Application.OpenForms["DoctorSearch"];
                    LoadFullList();
                    SetDataSource();
               // }
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

