using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWorks.MarketingData;
using REALWorks.MarketingService.Commands;
using REALWorks.MarketingService.Events;
using REALWorks.MessagingServer.Messages;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static REALWorks.MarketingCore.Entities.RentalProperty;

namespace REALWorks.MarketingService.CommandHandlers
{
    public class PublishPropertyListingCommandHandler : IRequestHandler<PublishPropertyListingCommand, Unit>
    {
        private readonly AppMarketingDbDataContext _context;

        IMessagePublisher _messagePublisher;

        public PublishPropertyListingCommandHandler(AppMarketingDbDataContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        public async Task<Unit> Handle(PublishPropertyListingCommand request, CancellationToken cancellationToken)
        {
            var listing = _context.PropertyListing
                .Include(l => l.RentalProperty)
                .FirstOrDefault(l => l.Id == request.Id);

            listing.Publish(listing);

            // Update rental property status
            //
            string newStatus = "";

            ListingStatus status = (ListingStatus)Enum.Parse(typeof(ListingStatus), newStatus, true);

            listing.RentalProperty.StatusUpdate(status);

            try
            {
                await _context.SaveChangesAsync(); // comment out for testing message sending
            }
            catch (Exception ex)
            {

                throw;
            }
            // Send status chagne message to the message queue so that the Asset service can update the status of the property

            RentalPropertyStatusChangeEvent e = new RentalPropertyStatusChangeEvent(new Guid(), listing.RentalProperty.OriginalId, "Listed");

            try
            {
                await _messagePublisher.PublishMessageAsync(e.MessageType, e, "status_updated");

                Log.Information("Message  {MessageType} with Id {MessageId} has been published successfully", e.MessageType, e.MessageId);

            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error while handling {MessageType} message with id {MessageId}.", e.MessageType, e.MessageId);

            }

            return await Unit.Task;

            //throw new NotImplementedException();
        }
    }
}
