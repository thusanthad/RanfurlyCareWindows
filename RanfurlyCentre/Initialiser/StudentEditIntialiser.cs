using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

using System.Reflection;

namespace RanfurlyCentre
{
    public class StudentEditIntialiser : FormInitialiserBase
    {
        protected StudentAddEdit se;
        public StudentEditIntialiser(Form input):base(input)
        {
            se = (StudentAddEdit)_form;
            PaintButtonBackColor();
        }

        public override void PaintButtonBackColor()
        {
            //Color btnColor = System.Drawing.SystemColors.Control;
            //Cursor cursor = System.Windows.Forms.Cursors.Hand;

            // StudentAddEdit dm = (StudentAddEdit)_form;
            foreach (Control ctrl in se.panel16.Controls)
            {
                AddEvent(ctrl);
            }
            foreach (Control ctrl in se.panel17.Controls)
            {
                AddEvent(ctrl);
            }
            foreach (Control ctrl in se.panel18.Controls)
            {
                AddEvent(ctrl);
            }
            base.AddButtonMouseMovement(se.btnClose);
        }

        //private void AddEvent(Control ctrl)
        //{
        //    if (ctrl is TextBox)
        //    {
        //        TextBox tb = (TextBox)ctrl;
        //        tb.TextChanged += ValueChanged;
        //    }

        //    if (ctrl is CheckBox)
        //    {
        //        CheckBox cb = (CheckBox)ctrl;
        //        cb.CheckedChanged += ValueChanged;
        //    }

        //    if (ctrl is DateTimePicker)
        //    {
        //        DateTimePicker dtp = (DateTimePicker)ctrl;
        //        dtp.ValueChanged += ValueChanged;
        //    }

        //    if (ctrl is ComboBox)
        //    {
        //        ComboBox cmb = (ComboBox)ctrl;
        //        cmb.SelectedIndexChanged += ValueChanged;
        //    }

        //    if (ctrl is GroupBox)
        //    {
        //        GroupBox grp = (GroupBox)ctrl;
        //        foreach (Control ctrl1 in grp.Controls)
        //        {
        //            if (ctrl1 is RadioButton)
        //            {
        //                RadioButton rb = (RadioButton)ctrl1;
        //                rb.CheckedChanged += ValueChanged;
        //            }
        //        }

        //    }
        //}

        public override void ValueChanged(object sender, EventArgs e)
        {
            se._changedOccured = true;
            se.btnSave.Enabled = true;
        }

        //public override bool EPHasErrors()
        //{
        //    bool failed = false;
        //    foreach (Control c in se.Controls)
        //    {
        //        if (c is TableLayoutPanel)
        //        {
        //            TableLayoutPanel tp = (TableLayoutPanel)c;
        //            foreach (Control ctrl in tp.Controls)
        //            {
        //                foreach (Control ctrl1 in ctrl.Controls)
        //                {
        //                    foreach (Control ctrl2 in ctrl1.Controls)
        //                    {
        //                        foreach (Control ctrl3 in ctrl2.Controls[0].Controls)
        //                        {
        //                            if (se.ep.GetError(ctrl3).Length > 0)
        //                                failed = true;
        //                        }
        //                    }
        //                }
        //            }

        //        }
        //    }



        //    return failed;
        //}

        //private void cb_CheckedChanged(object sender, EventArgs e)
        //{
        //    se._changedOccured = true;
        //}

        //private void dtp_ValueChanged(object sender, EventArgs e)
        //{

        //}





        //public void btn_Click(object sender, EventArgs e)
        //{
        //    _form.Close();            
        //}
    }
}

