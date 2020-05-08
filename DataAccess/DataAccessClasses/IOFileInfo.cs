using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Drawing;
using System.Collections;

namespace DataAccess
{
    public class IOFileInfo
    {
        public string FileFullPath { get; set; }
        public string WorkSheetName { get; set; }
        public string Delimiter { get; set; }
        public string FileExtension { get; set; }
        public DataTable OutputDataSource { get; set; }
        public int FileSplitSize { get; set; }
        public bool CreateHeader { get; set; }
        public bool WrappedWithQuotes { get; set; }
        public string FileName { get; set; }
        public string FileNameWithoutExtension { get; set; }
        public string FolderName { get; set; }
        public TextFieldParser TextParser { get; set; }
        public List<ExcelHeader> ExcelHeaders { get; set; }
        public string ConnectionString { get; set; }
        public string PrismNumber { get; set; }
        public int FileId { get; set; }
        public bool ReplaceQuotesWithEmptyString { get; set; }
        public EncodingType Encoding { get; set; }
        public string[] ExportFieldsList { get; set; }        
        //public MRD Mrd { get; set; }
        //public List<ImportDiscrepancy> ImportDiscrepancy { get; set; }    

        public IOFileInfo()
        {
            //ExcelHeaders = new List<ExcelHeader>();
            //ImportDiscrepancy = new List<ImportDiscrepancy>();
        }

        public enum EncodingType
        {
            Default,
            UTF8
        }

        public void GenerateFileDetails()
        {
            this.FileExtension = Path.GetExtension(FileFullPath);
            this.FileName = Path.GetFileName(FileFullPath);
            this.FileNameWithoutExtension = Path.GetFileNameWithoutExtension(FileFullPath);
            this.FolderName = Path.GetDirectoryName(FileFullPath);
        }

        //public void PopulatePrintSequence()
        //{
        //    int i = 1;
        //    foreach (DataRow dr in OutputDataSource.Rows)
        //    {
        //        dr["seq"] = i;
        //        dr["printseq"] = i;
        //        i += 1;
        //    }
        //}
    }

    public class ExcelHeader
    {
        public string HeaderText { get; set; }
        public System.Drawing.Font TextFont { get; set; }
        public int FontSize { get; set; }
    }

        
}
