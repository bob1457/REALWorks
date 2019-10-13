using Polly;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace REALWorks.NotificationService.Services.EmailService
{
    public class SMTPMailSender : ISMTPMailSender
    {
        private string _smptServer;
        private int _smtpPort;
        private string _userName;
        private string _password;
        private string _senderName;

        public SMTPMailSender(string smtpServer, int smtpPort, string userName, string password, string senderName)
        {
            _smptServer = smtpServer;
            _smtpPort = smtpPort;
            _userName = userName;
            _password = password;
            _senderName = senderName;
        }

        public async Task SendEmailAsync(string to, string from, string subject, string body)
        {
            using (SmtpClient client = new SmtpClient(_smptServer, _smtpPort))
            {
                //client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(_userName, _password);
                client.EnableSsl = true;

                MailMessage mailMessage = new MailMessage()
                {
                    From = new MailAddress(_senderName)  // "ml477344@telus.net"
                };
                //mailMessage.From = new MailAddress(from);
                mailMessage.To.Add(to);
                mailMessage.Body = body;
                mailMessage.Subject = subject;

                try
                {
                    await client.SendMailAsync(mailMessage);
                }
                catch(Exception ex)
                {
                    throw ex;
                }

                //await Policy
                //    .Handle<Exception>()
                //    .WaitAndRetry(3, r => TimeSpan.FromSeconds(2), (ex, ts) => { Log.Error("Error sending mail. Retrying in 2 sec."); })
                //    .Execute(() => client.SendMailAsync(mailMessage))
                //    .ContinueWith(_ => Log.Information("Notification mail sent to {Recipient}.", to));

            }


            //throw new NotImplementedException();
        }

    }
}
