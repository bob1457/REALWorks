using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.NotificationService.Services.MessageService
{
    public class SmsSettings
    {
        public SmsSettings(string accountSid, string authToken)
        {
            this.accountSid = accountSid;
            this.authToken = authToken;
        }

        public string accountSid { get; set; }

        public string authToken { get; set; }
    }
}
