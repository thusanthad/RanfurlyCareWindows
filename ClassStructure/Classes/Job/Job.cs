using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ClassStructure
{
    public class Job
    {
        public int JobId { get; set; }
        public int JobTypeId { get; set; }
        public string JobType { get; set; }
        public int JobStatusId { get; set; }
        public string JobStatus { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string JobDescription { get; set; }
        public string JobNotes { get; set; }
        public string DocketNo { get; set; }
        public string LotNo { get; set; }
        public DateTime LodgementDate { get; set; }       
        public DateTime JobCreatedDate { get; set; }
        public DateTime DocketReceivedDate { get; set; }
        public int CampaignManagerId { get; set; }
        public string CampaignManager { get; set; }
        public int ProgrammerId { get; set; }
        public string Programmer { get; set; }
        public DataTable JobTasks { get; set; }
        public bool IsSOARequired { get; set; }
        public bool IsPresortRequired { get; set; }
        public bool IsAddressCleansingRequired { get; set; }
        public bool IsTitleCasingRequired { get; set; }
        public bool IsEDM { get; set; }
        public bool IsLabel { get; set; }
        public int NoOfFiles{ get; set; }
        public int NoOfRecords { get; set; }
        public double HoursSpent { get; set; }
    }
}
