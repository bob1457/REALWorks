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
    public class AllLeaseListQueryHandler : IRequestHandler<AllLeaseListQuery, IQueryable<Lease>>
    {
        private readonly AppLeaseManagementDbContext _context;

        public AllLeaseListQueryHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<Lease>> Handle(AllLeaseListQuery request, CancellationToken cancellationToken)
        {
            var leaseList = _context.Lease.Include(p => p.RentalProperty).Include(t => t.Tenant).ToList();

            return leaseList.AsQueryable();

            //throw new NotImplementedException();
        }
    }
}
