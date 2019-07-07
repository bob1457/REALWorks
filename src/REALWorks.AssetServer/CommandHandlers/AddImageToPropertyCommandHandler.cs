using MediatR;
using REALWorks.AssetCore.Entities;
using REALWorks.AssetData;
using REALWorks.AssetServer.Commands;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.AssetServer.CommandHandlers
{
    public class AddImageToPropertyCommandHandler : IRequestHandler<AddImageToPropertyCommand, bool>
    {
        private readonly AppDataBaseContext _context;

        public AddImageToPropertyCommandHandler(AppDataBaseContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddImageToPropertyCommand request, CancellationToken cancellationToken)
        {
            var file = request.PropertyImage;

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\");
            string url = "images/" + file.FileName;

            if (file.Length > 0)
            {
                using (var fileStream = new FileStream(Path.Combine(path, file.FileName), FileMode.Create))
                {
                    try
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }

                }
            }

            var property = _context.Property.FirstOrDefault(p => p.Id == request.PropertyId);

            var image = property.AddImages(request.PropertyImgTitle, url, request.PropertyId);


            _context.Add(image);

            try
            {
                await _context.SaveChangesAsync();

                // logging
                Log.Information("An image for the property {PorpertyName} has been added successfully", property.PropertyName);

                // Send messages if necessary

            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error occured while adding image to the property {PropertyName}.", property.PropertyName);
            }

            return true;


        }
    }
}
