using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Collections;
using System.Data;
//using Excel = Microsoft.Office.Interop.Excel;
using System.Data.Common;

namespace DataAccess
{
    public class MSAccessDataAccess : DataAccessBase 
    {        
        public MSAccessDataAccess(IOFileInfo ioFileInfo)
            : base(ioFileInfo)
        {
            if (ioFileInfo.FileFullPath.ToUpper().Contains(".ACCDB"))
                IoFileInfo.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + IoFileInfo.FileFullPath;
            else
                IoFileInfo.ConnectionString = "Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + IoFileInfo.FileFullPath;
        }

        public override DataTable Import(string TableName)
        {
                DataTable results = new DataTable();
                using (OleDbConnection conn = new OleDbConnection(IoFileInfo.ConnectionString))
                {
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM " + TableName, conn);
                    conn.Open();
                    OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                    adapter.Fill(results);                    
                }
                results = ConvertAllColumnsToStringType(results);
                return results;
        }

        public override ArrayList GetTables()
        {
            DbProviderFactory factory = DbProviderFactories.GetFactory("System.Data.OleDb");
            DataTable userTables = null;

            ArrayList tables = new ArrayList();
            using (DbConnection connection = factory.CreateConnection())
            {
                connection.ConnectionString = IoFileInfo.ConnectionString;
                string[] restrictions = new string[4];
                //restrictions[2] = "Query";
                restrictions[3] = "Table";

                connection.Open();

                // Get list of user tables
                //userTables = connection.GetSchema("Tables", restrictions);
                userTables = connection.GetSchema("Tables");

                for (int i = 0; i < userTables.Rows.Count; i++)
                {
                    string tableName = userTables.Rows[i][2].ToString();
                    if (!tableName.StartsWith("~") && !tableName.ToUpper().StartsWith("MSYS"))
                        tables.Add(tableName);
                }
                return tables;
            }
        }

        private DataTable ConvertAllColumnsToStringType(DataTable dt)
        {
            DataTable dtNew = dt.Clone();
            foreach (DataColumn col in dtNew.Columns)
            {
                //Convert.ChangeType(col.ColumnName, typeof(String));
                dtNew.Columns[col.ColumnName].DataType = typeof(String);
            }

            foreach (DataRow dr in dt.Rows)
            {
                dtNew.ImportRow(dr);
            }
                return dtNew;
        }
    }

    
}
