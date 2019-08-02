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
    public class UpdatePropertyStatusCommandHandler : IRequestHandler<UpdatePropertyStatusCommand, UpdatePropertyStatusCommandResult>
    {
        private readonly AppDataBaseContext _context;

        public UpdatePropertyStatusCommandHandler(AppDataBaseContext context)
        {
            _context = context;
        }


        public async Task<UpdatePropertyStatusCommandResult> Handle(UpdatePropertyStatusCommand request, CancellationToken cancellationToken)
        {

            var property = _context.Property.FirstOrDefault(p => p.Id == request.Id);

            var updatedStatus = new UpdatePropertyStatusCommandResult();

            updatedStatus.Id = request.Id;
            updatedStatus.Status = request.Status;

            //property.StatusUpdate(property, request.Status);
            property.StatusUpdate(request.Status);

            try
            {
                await _context.SaveChangesAsync();

                // logging
                Log.Information("The status of the property {PorpertyName} has been updated to {Status} successfully", property.PropertyName, request.Status);

                // Send messages if necessary
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return updatedStatus;

        }
    }
}
