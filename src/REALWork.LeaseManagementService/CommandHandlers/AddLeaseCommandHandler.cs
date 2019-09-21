using MediatR;
using REALWork.LeaseManagementCore.Entities;
using REALWork.LeaseManagementCore.ValueObjects;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.Commands;
using REALWork.LeaseManagementService.ViewModels;
using REALWorks.MessagingServer.Messages;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.CommandHandlers
{
    public class AddLeaseCommandHandler : IRequestHandler<AddLeaseCommand, AddLeaseAgreementViewModel>
    {
        private readonly AppLeaseManagementDbContext _context;

        IMessagePublisher _messagePublisher;

        public AddLeaseCommandHandler(AppLeaseManagementDbContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }


        public async Task<AddLeaseAgreementViewModel> Handle(AddLeaseCommand request, CancellationToken cancellationToken)
        {
            // Teant data is in the entity NewTeant, Rental Property and Address data is in the Entity RentalProperty based on RentalPropertyId in Lease entity

            var newTenant = _context.NewTenant.FirstOrDefault(n => n.Id == request.NewTenantId);

            var tenant = new Tenant(newTenant.UserName, newTenant.FirstName, newTenant.LastName, newTenant.ContactEmail, newTenant.ContactTelephone1, newTenant.ContactTelephone2,
                newTenant.ContactOthers, request.OnlineAccessEnbaled, request.UserAvartaImgUrl, 3, true, DateTime.Now, DateTime.Now);

            var rentalCoverage = new RentCoverage(request.Water, request.Cablevison, request.Electricity, request.Internet, request.Heat, request.NaturalGas,
                request.SewageDisposal, request.SnowRemoval, request.Storage, request.RecreationFacility, request.GarbageCollection, request.RecreationFacility,
                request.KitchenScrapCollection, request.Laundry, request.FreeLaundry, request.Regfrigerator, request.Dishwasher, request.StoveOven,
                request.WindowCovering, request.Furniture, request.Carpets, request.ParkingStall, request.Other);

            var agent = new Agent(request.AgentFirstName, request.AgentLastName, request.AgentContactEmail, request.ContatTel, request.Other, request.IsPropertyManager, request.AddressStreetNumber,
                request.AddressCity, request.AddressStateProv, request.AddressZipPostCode, request.AddressCountry);

            var agents = new List<Agent>();
            var tenants = new List<Tenant>();

            agents.Add(agent);
            tenants.Add(tenant);

            var lease = new Lease(request.LeaseTitle, request.LeaseDesc, request.RentalPropertyId, request.LeaseStartDate, request.LeaseEndDate, request.Term, 
                request.RentFrequency, request.RentAmount, request.RentDueOn, request.DamageDepositAmount, request.PetDepositAmount, request.LeaseSignDate,
                request.LeaseAgreementDocUrl, true, request.IsAddendumAvailable, request.LeaseEndCode, request.RenewTerm,  DateTime.Now, DateTime.Now, request.Notes, rentalCoverage, agents, tenants);

            _context.Add(lease);

            var addedLease = new AddLeaseAgreementViewModel();

            addedLease.LeaseTitle = request.LeaseTitle;
            addedLease.LeaseDesc = request.LeaseDesc;
            addedLease.LeaseStartDate = request.LeaseStartDate;
            //...
            addedLease.LeaseEndDate = request.LeaseEndDate;
            addedLease.RentAmount = request.RentAmount;
            addedLease.DamageDepositAmount = request.DamageDepositAmount;
            addedLease.PetDepositAmount = request.PetDepositAmount;
            addedLease.Term = request.Term;
            addedLease.RenewTerm = request.RenewTerm;
            addedLease.LeaseSignDate = request.LeaseSignDate;
            addedLease.IsActive = request.IsActive;
            addedLease.IsAddendumAvailable = request.IsAddendumAvailable;
            addedLease.EndLeaseCode = request.LeaseEndCode;
            addedLease.Notes = request.Notes;
            addedLease.Created = DateTime.Now;
            addedLease.Updated = DateTime.Now;



            try
            {
                await _context.SaveChangesAsync(); // comment out for testing message sending ONLY

                addedLease.LeaseId = lease.Id;


                // Send message to MQ if needed
                //

                // Logging
                Log.Information("New lease agreement  {LeaseTile} has been created successfully", lease.LeaseTitle);

            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error while creating lease {LeaseTile}.", lease.LeaseTitle);
            }

            return addedLease;
        }
    }
}
