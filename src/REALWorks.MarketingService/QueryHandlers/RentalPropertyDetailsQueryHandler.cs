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
    public class RentalPropertyDetailsQueryHandler : IRequestHandler<RentalPropertyDetailsQuery, RentalProperty>
    {
        private readonly AppMarketingDbDataContext _context;

        public RentalPropertyDetailsQueryHandler(AppMarketingDbDataContext context)
        {
            _context = context;
        }

        public async Task<RentalProperty> Handle(RentalPropertyDetailsQuery request, CancellationToken cancellationToken)
        {
            var property = _context.RentalProperty
                .Include(a => a.Address).First(p => p.Id == request.Id);
            //.Include(o => o.OpenHouse).ToList();

            //var openHouse = _context.OpenHouse.First();

            _context.Entry(property).Collection(o => o.OpenHouse ).Load();

            foreach (var oh in property.OpenHouse )
            {
                _context.Entry(oh).Collection(v => v.OpenHouseViewer).Load();
            }

            return property;

            //throw new NotImplementedException();
        }
    }
}
