using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using RanfurlyBusiness.CFCryptography;


namespace RanfurlyCentre
{
    public class Jarvis
    {
        public RanfurlyBusiness.SystemUser CurrentUser { get; set; }
        public string OutputFileLocation { get; set; }
        public string ResourceFileLocation { get; set; }
        public string ExportFielFieldList { get; set; }
        public int FileIncrement { get; set; }
        public string OutputFileName { get; set; }
        public string InputFileArchiveLocation { get; set; }
        public List<object> ExportFileData { get; set; }
        public object ExportOjectType { get; set; }
        public License License { get; set; }
        //public string DatabaseLocation { get; set; }
        //public string DatabaseBackupLocation { get; set; }

        //public DMFileManager.DataFile Datafile { get; set; }

        public Jarvis()
        {
            OutputFileLocation = GetOutputFileLocations();
            ResourceFileLocation = GetResourceFileLocations();
            InputFileArchiveLocation = GetInputFileArchiveLocation();
            FileIncrement = 1;
            License = GetLicense();
            //DatabaseLocation = GetDatabaseFullPath();
            //DatabaseBackupLocation = GetDatabaseFullPath();
        }

       private string GetOutputFileLocations()
        {
            return ConfigurationManager.AppSettings["OutputFileLocation"];
        }

        private string GetResourceFileLocations()
        {
            return ConfigurationManager.AppSettings["ResourceFileLocation"];
        }

        private string GetInputFileArchiveLocation()
        {
            return ConfigurationManager.AppSettings["InputFileArchiveLocation"];
        }

        public string GetStudentFieldList()
        {
            return ConfigurationManager.AppSettings["StudentFieldList"];
        }

        //public string GetIndividualStudentFieldList()
        //{
        //    return ConfigurationManager.AppSettings["IndividualStudentFieldList"];
        //}

        public string GetStaffFieldList()
        {
            return ConfigurationManager.AppSettings["StaffFieldList"];
        }

        public string GetDoctorFieldList()
        {
            return ConfigurationManager.AppSettings["DoctorFieldList"];
        }

        public string GetSpecialistFieldList()
        {
            return ConfigurationManager.AppSettings["SpecialistFieldList"];
        }

        public string GetIncidentFieldList()
        {
            return ConfigurationManager.AppSettings["IncidentFieldList"];
        }

        public string GetResidentRollCallFieldList()
        {
            return ConfigurationManager.AppSettings["ResidentRollCallFielsList"];
        }

        public string GetResidentRollCallMonthlySummaryFieldList()
        {
            return ConfigurationManager.AppSettings["ResidentRollCallFielsList"];
        }

        public string GetResidetnRollCallMonthlySummaryFieldList()
        {
            return ConfigurationManager.AppSettings["ResidetnRollCallMonthlySummaryFieldList"];
        }

        public string GetResidetnRollCallYearlySummaryFieldList()
        {
            return ConfigurationManager.AppSettings["ResidetnRollCallYearlySummaryFieldList"];
        }

        public string GetResidetnRollCallYearlySummaryByMonthFieldList()
        {
            return ConfigurationManager.AppSettings["ResidetnRollCallYearlySummaryByMonthFieldList"];
        }

        public License GetLicense()
        {
            string str =  ConfigurationManager.AppSettings["LicenseKey"];
            License license = new License();
            string licenskey = Encryption.Decrypt(str);
            string[] split = licenskey.Split('_');
            license.LicensedTo = split[0];
            license.ExpiryDate = Convert.ToDateTime(split[1]);
            return license;
        }

        public void IncreaseFielIncrement()
        {
            FileIncrement += 1;
        }

        public void PlayFailSound()
        {
            string SoundFile = ResourceFileLocation + "VOLTAGE.wav";
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(SoundFile);
            player.Play();
        }

        public void BackupDatabase()
        {
            string conString = DataAccess.Singleton.GetConnectionString();
            string[] split = conString.Split('=');
            string databasePath = split[split.Length - 1].Replace(@"""","");
            string databaseBackupLocation = ConfigurationManager.AppSettings["DatabaseBackupLocation"];
            //string

            DMFileManager.DataFile df = new DMFileManager.DataFile(databasePath);
            string backupFilePath = databaseBackupLocation + df.FileNameWithoutExtension + "_backup" + df.FileExtension;
            df.CopyFile(databasePath, backupFilePath);
        }

    }


   
}
