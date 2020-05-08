using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using RanfurlyBusiness.CFCryptography;

namespace RanfurlyCentre
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LoginForm());
            try
            {
                //Form2 frm = new Form2();
                //frm.ShowDialog();
                //string licensKey = Encryption.Encrypt("Ranfurly Care Centre_31/12/2020");
                LoginForm loginForm = new LoginForm();
                //LoginFormTest loginForm = new LoginFormTest();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.EnableVisualStyles();
                    MDIMainForm mainForm = new MDIMainForm(loginForm.Jarvis);
                    Application.Run(mainForm);
                    //Application.Run(new Form1());
                }

                else
                    Application.Exit();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
