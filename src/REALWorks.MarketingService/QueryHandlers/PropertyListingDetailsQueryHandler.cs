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
    public class PropertyListingDetailsQueryHandler : IRequestHandler<PropertyListingDetailsQuery, PropertyListing>
    {
        private readonly AppMarketingDbDataContext _context;       

        public PropertyListingDetailsQueryHandler(AppMarketingDbDataContext context)
        {
            _context = context;
           
        }

        public async Task<PropertyListing> Handle(PropertyListingDetailsQuery request, CancellationToken cancellationToken)
        {
            var listing = _context.PropertyListing
                .Include(c => c.Contact)
                .Include(p => p.RentalProperty)                
                .ThenInclude(a => a.Address)
                //.Include(rp => rp.RentalProperty).ThenInclude(p => p.OpenHouse).ThenInclude(o => o.OpenHouseViewer) // use a separate query to get open house data
                .Include(rp => rp.RentalProperty)
                .ThenInclude(i => i.PropertyImg).ToList()
                //.Include(c => c.Contact)
                ;

            return listing.FirstOrDefault(r => r.Id == request.Id);

            //throw new NotImplementedException();
        }
    }
}
