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
    public class SaveCSVFile:DataFile
    {
        public SaveCSVFile(string fileFullPath)
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
            DataTable dt = this.GetExportDataTable(this.ExportDataList, mapper, ExportObjectType);
            //if (ConvertFieldsToRows)
            //{
            //    dt = GetConvertedDataTable(dt);
            //}
            this.IOFileInfo.FileFullPath = this.FileFullPath;
            this.IOFileInfo.OutputDataSource = dt;
            this.IOFileInfo.Delimiter = ",";
            this.IOFileInfo.CreateHeader = true;
            this.IOFileInfo.WrappedWithQuotes = true;

            DataAccessBase eda = new FlatFileDataAccess(this.IOFileInfo);
            eda.ReportProgress +=new EventHandler<DataAccessEventMessenger>(eda_ReportProgress);
            eda.Save();
        }
    }        
}
    

