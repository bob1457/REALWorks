using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace REALWorks.NotificationService.Services.MessageService
{
    public class TextSender : ISmsSender
    {
        public static IConfiguration Config { get; private set; }

        private readonly SmsSettings _smsSettings;

        public TextSender()
        {

        }

        public TextSender(SmsSettings smsSettings)
        {
            _smsSettings = smsSettings;
        }

        public async Task<string> SendTextAsync(string to, string from, string message)
        {
            
            string accountSid = _smsSettings.accountSid; 
            string authToken = _smsSettings.authToken;

            TwilioClient.Init(accountSid, authToken);

            try
            {
                var txtMessage = MessageResource.Create(
                    body: message, // "Join Earth's mightiest heroes. Like Kevin Bacon.",
                    from: new Twilio.Types.PhoneNumber(from),
                    to: new Twilio.Types.PhoneNumber(to)
                );

                Console.WriteLine(txtMessage.Sid);
            }
            catch (Exception ex)
            {

                throw ex;
            }
           

            return "SMS text sent successfully";

            //throw new NotImplementedException();
        }
    }
}
