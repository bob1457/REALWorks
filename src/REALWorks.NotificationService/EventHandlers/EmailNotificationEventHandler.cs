using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;
using REALWorks.MessagingServer.Messages;
using REALWorks.NotificationService.Events;
using REALWorks.NotificationService.Services.EmailService;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.NotificationService.EventHandlers
{
    public class EmailNotificationEventHandler : IMessageHandlerCallback
    {
        IMessageHandler _messageHandler;
        //INotificationRepository _repo;
        ISMTPMailSender _smtpMailSender;


        public EmailNotificationEventHandler(IMessageHandler messageHandler, /*INotificationRepository repo,*/ ISMTPMailSender smtpMailSender)
        {
            _messageHandler = messageHandler;
            //_repo = repo;
            _smtpMailSender = smtpMailSender;
        }

        public void Start()
        {
            _messageHandler.Start(this);
            //return Task.CompletedTask;
        }

        public void Stop()
        {
            _messageHandler.Stop();
            //return Task.CompletedTask;
        }

        public async Task<bool> HandleMessageAsync(string messageType, string message)
        {
            try
            {
                JObject messageObject = MessageSerializer.Deserialize(message);
                switch (messageType)
                {
                    case "EmailNotificationEvent":
                        await HandleAsync(messageObject.ToObject<EmailNotificationEvent>());
                        break;
                    case "MaintenanceJobPlanned":
                        //await HandleAsync(messageObject.ToObject<MaintenanceJobPlanned>());
                        break;
                    case "MaintenanceJobFinished":
                        //await HandleAsync(messageObject.ToObject<MaintenanceJobFinished>());
                        break;
                    case "DayHasPassed":
                        //await HandleAsync(messageObject.ToObject<DayHasPassed>());
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, $"Error while handling {messageType} event.");
            }

            return true;

            //throw new NotImplementedException();
        }

        private async Task HandleAsync(EmailNotificationEvent @event)
        {
            try
            {
                await _smtpMailSender.SendEmailAsync(@event.Email, "", @event.Subject, @event.Body);
            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error while sending notification message to { user }.", @event.Email);
            }

            //throw new NotImplementedException();
        }
    }
}
