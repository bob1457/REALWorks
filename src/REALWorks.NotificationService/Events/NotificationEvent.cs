using REALWorks.MessagingServer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.NotificationService.Events
{
    public class NotificationEvent : Event
    {
        public NotificationEvent(Guid messageId, string notificationRecipient, int notificationType, //string notificationConent, 
            string notificationSubject, string notificationBody, string notificationOriginService,
            DateTime notificationTimeStamp) : base(messageId)
        {
            NotificationType = notificationType;
            NotificationRecipient = notificationRecipient;
            //NotificationConent = notificationConent;
            NotificationSubject = notificationSubject;
            NotificationBody = notificationBody;
            NotificationOriginService = notificationOriginService;
            NotificationTimeStamp = notificationTimeStamp;
        }

        public string NotificationRecipient { get; set; }

        //public int NotificaitonId { get; set; }
        public int NotificationType { get; set; } // 1. EMAIL or 2. SMS, 3. both EMAIL and SMS

        //public string NotificationConent { get; set; }

        public string NotificationSubject { get; set; }

        public string NotificationBody { get; set; }

        public string NotificationOriginService { get; set; } // from which service the notificaiton is triggered

        public DateTime NotificationTimeStamp { get; set; }
    }
}
