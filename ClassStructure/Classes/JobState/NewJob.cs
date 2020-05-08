using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;

namespace ClassStructure
{
    public class NewJob : JobState
    {

        public NewJob(Job job)
            : base(job)
        {}
        //    CurrentJob = job;
        //}
        public override void Update()
        {            
            SQLDBCommand dbc = new SQLDBCommand(SQLDBCommand.TransactionType.WithoutTransaction);            
            string jobCommand = string.Format(SQLCommands.InsertJob, CurrentJob.JobTypeId, CurrentJob.CustomerId, CurrentJob.JobDescription.Replace("'", "''"), CurrentJob.DocketNo, CurrentJob.LotNo, CurrentJob.LodgementDate, CurrentJob.CampaignManagerId, CurrentJob.ProgrammerId, CurrentJob.DocketReceivedDate,
                CurrentJob.NoOfRecords, CurrentJob.NoOfFiles, CurrentJob.IsSOARequired, CurrentJob.IsPresortRequired, CurrentJob.IsAddressCleansingRequired, CurrentJob.IsTitleCasingRequired, CurrentJob.IsEDM, CurrentJob.IsLabel, CurrentJob.JobStatusId, CurrentJob.JobNotes.Replace("'", "''"));
            try
            {
                // Add Job Log
                int lastInsert = dbc.ExecuteCommand(jobCommand);
                string activity = "Job Created  - " + DateTime.Now.ToString();
                dbc.ExecuteCommand(string.Format(SQLCommands.InsertJobLog,lastInsert , activity));

                // Insert Job Tasks
                if (CurrentJob.JobTasks != null)
                {                  
                    foreach (DataRow dr in CurrentJob.JobTasks.Rows)
                    {
                        string insertJobTaskSQL = string.Format(SQLCommands.InsertJobTask, lastInsert, dr["TaskId"], dr["HoursSpent"], dr["Comments"].ToString().Replace("'", "''"));
                        dbc.ExecuteCommand(insertJobTaskSQL);
                    }
                }
                
                dbc.CloseConnection();
            }
            
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }  
        }

        public override DataTable GetTasks()
        {
            return base.GetTasks();
        }





        }

    }
    

