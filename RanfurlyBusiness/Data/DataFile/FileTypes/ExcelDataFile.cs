using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using Microsoft.VisualBasic.FileIO;
using System.Collections;
using System.Data.OleDb;
using DataAccess;

namespace DMFileManager
{
    public class ExcelDataFile:DataFile
    {
        public ExcelDataFile(string fileFullPath)
            : base(fileFullPath)
        { 
            //PopulateWorksheets();
            //WorkSheetsToImport = new List<WorkSheet>();            
        }

        //public ExcelDataFile(string folderName, string filName)
        //    : base(folderName, filName)
        //{
        //}

        public override void ImportData()
        {
            throw new NotImplementedException("Not implemented");
        }

        public override void ImportData(string WorkSheetName)
        {
            IOFileInfo ei = new IOFileInfo();
            ei.FileFullPath = FileFullPath;            
            DataAccessBase eda = new ExcelDataAccess(ei);
            DataSource = eda.Import(WorkSheetName);
            //RemoveSpecialCharactersFromColumns();
            //PopulateTableHeader();
            //PopulateFirstAndLastRowArray();
        }

        public override void SaveData()
        {
            IOFileInfo ei = new IOFileInfo();
           // CommonFunctions.SetCommonPropertyValues(this, ei);
            ei.WorkSheetName = FileName;
            ei.FileFullPath = this.FolderName + "\\" + FileName + ".XLSX";

            DataAccessBase eda = new ExcelDataAccess(ei);
            eda.Save();
        }

        //public override void Import()
        //{
        //    //base.Import();
        //}

        public override void ProcessData()
        {

        }

        //private void PopulateWorksheets()
        //{
        //    IOFileInfo ei = new IOFileInfo();
        //    ei.FileFullPath = this.FileFullPath;
        //    DataAccessBase eda = new ExcelDataAccess(ei);
        //    ArrayList workSheets = eda.GetTables();
        //    foreach (string workSheet in workSheets)
        //    {
        //        WorkSheet ws = new WorkSheet();
        //        ws.WorkSheetName = workSheet;
        //        WorkSheets.Add(ws);
        //    }
        //}

        //public override string[] GetAllFilesFromFolder()
        //{
        //    string[] files = base.GetAllFilesFromFolder();
        //    ArrayList fileList = new ArrayList();
        //    foreach (string file in files)
        //    {
        //        if (file.ToUpper().Contains(".XLS") || file.ToUpper().Contains(".XLS"))
        //            fileList.Add(file);
        //    }
        //    return (string[])fileList.ToArray();
        //}
    }
    
}
    

