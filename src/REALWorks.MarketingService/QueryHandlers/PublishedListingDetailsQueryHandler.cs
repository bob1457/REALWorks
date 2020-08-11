using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWorks.MarketingCore.Entities;
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
    public class PublishedListingDetailsQueryHandler : IRequestHandler<PublishedListingDetailsQuery, PublishedListingListViewModel>
    {
        private readonly AppMarketingDbDataContext _context;

        public PublishedListingDetailsQueryHandler(AppMarketingDbDataContext context)
        {
            _context = context;
        }   

        public async Task<PublishedListingListViewModel> Handle(PublishedListingDetailsQuery request, CancellationToken cancellationToken)
        {
            var listing = _context.PropertyListing
                            .Include(c => c.Contact)
                            //.Include(l => l.RentalProperty)
                            //.ThenInclude(p => p.OpenHouse).ToList()
                            .Include(l => l.RentalProperty)                            
                            .ThenInclude(i => i.PropertyImg).ToList()
                            .Where(p => p.IsActive == true)
                            .Select(i => new PublishedListingListViewModel 
                            {
                                ListingDesc = i.ListingDesc,
                                Title = i.Title,

                                PropertyImages = i.RentalProperty.PropertyImg.ToList(),
                                OpenHouseDetails = i.RentalProperty.OpenHouse.First(o => o.RentalPropertyId == i.RentalProperty.Id)


                            });



            return listing.FirstOrDefault(l => l.Id == request.Id);

            //throw new NotImplementedException();
        }
    }
}
