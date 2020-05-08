using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public class IndividualStudentReport:PDFFile
    {
        protected Jarvis _jarvis;
        protected Student _student;
        public IndividualStudentReport(Jarvis jarvis, Student student)
        {
            _jarvis = jarvis;
            _student = student;
            CretaeDocument();
        }

        public void CretaeDocument()
        {
            base.Create(_jarvis.OutputFileLocation + _student.FirstName + ".PDF");
            string imageLocation = @"C:\Users\kdes004\Documents\Visual Studio 2017\Projects\RanfurlyCareCentre\Images\RanfurlyLogo.jpg";
            base.AddImage(imageLocation);
            //base.AddParagraph("Student Report", 16, true);
            WriteDirectContent("Student Report", 400, 790, 16);
            WriteDirectContent(new String('_', 105), 30, 770,10);
            //WriteDirectContent("", 30, 740, 10);
            CreateParagraph();
            CreateTable(4);
            AddCellToTable("Student Full Name:", 10, false);
            AddCellToTable("Date of Birth:", 10, false);
            AddCellToTable("Admitted to Care Centre:", 10, false);
            AddCellToTable("Admitted to Residence:", 10, false);
            //WriteSelectedRows();
            AddTableToParagraph();
            
            AddParagraphToDocumnet();

            //base.CreateColumnText("This could be a very long sentence that needs to be wrapped", 0, 0, 800, 50);

            base.Open();

        }
    }
}
