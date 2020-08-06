using REALWorks.MessagingServer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.Events
{
    public class EmailNotificationEvent: Event
    {
        //public EmailNotificationEvent(string email, string subject, string body)
        //{
        //    Email = email;
        //    Subject = subject;
        //    Body = body;
        //}

        //public string Email { get; set; }
        //public string Subject { get; set; }
        //public string Body { get; set; }



        public EmailNotificationEvent(Guid messageId, List<string> notificationRecipients, int notificationType, //string notificationConent, 
           string notificationSubject, string notificationBody, string notificationOriginService,
           DateTime notificationTimeStamp) : base(messageId)
        {
            NotificationType = notificationType;
            NotificationRecipients = notificationRecipients;
            //NotificationConent = notificationConent;
            NotificationSubject = notificationSubject;
            NotificationBody = notificationBody;
            NotificationOriginService = notificationOriginService;
            NotificationTimeStamp = notificationTimeStamp;
        }
    

        public List<string> NotificationRecipients { get; set; }

        //public int NotificaitonId { get; set; }
        public int NotificationType { get; set; } // 1. EMAIL or 2. SMS, 3. both EMAIL and SMS

        //public string NotificationConent { get; set; }

        public string NotificationSubject { get; set; }

        public string NotificationBody { get; set; }

        public string NotificationOriginService { get; set; } // from which service the notificaiton is triggered

        public DateTime NotificationTimeStamp { get; set; }
    }
}
