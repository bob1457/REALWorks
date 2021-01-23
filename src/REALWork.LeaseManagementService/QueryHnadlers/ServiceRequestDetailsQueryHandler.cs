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
    public class ServiceRequestDetailsQueryHandler : IRequestHandler<ServiceRequestDetailsQuery, ServiceRequest>
    {
        private readonly AppLeaseManagementDbContext _context;

        public ServiceRequestDetailsQueryHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceRequest> Handle(ServiceRequestDetailsQuery request, CancellationToken cancellationToken)
        {
            var serviceRequest = _context.Request
                .Include(r => r.Lease)
                .ThenInclude(l => l.RentalProperty)
                .ThenInclude(p => p.WorkOrder).ToList();

            return serviceRequest.FirstOrDefault(r => r.Id == request.Id);

            //throw new NotImplementedException();
        }
    }
}
