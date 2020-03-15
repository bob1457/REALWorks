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
    public class WorkOrderListForPropertyQueryHandler : IRequestHandler<WorkOrderListForPropertyQuery, IQueryable<WorkOrder>>
    {
        private readonly AppLeaseManagementDbContext _context;

        public WorkOrderListForPropertyQueryHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<WorkOrder>> Handle(WorkOrderListForPropertyQuery request, CancellationToken cancellationToken)
        {
            var orderListForProperty = _context.WorkOrder.Where(p => p.RentalPropertyId == request.PropertyId).ToList();

            return orderListForProperty.AsQueryable();

            //throw new NotImplementedException();
        }
    }
}
