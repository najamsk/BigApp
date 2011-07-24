using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mvc.Mailer;
using System.Net.Mail;

namespace BigApp.Mailers
{ 
    public interface IUserMailer
    {
				
		MailMessage Signup(string targetMail);
		
				
		MailMessage PasswordForgot();
		
		
	}
}