using System;
using System.Linq;
using System.Data;

namespace RanfurlyBusiness
{
    public static class DataSortingAndCounts
    {
        public static DataTable SortAndFilterData(string Sort, string Filter, DataTable dt)
        {
            DataView dv = new DataView(dt);            
            dv.RowFilter = Filter;
            dv.Sort = Sort;
            return dv.ToTable();
        }

        public static DataTable SortOnlyData(string Sort, DataTable dt)
        {
            DataView dv = new DataView(dt);
            dv.Sort = Sort;
            return dv.ToTable();
        }

        public static DataTable FilterOnlyData(string Filter, DataTable dt)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = Filter;
            //dv.Sort = Sort;
            return dv.ToTable();
        }

        public static int GetRowCount(string Filter, DataTable dt)
        {
            DataView dv = new DataView(dt);
            dv.RowFilter = Filter;
            return dv.ToTable().Rows.Count;
        }

        public static bool CheckIfColumnExistsInDataSource(DataTable dt, string ColumnName)
        {
            //System.Collections.Generic.List<DataColumn> abccolumns = dt.Columns.Cast<DataColumn>()
            //                                  .Where(c => c.ColumnName.StartsWith(ColumnName))
            //                                  .Select(x => { x.DataType = typeof(string); return x; }).ToList();
            System.Collections.Generic.List<DataColumn> abccolumns = dt.Columns.Cast<DataColumn>()
                                              .Where(c => c.ColumnName.StartsWith(ColumnName)).ToList();
            return abccolumns.Count > 0;
        }

        public static DataTable GetGroupsAndCounts(string SortField, string Filter, DataTable DataSource)
        {            
            var groupQuery = (from table in DataSource.AsEnumerable()
                              group table by new { column1 = table[SortField] }
                                  into groupedTable
                                  select new
                                  {
                                      x = groupedTable.Key,  // Each Key contains column1 and column2 - see the commented section below
                                      //y = groupedTable.Key,  // Each Key contains column1 and column2 - see the commented section below
                                      y = groupedTable.Count()
                                  });

                DataTable groups = new DataTable();

                groups.Columns.Add("select", System.Type.GetType("System.Boolean"));
                groups.Columns.Add(SortField);
               // groups.Columns.Add("tns");
                groups.Columns.Add("count");
                foreach (var item in groupQuery)
                {
                    DataRow dr = groups.NewRow();
                    dr[SortField] = item.x.column1;
                    //dr["tns"] = item.x.column2;
                    dr["count"] = item.y;
                    groups.Rows.Add(dr);
                }
                return groups;           
        }

        public static DataTable GetGroupsNew(string SortField, string Filter, DataTable DataSource, string SplitField)
        {
            DataTable dt1 = SortAndFilterData(SortField, Filter, DataSource);

            DataTable groups = dt1.AsEnumerable()
           .GroupBy(r => new { Col1 = r[SplitField] })
           .Select(g => g.OrderBy(r => r[SplitField]).First())
           .CopyToDataTable();

            return groups;  
        }
    }
}