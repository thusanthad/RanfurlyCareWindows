using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.VisualBasic.FileIO;
using System.Collections;
using System.IO;
using System.Reflection;
using DataAccess;
using RanfurlyBusiness;


namespace DMFileManager
{
    public partial class DataFile : DMEProgressReporter, Interface2
    {
        private DMEventMessenger DmEm = new DMEventMessenger(); 

        public DataFile() 
        {
            IOFileInfo = new IOFileInfo();
        }

        //public DataFile(CurrentJob Cj) // Export file
        //{
        //    CurrentJob = Cj;
        //    SetDefaults();

        //    //if (CurrentJob.SelectedDataFile !=null && CurrentJob.SelectedDataFile.IsExcelColumnNames)
        //    //    throw new Exception("Please change Column headers back to original names");  
        //}

        public DataFile(string fileFullPath) // Import file
        {
            IOFileInfo = new IOFileInfo();
            SetFileFullPath(fileFullPath);
            FileIncrement = FileIncrement;
           // WorkSheets = new List<WorkSheet>();
           /// FirstAndLastRowArray = new List<string[]>();
        }

        public void SetFileFullPath(string fileFullPath)
        {
            this.FileFullPath = fileFullPath;
            this.FileExtension = Path.GetExtension(FileFullPath).ToUpper();
            this.FileName = Path.GetFileName(FileFullPath);
            this.FileNameWithoutExtension = Path.GetFileNameWithoutExtension(FileFullPath);
            this.FolderName = Path.GetDirectoryName(FileFullPath);
            //this.ParentJobFolder = Directory.GetParent(this.FolderName).FullName;
        }

        //public void SetDefaults()
        //{
        //    IOFileInfo = new IOFileInfo();
        //    IOFileInfo.WrappedWithQuotes = true;
        //    IOFileInfo.CreateHeader = true;
        //    IOFileInfo.Delimiter = ",";
        //    IOFileInfo.WrappedWithQuotes = true;
        //    if (CurrentJob.Encoding == CurrentJob.EncodingType.Default) 
        //        IOFileInfo.Encoding = IOFileInfo.EncodingType.Default;
        //    else
        //        IOFileInfo.Encoding = IOFileInfo.EncodingType.UTF8;
        //}

        public virtual void ImportData()
        {
            IOFileInfo ei = new IOFileInfo();
            ei.FileFullPath = FileFullPath;
            ei.FileName = FileName;

            DataAccessBase eda = new FlatFileDataAccess(ei);
            eda.ReportProgress += eda_ReportProgress;
            DataSource = eda.Import();
           // RemoveSpecialCharactersFromColumns();
        }

        public virtual void ImportData(DataTable dt)
        {
            IOFileInfo ei = new IOFileInfo();
            ei.FileFullPath = FileFullPath;
            ei.FileName = FileName;

            DataAccessBase eda = new FlatFileDataAccess(ei);
            eda.ReportProgress += eda_ReportProgress;
            DataSource = eda.Import(dt);   
        }

        public virtual object ImportXML()
        {
            throw new NotImplementedException("Not Implemented");
        }

        //public virtual List<string> GetTableHeaderList()
        //{
        //    //List<string> systemFields = GlobalVariables.GetSystemFields(); ;// ; PopulateSystemFieldArray();
        //    List<string> fields;
        //    if (DataSource == null)
        //    {
        //        fields = GetFileHeaderList();
        //    }
        //    else
        //    {
        //        fields = GetAllColumnsFromDataSource();
        //    }
        //    return fields.Except(systemFields).ToList();            
        //}

        //private List<string> GetFileHeaderList() // Populate headers without populating data - mainly for schema check
        //{
        //    IOFileInfo ei = new IOFileInfo();
        //    ei.FileFullPath = FileFullPath;
        //    ei.FileName = FileName;

        //    int increment = 0;

        //    DataAccessBase eda = new FlatFileDataAccess(ei); 
        //    List<string> fieldsFromFile = new List<string>();
        //    foreach (string str in eda.GetFileHeader().ToList())
        //    {
        //        string fieldName = str.Replace(" ", "_").ToLower();
        //        if (fieldsFromFile.Contains(fieldName))
        //        {
        //            increment += 1;
        //            fieldName += increment;
        //        }
        //        fieldsFromFile.Add(fieldName);
        //    }
        //    return CommonFunctions.RemoveSpecialCharacters(fieldsFromFile);
        //}

        public virtual void ImportData(string TableName)
        {
            throw new NotImplementedException("Not Implemented");
        }

        public virtual void SaveData()
        {
            throw new NotImplementedException("Not Implemented");
        }

        public virtual void SaveData(List<FieldNameMapper> list, object exportObjectType)
        {
            throw new NotImplementedException("Not Implemented");
        }

        public virtual void SaveData(object xml)
        {
            throw new NotImplementedException("Not Implemented");
        }

        public virtual void ProcessData()
        {
            throw new NotImplementedException("Not Implemented");
        } 

        public void eda_ReportProgress(object sender, DataAccessEventMessenger e)
        {
            DmEm.ProgressPercent = e.ProgressPercent;
            DmEm.FileName = e.FileName;
            OnReportProgress(DmEm);
        }

        protected DataTable GetExportDataTable(List<object> list, List<FieldNameMapper> mapper, object ExportObjectType)
        {
            DataTable dt;
            if (ExportObjectType is Student)
            {
                List<Student> listNew = list.ConvertAll(x => x as Student);
                dt = CommonFunctions.ToDataTable<Student>(listNew);
            }
            else if (ExportObjectType is Staff)
            {
                List<Staff> listNew = list.ConvertAll(x => x as Staff);
                dt = CommonFunctions.ToDataTable<Staff>(listNew);
            }
            else if (ExportObjectType is Doctor)
            {
                List<Doctor> listNew = list.ConvertAll(x => x as Doctor);
                dt = CommonFunctions.ToDataTable<Doctor>(listNew);
            }
            else if (ExportObjectType is Specialist)
            {
                List<Specialist> listNew = list.ConvertAll(x => x as Specialist);
                dt = CommonFunctions.ToDataTable<Specialist>(listNew);
            }
            else if (ExportObjectType is Incident)
            {
                List<Incident> listNew = list.ConvertAll(x => x as Incident);
                dt = CommonFunctions.ToDataTable<Incident>(listNew);
            }
            else if (ExportObjectType is ResidentRollCall)
            {
                List<ResidentRollCall> listNew = list.ConvertAll(x => x as ResidentRollCall);
                dt = CommonFunctions.ToDataTable<ResidentRollCall>(listNew);
            }
            else if (ExportObjectType is ResidentMonthlyCallSummary)
            {
                List<ResidentMonthlyCallSummary> listNew = list.ConvertAll(x => x as ResidentMonthlyCallSummary);
                dt = CommonFunctions.ToDataTable<ResidentMonthlyCallSummary>(listNew);
            }
            else if (ExportObjectType is ResidentYearlyCallSummaryByResident)
            {
                List<ResidentYearlyCallSummaryByResident> listNew = list.ConvertAll(x => x as ResidentYearlyCallSummaryByResident);
                dt = CommonFunctions.ToDataTable<ResidentYearlyCallSummaryByResident>(listNew);
            }
            else if (ExportObjectType is ResidentYearlyCallSummaryByMonth)
            {
                List<ResidentYearlyCallSummaryByMonth> listNew = list.ConvertAll(x => x as ResidentYearlyCallSummaryByMonth);
                dt = CommonFunctions.ToDataTable<ResidentYearlyCallSummaryByMonth>(listNew);
            }
            else
            {
                throw new NotImplementedException("not implemented");
            }

            //List<Student> list = this.ExportDataList.ConvertAll(x => x as Student);


            
            List<DataColumn> columnsToBeRemoved = new List<DataColumn>();
            List<FieldNameMapper> columnsToBeAdded = new List<FieldNameMapper>();
            foreach (DataColumn col in dt.Columns)
            {
                FieldNameMapper fm = mapper.Find(x => x.PropertyName == col.ColumnName && x.Selected==true);
                if (fm != null)
                {
                    columnsToBeAdded.Add(fm);
                }
                else
                {
                    //dt.Columns.Remove(col);
                    columnsToBeRemoved.Add(col);
                }
            }

            foreach (DataColumn col in columnsToBeRemoved)
            {
                dt.Columns.Remove(col);
            }

            columnsToBeAdded = columnsToBeAdded.OrderBy(x => x.ColumnPosition).ToList();

            foreach (FieldNameMapper map in columnsToBeAdded)
            {
                DataColumn col = dt.Columns[map.PropertyName];
                col.ColumnName = map.PrintName;
                col.SetOrdinal((int)map.ColumnPosition-1);
            }


            return dt;
        }

        protected DataTable GetConvertedDataTable(DataTable dt)
        {
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Student Report");
            dt1.Columns.Add(" ");

            foreach (DataColumn col in dt.Columns)
            {
                DataRow dr1 = dt1.NewRow();
                dr1["Student Report"] = col.ColumnName;
                dr1[" "] = dt.Rows[0][col.ColumnName].ToString();
                dt1.Rows.Add(dr1);
            }
            return dt1;
        }

        //protected void PopulateCorrectFileType()
        //{
        //    IOFileInfo.Delimiter = CurrentJob.Delimiter;
        //    if (IOFileInfo.Delimiter != ",")
        //    {
        //        IOFileInfo.WrappedWithQuotes = false;
        //        this.IOFileInfo.FileFullPath = this.IOFileInfo.FileFullPath.Replace(".csv", ".txt");
        //    }
        //}     

        //public string GetErrorMessage()
        //{
        //    return "Column 'seq' doesn't contain in the database. Please process data first or manually add 'seq' and 'printseq' fields";   
        //}        
    }
}
