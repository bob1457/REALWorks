using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
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

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            //throw new NotImplementedException();

            try
            {
                using (var client = new SmtpClient(_emailSettings.MailServer, _emailSettings.MailPort))
                //using (var client = new SmtpClient("in-v3.mailjet.com", 587)) 
                {
                    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                    //client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                    try
                    {
                        MailMessage mail = new MailMessage() //;
                        {
                            From = new MailAddress(_emailSettings.SenderName) //"ml477344@telus.net"
                        };


                        mail.To.Add(new MailAddress(email));
                        mail.Subject = subject;
                        mail.Body = message;
                        mail.IsBodyHtml = true;


                        //client.Credentials = new NetworkCredential("75e9a30fdb6750c5c5c5959ba1e0fba6", "91e32634f1b7b24b8135f5380f927e8c");
                        client.Credentials = new NetworkCredential(_emailSettings.Sender, _emailSettings.Password);
                        client.EnableSsl = true;
                        await client.SendMailAsync(mail);

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }

                }

            }
            catch (Exception ex)
            {
                // TODO: handle exception
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
