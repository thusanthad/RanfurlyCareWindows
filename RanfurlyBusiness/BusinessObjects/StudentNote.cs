using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RanfurlyBusiness
{
    public class StudentNote
    {
        public int StudentNoteId { get; set; }
        public int StudentId { get; set; }
        public string StudentNoteName { get; set; }
        public DateTime NoteDate { get; set; }
    }
}
