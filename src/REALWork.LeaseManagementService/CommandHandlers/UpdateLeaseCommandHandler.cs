using MediatR;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.Commands;
using REALWork.LeaseManagementService.ViewModels;
using REALWorks.MessagingServer.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.CommandHandlers
{
    public class UpdateLeaseCommandHandler : IRequestHandler<UpdateLeaseCommand, AddLeaseAgreementViewModel>
    {
        private readonly AppLeaseManagementDbContext _context;

        IMessagePublisher _messagePublisher;

        public UpdateLeaseCommandHandler(AppLeaseManagementDbContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        public async Task<AddLeaseAgreementViewModel> Handle(UpdateLeaseCommand request, CancellationToken cancellationToken)
        {
            var lease = _context.Lease.FirstOrDefault(l => l.Id == request.LeaseId);

            lease.Update(request.LeaseTitle, request.LeaseDesc, request.LeaseStartDate, request.LeaseEndDate, 
                request.Term, request.RentFrequency, request.RentDueOn, request.DamageDepositAmount, request.PetDepositAmount,
                request.LeaseSignDate, request.IsActive, request.IsAddendumAvailable, request.LeaseEndCode, request.RenewTerm);

            _context.Lease.Update(lease);

            var updatedLease = new AddLeaseAgreementViewModel();

            updatedLease.LeaseTitle = request.LeaseTitle;
            updatedLease.LeaseDesc = request.LeaseDesc;
            updatedLease.LeaseStartDate = request.LeaseStartDate;
            updatedLease.LeaseId = request.LeaseId;
            updatedLease.LeaseEndDate = request.LeaseEndDate;
            updatedLease.RentAmount = request.RentAmount;
            updatedLease.DamageDepositAmount = request.DamageDepositAmount;
            updatedLease.PetDepositAmount = request.PetDepositAmount;
            updatedLease.Term = request.Term;
            updatedLease.RenewTerm = request.RenewTerm;
            updatedLease.LeaseSignDate = request.LeaseSignDate;
            updatedLease.IsActive = request.IsActive;
            updatedLease.IsAddendumAvailable = request.IsAddendumAvailable;
            updatedLease.EndLeaseCode = request.LeaseEndCode;
            updatedLease.Notes = request.Notes;
            updatedLease.Updated = DateTime.Now;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //throw new NotImplementedException();

            return updatedLease;
        }
    }
}
