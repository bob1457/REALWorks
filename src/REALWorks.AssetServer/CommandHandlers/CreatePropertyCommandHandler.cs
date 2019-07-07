using MediatR;
using MongoDB.Bson;
using Newtonsoft.Json.Linq;
using REALWorks.AssetCore.Entities;
using REALWorks.AssetCore.ValueObjects;
using REALWorks.AssetData;
using REALWorks.AssetServer.Commands;
using REALWorks.AssetServer.Events;
using REALWorks.InfrastructureServer.MessageLog;
using REALWorks.MessagingServer.Messages;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Message = REALWorks.InfrastructureServer.MessageLog.Message;

namespace REALWorks.AssetServer.CommandHandlers
{
    public class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, bool>
    {
        private readonly AppDataBaseContext _context;
        private readonly IMessageLoggingService _loggingService;
        private IMediator _mediator;

        IMessagePublisher _messagePublisher;

        public CreatePropertyCommandHandler(AppDataBaseContext context, IMessagePublisher messagePublisher, IMessageLoggingService loggingService, IMediator mediator)
        {
            _context = context;
            _messagePublisher = messagePublisher;
            _loggingService = loggingService;
            _mediator = mediator;
        }

        public async Task<bool> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
            #region Create property aggregate root

            var address = new PropertyAddress(request.PropertySuiteNumber, 
                request.PropertyNumber, request.PropertyStreet, 
                request.PropertyCity, request.PropertyStateProvince, request.PropertyZipPostCode, 
                request.PropertyCountry);

            var feature = new PropertyFeature(request.NumberOfBathrooms,
                request.NumberOfBathrooms, request.NumberOfLayers,
                request.NumberOfParking, request.BasementAvailable,
                request.TotalLivingArea, request.IsShared, request.FeatureNotes);
           

            var facility = new PropertyFacility(request.Stove, request.Refrigerator, request.Dishwasher, 
                request.AirConditioner, request.Laundry, request.BlindsCurtain, request.Furniture, 
                request.Tvinternet, request.CommonFacility, request.SecuritySystem, request.UtilityIncluded,
                request.FireAlarmSystem, request.FacilityNotes, request.Others);



            var property = new Property(request.PropertyName, request.PropertyDesc,  request.Type, request.PropertyManagerUserName,
                request.PropertyBuildYear, request.IsActive, request.IsShared, request.Status, 
                request.BasementAvailable, DateTime.Now, DateTime.Now, address, facility, feature);


            await _context.AddAsync(property);

            #endregion


            if (request.PropertyOwnerId == 0)
            {
                object ownerAddress = null;

                if (!request.IsSameAddress)
                {
                    ownerAddress = new OwnerAddress( request.OwnerStreetNumber, request.OwnerCity, request.OwnerStateProv, 
                                                         request.OwnerCountry, request.OwnerZipPostCode);
                }
                else
                {
                    ownerAddress = new OwnerAddress(request.PropertySuiteNumber + " " + request.PropertyNumber + " " + request.PropertyStreet, request.PropertyCity, request.PropertyStateProvince,
                                                         request.PropertyCountry, request.PropertyZipPostCode);
                }                
                
                var owner = property.AddOwner("NotSet", request.FirstName, request.LastName, request.ContactEmail,
                    request.ContactTelephone1, request.ContactTelephone2, request.OnlineAccessEnbaled, request.UserAvartaImgUrl,
                    request.IsActive, request.RoleId, request.Notes, (OwnerAddress)ownerAddress);


                await _context.AddAsync(owner);

            }
            else
            {
                var owner = _context.PropertyOwner.FirstOrDefault(o => o.Id == request.PropertyOwnerId);

                var ownerProperty = property.AddExsitingOwner(owner);

                owner.OwnerProperty.Add(ownerProperty);

            }

            try
            {
                await _context.SaveChangesAsync(); // comment out for testing message sending ONLY

                int propertyId = property.Id;

                request.PropertyId = property.Id;
                request.CreatedDate = property.Created;
                request.UpdateDate = property.Modified;

                Log.Information("Property with id {PropertyName} has been successfully created.", property.PropertyName );

               
                // Publish Domain Event (MediatR pattern)

                AssetCore.Events.PropertyCreatedEvent domainEvent = new AssetCore.Events.PropertyCreatedEvent(property);                

                await _mediator.Publish(domainEvent);



                // Publish Integration Event (RabbitMQ)

                var streetNum = request.PropertySuiteNumber + " " + request.PropertyNumber + " " + request.PropertyStreet;

                //var streetNum = address.PropertySuiteNumber + " " + address.PropertyNumber + " " + address.PropertyStreet;
                // Send message to MQ
                //
                PropertyCreatedEvent e = new PropertyCreatedEvent(Guid.NewGuid(), request.PropertyId, request.PropertyName, request.PropertyManagerUserName,
                    request.PropertyBuildYear, request.Type.ToString(), request.BasementAvailable, request.IsShared, request.NumberOfBedrooms,
                    request.NumberOfBathrooms, request.NumberOfLayers, request.NumberOfParking, request.TotalLivingArea,
                    streetNum, request.PropertyCity, request.PropertyStateProvince, request.PropertyCountry,
                    request.PropertyZipPostCode, request.FirstName, request.LastName, request.ContactEmail, request.ContactTelephone1, request.ContactTelephone2,                    
                    request.OwnerStreetNumber, request.OwnerCity, request.OwnerStateProv, request.OwnerZipPostCode, request.OwnerCountry);

                try
                {
                    await _messagePublisher.PublishMessageAsync(e.MessageType, e, "asset_created"); // publishing the message
                    Log.Information("Message  {MessageType} with Id {MessageId} has been published successfully", e.MessageType, e.MessageId);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error while publishing {MessageType} message with id {MessageId}.", e.MessageType, e.MessageId);
                }
                

                // Log message for reconciliation purpose         ******** This part can be replaced by Serilog ***************       
                //
                var msgDetails = new MessageDetails();

                msgDetails.PrincicipalId = e.PropertyId;
                msgDetails.PrincipalType = "Property";
                msgDetails.PrincipalNameDesc = e.PropertyName;
                msgDetails.OperationType = "Create";

                var details = msgDetails.ToBsonDocument();

                var msg = new Message(e.MessageId, "Asset Management", details, "asset_created", "asset_created.*", "Publish", DateTime.Now);

                await _loggingService.LogMessage(msg);

            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error while creating property, {PropertyName} has not been created.", request.PropertyName);
            }

            return true;   

        }

        
    }
}
