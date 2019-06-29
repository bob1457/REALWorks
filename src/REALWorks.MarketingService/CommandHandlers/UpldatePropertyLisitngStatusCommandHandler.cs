using MediatR;
using REALWorks.MarketingData;
using REALWorks.MarketingService.Commands;
using REALWorks.MarketingService.Events;
using REALWorks.MessagingServer.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.CommandHandlers
{
    public class UpldatePropertyLisitngStatusCommandHandler : IRequestHandler<UpldatePropertyLisitngStatusCommand, bool>
    {
        private readonly AppMarketingDbDataContext _context;

        IMessagePublisher _messagePublisher;

        public UpldatePropertyLisitngStatusCommandHandler(AppMarketingDbDataContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        public async Task<bool> Handle(UpldatePropertyLisitngStatusCommand request, CancellationToken cancellationToken)
        {

            var listing = _context.PropertyListing.FirstOrDefault(l => l.Id == request.Id);

            listing.StatusUpdate(listing, request.IsActive);

            _context.PropertyListing.Update(listing);

            int origId = 0;

            if(request.RentalPropertyStatus.ToString() != "NotSet")
            {
                var property = _context.RentalProperty.FirstOrDefault(p => p.Id == listing.RentalPropertyId);
                property.ListingStatusUpdate(property, request.RentalPropertyStatus);

                origId = property.OriginalId;

                _context.RentalProperty.Update(property);
            }

            try
            {
                await _context.SaveChangesAsync(); // comment out for testing message sending

                if (request.RentalPropertyStatus.ToString() == "Pending" || request.RentalPropertyStatus.ToString() == "Rented")
                {
                    // Send message to queue to update property status in Asset Service
                    //
                    RentalPropertyStatusChangeEvent e = new RentalPropertyStatusChangeEvent(Guid.NewGuid(), origId, request.RentalPropertyStatus.ToString());
                    await _messagePublisher.PublishMessageAsync(e.MessageType, e, "status_updated.*");
                }

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
