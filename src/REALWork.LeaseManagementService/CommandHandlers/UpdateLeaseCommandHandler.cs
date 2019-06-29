using MediatR;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.Commands;
using REALWorks.MessagingServer.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.CommandHandlers
{
    public class UpdateLeaseCommandHandler : IRequestHandler<UpdateLeaseCommand, Unit>
    {
        private readonly AppLeaseManagementDbContext _context;

        IMessagePublisher _messagePublisher;

        public UpdateLeaseCommandHandler(AppLeaseManagementDbContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        public async Task<Unit> Handle(UpdateLeaseCommand request, CancellationToken cancellationToken)
        {
            var lease = _context.Lease.FirstOrDefault(l => l.Id == request.LeaseId);

            lease.Update(request.LeaseTitle, request.LeaseDesc, request.LeaseStartDate, request.LeaseEndDate, 
                request.Term, request.RentFrequency, request.RentDueOn, request.DamageDepositAmount, request.PetDepositAmount,
                request.LeaseSignDate, request.IsActive, request.IsAddendumAvailable, request.LeaseEndCode, request.RenewTerm);

            _context.Lease.Update(lease);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //throw new NotImplementedException();

            return await Unit.Task;
        }
    }
}
