using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static REALWorks.AssetCore.Entities.FeePayment;

namespace REALWorks.AssetServer.Commands
{
    public class AddFeePaymentCommand : IRequest<Unit>
    {
        public int ManagementContractId { get;  set; }
        public decimal ScheduledPaymentAmt { get;  set; }
        public decimal ActualPaymentAmt { get;  set; }
        public PaymentMethod PayMethod { get;  set; }
        public FeeType MangementFeeType { get;  set; }
        public DateTime PaymentDueDate { get;  set; }
        public DateTime PaymentReceivedDate { get;  set; }
        //public decimal? Balance { get;  set; }
        public bool IsOnTime { get;  set; }
        public int InChargeOwnerId { get;  set; }
        public string Note { get;  set; }
        public string FeeForMonth { get;  set; }
        public string FeeForYear { get;  set; }
    }
}
