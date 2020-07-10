using MediatR;
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
    public class AlNewTenantsListQueryHandler : IRequestHandler<AlNewTenantsListQuery, IQueryable<NewTenant>>
    {
        private readonly AppLeaseManagementDbContext _context;

        public AlNewTenantsListQueryHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<NewTenant>> Handle(AlNewTenantsListQuery request, CancellationToken cancellationToken)
        {
            var newTenants = _context.NewTenant;

            return newTenants;

            //throw new NotImplementedException();
        }
    }
}
