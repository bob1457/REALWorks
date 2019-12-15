using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.AuthServer.Events
{
    public class SmsNotificationEvent
    {
        public SmsNotificationEvent(string smsNumber, string subject, string body)
        {
            SmsNumber = smsNumber;
            Subject = subject;
            Body = body;
        }

        public string SmsNumber { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
