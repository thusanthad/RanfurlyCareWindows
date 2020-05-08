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
    public class ProgressiveFinancialReportSaver : DataAccessBase 
    {
        //IOFileInfo _ioFileInfo;
        public ProgressiveFinancialReportSaver(IOFileInfo ioFileInfo)
            : base(ioFileInfo)
        {}

        public override void Save()        
        {
            try
            {
                var excelApp = new Excel.Application();
                excelApp.Workbooks.Add();
                Excel._Worksheet workSheet = excelApp.ActiveSheet;

                Excel.Range range = workSheet.get_Range("A1", "F1");
                range.Font.Bold = true;
                range.Font.Size = 20;
                range.Cells.Font.Color = System.Drawing.Color.Maroon;
                workSheet.Cells[1, 1] = "Progressive Rewards " + IoFileInfo.PrismNumber + " Financial Report";
                workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[1, 5]].Merge();
                workSheet.Cells[1, 1].HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;

                range = workSheet.get_Range("A1", "A3");
                workSheet.Rows[2].Cells[1].Style.Font.Size = 12;
                workSheet.Rows[2].Cells[1].Style.Font.Color = System.Drawing.Color.Black;

                workSheet.Cells[2, 7] = "Total Vouchers Needed";
                workSheet.Range[workSheet.Cells[2, 6], workSheet.Cells[2, 10]].Merge();

                range = workSheet.get_Range("A2", "E3");
                range.Cells.Interior.Color = System.Drawing.Color.FromArgb(255, 255, 204);
                range.Font.Bold = true;

                range = workSheet.get_Range("A2", "J2");
                range.Style.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                range.EntireColumn.ColumnWidth = 17;
                //range.Style.

                range = workSheet.get_Range("F2", "J3");
                range.Cells.Interior.Color = System.Drawing.Color.FromArgb(51, 153, 102); ;
                range.Font.Color = System.Drawing.Color.White;
                range.Font.Bold = true;

                for (var i = 0; i < IoFileInfo.OutputDataSource.Columns.Count; i++)
                {
                    workSheet.Cells[3, i + 1] = IoFileInfo.OutputDataSource.Columns[i].ColumnName;
                }

                for (var i = 0; i < IoFileInfo.OutputDataSource.Rows.Count; i++)
                {
                    // to do: format datetime values before printing
                    for (var j = 0; j < IoFileInfo.OutputDataSource.Columns.Count; j++)
                    {
                        workSheet.Cells[i + 4, j + 1] = IoFileInfo.OutputDataSource.Rows[i][j];
                    }
                }

                range = workSheet.get_Range("A" + IoFileInfo.OutputDataSource.Rows.Count + 1, "J" + IoFileInfo.OutputDataSource.Rows.Count + 2);
                string r1 = "A" + (IoFileInfo.OutputDataSource.Rows.Count + 2).ToString();
                string r2 = "J" + (IoFileInfo.OutputDataSource.Rows.Count + 3).ToString();
                range = workSheet.get_Range(r1, r2);
                range.Cells.Interior.Color = System.Drawing.Color.Green;
                range.Font.Color = System.Drawing.Color.White;
                range.Font.Bold = true;

                workSheet.SaveAs(IoFileInfo.FolderName + "\\Progessive_" + IoFileInfo.PrismNumber + "_Financial_Reports.xls", Excel.XlFileFormat.xlExcel8);
                excelApp.Quit();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }

    
}
