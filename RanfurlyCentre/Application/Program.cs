using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

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
                LoginForm loginForm = new LoginForm();
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    Application.EnableVisualStyles();
                    MDIMainForm mainForm = new MDIMainForm();
                    mainForm.CurrentUser = loginForm.CurrentUser;
                    Application.Run(mainForm);
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
