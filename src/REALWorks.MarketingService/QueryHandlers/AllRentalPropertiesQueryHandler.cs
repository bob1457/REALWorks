using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class AllRentalPropertiesQueryHandler : IRequestHandler<AllRentalPropertiesQuery, IQueryable<AllRenatlPropertiesViewModel>>
    {
        private readonly AppMarketingDbDataContext _context;

        public AllRentalPropertiesQueryHandler(AppMarketingDbDataContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<AllRenatlPropertiesViewModel>> Handle(AllRentalPropertiesQuery request, CancellationToken cancellationToken)
        {
            var properties = (from p in _context.RentalProperty.Include(a => a.Address)
                              //where p.Status.ToString() == "NotSet"
                              select new AllRenatlPropertiesViewModel
                              {
                                  Id = p.Id,
                                  PropertyName = p.PropertyName,
                                  Status = p.Status

                                  // more attributes as needed
                              });

            return properties;

            //throw new NotImplementedException();
        }
    }
}
