using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWorks.MarketingCore.Entities;
using REALWorks.MarketingData;
using REALWorks.MarketingService.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.QueryHandlers
{
    public class PublishedListingDetailsQueryHandler : IRequestHandler<PublishedListingDetailsQuery, PropertyListing>
    {
        private readonly AppMarketingDbDataContext _context;

        public PublishedListingDetailsQueryHandler(AppMarketingDbDataContext context)
        {
        }   

        public async Task<PropertyListing> Handle(PublishedListingDetailsQuery request, CancellationToken cancellationToken)
        {
            var listing = _context.PropertyListing
                            .Include(c => c.Contact)
                            .Include(p => p.RentalProperty)
                            .ThenInclude(i => i.PropertyImg).ToList()
                            .Where(p => p.IsActive == true);



            return listing.FirstOrDefault(l => l.Id == request.Id);

            //throw new NotImplementedException();
        }
    }
}
