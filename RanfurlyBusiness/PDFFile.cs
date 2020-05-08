using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;


namespace RanfurlyBusiness
{
    public class PDFFile
    {
        protected Document _document;
        protected PdfWriter _pDFWriter;
        protected PdfPTable _table;
        protected string _pDFFullName;
        protected Paragraph _paragraph;

        public PDFFile()
        {
            _document = new Document(PageSize.A4, 10, 10, 20, 10);
        }

        public virtual void Create(string pDFFullName)
        {
            _pDFWriter = PdfWriter.GetInstance(_document, new FileStream(pDFFullName, FileMode.Create));
            _pDFFullName = pDFFullName;
            _document.Open();
        }

        public void CreateColumnText(string Text,float x,float y,float length,float height)
        {
            ColumnText ct = new ColumnText(_pDFWriter.DirectContent);
            ct.SetSimpleColumn(new Rectangle(x,y,length,height));
            ct.AddElement(new Paragraph(Text));
            ct.Go();
        }

        public void AddImage(string imageFullPath)
        {
            Image image = Image.GetInstance(imageFullPath);
            //Image image = Image.GetInstance(@"G:\DM_JOBS\_TOOLS\TNS_APPS\DMPreProcessing\NationalTrackingSheet.jpg");
            image.ScalePercent(20f);
            //image.SetAbsolutePosition(document.PageSize.Width - 36f - 72f,
            //      document.PageSize.Height - 36f - 216.6f);
            float f = iTextSharp.text.Utilities.MillimetersToPoints(160f); // 160f
            image.SetAbsolutePosition(20f, 780f);    //      document.PageSize.Height - 36f - 216.6f);
            _document.Add(image);
        }

        public virtual void CreateTable(int columns)
        {
            _table = new PdfPTable(columns)
            {
                WidthPercentage = 90,
                SpacingBefore = 15f
            };
            _table.DefaultCell.Border = Rectangle.NO_BORDER;
            _table.TotalWidth = 595f;
        }

        public void AddParagraphToDocumnet()
        {
            _document.Add(_paragraph);
        }

        //public void CreateParagraph(string text, int fontSize, bool IsBold)
        //{
        //    _paragraph = new Paragraph(text, GetFont(fontSize, IsBold));
        //    _paragraph.Alignment = Element.ALIGN_LEFT;
        //    _paragraph.SpacingAfter = 15f;
        //    //_document.Add(par);
        //}

        public virtual void CreateParagraph()
        {
            _paragraph = new Paragraph
            {
                Alignment = Element.ALIGN_LEFT,
                SpacingAfter = 150f
            };
            //_document.Add(par);
        }

        public virtual void AddTableToParagraph()
        {
            _paragraph.Add(_table);
        }

        public virtual Font GetFont(int fontSize, bool IsBold)
        {
            Font font;
            if (IsBold)
                font = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, fontSize);
            else
                font = FontFactory.GetFont(FontFactory.HELVETICA, fontSize);

            return font;
        }

        public void  AddCellToTable(string text, int fontSize, bool IsBold)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, GetFont(fontSize, IsBold)))
            {
                BorderWidthBottom = 0,
                BorderWidthLeft = 0,
                BorderWidthTop = 0,
                BorderWidthRight = 0,
                MinimumHeight = 20
            };
            _table.AddCell(cell);
        }

        public void AddCellToTable(string text, int fontSize, bool IsBold, int colSpan)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, GetFont(fontSize, IsBold)))
            {
                BorderWidthBottom = 0,
                BorderWidthLeft = 0,
                BorderWidthTop = 0,
                BorderWidthRight = 0,
                MinimumHeight = 20,
                Colspan = colSpan
            };
            _table.AddCell(cell);
        }

        public void WriteDirectContent(string text, float x, float y, int fontSize)
        {
            PdfContentByte cb = _pDFWriter.DirectContent;
            cb.BeginText();
            BaseFont f_cn = BaseFont.CreateFont("c:\\windows\\fonts\\calibri.ttf", BaseFont.CP1257, BaseFont.NOT_EMBEDDED);
            cb.SetFontAndSize(f_cn, fontSize);
            cb.SetTextMatrix(x, y);  //(xPos, yPos)
            cb.ShowText(text);
            cb.EndText();
        }

        public virtual void WriteSelectedRows()
        {
            _table.WriteSelectedRows(100, 100, 3000, 10000, _pDFWriter.DirectContent);
        }

        public virtual void Open()
        {
            _document.Close();
            System.Diagnostics.Process.Start(_pDFFullName);
        }
    }
}
