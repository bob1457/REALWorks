using MediatR;
using REALWork.LeaseManagementCore.Entities;
using System;

namespace REALWork.LeaseManagementService.Commands
{
    public class AddInvoiceToWorkOrderCommand : IRequest<Invoice>
    {
        public string InvoiceTitle { get; set; }
        public decimal InvoiceAmount { get;  set; }
        public string InvoiceDocUrl { get;  set; }
        public DateTime InvoiceDate { get;  set; }
        public bool IsPaid { get;  set; }
        public DateTime PaymentDate { get;  set; }
        public string PaymentMethod { get;  set; }
        public decimal? PaymentAmount { get;  set; }
        public int WorkOrderId { get;  set; }
    }
}
