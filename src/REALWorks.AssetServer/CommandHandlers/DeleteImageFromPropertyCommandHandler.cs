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

            int start = image.PropertyImgUrl.LastIndexOf("/");

            string fileName = image.PropertyImgUrl.Substring(start + 1);

            _context.PropertyImg.Remove(image);

            try
            {
                await _context.SaveChangesAsync();
               
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Remove the image file from file system

            string fileToBeDeleted = 
                
            return true;


            //throw new NotImplementedException();
        }
    }
}
