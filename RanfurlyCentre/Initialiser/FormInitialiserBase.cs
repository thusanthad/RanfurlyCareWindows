using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

using System.Reflection;

namespace RanfurlyCentre
{
    public abstract class FormInitialiserBase
    {
       // public abstract bool EPHasErrors();
        public Form _form;      
        public FormInitialiserBase(Form input)
        {
            _form = input;
            //PaintButtonBackColor();
        }

        public virtual void PaintButtonBackColor()
        {
            throw new NotImplementedException("not implemented");
            //Color btnColor = System.Drawing.SystemColors.Control;
            //Cursor cursor = System.Windows.Forms.Cursors.Hand;

            //StudentSearch dm = (StudentSearch)_form;

            //foreach (Control ctrl in dm.panel2.Controls)
            //{
            //    if (ctrl is Button)
            //    {
            //        Button btn = (Button)ctrl;
            //        btn.MouseHover += new EventHandler(btn_MouseHover);
            //        btn.MouseLeave += new EventHandler(btn_MouseLeave);
            //    }
            //}

            //dm.btnClose.MouseHover += new EventHandler(btn_MouseHover);
            //dm.btnClose.MouseLeave += new EventHandler(btn_MouseLeave);
        }

        public virtual void AddButtonMouseMovement(Button button)
        {
            button.MouseHover += new EventHandler(btn_MouseHover);
            button.MouseLeave += new EventHandler(btn_MouseLeave);
        }

        public virtual void btn_MouseHover(object sender, EventArgs e)
        {
            Color color = Color.NavajoWhite;//Color.FromName(_currentJob.CurrentUser.ButtonHoverBackColor);
            Button btn = (Button)sender;
            btn.BackColor = color;
            btn.Cursor=System.Windows.Forms.Cursors.Hand;
            btn.Font = new Font(btn.Font.FontFamily, 8.25F, System.Drawing.FontStyle.Bold);
        }

        public virtual void btn_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = System.Drawing.SystemColors.Control;
            btn.Font = new Font(btn.Font.FontFamily, 8.25F);
        }

        private void txtPreferredName_TextChanged(object sender, EventArgs e)
        {

        }

        public void btn_Click(object sender, EventArgs e)
        {
            _form.Close();            
        }

        public virtual void ValueChanged(object sender, EventArgs e)
        {
            //se._changedOccured = true;
            //se.btnSave.Enabled = true;
        }

        public virtual void AddEvent(Control ctrl)
        {
            if (ctrl is TextBox)
            {
                TextBox tb = (TextBox)ctrl;
                tb.TextChanged += ValueChanged;
            }

            if (ctrl is CheckBox)
            {
                CheckBox cb = (CheckBox)ctrl;
                cb.CheckedChanged += ValueChanged;
            }

            if (ctrl is DateTimePicker)
            {
                DateTimePicker dtp = (DateTimePicker)ctrl;
                dtp.ValueChanged += ValueChanged;
            }

            if (ctrl is ComboBox)
            {
                ComboBox cmb = (ComboBox)ctrl;
                cmb.SelectedIndexChanged += ValueChanged;
            }

            if (ctrl is GroupBox)
            {
                GroupBox grp = (GroupBox)ctrl;
                foreach (Control ctrl1 in grp.Controls)
                {
                    if (ctrl1 is RadioButton)
                    {
                        RadioButton rb = (RadioButton)ctrl1;
                        rb.CheckedChanged += ValueChanged;
                    }
                }

            }
        }
    }
}

