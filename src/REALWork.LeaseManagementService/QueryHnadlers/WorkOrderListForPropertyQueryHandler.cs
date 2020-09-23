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
    public class WorkOrderListForPropertyQueryHandler : IRequestHandler<WorkOrderListForPropertyQuery, IQueryable<WorkOrderListViewModel>>
    {
        private readonly AppLeaseManagementDbContext _context;

        public WorkOrderListForPropertyQueryHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<WorkOrderListViewModel>> Handle(WorkOrderListForPropertyQuery request, CancellationToken cancellationToken)
        {
            var orderListForProperty = _context.WorkOrder
                .Include(w => w.RentalProperty)
                .ThenInclude(p => p.Lease)
                .Select(o => new WorkOrderListViewModel {
                    Id = o.Id,
                    WorkOrderName = o.WorkOrderName,
                    WorkOrderCategory = o.WorkOrderCategory,
                    WorkOrderType = o.WorkOrderType,
                    VendorName = o.Vendor.VendorBusinessName,
                    WorkOrderStatus = o.WorkOrderStatus,
                    StartDate = o.StartDate,
                    EndDate = o.EndDate
                })
                .Where(p => p.RentalPropertyId == request.PropertyId).ToList();

            return orderListForProperty.AsQueryable();

            //throw new NotImplementedException();
        }
    }
}
