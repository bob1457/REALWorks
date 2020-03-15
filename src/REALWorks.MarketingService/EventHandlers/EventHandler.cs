using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using REALWorks.InfrastructureServer.MessageLog;
using REALWorks.MarketingCore.Entities;
using REALWorks.MarketingCore.ValueObjects;
using REALWorks.MarketingData;
using REALWorks.MarketingService.Events;
using REALWorks.MessagingServer.Messages;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWorks.MarketingCore.Entities.RentalProperty;
using Message = REALWorks.InfrastructureServer.MessageLog.Message;

namespace REALWorks.MarketingService.EventHandlers
{
    public class EventHandler : IMessageHandlerCallback
    {
        private readonly AppMarketingDbDataContext _context;

        IMessageHandler _messageHandler;

        public EventHandler(IMessageHandler messageHandler, AppMarketingDbDataContext context)
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
                    case "LeaseFinalizedEvent":
                        await HandleAsync(messageObject.ToObject<LeaseFinalizedEvent>());
                        break;
                    case "RentalPropertyStatusChangeEvent":
                        await HandleAsync(messageObject.ToObject<RentalPropertyStatusChangeEvent>());
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

        private Task HandleAsync(RentalPropertyStatusChangeEvent rentalPropertyStatusChangeEvent)
        {
            //Handling status change for the listed property


            throw new NotImplementedException();
        }

        private async Task HandleAsync(LeaseFinalizedEvent @event)
        {
            // Handle lease finalize event - update property status
            //
            var listing = _context.PropertyListing.FirstOrDefault(l => l.Id == @event.ListingId);

            var pId = listing.RentalPropertyId;

            var rentalProperty = _context.RentalProperty.FirstOrDefault(p => p.Id == pId);

            ListingStatus status = (ListingStatus)Enum.Parse(typeof(ListingStatus), "rented", true);


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

        private async Task HandleAsync(PropertyCreatedEvent @event)
        {
            //var p = _context.RentalProperty.FirstOrDefault(r => r.Id == 2); // Test code

            var ownerAddress = new OwnerAddress(@event.OwnerStreetNum, @event.OwnerCity, @event.OwnerStateProvince, @event.OwnerZipPostCode, @event.OwnerCountry);

            var owner = new RentalPropertyOwner(@event.OwnerFirstName, @event.OwnerLastName, @event.OwnerContactEmail, @event.OwnerContactTel, @event.OwnerContactOther, ownerAddress, DateTime.Now, DateTime.Now);

            var owners = new List<RentalPropertyOwner>();

            owners.Add(owner);

            await _context.AddAsync(owner);

            var address = new Address(
                @event.StreetNum, @event.City, @event.StateProvince, @event.Country, @event.ZipPostCode);

            var property = new RentalProperty(
                   @event.PropertyId, @event.PropertyName, @event.Type, @event.PropertyManagerUserName, @event.PropertyBuildYear,
                   @event.IsShared, @event.IsBasementSuite, @event.NumberOfBedrooms, @event.NumberOfBathrooms,
                   @event.NumberOfLayers, @event.NumberOfParking, @event.TotalLivingArea, "", DateTime.Now, 
                   DateTime.Now, address, owners);


            await _context.AddAsync(property);

            try
            {
                await _context.SaveChangesAsync();

                Log.Information("Message  {MessageType} with Id {MessageId} has been handled successfully", @event.MessageType, @event.MessageId);
            }
            catch (Exception ex)
            {
                //throw ex;
                //string messageId = messageObject.Property("MessageId") != null ? messageObject.Property("MessageId").Value<string>() : "[unknown]";
                Log.Error(ex, "Error while handling {MessageType} message with id {MessageId}.", @event.MessageType, @event.MessageId);
            }

            //throw new NotImplementedException();

            //Log.Information("Message  {MessageType} with Id {MessageId} has been handled successfully", @event.MessageType, @event.MessageId);

            //var msgDetails = new MessageDetails();

            //msgDetails.PrincicipalId = @event.PropertyId;
            //msgDetails.PrincipalType = "Property";
            //msgDetails.PrincipalNameDesc = @event.PropertyName;
            //msgDetails.OperationType = "Create";

            //var details = msgDetails.ToBsonDocument();

            //var msg = new Message(@event.MessageId, "Asset Management", details, "asset_created", "asset_created.*", "Subscription", DateTime.Now);

            //var messageLoggingService = new MessageLoggingService();

            //await messageLoggingService.LogMessage(msg);
        }
    }
}
