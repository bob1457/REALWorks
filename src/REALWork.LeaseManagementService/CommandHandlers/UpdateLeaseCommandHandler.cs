using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWork.LeaseManagementCore.ValueObjects;
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
    public class UpdateLeaseCommandHandler : IRequestHandler<UpdateLeaseCommand, UpdateLeaseAgreementViewModel>
    {
        private readonly AppLeaseManagementDbContext _context;

        IMessagePublisher _messagePublisher;

        public UpdateLeaseCommandHandler(AppLeaseManagementDbContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        public async Task<UpdateLeaseAgreementViewModel> Handle(UpdateLeaseCommand request, CancellationToken cancellationToken)
        {
            var lease = _context.Lease
                .Include(p => p.RentalProperty)
                .Include(l => l.RentCoverage)
                .Include(t => t.Tenant).ToList()                
                .FirstOrDefault(l => l.Id == request.Id);

            var coverage = new RentCoverage(request.Water, request.Cablevison, request.Electricity, request.Internet, request.Heat, 
                                            request.NaturalGas, request.SewageDisposal, request.SnowRemoval, request.Storage, request.RecreationFacility,
                                            request.GarbageCollection, request.RecycleServices, request.KitchenScrapCollection, request.Laundry, 
                                            /*request.FreeLaundry, */request.Regigerator, request.Dishwasher, request.StoveOven, request.WindowCovering, 
                                            request.Furniture, request.Carpets, request.ParkingStall, request.Other);
            //lease.RentCoverage;


            var property = lease.RentalProperty;
            var tenants = lease.Tenant;

            lease.Update(request.LeaseTitle, request.LeaseDesc, request.LeaseStartDate, request.LeaseEndDate, 
                request.Term, request.RentFrequency, request.RentAmount, request.RentDueOn, request.DamageDepositAmount, request.PetDepositAmount,
                request.LeaseSignDate, request.IsActive, request.IsAddendumAvailable, request.LeaseEndCode, request.RenewTerm,
                request.Notes, coverage);

            _context.Lease.Update(lease);

            var updatedLease = new UpdateLeaseAgreementViewModel();

            updatedLease.LeaseTitle = request.LeaseTitle;
            updatedLease.LeaseDesc = request.LeaseDesc;
            updatedLease.LeaseStartDate = request.LeaseStartDate;
            updatedLease.LeaseId = request.Id;
            updatedLease.LeaseEndDate = request.LeaseEndDate;
            updatedLease.RentAmount = request.RentAmount;
            updatedLease.DamageDepositAmount = request.DamageDepositAmount;
            updatedLease.PetDepositAmount = request.PetDepositAmount;
            updatedLease.Term = request.Term;
            updatedLease.RenewTerm = request.RenewTerm;
            updatedLease.LeaseSignDate = request.LeaseSignDate;
            updatedLease.IsActive = request.IsActive;
            updatedLease.IsAddendumAvailable = request.IsAddendumAvailable;
            updatedLease.LeaseEndCode = request.LeaseEndCode;
            updatedLease.Notes = request.Notes;
            updatedLease.Created = DateTime.Now;
            updatedLease.Updated = DateTime.Now;
            updatedLease.rentCoverage = coverage;
            updatedLease.rentalProperty = lease.RentalProperty;
            updatedLease.Tenant = tenants.ToList();

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
