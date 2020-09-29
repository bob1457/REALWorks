using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.Commands;
using REALWork.LeaseManagementService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.CommandHandlers
{
    public class UpdateTenantCommandHandler : IRequestHandler<UpdateTenantCommand, UpdateTenantViewModel>
    {
        private readonly AppLeaseManagementDbContext _context;

        public UpdateTenantCommandHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }


        public async Task<UpdateTenantViewModel> Handle(UpdateTenantCommand request, CancellationToken cancellationToken)
        {
            var lease = _context.Lease.Include(l => l.RentalProperty).FirstOrDefault(l => l.Id == request.LeaseId);

            var tenant = _context.Tenant.FirstOrDefault(t => t.Id == request.Id);

            var updatedTenant = lease.UpdateTenant(tenant, request.FirstName, request.LastName, request.ContactEmail, request.ContactTelephone1,
                request.ContactTelephone2, request.ContactOthers);

            _context.Tenant.Update(updatedTenant);

            UpdateTenantViewModel updated = new UpdateTenantViewModel();

            updated.Id = request.Id;
            updated.FirstName = request.FirstName;
            updated.LastName = request.LastName;
            updated.OnlineAccessEnbaled = updatedTenant.OnlineAccessEnbaled;
            updated.IsActive = updatedTenant.IsActive;
            updated.ContactTelephone1 = updatedTenant.ContactTelephone1;
            updated.ContactTelephone2 = updatedTenant.ContactTelephone2;
            updated.ContactOthers = updatedTenant.ContactOthers;
            updated.ContactEmail = updatedTenant.ContactEmail;
            updated.UserAvartaImgUrl = updatedTenant.UserAvartaImgUrl;
            updated.Created = updatedTenant.Created;
            updated.Modified = updatedTenant.Modified;


            updated.Lease = lease;
            updated.RentalProperty = lease.RentalProperty;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return updated;

            //throw new NotImplementedException();
        }
    }
}
