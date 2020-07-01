using MediatR;
using REALWorks.MarketingData;
using REALWorks.MarketingService.Commands;
using REALWorks.MarketingService.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.CommandHandlers
{
    public class AddImageToPropertyCommandHandler : IRequestHandler<AddImageToPropertyCommand, AddImageToPropertyViewModel>
    {
        private readonly AppMarketingDbDataContext _context;

        public AddImageToPropertyCommandHandler(AppMarketingDbDataContext context)
        {
            _context = context;
        }

        public async Task<AddImageToPropertyViewModel> Handle(AddImageToPropertyCommand request, CancellationToken cancellationToken)
        {
            var file = request.PropertyImage;

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\properties\\");
            string ext = Path.GetExtension(file.Name);
            string newFileName = "rental_property_" + request.RentalPropertyId.ToString() +  "." + ext;

            string url = "images/properties/" + file.FileName;

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

            var addedImage = new AddImageToPropertyViewModel();            

            var property = _context.RentalProperty.FirstOrDefault(p => p.Id == request.RentalPropertyId);

            var image = property.AddImages(request.PropertyImgTitle, url, request.RentalPropertyId);


            addedImage.PropertyImgUrl = image.PropertyImgUrl;            
            addedImage.PropertyImgTitle = image.PropertyImgTitle;
            addedImage.RentalPropertyId = image.RentalPropertyId;

            _context.Add(image);

            try
            {
                await _context.SaveChangesAsync();
                
                addedImage.Id = image.Id;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return addedImage;


        }
    }
}
