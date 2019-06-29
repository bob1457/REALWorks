using MediatR;
using Microsoft.EntityFrameworkCore;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.Commands;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.CommandHandlers
{
    public class UpdateWorkOrderCommandHandler : IRequestHandler<UpdateWorkOrderCommand, Unit>
    {
        private readonly AppLeaseManagementDbContext _context;

        public UpdateWorkOrderCommandHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateWorkOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _context.WorkOrder.Include(p => p.RentalProperty).FirstOrDefault(w => w.Id == request.WorkOrderId);

            

            var updated = order.Update(request.WorkOrderDetails, request.WorkOrderCategory, request.WorkOrderType, 
                request.StartDate, request.EndDate, request.WorkOrderStatus, request.Note);

            _context.WorkOrder.Update(updated);

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


            return await Unit.Task;

            //throw new NotImplementedException();
        }
    }
}
