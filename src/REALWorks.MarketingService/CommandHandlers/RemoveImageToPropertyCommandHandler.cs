using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWorks.MarketingData;
using REALWorks.MarketingService.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.CommandHandlers
{
    public class RemoveImageToPropertyCommandHandler : IRequestHandler<RemoveImageToPropertyCommand, Unit>
    {
        private readonly AppMarketingDbDataContext _context;        

        public RemoveImageToPropertyCommandHandler(AppMarketingDbDataContext context)
        {
            _context = context;           
        }

        public async Task<Unit> Handle(RemoveImageToPropertyCommand request, CancellationToken cancellationToken)
        {
            var rentalListing = _context.PropertyListing
                //.Include(p => p.RentalProperty)
                .FirstOrDefault(l => l.Id == request.Id);

            var imgToRemove = _context.PropertyImg.FirstOrDefault(p => p.RentalPropertyId == rentalListing.RentalPropertyId);

            _context.PropertyImg.Remove(imgToRemove);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            throw new NotImplementedException();
        }
    }
}
