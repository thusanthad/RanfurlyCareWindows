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
    public partial class RollCallSearch : Form
    {                
        public MDIMainForm _mdiForm {get;set;}
        private BindingSource _bs;
       // private List<ResidentRollCall> _allRollCalls;
        private List<ResidentRollCall> _filteredRollCalls;
        private bool _sorted;
        private ResidentRollCallData rcd;
       // private SqlGeneratorBase sqlBase;

        public RollCallSearch(MDIMainForm mdiForm)
        {
            InitializeComponent();
            _bs = new BindingSource();
            _mdiForm = mdiForm;
            rcd = new ResidentRollCallData();
        }       

        private void JobSearch_Load(object sender, EventArgs e)
        {
            //FormInitialiserBase fi = new GenericFormIntialiser(this);
            SetComboBoxDefaults();
            LoadRollCallList();
            //SetDataSource();
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
        }

        public void LoadRollCallList()
        {
            ep.SetError(dgRollCallData, "");
            try
            {
                string filter = GetFilter();
                //_allRollCalls= rcd.GetRollCalls(filter);
                _filteredRollCalls = rcd.GetRollCalls(filter); // _allRollCalls;
                SetDataSource();

                //_filteredStudentList = _allStudentList;
            }
            catch (Exception ex)
            {
                ep.SetError(dgRollCallData, ex.Message);
            }
        }

        public void SetDataSource()
        {
            ep.SetError(dgRollCallData, "");
            try
            {
                dgRollCallData.AutoGenerateColumns = false;
                _bs.DataSource = _filteredRollCalls;
                dgRollCallData.DataSource = null;
                dgRollCallData.DataSource = _bs.DataSource;
                dgRollCallData.Refresh();
                //dgRollCall.Columns[4].DefaultCellStyle.Format = "dd-MMM-yyyy";
                lblStudentCount.Text = "RollCall Count: " + dgRollCallData.Rows.Count.ToString();
                SetDefaultColumnProperties();
                dgRollCallData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;
            }
            catch (Exception ex)
            {
                ep.SetError(dgRollCallData, ex.Message);
            }

        }

        private void SetComboBoxDefaults()
        {
            DateTime dateTime = DateTime.Today;
            int month = dateTime.Month;
            int year = dateTime.Year;
            if (month == 1)
            {
                month = 12;
                year = year - 1;
            }
            else
            {
                month -= 1;
            }

            string month1 = month.ToString().PadLeft(2, '0');
            cmbMonth.Text = month1;
            cmbYear.Text = year.ToString();
        }

        private string GetFilter()
        {
            List<string> list = new List<string>();
            if (txtResidentName.Text != string.Empty)
                list.Add("ResidentName Like '%" + txtResidentName.Text + "%'");
            if (cmbMonth.Text != string.Empty)
                list.Add("MonthNumber =" + cmbMonth.Text);
            if (cmbYear.Text != string.Empty)
                list.Add("YearNumber =" + cmbYear.Text);
            if (cmbLocation.SelectedIndex>0)
                list.Add("LocationId =" + cmbLocation.SelectedValue);

            string filter = " WHERE "+ String.Join(" AND ", list.ToArray());
            return filter += " ORDER BY MonthNumber, LocationName,ResidentName";
        }

        private void SetDefaultColumnProperties()
        {
            dgRollCallData.EnableHeadersVisualStyles = false;
            dgRollCallData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;
            dgRollCallData.Columns["MonthNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgRollCallData.Columns["YearNumber"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            foreach (DataGridViewColumn col in dgRollCallData.Columns)
            {
                string columnName = col.HeaderText;
                if (CommonFunctions.IsNumeric(columnName))
                {
                    col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        } 



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdStudents_CheckedChanged(object sender, EventArgs e)
        {
            LoadRollCallList();
        }

        private void btnClose_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            txtResidentName.Text = string.Empty;
            cmbLocation.SelectedIndex = -1;
            SetComboBoxDefaults();
            LoadRollCallList();

        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            LoadRollCallList();
        }

        

        private void dataGridView1_RowHeaderMouseDoubleClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            ////if (!_mdiForm.Jarvis.CurrentUser.UserHasPermissionForAction("Student", "Edit"))
            ////    return;

            int index = e.RowIndex;
            int id = (int)dgRollCallData.Rows[e.RowIndex].Cells[0].Value;
            ResidentRollCall call = _filteredRollCalls.Find(x => x.ResidentRollCallId == id);
            if (call != null)
            {
                List<ResidentRollCall> list = new List<ResidentRollCall>();
                list.Add(call);
                ResidentRollCallEdit frm = new ResidentRollCallEdit(list);                
                frm.ShowDialog();
                if (frm.DialogResult == DialogResult.OK)
                    LoadRollCallList();
            }
        }

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.ColumnIndex;
            string propertyName = dgRollCallData.Columns[index].DataPropertyName;
            if(!CommonFunctions.IsNumeric(propertyName.Replace("d","")))
            {
                if (!_sorted)
                {
                    _filteredRollCalls = _filteredRollCalls.OrderBy(p => p.GetType()
                                   .GetProperty(propertyName)
                                   .GetValue(p, null)).ToList();
                    _sorted = true;
                }
                else
                {
                    _filteredRollCalls = _filteredRollCalls.OrderByDescending(p => p.GetType()
                                   .GetProperty(propertyName)
                                   .GetValue(p, null)).ToList();
                    _sorted = false;
                }
                SetDataSource();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            //_mdiForm.Jarvis.OutputFileName = sqlBase.GetType().Name;// "Export Student List";
            //_mdiForm.Jarvis.ExportOjectType = new Student();

            _mdiForm.Jarvis.ExportFileData = _filteredRollCalls.ConvertAll(x=> x as object);
            FileExportBase efb = new ResidentRollCalFile(_mdiForm.Jarvis);
            //FileExportDashBoard fed = new FileExportDashBoard(_mdiForm.Jarvis);
            FileExportDashBoard fed = new FileExportDashBoard(efb);
            fed.ShowDialog();
        }

       
       
     

        private void cmbLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgRollCallData.DataSource = null;
            dgRollCallData.Refresh();
            LoadRollCallList();
        }

  

        

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    int index = dgRollCall.CurrentCell.RowIndex;
        //    int personId = (int)dgRollCall.Rows[index].Cells[0].Value;
        //    Person person = _filteredStudentList.Find(x => x.PersonId == personId);
        //    if (person != null)
        //    {
        //        try
        //        {
        //            ReportViewer frm = new ReportViewer((Student)person);
        //            frm.ShowDialog();
        //            //Student student = (Student)person;
        //            ////IndividualStudentReport instrpt = new IndividualStudentReport(_mdiForm.Jarvis, student);
        //            //StudentExcelReport studentReport = new StudentExcelReport(student, _mdiForm.Jarvis);
        //            //_mdiForm.Jarvis.IncreaseFielIncrement();
        //            ////MessageBox.Show("Student file created", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //        }

        //        //StudentReportViewer frm = new StudentReportViewer(student);
        //        //frm.ShowDialog();
        //    }
        //}

        private void addNewStudentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_mdiForm.Jarvis.CurrentUser.UserHasPermissionForAction("Student", "Add"))
                return;

            ImportResidentRollCall frm = new ImportResidentRollCall(_mdiForm.Jarvis);  
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                SetComboBoxDefaults();
                LoadRollCallList();
            }
        }

       

        private void StudentSearch_Shown(object sender, EventArgs e)
        {
            cmbLocation.SelectedIndexChanged += cmbLocation_SelectedIndexChanged;
        }

        private void dgRollCallData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex != -1 )
            {
                if(chkShowWeekends.Checked)
                    ShowWeekends(e.RowIndex,true);
                else
                    ShowWeekends(e.RowIndex,false);
            }
            
        }

        private void ShowWeekends(int rowIndex,bool showHide)
        {
            DataGridViewRow dr = dgRollCallData.Rows[rowIndex];
            int month = Convert.ToInt16(dr.Cells["MonthNumber"].Value);
            int year = Convert.ToInt16(dr.Cells["YearNumber"].Value);
            foreach (DataGridViewCell cell in dr.Cells)
            {
                string columnName = cell.OwningColumn.HeaderText;
                if (CommonFunctions.IsNumeric(columnName))
                {
                    int day = Convert.ToInt16(columnName);
                    try
                    {
                        DateTime dateTime = new DateTime(year, month, day);
                        if (dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday)
                        {
                            if(showHide)
                            {
                                cell.Style.BackColor = Color.Pink;                                
                            }
                                
                            else
                                cell.Style.BackColor = Color.Empty;
                        }
                        else
                        {
                            cell.Style.BackColor = Color.Empty;
                        }
                           
                    }                    
                    catch
                    {
                        //if (showHide)
                        //{
                        //    if (cell.Value.ToString() == string.Empty)
                        //        cell.Style.BackColor = Color.Orange;
                        //    //else
                        //    //    cell.Style.BackColor = Color.Empty;

                        //}
                        //else
                        //{
                        //    cell.Style.BackColor = Color.Orange;
                        //}


                    }

                    if (showHide)
                    {
                        if (cell.Value.ToString() == string.Empty)
                            cell.Style.BackColor = Color.Yellow;
                        //else
                        //    cell.Style.BackColor = Color.Empty;

                    }
                    else
                    {
                        cell.Style.BackColor = Color.Empty; ;
                    }
                        


                }
            }
        }

        private void viewRollCallSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResidentRollCallMonthlySummary summary = new ResidentRollCallMonthlySummary(_filteredRollCalls,_mdiForm);
            summary.ShowDialog();
        }

        private void chkShowWeekends_CheckedChanged(object sender, EventArgs e)
        {
            dgRollCallData.Focus();
        }

        private void viewYearlyRollCallSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResidentRollCallYearlySummaryByResident summary = new ResidentRollCallYearlySummaryByResident(_filteredRollCalls,_mdiForm);
            summary.ShowDialog();
        }

        private void cmbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgRollCallData.DataSource = null;
            dgRollCallData.Refresh();
            if(cmbMonth.SelectedIndex==0)
            {
                viewYearlyRollCallSummaryToolStripMenuItem.Enabled = true;
                viewYearlRollCallOverallSummaryToolStripMenuItem.Enabled = true;
                viewRollCallSummaryToolStripMenuItem.Enabled = false;
            }
            else
            {
                viewYearlyRollCallSummaryToolStripMenuItem.Enabled = false;
                viewRollCallSummaryToolStripMenuItem.Enabled = true;
                viewYearlRollCallOverallSummaryToolStripMenuItem.Enabled = false;
            }
            LoadRollCallList();
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgRollCallData.DataSource = null;
            dgRollCallData.Refresh();
            LoadRollCallList();
        }

        private void txtResidentName_TextChanged(object sender, EventArgs e)
        {
            dgRollCallData.DataSource = null;
            dgRollCallData.Refresh();
        }

        private void viewYearlRollCallOverallSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResidentRollCallYearlySummaryByMonth summary = new ResidentRollCallYearlySummaryByMonth(_filteredRollCalls, _mdiForm);
            summary.ShowDialog();
        }

       

        //private void chkShowWeekends_CheckedChanged(object sender, EventArgs e)
        //{
        //    //if (chkShowWeekends.Checked)
        //    //{
        //    //    foreach(DataGridViewRow dr in dgRollCallData.Rows)
        //    //    {
        //    //       // ShowWeekends(dr.Index);
        //    //    }
        //    //}
        //}
    }    
    }

