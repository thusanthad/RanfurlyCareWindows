using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RanfurlyBusiness;

namespace RanfurlyCentre
{
    public static class InterfaceTasks
    {
        public static void PlaySound()
        {
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Application.StartupPath + @"\chord.wav");
            player.Play();
        }

        public static void ValidateOnlyDigits(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
        public static string GetUserRole(SystemUser user)
        {
            if (user.Roles.Length > 1)
            {
                foreach (string str in user.Roles)
                {
                    if (str.ToUpper().Contains("ADMIN"))
                    {
                        return "Admin";
                    }
                }
                return user.Roles[0].ToString();
            }
            else
                return user.Roles[0];
        }

    }
}
