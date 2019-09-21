using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWork.LeaseManagementCore.Entities;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.Queries;
using REALWork.LeaseManagementService.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.QueryHnadlers
{
    public class TenantDetailsQueryHandler : IRequestHandler<TenantDetailsQuery, Tenant>
    {
        private readonly AppLeaseManagementDbContext _context;

        public TenantDetailsQueryHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Tenant> Handle(TenantDetailsQuery request, CancellationToken cancellationToken)
        {
            var tenant = _context.Tenant.Include(l => l.Lease).ThenInclude(p => p.RentalProperty).FirstOrDefault(t => t.Id == request.Id);

            return tenant;

            //throw new NotImplementedException();
        }
    }
}
