using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace REALWork.LeaseManagementService.Commands
{
    public class UpdateRentPaymentCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public bool IsOnTime { get; set; }
        public decimal RentAmount { get; set; }
        public DateTime PaymentReceivedDate { get; set; }
        public string Note { get; set; }
    }
}
