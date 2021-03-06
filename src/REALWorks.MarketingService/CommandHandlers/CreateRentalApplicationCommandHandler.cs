﻿using MediatR;
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
    public class CreateRentalApplicationCommandHandler : IRequestHandler<CreateRentalApplicationCommand, bool>
    {
        private readonly AppMarketingDbDataContext _context;

        IMessagePublisher _messagePublisher;

        public CreateRentalApplicationCommandHandler(AppMarketingDbDataContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        public async Task<bool> Handle(CreateRentalApplicationCommand request, CancellationToken cancellationToken)
        {
            var applicant = new RentalApplicant(request.FirstName, request.LastName, request.ContactTel, request.ContactEmail,
                request.ContactSms, request.ContactOthers, request.AnnualIncome, request.NumberOfOccupant, request.WithChildren, request.Status,
                request.EmpoyedStatus, request.CreditRating, request.ReasonToMove, DateTime.Now, DateTime.Now);

            await _context.AddAsync(applicant);

            var application = new RentalApplication(request.RentalPropertyId, applicant, request.AppStatus, /*request.NotificaitonType,*/ DateTime.Now, DateTime.Now);

            await _context.AddAsync(application);

            application.AddApplicant(applicant);

            try
            {
                await _context.SaveChangesAsync(); // commented out for testing only

                Log.Information("New Applicatn from {ApplicantName} with Id {ApplicantId} has been created successfully", request.FirstName + " " + request.LastName, applicant.Id);

                // Sending notification??? by sending integration message to RabbitMQ for notification service to pickup and send notificaiotn

                string recipient = "";
                string subject = "Rental Applicaiton Received";
                //string body = "Your application has been successfully submitted!"; // for testing purpose, To be improved
                //string bodyContent = 
                //    "@Dear {name}: " +
                //    "Your application for teancy has been recieved." +
                //    "Please prepare to provide required reference materials for the screening process." +
                //    "Thanks." +
                //    "Property Manager";

                //string body = string.Format(bodyContent, request.FirstName + " " + request.LastName);
                string body = "";

                string service = "Marketing Service";

                

                switch (request.NotificationType)
                {
                    case 1:
                        body = "Dear " + request.FirstName + ": your application has been received. Best regards.";
                        recipient = request.ContactEmail;                        
                        break;
                    case 2:
                        body = "Dear " + request.FirstName + ": your application has been received. Best regards.";
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

                //EmailNotificationEvent e = new EmailNotificationEvent(new Guid(), recipients, request.NotificaitonType, subject, body, service, DateTime.Now);

                NotificationEvent e = new NotificationEvent(new Guid(), recipient, request.NotificationType, subject, body, service, DateTime.Now);

                try
                {
                    await _messagePublisher.PublishMessageAsync(e.MessageType, e, "notification"); // publishing the message

                    Log.Information("Rental application submissin from  {Applicant} has been sent successfully from {service}", request.FirstName + " " + request.LastName, service);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error while creating  new applicant for {ApplicantName}", request.FirstName + request.LastName);
            }


            return true;

            //throw new NotImplementedException();
        }
    }
}
