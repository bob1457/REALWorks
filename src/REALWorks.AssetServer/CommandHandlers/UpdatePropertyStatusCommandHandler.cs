using MediatR;
using REALWorks.AssetData;
using REALWorks.AssetServer.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.CommandHandlers
{
    public class UpdatePropertyStatusCommandHandler : IRequestHandler<UpdatePropertyStatusCommand, bool>
    {
        private readonly AppDataBaseContext _context;

        public UpdatePropertyStatusCommandHandler(AppDataBaseContext context)
        {
            _context = context;
        }


        public async Task<bool> Handle(UpdatePropertyStatusCommand request, CancellationToken cancellationToken)
        {

            var property = _context.Property.FirstOrDefault(p => p.Id == request.Id);

            property.StatusUpdate(property, request.Status);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;

        }
    }
}
