using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.NotificationService.Services.EmailService
{
    public class EmailSettings
    {
        public EmailSettings(string mailServer, int mailPort, string senderName, string sender, string password)
        {
            MailServer = mailServer;
            MailPort = mailPort;
            SenderName = senderName;
            Sender = sender;
            Password = password;
        }

        public string MailServer { get; set; }
        public int MailPort { get; set; }
        public string SenderName { get; set; }
        public string Sender { get; set; }
        public string Password { get; set; }
    }
}
