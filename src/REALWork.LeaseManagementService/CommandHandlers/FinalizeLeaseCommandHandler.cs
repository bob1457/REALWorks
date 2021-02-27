using MediatR;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.Commands;
using REALWork.LeaseManagementService.Events;
using REALWorks.MessagingServer.Messages;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.CommandHandlers
{
    public class FinalizeLeaseCommandHandler : IRequestHandler<FinalizeLeaseCommand, Unit>
    {
        private readonly AppLeaseManagementDbContext _context;

        IMessagePublisher _messagePublisher;

        public FinalizeLeaseCommandHandler(AppLeaseManagementDbContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        public async Task<Unit> Handle(FinalizeLeaseCommand request, CancellationToken cancellationToken)
        {
            var lease = _context.Lease.FirstOrDefault(l => l.Id == request.LeaseId);

            var rentalproeprty = _context.RentalProperty.FirstOrDefault(p => p.Id == lease.RentalPropertyId);

            var updated = lease.Finalize(request.LeaseSignDate);

            rentalproeprty.StatusUpdate("Rented");

            _context.RentalProperty.Update(rentalproeprty);

            _context.Lease.Update(updated);

            try
            {
                await _context.SaveChangesAsync(); // comment out for testing message sending ONLY


                // Send message to MQ 
                //
                LeaseFinalizedEvent e = new LeaseFinalizedEvent(Guid.NewGuid(), /*rentalproeprty.ListinglId,*/ rentalproeprty.OriginalId);

                try
                {
                    await _messagePublisher.PublishMessageAsync(e.MessageType, e, "lease_finalized"); // publishing the message
                    Log.Information("Message  {MessageType} with Id {MessageId} has been published successfully", e.MessageType, e.MessageId);
                }
                catch (Exception ex)
                {
                    Log.Error(ex, "Error while handling {MessageType} message with id {MessageId}.", e.MessageType, e.MessageId);
                }

                // Logging
                Log.Information("The lease {LeaseName} been finalized, signed on {SignDate}", lease.LeaseTitle, updated.LeaseSignDate);

            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error while finalizign the lease {LeaseTile}.", lease.LeaseTitle);
            }

            return await Unit.Task;

            //throw new NotImplementedException();
        }
    }
}
