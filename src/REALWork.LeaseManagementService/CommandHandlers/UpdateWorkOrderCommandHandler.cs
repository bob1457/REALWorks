using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.Commands;
using REALWork.LeaseManagementService.ViewModels;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.CommandHandlers
{
    public class UpdateWorkOrderCommandHandler : IRequestHandler<UpdateWorkOrderCommand, WorkOrderUpdateResultViewModel>
    {
        private readonly AppLeaseManagementDbContext _context;

        public UpdateWorkOrderCommandHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }

        public async Task<WorkOrderUpdateResultViewModel> Handle(UpdateWorkOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _context.WorkOrder
                .Include(p => p.RentalProperty).FirstOrDefault(w => w.Id == request.WorkOrderId);           



            var updated = order.Update(request.WorkOrderDetails, request.WorkOrderCategory, request.WorkOrderType, 
                request.StartDate, request.EndDate, request.WorkOrderStatus, request.Note);

            _context.WorkOrder.Update(updated);

            /**/ 

            try
            {
                await _context.SaveChangesAsync(); // comment out for testing message sending ONLY
                Log.Information("The work oreder {WorkOrder} for rental property {RentalProperty} has been updated .", order.WorkOrderName, order.RentalProperty.PropertyName);
            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error while updating the work order {WorkOrder} tfor rental property {RentalProperty}.", order.WorkOrderName, order.RentalProperty.PropertyName);
            }

            var updatedOrder = (from w in _context.WorkOrder
                                join r in _context.Request on w.ServiceRequestId equals r.Id
                                join p in _context.RentalProperty on w.RentalPropertyId equals p.Id
                                join v in _context.Vendor on w.VendorId equals v.Id
                                where w.Id == order.Id
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

                                }).FirstOrDefault();

            // update status of related Service Request

            var req = _context.Request.FirstOrDefault(r => r.Id == updatedOrder.ServiceRequestId);

            var lease = _context.Lease.FirstOrDefault(l => l.Id == req.LeaseId);

            int serviceReqStatus = 0;

            switch(updatedOrder.WorkOrderStatus)
            {
                case "New":
                    serviceReqStatus = 1;
                    break;
                case "Opened":
                    serviceReqStatus = 2;
                    break;
                case "In Progress":
                    serviceReqStatus = 3;
                    break;
                case "On Holde":
                    serviceReqStatus = 4;
                    break;
                case "Completed":
                    serviceReqStatus = 5;
                    break;
                case "Other":
                    serviceReqStatus = 6;
                    break;
                default:
                    serviceReqStatus = 0;
                    break;

            }

            var updatedReq = lease.UpdateServiceRequest(req, serviceReqStatus, request.WorkOrderId);

            _context.Request.Update(updatedReq);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //

            var newlyUpdated = new WorkOrderUpdateResultViewModel();

            newlyUpdated.Id = updatedOrder.Id;
            newlyUpdated.WorkOrderName = updatedOrder.WorkOrderName;
            newlyUpdated.WorkOrderDetails = updatedOrder.WorkOrderDetails;
            newlyUpdated.WorkOrderCategory = updatedOrder.WorkOrderCategory;
            newlyUpdated.WorkOrderStatus = updatedOrder.WorkOrderStatus;
            newlyUpdated.WorkOrderType = updatedOrder.WorkOrderType;
            newlyUpdated.Created = updatedOrder.Created;
            newlyUpdated.Updated = updatedOrder.Updated;
            newlyUpdated.IsEmergency = updatedOrder.IsEmergency;
            newlyUpdated.IsOwnerAuthorized = updatedOrder.IsOwnerAuthorized;
            newlyUpdated.Note = updatedOrder.Note;
            newlyUpdated.StartDate = updatedOrder.StartDate;
            newlyUpdated.EndDate = updatedOrder.EndDate;
            newlyUpdated.RentalProperty = updatedOrder.RentalProperty;
            newlyUpdated.ServiceRequest = updatedOrder.ServiceRequest;
            newlyUpdated.Vendor = updatedOrder.Vendor;


            return newlyUpdated;

            //throw new NotImplementedException();
        }
    }
}
