using MediatR;
using REALWorks.MarketingCore.ValueObjects;
using REALWorks.MarketingData;
using REALWorks.MarketingService.Commands;
using REALWorks.MessagingServer.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.CommandHandlers
{
    public class UpdatePropertyListingCommandHandler : IRequestHandler<UpdatePropertyListingCommand, bool>
    {
        private readonly AppMarketingDbDataContext _context;

        IMessagePublisher _messagePublisher;

        public UpdatePropertyListingCommandHandler(AppMarketingDbDataContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        public async Task<bool> Handle(UpdatePropertyListingCommand request, CancellationToken cancellationToken)
        {
            var listing = _context.PropertyListing.FirstOrDefault(i => i.Id == request.PropertyListingId);

            var contact = new ListingContact(request.ContactName, request.ContactTel, 
                request.ContactEmail, request.ContactSMS, request.ContactOthers);            

            var updated = listing.Update(listing, request.Title, request.ListingDesc, contact, request.MonthlyRent, request.Notes, DateTime.Now);

            _context.PropertyListing.Update(updated);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;

            //throw new NotImplementedException();
        }
    }
}
