using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc.Mailer;
using System.Net.Mail;

namespace BigApp.Mailers
{ 
    public class UserMailer : MailerBase, IUserMailer     
	{
		public UserMailer():
			base()
		{
			MasterName="_Layout";
		}

		
		public virtual MailMessage Signup(string targetMail)
		{
			var mailMessage = new MailMessage{Subject = "Signup with BigApp"};
            mailMessage.To.Add("nsawan@gmail.com");
			mailMessage.To.Add(targetMail);
			ViewBag.Name = "najam sikander awan";
			PopulateBody(mailMessage, viewName: "Signup");

			return mailMessage;
		}

		
		public virtual MailMessage PasswordForgot()
		{
			var mailMessage = new MailMessage{Subject = "PasswordForgot"};
			
			//mailMessage.To.Add("some-email@example.com");
			//ViewBag.Data = someObject;
			PopulateBody(mailMessage, viewName: "PasswordForgot");

			return mailMessage;
		}

		
	}
}