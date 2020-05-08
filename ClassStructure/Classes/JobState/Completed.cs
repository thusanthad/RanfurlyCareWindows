using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;


namespace ClassStructure
{
    public class Completed : JobState
    {
        public Completed(Job job)
            : base(job)
        {}

        public override void Update()
        {
            try
            {
                if (!CheckIfAnyUndeletedTasksExists())
                    throw new Exception("You haven't entered any tasks, sorry you cannot close this job");
                if (!CheckIfJobTypeIsNewSetupAndQATaskIsEntered())
                    throw new Exception("For 'DM-New setup' jobs You need to enter a QA entry, sorry you cannot close this job");

                SQLDBCommand dbc = new SQLDBCommand(SQLDBCommand.TransactionType.WithoutTransaction);
               // string jobSQL = string.Empty;
                string jobCommand = string.Empty;

                //jobSQL = "UPDATE Job SET CustomerId={0},JobDescription='{1}',DocketNo='{2}',LotNo='{3}',LodgementDate='{4}',CampaignManagerId={5},ProgrammerId={6}," +
                //"DocketReceivedDate='{7}',NoOfRecords={8},NoOfFiles={9},IsSOARequired={10},IsPresortRequired={11},IsAddressCleansingRequired={12},IsTitleCasingRequired={13}," +
                //"JobStatusId={14}, JobTypeId={15}, JobCompletedDate='{16}',IsEDM={17},IsLabel={18},JobNotes='{19}' WHERE JobId = {20}";

                jobCommand = string.Format(SQLCommands.CompleteJob, CurrentJob.CustomerId, CurrentJob.JobDescription.Replace("'", "''"), CurrentJob.DocketNo, CurrentJob.LotNo, CurrentJob.LodgementDate, CurrentJob.CampaignManagerId,
               CurrentJob.ProgrammerId, CurrentJob.DocketReceivedDate, CurrentJob.NoOfRecords, CurrentJob.NoOfFiles, CurrentJob.IsSOARequired, CurrentJob.IsPresortRequired, CurrentJob.IsAddressCleansingRequired,
               CurrentJob.IsTitleCasingRequired, CurrentJob.JobStatusId, CurrentJob.JobTypeId, DateTime.Now, CurrentJob.IsEDM, CurrentJob.IsLabel, CurrentJob.JobNotes.Replace("'", "''"), CurrentJob.JobId);

                dbc.ExecuteCommand(jobCommand);

                // Add Job Log            
                string activity = "Job Completed - " + DateTime.Now.ToString();
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
            if (CurrentJob.JobTypeId ==1)
                return false;
            else
                return true;
        }

        private bool CheckIfAnyUndeletedTasksExists()
        {
            bool returnValue = false;
            foreach (DataRow dr in CurrentJob.JobTasks.Rows)
            {
                if (dr.RowState != DataRowState.Deleted)
                {
                    returnValue = true;                       
                }
            }
            return returnValue;
        }

        public override DataTable GetTasks()
        {
            return base.GetTasks();
        }
    }
}