using MediatR;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.CommandHandlers
{
    public class UpdateTenantCommandHandler : IRequestHandler<UpdateTenantCommand, Unit>
    {
        private readonly AppLeaseManagementDbContext _context;

        public UpdateTenantCommandHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }


        public async Task<Unit> Handle(UpdateTenantCommand request, CancellationToken cancellationToken)
        {
            var lease = _context.Lease.FirstOrDefault(l => l.Id == request.LeaseId);

            var tenant = _context.Tenant.FirstOrDefault(t => t.Id == request.TenantId);

            var updatedTenant = lease.UpdateTenant(tenant, request.FirstName, request.LastName, request.ContactEmail, request.ContactTelephone1,
                request.ContactTelephone2, request.ContactOthers);

            _context.Tenant.Update(updatedTenant);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return await Unit.Task;

            //throw new NotImplementedException();
        }
    }
}
