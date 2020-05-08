using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;

namespace ClassStructure
{
    public abstract class JobState
    {
        public Job CurrentJob { get; set; }

        public JobState(Job job)
        {
            CurrentJob = job;
        }
     
        public virtual void Update()
        {

        }

        public virtual DataTable GetTasks()
        {
            string sql = "SELECT * FROM vw_Task";
            DataTable dt;
            SQLDBCommand dbc = new SQLDBCommand(SQLDBCommand.TransactionType.WithoutTransaction);
            dt = dbc.GetDataTable(sql);
            dbc.CloseConnection();
            return dt;           
        }
    }

   
}
