using MediatR;
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
    public class UpdatePropertyCommandHandler : IRequestHandler<UpdatePropertyCommand, UpdatePropertyCommandResult>
    {
        private readonly AppDataBaseContext _context;

        IMessagePublisher _messagePublisher;

        public UpdatePropertyCommandHandler(AppDataBaseContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        public async Task<UpdatePropertyCommandResult> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
        {
            var ppt = _context.Property.Include(op => op.OwnerProperty).ThenInclude(o => o.PropertyOwner ).FirstOrDefault(p => p.Id == request.PropertyId);

//
            var address = new PropertyAddress(request.PropertySuiteNumber,
                request.PropertyNumber, request.PropertyStreet,
                request.PropertyCity, request.PropertyStateProvince, request.PropertyZipPostCode,
                request.PropertyCountry);

            var feature = new PropertyFeature(request.NumberOfBedrooms,
                request.NumberOfBathrooms, request.NumberOfLayers,
                request.NumberOfParking, request.BasementAvailable,
                request.TotalLivingArea, request.IsShared, request.FeatureNotes);


            var facility = new PropertyFacility(request.Stove, request.Refrigerator, request.Dishwasher,
                request.AirConditioner, request.Laundry, request.BlindsCurtain, request.Furniture,
                request.Tvinternet, request.CommonFacility, request.SecuritySystem, request.UtilityIncluded,
                request.FireAlarmSystem, request.FacilityNotes, request.Others);



            var updated = ppt.Update(ppt, request.PropertyName, request.PropertyDesc, request.PropertyType1, request.PropertyBuildYear,
                request.IsActive, request.IsShared, request.Status, request.BasementAvailable,  DateTime.Now,
                address, facility, feature);

            _context.Property.Update(updated);

            var owners = ppt.OwnerProperty.Select(o => o.PropertyOwner).ToList();




            //var owners = _context.PropertyOwner
            //    .Include(op => op.OwnerProperty)
            //    .ThenInclude(p => p.FirstOrDefault().PropertyId == request.PropertyId).ToList();



            var contracts = _context.ManagementContract
                //.Include(p => p.Property)
                .Where(p => p.PropertyId == request.PropertyId).ToList();
               

            var updatedProperty = new UpdatePropertyCommandResult();
            // need to populate it either manual or automapper***************************
            updatedProperty.PropertyId = request.PropertyId;
            updatedProperty.Id = request.PropertyId;
            updatedProperty.AirConditioner = request.AirConditioner;
            updatedProperty.BasementAvailable = request.BasementAvailable;
            updatedProperty.CommonFacility = request.CommonFacility;
            updatedProperty.Dishwasher = request.Dishwasher;
            updatedProperty.FacilityNotes = request.FacilityNotes;
            updatedProperty.FireAlarmSystem = request.FireAlarmSystem;
            //updatedProperty.FurnishingId = request.FurnishingId;
            updatedProperty.Furniture = request.Furniture;
            updatedProperty.IsActive = request.IsActive;
            updatedProperty.IsShared = request.IsShared;
            updatedProperty.Laundry = request.Laundry;
            updatedProperty.NumberOfBathrooms = request.NumberOfBathrooms;
            updatedProperty.NumberOfBedrooms = request.NumberOfBedrooms;
            updatedProperty.NumberOfLayers = request.NumberOfLayers;
            updatedProperty.NumberOfParking = request.NumberOfParking;
            updatedProperty.Others = request.Others;
            updatedProperty.PropertyBuildYear = request.PropertyBuildYear;
            updatedProperty.PropertyCity = request.PropertyCity;
            updatedProperty.PropertyCountry = request.PropertyCountry;
            updatedProperty.PropertyDesc = request.PropertyDesc;
            //updatedProperty.PropertyLogoImgUrl = request.PropertyLogoImgUrl;
            //updatedProperty.PropertyManagerId = request.PropertyManagerId;
            updatedProperty.PropertyName = request.PropertyName;
            updatedProperty.PropertyNumber = request.PropertyNumber;
            updatedProperty.PropertyStateProvince = request.PropertyStateProvince;
            updatedProperty.PropertyStreet = request.PropertyStreet;
            updatedProperty.PropertySuiteNumber = request.PropertySuiteNumber;
            //updatedProperty.PropertyVideoUrl = request.PropertyVideoUrl;
            updatedProperty.PropertyZipPostCode = request.PropertyZipPostCode;
            updatedProperty.Refrigerator = request.Refrigerator;
            updatedProperty.SecuritySystem = request.SecuritySystem;
            updatedProperty.FeatureNotes = request.FeatureNotes;

            updatedProperty.Status = request.Status.ToString(); //***************************************************************

            updatedProperty.Stove = request.Stove;
            updatedProperty.TotalLivingArea = request.TotalLivingArea;
            updatedProperty.Tvinternet = request.Tvinternet; 

            updatedProperty.PropertyType1 = request.PropertyType1.ToString(); //***************************************************************
            updatedProperty.Type = request.PropertyType1.ToString();// new for client side rendering

            updatedProperty.UtilityIncluded = request.UtilityIncluded;
            updatedProperty.CreationDate = ppt.Created;
            updatedProperty.CreatedDate = ppt.Created; //new for client side rendering

            updatedProperty.UpdateDate = updated.Modified;

            updatedProperty.OwnerList = owners;
            updatedProperty.ContractList = contracts;

            try
            {
                await _context.SaveChangesAsync();

                // logging
                Log.Information("The property {PorpertyName} has been updated successfully", ppt.PropertyName);

                // Send messages if necessary

                PropertyUpdateEvent e = new PropertyUpdateEvent(Guid.NewGuid(), request.PropertyId, request.PropertyName,
                    request.PropertyBuildYear, request.PropertyType1.ToString(), request.BasementAvailable, request.IsShared, request.NumberOfBedrooms,
                    request.NumberOfBathrooms, request.NumberOfLayers, request.NumberOfParking, request.TotalLivingArea,
                    request.PropertyNumber, request.PropertyCity, request.PropertyStateProvince, request.PropertyCountry,
                    request.PropertyZipPostCode);

                try
                {
                    await _messagePublisher.PublishMessageAsync(e.MessageType, e, "asset_created"); // publishing the message

                }
                catch (Exception ex)
                {

                    Log.Error(ex, "Error while publishing {MessageType} message with id {MessageId}.", e.MessageType, e.MessageId);
                }
                
            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error occured while deleting the image for the property {PropertyName}.", ppt.PropertyName);
            }

            return updatedProperty;  //.true;
        }
    }
}
