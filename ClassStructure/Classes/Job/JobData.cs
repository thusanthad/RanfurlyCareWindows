using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;
using System.Data;

namespace ClassStructure
{
    public class JobData
    {              
       
        public static DataTable GetAllJobs(string sql)
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

        private static List<Job> CreateJobs(DataTable dt)
        {
            List<Job> Jobs = new List<Job>();
            foreach (DataRow dr in dt.Rows)
            {
                Job job = new Job();               
                job.DocketNo = dr["DocketNo"].ToString();
                job.LotNo = dr["LotNo"].ToString();
                job.CustomerName = dr["CustomerName"].ToString();
                job.JobDescription = dr["JobDescription"].ToString();
                job.JobNotes = dr["JobNotes"].ToString();
                job.JobId = (int)dr["JobId"];
                job.CustomerId = (int)dr["CustomerId"];
                if (String.IsNullOrEmpty(dr["HoursSpent"].ToString())) 
                    job.HoursSpent=0;
                else 
                    job.HoursSpent = (double)dr["HoursSpent"]; 
                job.JobCreatedDate = (DateTime)dr["JobCreatedDate"];
                job.LodgementDate = (DateTime)dr["LodgementDate"];
                job.NoOfRecords = (int)dr["NoOfrecords"];
                job.Programmer = dr["Programmer"].ToString();
                job.CampaignManager = dr["CampaignManager"].ToString();
                job.JobCreatedDate = (DateTime)dr["JobCreatedDate"];
                job.JobType = dr["JobType"].ToString();
                job.JobStatus = dr["JobStatus"].ToString();               
                Jobs.Add(job);
            }
            return Jobs;
        }

        public Job GetOneJob(int JobId)
        {
            string strSQL = string.Format(SQLCommands.SingleJob, JobId);             
            DataTable dt;
            SQLDBCommand dbc = new SQLDBCommand(SQLDBCommand.TransactionType.WithoutTransaction);
            dt = dbc.GetDataTable(strSQL);
            dbc.CloseConnection();
            DataRow dr = dt.Rows[0];
            
            Job job = new Job();
            job.JobId = (int)dr["JobId"];
            job.JobTypeId = (int)dr["JobTypeId"];
            job.DocketNo = dr["DocketNo"].ToString();
            job.LotNo = dr["LotNo"].ToString();                
            job.JobDescription = dr["JobDescription"].ToString();
            job.JobNotes = dr["JobNotes"].ToString();
            job.LodgementDate = (DateTime)dr["LodgementDate"];
            job.DocketReceivedDate = (DateTime)dr["DocketReceivedDate"];  
            job.CustomerId = (int)dr["CustomerId"];               
            job.JobCreatedDate = (DateTime)dr["JobCreatedDate"];
            job.NoOfRecords = (int)dr["NoOfrecords"];
            job.NoOfFiles = (int)dr["NoOfFiles"];            
            job.CampaignManagerId = (int)dr["CampaignManagerId"];
            job.ProgrammerId = (int)dr["ProgrammerId"];
            job.JobStatusId = (int)dr["JobStatusId"];
            job.IsAddressCleansingRequired = (bool)dr["IsAddressCleansingRequired"];
            job.IsPresortRequired = (bool)dr["IsPresortRequired"];
            job.IsSOARequired = (bool)dr["IsSOARequired"];
            job.IsTitleCasingRequired = (bool)dr["IsTitleCasingRequired"];
            job.IsEDM = (bool)dr["IsEDM"];
            job.IsLabel = (bool)dr["IsLabel"];

            dbc.CloseConnection();            
            JobTaskData jtd = new JobTaskData();
            job.JobTasks = jtd.GetJobTaskDT(JobId);
            return job;
        } 
    }
}
