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
using static REALWorks.MarketingCore.Entities.RentalProperty;
using REALWorks.MarketingService.Events;
using Serilog;

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

        /// <summary>
        /// This update listing process only catches published/listed event so that Asset microservice can upate the property status from "UnSet" to "Vacant" or vice verser
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<PropertyListingUpdateViewModel> Handle(UpdatePropertyListingCommand request, CancellationToken cancellationToken)
        {
            var listing = _context.PropertyListing.Include(r => r.RentalProperty).FirstOrDefault(i => i.Id == request.Id);
//.ThenInclude(m => m.PropertyImg.ToList())
            var contact = new ListingContact(request.ContactName, request.ContactTel, 
                request.ContactEmail, request.ContactSMS, request.ContactOthers);

            var allImgs = _context.PropertyImg; // Get all property images

            var rentalProperty = listing.RentalProperty;


            var updated = listing.Update(listing, request.Title, request.ListingDesc, contact, request.MonthlyRent, request.isActive, request.Note, DateTime.Now);

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

            // Update rental property status

            ListingStatus status;

            if (request.isActive == true)
            {
                status = (ListingStatus)Enum.Parse(typeof(ListingStatus), "Listed");                
            }
            else
            {
                status = (ListingStatus)Enum.Parse(typeof(ListingStatus), "NotSet");
            }

            rentalProperty.StatusUpdate(status);

            try
            {
                await _context.SaveChangesAsync();

                // Only send message to the message queue for status change, i.e. isActive from true to false or vice versa
                if(listing.IsActive != request.isActive)
                {
                    RentalPropertyStatusChangeEvent e = new RentalPropertyStatusChangeEvent(new Guid(), listing.RentalProperty.OriginalId, status.ToString());

                    try
                    {
                        await _messagePublisher.PublishMessageAsync(e.MessageType, e, "status_updated"); // publishing the message
                        Log.Information("Message  {MessageType} with Id {MessageId} has been published successfully: Proeprty status change.", e.MessageType, e.MessageId);
                    }
                    catch (Exception ex)
                    {
                        Log.Error(ex, "Error while publishing {MessageType} message with id {MessageId}. Proeprty status change.", e.MessageType, e.MessageId);

                        throw ex;
                    }
                }

                

            }
            catch (Exception ex)
            {
                Log.Information("Error {Message} saving to database!", ex.Message);
                throw ex;
            }

            return updatedList;

            //throw new NotImplementedException();
        }
    }
}
