using MediatR;
using Microsoft.AspNetCore.Hosting;
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
    public class DeleteImageFromPropertyCommandHandler : IRequestHandler<DeleteImageFromPropertyCommand, bool>
    {
        private readonly AppDataBaseContext _context;      
        private readonly IHostingEnvironment _hostingEnvironment;

        public DeleteImageFromPropertyCommandHandler(AppDataBaseContext context, IHostingEnvironment hostingEnvironment )
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<bool> Handle(DeleteImageFromPropertyCommand request, CancellationToken cancellationToken)
        {
            string filePath = _hostingEnvironment.WebRootPath + "\\images";

            var image = _context.PropertyImg.FirstOrDefault(i => i.Id == request.Id);

            int start = image.PropertyImgUrl.LastIndexOf("/");

            string fileName = image.PropertyImgUrl.Substring(start + 1);

            _context.PropertyImg.Remove(image);

            try
            {
                await _context.SaveChangesAsync();

                // logging
                Log.Information("The image for the property {PorpertyName} has been deleted/ successfully", image.Property.PropertyName);

                // Send messages if necessary

            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error occured while deleting the image for the property {PropertyName}.", image.Property.PropertyName);
            }

            string fileToBeDeleted = filePath + "\\" + fileName;

            System.IO.File.Delete(fileToBeDeleted);
                 
            return true;


        }
    }
}
