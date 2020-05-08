using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;

namespace ClassStructure
{
    public class InProgress : JobState
    {
        public InProgress(Job job)
            : base(job)
        {}
        //    CurrentJob = job;
        //}
    
        public override void Update()
        {
            SQLDBCommand dbc = new SQLDBCommand(SQLDBCommand.TransactionType.WithoutTransaction);
            string jobSQL = string.Empty;
            string jobCommand = string.Empty;

            jobCommand = string.Format(SQLCommands.UpdateJob, CurrentJob.CustomerId, CurrentJob.JobDescription.Replace("'", "''"), CurrentJob.DocketNo, CurrentJob.LotNo, CurrentJob.LodgementDate, CurrentJob.CampaignManagerId,
           CurrentJob.ProgrammerId, CurrentJob.DocketReceivedDate, CurrentJob.NoOfRecords, CurrentJob.NoOfFiles, CurrentJob.IsSOARequired, CurrentJob.IsPresortRequired, CurrentJob.IsAddressCleansingRequired,
           CurrentJob.IsTitleCasingRequired, 1, CurrentJob.JobTypeId, CurrentJob.IsEDM, CurrentJob.IsLabel, CurrentJob.JobNotes.Replace("'", "''"), CurrentJob.JobId);

            dbc.ExecuteCommand(jobCommand);

            // Add Job Log            
            string activity = "Job Updated to IN PROGRESS  - " + DateTime.Now.ToString();
            dbc.ExecuteCommand(string.Format(SQLCommands.InsertJobLog, CurrentJob.JobId, activity));
            dbc.CloseConnection();           

            JobTaskData jobTaskdata = new JobTaskData();
            jobTaskdata.UpdateJobTasks(CurrentJob.JobTasks);
        }

        public override DataTable GetTasks()
        {
            return base.GetTasks();
        }

    }
    
}
