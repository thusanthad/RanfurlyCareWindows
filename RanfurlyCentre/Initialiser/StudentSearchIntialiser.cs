using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

using System.Reflection;

namespace RanfurlyCentre
{
    public class StudentSearchIntialiser:FormInitialiserBase
    {          
        public StudentSearchIntialiser(Form input):base(input)
        {           
            PaintButtonBackColor();
        }

        public override void PaintButtonBackColor()
        {
            Color btnColor = System.Drawing.SystemColors.Control;
            Cursor cursor = System.Windows.Forms.Cursors.Hand;

            StudentSearch dm = (StudentSearch)_form;

            foreach (Control ctrl in dm.panel2.Controls)
            {
                if (ctrl is Button)
                {
                    Button btn = (Button)ctrl;
                    base.AddButtonMouseMovement(btn);
                }
            }
            base.AddButtonMouseMovement(dm.btnClose);
        }

        public override bool EPHasErrors()
        {
            throw new NotImplementedException("not implemented");
        }

        //public virtual void btn_MouseHover(object sender, EventArgs e)
        //{
        //    Color color = Color.NavajoWhite;//Color.FromName(_currentJob.CurrentUser.ButtonHoverBackColor);
        //    Button btn = (Button)sender;
        //    btn.BackColor = color;
        //    btn.Cursor=System.Windows.Forms.Cursors.Hand;
        //    btn.Font = new Font(btn.Font.FontFamily, 8.25F, System.Drawing.FontStyle.Bold);
        //}

        //public virtual void btn_MouseLeave(object sender, EventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    btn.BackColor = System.Drawing.SystemColors.Control;
        //    btn.Font = new Font(btn.Font.FontFamily, 8.25F);
        //}

        //private void txtPreferredName_TextChanged(object sender, EventArgs e)
        //{

        //}

        //public void btn_Click(object sender, EventArgs e)
        //{
        //    _form.Close();            
        //}
    }
}

//DataMaster dm = (DataMaster)_form;
// AddContolBase acb;
////foreach (Control ctrl in _form.Controls)
////{
////    if (ctrl is Button)
////    {
////        // acb = new AddButtonObjects(this,ctrl);
////        //Button btn = (Button)ctrl;
////        //if (_form is DataMaster)
////        //    AddCommandItemTpList(btn);
////        //btn.BackColor = btnColor;
////        //btn.Cursor = cursor;
////        //btn.MouseHover += new EventHandler(btn_MouseHover);
////        //btn.MouseLeave += new EventHandler(btn_MouseLeave);
////        //if (btn.Name == "btnClose")
////        //    btn.Click += new EventHandler(btn_Click);

////    }
////    else if (ctrl is TableLayoutPanel)
////    {
////        TableLayoutPanel pl = (TableLayoutPanel)ctrl;
////        foreach (Control ctrl1 in pl.Controls)
////        {
////            if (ctrl is Panel)
////            {
////                Panel pnl = (Panel)ctrl;
////                foreach (Control ctrl2 in pnl.Controls)
////                {
////                    if (ctrl is Button)
////                    {

////                    }
////                }
////            }
////        }
////    }  
////    else if (ctrl is Panel)
////    {
////        Panel pnl = (Panel)ctrl;
////        foreach (Control ctrl1 in pnl.Controls)
////        {
////            if (ctrl1 is Button)
////            {
////                // acb = new AddButtonObjects(this, ctrl1);
////                //Button btn = (Button)ctrl1;
////                //if (_form is DataMaster)
////                //    AddCommandItemTpList(btn);
////                //btn.BackColor = btnColor;
////                //btn.Cursor = cursor;
////                //btn.MouseHover += new EventHandler(btn_MouseHover);
////                //btn.MouseLeave += new EventHandler(btn_MouseLeave);
////                //if (btn.Name == "btnClose")
////                //    btn.Click += new EventHandler(btn_Click);
////            }
////        }
////    }
////    else if (ctrl is TabControl)
////    {
////        TabControl tabControl = (TabControl)ctrl;
////        foreach (Control ctrl1 in tabControl.Controls)
////        {
////            if (ctrl1 is TabPage)
////            {
////                TabPage tabPage = (TabPage)ctrl1;
////                foreach (Control ctrl2 in tabPage.Controls)
////                {
////                    if (ctrl2 is Button)
////                    {
////                        // acb = new AddButtonObjects(this, ctrl2);
////                        //Button btn = (Button)ctrl2;
////                        //if (_form is DataMaster)
////                        //    AddCommandItemTpList(btn);
////                        //btn.BackColor = btnColor;
////                        //btn.Cursor = cursor;
////                        //btn.MouseHover += new EventHandler(btn_MouseHover);
////                        //btn.MouseLeave += new EventHandler(btn_MouseLeave);
////                        //if (btn.Name == "btnClose")
////                        //    btn.Click += new EventHandler(btn_Click);
////                    }
////                    else if (ctrl2 is Panel)
////                    {
////                        Panel pnl = (Panel)ctrl2;
////                        foreach (Control ctrl3 in pnl.Controls)
////                        {
////                            if (ctrl3 is Button)
////                            {
////                                //acb = new AddButtonObjects(this, ctrl3);

////                                //Button btn = (Button)ctrl3;
////                                //if (_form is DataMaster)
////                                //    AddCommandItemTpList(btn);
////                                //btn.BackColor = btnColor;
////                                //btn.Cursor = cursor;
////                                //btn.MouseHover += new EventHandler(btn_MouseHover);
////                                //btn.MouseLeave += new EventHandler(btn_MouseLeave);
////                                //if (btn.Name == "btnClose")
////                                //    btn.Click += new EventHandler(btn_Click);
////                            }
////                        }
////                    }

////                }
////            }
////        }
////    }
//}