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
    public class FlatDataFile:DataFile
    {
        public FlatDataFile(string fileFullPath)
            : base(fileFullPath)
        {                     
        }

        public override List<string> GetAllFilesFromFolder()
        {
            List<string> files= base.GetAllFilesFromFolder();
            List<string> list = new List<string>();
            foreach (string file in files)
            {
                DataFile df = new DataFile(file);
                if (df.FileExtension.ToUpper() == ".CSV" || df.FileExtension.ToUpper() == ".TXT" || df.FileExtension.ToUpper() == ".XLS" || df.FileExtension.ToUpper() == ".XLSX")
                {                   
                    list.Add(df.FileName.ToUpper());
                }                    
            }
            return list;
        }
    }
    
}
    

