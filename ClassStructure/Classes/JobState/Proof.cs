using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;

namespace ClassStructure
{
    public class Proof : JobState
    {
        public Proof(Job job)
            : base(job)
        {}
        public override void Update()
        {            
            try
            {
                if (!CheckIfJobTypeIsNewSetupAndQATaskIsEntered())
                    throw new Exception("You haven't entered a QA tasks for this job, sorry you cannot change job status to Proof");

                SQLDBCommand dbc = new SQLDBCommand(SQLDBCommand.TransactionType.WithoutTransaction);
                string jobSQL = string.Empty;
                string jobCommand = string.Empty;

                jobCommand = string.Format(SQLCommands.UpdateJob, CurrentJob.CustomerId, CurrentJob.JobDescription.Replace("'", "''"), CurrentJob.DocketNo, CurrentJob.LotNo, CurrentJob.LodgementDate, CurrentJob.CampaignManagerId,
               CurrentJob.ProgrammerId, CurrentJob.DocketReceivedDate, CurrentJob.NoOfRecords, CurrentJob.NoOfFiles, CurrentJob.IsSOARequired, CurrentJob.IsPresortRequired, CurrentJob.IsAddressCleansingRequired,
               CurrentJob.IsTitleCasingRequired, 5, CurrentJob.JobTypeId, CurrentJob.IsEDM, CurrentJob.IsLabel, CurrentJob.JobNotes.Replace("'", "''"), CurrentJob.JobId);

                dbc.ExecuteCommand(jobCommand);

                // Add Job Log            
                string activity = "Job Updated to PROOF  - " + DateTime.Now.ToString();
                dbc.ExecuteCommand(string.Format(SQLCommands.InsertJobLog, CurrentJob.JobId, activity));
                dbc.CloseConnection();
                dbc.CloseConnection();

                JobTaskData jobTaskdata = new JobTaskData();
                jobTaskdata.UpdateJobTasks(CurrentJob.JobTasks);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        private bool CheckIfJobTypeIsNewSetupAndQATaskIsEntered()
        {
            foreach (DataRow dr in CurrentJob.JobTasks.Rows)
            {
                if (dr.RowState != DataRowState.Deleted)
                {
                    if (dr["TaskId"].ToString() == "2")
                        return true;
                }
            }
            if (CurrentJob.JobTypeId == 1)
                return false;
            else
                return true;
        }

        public override DataTable GetTasks()
        {              
            return base.GetTasks();
        }

    }
    
}
