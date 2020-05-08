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
    public partial class AppointmentSearch : Form
    {                
        public MDIMainForm _mdiForm {get;set;}
        private BindingSource _studentBs;
        private List<AppointmentBase> _allAppointments;
        private List<AppointmentBase> _fileteredAppointments;
        private AppointmentSearchClassBase _appointmentSearchClassBase;
        private bool _sorted;
        //private SqlGeneratorBase sqlBase;

        public AppointmentSearch(MDIMainForm mdiForm)
        {
            InitializeComponent();
            _studentBs = new BindingSource();
            _mdiForm = mdiForm;
        }       

        private void JobSearch_Load(object sender, EventArgs e)
        {
            //FormInitialiserBase fi = new GenericFormIntialiser(this);
            //sqlBase = new AllCurrentStudents(cmbLocation);
            LoadAppointments();

            dtpFrom.ValueChanged -= dtpFrom_ValueChanged;
            dtpTo.ValueChanged -= dtpTo_ValueChanged;
            dtpFrom.Value = DateTime.Today.AddDays(-30);
            dtpTo.Value = DateTime.Today;
            //SetDataSource();

            //if (Application.OpenForms["MDIMainForm"] as MDIMainForm != null)
            //{
            //    MDIMainForm mfrm = Application.OpenForms["MDIMainForm"] as MDIMainForm;
            //}
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty ;
            LoadAppointments();
        }

       

        //public void SetDataSource()
        //{
        //    //dgAppointment.AutoGenerateColumns = false;
        //    //_studentBs.DataSource = _fileteredAppointments;
        //    //dgAppointment.DataSource = _studentBs.DataSource;
        //    //dgAppointment.Refresh();
        //    ////dgAppointment.Columns[1].DefaultCellStyle.Format = "dd-MMMM-yyyy";
        //    //lblAppointmentCount.Text = "Appointment Count: " + dgAppointment.Rows.Count.ToString(); 
        //}

        

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
            LoadAppointments();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void btnClear_Click_1(object sender, EventArgs e)
        {

            //txtCustomer.Text = string.Empty ;
            txtSearch.Text = string.Empty;
            _fileteredAppointments = _allAppointments;
            //SetSearchType();
            //SetDataSource();
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
                //_fileteredAppointments = _allAppointments.FindAll(x => x.PreferredName.ToUpper().Contains(txtSearch.Text.ToUpper()) || x.FirstName.ToUpper().Contains(txtSearch.Text.ToUpper()) || x.LastName.ToUpper().Contains(txtSearch.Text.ToUpper()));
                //SetDataSource();

            }
        }

        private void dataGridView1_RowHeaderMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (!_mdiForm.Jarvis.CurrentUser.UserHasPermissionForAction("Appointment", "Edit"))
                return;

            int index = e.RowIndex;
            int apId = (int)dgAppointment.Rows[e.RowIndex].Cells[0].Value;
            AppointmentBase ap = _appointmentSearchClassBase.GetAppointment(apId);
            if (ap != null)
            {
                //if (Application.OpenForms["StudentAddEdit"] as StudentAddEdit != null)
                //{
                //    StudentAddEdit frm1 = (StudentAddEdit)Application.OpenForms["StudentAddEdit"];
                //    frm1.Close();
                //}
                AddEditAppointment frm = new AddEditAppointment(ap);
                //frm.MdiParent = _mdiForm;
                //frm.Dock = DockStyle.Fill;
                //frm.FormBorderStyle = FormBorderStyle.None;
                frm.ShowDialog();
                LoadAppointments();
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.ColumnIndex;
            string propertyName = dgAppointment.Columns[index].DataPropertyName;
            _appointmentSearchClassBase.SetSortDataSource(propertyName, _sorted);

            if (!_sorted)
                _sorted = true;
            else
                _sorted = false;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //_mdiForm.Jarvis.OutputFileName = sqlBase.GetType().Name;// "Export Student List";
            ////_mdiForm.Jarvis.ExportOjectType = new Student();

            //_mdiForm.Jarvis.ExportFileData = _fileteredAppointments.ConvertAll(x=> x as object);
            //FileExportBase efb = new StudentFile(_mdiForm.Jarvis);
            ////FileExportDashBoard fed = new FileExportDashBoard(_mdiForm.Jarvis);
            //FileExportDashBoard fed = new FileExportDashBoard(efb);
            //fed.ShowDialog();
        }

        private void rbActiveAppointments_CheckedChanged(object sender, EventArgs e)
        {
            LoadAppointments();
            //if (rbAllActiveAppointment.Checked)
            //{
            //    _appointmentSearchClassBase = new ActiveAppointmentsClass(this);
            //    _appointmentSearchClassBase.SetDataSource();
            //}
        }

        private void rbAppointmentsWaitingClosure_CheckedChanged(object sender, EventArgs e)
        {
            LoadAppointments();
            //if (rbAppointmentsPendingClosure.Checked)
            //{
            //    _appointmentSearchClassBase = new AppointmentsWaitingClosureClass(this);
            //    _appointmentSearchClassBase.SetDataSource();
            //}
        }

        private void rbPastAppointments_CheckedChanged(object sender, EventArgs e)
        {
            LoadAppointments();
            //if (rbPastAppointments.Checked)
            //{
            //    _appointmentSearchClassBase = new PastAppointmentClass(this);
            //    _appointmentSearchClassBase.SetDataSource();
            //}
            //else if (rbAppointmentsPendingClosure.Checked)
            //{
            //    _appointmentSearchClassBase = new AppointmentsWaitingClosureClass(this);
            //    _appointmentSearchClassBase.SetDataSource();
            //}
        }

        public void LoadAppointments()
        {
            ep.SetError(dgAppointment, "");
            try
            {
                if (rbAllActiveAppointment.Checked)
                {
                    _appointmentSearchClassBase = new ActiveAppointmentsClass(this);
                    //_appointmentSearchClassBase.SetDataSource();
                }
                else if (rbAppointmentsPendingClosure.Checked)
                {
                    _appointmentSearchClassBase = new AppointmentsWaitingClosureClass(this);
                    //_appointmentSearchClassBase.SetDataSource();
                }
                else if (rbPastAppointments.Checked)
                {
                    _appointmentSearchClassBase = new PastAppointmentClass(this);
                    //_appointmentSearchClassBase.SetDataSource();
                }
                _appointmentSearchClassBase.SetDataSource();
            }
            catch (Exception ex)
            {
                ep.SetError(dgAppointment, ex.Message);
            }
        }



        private void dataGridView1_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dgr = dgAppointment.Rows[e.RowIndex];
                //int apId = (int)dgr.Cells[0].Value;
                //AppointmentBase ap = _appointmentSearchClassBase.GetAppointment(apId);
                if ((bool)dgr.Cells["IsInHouseAppointment"].Value == true)
                {
                    dgr.DefaultCellStyle.BackColor = Color.LightGreen;
                }

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
            //int index = dgAppointment.CurrentCell.RowIndex;
            //int personId = (int)dgAppointment.Rows[index].Cells[0].Value;
            //Person person = _fileteredAppointments.Find(x => x.PersonId == personId);
            //if (person != null)
            //{
            //    try
            //    {
            //        ReportViewer frm = new ReportViewer((Student)person);
            //        frm.ShowDialog();
            //        //Student student = (Student)person;
            //        ////IndividualStudentReport instrpt = new IndividualStudentReport(_mdiForm.Jarvis, student);
            //        //StudentExcelReport studentReport = new StudentExcelReport(student, _mdiForm.Jarvis);
            //        //_mdiForm.Jarvis.IncreaseFielIncrement();
            //        ////MessageBox.Show("Student file created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    }

            //    //StudentReportViewer frm = new StudentReportViewer(student);
            //    //frm.ShowDialog();
            //}
        }

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_mdiForm.Jarvis.CurrentUser.UserHasPermissionForAction("Appointment", "Add"))
                return;
            AddEditAppointment frm = new AddEditAppointment(new NewAppointment());
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.OK)
            {
                LoadAppointments();
                //SetDataSource();
            }
        }



        private void StudentSearch_Shown(object sender, EventArgs e)
        {
            dtpFrom.ValueChanged += dtpFrom_ValueChanged;
            dtpTo.ValueChanged += dtpTo_ValueChanged;
        }

        private void deleteAppintmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int index = dgAppointment.CurrentCell.RowIndex;
            if(index !=-1)
            {
                int appointmentId = (int)dgAppointment.Rows[index].Cells[0].Value;
                AppointmentBase ap = _allAppointments.Find(x=>x.AppointmentId == appointmentId);
                if (MessageBox.Show("Are you sure you want to delete appointment '"+ ap.Purpose +"' ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question)== DialogResult.Yes)
                {
                    ap.Delete();
                    LoadAppointments();
                    //SetDataSource();
                }
            }
        }

        public void dtpFrom_ValueChanged(object sender, EventArgs e)
        {
            _appointmentSearchClassBase = new PastAppointmentClass(this);
            _appointmentSearchClassBase.SetDataSource();
        }

        public void dtpTo_ValueChanged(object sender, EventArgs e)
        {
            _appointmentSearchClassBase = new PastAppointmentClass(this);
            _appointmentSearchClassBase.SetDataSource();
        }
    }    
    }
