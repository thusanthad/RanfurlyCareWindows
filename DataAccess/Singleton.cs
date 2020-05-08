using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace DataAccess
{
    public sealed class Singleton
    {
        static readonly Singleton instance = new Singleton();
        static string connectionString = ConfigurationManager.ConnectionStrings["RanfurlyCentre"].ConnectionString;
        static string reportPath = ConfigurationManager.AppSettings["ReportPath"];
        static string showPath = ConfigurationManager.AppSettings["ShowPath"];
        static string isTest = ConfigurationManager.AppSettings["IsTest"];

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        //static SingletonConnectionString()
        //{
        //}

        //SingletonConnectionString()
        //{
        //}

        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }

        public static string GetConnectionString()
        {
            return connectionString;
        }

        public static string GetReportPath()
        {
            return reportPath;
        }

        public static string ShowPath()
        {
            return showPath;
        }

        //public static string GetDatabaseFullPath()
        //{
        //    string conString = GetConnectionString();
        //    return conString;
        //}

        public static bool IsTest()
        {
            return (isTest == "True");
        }
       
        private static string GetSetting(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        private static void SetSetting(string key, string value)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            configuration.AppSettings.Settings[key].Value = value;
            configuration.Save(ConfigurationSaveMode.Full, true);
            ConfigurationManager.RefreshSection("appSettings");
        }
       
    }
}
