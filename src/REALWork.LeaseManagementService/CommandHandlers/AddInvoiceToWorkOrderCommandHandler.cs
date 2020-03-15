using MediatR;
using REALWork.LeaseManagementCore.Entities;
using REALWork.LeaseManagementData;
using REALWork.LeaseManagementService.Commands;
using Serilog;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.CommandHandlers
{
    public class AddInvoiceToWorkOrderCommandHandler : IRequestHandler<AddInvoiceToWorkOrderCommand, Invoice>
    {
        private readonly AppLeaseManagementDbContext _context;

        public AddInvoiceToWorkOrderCommandHandler(AppLeaseManagementDbContext context)
        {
            _context = context;
        }

        public async Task<Invoice> Handle(AddInvoiceToWorkOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _context.WorkOrder.FirstOrDefault(w => w.Id == request.WorkOrderId);

            var invoice = order.AddInvoice(request.InvoiceTitle, request.InvoiceAmount, request.InvoiceDate, request.IsPaid, request.PaymentDate, 
                request.PaymentMethod, request.PaymentAmount, request.WorkOrderId);

            _context.Invoice.Add(invoice);

            try
            {
                await _context.SaveChangesAsync(); // comment out for testing message sending ONLY
                Log.Information("The invoce {Invoice} has been added to the workorder {WorkOrder}.", invoice.InvoiceTitle, order.WorkOrderName);
            }
            catch (Exception ex)
            {
                //throw ex;
                Log.Error(ex, "Error while adding the invoice {Invoice} to workorder {WorkOrder}.", invoice.InvoiceTitle, order.WorkOrderName);
            }

            return invoice;

            //throw new NotImplementedException();
        }
    }
}
