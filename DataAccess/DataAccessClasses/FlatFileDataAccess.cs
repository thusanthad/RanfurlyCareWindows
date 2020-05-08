using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;

namespace DataAccess
{
    public class FlatFileDataAccess:DataAccessBase 
    {
        //IOFileInfo _ioFileInfo;
        private DataAccessEventMessenger DmEm = new DataAccessEventMessenger();

        public FlatFileDataAccess(IOFileInfo ioFileInfo)
            :base(ioFileInfo)
        {
            
        }

        public override DataTable Import()       
        {            
            return base.Import();
        }

        public override void Save()
        {
            IoFileInfo.GenerateFileDetails();
            string HeaderText = string.Empty;
            int splitFileCount = 1;
            try
            {
                string fileileName = string.Empty;
                if (IoFileInfo.FileSplitSize == 0)
                    fileileName = IoFileInfo.FileFullPath;
                else
                    fileileName = GetNewSplitFileName(splitFileCount);               

                //StreamWriter sw = new StreamWriter(fileileName, false, Encoding.UTF8); // earlier option was Default
                StreamWriter sw = GetStreamWriter(fileileName);

                StringBuilder builder = new StringBuilder();
                int fieldIndex = 0;
                int rowNo = 0;
                int seqNo = 0;
                DmEm.FileName = "Saving - " + IoFileInfo.FileName;

                DataColumnCollection columns = IoFileInfo.OutputDataSource.Columns;

                if (IoFileInfo.CreateHeader)
                {
                    foreach (DataColumn dc in columns)
                    {
                        fieldIndex += 1;
                        if (IoFileInfo.WrappedWithQuotes)
                            builder.Append("\"" + dc.ToString().ToLower() + "\"");
                        else
                            builder.Append(dc.ToString().ToLower());
                        if (fieldIndex != IoFileInfo.OutputDataSource.Columns.Count)
                            builder.Append(IoFileInfo.Delimiter);
                    }
                    sw.WriteLine(builder.ToString());
                    HeaderText = builder.ToString();
                }

                int recCount = IoFileInfo.OutputDataSource.Rows.Count;
                rowNo = 0;
                foreach (DataRow dr in IoFileInfo.OutputDataSource.Rows)
                        {
                            fieldIndex = 0;
                            rowNo += 1;
                            seqNo += 1;

                            builder = new StringBuilder();
                            foreach (var dc in dr.ItemArray)
                            {
                                fieldIndex += 1;
                                string outputString = string.Empty;
                                outputString = dc.ToString();

                                if (IoFileInfo.ReplaceQuotesWithEmptyString && outputString.ToString().Contains("\"")) // replace double quotes
                                     outputString = outputString.Replace("\"", "");                                    

                                if (IoFileInfo.WrappedWithQuotes)
                                    builder.Append("\"" + outputString + "\"");
                                else
                                    builder.Append(outputString);
                                if (fieldIndex != dr.ItemArray.Length)
                                    builder.Append(IoFileInfo.Delimiter);
                            }
                            sw.WriteLine(builder.ToString());

                            if (rowNo % 10 == 0)
                            {
                                DmEm.ProgressPercent = (double)rowNo / (double)recCount;
                                OnReportProgress(DmEm);
                            }

                            if (IoFileInfo.FileSplitSize != 0 && rowNo % IoFileInfo.FileSplitSize == 0 && rowNo != recCount)
                            // if (CurrentJob.FileSplitSize != 0 && rowNo % CurrentJob.FileSplitSize == 0 )
                            {
                                sw.Dispose();
                                splitFileCount += 1;
                                seqNo = 0;
                                fileileName = GetNewSplitFileName(splitFileCount);
                                //sw = new StreamWriter(fileileName, false, Encoding.UTF8);
                                sw = GetStreamWriter(fileileName);
                                sw.WriteLine(HeaderText);
                            }  
                        }
                sw.Close();
                sw.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        //private StreamWriter GetStreamWriter(string FileName)
        //{
        //    if (IoFileInfo.Encoding == IOFileInfo.EncodingType.Default)
        //        return new StreamWriter(FileName, false, Encoding.Default);  
        //    else
        //        return new StreamWriter(FileName, false, Encoding.UTF8);
        //}

        //public string GetNewSplitFileName(int increment)
        //{
        //    return IoFileInfo.FolderName + "\\" +  IoFileInfo.FileNameWithoutExtension + "_" + increment + IoFileInfo.FileExtension;
        //}
    }
}