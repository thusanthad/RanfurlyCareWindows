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
    public partial class CopyOfWelcome : Form
    {
        public CopyOfWelcome()
        {
            InitializeComponent();
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "Version : " + Application.ProductVersion;
        }
    }
}
