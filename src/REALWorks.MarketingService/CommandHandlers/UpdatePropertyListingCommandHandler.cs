using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class UpdatePropertyListingCommandHandler : IRequestHandler<UpdatePropertyListingCommand, PropertyListingUpdateViewModel>
    {
        private readonly AppMarketingDbDataContext _context;

        IMessagePublisher _messagePublisher;

        public UpdatePropertyListingCommandHandler(AppMarketingDbDataContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        public async Task<PropertyListingUpdateViewModel> Handle(UpdatePropertyListingCommand request, CancellationToken cancellationToken)
        {
            var listing = _context.PropertyListing.Include(r => r.RentalProperty).FirstOrDefault(i => i.Id == request.Id);
//.ThenInclude(m => m.PropertyImg.ToList())
            var contact = new ListingContact(request.ContactName, request.ContactTel, 
                request.ContactEmail, request.ContactSMS, request.ContactOthers);

            var allImgs = _context.PropertyImg; // Get all property images


            var updated = listing.Update(listing, request.Title, request.ListingDesc, contact, request.MonthlyRent, request.Note, DateTime.Now);

            _context.PropertyListing.Update(updated);

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

            updatedList.Contact = contact;

            //updatedList.PropertyImgs = allImgs.ToList();

            try
            {
                await _context.SaveChangesAsync();
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
