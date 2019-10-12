using REALWorks.MessagingServer.EventBus;
using REALWorks.MessagingServer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.NotificationService.Events
{
    public class RegisterAccountEvent: IntegrationEvent
    {
        public RegisterAccountEvent(Guid messageId, string emailRecipient, string userName, string emailSender, string emailBody, string subject) 
        {
            EmailRecipient = emailRecipient;
            UserName = userName;
            EmailSender = emailSender;
            EmailBody = emailBody;
            EmailSubject = subject;
        }

        public string EmailRecipient { get; set; }
        public string UserName { get; set; }
        public string EmailSender { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
    }
}
