using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWorks.AssetCore.Entities;
using REALWorks.AssetData;
using REALWorks.AssetServer.Commands;
using REALWorks.AssetServer.Services.ViewModels;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.CommandHandlers
{
    public class UpdatePropertyOwnerCommandHandler : IRequestHandler<UpdatePropertyOwnerCommand, UpdatePropertyOwnerCommandResult>
    {
        private readonly AppDataBaseContext _context;

        public UpdatePropertyOwnerCommandHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<UpdatePropertyOwnerCommandResult> Handle(UpdatePropertyOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = _context.PropertyOwner.Include(op => op.OwnerProperty).ThenInclude(p => p.Property)
                .FirstOrDefault(o => o.Id == request.Id);

            var property = owner.OwnerProperty.FirstOrDefault().Property;

            var updated = property.UpdateOwner(owner, request.FirstName, request.LastName, request.ContactEmail, request.ContactTelephone1,
                request.ContactTelephone2, request.UserAvartaImgUrl, request.IsActive, request.Notes, request.StreetNumber, request.City, request.StateProvince, 
                request.ZipPostCode, request.Country);

            //var updated = owner.Update(owner, request.FirstName, request.LastName, request.ContactEmail, request.ContactTelephone1, 
            //    request.ContactTelephone2, request.UserAvartaImgUrl, request.IsActive, request.Notes);

            var updatedOwner = new UpdatePropertyOwnerCommandResult();

            var address = new UpdatedOwnerAddress();

            address.City = request.City;
            address.StreetNumber = request.StreetNumber;
            address.StateProvince = request.StateProvince;
            address.ZipPostCode = request.ZipPostCode;
            address.Country = request.Country;

            // Query list of property owned by this owner
            //getOwnerPropertyList(request.Id);

            /*
             
             */

            //var propertyList = _context.Property
            //    .Include(a => a.Address)
            //    .Include(op => op.OwnerProperty)
            //    .ThenInclude(o => o.PropertyOwner)
            //    //.ThenInclude(p => p.Id == request.Id)
            //    .Where(o => o.Id == request.Id)
            //    .ToList();

            //var propertyList = (from p in _context.Property.Include(a => a.Address)
            //                    join op in _context.OwnerProperty on p.Id equals op.PropertyId
            //                    join o in _context.PropertyOwner on op.PropertyOwnerId equals o.Id
            //                    where o.Id == request.Id
            //                    select new PropertyListViewModel
            //                    {
            //                        PropertyName = p.PropertyName.

            //var powner = _context.PropertyOwner
            //     .Include(op => op.OwnerProperty)
            //     .ThenInclude(p => p.Property).ToList()
            //     .Where(o => o.Id == request.Id);

            var propertyList = owner.OwnerProperty.ToList();
            //                    }).ToList();




            //populate the updated owner
            updatedOwner.Id = request.Id;
            updatedOwner.FirstName = request.FirstName;
            updatedOwner.LastName = request.LastName;
            updatedOwner.ContactEmail = request.ContactEmail;
            updatedOwner.ContactTelephone1 = request.ContactTelephone1;
            updatedOwner.ContactTelephone2 = request.ContactTelephone2;
            updatedOwner.UserAvartaImgUrl = request.UserAvartaImgUrl;
            updatedOwner.IsActive = request.IsActive;
            updatedOwner.Notes = request.Notes;
            updatedOwner.UpdateDate = DateTime.Now;
            updatedOwner.City = request.City;
            updatedOwner.StreetNumber = request.StreetNumber;
            updatedOwner.StateProvince = request.StateProvince;
            updatedOwner.ZipPostCode = request.ZipPostCode;
            updatedOwner.Country = request.Country;
            updatedOwner.Created = owner.Created;
            updatedOwner.Updated = owner.Modified;

            updatedOwner.Address = address;

            updatedOwner.OwnerProperty = propertyList;

            _context.Update(updated);

            try
            {
                await _context.SaveChangesAsync();

                // logging
                Log.Information("The owner {OwnerName} for the property {PorpertyName} has been updated successfully", owner.FirstName + " " + owner.LastName, property.PropertyName);

                // Send messages if necessary

            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error occured while updating the owner for the property {PropertyName}.", property.PropertyName);
            }

            return updatedOwner;

            //throw new NotImplementedException();
        }

        private void getOwnerPropertyList(int id)
        {

        }
    }
}
