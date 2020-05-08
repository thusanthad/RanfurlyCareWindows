using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using Microsoft.VisualBasic.FileIO;
using System.Collections;
using DataAccess;
using RanfurlyBusiness;

namespace DMFileManager
{
    public class SaveXLSXFile : DataFile
    {
        public SaveXLSXFile(string fileFullPath)
            : base(fileFullPath)
        { }

        //public SaveWorkingCopy()             
        //{}

        //public SaveWorkingCopy(CurrentJob cj)
        //    : base(cj)
        //{ }

        public override void ImportData()
        {
            throw new NotImplementedException("Not Implemented");   
        }
        public override void SaveData(List<FieldNameMapper> mapper, object ExportObjectType)
        {
            //List<Student> list = this.ExportDataList.ConvertAll(x => x as Student);
            //DataBase db = new StudentData();
            //DataTable dt = db.GeteExportDatatable(this.ExportDataList);
            this.IOFileInfo.FileFullPath = this.FileFullPath;
            DataTable dt = this.GetExportDataTable(this.ExportDataList, mapper, ExportObjectType);

            this.IOFileInfo.CreateHeader = true;
            //if (ConvertFieldsToRows)
            //{
            //    dt = GetConvertedDataTable(dt);
            //    //this.IOFileInfo.CreateHeader = false;
            //}
            this.IOFileInfo.OutputDataSource = dt;
            this.IOFileInfo.Delimiter = ",";
            
            this.IOFileInfo.WorkSheetName = this.FileNameWithoutExtension;

            DataAccessBase eda = new ExcelDataAccess(this.IOFileInfo);
            eda.ReportProgress += new EventHandler<DataAccessEventMessenger>(eda_ReportProgress);
            eda.Save();
          
        }
    }        
}
    

