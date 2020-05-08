using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace DataAccess
{
    public class DataAccessBase : DataAccessProgressReporter
    {
        public IOFileInfo IoFileInfo {get;set;}
        private DataAccessEventMessenger DmEm = new DataAccessEventMessenger();

        public DataAccessBase(IOFileInfo ioFileInfo)
        {
            IoFileInfo = ioFileInfo; 
        }

        public virtual DataTable Import()
        {
            try
            {
                DataTable dt = new DataTable();
                GetParser();

                //string[] headers;
                string[] headers = IoFileInfo.TextParser.ReadFields();
                int columsToImport = headers.Length;

                DmEm.FileName = "Importing - " + IoFileInfo.FileName;

                // Add headers
                foreach (string field in headers)
                {
                    //dt.Columns.Add(field.Replace(" ", "_").ToLower());
                    dt.Columns.Add(GetColumnName(field,dt));
                }

                int recCount = System.IO.File.ReadAllLines(IoFileInfo.FileFullPath).Length;
                int rowNo = 0;

                string[] columns;
                while (!IoFileInfo.TextParser.EndOfData)
                {
                    rowNo += 1;
                    columns = IoFileInfo.TextParser.ReadFields();
                    DataRow dr = dt.NewRow();

                    if (headers.Length != columns.Length)
                    {
                        if (!dt.Columns.Contains("dataerror"))
                            dt.Columns.Add("dataerror");
                        columsToImport = CreateDiscrepancyAndGetColumnsToImport(dr, headers, columns);
                    }
                    else
                        columsToImport = headers.Length;

                    for (int i = 0; i < columsToImport; i++)
                    {
                        //dr[i] = columns[i].ToString().Trim().Replace("\r\n", " ").Replace("\r", " ").Replace("\n", " ").Replace("\"", "");
                        dr[i] = columns[i].ToString().Trim().Replace("\r\n", " | ").Replace("\r", " | ").Replace("\n", " | ").Replace("\"", " | ");
                    }
                    dt.Rows.Add(dr);

                    if (rowNo % 100 == 0)
                    {
                        DmEm.ProgressPercent = (double)rowNo / (double)recCount;
                        base.OnReportProgress(DmEm);
                    }
                }
                IoFileInfo.TextParser.Close(); ;
                IoFileInfo.TextParser.Dispose();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }       

        private int CreateDiscrepancyAndGetColumnsToImport(DataRow dr, string[] Headers, string[] Columns)
        {
            if (Headers.Length > Columns.Length)
            {
                dr["dataerror"] = "Short->Column: " + Columns.Length;
                return Columns.Length;
            }

            else
            {
                dr["dataerror"] = "Long->Column: " + Columns.Length;
                return Headers.Length;
            } 
        }

        public virtual DataTable Import(DataTable dt )
        {
            try
            {                
                GetParser();
                DmEm.FileName = "Importing - " + IoFileInfo.FileName;               

                int recCount = System.IO.File.ReadAllLines(IoFileInfo.FileFullPath).Length;
                int rowNo = 0;

                string[] columns ;
                IoFileInfo.TextParser.HasFieldsEnclosedInQuotes = true;
                while (!IoFileInfo.TextParser.EndOfData)
                {
                    rowNo += 1;
                    columns = IoFileInfo.TextParser.ReadFields();
                    if (columns.Length != dt.Columns.Count)
                        throw new Exception("Column Counts dont' match, Line No - " + rowNo + " (" + columns.Length + " vs " + dt.Columns.Count + ")");

                    DataRow dr = dt.NewRow();

                    for (int i = 0; i < columns.Length; i++)
                    {
                        dr[i] = columns[i].ToString().Trim().Replace("\"", ""); ;
                    }
                    dt.Rows.Add(dr);

                    if (rowNo % 100 == 0)
                    {
                        DmEm.ProgressPercent = (double)rowNo / (double)recCount;
                        base.OnReportProgress(DmEm);
                    }
                }
                IoFileInfo.TextParser.Close(); ;
                IoFileInfo.TextParser.Dispose(); ;
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }   

        public virtual void Save()
        {
            throw new NotImplementedException("Not implemented");
        }

        public  virtual DataTable Import(string WorksheetName)
        {
            throw new NotImplementedException("Not implemented");
        }

        public virtual ArrayList GetTables()
        {
            throw new NotImplementedException("Not implemented");
        }       

        public void GetParser()
        {
            //TextFieldParser parser = new TextFieldParser(IoFileInfo.FileFullPath, IoFileInfo., true); //new TextFieldParser(IoFileInfo.FileFullPath);
            TextFieldParser parser = new TextFieldParser(IoFileInfo.FileFullPath, Encoding.Default, true); 
            
            parser.HasFieldsEnclosedInQuotes = true;
            if (IoFileInfo.Delimiter != null && IoFileInfo.Delimiter.Length > 0)
                parser.SetDelimiters(IoFileInfo.Delimiter);
            else
                parser.SetDelimiters(GetDelimiter(IoFileInfo.FileFullPath));

            IoFileInfo.TextParser = parser;
            IoFileInfo.Delimiter = parser.Delimiters[0];

            //string[] delimiters = new string[] { ",", "|", "\t", "~", ";" };
            //parser.SetDelimiters(delimiters);
            //IoFileInfo.TextParser = parser;
        }

        public static string GetDelimiter(string FilePath)
        {
            string delimiter = string.Empty; ;
            using (System.IO.StreamReader file = new System.IO.StreamReader(FilePath))
            {
                string line = file.ReadLine();

                if (line == null)
                    throw new Exception("May be an empty file with zero bytes- please check");

                string[] fileds = line.Split('\t');
                if (fileds.Length > 1)
                {
                    delimiter = "\t";
                    return delimiter;
                }

                fileds = line.Split('|');
                if (fileds.Length > 1)
                {
                    delimiter = "|";
                    return delimiter;
                }

                fileds = line.Split('~');
                if (fileds.Length > 1)
                {
                    delimiter = "~";
                    return delimiter;
                }

                fileds = line.Split(';');
                if (fileds.Length > 1)
                {
                    delimiter = ";";
                    return delimiter;
                }

                fileds = line.Split(',');
                if (fileds.Length > 1)
                {
                    delimiter = ",";
                    return delimiter;
                }

                if (fileds.Length == 1)
                {
                    delimiter = ",";
                    return delimiter;
                }
                return delimiter;
            }              
        }

        public StreamWriter GetStreamWriter(string FileName)
        {
            if (IoFileInfo.Encoding == IOFileInfo.EncodingType.Default)
                return new StreamWriter(FileName, false, Encoding.Default);
            else
                return new StreamWriter(FileName, false, Encoding.UTF8);
        }

        //private DataRow CleanElements(DataRow drNew)
        //{
        //    drNew.ItemArray = drNew.ItemArray.Select(x => x.ToString().Replace("\"", "")).ToArray(); // double quotes
        //    //drNew.ItemArray = drNew.ItemArray.Select(x => x.ToString().Replace("12:00:00 a.m.", "").Trim()).ToArray(); // DateTime time
        //    drNew.ItemArray = drNew.ItemArray.Select(x => x.ToString().Replace("\r\n", " | ").Trim()).ToArray(); // carriage return   
        //    drNew.ItemArray = drNew.ItemArray.Select(x => x.ToString().Replace("\r", " | ").Trim()).ToArray(); // carriage return      
        //    drNew.ItemArray = drNew.ItemArray.Select(x => x.ToString().Replace("\n", " | ").Trim()).ToArray(); // carriage return  

        //    return drNew;
        //}

        public virtual string[] GetFileHeader()
        {
            GetParser();            
            return IoFileInfo.TextParser.ReadFields();
        }

        public string GetNewSplitFileName(int increment)
        {
            return IoFileInfo.FolderName + "\\" + IoFileInfo.FileNameWithoutExtension + "_" + increment + IoFileInfo.FileExtension;
        }

        public string GetColumnName(string colName, DataTable dt)
        {
            int increment = 0;  
            string checkColName = colName.Replace(" ", "_").ToLower();
            if (checkColName.Length == 0)
                //throw new Exception("There seems to be hidden empty columns on the table. Please delete them and re-try");
                checkColName = "column";
            
            string checkOrgColName = checkColName;

            if(dt.Columns.Contains(checkColName))
            {
                while (dt.Columns.Contains(checkColName))
                {
                    increment += 1;
                    checkColName = checkOrgColName + increment.ToString(); ;
                }
                return checkColName.Trim();
            }
            else
                return checkColName.Trim();
        }
    }

}
