using MediatR;
using REALWorks.MarketingData;
using REALWorks.MarketingService.Queries;
using REALWorks.MarketingService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.QueryHandlers
{
    public class AllPropertyImagesListQueryHandler : IRequestHandler<AllPropertyImagesListQuery, IQueryable<AddImageToPropertyViewModel>>
    {
        private readonly AppMarketingDbDataContext _context;

        public AllPropertyImagesListQueryHandler(AppMarketingDbDataContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<AddImageToPropertyViewModel>> Handle(AllPropertyImagesListQuery request, CancellationToken cancellationToken)
        {
            //var images = _context.PropertyImg.AsQueryable();

            //var returnedImg = new AddImageToPropertyViewModel();

            var list = (from i in _context.PropertyImg
                        join p in _context.RentalProperty on i.RentalPropertyId equals p.Id
                        select new AddImageToPropertyViewModel
                        {
                            Id = i.Id,
                            OriginalId = p.OriginalId,
                            PropertyImgUrl = i.PropertyImgUrl,
                            PropertyImgTitle = i.PropertyImgTitle,
                            RentalPropertyId = i.RentalPropertyId
                        });

            return list.AsQueryable();
           
            //throw new NotImplementedException();
        }
    }
}
