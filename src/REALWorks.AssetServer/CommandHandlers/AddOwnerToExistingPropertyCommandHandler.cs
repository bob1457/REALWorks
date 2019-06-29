using MediatR;
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
    public class AddOwnerToExistingPropertyCommandHandler : IRequestHandler<AddOwnerToExistingPropertyCommand, bool>
    {
        private readonly AppDataBaseContext _context;

        public AddOwnerToExistingPropertyCommandHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddOwnerToExistingPropertyCommand request, CancellationToken cancellationToken)
        {
            var property = _context.Property.FirstOrDefault(p => p.Id == request.PropertyId);

            if(request.PropertyOwnerId == 0)
            {
                var ownerAddress = new OwnerAddress(request.StreetNumber, request.City, request.StateProv, request.ZipPostCode, request.Country);

                var owner  = property.AddNewOwnerToProperty(request.PropertyId, request.UserName, request.FirstName, request.LastName, request.ContactEmail,
                    request.ContactTelephone1, request.ContactTelephone2, false, request.UserAvartaImgUrl, request.IsActive, 2, request.Notes, ownerAddress);

                _context.Add(owner);
            }
            else
            {
                var owner = _context.PropertyOwner.FirstOrDefault(o => o.Id == request.PropertyOwnerId);

                var ownerProperty = property.AddExistingOwnerToProperty(owner, request.PropertyId);

                _context.Add(ownerProperty);
            }

            
            try
            {
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


    }
}
