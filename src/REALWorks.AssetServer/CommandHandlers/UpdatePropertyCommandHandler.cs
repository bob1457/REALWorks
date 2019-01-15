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
    public class UpdatePropertyCommandHandler : IRequestHandler<UpdatePropertyCommand, bool>
    {
        private readonly AppDataBaseContext _context;

        public UpdatePropertyCommandHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdatePropertyCommand request, CancellationToken cancellationToken)
        {
            //Get the property to be updated
            var ppt = _context.Property.FirstOrDefault(p => p.Id == request.PropertyId);


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



            //var property = new Property(request.PropertyName, request.PropertyDesc, request.Type,
            //    request.PropertyBuildYear, request.IsActive, request.IsShared, request.Status,
            //    request.BasementAvailable, DateTime.Now, DateTime.Now, address, facility, feature);

            var updated = ppt.Update(ppt, request.PropertyName, request.PropertyDesc, request.Type, request.PropertyBuildYear,
                request.IsActive, request.IsShared, request.Status, request.BasementAvailable, /*request.CreatedDate, */DateTime.Now,
                address, facility, feature);

            _context.Property.Update(updated);           
            //_context.PropertyAddress.Update(address);


            try
            {
                await _context.SaveChangesAsync();                
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
            //throw new NotImplementedException();
        }
    }
}
