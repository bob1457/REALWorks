using REALWorks.MessagingServer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.NotificationService.Events
{
    public class EnableOnlineAccessEvent : Event
    {
        public string Email { get; set; }       
        public string Subject { get; set; }
        public string Body { get; set; }

        public EnableOnlineAccessEvent(Guid messageId, string email, string subject, string body ) : base(messageId)
        {
            Email = email;            
            Subject = subject;
            Body = body;
        }
    }
}
