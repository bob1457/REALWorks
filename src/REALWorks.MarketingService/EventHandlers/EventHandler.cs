using Microsoft.EntityFrameworkCore;
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
        IMessagePublisher _messagePublisher;

        public EventHandler(IMessageHandler messageHandler, AppMarketingDbDataContext context)
        {
            _messageHandler = messageHandler;           
            _context = context;
        }

        public EventHandler(IMessageHandler messageHandler, IMessagePublisher messagePublisher, AppMarketingDbDataContext context)
        {
            _messageHandler = messageHandler;
            _messagePublisher = messagePublisher;
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
                    case "PropertyUpdateEvent":
                        await HandleAsync(messageObject.ToObject<PropertyUpdateEvent>());
                        break;
                    case "AddOwnerEvent":
                        await HandleAsync(messageObject.ToObject<AddOwnerEvent>());
                        break;
                    case "UpdateOwnerEvent":
                        await HandleAsync(messageObject.ToObject<UpdateOwnerEvent>());
                        break;
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

        private async Task HandleAsync(UpdateOwnerEvent @event)
        {
            var owner = _context.RentalPropertyOwner.Include(o => o.OwnerAddress).FirstOrDefault(o => o.OriginalId == @event.PropertyOwnerId);

            var oAddress = new OwnerAddress(@event.StreetNumber, @event.City, @event.StateProv, @event.ZipPostCode, @event.Country);

            var updated = owner.Update(owner, @event.FirstName, @event.LastName, @event.ContactEmail, @event.ContactTelephone1, @event.ContactTelephone2, oAddress);

            _context.RentalPropertyOwner.Update(updated);

            try
            {
                _context.SaveChanges();

                Log.Information("Message  {MessageType} with Id {MessageId} has been handled successfully", @event.MessageType, @event.MessageId);
            }
            catch (Exception ex)
            {

                //throw;
                Log.Error(ex, "Error while handling {MessageType} message with id {MessageId}.", @event.MessageType, @event.MessageId);
            }


            //throw new NotImplementedException();
        }

        private async Task HandleAsync(AddOwnerEvent @event)
        {
            var rentalProperty = _context.RentalProperty.FirstOrDefault(p => p.OriginalId == @event.PropertyId);

            var address = new OwnerAddress(@event.StreetNumber, @event.City, @event.StateProv, @event.Country, @event.ZipPostCode);

            var owner = new RentalPropertyOwner(@event.OriginalId, @event.FirstName, @event.LastName, @event.ContactEmail, 
                @event.ContactTelephone1, @event.ContactTelephone2, address, rentalProperty.Id, DateTime.Now, DateTime.Now);

            _context.Add(owner);
            
            try
            {
                await _context.SaveChangesAsync();

                Log.Information("Owner {Owner} has been added to property {Property} successfully", @event.FirstName + " " + @event.LastName, rentalProperty.PropertyName);

                // Send message so that lease service can consume to queue app_approved


                // need to make sure the rental property exists in Lease service then send message if it does.
                //************************************************
                // It may not need this because as ApproveApplicaiton Event will send property including owner so that it should be created in Lease service already
                //************************************************

                /*
                AddOwnerEvent e = new AddOwnerEvent(new Guid(), @event.PropertyId, @event.UserName, @event.FirstName, @event.LastName,
                                                    @event.ContactEmail, @event.ContactTelephone1, @event.ContactTelephone2, @event.OnlineAccessEnbaled,
                                                    @event.UserAvartaImgUrl, @event.IsActive, @event.RoleId, @event.Notes, @event.StreetNumber,
                                                    @event.City, @event.StateProv, @event.ZipPostCode, @event.Country);


                try
                {
                    await _messagePublisher.PublishMessageAsync(e.MessageType, e, "asset_created"); // publishing the message
                    Log.Information("Message  {MessageType} with Id {MessageId} has been published successfully", e.MessageType, e.MessageId);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error while publishing {MessageType} message with id {MessageId}.", e.MessageType, e.MessageId);
                }

                */
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error while addinng owner {Owner} to {Property}.", @event.FirstName + " " + @event.LastName, rentalProperty.PropertyName);
                throw ex;
            }

            //throw new NotImplementedException();
        }

        private async Task HandleAsync(PropertyUpdateEvent @event)
        {
            var rentalProperty = _context.RentalProperty.FirstOrDefault(i => i.OriginalId == @event.PropertyId);

            var address = new Address(@event.StreetNum, @event.City, @event.StateProvince, @event.Country, @event.ZipPostCode);

            var updated = rentalProperty.Update(rentalProperty, @event.PropertyName, @event.PropertyBuildYear, @event.Type, @event.IsBasementSuite, @event.IsShared,
                @event.NumberOfBedrooms, @event.NumberOfBathrooms, @event.NumberOfLayers, @event.NumberOfParking, @event.TotalLivingArea, address);

            _context.RentalProperty.Update(updated);

            try
            {
                _context.SaveChanges();

                Log.Information("Message  {MessageType} with Id {MessageId} has been handled successfully", @event.MessageType, @event.MessageId);

            }
            catch (Exception ex)
            {

                //throw;
                Log.Error(ex, "Error while handling {MessageType} message with id {MessageId}.", @event.MessageType, @event.MessageId);
            }

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

            var owner = new RentalPropertyOwner(@event.OwnerFirstName, @event.OwnerLastName, @event.OwnerContactEmail, @event.OwnerContactTel, @event.OwnerContactOther, ownerAddress,  DateTime.Now, DateTime.Now);

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
