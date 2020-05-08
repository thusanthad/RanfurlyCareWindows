using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using RanfurlyBusiness;
using DataAccess;
using System.Reflection;

namespace RanfurlyBusiness
{
    public class ResidentRollCallData
    {
        protected DBCommand dbc;
        public ResidentRollCallData(DBCommand dbCommand)
        {
            dbc = dbCommand;
        }

        public ResidentRollCallData()
        {
            dbc = new DBCommand(DBCommand.TransactionType.WithoutTransaction);
        }


        public DataTable GetStudentRollTable(string FilePath)
        {
            DMFileManager.DataFile df = new DMFileManager.ExcelDataFile(FilePath);
            df.ImportData("Sheet1");
            return df.DataSource;
        }

        public List<ResidentRollCall> GetRollCalls(string sql)
        {
            DataTable dt = dbc.GetDataTable("SELECT * FROM vw_ResidentRollCalls" + sql);
            List<ResidentRollCall> list = new List<ResidentRollCall>();
            foreach (DataRow dr in dt.Rows)
            {
                list.Add(GetRollCall(dr));
            }
            return list;
        }
        private ResidentRollCall GetRollCall(DataRow dr)
        {
            ResidentRollCall rrc = new ResidentRollCall();
            rrc.ResidentRollCallId = (int)dr["ResidentRollCallId"];
            rrc.StudentId = (int)dr["StudentId"];
            rrc.ResidentName = dr["ResidentName"].ToString();
            rrc.LocationName = dr["LocationName"].ToString();
            rrc.Abbreviation = dr["Abbreviation"].ToString();            
            rrc.MonthNumber= (int)dr["MonthNumber"];
            rrc.YearNumber = (int)dr["YearNumber"];
            rrc.FileName = dr["FileName"].ToString();
            rrc.RollReference = dr["RollReference"].ToString();
            rrc.d1 = dr["1"].ToString();
            rrc.d2 = dr["2"].ToString();
            rrc.d3 = dr["3"].ToString();
            rrc.d4 = dr["4"].ToString();
            rrc.d5 = dr["5"].ToString();
            rrc.d6 = dr["6"].ToString();
            rrc.d7 = dr["7"].ToString();
            rrc.d8 = dr["8"].ToString();
            rrc.d9 = dr["9"].ToString();
            rrc.d10 = dr["10"].ToString();
            rrc.d11 = dr["11"].ToString();
            rrc.d12 = dr["12"].ToString();
            rrc.d13 = dr["13"].ToString();
            rrc.d14 = dr["14"].ToString();
            rrc.d15 = dr["15"].ToString();
            rrc.d16 = dr["16"].ToString();
            rrc.d17 = dr["17"].ToString();
            rrc.d18 = dr["18"].ToString();
            rrc.d19 = dr["19"].ToString();
            rrc.d20 = dr["20"].ToString();
            rrc.d21 = dr["21"].ToString();
            rrc.d22 = dr["22"].ToString();
            rrc.d23 = dr["23"].ToString();
            rrc.d24 = dr["24"].ToString();
            rrc.d25 = dr["25"].ToString();
            rrc.d26 = dr["26"].ToString();
            rrc.d27 = dr["27"].ToString();
            rrc.d28 = dr["28"].ToString();
            rrc.d29 = dr["29"].ToString();
            rrc.d30 = dr["30"].ToString();
            rrc.d31 = dr["31"].ToString();
            return rrc;
        }

        public bool CheckIfFileAlreadyImported(ResidentRollCall residentRollCall)
        {            
            DataTable dt = dbc.GetDataTable("SELECT * FROM ResidentRollCallImportLog WHERE FileName ='"+ residentRollCall.FileName +"'");
           // dbc.CloseConnection();
            return dt.Rows.Count != 0;
        }

        public Location getLocationFromLocationReference(string reference)
        {
            LocationData ld = new LocationData();
            return ld.GetLocationFromReference(reference);
        }

        public void SaveRollCalll(ResidentRollCall residenceRollCall)
        {
            string rtn = ValidateAllStudentIds(residenceRollCall);
            if (rtn != string.Empty)
                throw new Exception(rtn + " not valid Student Id(s)");

            rtn = CheckAllRollValues(residenceRollCall);
            if (rtn != string.Empty)
                throw new Exception(rtn + " values not acceptable, please check spread sheet");


            string sql = "INSERT INTO ResidentRollCallImportLog (FileLocation, FileName) VALUES ('"+ residenceRollCall.FileLocation+ "','"+residenceRollCall.FileName +"')";
            int ResidentRollCallImportId = dbc.ExecuteCommand(sql);
           
            foreach(DataRow dr in residenceRollCall.RollTable.Rows)
            {
                string studentId = dr[0].ToString();
               
                StringBuilder sb = new StringBuilder();
                sb.Append("INSERT INTO ResidentRollCall (StudentId,MonthNumber,YearNumber,LocationId,RollReference,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,ResidentRollCallImportId) VALUES (");
                sb.Append(dr[0].ToString());
                sb.Append(",'"+ residenceRollCall .MonthNumber+ "'");
                sb.Append(",'" + residenceRollCall.YearNumber + "'");
                sb.Append(",'" + residenceRollCall.LocationId + "'");
                sb.Append(",'" + residenceRollCall.LocationReference + "'");
                sb.Append(",'" + dr["2"].ToString() + "'");
                sb.Append(",'" + dr["2"].ToString() + "'");
                sb.Append(",'" + dr["3"].ToString() + "'");
                sb.Append(",'" + dr["4"].ToString() + "'");
                sb.Append(",'" + dr["5"].ToString() + "'");
                sb.Append(",'" + dr["6"].ToString() + "'");
                sb.Append(",'" + dr["7"].ToString() + "'");
                sb.Append(",'" + dr["8"].ToString() + "'");
                sb.Append(",'" + dr["9"].ToString() + "'");
                sb.Append(",'" + dr["10"].ToString() + "'");
                sb.Append(",'" + dr["11"].ToString() + "'");
                sb.Append(",'" + dr["12"].ToString() + "'");
                sb.Append(",'" + dr["13"].ToString() + "'");
                sb.Append(",'" + dr["14"].ToString() + "'");
                sb.Append(",'" + dr["15"].ToString() + "'");
                sb.Append(",'" + dr["16"].ToString() + "'");
                sb.Append(",'" + dr["17"].ToString() + "'");
                sb.Append(",'" + dr["18"].ToString() + "'");
                sb.Append(",'" + dr["19"].ToString() + "'");
                sb.Append(",'" + dr["20"].ToString() + "'");
                sb.Append(",'" + dr["21"].ToString() + "'");
                sb.Append(",'" + dr["22"].ToString() + "'");
                sb.Append(",'" + dr["23"].ToString() + "'");
                sb.Append(",'" + dr["24"].ToString() + "'");
                sb.Append(",'" + dr["25"].ToString() + "'");
                sb.Append(",'" + dr["26"].ToString() + "'");
                sb.Append(",'" + dr["27"].ToString() + "'");
                sb.Append(",'" + dr["28"].ToString() + "'");
                if (residenceRollCall.RollTable.Columns.Contains("29"))               
                    sb.Append(",'" + dr["29"].ToString() + "'");                
                else
                    sb.Append(",null");
                if (residenceRollCall.RollTable.Columns.Contains("30"))
                    sb.Append(",'" + dr["30"].ToString() + "'");
                else
                    sb.Append(",null");
                if (residenceRollCall.RollTable.Columns.Contains("31"))
                    sb.Append(",'" + dr["31"].ToString() + "'");
                else
                    sb.Append(",null");
                sb.Append("," + ResidentRollCallImportId);
                sb.Append(")");

                sql = sb.ToString();
                dbc.ExecuteCommand(sql);
            }
        }

        private string ValidateAllStudentIds(ResidentRollCall residenceRollCall)
        {
            List<string> list = new List<string>();
            foreach (DataRow dr in residenceRollCall.RollTable.Rows)
            {
                string studentid = dr[0].ToString();
                DataTable dt = dbc.GetDataTable("SELECT StudentId FROM student where StudentId=" + studentid);
                if(dt.Rows.Count ==0)
                {
                    list.Add(studentid);
                }
            }

            if (list.Count > 0)
                return String.Join(", ", list.ToArray());
            else
                return string.Empty;
        }

        public void Update(ResidentRollCall rollCall)
        {
            //PropertyInfo[] properties = GetRollCallProperties();
            List<string> list = new List<string>();
            StringBuilder sb = new StringBuilder();

            sb.Append("UPDATE ResidentRollCall Set ");
            for (int i=1;i<=31;i++)
            {
                string propertyName = "d" + i;
                
                var rollValue = rollCall.GetType().GetProperty(propertyName).GetValue(rollCall, null);
                //var rollValue = rollCall.GetType().GetProperties()..GetValue(property.Name, null);
                if (rollValue != null && rollValue.ToString() !=string.Empty)
                {
                    if (CheckIfValueAcceptables(rollValue.ToString()))
                    {
                        list.Add(i + "='" + rollValue + "'");
                        //sb.Append("d" + i + "='" + rollValue + "'");

                        }
                    else
                        throw new Exception(rollValue.ToString() + " not acceptable");
                }
                else
                    list.Add(i + "=null");
                    //sb.Append(i + "=null");
            }
            sb.Append(String.Join(",", list.ToArray()));
            sb.Append(" WHERE ResidentRollCallId="+ rollCall.ResidentRollCallId);

            string sql = sb.ToString();
            dbc.ExecuteCommand(sql);

            //StringBuilder sb = new StringBuilder();
            //sb.Append("UPDATE ResidentRollCall Set (");
            //sb.Append("1='" + rollCall.d1 + "'");
            //sb.Append("2='" + rollCall.d2 + "'");
            //sb.Append("3='" + rollCall.d2 + "'");
            //sb.Append("4='" + rollCall.d4 + "'");
            //sb.Append("5='" + rollCall.d5 + "'");
            //sb.Append("5='" + rollCall.d6 + "'");
            //sb.Append("7='" + rollCall.d7 + "'");
            //sb.Append("8='" + rollCall.d8 + "'");
            //sb.Append("9='" + rollCall.d9 + "'");
            //sb.Append("10='" + rollCall.d10 + "'");
            //sb.Append("11='" + rollCall.d11 + "'");
            //sb.Append("12='" + rollCall.d12 + "'");
            //sb.Append("13='" + rollCall.d13 + "'");
            //sb.Append("14='" + rollCall.d14 + "'");
            //sb.Append("15='" + rollCall.d15 + "'");
            //sb.Append("16='" + rollCall.d16 + "'");
            //sb.Append("17='" + rollCall.d17 + "'");
            //sb.Append("18='" + rollCall.d18 + "'");
            //sb.Append("19='" + rollCall.d19 + "'");
            //sb.Append("20='" + rollCall.d20 + "'");
            //sb.Append("21='" + rollCall.d21 + "'");
            //sb.Append("22='" + rollCall.d22 + "'");
            //sb.Append("23='" + rollCall.d23 + "'");
            //sb.Append("24='" + rollCall.d21 + "'");
            //sb.Append("25='" + rollCall.d21 + "'");
            //sb.Append("26='" + rollCall.d21 + "'");
            //sb.Append("27='" + rollCall.d21 + "'");
            //sb.Append("28='" + rollCall.d21 + "'");


        }
        
        private string CheckAllRollValues(ResidentRollCall residenceRollCall)
        {            
            List<string> errors = new List<string>();
            List<string> properties = CommonFunctions.GetAllPropertiesFromType(residenceRollCall);

            foreach (DataRow dr in residenceRollCall.RollTable.Rows)
            {                
                foreach(string property in properties)
                {
                    string numericValue = property.Replace("d", "");                    
                    if (CommonFunctions.IsNumeric(numericValue))
                    {
                        if (CommonFunctions.IsDate(residenceRollCall.YearNumber, residenceRollCall.MonthNumber, Convert.ToInt16(numericValue)))
                        {
                            string str = dr[numericValue].ToString();
                            if (str != string.Empty)
                            {
                                if (!CheckIfValueAcceptables(str))
                                    errors.Add(str);
                            }
                        }
                    }
                }
            }
            if (errors.Count > 0)
                return String.Join(", ", errors.ToArray());
            else
                return string.Empty;
        }

        private bool CheckIfValueAcceptables(string str)
        {
            List<string> acceptableValues = new List<string> { "DH", "M", "H", "AL", "W", "ST", "1" };
            return acceptableValues.Contains(str);
        }

        public List<ResidentRollCallFileLog> GetImportFiles(string month,string year)
        {
            string str = month + "_" + year;
            DataTable dt = dbc.GetDataTable("SELECT * FROM ResidentRollCallImportLog Where FileName like '%" + str + "%'");
            List<ResidentRollCallFileLog> list = new List<ResidentRollCallFileLog>();
            foreach (DataRow dr in dt.Rows)
            {
                ResidentRollCallFileLog log = new ResidentRollCallFileLog
                {
                    ResidentRollCallImportId= (int)dr["ResidentRollCallImportId"],
                    FileLocation = dr["FileLocation"].ToString(),
                    FileName = dr["FileName"].ToString()
                };

                list.Add(log);
            }
            return list;
        }

        public void RemoveFile(ResidentRollCallFileLog file)
        {
            string sql ="DELETE FROM ResidentRollCallImportLog WHERE ResidentRollCallImportId=" + file.ResidentRollCallImportId;
            dbc.ExecuteCommand(sql);
        }
    }
}
