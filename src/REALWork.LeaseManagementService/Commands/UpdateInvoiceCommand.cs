using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.Commands
{
    public class UpdateInvoiceCommand : IRequest<Unit>
    {
        public int InvoiceId { get; set; }
        public bool IsPaid { get; set; }
        public DateTime PaymentDate { get; set; }
        public string PaymentMethod { get; set; }
        public decimal PaymentAmount { get; set; }
        public int WorkOrderId { get; set; }
    }
}
