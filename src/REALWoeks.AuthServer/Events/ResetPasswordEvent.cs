﻿using REALWorks.MessagingServer.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AuthServer.Events
{
    public class ResetPasswordEvent : Event
    {
        public ResetPasswordEvent(string emailRecipient, string userName, string emailSender, string emailSubject, string emailBody)
        {
            EmailRecipient = emailRecipient;
            UserName = userName;
            EmailSender = emailSender;
            EmailSubject = emailSubject;
            EmailBody = emailBody;
        }

        public string EmailRecipient { get; set; }
        public string UserName { get; set; }
        public string EmailSender { get; set; }
        public string EmailSubject { get; set; }
        public string EmailBody { get; set; }
    }
}
