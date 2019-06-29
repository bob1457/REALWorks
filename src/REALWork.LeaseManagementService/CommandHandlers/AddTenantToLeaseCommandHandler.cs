using MediatR;
using REALWork.LeaseManagementCore.Entities;
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
    public class AddTenantToLeaseCommandHandler : IRequestHandler<AddTenantToLeaseCommand, Unit>
    {
        private readonly AppLeaseManagementDbContext _context;

        IMessagePublisher _messagePublisher;

        public AddTenantToLeaseCommandHandler(AppLeaseManagementDbContext context, IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }

        public async Task<Unit> Handle(AddTenantToLeaseCommand request, CancellationToken cancellationToken)
        {
            var existingLease = _context.Lease.FirstOrDefault(l => l.Id == request.LeaseId);
            object tenant;

            if(request.NewTenantId != 0) // newTenant exists and approved
            {
                var newTenant = _context.NewTenant.FirstOrDefault(n => n.Id == request.NewTenantId);

                tenant = new Tenant(newTenant.UserName, newTenant.FirstName, newTenant.LastName, newTenant.ContactEmail, newTenant.ContactTelephone1, newTenant.ContactTelephone2,
                newTenant.ContactOthers, request.OnlineAccessEnbaled, request.UserAvartaImgUrl, 3, true, request.LeaseId, DateTime.Now, DateTime.Now);

                
            }
            else
            {
                tenant = new Tenant(request.UserName, request.FirstName, request.LastName, request.ContactEmail, request.ContactTelephone1, request.ContactTelephone2,
                request.ContactOthers, request.OnlineAccessEnbaled, request.UserAvartaImgUrl, 3, true, request.LeaseId, DateTime.Now, DateTime.Now);
            }

            _context.Tenant.Add((Tenant)tenant);

            try
            {
                await _context.SaveChangesAsync(); // comment out for testing message sending ONLY


                // Send message to MQ if needed
                //

                // Logging
                Log.Information("New tenant {TenantName} has been added to the lease agreement  {LeaseTile} has been created successfully", request.FirstName, existingLease.LeaseTitle);

            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error while add tenant {TenantName} to lease {LeaseTile}.", request.FirstName, existingLease.LeaseTitle);
            }
            //throw new NotImplementedException();

            return await Unit.Task;
        }
    }
}
