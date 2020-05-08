using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;

namespace RanfurlyCentre
{
    public class EmailBase
    {


        public virtual void SendEmail()
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("dfgdfgdfgdfg.desilva@gmail.com");
                mail.To.Add("thusantha.desilva@gmail.com");
                mail.Subject = "Test Mail";
                mail.Body = "This is for testing SMTP mail from GMAIL";
                //mail.Attachments.Add()

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("thusantha.desilva@gmail.com", "kioltsiupbxnmmwp");
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
