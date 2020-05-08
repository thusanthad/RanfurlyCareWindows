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
    public class MSAccessDataFile : DataFile
    { 
        public MSAccessDataFile(string fileFullPath)
            : base(fileFullPath)
        {
            PopulateTables();        
        }

        public MSAccessDataFile()             
        {}

        public override void ImportData(string TableName)
        {
            
            IOFileInfo ei = new IOFileInfo();
            ei.OutputDataSource = OutputDataSource;
            ei.FileFullPath = FileFullPath;
            ei.WorkSheetName = TableName;
            
            DataAccessBase eda = new MSAccessDataAccess(ei);
            DataSource = eda.Import(TableName);
           // ReplaceSpacesWithUnderscore();
        }

        public override void SaveData()
        {
            IOFileInfo ei = new IOFileInfo();
            //CommonFunctions.SetCommonPropertyValues(this, ei);
            ei.WorkSheetName = FileName;

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
        private void PopulateTables()
        {
            IOFileInfo ei = new IOFileInfo();
            ei.FileFullPath = this.FileFullPath;
            DataAccessBase eda = new MSAccessDataAccess(ei);
            Tables = eda.GetTables();            
        }
    }
    
}
    

