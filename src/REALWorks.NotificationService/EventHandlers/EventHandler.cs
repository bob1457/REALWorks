﻿using Newtonsoft.Json.Linq;
using REALWorks.MessagingServer.Messages;
using REALWorks.NotificationService.Events;
using REALWorks.NotificationService.Services.EmailService;
using REALWorks.NotificationService.Services.MessageService;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWorks.NotificationService.EventHandlers
{
    public class EventHandler : IMessageHandlerCallback
    {
        IMessageHandler _messageHandler;
        //private RabbitMQMessageHandler messageHandler;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;

        public EventHandler(IMessageHandler messageHandler, IEmailSender emailSender, ISmsSender smsSender) //, AppMarketingDbDataContext context)
        {
            _messageHandler = messageHandler;
            //_context = context;
            _emailSender = emailSender;
            _smsSender = smsSender;
        }

        // To be reviewed ...
        //public EventHandler(RabbitMQMessageHandler messageHandler)
        //{
        //    this.messageHandler = messageHandler;
        //}

        public void Start()
        {
            _messageHandler.Start(this);
        }

        public void Stop()
        {
            _messageHandler.Stop();
        }


        public async Task<bool> HandleMessageAsync(string messageType, string message)  // MEssage type can be refactored so that there is only one type of message, e.g NotificaiotnMessage
        {
            JObject messageObject = MessageSerializer.Deserialize(message);

            try
            {
                switch (messageType)
                {
                    case "NotificationEvent":
                        await HandleAsync(messageObject.ToObject<NotificationEvent>());
                        break;

                    // All the rest will NOT be used as they are integrated with the above message type
                    #region
                    case "RegisterAccountEvent":
                        await HandleAsync(messageObject.ToObject<RegisterAccountEvent>());
                        break;
                    case "":
                        //await HandleAsync(messageObject.ToObject<LeaseFinalizedEvent>());
                        break;
                    case "RentalPropertyStatusChangeEvent":
                        //await HandleAsync(messageObject.ToObject<RentalPropertyStatusChangeEvent>());
                        break;
                    case "EnableOnlineAccessEvent":
                        await HandleAsync(messageObject.ToObject<EnableOnlineAccessEvent>());
                        break;
                    #endregion
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }
            catch (Exception ex)
            {
                string messageId = messageObject.Property("MessageId") != null ? messageObject.Property("MessageId").Value<string>() : "[unknown]";
                Log.Error(ex, "Error while handling {MessageType} message with id {MessageId}.", messageType, messageId); // message to be updated
            }

            // always akcnowledge message - any errors need to be dealt with locally.
            return true;

            //throw new NotImplementedException();
        }

        private async Task HandleAsync(NotificationEvent @event)
        {
            try
            {
                
                if(@event.NotificationType == 1)
                {
                    // Send email
                    await _emailSender.SendEmailAsync(@event.NotificationRecipient, @event.NotificationSubject, @event.NotificationBody);
                }

                if (@event.NotificationType == 2)
                {
                    // Send sms text
                    string from = "+16042434804";

                    await _smsSender.SendTextAsync( @event.NotificationRecipient, from, @event.NotificationBody);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            

            //throw new NotImplementedException();
        }

#region



        private async Task HandleAsync(EnableOnlineAccessEvent @event)
        {
            try
            {
                //await _emailSender.SendEmailAsync(@event.Email, @event.Subject, @event.Body);
            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error while sending notification message {user}.", @event.Email);
            }
            //throw new NotImplementedException();
        }

        private async Task HandleAsync(RegisterAccountEvent @event)
        {
            //EmailSettings settings;
            //var emailSender = new EmailSender();
            try
            {
                //await _emailSender.SendEmailAsync(@event.EmailRecipient, @event.EmailSubject, @event.EmailBody);
            }
            catch(Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error while sending notification message {user}.", @event.EmailRecipient);
            }
            

            //throw new NotImplementedException();
        }

#endregion

    }
}
