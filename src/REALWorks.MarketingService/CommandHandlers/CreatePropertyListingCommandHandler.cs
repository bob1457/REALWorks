using MediatR;
using REALWorks.MarketingCore.Entities;
using REALWorks.MarketingCore.ValueObjects;
using REALWorks.MarketingData;
using REALWorks.MarketingService.Commands;
using REALWorks.MarketingService.ViewModels;
using REALWorks.MessagingServer.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWorks.MarketingService.CommandHandlers
{
    public class CreatePropertyListingCommandHandler : IRequestHandler<CreatePropertyListingCommand, PropertyListingListViewModel>
    {
        private readonly AppMarketingDbDataContext _context;

        IMessagePublisher _messagePublisher;

        public CreatePropertyListingCommandHandler(AppMarketingDbDataContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        public async Task<PropertyListingListViewModel> Handle(CreatePropertyListingCommand request, CancellationToken cancellationToken)
        {
            var contact = new ListingContact(request.ContactName, request.ContactTel, 
                request.ContactEmail, request.ContactSMS, request.ContactOthers);

            //var listedProperty = _context.RentalProperty.FirstOrDefault(p => p.Id == request.RentalPropertyId);

            var listing = new PropertyListing(request.Title, request.ListingDesc, contact,  request.RentalPropertyId, false,
                request.MonthlyRent, request.Notes,
                DateTime.Now, DateTime.Now);

            var listingProeprty = _context.RentalProperty.FirstOrDefault(p => p.Id == request.RentalPropertyId);

            await _context.AddAsync(listing);

            var addedListing = new PropertyListingListViewModel();

            addedListing.Title = request.Title;
            addedListing.ListingDesc = request.ListingDesc;
            addedListing.MonthlyRent = request.MonthlyRent;
            addedListing.ListingNote = request.Notes;
            addedListing.IsActive = true;
            addedListing.PropertyName = listingProeprty.PropertyName;
            addedListing.PropertyType = listingProeprty.PropertyType;
            addedListing.PropertyBuildYear = listingProeprty.PropertyBuildYear;
            addedListing.IsShared = listingProeprty.IsShared;
            addedListing.IsBasementSuite = listingProeprty.IsBasementSuite;

            try
            {
                await _context.SaveChangesAsync();

                // Send message to message queue

            }
            catch (Exception ex)
            {
                throw ex;
            }

            
            return addedListing;

            //throw new NotImplementedException();
        }
    }
}
