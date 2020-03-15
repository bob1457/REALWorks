using MediatR;
using REALWorks.MarketingData;
using REALWorks.MarketingService.Queries;
using REALWorks.MarketingService.ViewModels;
using REALWorks.MessagingServer.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.QueryHandlers
{
    public class PropertyListingListQueryHandler : IRequestHandler<PropertyListingListQuery, IQueryable<PropertyListingListViewModel>>
    {
        private readonly AppMarketingDbDataContext _context;

        public PropertyListingListQueryHandler(AppMarketingDbDataContext context)
        {
            _context = context;            
        }

        public async Task<IQueryable<PropertyListingListViewModel>> Handle(PropertyListingListQuery request, CancellationToken cancellationToken)
        {
            var list = ( from l in _context.PropertyListing
                         join p in _context.RentalProperty on l.RentalPropertyId equals p.Id

                         select new PropertyListingListViewModel
                         {
                             Title = l.Title,
                             ListingDesc = l.ListingDesc,
                             MonthlyRent = l.MonthlyRent,
                             IsActive = l.IsActive,
                             RentalPropertyId = p.Id,
                             PropertyName = p.PropertyName,
                             PropertyType = p.PropertyType,
                             PropertyBuildYear = p.PropertyBuildYear,
                             IsBasementSuite = p.IsBasementSuite,
                             ListingNote = l.Note
                         }).AsQueryable();

            return list;

            //throw new NotImplementedException();
        }
    }
}
