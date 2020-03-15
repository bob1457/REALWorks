using MediatR;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.Commands;
using REALWorks.MessagingServer.Messages;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.CommandHandlers
{
    public class UpdateRentalPropertyStatusCommandHandler : IRequestHandler<UpdateRentalPropertyStatusCommand, Unit>
    {
        private readonly AppLeaseManagementDbContext _context;

        IMessagePublisher _messagePublisher;

        public UpdateRentalPropertyStatusCommandHandler(AppLeaseManagementDbContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        public async Task<Unit> Handle(UpdateRentalPropertyStatusCommand request, CancellationToken cancellationToken)
        {
            var lease = _context.Lease.FirstOrDefault(l => l.Id == request.LeaseId);

            var property = _context.RentalProperty.FirstOrDefault(p => p.Id == lease.RentalPropertyId);

            var updatedPpty = lease.UpdatePropertyStatus(property, request.RentalPropertyStatus);

            _context.RentalProperty.Update(updatedPpty);

            try
            {
                await _context.SaveChangesAsync(); // comment out for testing message sending ONLY


                // Send message to MQ 
                //

                // Logging
                Log.Information("The rental property status has been updated {PropertyName} to {status} successfully", property.PropertyName, request.RentalPropertyStatus);

            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error while updating status of {PropertyName} to status {LeaseTile}.", property.PropertyName, request.RentalPropertyStatus);
            }

            return await Unit.Task;
            //throw new NotImplementedException();
        }
    }
}
