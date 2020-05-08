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
    public partial class ImportResidentRollCall : Form
    {
        protected ResidentRollCall _residentRollCall;
        protected ResidentRollCallData rcd;
        protected Jarvis _jarvis;
        public ImportResidentRollCall(Jarvis jarvis)
        {
            InitializeComponent();
            _residentRollCall = new ResidentRollCall();
            rcd = new ResidentRollCallData();
            _jarvis = jarvis;
            //_residentRollCall.FileName = "sdfsdfsdf";
        }

        private void ImportStudentRollCall_Load(object sender, EventArgs e)
        {
            txtFileLocation.DataBindings.Add("Text", _residentRollCall, "FileLocation");
            txtFileName.DataBindings.Add("Text", _residentRollCall, "FileName");
            txtMonthName.DataBindings.Add("Text", _residentRollCall, "MonthName");
            txtYearNumber.DataBindings.Add("Text", _residentRollCall, "YearNumber");
            txtRollReference.DataBindings.Add("Text", _residentRollCall, "LocationReference");
            txtLocationName.DataBindings.Add("Text", _residentRollCall, "LocationName");            
        }

        private void DragAndDropFile_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void DragAndDropFile_DragDrop(object sender, DragEventArgs e)
        {
            ep.Clear();
            btnSave.Enabled = false;
            var files = e.Data.GetData(DataFormats.FileDrop);
            string[] droppedFiles = (string[])files;

            try
            {
                if (droppedFiles.Length > 0)
                {
                    DMFileManager.DataFile df1 = new DMFileManager.DataFile(droppedFiles[0]);
                    if (df1.FileExtension.ToUpper() == ".XLSX" || df1.FileExtension.ToUpper() == ".XLS")
                    {
                        txtFileLocation.Text = df1.FolderName;
                        txtFileName.Text = df1.FileName;
                        if (CheckIfFileAlreadyImported())
                        {
                            MessageBox.Show("'" + _residentRollCall.FileName + "' already imported", "Import Roll Call", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtFileLocation.Text = string.Empty;
                            txtFileName.Text = string.Empty;
                        }
                        else
                        {
                            string[] arr = df1.FileName.Split('_');
                            _residentRollCall.MonthNumber = Convert.ToInt16(arr[1]);
                            txtMonthName.Text = CommonFunctions.GetMonthName(Convert.ToInt16(arr[1]));
                            _residentRollCall.MonthName = txtMonthName.Text;
                            txtYearNumber.Text = arr[2];
                            txtRollReference.Text = arr[3];
                            ImportRollCall();
                            btnSave.Enabled = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not a valid file type, only Excel files acceptable", "Drag and drop files", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Drag and drop files", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void txtFileLocation_TextChanged(object sender, EventArgs e)
        {
            _residentRollCall.FileLocation = txtFileLocation.Text;
        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            _residentRollCall.FileName = txtFileName.Text;
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            _residentRollCall.YearNumber = Convert.ToInt16(txtYearNumber.Text);
        }

        private void txtLocationReference_TextChanged(object sender, EventArgs e)
        {
            _residentRollCall.LocationReference = txtRollReference.Text;
            Location location = GetLocationFromReference();
            if (location != null)
            {
                _residentRollCall.LocationName = location.LocationName;
                _residentRollCall.LocationId = location.LocationId;
                txtLocationName.Text = location.LocationName; ;
            }
            else
            {
                MessageBox.Show("'" + _residentRollCall.LocationReference + "' is not a valid Roll reference", "Import Roll call", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        
        private bool CheckIfFileAlreadyImported()
        {            
            return rcd.CheckIfFileAlreadyImported(_residentRollCall);
        }
        private Location GetLocationFromReference()
        {            
            return rcd.getLocationFromLocationReference(_residentRollCall.LocationReference);
        }

        private void ImportRollCall()
        {
            try
            {
                string filePath = _residentRollCall.FileLocation + "\\" + _residentRollCall.FileName;
                _residentRollCall.RollTable = rcd.GetStudentRollTable(filePath);
                DeleteUnnecessaryColumns();
                RemoveEmptyRows();
                if (CheckIfDoubleColumns())
                {
                    throw new Exception("Please convert all Excel file data columns to Text type and re-try");
                }
                //if (CheckIfEmptyRows())
                //{
                //    throw new Exception("There are empty rows in the Excel file, please remove them and re-try");
                //}

                BindingSource bs = new BindingSource();
                bs.DataSource = _residentRollCall.RollTable;
                dgRollCallData.DataSource = bs;
                dgRollCallData.Refresh();
                //dgRollCallData.SortMode = DataGridViewColumnSortMode.NotSortable;
                SetDefaultColumnWidh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Import Roll Call", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckIfDoubleColumns()
        {
            bool nullTypeFound = false;
            foreach(DataColumn col in _residentRollCall.RollTable.Columns)
            {
                if(col.DataType.Name != "String")
                {
                    nullTypeFound = true;
                    break;
                }

            }
            return nullTypeFound;

        }

        private void RemoveEmptyRows()
        {
            List<DataRow> invalidRows = new List<DataRow>();
            //bool Found = false;
            foreach (DataRow dr in _residentRollCall.RollTable.Rows)
            {
                if (!CommonFunctions.IsNumeric(dr[0].ToString()))
                {
                    //_residentRollCall.RollTable.Rows.Remove(dr);
                    //Found = true;
                    //break;
                    invalidRows.Add(dr);
                }

            }
           // return Found;
           foreach(DataRow dr in invalidRows)
            {
                _residentRollCall.RollTable.Rows.Remove(dr);
            }

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
           

        }

        private void DeleteUnnecessaryColumns()
        {
            int days = DateTime.DaysInMonth(_residentRollCall.YearNumber, _residentRollCall.MonthNumber);

            int columnCount = _residentRollCall.RollTable.Columns.Count;
            //int coulmnsToDelete = columnCount - 33;

            //int i = 0;
            if (_residentRollCall.RollTable.Columns.Count> days+2)
            {
                for (int i = columnCount-1; i >= days+2; i--)
                {
                    //i = 33 + j;
                    DataColumn col = _residentRollCall.RollTable.Columns[i];
                    _residentRollCall.RollTable.Columns.RemoveAt(i);
                }

                //if (_residentRollCall.RollTable.Columns.Count == days+2)
                //{
                //    string lastcolName = _residentRollCall.RollTable.Columns[days+2].ColumnName;
                //    if (!CommonFunctions.IsNumeric(lastcolName))
                //    {
                //        _residentRollCall.RollTable.Columns.RemoveAt(days+1);
                //    }
                //}
            }

        }

        private void SetDefaultColumnWidh()
        {
            dgRollCallData.EnableHeadersVisualStyles = false;
            dgRollCallData.Columns[0].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dgRollCallData.Columns[1].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dgRollCallData.Columns[0].Width = 80;
            dgRollCallData.Columns[1].Width = 90;
            for (int i = 2; i < dgRollCallData.Columns.Count; i++)
            {
                dgRollCallData.Columns[i].Width = 32;
                dgRollCallData.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgRollCallData.Columns[i].HeaderCell.Style.Alignment= DataGridViewContentAlignment.MiddleCenter;
                string colNumber = dgRollCallData.Columns[i].Name;
                if(CommonFunctions.IsNumeric(colNumber))
                {
                    DateTime dateTime = new DateTime(_residentRollCall.YearNumber, _residentRollCall.MonthNumber, Convert.ToInt16(colNumber));
                    if (dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday)
                    {
                        dgRollCallData.Columns[i].DefaultCellStyle.BackColor = Color.Pink;
                        dgRollCallData.Columns[i].HeaderCell.Style.BackColor= Color.Pink;
                    }
                        
                }
            }
            dgRollCallData.ColumnHeadersDefaultCellStyle.BackColor = Color.LightSteelBlue;
        }

        private void dgRollCallData_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataAccess.DBCommand dbcNew = new DataAccess.DBCommand(DataAccess.DBCommand.TransactionType.WithTransaction);
            try
            {
                
                rcd = new ResidentRollCallData(dbcNew);
                rcd.SaveRollCalll(_residentRollCall);
                MoveFileToArchive(_residentRollCall);
                MessageBox.Show("Resident Roll Call saved to database successfully", "Sae Roll Call", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //this.DialogResult = DialogResult.OK;
                dgRollCallData.DataSource = null;
                dgRollCallData.Refresh();
                dbcNew.CommitTransactions();
                ResetTextBoxes();
               // dbcNew.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Import Roll Call", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dbcNew.rollbackTransactions();
            }
        }

        private void MoveFileToArchive(ResidentRollCall rc)
        {
            string fileName = rc.FileLocation + "\\" + rc.FileName;
            string movFile = _jarvis.InputFileArchiveLocation + "\\" + rc.FileName;
            DMFileManager.DataFile df = new DMFileManager.DataFile();
            df.MoveFile(fileName, movFile);

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ResetTextBoxes()
        {
            txtFileLocation.Text = string.Empty;
            txtFileName.Text = string.Empty;
            txtRollReference.TextChanged -= txtLocationReference_TextChanged;
            txtRollReference.Text = string.Empty;
            txtRollReference.TextChanged += txtLocationReference_TextChanged;
            txtLocationName.Text = string.Empty;
            //txtLocationName.Text = string.Empty;
            //txtLocationName.Text = string.Empty;

        }
    }
}
