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
    public class SaveTXTFile : DataFile
    {
        public SaveTXTFile(string fileFullPath)
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
            DataTable dt = this.GetExportDataTable(this.ExportDataList, mapper, ExportObjectType);
            //if (ConvertFieldsToRows)
            //{
            //    dt = GetConvertedDataTable(dt);
            //}
            this.IOFileInfo.FileFullPath = this.FileFullPath;
            this.IOFileInfo.OutputDataSource = dt;
            this.IOFileInfo.Delimiter = "|";
            this.IOFileInfo.CreateHeader = true;

            DataAccessBase eda = new FlatFileDataAccess(this.IOFileInfo);
            eda.ReportProgress += new EventHandler<DataAccessEventMessenger>(eda_ReportProgress);
            eda.Save();
        }


    }
}
    

