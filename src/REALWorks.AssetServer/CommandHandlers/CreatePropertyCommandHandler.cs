using MediatR;
using REALWorks.AssetCore.Entities;
using REALWorks.AssetCore.ValueObjects;
using REALWorks.AssetData;
using REALWorks.AssetServer.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.CommandHandlers
{
    public class CreatePropertyCommandHandler : IRequestHandler<CreatePropertyCommand, bool>
    {
        private readonly AppDataBaseContext _context;      

        public CreatePropertyCommandHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(CreatePropertyCommand request, CancellationToken cancellationToken)
        {
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


            if (request.PropertyOwnerId == 0)
            {

                var owner = property.AddOwner("NotSet", request.FirstName, request.LastName, request.ContactEmail,
                    request.ContactTelephone1, request.ContactTelephone2, request.OnlineAccessEnbaled, request.UserAvartaImgUrl,
                    request.IsActive, request.RoleId, request.Notes);


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
                await _context.SaveChangesAsync();

                int propertyId = property.Id;

                request.PropertyId = property.Id;
                request.CreatedDate = property.Created;
                request.UpdateDate = property.Modified;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;   

        }

        
    }
}
