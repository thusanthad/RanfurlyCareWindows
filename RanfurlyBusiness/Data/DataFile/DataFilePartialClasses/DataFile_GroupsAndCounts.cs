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
        //public DataTable GetGroups()
        //{
        //    DataTable dt1 = SortAndFilterData(CurrentJob.SortField, CurrentJob.CurrentFilter, CurrentJob.SelectedDataFile.DataSource);

        //    DataTable groups = dt1.AsEnumerable()
        //   .GroupBy(r => new { Col1 = r[CurrentJob.SplitField] })
        //   .Select(g => g.OrderBy(r => r[CurrentJob.SplitField]).First())
        //   .CopyToDataTable();

        //    return groups;
        //}

        public DataTable GetGroupsAndCounts(string SortField, string Filter, DataTable DataSource)
        {
            // DataTable sortedAndFilterd = DataSortingAndCounts.SortAndFilterData(SortField, Filter, DataSource);

            var groupQuery = (from table in DataSource.AsEnumerable()
                              group table by new { column1 = table[SortField] }
                                  into groupedTable
                                  select new
                                  {
                                      x = groupedTable.Key,  // Each Key contains column1 and column2 - see the commented section below
                                      y = groupedTable.Count()
                                  });

            DataTable groups = new DataTable();

            groups.Columns.Add("select", System.Type.GetType("System.Boolean"));
            groups.Columns.Add(SortField);
            groups.Columns.Add("count");
            foreach (var item in groupQuery)
            {
                DataRow dr = groups.NewRow();
                dr[SortField] = item.x.column1;
                dr["count"] = item.y;
                groups.Rows.Add(dr);
            }
            return groups;
        }

       

        
    }
}
