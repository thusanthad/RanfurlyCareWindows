using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;

namespace ClassStructure
{
    public class TaskData
    {
        public static DataTable GetAllTasks(string sql)
        {
            try
            {
                DataTable dt;
                SQLDBCommand dbc = new SQLDBCommand(SQLDBCommand.TransactionType.WithoutTransaction);
                dt = dbc.GetDataTable(sql);
                dbc.CloseConnection();
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }    

    }
}
