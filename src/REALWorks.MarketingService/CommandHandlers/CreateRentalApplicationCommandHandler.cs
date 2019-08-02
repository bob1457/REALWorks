﻿using MediatR;
using REALWorks.MarketingCore.Entities;
using REALWorks.MarketingData;
using REALWorks.MarketingService.Commands;
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
                request.EmpoyedStatus, request.ReasonToMove, DateTime.Now, DateTime.Now);

            await _context.AddAsync(applicant);

            var application = new RentalApplication(request.RentalPropertyId, applicant, request.AppStatus, DateTime.Now, DateTime.Now);

            await _context.AddAsync(application);

            application.AddApplicant(applicant);

            try
            {
                await _context.SaveChangesAsync();

                Log.Information("New Applicatn from {ApplicantName} with Id {ApplicantId} has been created successfully", request.FirstName + request.LastName, applicant.Id);
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