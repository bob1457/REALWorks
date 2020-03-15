using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWork.LeaseManagementCore.Entities;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.QueryHnadlers
{
    public class AllTenantListQueryHandler : IRequestHandler<AllTenantListQuery, IQueryable<Tenant>>
    {
        private readonly AppLeaseManagementDbContext _context;

        public AllTenantListQueryHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Tenant>> Handle(AllTenantListQuery request, CancellationToken cancellationToken)
        {
            var tenantList = _context.Tenant.Include(l => l.Lease).ThenInclude(p => p.RentalProperty);

            return tenantList.AsQueryable();

            //throw new NotImplementedException();
        }
    }
}
