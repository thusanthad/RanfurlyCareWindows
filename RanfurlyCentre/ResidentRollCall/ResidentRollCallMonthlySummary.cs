using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public partial class ResidentRollCallMonthlySummary : Form
    {
        protected List<ResidentRollCall> _residentCalls;        
        protected bool _sorted;
        protected List<ResidentCallSummaryBase> _esidentMonthlyCallSummaryList;
        protected MDIMainForm _mdiForm;
        public ResidentRollCallMonthlySummary(List<ResidentRollCall> residentCalls, MDIMainForm mdiForm)
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
                dgRollCallMonthlySummary.AutoGenerateColumns = false;
                RollCallSummaryCalculatorBase rcsb = new RollCallMonthlySummaryCalculator(_residentCalls);
                rcsb.Calculate();
                _esidentMonthlyCallSummaryList= rcsb.ResidentCallSummaryListBase;
                SetDataSource();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetDataSource()
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = _esidentMonthlyCallSummaryList.ConvertAll(y => y as ResidentMonthlyCallSummary);
            dgRollCallMonthlySummary.DataSource = bs;
            dgRollCallMonthlySummary.Visible = true;
            SetDefaultColumnProperties();
            lblRowCount.Text = "Row Count: " + _esidentMonthlyCallSummaryList.Count;
        }

        private void SetDefaultColumnProperties()
        {
            //dgRollCallMonthlySummary.AutoGenerateColumns = false;
            dgRollCallMonthlySummary.EnableHeadersVisualStyles = false;         
            


            dgRollCallMonthlySummary.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;
            dgRollCallMonthlySummary.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;           


            dgRollCallMonthlySummary.Columns["LocationName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgRollCallMonthlySummary.Columns["ResidentName"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

        }

        
        //private List<Location> GetResidentLocations()
        //{
        //    LocationData ld = new LocationData();
        //    return ld.GetList("SELECT * FROM vw_Locations WHERE IsRollCall=true");
        //}

        

       

        private void dgRollCallSummary_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            if(e.RowIndex !=-1)
            {
                DataGridViewRow dr = dgRollCallMonthlySummary.Rows[e.RowIndex];
                for(int i=5;i < dgRollCallMonthlySummary.Columns.Count;i++)
                {
                    DataGridViewCell cell = dr.Cells[i];
                    if (cell.Value != null && cell.Value.ToString() != "0")
                    {
                        if (cell.OwningColumn.HeaderText == "Total")
                            cell.Style.BackColor = Color.LightGreen;
                        else
                            cell.Style.BackColor = Color.PaleTurquoise;
                    }
                       
                }

            }
        }

        private void dgRollCallMonthlySummary_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.ColumnIndex;
            string propertyName = dgRollCallMonthlySummary.Columns[index].DataPropertyName;
            //if (!CommonFunctions.IsNumeric(propertyName.Replace("d", "")))
            //{
                if (!_sorted)
                {
                    _esidentMonthlyCallSummaryList = _esidentMonthlyCallSummaryList.OrderBy(p => p.GetType()
                                   .GetProperty(propertyName)
                                   .GetValue(p, null)).ToList();
                    _sorted = true;
                }
                else
                {
                    _esidentMonthlyCallSummaryList = _esidentMonthlyCallSummaryList.OrderByDescending(p => p.GetType()
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

            _mdiForm.Jarvis.ExportFileData = _esidentMonthlyCallSummaryList.ConvertAll(x => x as object);
            FileExportBase efb = new ResidentRollCallMonthlySummaryFile(_mdiForm.Jarvis);
            //FileExportDashBoard fed = new FileExportDashBoard(_mdiForm.Jarvis);
            FileExportDashBoard fed = new FileExportDashBoard(efb);
            fed.ShowDialog();
        }

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            if(_residentCalls.Count>0)
            {
                try
                {
                    ResidentRollCall call = _residentCalls[0];
                    ReportContainer rc = new ReportContainer();
                    rc.Month = call.GetMonthName();
                    rc.Year = call.YearNumber.ToString(); ;
                    rc.RollCallSummaryList = _esidentMonthlyCallSummaryList;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
//Shows how to create a dynamic class
//private void HowToUseDynamicClass()
//{
//    dynamic d = new MyDynamicClass();

//    d.Name = "Sarah"; // TrySetMember called with binder.Name of "Name"
//    d.Age = 42; // TrySetMember called with binder.Name of "Age"
//    d.aaaaaaaaaaaaaaaaa = "Thusantha";
//    d.bbbbbbbbbbbbbbbbbb = "Thusantha";

//    Console.WriteLine(d.Name); // TryGetMember called
//    Console.WriteLine(d.Age); // TryGetMember called
//    Console.WriteLine(d.aaaaaaaaaaaaaaaaa); // TryGetMember called
//}

//class MyDynamicClass : DynamicObject
//{
//    private readonly Dictionary<string, object> _dynamicProperties = new Dictionary<string, object>();

//    public override bool TrySetMember(SetMemberBinder binder, object value)
//    {
//        _dynamicProperties.Add(binder.Name, value);

//        // additional error checking code omitted

//        return true;
//    }

//    public override bool TryGetMember(GetMemberBinder binder, out object result)
//    {
//        return _dynamicProperties.TryGetValue(binder.Name, out result);
//    }

//    public override string ToString()
//    {
//        var sb = new StringBuilder();

//        foreach (var property in _dynamicProperties)
//        {
//            sb.AppendLine($"Property '{property.Key}' = '{property.Value}'");
//        }

//        return sb.ToString();
//    }
//}