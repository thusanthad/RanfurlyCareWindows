using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Collections;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;

namespace DataAccess
{
    public class ExcelDataAccess : DataAccessBase 
    {
        private DataAccessEventMessenger DmEm = new DataAccessEventMessenger();
        public ExcelDataAccess(IOFileInfo ioFileInfo):base(ioFileInfo)
        {
            //_ioFileInfo = ioFileInfo; 
        }

        public override ArrayList GetTables()
        {
            ArrayList al = new ArrayList();
            OleDbConnectionStringBuilder sbConnection = GeteConnectionBuilder(IoFileInfo.FileFullPath);
            using (OleDbConnection conn = new OleDbConnection(sbConnection.ToString()))
            {
                conn.Open();
                DataTable dtSheet = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                foreach (DataRow drSheet in dtSheet.Rows)
                {
                    if (drSheet["TABLE_NAME"].ToString().Contains("$"))//checks whether row contains '_xlnm#_FilterDatabase' or sheet name(i.e. sheet name always ends with $ sign)
                    {
                        al.Add(drSheet["TABLE_NAME"].ToString().Replace("$", "").Replace("'", ""));
                    }
                }
            }
            return al;
        }

        private OleDbConnectionStringBuilder GeteConnectionBuilder(string FileFullPath)
        {
            OleDbConnectionStringBuilder sbConnection = new OleDbConnectionStringBuilder();
            String strExtendedProperties = String.Empty;
            sbConnection.DataSource = FileFullPath;

            if (System.IO.Path.GetExtension(FileFullPath).ToUpper().Equals(".XLS"))//for 97-03 Excel file
            {
                sbConnection.Provider = "Microsoft.Jet.OLEDB.4.0";
                strExtendedProperties = "Excel 8.0;HDR=No;IMEX=1";//HDR=ColumnHeader,IMEX=InterMixed
            }
            else if (System.IO.Path.GetExtension(FileFullPath).ToUpper().Equals(".XLSX"))  //for 2007 Excel file
            {
                sbConnection.Provider = "Microsoft.ACE.OLEDB.12.0";
                strExtendedProperties = "Excel 12.0;HDR=No;IMEX=1";
                //strExtendedProperties = "Excel 12.0;HDR=Yes;IMEX=100";

                //changed to HDR=No and then rename column headers and delete frist row 'RenameColumnsToFirstRowValues' module
            }
            sbConnection.Add("Extended Properties", strExtendedProperties);

            return sbConnection;
        }

        public override DataTable Import(string WorksheetName)
        {            
            DataTable dt = new DataTable();
            {
                OleDbConnectionStringBuilder sbConnection = GeteConnectionBuilder(IoFileInfo.FileFullPath);
                using (OleDbConnection conn = new OleDbConnection(sbConnection.ToString()))
                {
                    conn.Open();
                    var adapter = new OleDbDataAdapter("SELECT * FROM [" + WorksheetName + "$]", conn);
                    adapter.Fill(dt);
                    RenameColumnsToFirstRowValues(dt);
                    return dt;
                }
            }           
        }

        private void RenameColumnsToFirstRowValues(DataTable dt)
        {
            if (dt.Rows.Count > 0)
            {
                foreach (DataColumn col in dt.Columns)
                {
                    string columnName = GetColumnName(dt.Rows[0][col].ToString(), dt);
                    col.ColumnName = columnName.Trim('_');
                }
                dt.Rows[0].Delete();
                dt.AcceptChanges();
            }
            else
                throw new Exception("Cannot recognise data structure");
        }

        //private void RenameColumnsToFirstRowValues(DataTable dt)
        //{
        //    if (dt.Rows.Count > 0)
        //    {
        //        int emptyColuNameIncrement = 0;
        //        //DataTable newDt = dt.Clone();
        //        foreach (DataColumn col in dt.Columns)
        //        {
        //            string columnName = dt.Rows[0][col].ToString().Trim().ToLower().Replace(" ", "_");
        //            //string columnName = GetColumnName(
        //            if (dt.Columns.Contains(columnName))
        //                columnName += 1; //for duplicate column names

        //            if (columnName == string.Empty) // for empty column names
        //            {
        //                emptyColuNameIncrement += 1;
        //                columnName = "col" + emptyColuNameIncrement;
        //            }
        //            col.ColumnName = columnName;//.ToLower().Replace(" ", "_");
        //        }
        //        dt.Rows[0].Delete();
        //        dt.AcceptChanges();
        //    }
        //}

        public override void Save()        
        {
            Excel.Application xlApp = new Excel.Application();
            xlApp.Workbooks.Add();
            //Excel.Workbook wb = new Excel.Workbook();
            Excel._Worksheet workSheet = xlApp.ActiveSheet;
            workSheet.Name = IoFileInfo.WorkSheetName;

            int headerCount = 1;

            //if (IoFileInfo.ExcelHeaders.Count > 0)
            //{
            //foreach(DataColumn col in IoFileInfo.OutputDataSource.Columns)
            ////foreach (ExcelHeader eh in IoFileInfo.ExcelHeaders)
            ////{
            //workSheet.Cells[headerCount, 1] = col.ColumnName;
            //workSheet.Cells[headerCount,1].Style.Font.Size = 14;
            //workSheet.Cells[headerCount, 1].Style.Font = System.Drawing.FontStyle.Bold;
            ////    headerCount += 1;
            ////}
            // }
            int recCount = IoFileInfo.OutputDataSource.Rows.Count;

            if (IoFileInfo.CreateHeader)
            {
                for (var i = 0; i < IoFileInfo.OutputDataSource.Columns.Count; i++)
                {
                    workSheet.Cells[headerCount, i + 1] = IoFileInfo.OutputDataSource.Columns[i].ColumnName;
                    workSheet.Cells[headerCount, i + 1].Style.Font.Size = 12;
                    workSheet.Cells[headerCount, i + 1].Font.Bold = true;
                    workSheet.Columns[i+1].ColumnWidth = 25;
                    workSheet.Cells[headerCount, i + 1].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                }
            }

            headerCount += 1;

            for (var i = 0; i < IoFileInfo.OutputDataSource.Rows.Count; i++)
            {
                // to do: format datetime values before printing
                for (var j = 0; j < IoFileInfo.OutputDataSource.Columns.Count; j++)
                {
                    workSheet.Cells[i + headerCount, j + 1] = IoFileInfo.OutputDataSource.Rows[i][j];
                    workSheet.Cells[i + headerCount, j + 1].Style.Font.Size = 12;
                    //workSheet.Columns[i + headerCount, j + 1].ColumnWidth = 30;
                    //workSheet.Cells[i + headerCount, j + 1].Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                }

                if (i % 10 == 0)
                {
                    DmEm.ProgressPercent = (double)i / (double)recCount;
                    OnReportProgress(DmEm);
                }
            }

            if (IoFileInfo.FileFullPath.ToUpper().Contains(".XLSX"))
                workSheet.SaveAs(IoFileInfo.FileFullPath);
            else
                workSheet.SaveAs(IoFileInfo.FileFullPath, Excel.XlFileFormat.xlExcel8);

           // xlApp.Columns.AutoFit();

            xlApp.Quit();
        }
    }

    
}
