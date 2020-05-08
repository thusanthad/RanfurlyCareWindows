using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RanfurlyCentre
{
    public partial class EditBox : Form
    {
        public EditBox()
        {
            InitializeComponent();
        }

        private void EditBox_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
