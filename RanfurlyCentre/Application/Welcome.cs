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
    public partial class Welcome : Form
    {
        protected Jarvis _jarvis;
        public Welcome(Jarvis jarvis)
        {
            InitializeComponent();
            _jarvis = jarvis;
        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "Version : " + Application.ProductVersion;
            lblIssuedTo.Text = "Licensed to: " + _jarvis.License.LicensedTo;
            lblExpirydate.Text = "License expires on: " +_jarvis.License.ExpiryDate.ToLongDateString();
            //EmailBase emb = new EmailBase();
            //emb.SendEmail();
        }

        //private void pictureBox1_Click(object sender, EventArgs e)`z
        //{

        //}
    }
}
