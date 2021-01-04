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
            //var workOrder = _context.WorkOrder
            //                        .Include(w => w.Vendor)
            //                        .Include(w => w.RentalProperty)
            //                        .FirstOrDefault(w => w.Id == request.Id);

            //var orderDetails = new WorkOrderDetailsViewModel();

            //orderDetails.WorkOrderName = workOrder.WorkOrderName;
            //orderDetails.WorkOrderCategory = workOrder.WorkOrderCategory;
            //orderDetails.StartDate = workOrder.StartDate;
            //orderDetails.EndDate = workOrder.EndDate;
            //orderDetails.WorkOrderStatus = workOrder.WorkOrderStatus;
            //orderDetails.RentalProperty = workOrder.RentalProperty;
            //orderDetails.Vendor = workOrder.Vendor;
            //orderDetails.IsEmergency = workOrder.IsEmergency;
            //orderDetails.IsOwnerAuthorized = workOrder.IsOwnerAuthorized;
            //orderDetails.WorkOrderType = workOrder.WorkOrderType;
            //orderDetails.WorkOrderDetails = workOrder.WorkOrderDetails;
            //orderDetails.Id = workOrder.Id;
            //orderDetails.VendorId = workOrder.Vendor.Id;
            //orderDetails.RentalPropertyId = workOrder.RentalProperty.Id;
            //orderDetails.Created = workOrder.Created;
            //orderDetails.Updated = workOrder.Modified;

            var workOrder = (from w in _context.WorkOrder
                             join r in _context.Request on w.ServiceRequestId equals r.Id
                             join p in _context.RentalProperty on w.RentalPropertyId equals p.Id
                             join v in _context.Vendor on w.VendorId equals v.Id
                             where w.Id == request.Id
                             select new WorkOrderDetailsViewModel
                             {
                                 WorkOrderName = w.WorkOrderName,
                                 WorkOrderCategory = w.WorkOrderCategory,
                                 StartDate = w.StartDate,
                                 EndDate = w.EndDate,
                                 WorkOrderStatus = w.WorkOrderStatus,
                                 WorkOrderType = w.WorkOrderType,
                                 WorkOrderDetails = w.WorkOrderDetails,
                                 IsEmergency = w.IsEmergency,
                                 IsOwnerAuthorized = w.IsOwnerAuthorized,
                                 RentalProperty = p,
                                 RentalPropertyId = p.Id,
                                 VendorId = v.Id,
                                 Vendor = v,
                                 ServiceRequestId = r.Id,
                                 Id = w.Id,
                                 ServiceRequest = r,
                                 Created = w.Created,
                                 Updated = w.Modified
                                 
                             });


            return workOrder.FirstOrDefault();

            //throw new NotImplementedException();
        }
    }
}
