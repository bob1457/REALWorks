using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWorks.MarketingCore.ValueObjects;
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
    public class ApproveApplicationCommandHandler : IRequestHandler<ApproveApplicationCommand>
    {
        private readonly AppMarketingDbDataContext _context;

        IMessagePublisher _messagePublisher;

        public ApproveApplicationCommandHandler(AppMarketingDbDataContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        public async Task<Unit> Handle(ApproveApplicationCommand request, CancellationToken cancellationToken)
        {
            //throw new NotImplementedException();

            var application = _context.RentalApplication
                .Include(p => p.RentalProperty)
                //.ThenInclude(l => l.PropertyListing)
                .FirstOrDefault(a => a.Id == request.ApplicationId);

            //application.StatusUpdate(application, request.AppStatus);
            
            // Get related rental property
            var rentalProperty = application.RentalProperty;
            //Get the related listing for this rental property
            var listing = _context.PropertyListing.FirstAsync(l => l.RentalPropertyId == rentalProperty.Id);
            
            


            //var rentalProperty = _context.RentalProperty.Include(l => l.PropertyListing).FirstOrDefault(p => p.Id == application.RentalPropertyId); // Get related rental property
            //var rentalProperty = application.RentalProperty;                       

            ////Get the related listing for this rental property
            //var listing = _context.PropertyListing.FirstAsync(l => l.RentalPropertyId == rentalProperty.Id);

            
            // Update applicaiton status
            //
            application.StatusUpdate(application, request.AppStatus);

            // Update listing/rental property status
            //
            ListingStatus status = (ListingStatus)Enum.Parse(typeof(ListingStatus), "Pending");

            rentalProperty.StatusUpdate(status);

            _context.RentalApplication.Update(application);

            try
            {
                await _context.SaveChangesAsync(); // comment out for testing message sending
            }
            catch (Exception ex)
            {
                throw ex;
            }


            // Send message to message queue on conditions
            //
            if (request.AppStatus.ToString() == "Approved")
            {
                
                NewTemantCreatedEvent e = new NewTemantCreatedEvent(new Guid(), "NotSet", request.FirstName, request.LastName, request.ContactEmail, 
                    request.ContactTelephone1, request.ContactTelephone2, request.ContactOthers);

                //var rentalproperty = _context.RentalProperty.Include(a => a.Address).FirstOrDefault(a => a.Id == application.RentalPropertyId); // Get related rental property

                //var address = new Address(request.);

                /*
                //if (rentalProperty == null) // check if the rental property exists, if not create it
                //{
                RentalPropertyCreatedEvent e2 = new RentalPropertyCreatedEvent(new Guid(), rentalProperty.OriginalId, 0, rentalProperty.PropertyName, rentalProperty.PmUserName, rentalProperty.PropertyBuildYear,
                   rentalProperty.PropertyType, rentalProperty.IsBasementSuite, rentalProperty.IsShared, rentalProperty.NumberOfBedrooms, rentalProperty.NumberOfBathrooms, rentalProperty.NumberOfLayers,
                   rentalProperty.NumberOfParking, rentalProperty.TotalLivingArea, rentalProperty.Address.StreetNum, rentalProperty.Address.City, rentalProperty.Address.StateProvince, 
                   rentalProperty.Address.Country, rentalProperty.Address.ZipPostCode);

                //await _messagePublisher.PublishMessageAsync(e2.MessageType, e2, "rental_created.*");
                //await _messagePublisher.PublishMessageAsync(e2.MessageType, e2, "app_approved"); // this event does not need to triggered, all combined as the following one!
                //}
*/
                RentalAppApprovedEvent e3 = new RentalAppApprovedEvent(Guid.NewGuid(), "NotSet", request.FirstName, request.LastName, request.ContactEmail,
                    request.ContactTelephone1, request.ContactTelephone2, request.ContactOthers, rentalProperty.OriginalId, listing.Id, rentalProperty.PropertyName, rentalProperty.PmUserName, rentalProperty.PropertyBuildYear,
                   rentalProperty.PropertyType, rentalProperty.IsBasementSuite, rentalProperty.IsShared, rentalProperty.NumberOfBedrooms, rentalProperty.NumberOfBathrooms, rentalProperty.NumberOfLayers,
                   rentalProperty.NumberOfParking, rentalProperty.TotalLivingArea, rentalProperty.Address.StreetNum, rentalProperty.Address.City, rentalProperty.Address.StateProvince,
                   rentalProperty.Address.Country, rentalProperty.Address.ZipPostCode);

                try
                {
                    await _messagePublisher.PublishMessageAsync(e3.MessageType, e3, "app_approved");

                    Log.Information("Message  {MessageType} with Id {MessageId} has been published successfully", e3.MessageType, e3.MessageId);

                }
                catch (Exception ex)
                {
                    //throw ex;
                    Log.Error(ex, "Error while handling {MessageType} message with id {MessageId}.", e3.MessageType, e3.MessageId);

                }
               
                //await _messagePublisher.PublishMessageAsync(e.MessageType, e, "rental_created.*");
            }


            return await Unit.Task;
        }

        
    }
}
