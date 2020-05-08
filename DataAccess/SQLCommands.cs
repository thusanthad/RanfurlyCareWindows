using System;
using System.Data;
using System.Configuration;
using System.Web;



/// <summary>
/// Keeps the values of the constants
/// </summary>
/// 

namespace RanfurlyBusiness
{
     public static class SQLCommands
    {
       public static string User
        {
            get
            {
                return "SELECT * FROM vw_SystemUsers WHERE UserName ='{0}' AND UserPassword ='{1}'"; ;
            }           
        }
       
        public static string AllJobs
        {
            get
            {
                return "SELECT * FROM vw_Jobs";
            }
        }
        
        public static string SingleJob
        {
            get
            {
                return "SELECT * FROM Job WHERE JobId = {0}";
            }
        }

         public static string InsertJob
         {
             get
             {
                 return "INSERT INTO Job (JobTypeId,CustomerId,JobDescription,DocketNo,LotNo,LodgementDate,CampaignManagerId,ProgrammerId," +
            "DocketReceivedDate,NoOfRecords,NoOfFiles,IsSOARequired,IsPresortRequired,IsAddressCleansingRequired,IsTitleCasingRequired, IsEDM,IsLabel,JobStatusId,JobNotes)  Values ({0},{1},'{2}','{3}','{4}'," +
            "'{5}',{6},{7},'{8}','{9}','{10}',{11},{12},{13},{14},{15},{16},{17},'{18}')";
             }
         }

         public static string CreateJobFromPreviousJob
         {
             get
             {
                 return "INSERT INTO Job (JobTypeId,CustomerId,JobDescription,DocketNo,LotNo,LodgementDate,CampaignManagerId,ProgrammerId," +
            "DocketReceivedDate,NoOfRecords,NoOfFiles,IsSOARequired,IsPresortRequired,IsAddressCleansingRequired,IsTitleCasingRequired, IsEDM,IsLabel,JobStatusId)  SELECT TOP 1 JobTypeId,CustomerId,JobDescription,'{0}','{1}',LodgementDate,CampaignManagerId,ProgrammerId," +
            "DocketReceivedDate,NoOfRecords,NoOfFiles,IsSOARequired,IsPresortRequired,IsAddressCleansingRequired,IsTitleCasingRequired, IsEDM,IsLabel,JobStatusId FROM Job WHERE DocketNo ='{2}' and CustomerId = {3}";
             }
         }

         public static string CompleteJob
         {
             get
             {
                 return "UPDATE Job SET CustomerId={0},JobDescription='{1}',DocketNo='{2}',LotNo='{3}',LodgementDate='{4}',CampaignManagerId={5},ProgrammerId={6}," +
                "DocketReceivedDate='{7}',NoOfRecords={8},NoOfFiles={9},IsSOARequired={10},IsPresortRequired={11},IsAddressCleansingRequired={12},IsTitleCasingRequired={13}," +
                "JobStatusId={14}, JobTypeId={15}, JobCompletedDate='{16}',IsEDM={17},IsLabel={18},JobNotes='{19}' WHERE JobId = {20}";
             }
         }
        

         public static string InsertJobLog
         {
             get
             {
                 return "INSERT INTO JobLog (JobId,Activity) VALUES ({0},'{1}')";
             }
         }

         public static string InsertJobTask
         {
             get
             {
                 return "INSERT INTO JobTask (JobId,TaskId,HoursSpent,Comments)  Values ({0},{1},{2},'{3}')";
             }
         }

          public static string UpdateJob
         {
             get
             {
                 return "UPDATE Job SET CustomerId={0},JobDescription='{1}',DocketNo='{2}',LotNo='{3}',LodgementDate='{4}',CampaignManagerId={5},ProgrammerId={6}," +
                "DocketReceivedDate='{7}',NoOfRecords={8},NoOfFiles={9},IsSOARequired={10},IsPresortRequired={11},IsAddressCleansingRequired={12},IsTitleCasingRequired={13}," +
                "JobStatusId={14}, JobTypeId={15},IsEDM={16},IsLabel={17}, JobNotes='{18}'  WHERE JobId = {19}";
             }
         }

          public static string UpdateUser
         {
             get
             {
                 return "UPDATE SystemUser SET UserPassword='{0}' WHERE  UserId={1}";
             }
         }
          public static string CreatePerson
          {
              get
              {
                  return "INSERT INTO Person (PersonFirstName, PersonLastName) VALUES ('{0}', '{1}')  ";
              }
          }

          public static string CreateUser
          {
              get
              {
                  return "INSERT INTO SystemUser (UserName, UserPassword, PersonId) VALUES ('{0}', '{1}', {2})  ";
              }
          }

          public static string CreateRole
          {
              get
              {
                  return "INSERT INTO UserRole (UserId, RoleId) VALUES ({0}, {1})  ";
              }
          }
    } 
}

