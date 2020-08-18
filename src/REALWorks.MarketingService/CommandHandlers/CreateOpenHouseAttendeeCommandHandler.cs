using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWorks.MarketingCore.Entities;
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

namespace REALWorks.MarketingService.CommandHandlers
{
    public class CreateOpenHouseAttendeeCommandHandler : IRequestHandler<CreateOpenHouseAttendeeCommand, bool>
    {
        private readonly AppMarketingDbDataContext _context;

        IMessagePublisher _messagePublisher;

        public CreateOpenHouseAttendeeCommandHandler(AppMarketingDbDataContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        public async Task<bool> Handle(CreateOpenHouseAttendeeCommand request, CancellationToken cancellationToken)
        {
            var oh = _context.OpenHouse.Include(o => o.RentalProperty).FirstOrDefault(o => o.Id == request.OpenHouseId);

            var attendee = new OpenHouseViewer(request.OpenHouseId, request.FirstName, request.LastName, 
                request.ContactTel, request.ContactEmail, request.NumberOfPeople, request.ContactType, DateTime.Now, DateTime.Now);

            _context.OpenHouseViewer.Add(attendee);

            try
            {
                await _context.SaveChangesAsync();

                // Send message to message queue for notification
                //
                Log.Information("New Open House Attendee {Name} has been created successfully", request.FirstName + " " + request.LastName);

                // Sending notification??? by sending integration message to RabbitMQ for notification service to pickup and send notificaiotn

                string recipient = "";
                string subject = "Open House Registration"; 
             
                string body = "";

                string service = "Marketing Service";

                switch (Convert.ToInt32(request.ContactType))
                {
                    case 1:
                        body = "Dear " + request.FirstName + ": you have registered for " + oh.RentalProperty.PropertyName + ". Best regards.";
                        recipient = request.ContactEmail;
                        break;
                    case 2:
                        body = "Dear " + request.FirstName + ": you have registered for " + oh.RentalProperty.PropertyName + ". Best regards.";
                        recipient = request.ContactTel;
                        //if (request.ContactSms != null)
                        //{
                        //    recipient = request.ContactSms; 
                        //}
                        //else
                        //{
                        //    // throw errror 
                        //    recipient = request.ContactTel;
                        //}
                        break;
                    default:
                        break;
                }

                NotificationEvent e = new NotificationEvent(new Guid(), recipient, Convert.ToInt32(request.ContactType), subject, body, service, DateTime.Now);

                try
                {
                    await _messagePublisher.PublishMessageAsync(e.MessageType, e, "notification"); // publishing the message

                    Log.Information("Open house registration from {Applicant} has been sent successfully from {service}", request.FirstName + " " + request.LastName, service);
                }
                catch (Exception ex)
                {

                    throw ex;
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
