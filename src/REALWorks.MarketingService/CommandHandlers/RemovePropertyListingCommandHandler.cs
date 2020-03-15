using MediatR;
using REALWorks.MarketingData;
using REALWorks.MarketingService.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.CommandHandlers
{
    public class RemovePropertyListingCommandHandler : IRequestHandler<RemovePropertyListingCommand, Unit>
    {
        private readonly AppMarketingDbDataContext _context;

        public RemovePropertyListingCommandHandler(AppMarketingDbDataContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(RemovePropertyListingCommand request, CancellationToken cancellationToken)
        {
            var listing = _context.PropertyListing.FirstOrDefault(l => l.Id == request.Id);

            listing.DeActivate(listing);

            return await Unit.Task;
            //throw new NotImplementedException();
        }
    }
}
