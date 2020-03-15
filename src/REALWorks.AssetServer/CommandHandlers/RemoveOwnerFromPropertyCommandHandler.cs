using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWorks.AssetData;
using REALWorks.AssetServer.Commands;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.CommandHandlers
{
    public class RemoveOwnerFromPropertyCommandHandler : IRequestHandler<RemoveOwnerFromPropertyCommand, RemovePropertyOwnerCommandResult>
    {
        private readonly AppDataBaseContext _context;      

        public RemoveOwnerFromPropertyCommandHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<RemovePropertyOwnerCommandResult> Handle(RemoveOwnerFromPropertyCommand request, CancellationToken cancellationToken)
        {
            var numOfgOwners = _context.OwnerProperty.Where(p => p.PropertyId == request.PropertyId).Count();
            var property = _context.Property.FirstOrDefault(i => i.Id == request.PropertyId);

            var ownerToRemove = await _context.OwnerProperty.FirstAsync(o => o.PropertyOwnerId == request.PropertyOwnerId);

            if (numOfgOwners >= 2)
            {
                //var ownerToRemove = await _context.OwnerProperty.FirstAsync(o => o.PropertyOwnerId == request.PropertyOwnerId);

                _context.OwnerProperty.Remove(ownerToRemove);

                var removed = new RemovePropertyOwnerCommandResult();

                 try
                {
                    await _context.SaveChangesAsync();

                    removed.PropertyId = property.Id;
                    removed.PropertyOwnerId = request.PropertyOwnerId;

                    //return "Onwer has been removed from the property";

                    // logging
                    Log.Information("The owner {OwnerName} has been removed from the property {PorpertyName} has been added successfully", 
                        ownerToRemove.PropertyOwner.FirstName + " " + ownerToRemove.PropertyOwner.LastName, property.PropertyName);

                    // Send messages if necessary
                }
                catch (Exception ex)
                {
                    //throw ex;
                    Log.Error(ex, "Error occured while deleting the owner for the property {PropertyName}.", property.PropertyName);
                }

                //return "Owner has been removed from the proeprty specified!";
                return removed;
            }


            Log.Information("The owner {OwnerName} cannot removed from the property {PorpertyName} because this is the only owner",
                        ownerToRemove.PropertyOwner.FirstName + " " + ownerToRemove.PropertyOwner.LastName, property.PropertyName);

            //return "Onwer cannot be removed from the property!";
            return new RemovePropertyOwnerCommandResult() {};

        }
    }
}
