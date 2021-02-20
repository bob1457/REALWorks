using MediatR;
using REALWorks.MarketingData;
using REALWorks.MarketingService.Commands;
using REALWorks.MarketingService.Events;
using REALWorks.MarketingService.ViewModels;
using REALWorks.MessagingServer.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.CommandHandlers
{
    public class UpldatePropertyLisitngStatusCommandHandler : IRequestHandler<UpldatePropertyLisitngStatusCommand, PropertyListingUpdateViewModel>
    {
        private readonly AppMarketingDbDataContext _context;

        IMessagePublisher _messagePublisher;

        public UpldatePropertyLisitngStatusCommandHandler(AppMarketingDbDataContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        public async Task<PropertyListingUpdateViewModel> Handle(UpldatePropertyLisitngStatusCommand request, CancellationToken cancellationToken) // This only update the isActive attribute
        {

            var listing = _context.PropertyListing.FirstOrDefault(l => l.Id == request.Id);

            var updated = listing.StatusUpdate(listing, request.IsActive);
            

            _context.PropertyListing.Update(updated);

            int origId = 0;

            if(request.RentalPropertyStatus.ToString() != "New")
            {
                var property = _context.RentalProperty.FirstOrDefault(p => p.Id == listing.RentalPropertyId);
                property.ListingStatusUpdate(property, request.RentalPropertyStatus);

                origId = property.OriginalId;

                _context.RentalProperty.Update(property);
            }

            var updatedList = new PropertyListingUpdateViewModel();

            updatedList.Id = updated.Id;
            updatedList.RentalPropertyId = updated.RentalPropertyId;
            updatedList.Title = updated.Title;
            updatedList.ListingDesc = updated.ListingDesc;
            updatedList.MonthlyRent = updated.MonthlyRent;
            updatedList.Note = updated.Note;
            updatedList.IsActive = updated.IsActive;
            updatedList.ContactName = updated.Contact.ContactName;
            updatedList.ContactEmail = updated.Contact.ContactEmail;
            updatedList.ContactTel = updated.Contact.ContactTel;
            updatedList.ContactSMS = updated.Contact.ContactSMS;
            updatedList.ContactOthers = updated.Contact.ContactOthers;
            updatedList.Created = updated.Created;
            updatedList.Modified = updated.Modified;

            updatedList.RentalProperty = listing.RentalProperty;

            //updatedList.Contact = contact;

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

            
            return updatedList;

            //throw new NotImplementedException();
        }
    }
}
