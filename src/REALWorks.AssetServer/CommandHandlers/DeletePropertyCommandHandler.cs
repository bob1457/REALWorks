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
    public class DeletePropertyCommandHandler : IRequestHandler<DeletePropertyCommand, bool>
    {
        private readonly AppDataBaseContext _context;

        public DeletePropertyCommandHandler(AppDataBaseContext context)
        {
            _context = context;
        }


        public async Task<bool> Handle(DeletePropertyCommand request, CancellationToken cancellationToken)
        {
            var property = _context.Property.FirstOrDefault(p => p.Id == request.PropertyId);

            property.Delete(property);

            try
            {
                await _context.SaveChangesAsync();

                // logging
                Log.Information("A management contract for the property {PorpertyName} has been added successfully", property.PropertyName);

                // Send messages if necessary
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;


        }
    }
}
