using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public partial class AddEditCommunicationNote : Form
    {
        protected Student _student;
        public AddEditCommunicationNote(Student student)
        {
            InitializeComponent();
            _student = student;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsValidated())
            {
                StudentNote sn = new StudentNote();
                sn.NoteDate = dtp.Value;
                sn.StudentNoteName = txtNote.Text;
                sn.StudentId = _student.PersonId;
                _student.StudentNotes.Add(sn);
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool IsValidated()
        {
            int errors = 0;
            if (!dtp.Checked)
            {
                ep.SetError(dtp,"Select date");
                errors += 1;
            }
            if (txtNote.Text==string.Empty)
            {
                ep.SetError(txtNote, "type note");
                errors += 1;
            }
            return errors == 0;
        }
        
    }
}
