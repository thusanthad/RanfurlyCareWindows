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
        public MDIMainForm _mdiForm {get;set;}
        private BindingSource _studentBs;
        private List<Student> _allStudentList;
        private List<Student> _filteredStudentList;
        private bool _sorted;
        private SqlGeneratorBase sqlBase;

        public StudentSearch(MDIMainForm mdiForm)
        {
            InitializeComponent();
            _studentBs = new BindingSource();
            _mdiForm = mdiForm;
        }       

        private void JobSearch_Load(object sender, EventArgs e)
        {
            FormInitialiserBase fi = new GenericFormIntialiser(this);
            sqlBase = new AllCurrentStudents(cmbLocation);
            LoadStudentList();
            SetDataSource();
            cmbLocation.SelectedIndexChanged -= cmbLocation_SelectedIndexChanged;
            PopulateLocationCombobox();

            if (Application.OpenForms["MDIMainForm"] as MDIMainForm != null)
            {
                MDIMainForm mfrm = Application.OpenForms["MDIMainForm"] as MDIMainForm;
            }
        }

        private void PopulateLocationCombobox()
        {
            LocationData ld = new LocationData();
            List<Location> locations = ld.GetList("SELECT * FROM vw_Locations WHERE IsResidence=true");

            Location location = new Location();
            location.LocationId = 0;
            location.LocationName = string.Empty;
            locations.Insert(0, location);

            cmbLocation.DataSource = locations;
            cmbLocation.ValueMember = "LocationId";
            cmbLocation.DisplayMember = "LocationName";

           
            ; 
            //cmbLocation.DataBindings.Add("SelectedValue", _student, "LocationId");
            //cmbLocation.SelectedIndexChanged += cmbLocation_SelectedIndexChanged;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty ;
            LoadStudentList();
        }

        public void LoadStudentList()
        {
            ep.SetError(dataGridView1, "");
            try
            {
                //sqlBase = new Students.AllCurrentStudents();
                _allStudentList = sqlBase.GetList().ConvertAll(x => x as Student);
                _filteredStudentList = _allStudentList;
            }
            catch (Exception ex)
            {
                _mdiForm.Jarvis.PlayFailSound();
                ep.SetError(dataGridView1, ex.Message);
            }
        }

        public void SetDataSource()
        {
            dataGridView1.AutoGenerateColumns = false;
            _studentBs.DataSource = _filteredStudentList;
            dataGridView1.DataSource = _studentBs.DataSource;
            dataGridView1.Refresh();
            dataGridView1.Columns[4].DefaultCellStyle.Format = "dd-MMM-yyyy";
            lblStudentCount.Text = "Student Count: " + dataGridView1.Rows.Count.ToString(); 
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void rdStaff_CheckedChanged(object sender, EventArgs e)
        //{
        //    LoadStudentList();
        //}

        private void rdStudents_CheckedChanged(object sender, EventArgs e)
        {
            LoadStudentList();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void btnClear_Click_1(object sender, EventArgs e)
        {

            //txtCustomer.Text = string.Empty ;
            txtSearch.Text = string.Empty;
            _filteredStudentList = _allStudentList;
            //SetSearchType();
            SetDataSource();
            //rbAllCurrentStudents.Checked = true ;
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {           
            ApplyFilter();
        }

        private void ApplyFilter()
        {
            if (txtSearch.Text != string.Empty)
            {
                _filteredStudentList = _allStudentList.FindAll(x => x.PreferredName.ToUpper().Contains(txtSearch.Text.ToUpper()) || x.FirstName.ToUpper().Contains(txtSearch.Text.ToUpper()) || x.LastName.ToUpper().Contains(txtSearch.Text.ToUpper()));
                SetDataSource();

            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (!_mdiForm.Jarvis.CurrentUser.UserHasPermissionForAction("Student", "Edit"))
            //    return;

            int index = e.RowIndex;
            int personId = (int)dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            Person person = _allStudentList.Find(x=>x.PersonId == personId);
            if (person != null)
            {
                if (Application.OpenForms["StudentAddEdit"] as StudentAddEdit != null)
                {
                    StudentAddEdit frm1 = (StudentAddEdit)Application.OpenForms["StudentAddEdit"];
                    frm1.Close();
                }
                StudentAddEdit frm = new StudentAddEdit(person, this);
                frm.MdiParent = _mdiForm;
                frm.Dock = DockStyle.Fill;
                frm.FormBorderStyle = FormBorderStyle.None;
                frm.Show();
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            _mdiForm.Jarvis.OutputFileName = sqlBase.GetType().Name;// "Export Student List";
            //_mdiForm.Jarvis.ExportOjectType = new Student();

            _mdiForm.Jarvis.ExportFileData = _filteredStudentList.ConvertAll(x=> x as object);
            FileExportBase efb = new StudentFile(_mdiForm.Jarvis);
            //FileExportDashBoard fed = new FileExportDashBoard(_mdiForm.Jarvis);
            FileExportDashBoard fed = new FileExportDashBoard(efb);
            fed.ShowDialog();
        }

        private void rbAllCurrentStudents_CheckedChanged(object sender, EventArgs e)
        {
            PopulateGridAfterSelection();
            //if (rbAllCurrentStudents.Checked)
            //{
            //    //_filteredStudentList = _allStudentList;
            //    sqlBase = new AllCurrentStudents(cmbLocation);
            //    LoadStudentList();
            //    SetDataSource();
            //}
        }

        private void rbResidentStudents_CheckedChanged(object sender, EventArgs e)
        {
            PopulateGridAfterSelection();
            //if (rbResidentStudents.Checked)
            //{
            //    //_filteredStudentList = _allStudentList.FindAll(x => x.AdmittedToResidence.HasValue);
            //    //sqlBase = new AllResidentStudents(cmbLocation);
            //    //LoadStudentList();
            //    //SetDataSource();
            //    SetResidentDataSource();
            //}
        }

        private void rbANonResidentStudents_CheckedChanged(object sender, EventArgs e)
        {
            PopulateGridAfterSelection();
            //if (rbNonResidentStudents.Checked)
            //{
            //    //_filteredStudentList = _allStudentList.FindAll(x => x.AdmittedToResidence.HasValue == false);
            //    sqlBase = new AllNonResidentStudents(cmbLocation);
            //    LoadStudentList();
            //    SetDataSource();
            //}
        }

        private void rbAttendsActivityCentre_CheckedChanged(object sender, EventArgs e)
        {
            PopulateGridAfterSelection();
            //if (rbAttendsActivityCentre.Checked)
            //{
            //    //_filteredStudentList = _allStudentList.FindAll(x => x.AttendsActivityCentre==true);
            //    sqlBase = new AllStudentsAttendActivityCentre(cmbLocation);
            //    LoadStudentList();
            //    SetDataSource();
            //}
        }

        private void rbShortStayStudents_CheckedChanged(object sender, EventArgs e)
        {
            PopulateGridAfterSelection();
            //if (rbShortStayStudents.Checked)
            //{
            //    //_filteredStudentList = _allStudentList.FindAll(x => x.IsShortStayResident == true);
            //    sqlBase = new AllShortStayResidents(cmbLocation);
            //    LoadStudentList();
            //    SetDataSource();
            //}
        }

        private void rbPastStudents_CheckedChanged(object sender, EventArgs e)
        {
            PopulateGridAfterSelection();
            //if (rbPastStudents.Checked)
            //{
            //    //_filteredStudentList = _allStudentList.FindAll(x => x.IsActive == false);
            //    sqlBase = new AllPastStudents(cmbLocation);
            //    LoadStudentList();
            //    SetDataSource();
            //}
        }

        public void PopulateGridAfterSelection()
        {
            if (rbAllCurrentStudents.Checked)
            {
                //_filteredStudentList = _allStudentList;
                sqlBase = new AllCurrentStudents(cmbLocation);
                LoadStudentList();
                SetDataSource();
            }
            else if (rbResidentStudents.Checked)
            {
                SetResidentDataSource();
            }
            else if (rbNonResidentStudents.Checked)
            {
                //_filteredStudentList = _allStudentList.FindAll(x => x.AdmittedToResidence.HasValue == false);
                sqlBase = new AllNonResidentStudents(cmbLocation);
                LoadStudentList();
                SetDataSource();
            }
            else if (rbAttendsActivityCentre.Checked)
            {
                //_filteredStudentList = _allStudentList.FindAll(x => x.AttendsActivityCentre==true);
                sqlBase = new AllStudentsAttendActivityCentre(cmbLocation);
                LoadStudentList();
                SetDataSource();
            }
            else if (rbShortStayStudents.Checked)
            {
                //_filteredStudentList = _allStudentList.FindAll(x => x.IsShortStayResident == true);
                sqlBase = new AllShortStayResidents(cmbLocation);
                LoadStudentList();
                SetDataSource();
            }
            else if (rbPastStudents.Checked)
            {
                //_filteredStudentList = _allStudentList.FindAll(x => x.IsActive == false);
                sqlBase = new AllPastStudents(cmbLocation);
                LoadStudentList();
                SetDataSource();
            }

        }

        private void cmbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbLocation.SelectedIndex != -1)
            {
                SetResidentDataSource();
            //    int index = cmbLocation.SelectedIndex;
            //    Location location = (Location)cmbLocation.SelectedItem;

                //    sqlBase = new AllResidentStudents(cmbLocation);
                //    //cmbLocation.SelectedIndex = index;
                //    LoadStudentList();

                //    if (location.LocationId != 0)
                //    {
                //        _filteredStudentList = _filteredStudentList.FindAll(x => x.LocationId == location.LocationId);
                //    }
                //    SetDataSource();
            }
        }

        private void SetResidentDataSource()
        {
            int index = cmbLocation.SelectedIndex;
            Location location = (Location)cmbLocation.SelectedItem;

            sqlBase = new AllResidentStudents(cmbLocation);
            //cmbLocation.SelectedIndex = index;
            LoadStudentList();

            if (location.LocationId != 0)
            {
                _filteredStudentList = _filteredStudentList.FindAll(x => x.LocationId == location.LocationId);
            }
            SetDataSource();
        }
   // }

        private void dataGridView1_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgr = dataGridView1.Rows[e.RowIndex];
                if (dgr.Cells["DateOfBirth"].Value == null || dgr.Cells["DateOfBirth"].Value.ToString() ==string.Empty)
                {
                    dgr.Cells["DateOfBirth"].Style.BackColor = Color.Orange;
                }
                else
                {
                    dgr.Cells["DateOfBirth"].Style.BackColor = dgr.Cells[1].Style.BackColor;
                }

                if (dgr.Cells["Ethnicity"].Value == null || dgr.Cells["Ethnicity"].Value.ToString() == string.Empty)
                {
                    dgr.Cells["Ethnicity"].Style.BackColor = Color.Orange;
                }
                else
                {
                    dgr.Cells["Ethnicity"].Style.BackColor = dgr.Cells[1].Style.BackColor;
                }

               
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int index = dataGridView1.CurrentCell.RowIndex;
            int personId = (int)dataGridView1.Rows[index].Cells[0].Value;
            Person person = _filteredStudentList.Find(x => x.PersonId == personId);
            if (person != null)
            {
                try
                {
                    ReportViewer frm = new ReportViewer((Student)person);
                    frm.ShowDialog();
                    //Student student = (Student)person;
                    ////IndividualStudentReport instrpt = new IndividualStudentReport(_mdiForm.Jarvis, student);
                    //StudentExcelReport studentReport = new StudentExcelReport(student, _mdiForm.Jarvis);
                    //_mdiForm.Jarvis.IncreaseFielIncrement();
                    ////MessageBox.Show("Student file created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //StudentReportViewer frm = new StudentReportViewer(student);
                //frm.ShowDialog();
            }
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_mdiForm.Jarvis.CurrentUser.UserHasPermissionForAction("Student", "Add"))
                return;

            StudentAddEdit frm = new StudentAddEdit(new Student(), this);
            frm.headerLabel.Text = "Student Add";
            frm.Text = "Add New Student";
            //frm.MdiParent = this;
            //frm.Dock = DockStyle.Fill;
            //frm.FormBorderStyle = FormBorderStyle.None;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                //if (Application.OpenForms["StudentSearch"] as StudentSearch != null)
                //{
                    //StudentSearch frm1 = (StudentSearch)Application.OpenForms["StudentSearch"];
                    LoadStudentList();
                    SetDataSource();
                //}
                //{
            }
        }

       

        private void StudentSearch_Shown(object sender, EventArgs e)
        {
            cmbLocation.SelectedIndexChanged += cmbLocation_SelectedIndexChanged;
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

//private void btnGenerateReport_Click_1(object sender, EventArgs e)
//{
//    int index = dataGridView1.CurrentCell.RowIndex;
//    int personId = (int)dataGridView1.Rows[index].Cells[0].Value;
//    Person person = _filteredStudentList.Find(x => x.PersonId == personId);
//    if (person != null)
//    {
//        try
//        {
//            Student student = (Student)person;
//            //IndividualStudentReport instrpt = new IndividualStudentReport(_mdiForm.Jarvis, student);
//            StudentExcelReport studentReport = new StudentExcelReport(student, _mdiForm.Jarvis);
//            _mdiForm.Jarvis.IncreaseFielIncrement();
//            //MessageBox.Show("Student file created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


//        }
//        catch (Exception ex)
//        {
//            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//        }

//        //StudentReportViewer frm = new StudentReportViewer(student);
//        //frm.ShowDialog();
//    }

//        //if (Application.OpenForms["ReportViewer"] as ReportViewer == null)
//        //{           
//        //    ReportViewer frm = new ReportViewer(_filteredStudentList.ConvertAll(x=>x as Person));
//        //    frm.MdiParent = _mdiForm;
//        //    frm.Dock = DockStyle.Fill;
//        //    frm.FormBorderStyle = FormBorderStyle.FixedSingle;
//        //   // try
//        //    //{
//        //        frm.Show();
//        //    //}
//        //    //catch(Exception ex)
//        //    //{


//        //    //}

//        //    }
//    }
