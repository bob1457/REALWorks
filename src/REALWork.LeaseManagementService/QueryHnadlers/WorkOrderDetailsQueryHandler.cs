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
    public class WorkOrderDetailsQueryHandler : IRequestHandler<WorkOrderDetailsQuery, WorkOrderDetailsViewModel>
    {
        private readonly AppLeaseManagementDbContext _context;

        public WorkOrderDetailsQueryHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }

        public async Task<WorkOrderDetailsViewModel> Handle(WorkOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var workOrder = _context.WorkOrder
                                    .Include(w => w.Vendor)
                                    .Include(w => w.RentalProperty)
                                    .FirstOrDefault(w => w.Id == request.Id);

            var orderDetails = new WorkOrderDetailsViewModel();

            orderDetails.WorkOrderName = workOrder.WorkOrderName;
            orderDetails.WorkOrderCategory = workOrder.WorkOrderCategory;
            orderDetails.StartDate = workOrder.StartDate;
            orderDetails.EndDate = workOrder.EndDate;
            orderDetails.WorkOrderStatus = workOrder.WorkOrderStatus;
            orderDetails.RentalProperty = workOrder.RentalProperty;
            orderDetails.Vendor = workOrder.Vendor;
            orderDetails.IsEmergency = workOrder.IsEmergency;
            orderDetails.IsOwnerAuthorized = workOrder.IsOwnerAuthorized;
            orderDetails.WorkOrderType = workOrder.WorkOrderType;
            orderDetails.WorkOrderDetails = workOrder.WorkOrderDetails;
            orderDetails.Id = workOrder.Id;
            orderDetails.Created = workOrder.Created;
            orderDetails.Updated = workOrder.Modified;



            return orderDetails;

            //throw new NotImplementedException();
        }
    }
}
