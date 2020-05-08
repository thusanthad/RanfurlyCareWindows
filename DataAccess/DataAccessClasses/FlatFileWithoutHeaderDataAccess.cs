using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Diagnostics;

namespace DataAccess
{
    public class FlatFileWithoutHeaderDataAccess:DataAccessBase 
    {
        //IOFileInfo _ioFileInfo;
        private DataAccessEventMessenger DmEm = new DataAccessEventMessenger();

        public FlatFileWithoutHeaderDataAccess(IOFileInfo ioFileInfo)
            :base(ioFileInfo)
        {
            //_ioFileInfo = ioFileInfo;
        }

        public override DataTable Import()       
        {
            try
            {
                DataTable dt = new DataTable();
                GetParser();

               // string[] headers;
                //headers = IoFileInfo.TextParser.ReadFields();

                DmEm.FileName = "Importing - " + IoFileInfo.FileName;
                
                // Add headers
                //for (int i = 0; i < headers.Length; i++)
                //{
                dt.Columns.Add("Field1");
                //}
               
                int recCount = System.IO.File.ReadAllLines(IoFileInfo.FileFullPath).Length;
                int rowNo = 0;

                //string[] columns;
                while (!IoFileInfo.TextParser.EndOfData)
                {
                    Debug.Print(IoFileInfo.TextParser.LineNumber.ToString());
                    rowNo += 1;
                    //columns = IoFileInfo.TextParser.ReadFields();
                    string lineValue = IoFileInfo.TextParser.ReadLine();
                    DataRow dr = dt.NewRow();

                    //for (int i = 0; i < columns.Length; i++)
                    //{
                    dr["Field1"] = lineValue;// columns[i].ToString().Trim().Replace("\"", ""); ;
                    //}
                    dt.Rows.Add(dr);

                    if (rowNo % 100 == 0)
                    {
                        DmEm.ProgressPercent = (double)rowNo / (double)recCount;
                        //DmEm.FileName = IoFileInfo.FileName;
                        base.OnReportProgress(DmEm);
                    }
                }
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}