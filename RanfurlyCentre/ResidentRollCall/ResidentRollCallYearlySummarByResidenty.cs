using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RanfurlyBusiness;
using System.Reflection;
using System.Dynamic;

namespace RanfurlyCentre
{
    public partial class ResidentRollCallYearlySummaryByResident : Form
    {
        protected List<ResidentRollCall> _residentCalls;
        protected List<ResidentCallSummaryBase> _residentYearlyCallSummarySummaryList;
        protected bool _sorted;
        protected MDIMainForm _mdiForm;
        public ResidentRollCallYearlySummaryByResident(List<ResidentRollCall> residentCalls, MDIMainForm mdiForm)
        {
            InitializeComponent();
            _residentCalls = residentCalls;
            _mdiForm = mdiForm;
        }

        private void ResidentRollCallSummary_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dgRollCallYearlySummary.AutoGenerateColumns = false;
                RollCallSummaryCalculatorBase rcsb = new RollCallYearlySummaryCalculatorByResident(_residentCalls);
                rcsb.Calculate();
                _residentYearlyCallSummarySummaryList = rcsb.ResidentCallSummaryListBase;
                SetDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDataSource()
        {
            dgRollCallYearlySummary.DataSource = _residentYearlyCallSummarySummaryList.ConvertAll(y => y as ResidentYearlyCallSummaryByResident); ;
            SetDefaultColumnProperties();
            lblRowCount.Text = "Row Count: " + _residentYearlyCallSummarySummaryList.Count;
        }

        private void SetDefaultColumnProperties()
        {            
            dgRollCallYearlySummary.EnableHeadersVisualStyles = false;           
            dgRollCallYearlySummary.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;
            dgRollCallYearlySummary.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgRollCallYearlySummary.Columns["LocationName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgRollCallYearlySummary.Columns["ResidentName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        
        private List<Location> GetResidentLocations()
        {
            LocationData ld = new LocationData();
            return ld.GetList("SELECT * FROM vw_Locations WHERE IsRollCall=true");
        }

        private void chkYearlySummary_CheckedChanged(object sender, EventArgs e)
        {           
            LoadData();
        }

        private void dgRollCallYearlySummary_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow dr = dgRollCallYearlySummary.Rows[e.RowIndex];
                for (int i = 4; i < dgRollCallYearlySummary.Columns.Count; i++)
                {
                    DataGridViewCell cell = dr.Cells[i];
                    if (cell.Value != null && cell.Value.ToString() != "0")
                    {
                        if(cell.OwningColumn.HeaderText =="Total")
                            cell.Style.BackColor = Color.LightGreen;
                        else
                            cell.Style.BackColor = Color.PaleTurquoise;
                    } 
                }
            }
        }

        private void dgRollCallYearlySummary_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.ColumnIndex;
            string propertyName = dgRollCallYearlySummary.Columns[index].DataPropertyName;
            //if (!CommonFunctions.IsNumeric(propertyName.Replace("d", "")))
            //{
            if (!_sorted)
            {
                _residentYearlyCallSummarySummaryList = _residentYearlyCallSummarySummaryList.OrderBy(p => p.GetType()
                               .GetProperty(propertyName)
                               .GetValue(p, null)).ToList();
                _sorted = true;
            }
            else
            {
                _residentYearlyCallSummarySummaryList = _residentYearlyCallSummarySummaryList.OrderByDescending(p => p.GetType()
                               .GetProperty(propertyName)
                               .GetValue(p, null)).ToList();
                _sorted = false;
            }
            SetDataSource();
            //}
        }

        private void btnExport_Click(object sender, EventArgs e)
        {

            //_mdiForm.Jarvis.OutputFileName = sqlBase.GetType().Name;// "Export Student List";
            //_mdiForm.Jarvis.ExportOjectType = new Student();

            _mdiForm.Jarvis.ExportFileData = _residentYearlyCallSummarySummaryList.ConvertAll(x => x as object);
            FileExportBase efb = new ResidentRollCallYearlySummaryFile(_mdiForm.Jarvis);
            //FileExportDashBoard fed = new FileExportDashBoard(_mdiForm.Jarvis);
            FileExportDashBoard fed = new FileExportDashBoard(efb);
            fed.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                ResidentRollCall call = _residentCalls[0];
                ReportContainer rc = new ReportContainer();
                rc.Month = call.GetMonthName();
                rc.Year = call.YearNumber.ToString(); ;
                rc.RollCallSummaryList = _residentYearlyCallSummarySummaryList;
                ReportViewer rv = new ReportViewer(rc);
                rv.Jarvis = _mdiForm.Jarvis;
                rv.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}