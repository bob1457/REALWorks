using MediatR;
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
    public class UpdateInvoiceCommandHandler : IRequestHandler<UpdateInvoiceCommand, Unit>
    {
        private readonly AppLeaseManagementDbContext _context;

        public UpdateInvoiceCommandHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var workOrder = _context.WorkOrder.FirstOrDefault(w => w.Id == request.InvoiceId);

            var invoice = _context.Invoice.FirstOrDefault(i => i.Id == request.InvoiceId);

            var updated = workOrder.UpdateInvoice(invoice, request.PaymentAmount, request.PaymentDate, request.IsPaid, request.PaymentMethod);

            _context.Invoice.Update(updated);

            try
            {
                await _context.SaveChangesAsync(); // comment out for testing message sending ONLY
                Log.Information("The invoce {Invoice} for workorder {WorkOrder} has been updated .", invoice.InvoiceTitle, workOrder.WorkOrderName);
            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error while adding the invoice {Invoice} to workorder {WorkOrder}.", invoice.InvoiceTitle, workOrder.WorkOrderName);
            }

            return await Unit.Task;

            //throw new NotImplementedException();
        }
    }
}
