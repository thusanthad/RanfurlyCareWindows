using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;

using System.Reflection;

namespace RanfurlyCentre
{
    public class GenericFormIntialiser : FormInitialiserBase
    {
        public GenericFormIntialiser(Form input) : base(input)
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

        //public override bool EPHasErrors()
        //{
        //    throw new NotImplementedException("not implemented");
        //}
    }
}

        