﻿using Microsoft.EntityFrameworkCore;
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
                        await HandleAsync(messageObject.ToObject<WorkOrderUpdatedEvent>());
                        break;
                    case "PropertyUpdateEvent":
                        await HandleAsync(messageObject.ToObject<PropertyUpdateEvent>());
                        break;
                    case "AddOwnerEvent":
                        await HandleAsync(messageObject.ToObject<AddOwnerEvent>());
                        break;
                    case "RentalAppApprovedEvent":
                        await HandleAsync(messageObject.ToObject<RentalAppApprovedEvent>());
                        break;
                    case "UpdateOwnerEvent":
                        await HandleAsync(messageObject.ToObject<UpdateOwnerEvent>());
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

        private async Task HandleAsync(PropertyUpdateEvent @event)
        {
            var rentalProperty = _context.RentalProperty.FirstOrDefault(i => i.OriginalId == @event.PropertyId);

            var address = new Address(@event.StreetNum, @event.City, @event.StateProvince, @event.Country, @event.ZipPostCode);

            var updated = rentalProperty.Update(rentalProperty, @event.PropertyName, @event.PropertyBuildYear, @event.Type, @event.IsBasementSuite, @event.IsShared,
                @event.NumberOfBedrooms, @event.NumberOfBathrooms, @event.NumberOfLayers, @event.NumberOfParking, @event.TotalLivingArea, address);

            _context.RentalProperty.Update(updated);

            try
            {
                await _context.SaveChangesAsync();

                Log.Information("Message  {MessageType} with Id {MessageId} has been handled successfully", @event.MessageType, @event.MessageId);

            }
            catch (Exception ex)
            {

                //throw;
                Log.Error(ex, "Error while handling {MessageType} message with id {MessageId}.", @event.MessageType, @event.MessageId);
            }
            //throw new NotImplementedException();
        }

        private async Task HandleAsync(UpdateOwnerEvent @event)
        {
            var owner = _context.RentalPropertyOwner.Include(o => o.OwnerAddress).FirstOrDefault(o => o.OriginalId == @event.PropertyOwnerId);

            if (owner != null)
            {
                var oAddress = new OwnerAddress(@event.StreetNumber, @event.City, @event.StateProv, @event.ZipPostCode, @event.Country);

                var updated = owner.Update(owner, @event.FirstName, @event.LastName, @event.ContactEmail, @event.ContactTelephone1, @event.ContactTelephone2, oAddress);

                _context.RentalPropertyOwner.Update(updated);

                try
                {
                    await _context.SaveChangesAsync();

                    Log.Information("Message  {MessageType} with Id {MessageId} has been handled successfully", @event.MessageType, @event.MessageId);
                }
                catch (Exception ex)
                {

                    //throw;
                    Log.Error(ex, "Error while handling {MessageType} message with id {MessageId}.", @event.MessageType, @event.MessageId);
                }
            }
            else
            {
                Log.Information("The owner with Id: {OwnerId} does not exist.", @event.PropertyOwnerId);
            }


            //throw new NotImplementedException();
        }

        private async Task HandleAsync(AddOwnerEvent @event)
        {

            var rentalProperty = _context.RentalProperty.Include(a => a.Address).FirstOrDefault(p => p.OriginalId == @event.PropertyId);

            if (rentalProperty != null)
            {
                var address = new OwnerAddress(@event.StreetNumber, @event.City, @event.StateProv, @event.Country, @event.ZipPostCode);

                var owner = new RentalPropertyOwner(@event.OriginalId, @event.FirstName, @event.LastName, @event.ContactEmail,
                    @event.ContactTelephone1, @event.ContactTelephone2, rentalProperty.Id, address, DateTime.Now, DateTime.Now);

                _context.Add(owner);

                try
                {
                    await _context.SaveChangesAsync();

                    Log.Information("Owner {Owner} has been added to property {Property} successfully", @event.FirstName + " " + @event.LastName, rentalProperty.PropertyName);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error while addinng owner {Owner} to {Property}.", @event.FirstName + " " + @event.LastName, rentalProperty.PropertyName);
                    throw ex;
                }
            }
            else
            {
                Log.Information("The rental property with Id: {PrpertyId} does not exist.", @event.PropertyId);
            }

            

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

                var owners = new List<RentalPropertyOwner>();

                foreach (var owner in @event.PropertyOwners)
                {
                    var ownerAddress = new OwnerAddress(@event.StreetNum, @event.City, @event.StateProvince, @event.ZipPostCode, @event.Country);
                    var pOwner = new RentalPropertyOwner(owner.FirstName, owner.LastName, owner.ContactEmail, owner.ContactTelephone, owner.ContactOther, ownerAddress, DateTime.Now, DateTime.Now);
                    owners.Add(pOwner);

                }

//(IList<RentalPropertyOwner>)@event.PropertyOwners
                                              

                var newRentalProperty = new RentalProperty(@event.PropertyId,DateTime.Now, DateTime.Now, @event.ListingId, /*0,*/  @event.PropertyName,  @event.Type, @event.PropertyBuildYear,
                    @event.IsShared, "Pending", @event.IsBasementSuite, @event.NumberOfBedrooms, @event.NumberOfBathrooms, @event.NumberOfLayers,
                   @event.NumberOfParking, @event.TotalLivingArea, @event.Notes, @event.PropertyManagerUserName, address, owners);

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

        private async Task HandleAsync(WorkOrderUpdatedEvent @event) //????
        {
            //var ownerAddress = new OwnerAddress(@event.StreetNum, @event.City, @event.StateProvince, @event.City, @event.ZipPostCode);

            var address = new Address(@event.StreetNum, @event.City, @event.StateProvince, @event.City, @event.ZipPostCode);

            // need to add owner infomration

            //var owner = new RentalPropertyOwner(@event.OwnerFirstName, @event.OwnerLastName, @event.OwnerContactEmail,
            //   @event.OwnerContactTel, @event.OwnerContactOther,  @event.PropertyId, ownerAddress, DateTime.Now, DateTime.Now);

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
