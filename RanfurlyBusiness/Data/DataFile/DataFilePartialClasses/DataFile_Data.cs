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
namespace DMFileManager
{
    public partial class DataFile
    {
        public List<string> GetAllColumnsFromDataSource()
        {
            return DataSource.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToList();
        }

        //public List<string> GetOnlyDatasourceColumns()
        //{
        //    List<string> AllColumns = GetAllColumnsFromDataSource();
        //    List<string> SystemColumns = GlobalVariables.GetSystemFields();
        //    return AllColumns.Except(SystemColumns).ToList();
        //}

        //public void PopulateFirstAndLastRowArray()
        //{
        //    FirstAndLastRowArray.Clear();
        //    if (this.DataSource != null && this.DataSource.Rows.Count > 0)
        //    {
        //        DataTable newDt = this.DataSource.Copy();
        //        if (newDt.Columns.Contains("id"))                
        //            newDt.Columns.Remove("id");               

        //        if (newDt.Columns.Contains("select"))               
        //            newDt.Columns.Remove("select");               

        //        if (newDt.Columns.Contains("dataerror"))
        //            newDt.Columns.Remove("dataerror");

        //        FirstAndLastRowArray.Add(newDt.Rows[0].ItemArray.Cast<string>().ToArray());

        //        if(this.DataSource.Rows.Count ==1)
        //            FirstAndLastRowArray.Add(newDt.Rows[0].ItemArray.Cast<string>().ToArray());
        //        else
        //            FirstAndLastRowArray.Add(newDt.Rows[newDt.Rows.Count - 1].ItemArray.Cast<string>().ToArray());                
        //    }
        }

        //public void PopulatePrintSequence(DataTable dt,int PrintSeq)
        //{
        //    string NextJobId = string.Empty;
        //    if (CurrentJob.CreateSmartmailBarcode)
        //    {
        //        dt.Columns.Add("SmartmailBarcode");
        //        NextJobId = CurrentJob.CurrentUser.GetNetSmartmailId();
        //        CurrentJob.CurrentUser.LastSmartmailJobId = NextJobId;
        //        CurrentJob.CurrentUser.SaveLastSmartMailJob();
        //    }

        //    int i = 1;
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        dr["seq"] = i;
        //        dr["printseq"] = PrintSeq;// i;
               
        //        if (CurrentJob.CreateSmartmailBarcode)
        //            dr["SmartmailBarcode"] = CurrentJob.CurrentUser.UserSmartmailId + NextJobId + (i).ToString().PadLeft(5, '0') + "01";
                
        //        i += 1;
        //        PrintSeq += 1;            
        //    }
        //}

        //public int GetLastId()
        //{
        //    int recCount = DataSource.Rows.Count;
        //    if (recCount != 0)
        //        return Convert.ToInt32(SortAndFilterData("id", "", DataSource).Rows[recCount - 1]["id"].ToString());
        //    else
        //        return 0;
        //}

        //public void DeleteInvalids()
        //{
        //    DataSource = SortAndFilterData("", "select=false", DataSource);
        //}

        //public decimal GetPostCodePercentage()
        //{
        //    if(DataSource.Columns.Contains("postcode"))
        //    {
        //        DataRow[] rows = DataSource.Select("postcode='0'");
        //        return (decimal)rows.Length/DataSource.Rows.Count;
        //    }
        //    else
        //        return -1;            
        //}
        //public void RemoveRecordsRandomly(int RemoveCount)
        //{
        //    var rand = new Random();

        //    var selected = DataSource.Select(CurrentJob.CurrentFilter).AsEnumerable().OrderBy(r => rand.Next()).Take(RemoveCount);

        //   foreach (DataRow dr in selected)
        //   {
        //       dr["select"] = true;
        //   }
        //    DataSource = SortAndFilterData("select DESC",DataSource);
        //}

    }

