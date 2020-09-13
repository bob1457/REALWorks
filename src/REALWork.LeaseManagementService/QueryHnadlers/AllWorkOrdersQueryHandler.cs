using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class AllWorkOrdersQueryHandler : IRequestHandler<AllWorkOrdersQuery, IQueryable<WorkOrderListViewModel>>
    {
        private readonly AppLeaseManagementDbContext _context;

        public AllWorkOrdersQueryHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<WorkOrderListViewModel>> Handle(AllWorkOrdersQuery request, CancellationToken cancellationToken)
        {
            var workOrders = _context.WorkOrder
                .Include(w => w.Vendor)
                .Include(w => w.RentalProperty)
                .Select(wo => new WorkOrderListViewModel
                {
                    Id = wo.Id,
                    WorkOrderName = wo.WorkOrderName,
                    WorkOrderCategory = wo.WorkOrderCategory,
                    WorkOrderType = wo.WorkOrderType,
                    WorkOrderStatus = wo.WorkOrderStatus,
                    StartDate = wo.StartDate,
                    EndDate = wo.EndDate,
                    VendorName = wo.Vendor.VendorBusinessName,
                    VendorId = wo.Vendor.Id,
                    RentalPropertyId = wo.RentalProperty.Id,
                    RentalPropertyName = wo.RentalProperty.PropertyName,
                    Created = wo.Created,
                    Updated = wo.Modified
                    

                });

            return workOrders.AsQueryable();
                

            //throw new NotImplementedException();
        }
    }
}
