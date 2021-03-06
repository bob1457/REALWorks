﻿using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWorks.AssetCore.Entities;
using REALWorks.AssetCore.ValueObjects;
using REALWorks.AssetData;
using REALWorks.AssetServer.Commands;
using REALWorks.AssetServer.Events;
using REALWorks.MessagingServer.Messages;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.CommandHandlers
{
    public class AddOwnerToExistingPropertyCommandHandler : IRequestHandler<AddOwnerToExistingPropertyCommand, AddOwnerToExistingPropertyCommandResult>
    {
        private readonly AppDataBaseContext _context;

        IMessagePublisher _messagePublisher;

        public AddOwnerToExistingPropertyCommandHandler(AppDataBaseContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        public async Task<AddOwnerToExistingPropertyCommandResult> Handle(AddOwnerToExistingPropertyCommand request, CancellationToken cancellationToken)
        {
            var property = _context.Property.FirstOrDefault(p => p.Id == request.PropertyId);

            PropertyOwner owner = null;

            var addedOwner = new AddOwnerToExistingPropertyCommandResult();

            // Check if the email already exist if adding new owner instead of existing owner
            //

            //var user = _context.PropertyOwner.FirstOrDefault(e => e.ContactEmail == request.ContactEmail);

            //if (user != null)
            //{
            //    return new AddOwnerToExistingPropertyCommandResult() { Notes = "The email already exists!"};
            //}

            // populate the addedOnwer
            addedOwner.UserAvartaImgUrl = request.UserAvartaImgUrl;
            addedOwner.FirstName = request.FirstName;
            addedOwner.LastName = request.LastName;
            addedOwner.UserName = request.UserName;
            addedOwner.ContactEmail = request.ContactEmail;
            addedOwner.ContactTelephone1 = request.ContactTelephone1;
            addedOwner.ContactTelephone2 = request.ContactTelephone2;
            addedOwner.OnlineAccessEnbaled = request.OnlineAccessEnbaled;
            addedOwner.IsActive = request.IsActive;
            addedOwner.RoleId = request.RoleId;
            addedOwner.Notes = request.Notes;
            addedOwner.StreetNumber = request.StreetNumber;
            addedOwner.City = request.City;
            addedOwner.StateProv = request.StateProv;
            addedOwner.ZipPostCode = request.ZipPostCode;
            addedOwner.Country = request.Country;


            if (request.PropertyOwnerId == 0)
            {
                // Check if the email already exist if adding new owner instead of existing owner
                //

                var user = _context.PropertyOwner.FirstOrDefault(e => e.ContactEmail == request.ContactEmail);

                if (user != null)
                {
                    return new AddOwnerToExistingPropertyCommandResult() { Notes = "The email already exists!" };
                }

                var ownerAddress = new OwnerAddress(request.StreetNumber, request.City, request.StateProv, request.Country,request. ZipPostCode);

                owner  = property.AddNewOwnerToProperty(request.PropertyId, request.UserName, request.FirstName, request.LastName, request.ContactEmail,
                    request.ContactTelephone1, request.ContactTelephone2, false, request.UserAvartaImgUrl, request.IsActive, 2, request.Notes, ownerAddress);

                _context.Add(owner);
            }
            else
            {
                owner = _context.PropertyOwner.Include(a => a.Address).FirstOrDefault(o => o.Id == request.PropertyOwnerId);

                var ownerProperty = property.AddExistingOwnerToProperty(owner, request.PropertyId);

                _context.Add(ownerProperty);
            }

            
            try
            {
                await _context.SaveChangesAsync();

                addedOwner.PropertyOwnerId = owner.Id;


                // logging
                Log.Information("The new owner {OwnerName} has been added to the property {PorpertyName} successfully", request.FirstName + " " + request.LastName, property.PropertyName);

                // Send messages if necessary
                // Publish message to MQ for other service to consume

                AddOwnerEvent e = new AddOwnerEvent(new Guid(), owner.Id, request.PropertyId, owner.UserName, owner.FirstName, owner.LastName,
                                                    owner.ContactEmail, owner.ContactTelephone1, owner.ContactTelephone2, owner.OnlineAccess,
                                                    owner.UserAvartaImgUrl, owner.IsActive, owner.RoleId, owner.Notes, owner.Address.StreetNumber,
                                                    owner.Address.City, owner.Address.StateProvince, owner.Address.ZipPostCode, owner.Address.Country);


                try
                {
                    await _messagePublisher.PublishMessageAsync(e.MessageType, e, "asset_created"); // publishing the message
                    Log.Information("Message  {MessageType} with Id {MessageId} has been published successfully", e.MessageType, e.MessageId);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error while publishing {MessageType} message with id {MessageId}.", e.MessageType, e.MessageId);
                }


            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error occured while adding the new owner {OwnerName} to the property {PropertyName}.", request.FirstName + " " + request.LastName, property.PropertyName);
            }

            return addedOwner;
        }


    }
}
