using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Microsoft.VisualBasic.FileIO;
using System.Collections;
using DataAccess;
using System.IO;
using System.Reflection;
using RanfurlyBusiness;

namespace DMFileManager
{
    public partial class DataFile
    {
        public string FileName { get; set; }
        public string FileFullPath { get; set; }
        public string FolderName { get; set; }
        public string FileNameWithoutExtension { get; set; }
        public DataTable DataSource { get; set; }
        public DataTable OutputDataSource { get; set; }
        public string OutputFileName { get; set; }
        public string FileExtension { get; set; }
        public DBCommand DBCommand { get; set; }
        public IOFileInfo IOFileInfo { get; set; }
        public ArrayList Tables { get; set; }     
        public string FileType { get; set; }
        //public List<string[]> FirstAndLastRowArray { get; set; }
        public List<object> ExportDataList { get; set; }
        public bool IsExcelColumnNames { get; set; }
        private string _parentFolder;
        public int FileIncrement { get; set; }



        public string ParentJobFolder 
        { 
            get
            {
                return _parentFolder + "\\";
            }
            set
            {
                _parentFolder = value;
            }
        
        
        }
    }
}
