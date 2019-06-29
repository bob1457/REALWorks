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
    public class RentalDetailsForReportingQueryHandler : IRequestHandler<RentalDetailsForReportingQuery, Lease>
    {
        private readonly AppLeaseManagementDbContext _context;

        public RentalDetailsForReportingQueryHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }

        public Task<Lease> Handle(RentalDetailsForReportingQuery request, CancellationToken cancellationToken)
        {
            //var reault = _context.Lease.FirstOrDefault(l => l.Id == request.LeaseId).Include()


            throw new NotImplementedException();
        }
    }
}
