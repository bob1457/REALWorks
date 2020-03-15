using MediatR;
using REALWorks.MarketingData;
using REALWorks.MarketingService.Commands;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.CommandHandlers
{
    public class AddImageToPropertyCommandHandler : IRequestHandler<AddImageToPropertyCommand, bool>
    {
        private readonly AppMarketingDbDataContext _context;

        public AddImageToPropertyCommandHandler(AppMarketingDbDataContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddImageToPropertyCommand request, CancellationToken cancellationToken)
        {
            var file = request.PropertyImage;

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Avatars\\");
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

            var property = _context.RentalProperty.FirstOrDefault(p => p.Id == request.RentalPropertyId);

            var image = property.AddImages(request.PropertyImgTitle, url, request.RentalPropertyId);


            _context.Add(image);

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
