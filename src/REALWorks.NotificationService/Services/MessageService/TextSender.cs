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
        public static IConfigurationRoot Config { get; private set; }

        private readonly SmsSettings _smsSettings;

        public TextSender()
        {

        }

        public TextSender(SmsSettings smsSettings)
        {
            _smsSettings = smsSettings;
        }

        public async Task<string> SendTextAsync(string from, string to, string message)
        {
            //var smsConfiguration = Config.GetSection("SmsSettings");
            //string accountSid = smsConfiguration["AccountSID"];
            //string authCode = smsConfiguration["AuthToken"];

            const string accountSid = "AC77d88a49c272f063fe810c7501361d4c";
            const string authToken = "85510000205de82211b993482351d6ce";

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
