using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;

namespace REALWorks.NotificationService.Services.EmailService
{
    public class EmailSender: IEmailSender
    {
        private readonly EmailSettings _emailSettings;
        private readonly IHostingEnvironment _env;

        public EmailSender()
        {
        }

        // Below to be reviewed, enable before, is it necessary?
        public EmailSender(EmailSettings emailSettings) //, IHostingEnvironment env)
        {
            _emailSettings = emailSettings;
            //_env = env;
        }

        public async Task<string> SendEmailAsync(string email, string subject, string message)
        {
            //throw new NotImplementedException();
            try
            {              

                MailMessage mailMsg = new MailMessage();

                // To
                
                mailMsg.To.Add(new MailAddress(email));

                // From
                
                mailMsg.From = new MailAddress(_emailSettings.SenderName, "Admin@real.com");

                // Subject and multipart/alternative Body
                mailMsg.Subject = subject; // "Testing";
                string text = message; // "text sent by sendgrid";
                string html = @"<p>html body</p>";
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                
                mailMsg.Body = text;

                
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Host = _emailSettings.MailServer; 
                    smtp.Port = _emailSettings.MailPort;
                    
                    smtp.Credentials = new NetworkCredential(_emailSettings.Sender, _emailSettings.Password);
                    // send the email
                    smtp.Send(mailMsg);
                }



                return "email has been sent to: " + email;
            }
            catch (Exception ex)
            {
                // TODO: handle exception
                //throw new InvalidOperationException(ex.Message);
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }

        
    }
}
