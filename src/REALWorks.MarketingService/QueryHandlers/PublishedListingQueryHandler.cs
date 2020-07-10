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
    public class PublishedListingQueryHandler : IRequestHandler<PublishedListingQuery,IQueryable<PropertyListing>>
    {
        private readonly AppMarketingDbDataContext _context;

        public PublishedListingQueryHandler(AppMarketingDbDataContext context)
        {
            _context = context;            
        }
        public async Task<IQueryable<PropertyListing>> Handle(PublishedListingQuery request, CancellationToken cancellationToken)
        {
            //var listing = (from l in _context.PropertyListing
            //               .Include(p => p.RentalProperty)
            //               .ThenInclude(i => i.PropertyImg).ToList()
            //                   //join p in _context.RentalProperty on l.RentalPropertyId equals p.Id
            //                   //join i in _context.PropertyImg on p.Id equals i.RentalPropertyId
            //               where l.IsActive == true
            //               select new PublishedListingListViewModel
            //               {
            //                   Id = l.Id,
            //                   ListingDesc = l.ListingDesc,
            //                   MonthlyRent = l.MonthlyRent



            //               }).AsQueryable();

            var listing = _context.PropertyListing
                            .Include(c => c.Contact)
                            .Include(p => p.RentalProperty)
                            .ThenInclude(i => i.PropertyImg).ToList()
                            .Where(p => p.IsActive == true)
                            .AsQueryable();
                           
                           

            return listing;

            //throw new NotImplementedException();
        }
    }
}
