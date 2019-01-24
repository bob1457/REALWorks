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
    public class DeleteImageFromPropertyCommandHandler : IRequestHandler<DeleteImageFromPropertyCommand, bool>
    {
        private readonly AppDataBaseContext _context; // Inject db context for persisitence

        public DeleteImageFromPropertyCommandHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(DeleteImageFromPropertyCommand request, CancellationToken cancellationToken)
        {
            var image = _context.PropertyImg.FirstOrDefault(i => i.Id == request.Id);

            _context.PropertyImg.Remove(image);

            try
            {
                await _context.SaveChangesAsync();

                // Remove the image file from file system


                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //throw new NotImplementedException();
        }
    }
}
