using MediatR;
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
    public class AssignPMtoPropertyCommandHandler : IRequestHandler<AssignPMtoPropertyCommand, string>
    {
        private readonly AppDataBaseContext _context;

        public AssignPMtoPropertyCommandHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<string> Handle(AssignPMtoPropertyCommand request, CancellationToken cancellationToken)
        {
            var property = _context.Property.FirstOrDefault(p => p.Id == request.PropertyId);

            property.AsssignPropertyManager(property, request.PmUserName);

            try
            {
                await _context.SaveChangesAsync();


                // logging
                Log.Information("The property manager {ManagerName} has been added to the property {PorpertyName} as been added successfully", request.PmUserName, property.PropertyName);

                // Send messages if necessary
            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error occured while adding property manager to the property {PropertyName}.", property.PropertyName);
            }

            return "Property manager assigned!";

        }
    }
}
