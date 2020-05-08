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
    public partial class IncidentSearch : Form
    {                
        public MDIMainForm _mdiForm {get;set;}
        private BindingSource _bs;
        private List<Incident> _allIncidents;
        private List<Incident> _filteredIncidents;
        private bool _sorted;
        private Incident.IncidentTypeEnum _incidentType;
        private string _lastSortedPropertyName;

        public IncidentSearch(MDIMainForm mdiForm)
        {
            InitializeComponent();
            _bs = new BindingSource();
            _mdiForm = mdiForm;
            _incidentType = Incident.IncidentTypeEnum.All;
            _lastSortedPropertyName = "IncidentDate";
        }       

        private void JobSearch_Load(object sender, EventArgs e)
        {
            //FormInitialiserBase fi = new GenericFormIntialiser(this);
           // sqlBase = new AllIncidents();
            LoadList();
            SetDataSource(false);

            if (Application.OpenForms["MDIMainForm"] as MDIMainForm != null)
            {
                MDIMainForm mfrm = Application.OpenForms["MDIMainForm"] as MDIMainForm;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty ;
            LoadList();
        }

        public void LoadList()
        {
            ep.SetError(dgIncidents, "");
            try
            {
                IncidentData id = new IncidentData();
               _allIncidents = id.GetList();
                _filteredIncidents = _allIncidents;
            }
            catch (Exception ex)
            {
                ep.SetError(dgIncidents, ex.Message);
            }
        }

        public void SetDataSource(bool sort)
        {
            dgIncidents.AutoGenerateColumns = false;
            _filteredIncidents = GetFilteredList(_incidentType,sort);
            _bs.DataSource = _filteredIncidents;
            dgIncidents.DataSource = _bs.DataSource;
            dgIncidents.Refresh();
            //dgIncidents.Columns[4].DefaultCellStyle.Format = "dd-MMM-yyyy";
            lblStudentCount.Text = "Incident Count: " + dgIncidents.Rows.Count.ToString();

            
        }

        

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      

        //private void btnGenerateReport_Click(object sender, EventArgs e)
        //{

        //    if (Application.OpenForms["ReportViewer"] as ReportViewer == null)
        //    {
        //        //SetSearchType();
        //        //ReportProcessor rp = new JobReport();
        //        //rp.CurrentUser = currentUser;               
        //        ReportViewer frm = new ReportViewer(_allStudentList.ConvertAll(x=>x as Person));
        //        frm.MdiParent = _mdiForm;
        //        frm.Dock = DockStyle.Fill;
        //        frm.FormBorderStyle = FormBorderStyle.Sizable;
        //        frm.Show();
        //    }
        //}  

        private void rdStudents_CheckedChanged(object sender, EventArgs e)
        {
            LoadList();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {

            //txtCustomer.Text = string.Empty ;
            txtSearch.Text = string.Empty;
            _filteredIncidents = _allIncidents;
            //SetSearchType();
            SetDataSource(false);
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
                //_filteredIncidents = _allIncidents.FindAll(x => x.PreferredName.ToUpper().Contains(txtSearch.Text.ToUpper()) || x.FirstName.ToUpper().Contains(txtSearch.Text.ToUpper()) || x.LastName.ToUpper().Contains(txtSearch.Text.ToUpper()));
                SetDataSource(false);

            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!_mdiForm.Jarvis.CurrentUser.UserHasPermissionForAction("Incident", "Edit"))
                return;

            int index = e.RowIndex;
            int incidenId = (int)dgIncidents.Rows[e.RowIndex].Cells[0].Value;
            Incident incident = _allIncidents.Find(x => x.IncidentId == incidenId);
            if (incident != null)
            {
                //if (Application.OpenForms["StudentAddEdit"] as StudentAddEdit != null)
                //{
                //    StudentAddEdit frm1 = (StudentAddEdit)Application.OpenForms["StudentAddEdit"];
                //    frm1.Close();
                //}
                IncidentAddEdit frm = new IncidentAddEdit(incident, _mdiForm.Jarvis);
                //frm.MdiParent = _mdiForm;
                //frm.Dock = DockStyle.Fill;
                //frm.FormBorderStyle = FormBorderStyle.None;
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                {
                    //_sorted = false;
                    LoadList();
                    SetDataSource(false);
                }
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.ColumnIndex;
            //string propertyName = dgIncidents.Columns[index].DataPropertyName;
            _lastSortedPropertyName= dgIncidents.Columns[index].DataPropertyName;
            //if (!_sorted)
            //{
                //_filteredIncidents = _filteredIncidents.OrderBy(p => p.GetType()
                               //.GetProperty(propertyName)
                              // .GetValue(p, null)).ToList();
                //_sorted = true;
            //}
            //else
            //{
                //_filteredIncidents = _filteredIncidents.OrderByDescending(p => p.GetType()
                               //.GetProperty(propertyName)
                              // .GetValue(p, null)).ToList();
                //_sorted = false;
            //}
            SetDataSource(true);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            _mdiForm.Jarvis.OutputFileName = "Export Incident List";
            _mdiForm.Jarvis.ExportOjectType = new Incident();
            _mdiForm.Jarvis.ExportFileData = _filteredIncidents.ConvertAll(x=> x as object);
            FileExportBase efb = new IncidentFile(_mdiForm.Jarvis);
            //FileExportDashBoard fed = new FileExportDashBoard(_mdiForm.Jarvis);
            FileExportDashBoard fed = new FileExportDashBoard(efb);
            fed.ShowDialog();
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAll.Checked)
            {
                //_filteredIncidents=_allIncidents;
                //_incidentType = Incident.IncidentTypeEnum.All;
                _incidentType = Incident.IncidentTypeEnum.All;
                SetDataSource(false);
                
            }
        }

        private void rbStudent_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStudent.Checked)
            {
                //_filteredIncidents = GetFilteredList(Incident.IncidentTypeEnum.Student);
                //LoadList();
                _incidentType = Incident.IncidentTypeEnum.Student;
                SetDataSource(false);
                
            }
        }

        private void rbStaff_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStaff.Checked)
            {
                //_filteredIncidents = GetFilteredList(Incident.IncidentTypeEnum.Staff);
                _incidentType = Incident.IncidentTypeEnum.Staff;
                SetDataSource(false);
                
            }
        }

        private void rbStaffAndStudent_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStaffAndStudent.Checked)
            {
                //_filteredIncidents = GetFilteredList(Incident.IncidentTypeEnum.StaffAndStudent);
                _incidentType = Incident.IncidentTypeEnum.StaffAndStudent;
                SetDataSource(false);
                
            }
        }

        private void rbOther_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOther.Checked)
            {
                //_filteredIncidents = GetFilteredList(Incident.IncidentTypeEnum.Other);
                _incidentType = Incident.IncidentTypeEnum.Other;
                SetDataSource(false);
            }
        }

        private void dataGridView1_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                //DataGridViewRow dgr = dataGridView1.Rows[e.RowIndex];
                //if (dgr.Cells["DateOfBirth"].Value == null || dgr.Cells["DateOfBirth"].Value.ToString() ==string.Empty)
                //{
                //    dgr.Cells["DateOfBirth"].Style.BackColor = Color.Orange;
                //}
                //else
                //{
                //    dgr.Cells["DateOfBirth"].Style.BackColor = dgr.Cells[1].Style.BackColor;
                //}

                //if (dgr.Cells["Ethnicity"].Value == null || dgr.Cells["Ethnicity"].Value.ToString() == string.Empty)
                //{
                //    dgr.Cells["Ethnicity"].Style.BackColor = Color.Orange;
                //}
                //else
                //{
                //    dgr.Cells["Ethnicity"].Style.BackColor = dgr.Cells[1].Style.BackColor;
                //}

               
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //int index = dgIncidents.CurrentCell.RowIndex;
            //int personId = (int)dgIncidents.Rows[index].Cells[0].Value;
            //Person person = _filteredIncidents.Find(x => x.PersonId == personId);
            //if (person != null)
            //{
            //    try
            //    {
            //        ReportViewer frm = new ReportViewer((Student)person);
            //        frm.ShowDialog();

            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

                
            //}
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_mdiForm.Jarvis.CurrentUser.UserHasPermissionForAction("Incident", "Add"))
                return;

            IncidentAddEdit frm = new IncidentAddEdit(new Incident(), _mdiForm.Jarvis);
            frm.headerLabel.Text = "Add New Incident";
            frm.Text = "Add New Incident";
            //frm.MdiParent = this;
            //frm.Dock = DockStyle.Fill;
            //frm.FormBorderStyle = FormBorderStyle.None;
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadList();
                SetDataSource(false);                
            }
        }

        private void dgIncidents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 6)
                {
                    string filename = dgIncidents.Rows[e.RowIndex].Cells[5].Value.ToString() + "\\" + dgIncidents.Rows[e.RowIndex].Cells[6].Value.ToString();
                    System.Diagnostics.Process.Start(filename);
                }

                if (e.RowIndex >= 0 && e.ColumnIndex == 5)
                {
                    string folderName = dgIncidents.Rows[e.RowIndex].Cells[5].Value.ToString() + "\\";
                    System.Diagnostics.Process.Start(folderName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Cannot find file", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private List<Incident> GetFilteredList(Incident.IncidentTypeEnum incidentType,bool sort)
        {
            List<Incident> newList;
            if (incidentType == Incident.IncidentTypeEnum.All)
                newList= _allIncidents;
            else if (incidentType == Incident.IncidentTypeEnum.Student)
                newList = _allIncidents.FindAll(x => x.IncidentType == Incident.IncidentTypeEnum.Student);
            else if (incidentType == Incident.IncidentTypeEnum.Staff)
                newList = _allIncidents.FindAll(x => x.IncidentType == Incident.IncidentTypeEnum.Staff);
            else if (incidentType == Incident.IncidentTypeEnum.StaffAndStudent)
                newList = _allIncidents.FindAll(x => x.IncidentType == Incident.IncidentTypeEnum.StaffAndStudent);
            else 
                newList = _allIncidents.FindAll(x => x.IncidentType == Incident.IncidentTypeEnum.Other);

            if(txtSearch.Text !=string.Empty)
            {
                newList = _filteredIncidents = newList.FindAll(x => x.PersonFullName.ToUpper().Contains(txtSearch.Text.ToUpper()) || x.Description.ToUpper().Contains(txtSearch.Text.ToUpper()));

            }

            if (sort)
            {
                if (!_sorted)
                {
                    newList = newList.OrderBy(p => p.GetType()
                                   .GetProperty(_lastSortedPropertyName)
                                   .GetValue(p, null)).ToList();
                    _sorted = true;
                }
                else
                {
                    newList = newList.OrderByDescending(p => p.GetType()
                                   .GetProperty(_lastSortedPropertyName)
                                   .GetValue(p, null)).ToList();
                    _sorted = false;
                }
            }
            return newList;
        }

        
    }    
    }

