using MediatR;
using REALWorks.MarketingCore.Entities;
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
    public class CreatePropertyListingCommandHandler : IRequestHandler<CreatePropertyListingCommand, bool>
    {
        private readonly AppMarketingDbDataContext _context;

        IMessagePublisher _messagePublisher;

        public CreatePropertyListingCommandHandler(AppMarketingDbDataContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        public async Task<bool> Handle(CreatePropertyListingCommand request, CancellationToken cancellationToken)
        {
            var contact = new ListingContact(request.ContactName, request.ContactTel, 
                request.ContactEmail, request.ContactSMS, request.ContactOthers);

            //var listedProperty = _context.RentalProperty.FirstOrDefault(p => p.Id == request.RentalPropertyId);

            var listing = new PropertyListing(request.Title, request.ListingDesc, contact,  request.RentalPropertyId, false,
                request.MonthlyRent, request.Notes,
                DateTime.Now, DateTime.Now);

            await _context.AddAsync(listing);

            try
            {
                await _context.SaveChangesAsync();

                // Send message to message queue

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
