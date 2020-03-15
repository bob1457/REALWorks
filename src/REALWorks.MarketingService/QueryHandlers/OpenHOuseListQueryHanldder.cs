using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWorks.MarketingCore.Entities;
using REALWorks.MarketingData;
using REALWorks.MarketingService.Queries;
using REALWorks.MessagingServer.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.QueryHandlers
{
    public class OpenHOuseListQueryHanldder : IRequestHandler<OpenHOuseListQuery, IQueryable<OpenHouse>>
    {
        private readonly AppMarketingDbDataContext _context;

        IMessagePublisher _messagePublisher;

        public OpenHOuseListQueryHanldder(AppMarketingDbDataContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        public async Task<IQueryable<OpenHouse>> Handle(OpenHOuseListQuery request, CancellationToken cancellationToken)
        {
            var openHouseList = _context.OpenHouse.Include(p => p.RentalProperty).AsQueryable();

            return openHouseList;

            //throw new NotImplementedException();
        }
    }
}
