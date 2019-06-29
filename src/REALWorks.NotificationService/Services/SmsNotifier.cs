using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.NotificationService.Services
{
    public class SmsNotifier : ISmsNotifier
    {
        //private string _smptServer;
        //private int _smtpPort;
        private string _account;
        private string _token;


        public SmsNotifier(/*string smtpServer, int smtpPort,*/ string account, string token)
        {
            //_smptServer = smtpServer;
            //_smtpPort = smtpPort;
            _account = account;
            _token = token;
        }

        public Task SendSmsAsync(string to, string from, string body)
        {

            throw new NotImplementedException();
        }
    }
}
