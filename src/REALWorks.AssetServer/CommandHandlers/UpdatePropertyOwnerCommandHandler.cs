using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWorks.AssetData;
using REALWorks.AssetServer.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.CommandHandlers
{
    public class UpdatePropertyOwnerCommandHandler : IRequestHandler<UpdatePropertyOwnerCommand, bool>
    {
        private readonly AppDataBaseContext _context;

        public UpdatePropertyOwnerCommandHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdatePropertyOwnerCommand request, CancellationToken cancellationToken)
        {
            var owner = _context.PropertyOwner.Include(op => op.OwnerProperty).ThenInclude(p => p.Property)
                .FirstOrDefault(o => o.Id == request.PropertyOwnerId);

            var property = owner.OwnerProperty.FirstOrDefault().Property;

            var updated = property.UpdateOwner(owner, request.FirstName, request.LastName, request.ContactEmail, request.ContactTelephone1,
                request.ContactTelephone2, request.UserAvartaImgUrl, request.IsActive, request.Notes);

            //var updated = owner.Update(owner, request.FirstName, request.LastName, request.ContactEmail, request.ContactTelephone1, 
            //    request.ContactTelephone2, request.UserAvartaImgUrl, request.IsActive, request.Notes);


            _context.Update(updated);

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
