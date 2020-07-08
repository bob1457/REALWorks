using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using REALWorks.AssetData;
using REALWorks.AssetServer.Events;
using REALWorks.MessagingServer.Messages;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWorks.AssetCore.Entities.Property;

namespace REALWorks.AssetServer.EventHandlers
{
    public class EventHandler : IMessageHandlerCallback
    {
        private readonly AppDataBaseContext _context;

        IMessageHandler _messageHandler;

        public EventHandler(IMessageHandler messageHandler, AppDataBaseContext context)
        {
            _messageHandler = messageHandler;
            _context = context;
        }

        public void Start()
        {
            _messageHandler.Start(this);
        }

        public void Stop()
        {
            _messageHandler.Stop();
        }


        public async Task<bool> HandleMessageAsync(string messageType, string message)
        {
            JObject messageObject = MessageSerializer.Deserialize(message);

            try
            {
                switch (messageType)
                {
                    case "PropertyCreatedEvent":
                        await HandleAsync(messageObject.ToObject<PropertyCreatedEvent>());
                        break;
                    case "RentalPropertyStatusChangeEvent":
                        //await HandleAsync(messageObject.ToObject<RentalPropertyStatusChangeEvent>());
                        await HandleAsync(messageObject.ToObject<RentalPropertyStatusChangeEvent>());
                        break;
                    case "LeaseFinalizedEvent":
                        await HandleAsync(messageObject.ToObject<LeaseFinalizedEvent>());
                        break;
                    //case "MaintenanceJobFinished":
                    //    await HandleAsync(messageObject.ToObject<MaintenanceJobFinished>());
                    //    break;
                    default:
                        Console.WriteLine("Default case");
                        break;
                }
            }
            catch (Exception ex)
            {
                string messageId = messageObject.Property("MessageId") != null ? messageObject.Property("MessageId").Value<string>() : "[unknown]";
                Log.Error(ex, "Error while handling {MessageType} message with id {MessageId}.", messageType, messageId);
            }

            // always akcnowledge message - any errors need to be dealt with locally.
            return true;

            //throw new NotImplementedException();
        }

        private async Task HandleAsync(LeaseFinalizedEvent @event)
        {
            // Handle lease finalize event - update property status
            //
            var rentalProperty = _context.Property.FirstOrDefault(p => p.Id == @event.RentalPropertyId);

            RentalStatus status = (RentalStatus)Enum.Parse(typeof(RentalStatus), "rented", true);


            rentalProperty.StatusUpdate(status);

            try
            {
                await _context.SaveChangesAsync();

                Log.Information("Message  {MessageType} with Id {MessageId} has been handled successfully", @event.MessageType, @event.MessageId);
            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error while handling {MessageType} message with id {MessageId}.", @event.MessageType, @event.MessageId);
            }
            //throw new NotImplementedException();
        }

        private async Task HandleAsync(RentalPropertyStatusChangeEvent e)
        {
            var property = _context.Property
                .FirstOrDefault(p => p.Id == e.OriginalPropertyId);

            string newStatus = "";
            
            if(e.CurrentStatus == "Listed")
            {
                newStatus = "Vacant";
            }

            if (e.CurrentStatus == "NotSetted")
            {
                newStatus = "UnSet";
            }



            RentalStatus status = (RentalStatus)Enum.Parse(typeof(RentalStatus), newStatus, true);

            //property.StatusUpdate(property, status); // update method chagned
            
            
            property.StatusUpdate(status);

            try
            {
                await _context.SaveChangesAsync();

                Log.Information("Message  {MessageType} with Id {MessageId} has been handled successfully: Updated property status!", e.MessageType, e.MessageId);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while publishing {MessageType} message with id {MessageId}. Property status not updated!d", e.MessageType, e.MessageId);
                throw ex;
            }

            //var owner = _context.PropertyOwner.FirstOrDefault(p => p.Id == 1);

            //throw new NotImplementedException();
        }

        private async Task HandleAsync(PropertyCreatedEvent @event)
        {
            




            throw new NotImplementedException();
        }
    }
}
