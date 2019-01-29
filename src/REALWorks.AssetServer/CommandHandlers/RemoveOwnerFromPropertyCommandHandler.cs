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
    public class RemoveOwnerFromPropertyCommandHandler : IRequestHandler<RemoveOwnerFromPropertyCommand, string>
    {
        private readonly AppDataBaseContext _context;      

        public RemoveOwnerFromPropertyCommandHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(RemoveOwnerFromPropertyCommand request, CancellationToken cancellationToken)
        {
            var numOfgOwners = _context.OwnerProperty.Where(p => p.PropertyId == request.PropertyId).Count();           

            if (numOfgOwners >= 2)
            {
                var ownerToRemove = await _context.OwnerProperty.FirstAsync(o => o.PropertyOwnerId == request.PropertyOwnerId);

                _context.OwnerProperty.Remove(ownerToRemove);

                 try
                {
                    await _context.SaveChangesAsync();

                    return "Onwer has been removed from the property";
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }           

            return "Onwer cannot be removed from the property";

        }
    }
}
