using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;

namespace BigApp
{
    public class Emailer
    {
        public static void SendMail() {
            MailMessage mail = new MailMessage();
            mail.To.Add("najamsk@gmail.com");

            mail.From = new MailAddress("najamsk@gmail.com");
            mail.Subject = "Email using Gmail";

            string Body = "Hi, najam sikander awan this mail is to test sending mail" +
                          "using Gmail in ASP.NET";
            mail.Body = Body;

            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com"; //Or Your SMTP Server Address
            smtp.Credentials = new System.Net.NetworkCredential
                 ("bigapp.awan@gmail.com", "#goga123#");
            //Or your Smtp Email ID and Password
            smtp.EnableSsl = true;
            smtp.Send(mail);
        }
    }
}