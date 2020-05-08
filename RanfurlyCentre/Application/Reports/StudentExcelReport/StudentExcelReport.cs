using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;
using System.Data;
using DMFileManager;
using DataAccess;

namespace RanfurlyCentre
{
    public class StudentExcelReport
    {
        protected Student _student;
        protected Jarvis _jarvis;

        public StudentExcelReport(Student student, Jarvis jarvis)
        {
            _student = student;
            _jarvis = jarvis;
            GenerateReport();
        }

        private void GenerateReport()
        {
            _student.FullName = _student.GetFullName();
            _student.FullAddress = _student.GetFullAddress();
            List<Student> list = new List<Student>();
            list.Add(_student);
            DataTable dt1 = CommonFunctions.ToDataTable<Student>(list);

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("col1");
            dt2.Columns.Add("col2");

            foreach (DataColumn col in dt1.Columns)
            {
                DataRow dr1 = dt2.NewRow();
                dr1["col1"] = col.ColumnName;
                dr1["col2"] = dt1.Rows[0][col.ColumnName].ToString();
                dt2.Rows.Add(dr1);

            }

           // _student.FullName = _student.GetFullName();
           // _student.FullAddress = _student.GetFullAddress();
           // DataTable dt = new DataTable();
           // dt.Columns.Add("col1");
           // dt.Columns.Add("col2");
           // dt.Columns.Add("col3");
           // dt.Columns.Add("col4");
           //// dt.Columns.Add("col5");

           // DataRow dr = dt.NewRow();
           // dr["col2"] = "Student Report";
           // dt.Rows.Add(dr);

           // dr = dt.NewRow();
           // dr["col1"] = "Student Full Name:";
           // dr["col2"] = _student.FullName;
           // dr["col3"] = "Gender:";
           // dr["col4"] = _student.Gender;
           // dt.Rows.Add(dr);

           // dr = dt.NewRow();
           // dr["col1"] = "Date of Birth:";
           // dr["col2"] = _student.DateOfBirth?.ToString("dd/MM/yyyy");
           // dr["col3"] = "Ethnicity:";
           // dr["col4"] = _student.Ethnicity;
           // dt.Rows.Add(dr);

           // dr = dt.NewRow();
           // dr["col1"] = "Admitted to Activity Centre:";
           // dr["col2"] = _student.AdmittedToActivityCentre?.ToString("dd/MM/yyyy");
           // dr["col3"] = "Place of Birth:";
           // dr["col4"] = _student.PlaceOfBirth;
           // dt.Rows.Add(dr);

           // dr = dt.NewRow();
           // dr["col1"] = "Admitted to Residence:";
           // dr["col2"] = _student.AdmittedToResidence?.ToString("dd/MM/yyyy");
           // dr["col3"] = "NHI Number:";
           // dr["col4"] = _student.NHINumber;
           // dt.Rows.Add(dr);

           // dr = dt.NewRow();
           // dr["col1"] = "Home Phonee:";
           // dr["col2"] = _student.HomePhone;
           // dr["col3"] = "Mobile Phone:";
           // dr["col4"] = _student.MobilePhone;
           // dt.Rows.Add(dr);

           // dr = dt.NewRow();
           // dr["col1"] = "Full Address:";
           // dr["col2"] = _student.FullAddress;

           // dr = dt.NewRow();            
           // dt.Rows.Add(dr);

           // dr = dt.NewRow();
           // dr["col1"] = "Doctor(s)";
           // dt.Rows.Add(dr);

           // foreach (Doctor doctor in _student.Doctors)
           // {
           //     dr = dt.NewRow();
           //     dr["col1"] = doctor.FullName;
           //     dr["col2"] = doctor.GetFullAddress();
           //     dr["col3"] = doctor.Phone;
           //     dt.Rows.Add(dr);
           // }

           // dr = dt.NewRow();
           // dt.Rows.Add(dr);

           // dr = dt.NewRow();
           // dr["col1"] = "Next of Kin(s)";
           // dt.Rows.Add(dr);

           // foreach (NextOfKin nextofkin in _student.NextOfKin)
           // {
           //     dr = dt.NewRow();
           //     dr["col1"] = nextofkin.FullName;
           //     dr["col2"] = nextofkin.GetFullAddress();
           //     dr["col3"] = nextofkin.Phone;                
           //     dr["col4"] = nextofkin.Relationship;
           //     dt.Rows.Add(dr);
           // }


            DataFile df = new DataFile();

            df.IOFileInfo.FileFullPath = _jarvis.OutputFileLocation + _student.FullName + "_Student Report_"+_jarvis.FileIncrement+".XLSX";            
            df.IOFileInfo.OutputDataSource = dt2 ;
            df.IOFileInfo.CreateHeader = false;
            df.IOFileInfo.WorkSheetName = _student.FullName;

            DataAccessBase eda = new ExcelDataAccess(df.IOFileInfo);
            //eda.ReportProgress += new EventHandler<DataAccessEventMessenger>(eda_ReportProgress);
            eda.Save();
            System.Diagnostics.Process.Start(df.IOFileInfo.FileFullPath);



        }

    }
}
