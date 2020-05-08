using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess;

namespace ClassStructure
{
    public static class CommonVariables
    {

        public static string GetConnectionString()
        {
            if (Singleton.ShowPath() == "True")
                return Singleton.GetConnectionString();
            else
                return "";           
        }

        public static string GetReportPath()
        {
            return Singleton.GetReportPath();
        }

        public static bool IsTest()
        {
            return Singleton.IsTest();
        }
       
    }


    
}
