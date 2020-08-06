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
                ////using (var client = new SmtpClient(_emailSettings.MailServer, _emailSettings.MailPort))
                ////using (var client = new SmtpClient("in-v3.mailjet.com", 587))
                //using (var client = new SmtpClient("smtp.sendgrid.net", Convert.ToInt32(587)))
                //{
                //    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                //    //client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                //    try
                //    {
                //        MailMessage mail = new MailMessage() //;
                //        {
                //            From = new MailAddress(_emailSettings.SenderName) //"ml477344@telus.net"
                //        };


                //        mail.To.Add(new MailAddress(email));
                //        mail.Subject = subject;
                //        mail.Body = message;
                //        mail.IsBodyHtml = true;


                //        //client.Credentials = new NetworkCredential("75e9a30fdb6750c5c5c5959ba1e0fba6", "91e32634f1b7b24b8135f5380f927e8c");
                //        client.Credentials = new NetworkCredential(_emailSettings.Sender, _emailSettings.Password);
                //        client.EnableSsl = true;
                //        await client.SendMailAsync(mail);

                //    }
                //    catch (Exception ex)
                //    {
                //        //throw ex;
                //        Log.Error(ex, "Error while sending mail. Error:  {Error} ", ex.Message);
                //    }

                //}

                //string gmailHost = "smtp.gmail.com";
                //int gmailPort = 465;
                //string gmailUserName = "bob.h.yuan@gmail.com";
                //string gmailPass = "MBA570924!";


                MailMessage mailMsg = new MailMessage();

                // To
                //mailMsg.To.Add(new MailAddress("bob.yuan@yahoo.com", "Bob"));
                mailMsg.To.Add(new MailAddress(email));

                // From
                mailMsg.From = new MailAddress("bob.h.yuan@gmail.com", "Admin@real.com");

                // Subject and multipart/alternative Body
                mailMsg.Subject = subject; // "Testing";
                string text = message; // "text sent by sendgrid";
                string html = @"<p>html body</p>";
                mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
                //mailMsg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));
                mailMsg.Body = text;

                //// Init SmtpClient and send
                //SmtpClient smtpClient = new SmtpClient(gmailHost, 465);
                ////System.Net.NetworkCredential credentials = new System.Net.NetworkCredential("apikey", "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");
                //System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(gmailUserName, gmailPass);
                //smtpClient.Credentials = credentials;


                //smtpClient.Send(mailMsg);

                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.EnableSsl = true;
                    smtp.Host = "smtp.gmail.com";
                    smtp.Port = 587;
                    smtp.Credentials = new NetworkCredential("bob.h.yuan@gmail.com", "MBA570924!");
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
