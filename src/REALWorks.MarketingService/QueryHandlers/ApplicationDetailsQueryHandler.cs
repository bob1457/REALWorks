using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWorks.MarketingCore.Entities;
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
    public class ApplicationDetailsQueryHandler : IRequestHandler<ApplicationDetailsQuery, RentalApplication>
    {
        private readonly AppMarketingDbDataContext _context;        

        public ApplicationDetailsQueryHandler(AppMarketingDbDataContext context)
        {
            _context = context;            
        }

        public async Task<RentalApplication> Handle(ApplicationDetailsQuery request, CancellationToken cancellationToken)
        {
            var application = _context.RentalApplication
                .Include(a => a.RentalApplicant)
                .Include(p => p.RentalProperty);

            return application.FirstOrDefault(i => i.Id == request.Id);

            //throw new NotImplementedException();
        }
    }
}
