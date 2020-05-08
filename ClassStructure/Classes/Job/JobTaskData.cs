using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DataAccess;
using System.Diagnostics;

namespace ClassStructure
{
   public class JobTaskData
    {
       public List<JobTask> GetJobTasks(int JobId)
       {
           string strSQL = string.Format("SELECT * FROM vw_JobTask WHERE JobId = {0}", JobId);
           List<JobTask> jobTasks = new List<JobTask>();
           Job Job = new Job();
           DataTable dt;
           SQLDBCommand dbc = new SQLDBCommand(SQLDBCommand.TransactionType.WithoutTransaction);
           dt = dbc.GetDataTable(strSQL);           
           foreach (DataRow dr in dt.Rows)
           {
               JobTask jobTask = new JobTask();
               jobTask.JobTaskId = (int)dr["JobTaskId"];
               jobTask.JobId = (int)dr["JobId"];
               jobTask.TaskId = (int)dr["TaskId"];
               jobTask.HoursSpent = Convert.ToDecimal(dr["HoursSpent"]);
               jobTask.Comments = dr["Comments"].ToString();
               jobTasks.Add(jobTask);
           }
           dbc.CloseConnection();
           return jobTasks;
       }

       public DataTable GetJobTaskDT(int JobId)
       {
           string strSQL = string.Format("SELECT * FROM vw_JobTask WHERE JobId = {0}", JobId);
           List<JobTask> jobTasks = new List<JobTask>();           
           DataTable dt;
           SQLDBCommand dbc = new SQLDBCommand(SQLDBCommand.TransactionType.WithoutTransaction);
           dt = dbc.GetDataTable(strSQL);           
           dbc.CloseConnection();
           return dt;
       }

       public void UpdateJobTasks(DataTable Tasks)
       {
           SQLDBCommand dbc = new SQLDBCommand(SQLDBCommand.TransactionType.WithoutTransaction);
           string strSQL =string.Empty;
           foreach (DataRow dr in Tasks.Rows)
           {
               if (dr.RowState == DataRowState.Modified)
               {
                   strSQL = "UPDATE JobTask SET TaskId={0}, HoursSpent={1}, Comments='{2}' WHERE JobTaskId = {3}";
                   strSQL = string.Format(strSQL, (int)dr["TaskId"], dr["HoursSpent"], dr["Comments"].ToString().Replace("'", "''"), (int)dr["JobTaskId"]);
                   dbc.ExecuteCommand(strSQL);
               }
               if (dr.RowState == DataRowState.Added)
               {
                   strSQL = "INSERT INTO JobTask (JobId,TaskId,HoursSpent,Comments)  Values ({0},{1},{2},'{3}')";
                   strSQL = string.Format(strSQL,(int)dr["JobId"],(int)dr["TaskId"], dr["HoursSpent"], dr["Comments"].ToString().Replace("'", "''"));
                   dbc.ExecuteCommand(strSQL);
               }
               if (dr.RowState == DataRowState.Deleted)
               {
                   int dataTaskId = (int)dr["JobTaskId", DataRowVersion.Original];
                   strSQL = "DELETE * FROM JobTask WHERE JobTaskId = {0}";
                   strSQL = string.Format(strSQL, dataTaskId);
                   dbc.ExecuteCommand(strSQL);
               }
               //Debug.WriteLine(dr.RowState);
           }
           dbc.CloseConnection();
           Tasks.AcceptChanges();          
       }  
    }
}
