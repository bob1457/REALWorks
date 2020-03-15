using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using REALWork.LeaseManagementCore.Entities;
using REALWork.LeaseManagementCore.ValueObjects;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.Events;
using REALWorks.MessagingServer.Messages;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.EventHandlers
{
    public class EventHandler : IMessageHandlerCallback
    {
        private readonly AppLeaseManagementDbContext _context;

        IMessageHandler _messageHandler;

        public EventHandler(IMessageHandler messageHandler, AppLeaseManagementDbContext context)
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
                    case "NewTemantCreatedEvent":
                        await HandleAsync(messageObject.ToObject<NewTemantCreatedEvent>());
                        break;
                    case "RentalPropertyStatusChangeEvent":
                        //await HandleAsync(messageObject.ToObject<RentalPropertyStatusChangeEvent>());
                        //await HandleAsync(messageObject.ToObject<RentalPropertyStatusChangeEvent>());
                        break;
                    case "RentalPropertyCreatedEvent":
                        await HandleAsync(messageObject.ToObject<PropertyCreatedEvent>());
                        break;
                    case "RentalAppApprovedEvent":
                        await HandleAsync(messageObject.ToObject<RentalAppApprovedEvent>());
                        break;
                    //case "LeaseFinalizedEvent":
                    //    await HandleAsync(messageObject.ToObject<LeaseFinalizedEvent>());
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

        private Task HandleAsync(LeaseFinalizedEvent leaseFinalizedEvent)
        {



            throw new NotImplementedException();
        }

        private async Task HandleAsync(RentalAppApprovedEvent @event)
        {

            var newTenant = new NewTenant(@event.UserName, @event.FirstName, @event.LastName, @event.ContactEmail,
                @event.ContactTelephone1, @event.ContactTelephone2, @event.ContactOthers, DateTime.Now, DateTime.Now);

            _context.Add(newTenant);

            var rentalproperty = _context.RentalProperty.Include(a => a.Address).FirstOrDefault(a => a.OriginalId == @event.PropertyId); // Get related rental property
            //Note above: @event.ProeprtyId comes from the event and is the Id for rental property (in Marketing), it should be named OriginalId in RentalProperty in Lease service

            if (rentalproperty == null)
            {
                var address = new Address(@event.StreetNum, @event.City, @event.StateProvince, @event.Country, @event.ZipPostCode);

                var newRentalProperty = new RentalProperty(@event.PropertyId,DateTime.Now, DateTime.Now, 0,  @event.PropertyName,  @event.Type, @event.PropertyBuildYear,
                    @event.IsShared, "Pending", @event.IsBasementSuite, @event.NumberOfBedrooms, @event.NumberOfBathrooms, @event.NumberOfLayers,
                   @event.NumberOfParking, @event.TotalLivingArea, @event.Notes, @event.PropertyManagerUserName, address);

                _context.RentalProperty.Add(newRentalProperty);

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

            }


            //throw new NotImplementedException();
        }

        private async Task HandleAsync(PropertyCreatedEvent @event)
        {
            var address = new Address(@event.StreetNum, @event.City, @event.StateProvince, @event.City, @event.ZipPostCode);
            var rentalProperty = new RentalProperty(@event.PropertyId, DateTime.Now, DateTime.Now, 0, @event.PropertyName, @event.Type, @event.PropertyBuildYear, 
                @event.IsShared,"Rented", @event.IsBasementSuite, @event.NumberOfBedrooms, @event.NumberOfBathrooms, @event.NumberOfLayers, @event.NumberOfParking, 
                @event.TotalLivingArea, "", @event.PropertyManagerUserName, address);

            _context.RentalProperty.Add(rentalProperty);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //throw new NotImplementedException();
        }

        private async Task HandleAsync(NewTemantCreatedEvent @event)
        {
            var newTenant = new NewTenant(@event.UserName, @event.FirstName, @event.LastName, @event.ContactEmail, 
                @event.ContactTelephone1, @event.ContactTelephone2, @event.ContactOthers, DateTime.Now, DateTime.Now);

                _context.Add(newTenant);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //var owner = _context.PropertyOwner.FirstOrDefault(p => p.Id == 1);

            //throw new NotImplementedException();
        }

        //private async Task HandleAsync(PropertyCreatedEvent @event)
        //{





        //    throw new NotImplementedException();
        //}
    }
}
