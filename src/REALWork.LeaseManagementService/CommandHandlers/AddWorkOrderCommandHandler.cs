using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWork.LeaseManagementCore.Entities;
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
    public class AddWorkOrderCommandHandler : IRequestHandler<AddWorkOrderCommand, WorkOrderListViewModel>
    {

        private readonly AppLeaseManagementDbContext _context;

        public AddWorkOrderCommandHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }

        public async Task<WorkOrderListViewModel> Handle(AddWorkOrderCommand request, CancellationToken cancellationToken)
        {

            var property = _context.RentalProperty.FirstOrDefault(p => p.Id == request.RentalPropertyId);

            var workOrder = property.AddWorkOrder(request.WorkOrderName, request.WorkOrderDetails, request.WorkOrderCategory, request.RentalPropertyId,
                request.VendorId, request.WorkOrderType, request.StartDate, request.EndDate, request.IsOwnerAuthorized, request.IsEmergency, request.WorkOrderStatus,
                request.Note);

            _context.WorkOrder.Add(workOrder);

            var newWorkOrder = new WorkOrderListViewModel();

            try
            {
                await _context.SaveChangesAsync(); // comment out for testing message sending ONLY

                Log.Information("Then work order  {WorkOrder} has been added successfully", workOrder.WorkOrderName);
            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error while adding the workorder {WorkOrder}.", workOrder.WorkOrderName);
            }


            var serviceReq = _context.Request.FirstOrDefault(r => r.Id == request.ServiceRequestId);

            var lease = _context.Lease.Include(l => l.ServiceRequest).FirstOrDefault(l => l.RentalPropertyId == property.Id);

            var updatedReq = lease.UpdateServiceRequest(serviceReq, 2, workOrder.Id);

            _context.Request.Update(updatedReq);



            newWorkOrder.Id = workOrder.Id;
            newWorkOrder.WorkOrderName = workOrder.WorkOrderName;
            newWorkOrder.StartDate = null;
            newWorkOrder.EndDate = null;
            newWorkOrder.WorkOrderType = workOrder.WorkOrderType;
            newWorkOrder.IsEmergency = workOrder.IsEmergency;
            newWorkOrder.WorkOrderStatus = workOrder.WorkOrderStatus;
            newWorkOrder.Created = workOrder.Created;
            newWorkOrder.Updated = workOrder.Modified;

            try
            {
                await _context.SaveChangesAsync();

                Log.Information("Then service request  {ServiceRequest} has been updated successfully", serviceReq.RequestSubject);
            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error while updating the service request {ServiceRequest}.", serviceReq.RequestSubject);
            }
            

            return newWorkOrder;

            //throw new NotImplementedException();
        }
    }
}
