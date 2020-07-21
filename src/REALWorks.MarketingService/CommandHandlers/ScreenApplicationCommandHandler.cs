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
    public class ScreenApplicationCommandHandler : IRequestHandler<ScreenApplicationCommand, string>
    {
        private readonly AppMarketingDbDataContext _context;

        public ScreenApplicationCommandHandler(AppMarketingDbDataContext context)
        {
            _context = context;
        }
        public Task<string> Handle(ScreenApplicationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
