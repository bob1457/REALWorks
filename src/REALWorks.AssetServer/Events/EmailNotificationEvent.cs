using REALWorks.MessagingServer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.Events
{
    public class EmailNotificationEvent: Event
    {
        public EmailNotificationEvent(Guid messageId, string email, string subject, string body) : base(messageId)
        {
            Email = email;
            Subject = subject;
            Body = body;
        }

        public string Email { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
